using Sandbox.Game;
using Sandbox.Game.Entities;
using Sandbox.Game.Entities.Character.Components;
using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRage.Game;
using VRage.Game.Components;
using VRage.Game.ModAPI;
using VRage.Utils;
using VRageMath;
using static VRageRender.MyBillboard;

namespace ExtendedSurvival.Stats
{

    [MySessionComponentDescriptor(MyUpdateOrder.AfterSimulation)]
    public class ExtendedSurvivalStatsSession : BaseSessionComponent
    {

        public static ExtendedSurvivalStatsSession Static { get; private set; }

        public const string ES_TECHNOLOGY_LOCALNAME = "SEExtendedSurvival-Technology";

        public const ulong ES_TECHNOLOGY_MODID = 2842844421;

        private static bool? isUsingTechnology = null;
        public static bool IsUsingTechnology()
        {
            if (!isUsingTechnology.HasValue)
                isUsingTechnology = MyAPIGateway.Session.Mods.Any(x => x.PublishedFileId == ES_TECHNOLOGY_MODID || x.Name == ES_TECHNOLOGY_LOCALNAME);
            return isUsingTechnology.Value;
        }

        public HudAPIv2 TextAPI;
        public ExtendedSurvivalCoreAPI ESCoreAPI;

        public const ushort NETWORK_ID_STATSSYSTEM = 40522;
        public const ushort NETWORK_ID_COMMANDS = 40523;
        public const ushort NETWORK_ID_DEFINITIONS = 40524;
        public const ushort NETWORK_ID_ENTITYCALLS = 40525;
        public const string CALL_FOR_DEFS = "NEEDDEFS";

        protected override void DoInit(MyObjectBuilder_SessionComponent sessionComponent)
        {

            Static = this;

            if (!IsDedicated)
            {
                MyAPIGateway.Utilities.MessageEntered += OnMessageEntered;
                MyAPIGateway.Multiplayer.RegisterSecureMessageHandler(NETWORK_ID_STATSSYSTEM, ClientUpdateMsgHandler);
            }

            if (IsServer)
            {

                MyAPIGateway.Multiplayer.RegisterSecureMessageHandler(NETWORK_ID_COMMANDS, CommandsMsgHandler);

                MyAPIGateway.Session.DamageSystem.RegisterAfterDamageHandler(0, (entity, damage) =>
                {
                    if (entity != null)
                    {
                        var character = entity as IMyCharacter;
                        if (character != null)
                        {
                            if (character.IsValidPlayer())
                            {
                                if (ExtendedSurvivalStatsEntityManager.Instance.PlayerCharacters.ContainsKey(character.EntityId))
                                    ExtendedSurvivalStatsEntityManager.Instance.PlayerCharacters[character.EntityId].OnReciveDamage(damage);
                            }
                            else
                            {
                                if (ExtendedSurvivalStatsEntityManager.Instance.BotCharacters.ContainsKey(character.EntityId))
                                    ExtendedSurvivalStatsEntityManager.Instance.BotCharacters[character.EntityId].OnReciveDamage(damage);
                            }
                        }
                    }
                });

                MyAPIGateway.Session.SessionSettings.AutoHealing = false; /* Remove auto healing to control at playerentity */
                MyAPIGateway.Session.SessionSettings.WeatherSystem = true; /* multiple systens use weather */

                ForceWolfAndSpiders();

                MyAPIGateway.Multiplayer.RegisterSecureMessageHandler(NETWORK_ID_DEFINITIONS, ClientDefinitionsUpdateServerMsgHandler);

            }
            else
            {

                MyAPIGateway.Multiplayer.RegisterSecureMessageHandler(NETWORK_ID_DEFINITIONS, ClientDefinitionsUpdateMsgHandler);
                Command cmd = new Command(MyAPIGateway.Multiplayer.MyId, CALL_FOR_DEFS);
                string message = MyAPIGateway.Utilities.SerializeToXML<Command>(cmd);
                MyAPIGateway.Multiplayer.SendMessageToServer(
                    NETWORK_ID_DEFINITIONS,
                    Encoding.Unicode.GetBytes(message)
                );

            }

        }

        private const string SETTINGS_COMMAND = "settings";
        private const string SETTINGS_COMMAND_PLAYER_STATUS = "player.setstatus";
        private const string SETTINGS_COMMAND_PLAYER_RESETSTATUS = "player.resetstatus";

