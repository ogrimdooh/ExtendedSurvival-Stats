﻿using Sandbox.Game;
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

        private static readonly Dictionary<string, KeyValuePair<int, bool>> VALID_COMMANDS = new Dictionary<string, KeyValuePair<int, bool>>()
        {
            { SETTINGS_COMMAND, new KeyValuePair<int, bool>(3, false) },
            { SETTINGS_COMMAND_PLAYER_STATUS, new KeyValuePair<int, bool>(3, false) }
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
                                    ExtendedSurvivalSettings.Instance.SetConfigValue(mCommandData.content[1], mCommandData.content[2]);
                                    break;
                                case SETTINGS_COMMAND_PLAYER_STATUS:
                                    var playerChar = ExtendedSurvivalStatsEntityManager.Instance.GetPlayerCharacterBySteamId(mCommandData.sender);
                                    if (playerChar != null)
                                    {
                                        if (!mCommandData.content[1].Contains("Effect"))
                                        {
                                            MyEntityStat targetStat = playerChar.GetStatCache(mCommandData.content[1]);
                                            if (targetStat != null)
                                            {
                                                float targetValue;
                                                if (float.TryParse(mCommandData.content[2], out targetValue))
                                                {
                                                    targetStat.Value = targetValue;
                                                }
                                            }
                                        }
                                    }
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
                        ExtendedSurvivalCoreAPI.AddExtraStartLoot(ItensConstants.ANTI_INFRAMMATORY_ID.DefinitionId, 1);

                        ExtendedSurvivalCoreAPI.AddGasSpoilInfo(
                            LivestockConstants.CREATURE_HEALTH,
                            LivestockConstants.FEED_TIME_CICLE,
                            LivestockConstants.BASE_HUNGRY_FACTOR,
                            (Guid observerId) =>
                            {
                                return true;
                            }
                        );
                        ExtendedSurvivalCoreAPI.AddGasSpoilInfo(
                            LivestockConstants.TREE_HEALTH,
                            FarmConstants.BASE_TIME_TO_PRODUCE,
                            FarmConstants.BASE_TREE_DECAY_FACTOR,
                            (Guid observerId) =>
                            {
                                return !HasIce(observerId) || !HasAnyFertilizer(observerId);
                            }
                        );
                        foreach (var itemKey in ItensConstants.ITEM_EXTRA_INFO_DEF.Keys)
                        {
                            ExtendedSurvivalCoreAPI.AddItemExtraInfo(ItensConstants.ITEM_EXTRA_INFO_DEF[itemKey]);
                        }
                        ExtendedSurvivalCoreAPI.AddItemCategory(LivestockConstants.ANIMAL_CATEGORY);
                        foreach (var animalId in ItensConstants.ANIMALS_IDS)
                        {
                            ExtendedSurvivalCoreAPI.AddDefinitionToCategory(animalId.DefinitionId, LivestockConstants.ANIMAL_CATEGORY);
                        }
                        ExtendedSurvivalCoreAPI.AddTreeDropLoot(new ExtendedSurvivalCoreAPI.TreeDropLoot(ItensConstants.CEREAL_ID.DefinitionId, 30, 50));
                        ExtendedSurvivalCoreAPI.AddTreeDropLoot(new ExtendedSurvivalCoreAPI.TreeDropLoot(ItensConstants.APPLE_ID.DefinitionId, 5, 25) { AlowDesert = false });
                        ExtendedSurvivalCoreAPI.AddTreeDropLoot(new ExtendedSurvivalCoreAPI.TreeDropLoot(ItensConstants.APPLETREESEEDLING_ID.DefinitionId, 1, 50) { AlowDesert = false, IsGas = true });
                    
                        if (InvokeAfterCoreApiLoaded.Any())
                            foreach (var action in InvokeAfterCoreApiLoaded)
                            {
                                action.Invoke();
                            }
                    }
                }
            });

            if (IsServer)
            {
                ExtendedSurvivalSettings.Load();
                ExtendedSurvivalStorage.Load();
                CheckDefinitions();
            }

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
                    DefinitionUtils.AddStatToCharacter("Creature_Torpor", character);
                }

                var playerCharacters = new string[] { "Default_Astronaut", "Default_Astronaut_Female" };
                foreach (var character in playerCharacters)
                {
                    DefinitionUtils.AddStatToCharacter("IntakeCarbohydrates", character);
                    DefinitionUtils.AddStatToCharacter("IntakeProtein", character);
                    DefinitionUtils.AddStatToCharacter("IntakeLipids", character);
                    DefinitionUtils.AddStatToCharacter("IntakeVitamins", character);
                    DefinitionUtils.AddStatToCharacter("IntakeMinerals", character);
                    DefinitionUtils.AddStatToCharacter("BodyMuscles", character);
                    DefinitionUtils.AddStatToCharacter("BodyFat", character);
                    DefinitionUtils.AddStatToCharacter("BodyPerformance", character);
                    DefinitionUtils.AddStatToCharacter("IntakeBodyFood", character);
                    DefinitionUtils.AddStatToCharacter("IntakeBodyWater", character);
                    DefinitionUtils.AddStatToCharacter("BodyEnergy", character);
                    DefinitionUtils.AddStatToCharacter("BodyWater", character);
                    DefinitionUtils.AddStatToCharacter("WoundedTime", character);
                    DefinitionUtils.AddStatToCharacter("TemperatureTime", character);
                    DefinitionUtils.AddStatToCharacter("WetTime", character);
                    DefinitionUtils.AddStatToCharacter("SurvivalEffects", character);
                    DefinitionUtils.AddStatToCharacter("DamageEffects", character);
                    DefinitionUtils.AddStatToCharacter("TemperatureEffects", character);
                    DefinitionUtils.AddStatToCharacter("DiseaseEffects", character);
                    DefinitionUtils.AddStatToCharacter("OtherEffects", character);
                    DefinitionUtils.AddStatToCharacter("Stamina", character);
                    DefinitionUtils.AddStatToCharacter("Thirst", character);
                    DefinitionUtils.AddStatToCharacter("Hunger", character);
                }

                // NUTRITION
                NutritionConstants.CalculateRecipesNutrition();
                NutritionConstants.TryOverrideRecipes();

                // SPAWNS
                SpawnGroupOverride.SetDefinitions();

                // BLOCKS
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
                DefinitionUtils.GetLootItem(new Vector2(1, 5).GetMultiplier(multiplier), ItensConstants.CARROT_SEEDS_ID, 0.1f),
                DefinitionUtils.GetLootItem(new Vector2(1, 5).GetMultiplier(multiplier), ItensConstants.MINT_SEEDS_ID, 0.1f),
                DefinitionUtils.GetLootItem(new Vector2(1, 5).GetMultiplier(multiplier), ItensConstants.ARNICA_SEEDS_ID, 0.1f),
                DefinitionUtils.GetLootItem(new Vector2(1, 5).GetMultiplier(multiplier), ItensConstants.BROCCOLI_SEEDS_ID, 0.1f),
                DefinitionUtils.GetLootItem(new Vector2(1, 5).GetMultiplier(multiplier), ItensConstants.COFFEE_SEEDS_ID, 0.1f),
                DefinitionUtils.GetLootItem(new Vector2(1, 5).GetMultiplier(multiplier), ItensConstants.TOMATO_SEEDS_ID, 0.1f),
                DefinitionUtils.GetLootItem(new Vector2(1, 5).GetMultiplier(multiplier), ItensConstants.WHEAT_SEEDS_ID, 0.1f),
                DefinitionUtils.GetLootItem(new Vector2(1, 5).GetMultiplier(multiplier), ItensConstants.CHAMOMILE_SEEDS_ID, 0.1f),
                DefinitionUtils.GetLootItem(new Vector2(1, 5).GetMultiplier(multiplier), ItensConstants.ALOEVERA_SEEDS_ID, 0.1f),
                DefinitionUtils.GetLootItem(new Vector2(1, 5).GetMultiplier(multiplier), ItensConstants.ERYTHROXYLUM_SEEDS_ID, 0.1f)
            };
        }

        private MyObjectBuilder_ContainerTypeDefinition.ContainerTypeItem[] GetAnimalLoot(float multiplier = 1f)
        {
            return new MyObjectBuilder_ContainerTypeDefinition.ContainerTypeItem[]
            {
                DefinitionUtils.GetLootItem(new Vector2(6, 12).GetMultiplier(multiplier), ItensConstants.MEAT_ID, 6),
                DefinitionUtils.GetLootItem(new Vector2(3, 6).GetMultiplier(multiplier), ItensConstants.NOBLE_MEAT_ID, 1),
                DefinitionUtils.GetLootItem(new Vector2(10, 20).GetMultiplier(multiplier), ItensConstants.BONES_ID, 3)
            };
        }

        private MyObjectBuilder_ContainerTypeDefinition.ContainerTypeItem[] GetSpiderLoot(float multiplier = 1f)
        {
            return new MyObjectBuilder_ContainerTypeDefinition.ContainerTypeItem[]
            {
                DefinitionUtils.GetLootItem(new Vector2(12, 24).GetMultiplier(multiplier), ItensConstants.ALIEN_MEAT_ID, 6),
                DefinitionUtils.GetLootItem(new Vector2(6, 12).GetMultiplier(multiplier), ItensConstants.ALIEN_NOBLE_MEAT_ID, 1),
                DefinitionUtils.GetLootItem(new Vector2(20, 40).GetMultiplier(multiplier), ItensConstants.BONES_ID, 3),
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
                    player.CheckValuesToDoDamage();

                    if (RunCount < 300)
                        continue;

                    player.ProcessStatsCycle();
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(GetType(), ex);
            }
        }

    }

}