        private static readonly Dictionary<string, KeyValuePair<int, bool>> VALID_COMMANDS = new Dictionary<string, KeyValuePair<int, bool>>()
        {
            { SETTINGS_COMMAND, new KeyValuePair<int, bool>(3, false) },
            { SETTINGS_COMMAND_PLAYER_STATUS, new KeyValuePair<int, bool>(3, true) },
            { SETTINGS_COMMAND_PLAYER_RESETSTATUS, new KeyValuePair<int, bool>(1, true) }
        };

        private void ClientUpdateMsgHandler(ushort netId, byte[] data, ulong steamId, bool fromServer)
        {
            try
            {
                if (netId != NETWORK_ID_STATSSYSTEM)
                    return;

                var message = Encoding.Unicode.GetString(data);
                var mPlayerData = MyAPIGateway.Utilities.SerializeFromXML<PlayerSendData>(message);

                if (mPlayerData.NeedToUpdateLocal)
                {
                    if (MyAPIGateway.Session.Player != null && MyAPIGateway.Session.Player.Character != null)
                    {
                        var OxygenComponent = MyAPIGateway.Session.Player.Character.Components.Get<MyCharacterOxygenComponent>();
                        OxygenComponent.SuitOxygenLevel = mPlayerData.O2Level;
                        var Inventory = MyAPIGateway.Session.Player.Character.GetInventory() as MyInventory;
                        if (Inventory != null)
                        {
                            if ((float)Inventory.MaxVolume != mPlayerData.CurrentCargoVolume)
                            {
                                var definition = new MyInventoryComponentDefinition
                                {
                                    RemoveEntityOnEmpty = false,
                                    MultiplierEnabled = false,
                                    MaxItemCount = int.MaxValue,
                                    Mass = mPlayerData.CurrentCargoMass,
                                    Volume = mPlayerData.CurrentCargoVolume,
                                    InputConstraint = new MyInventoryConstraint("PlayerInventory", null, false)
                                };
                                Inventory.Init(definition);
                            }
                        }
                    }
                    else
                    {
                        ExtendedSurvivalStatsLogging.Instance.LogWarning(GetType(), $"ClientUpdateMsgHandler MyAPIGateway.Session.Player || Character is NULL");
                    }
                }

            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(GetType(), ex);
            }

        }

        private void DoCommand_Settings(string name, string value)
        {
            ExtendedSurvivalSettings.Instance.SetConfigValue(name, value);
        }

        private void DoCommand_PlayerStat(string name, string value, string player, ulong steamId)
        {
            PlayerCharacterEntity playerChar = null;
            if (!string.IsNullOrWhiteSpace(player))
            {
                playerChar = ExtendedSurvivalStatsEntityManager.Instance.PlayerCharacters.Values.FirstOrDefault(x => x.Player?.DisplayName.CompareTo(player) == 0);
            }
            else
            {
                playerChar = ExtendedSurvivalStatsEntityManager.Instance.GetPlayerCharacterBySteamId(steamId);
            }
            if (playerChar != null)
            {
                float targetValue;
                if (float.TryParse(value, out targetValue))
                {
                    playerChar.SetCharacterStatValue(name, targetValue);
                }
            }
        }

        private void DoCommand_PlayerReset(string player, ulong steamId)
        {
            PlayerCharacterEntity playerChar = null;
            if (!string.IsNullOrWhiteSpace(player))
            {
                playerChar = ExtendedSurvivalStatsEntityManager.Instance.PlayerCharacters.Values.FirstOrDefault(x => x.Player?.DisplayName.CompareTo(player) == 0);
            }
            else
            {
                playerChar = ExtendedSurvivalStatsEntityManager.Instance.GetPlayerCharacterBySteamId(steamId);
            }
            if (playerChar != null)
            {
                playerChar.ResetCharacterStats();
            }
        }

        private void CommandsMsgHandler(ushort netId, byte[] data, ulong steamId, bool fromServer)
        {
            try
            {
                var message = Encoding.Unicode.GetString(data);
                var mCommandData = MyAPIGateway.Utilities.SerializeFromXML<Command>(message);
                if (MyAPIGateway.Session.IsUserAdmin(steamId))
                {
                    if (VALID_COMMANDS.ContainsKey(mCommandData.content[0]))
                    {
                        if ((!VALID_COMMANDS[mCommandData.content[0]].Value && mCommandData.content.Length == VALID_COMMANDS[mCommandData.content[0]].Key) ||
                            (VALID_COMMANDS[mCommandData.content[0]].Value && mCommandData.content.Length >= VALID_COMMANDS[mCommandData.content[0]].Key))
                        {
                            switch (mCommandData.content[0])
                            {
                                case SETTINGS_COMMAND:
                                    DoCommand_Settings(
                                        mCommandData.content[1], 
                                        mCommandData.content[2]
                                    );
                                    break;
                                case SETTINGS_COMMAND_PLAYER_STATUS:
                                    DoCommand_PlayerStat(
                                        mCommandData.content[1],
                                        mCommandData.content[2],
                                        mCommandData.content.Length >= 4 ? mCommandData.content[3] : null,
                                        mCommandData.sender
                                    );
                                    break;
                                case SETTINGS_COMMAND_PLAYER_RESETSTATUS:
                                    DoCommand_PlayerReset(
                                        mCommandData.content.Length >= 2 ? mCommandData.content[1] : null,
                                        mCommandData.sender
                                    );
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(GetType(), ex);
            }
        }

        private void OnMessageEntered(string messageText, ref bool sendToOthers)
        {
            sendToOthers = true;
            if (!messageText.StartsWith("/")) return;
            var words = messageText.Trim().ToLower().Replace("/", "").Split(' ');
            if (words.Length > 0)
            {
                if (VALID_COMMANDS.ContainsKey(words[0]))
                {
                    if ((!VALID_COMMANDS[words[0]].Value && words.Length == VALID_COMMANDS[words[0]].Key) ||
                        (VALID_COMMANDS[words[0]].Value && words.Length >= VALID_COMMANDS[words[0]].Key))
                    {
                        sendToOthers = false;
                        Command cmd = new Command(MyAPIGateway.Multiplayer.MyId, words);
                        string message = MyAPIGateway.Utilities.SerializeToXML<Command>(cmd);
                        MyAPIGateway.Multiplayer.SendMessageToServer(
                            NETWORK_ID_COMMANDS,
                            Encoding.Unicode.GetBytes(message)
                        );
                    }
                }
            }
        }

        private void ClientDefinitionsUpdateServerMsgHandler(ushort netId, byte[] data, ulong steamId, bool fromServer)
        {
            try
            {
                if (netId != NETWORK_ID_DEFINITIONS)
                    return;

                var message = Encoding.Unicode.GetString(data);
                var mCommandData = MyAPIGateway.Utilities.SerializeFromXML<Command>(message);
                if (IsServer)
                {

                    switch (mCommandData.content[0])
                    {
                        default:
                            Command cmd = new Command(0, CALL_FOR_DEFS);
                            cmd.data = Encoding.Unicode.GetBytes(ExtendedSurvivalSettings.Instance.GetDataToClient());
                            string messageToSend = MyAPIGateway.Utilities.SerializeToXML<Command>(cmd);
                            MyAPIGateway.Multiplayer.SendMessageTo(
                                NETWORK_ID_DEFINITIONS,
                                Encoding.Unicode.GetBytes(messageToSend),
                                mCommandData.sender
                            );
                            break;
                    }

                }

            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(GetType(), ex);
            }
        }

        private void ClientDefinitionsUpdateMsgHandler(ushort netId, byte[] data, ulong steamId, bool fromServer)
        {
            try
            {
                if (netId != NETWORK_ID_DEFINITIONS)
                    return;

                var message = Encoding.Unicode.GetString(data);
                var mCommandData = MyAPIGateway.Utilities.SerializeFromXML<Command>(message);
                if (IsClient)
                {
                    var settingsData = Encoding.Unicode.GetString(mCommandData.data);
                    ExtendedSurvivalSettings.ClientLoad(settingsData);
                    CheckDefinitions();
                }

            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(GetType(), ex);
            }
        }

        private bool HasIce(Guid observerId)
        {
            return HasItem(observerId, ItensConstants.ICE_ID);
        }

        private bool HasItem(Guid observerId, UniqueEntityId id)
        {
            if (ExtendedSurvivalCoreAPI.Registered)
                return ExtendedSurvivalCoreAPI.HasItemInObserver(observerId, id.DefinitionId);
            return false;
        }

        private bool HasAnyFertilizer(Guid observerId)
        {
            foreach (var item in FarmConstants.FERTILIZERS)
            {
                if (HasItem(observerId, item))
                    return true;
            }
            return false;
        }

        public override void SaveData()
        {
            base.SaveData();

            if (IsServer)
            {
                try
                {
                    foreach (var key in ExtendedSurvivalStatsEntityManager.Instance.PlayerCharacters.Keys)
                    {
                        var player = ExtendedSurvivalStatsEntityManager.Instance.PlayerCharacters[key];
                        ExtendedSurvivalStorage.Instance.SetPlayerData(player.GetStoreData());
                    }
                }
                catch (Exception ex)
                {
                    ExtendedSurvivalStatsLogging.Instance.LogError(GetType(), ex);
                }

                ExtendedSurvivalSettings.Save();
                ExtendedSurvivalStorage.Save();
            }
        }

        private static List<Action> InvokeAfterCoreApiLoaded = new List<Action>();
        public static void AddToInvokeAfterCoreApiLoaded(Action action)
        {
            if (!ExtendedSurvivalCoreAPI.Registered)
                InvokeAfterCoreApiLoaded.Add(action);
        }

        public override void LoadData()
        {

            if (IsServer)
            {
                ExtendedSurvivalSettings.Load();
                ExtendedSurvivalStorage.Load();
                CheckDefinitions();
            }

            TextAPI = new HudAPIv2();
            ESCoreAPI = new ExtendedSurvivalCoreAPI(()=> {
                if (IsServer)
                {
                    if (ExtendedSurvivalCoreAPI.Registered)
                    {

                        ExtendedSurvivalCoreAPI.AddExtraStartLoot(ItensConstants.BODYTRACKER_ID.DefinitionId, 1);
                        ExtendedSurvivalCoreAPI.AddExtraStartLoot(ItensConstants.WATER_FLASK_SMALL_ID.DefinitionId, 5);
                        ExtendedSurvivalCoreAPI.AddExtraStartLoot(ItensConstants.CEREALBAR_ID.DefinitionId, 10);
                        ExtendedSurvivalCoreAPI.AddExtraStartLoot(ItensConstants.BANDAGES_ID.DefinitionId, 3);
                        ExtendedSurvivalCoreAPI.AddExtraStartLoot(ItensConstants.HEALTHINJECTION_ID.DefinitionId, 1);

                        ExtendedSurvivalCoreAPI.AddGasSpoilInfo(
                            LivestockConstants.CREATURE_HEALTH,
                            LivestockConstants.FEED_TIME_CICLE,
                            LivestockConstants.BASE_HUNGRY_FACTOR,
                            LivestockConstants.BASE_TOLERANCE_TIME,
                            (Guid observerId) =>
                            {
                                return true;
                            }
                        );
                        ExtendedSurvivalCoreAPI.AddGasSpoilInfo(
                            LivestockConstants.TREE_HEALTH,
                            FarmConstants.BASE_TIME_TO_PRODUCE,
                            FarmConstants.BASE_TREE_DECAY_FACTOR,
                            FarmConstants.BASE_TOLERANCE_TIME,
                            (Guid observerId) =>
                            {
                                return !HasIce(observerId) || !HasAnyFertilizer(observerId);
                            }
                        );
                        foreach (var itemKey in FoodConstants.FOOD_DEFINITIONS.Where(x => x.Value.NeedConservation))
                        {
                            ExtendedSurvivalCoreAPI.AddItemExtraInfo(itemKey.Value.GetItemExtraInfo());
                        }
                        foreach (var itemKey in LivestockConstants.LIVESTOCK_DEFINITIONS)
                        {
                            ExtendedSurvivalCoreAPI.AddItemExtraInfo(itemKey.Value.GetItemExtraInfo());
                        }
                        foreach (var itemKey in FishingConstants.FISHS_DEFINITIONS)
                        {
                            ExtendedSurvivalCoreAPI.AddItemExtraInfo(itemKey.Value.GetItemExtraInfo());
                        }
                        foreach (var itemKey in ItensConstants.ITEM_EXTRA_INFO_DEF.Keys)
                        {
                            ExtendedSurvivalCoreAPI.AddItemExtraInfo(ItensConstants.ITEM_EXTRA_INFO_DEF[itemKey]);
                        }                        
                        ExtendedSurvivalCoreAPI.AddItemCategory(LivestockConstants.ANIMAL_CATEGORY);
                        foreach (var animalId in LivestockConstants.ANIMALS_IDS)
                        {
                            ExtendedSurvivalCoreAPI.AddDefinitionToCategory(animalId.DefinitionId, LivestockConstants.ANIMAL_CATEGORY);
                        }
                        ExtendedSurvivalCoreAPI.AddTreeDropLoot(new ExtendedSurvivalCoreAPI.TreeDropLoot(ItensConstants.CEREAL_ID.DefinitionId, new Vector2(15, 50), 50));
                        ExtendedSurvivalCoreAPI.AddTreeDropLoot(new ExtendedSurvivalCoreAPI.TreeDropLoot(ItensConstants.APPLE_ID.DefinitionId, new Vector2(2, 6), 25) { AlowDesert = false });
                        ExtendedSurvivalCoreAPI.AddTreeDropLoot(new ExtendedSurvivalCoreAPI.TreeDropLoot(SeedsAndFertilizerConstants.APPLETREESEEDLING_ID.DefinitionId, new Vector2(1, 1), 50) { AlowDesert = false, IsGas = true });
                    
                        if (InvokeAfterCoreApiLoaded.Any())
                            foreach (var action in InvokeAfterCoreApiLoaded)
                            {
                                action.Invoke();
                            }
                    }
                }
            });

            base.LoadData();
        }

        private bool definitionsChecked = false;
        private void CheckDefinitions()
        {
            ExtendedSurvivalStatsLogging.Instance.LogInfo(GetType(), $"CheckDefinitions Called");
            if (!definitionsChecked)
            {
                definitionsChecked = true;

                DefinitionUtils.ChangeInventoryContainerType("deer_bot", "DeerLoot");
                DefinitionUtils.ChangeInventoryContainerType("deerbuck_bot", "DeerLoot");
                DefinitionUtils.ChangeInventoryContainerType("Cow_Bot", "CowLoot");
                DefinitionUtils.ChangeInventoryContainerType("Sheep_Bot", "SheepLoot");
                DefinitionUtils.ChangeInventoryContainerType("Horse_Bot", "HorseLoot");

                DefinitionUtils.ReplaceContainerTypeDefinition("WolfLoot", new Vector2I(2, 3), true, GetAnimalLoot());
                DefinitionUtils.ReplaceContainerTypeDefinition("DeerLoot", new Vector2I(2, 3), true, GetAnimalLoot(2));
                DefinitionUtils.ReplaceContainerTypeDefinition("CowLoot", new Vector2I(2, 3), true, GetAnimalLoot(3));
                DefinitionUtils.ReplaceContainerTypeDefinition("SheepLoot", new Vector2I(2, 3), true, GetAnimalLoot());
                DefinitionUtils.ReplaceContainerTypeDefinition("HorseLoot", new Vector2I(2, 3), true, GetAnimalLoot(2));
                DefinitionUtils.ReplaceContainerTypeDefinition("SpiderLoot", new Vector2I(2, 4), true, GetSpiderLoot());

                DefinitionUtils.ReplaceContainerTypeDefinition("PersonalContainerSmall", new Vector2I(2, 5), false, GetUnknownSignalLoot());

                DefinitionUtils.ChangeStatValue("AnimalHealth", new Vector3(0, 150, 150));
                DefinitionUtils.ChangeStatValue("Health", new Vector3(0, 250, 250));
                DefinitionUtils.ChangeStatValue("SpaceCharacterHealth", new Vector3(0, 250, 250));
                DefinitionUtils.ChangeStatValue("WolfHealth", new Vector3(0, 250, 250));
                DefinitionUtils.ChangeStatValue("SpiderHealth", new Vector3(0, 500, 500));

                var creatureCharacters = new string[] { "Space_Wolf", "Space_spider", "deer_bot", "deerbuck_bot", "Cow_Bot", "Sheep_Bot", "Horse_Bot" };
                foreach (var character in creatureCharacters)
                {
                    foreach (StatsConstants.CreatureValidStats stat in Enum.GetValues(typeof(StatsConstants.CreatureValidStats)).Cast<StatsConstants.CreatureValidStats>())
                    {
                        DefinitionUtils.AddStatToCharacter(stat.ToString(), character);
                    }
                }

                var playerCharacters = new string[] { "Default_Astronaut", "Default_Astronaut_Female" };
                foreach (var character in playerCharacters)
                {
                    foreach (StatsConstants.ValidStats stat in Enum.GetValues(typeof(StatsConstants.ValidStats)).Cast<StatsConstants.ValidStats>())
                    {
                        DefinitionUtils.AddStatToCharacter(stat.ToString(), character);
                    }
                }

                // ITENS OVERRIDES
                FoodConstants.TryOverrideDefinitions();
                MedicalConstants.TryOverrideDefinitions();
                RationConstants.TryOverrideDefinitions();
                LivestockConstants.TryOverrideDefinitions();
                EquipmentConstants.TryOverrideDefinitions();
                SeedsAndFertilizerConstants.TryOverrideDefinitions();
                FishingConstants.TryOverrideDefinitions();
                WeaponsConstants.TryOverrideDefinitions();
                QuimicalConstants.TryOverrideDefinitions();
                HerbsConstants.TryOverrideDefinitions();
                RecipientConstants.TryOverrideDefinitions();
                OreConstants.TryOverrideDefinitions();
                IngotsConstants.TryOverrideDefinitions();
                FactionTypeConstants.TryOverrideDefinitions();

                // SPAWNS
                SpawnGroupOverride.SetDefinitions();

                // BLOCKS
                DescriptionBlocksOverride.TryOverride();
                AssemblerOverride.TryOverride();

                //HUD
                HUDOverride.TryOverride();

            }
        }

        private MyObjectBuilder_ContainerTypeDefinition.ContainerTypeItem[] GetUnknownSignalLoot(float multiplier = 1f)
        {
            return new MyObjectBuilder_ContainerTypeDefinition.ContainerTypeItem[]
            {
                DefinitionUtils.GetLootItem(new Vector2(1, 5).GetMultiplier(multiplier), ItensConstants.BANDAGES_ID, 0.1f),
                DefinitionUtils.GetLootItem(new Vector2(1, 5).GetMultiplier(multiplier), SeedsAndFertilizerConstants.CARROT_SEEDS_ID, 0.1f),
                DefinitionUtils.GetLootItem(new Vector2(1, 5).GetMultiplier(multiplier), SeedsAndFertilizerConstants.MINT_SEEDS_ID, 0.1f),
                DefinitionUtils.GetLootItem(new Vector2(1, 5).GetMultiplier(multiplier), SeedsAndFertilizerConstants.ARNICA_SEEDS_ID, 0.1f),
                DefinitionUtils.GetLootItem(new Vector2(1, 5).GetMultiplier(multiplier), SeedsAndFertilizerConstants.BROCCOLI_SEEDS_ID, 0.1f),
                DefinitionUtils.GetLootItem(new Vector2(1, 5).GetMultiplier(multiplier), SeedsAndFertilizerConstants.COFFEE_SEEDS_ID, 0.1f),
                DefinitionUtils.GetLootItem(new Vector2(1, 5).GetMultiplier(multiplier), SeedsAndFertilizerConstants.TOMATO_SEEDS_ID, 0.1f),
                DefinitionUtils.GetLootItem(new Vector2(1, 5).GetMultiplier(multiplier), SeedsAndFertilizerConstants.WHEAT_SEEDS_ID, 0.1f),
                DefinitionUtils.GetLootItem(new Vector2(1, 5).GetMultiplier(multiplier), SeedsAndFertilizerConstants.CHAMOMILE_SEEDS_ID, 0.1f),
                DefinitionUtils.GetLootItem(new Vector2(1, 5).GetMultiplier(multiplier), SeedsAndFertilizerConstants.ALOEVERA_SEEDS_ID, 0.1f),
                DefinitionUtils.GetLootItem(new Vector2(1, 5).GetMultiplier(multiplier), SeedsAndFertilizerConstants.ERYTHROXYLUM_SEEDS_ID, 0.1f)
            };
        }

        private MyObjectBuilder_ContainerTypeDefinition.ContainerTypeItem[] GetAnimalLoot(float multiplier = 1f)
        {
            return new MyObjectBuilder_ContainerTypeDefinition.ContainerTypeItem[]
            {
                DefinitionUtils.GetLootItem(new Vector2(6, 12).GetMultiplier(multiplier), ItensConstants.MEAT_ID, 6),
                DefinitionUtils.GetLootItem(new Vector2(3, 6).GetMultiplier(multiplier), ItensConstants.NOBLE_MEAT_ID, 1),
                DefinitionUtils.GetLootItem(new Vector2(10, 20).GetMultiplier(multiplier), OreConstants.BONES_ID, 3)
            };
        }

        private MyObjectBuilder_ContainerTypeDefinition.ContainerTypeItem[] GetSpiderLoot(float multiplier = 1f)
        {
            return new MyObjectBuilder_ContainerTypeDefinition.ContainerTypeItem[]
            {
                DefinitionUtils.GetLootItem(new Vector2(12, 24).GetMultiplier(multiplier), ItensConstants.ALIEN_MEAT_ID, 6),
                DefinitionUtils.GetLootItem(new Vector2(6, 12).GetMultiplier(multiplier), ItensConstants.ALIEN_NOBLE_MEAT_ID, 1),
                DefinitionUtils.GetLootItem(new Vector2(20, 40).GetMultiplier(multiplier), OreConstants.BONES_ID, 3),
                DefinitionUtils.GetLootItem(new Vector2(4, 8).GetMultiplier(multiplier), ItensConstants.ALIEN_EGG_ID, 2)
            };
        }

        protected override void UnloadData()
        {
            TextAPI.Close();
            ESCoreAPI.Unregister();

            if (!IsDedicated)
                MyAPIGateway.Multiplayer.UnregisterSecureMessageHandler(NETWORK_ID_STATSSYSTEM, ClientUpdateMsgHandler);

            if (IsServer)
                MyAPIGateway.Multiplayer.UnregisterSecureMessageHandler(NETWORK_ID_COMMANDS, CommandsMsgHandler);

            base.UnloadData();
        }

        private static void ForceWolfAndSpiders()
        {
            try
            {
                MyAPIGateway.Session.SessionSettings.EnableSpiders = true;
                MyAPIGateway.Session.SessionSettings.EnableWolfs = true;
            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(typeof(ExtendedSurvivalStatsSession), ex);
            }
        }

        protected override void DoUpdate()
        {
            base.DoUpdate();

            try
            {

                if (IsServer)
                {

                    ForceWolfAndSpiders();

                    foreach (var item in ExtendedSurvivalStatsEntityManager.Instance.PlayerCharacters.Where(x => x.Value.PlayerId > 0 && x.Value.Entity != null && !x.Value.Entity.IsDead))
                    {
                        var player = item.Value;
                        player.ProcessUnderwater(RunCount);
                        if (ExtendedSurvivalStatsEntityManager.Instance.Players.ContainsKey(player.PlayerId))
                        {
                            try
                            {
                                var data = player.GetData();
                                if (data != null)
                                {
                                    string message = MyAPIGateway.Utilities.SerializeToXML<PlayerSendData>(data);
                                    MyAPIGateway.Multiplayer.SendMessageTo(
                                        NETWORK_ID_STATSSYSTEM,
                                        Encoding.Unicode.GetBytes(message),
                                        ExtendedSurvivalStatsEntityManager.Instance.Players[player.PlayerId].SteamUserId
                                    );
                                }
                            }
                            catch (Exception ex)
                            {
                                ExtendedSurvivalStatsLogging.Instance.LogError(GetType(), ex);
                                if (ex.Message.Contains("There was an error generating the XML document"))
                                {
                                    // To prevent server crash is better to kill this player
                                    if (player != null && player.Entity != null)
                                    {
                                        player.Entity.Kill();
                                        player.RemoveDiedRoutine();
                                    }
                                }
                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(GetType(), ex);
            }

        }

        protected override void DoUpdate60()
        {
            base.DoUpdate60();

            if (MyAPIGateway.Session.IsServer)
            {

                PlayersUpdate();

            }
        }

        private void PlayersUpdate()
        {
            try
            {
                foreach (var key in ExtendedSurvivalStatsEntityManager.Instance.PlayerCharacters.Keys)
                {
                    var player = ExtendedSurvivalStatsEntityManager.Instance.PlayerCharacters[key];
                    if (!player.IsValid || player.IsDead)
                        continue;

                    player.ProcessActivityCycle();
                    player.CheckStatusValues();
                    player.ProcessStatsCycle(RunCount);
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(GetType(), ex);
            }
        }

    }

}
