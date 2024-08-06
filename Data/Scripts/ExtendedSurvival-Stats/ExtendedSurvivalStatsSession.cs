using Sandbox.Definitions;
using Sandbox.Game;
using Sandbox.Game.Components;
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
using VRage.Game.Entity;
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

        public const ulong ES_STATS_EFFECTS_MODID = 2840924715;
        public const ulong ES_TECHNOLOGY_MODID = 2842844421;

        private static bool? isUsingTechnology = null;
        public static bool IsUsingTechnology()
        {
            if (!isUsingTechnology.HasValue)
                isUsingTechnology = MyAPIGateway.Session.Mods.Any(x => x.PublishedFileId == ES_TECHNOLOGY_MODID || x.Name == ES_TECHNOLOGY_LOCALNAME);
            return isUsingTechnology.Value;
        }

        public EasyInventoryAPI EasyInventoryAPI;
        public HudAPIv2 TextAPI;
        public ExtendedSurvivalCoreAPI ESCoreAPI;
        public AdvancedStatsAndEffectsAPI ASECoreAPI;
        public AdvancedStatsAndEffectsClientAPI ASECoreClientAPI;
        public AdvancedPlayerUICoreAPI APUCoreAPI;
        public AdvancedPlayerEquipCoreAPI APECoreAPI;
        public AdvancedPlayerEquipCoreClientAPI APECoreClientAPI;

        public const ushort NETWORK_ID_STATSSYSTEM = 40522;
        public const ushort NETWORK_ID_COMMANDS = 40523;
        public const ushort NETWORK_ID_DEFINITIONS = 40524;
        public const ushort NETWORK_ID_ENTITYCALLS = 40525;
        public const ushort NETWORK_ID_APICALLS = 40526;
        public const string CALL_FOR_DEFS = "NEEDDEFS";

        public int GetPlayerFixedStatUpdateHash()
        {
            if (IsServer)
                return AdvancedStatsAndEffectsAPI.GetPlayerFixedStatUpdateHash(MyAPIGateway.Session.Player.IdentityId);
            else
                return AdvancedStatsAndEffectsClientAPI.GetPlayerFixedStatUpdateHash();
        }

        public byte GetPlayerFixedStatStack(string fixedStat)
        {
            if (IsServer)
                return AdvancedStatsAndEffectsAPI.GetPlayerFixedStatStack(MyAPIGateway.Session.Player.IdentityId, fixedStat);
            else
                return AdvancedStatsAndEffectsClientAPI.GetPlayerFixedStatStack(fixedStat);
        }

        public long GetPlayerFixedStatRemainTime(string fixedStat)
        {
            if (IsServer)
                return AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(MyAPIGateway.Session.Player.IdentityId, fixedStat);
            else
                return AdvancedStatsAndEffectsClientAPI.GetPlayerFixedStatRemainTime(fixedStat);
        }

        protected override void DoInit(MyObjectBuilder_SessionComponent sessionComponent)
        {
            
            Static = this;

            if (!IsDedicated)
            {
                MyAPIGateway.Multiplayer.RegisterSecureMessageHandler(NETWORK_ID_STATSSYSTEM, ClientUpdateMsgHandler);
            }

            if (IsServer)
            {

                MyAPIGateway.Session.DamageSystem.RegisterBeforeDamageHandler(int.MaxValue, (object entity, ref MyDamageInformation damage) =>
                {
                    if (entity != null)
                    {
                        var character = entity as IMyCharacter;
                        if (character != null)
                        {
                            if (!character.IsValidPlayer())
                            {
                                CreatureActionsController.DoReciveDamage(character, ref damage);
                            }
                            else
                            {
                                PlayerHealthController.DoReciveDamage(character, ref damage);
                            }
                            damage.AttackerId = 0; /* Set Attacker to 0 */
                        }
                    }
                });

                MyAPIGateway.Session.SessionSettings.AutoHealing = false; /* Remove auto healing to control at playerentity */
                MyAPIGateway.Session.SessionSettings.WeatherSystem = true; /* multiple systens use weather */

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

            if (IsServer)
            {
                ExtendedSurvivalSettings.Load();
                ExtendedSurvivalStorage.Load();
                CheckDefinitions();
            }

            TextAPI = new HudAPIv2();
            EasyInventoryAPI = new EasyInventoryAPI(() => {
                EasyInventoryAPI.RegisterEasyFilter("ExtendedSurvival-Stats", (item) => {
                    var id = new UniqueEntityId(item);
                    if (EquipmentConstants.EQUIPMENTS_DEFINITIONS.ContainsKey(id))
                        return true;
                    if (WeaponsConstants.WEAPONS_DEFINITIONS.ContainsKey(id))
                        return true;
                    if (WeaponsConstants.WEAPONMAGZINES_DEFINITIONS.ContainsKey(id))
                        return true;
                    return false;
                });
            });
            ESCoreAPI = new ExtendedSurvivalCoreAPI(()=> {
                if (IsServer)
                {
                    if (ExtendedSurvivalCoreAPI.Registered)
                    {

                        ExtendedSurvivalCoreAPI.AddExtraStartLoot(ItensConstants.BODYTRACKER_ID.DefinitionId, 1);
                        ExtendedSurvivalCoreAPI.AddExtraStartLoot(ItensConstants.WATER_FLASK_SMALL_ID.DefinitionId, 5);
                        ExtendedSurvivalCoreAPI.AddExtraStartLoot(FoodConstants.CEREALBAR_ID.DefinitionId, 10);
                        ExtendedSurvivalCoreAPI.AddExtraStartLoot(MedicalConstants.BANDAGES_ID.DefinitionId, 3);
                        ExtendedSurvivalCoreAPI.AddExtraStartLoot(MedicalConstants.HEALTHINJECTION_ID.DefinitionId, 1);

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
                        ExtendedSurvivalCoreAPI.AddTreeDropLoot(new TreeDropLoot(FoodConstants.CEREAL_ID.DefinitionId, new Vector2(0.5f, 0.75f), 50));
                        ExtendedSurvivalCoreAPI.AddTreeDropLoot(new TreeDropLoot(FoodConstants.APPLE_ID.DefinitionId, new Vector2(2, 6), 25) { AlowDesert = false });
                        ExtendedSurvivalCoreAPI.AddTreeDropLoot(new TreeDropLoot(SeedsAndFertilizerConstants.APPLETREESEEDLING_ID.DefinitionId, new Vector2(1, 1), 50) { AlowDesert = false, IsGas = true });
                    
                        if (InvokeAfterCoreApiLoaded.Any())
                            foreach (var action in InvokeAfterCoreApiLoaded)
                            {
                                action.Invoke();
                            }

                        EquipmentConstants.RegisterShopItens();
                        FishingConstants.RegisterShopItens();
                        FoodConstants.RegisterShopItens();
                        HerbsConstants.RegisterShopItens();
                        IngotsConstants.RegisterShopItens();
                        LivestockConstants.RegisterShopItens();
                        MedicalConstants.RegisterShopItens();
                        OreConstants.RegisterShopItens();
                        QuimicalConstants.RegisterShopItens();
                        RationConstants.RegisterShopItens();
                        RecipientConstants.RegisterShopItens();
                        SeedsAndFertilizerConstants.RegisterShopItens();
                        WeaponsConstants.RegisterShopItens();

                        if (definitionsCheckedToTheEnd)
                        {
                            ExtendedSurvivalCoreAPI.MarkAsAllItensLoaded(ES_STATS_EFFECTS_MODID);
                            markAsAllItensLoadedCalled = true;
                        }
                    }
                }
                else
                {
                    if (definitionsCheckedToTheEnd)
                    {
                        ExtendedSurvivalCoreAPI.MarkAsAllItensLoaded(ES_STATS_EFFECTS_MODID);
                        markAsAllItensLoadedCalled = true;
                    }
                }
            });
            if (IsServer)
            {
                ASECoreAPI = new AdvancedStatsAndEffectsAPI(() => {
                    if (IsServer)
                    {
                        // Define Consumable Triggers
                        AdvancedStatsAndEffectsAPI.SetStatAsConsumableTrigger(StatsConstants.ValidStats.FoodDetector.ToString());
                        AdvancedStatsAndEffectsAPI.SetStatAsConsumableTrigger(StatsConstants.ValidStats.MedicalDetector.ToString());
                        // Define Virtual Stats
                        AdvancedStatsAndEffectsAPI.ConfigureVirtualStat(new VirtualStatInfo()
                        {
                            Name = StatsConstants.VirtualStats.Liquid.ToString(),
                            Target = StatsConstants.ValidStats.BodyWater.ToString()
                        });
                        AdvancedStatsAndEffectsAPI.ConfigureVirtualStat(new VirtualStatInfo()
                        {
                            Name = StatsConstants.VirtualStats.Solid.ToString(),
                            Target = StatsConstants.ValidStats.Intestine.ToString()
                        });
                        // Define Fixed Stats
                        // Survival Effects : Group 01
                        var survivalStats = ((StatsConstants.SurvivalEffects[])Enum.GetValues(typeof(StatsConstants.SurvivalEffects))).ToList();
                        foreach (StatsConstants.SurvivalEffects item in survivalStats)
                        {
                            if (item != StatsConstants.SurvivalEffects.None)
                            {
                                AdvancedStatsAndEffectsAPI.ConfigureFixedStat(new FixedStatInfo()
                                {
                                    Group = 1,
                                    Index = survivalStats.IndexOf(item),
                                    Id = item.ToString(),
                                    Name = StatsConstants.GetSurvivalEffectDescription(item),
                                    IsInverseTime = StatsConstants.GetSurvivalEffectIsInverseTime(item),
                                    MaxInverseTime = StatsConstants.GetSurvivalEffectMaxInverseTime(item),
                                    CanStack = StatsConstants.GetSurvivalEffectCanStack(item),
                                    MaxStacks = StatsConstants.GetSurvivalEffectMaxStacks(item)
                                });
                            }
                        }
                        // Damage Effects : Group 02
                        var damageStats = ((StatsConstants.DamageEffects[])Enum.GetValues(typeof(StatsConstants.DamageEffects))).ToList();
                        foreach (StatsConstants.DamageEffects item in damageStats)
                        {
                            if (item != StatsConstants.DamageEffects.None)
                            {
                                AdvancedStatsAndEffectsAPI.ConfigureFixedStat(new FixedStatInfo()
                                {
                                    Group = 2,
                                    Index = damageStats.IndexOf(item),
                                    Id = item.ToString(),
                                    Name = StatsConstants.GetDamageEffectDescription(item),
                                    CanSelfRemove = StatsConstants.GetDamageEffectSelfRemove(item),
                                    CompleteRemove = StatsConstants.IsDamageEffectCompleteRemove(item),
                                    CanStack = StatsConstants.IsDamageEffectCanStack(item),
                                    StacksWhenRemove = StatsConstants.GetDamageEffectStacksWhenRemove(item),
                                    TimeToSelfRemove = StatsConstants.GetDamageEffectTimeToRemove(item)
                                });
                            }
                        }
                        // Temperature Effects : Group 03
                        var temperatureStats = ((StatsConstants.TemperatureEffects[])Enum.GetValues(typeof(StatsConstants.TemperatureEffects))).ToList();
                        foreach (StatsConstants.TemperatureEffects item in temperatureStats)
                        {
                            if (item != StatsConstants.TemperatureEffects.None)
                            {
                                AdvancedStatsAndEffectsAPI.ConfigureFixedStat(new FixedStatInfo()
                                {
                                    Group = 3,
                                    Index = temperatureStats.IndexOf(item),
                                    Id = item.ToString(),
                                    Name = StatsConstants.TEMPERATURE_EFFECTS[item].Name,
                                    CanSelfRemove = StatsConstants.TEMPERATURE_EFFECTS[item].CanSelfRemove,
                                    TimeToSelfRemove = StatsConstants.TEMPERATURE_EFFECTS[item].TimeToSelfRemove,
                                    CompleteRemove = StatsConstants.TEMPERATURE_EFFECTS[item].CompleteRemove,
                                    StacksWhenRemove = StatsConstants.TEMPERATURE_EFFECTS[item].StacksWhenRemove,
                                    IsInverseTime = StatsConstants.TEMPERATURE_EFFECTS[item].IsInverseTime,
                                    MaxInverseTime = StatsConstants.TEMPERATURE_EFFECTS[item].MaxInverseTime,
                                    SelfRemoveWhenMaxInverse = StatsConstants.TEMPERATURE_EFFECTS[item].SelfRemoveWhenMaxInverse,
                                    CanStack = StatsConstants.TEMPERATURE_EFFECTS[item].CanStack,
                                    MaxStacks = StatsConstants.TEMPERATURE_EFFECTS[item].MaxStacks,
                                    IsPositive = StatsConstants.TEMPERATURE_EFFECTS[item].IsPositive
                                });
                            }
                        }
                        // Disease Effects : Group 04
                        var diseaseStats = ((StatsConstants.DiseaseEffects[])Enum.GetValues(typeof(StatsConstants.DiseaseEffects))).ToList();
                        foreach (StatsConstants.DiseaseEffects item in diseaseStats)
                        {
                            if (item != StatsConstants.DiseaseEffects.None)
                            {
                                AdvancedStatsAndEffectsAPI.ConfigureFixedStat(new FixedStatInfo()
                                {
                                    Group = 4,
                                    Index = diseaseStats.IndexOf(item),
                                    Id = item.ToString(),
                                    Name = StatsConstants.GetDiseaseEffectDescription(item),
                                    CanStack = StatsConstants.CanDiseaseEffectStack(item),
                                    MaxStacks = StatsConstants.GetDiseaseEffectMaxStack(item),
                                    CanSelfRemove = StatsConstants.CanDiseaseEffectSelfRemove(item),
                                    TimeToSelfRemove = StatsConstants.GetDiseaseEffectTimeToRemove(item),
                                    CompleteRemove = StatsConstants.IsDiseaseEffectCompleteRemove(item),
                                    StacksWhenRemove = StatsConstants.GetDiseaseEffectStacksWhenRemove(item)
                                });
                            }
                        }
                        // Add Poison cycle
                        AdvancedStatsAndEffectsAPI.AddFixedStatCycleCallback(
                            StatsConstants.DiseaseEffects.Poison.ToString(),
                            (fixedStat, stack, remainTime, playerId, character, statComponent) => 
                            {
                                if (stack > 0 && character != null && character.CanTakeDamage())
                                {
                                    character.DoDamage(stack * StatsConstants.POISON_DAMAGE, MyDamageType.Radioactivity, true, attackerId: playerId);
                                }
                            },
                            int.MaxValue
                        );
                        // Add Hypothermia cycle
                        AdvancedStatsAndEffectsAPI.AddFixedStatCycleCallback(
                            StatsConstants.DiseaseEffects.Hypothermia.ToString(),
                            (fixedStat, stack, remainTime, playerId, character, statComponent) =>
                            {
                                if (stack > 0 && character != null && character.CanTakeDamage())
                                {
                                    character.DoDamage(stack * StatsConstants.TEMPERATURE_DAMAGE, MyDamageType.Temperature, true, attackerId: playerId);
                                }
                            },
                            int.MaxValue
                        );
                        // Add Hyperthermia cycle
                        AdvancedStatsAndEffectsAPI.AddFixedStatCycleCallback(
                            StatsConstants.DiseaseEffects.Hyperthermia.ToString(),
                            (fixedStat, stack, remainTime, playerId, character, statComponent) =>
                            {
                                if (stack > 0 && character != null && character.CanTakeDamage())
                                {
                                    character.DoDamage(stack * StatsConstants.TEMPERATURE_DAMAGE, MyDamageType.Temperature, true, attackerId: playerId);
                                }
                            },
                            int.MaxValue
                        );
                        // Other Effects : Group 05
                        var otherStats = ((StatsConstants.OtherEffects[])Enum.GetValues(typeof(StatsConstants.OtherEffects))).ToList();
                        foreach (StatsConstants.OtherEffects item in otherStats)
                        {
                            if (item != StatsConstants.OtherEffects.None)
                            {
                                AdvancedStatsAndEffectsAPI.ConfigureFixedStat(new FixedStatInfo()
                                {
                                    Group = 5,
                                    Index = otherStats.IndexOf(item),
                                    Id = item.ToString(),
                                    Name = StatsConstants.GetOtherEffectDescription(item)
                                });
                            }
                        }
                        // Food Effects : Group 06
                        var foodStats = ((FoodEffectConstants.FoodEffects[])Enum.GetValues(typeof(FoodEffectConstants.FoodEffects))).ToList();
                        foreach (FoodEffectConstants.FoodEffects item in foodStats)
                        {
                            if (item != FoodEffectConstants.FoodEffects.None)
                            {
                                AdvancedStatsAndEffectsAPI.ConfigureFixedStat(new FixedStatInfo()
                                {
                                    Group = 6,
                                    Index = foodStats.IndexOf(item),
                                    Id = item.ToString(),
                                    Name = FoodEffectConstants.FOOD_EFFECTS[item].Name,
                                    CanSelfRemove = FoodEffectConstants.FOOD_EFFECTS[item].CanSelfRemove,
                                    TimeToSelfRemove = FoodEffectConstants.FOOD_EFFECTS[item].TimeToSelfRemove,
                                    CompleteRemove = FoodEffectConstants.FOOD_EFFECTS[item].CompleteRemove,
                                    StacksWhenRemove = FoodEffectConstants.FOOD_EFFECTS[item].StacksWhenRemove,
                                    IsInverseTime = FoodEffectConstants.FOOD_EFFECTS[item].IsInverseTime,
                                    MaxInverseTime = FoodEffectConstants.FOOD_EFFECTS[item].MaxInverseTime,
                                    SelfRemoveWhenMaxInverse = FoodEffectConstants.FOOD_EFFECTS[item].SelfRemoveWhenMaxInverse,
                                    CanStack = FoodEffectConstants.FOOD_EFFECTS[item].CanStack,
                                    MaxStacks = FoodEffectConstants.FOOD_EFFECTS[item].MaxStacks,
                                    IsPositive = FoodEffectConstants.FOOD_EFFECTS[item].IsPositive
                                });
                            }
                        }
                        // Food Effects : Group 07
                        var foodStats2 = ((FoodEffectConstants.FoodEffectsPart2[])Enum.GetValues(typeof(FoodEffectConstants.FoodEffectsPart2))).ToList();
                        foreach (FoodEffectConstants.FoodEffectsPart2 item in foodStats2)
                        {
                            if (item != FoodEffectConstants.FoodEffectsPart2.None)
                            {
                                AdvancedStatsAndEffectsAPI.ConfigureFixedStat(new FixedStatInfo()
                                {
                                    Group = 7,
                                    Index = foodStats2.IndexOf(item),
                                    Id = item.ToString(),
                                    Name = FoodEffectConstants.FOOD_EFFECTS2[item].Name,
                                    CanSelfRemove = FoodEffectConstants.FOOD_EFFECTS2[item].CanSelfRemove,
                                    TimeToSelfRemove = FoodEffectConstants.FOOD_EFFECTS2[item].TimeToSelfRemove,
                                    CompleteRemove = FoodEffectConstants.FOOD_EFFECTS2[item].CompleteRemove,
                                    StacksWhenRemove = FoodEffectConstants.FOOD_EFFECTS2[item].StacksWhenRemove,
                                    IsInverseTime = FoodEffectConstants.FOOD_EFFECTS2[item].IsInverseTime,
                                    MaxInverseTime = FoodEffectConstants.FOOD_EFFECTS2[item].MaxInverseTime,
                                    SelfRemoveWhenMaxInverse = FoodEffectConstants.FOOD_EFFECTS2[item].SelfRemoveWhenMaxInverse,
                                    CanStack = FoodEffectConstants.FOOD_EFFECTS2[item].CanStack,
                                    MaxStacks = FoodEffectConstants.FOOD_EFFECTS2[item].MaxStacks,
                                    IsPositive = FoodEffectConstants.FOOD_EFFECTS2[item].IsPositive
                                });
                            }
                        }
                        // Set foods
                        foreach (var foodId in FoodConstants.FOOD_DEFINITIONS.Keys)
                        {
                            var foodDef = FoodConstants.FOOD_DEFINITIONS[foodId];
                            AdvancedStatsAndEffectsAPI.ConfigureConsumable(foodDef.GetConsumableConfigure(foodId));
                        }
                        // Set medical
                        foreach (var medicalId in MedicalConstants.MEDICAL_DEFINITIONS.Keys)
                        {
                            var medicalDef = MedicalConstants.MEDICAL_DEFINITIONS[medicalId];
                            AdvancedStatsAndEffectsAPI.ConfigureConsumable(medicalDef.GetConsumableConfigure(medicalId));
                        }
                        // Set virtual stats Liquid cycle
                        AdvancedStatsAndEffectsAPI.AddVirtualStatAbsorptionCicle(
                            StatsConstants.VirtualStats.Liquid.ToString(),
                            (virtualStat, amount, consumableId, playerId, character, statComponent) =>
                            {
                                if (amount > 0)
                                {
                                    MyEntityStat Bladder;
                                    statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.ValidStats.Bladder.ToString()), out Bladder);
                                    // 50% of water overload go to bladder
                                    Bladder.Value += amount * 0.50f;
                                }
                            },
                            int.MaxValue
                        );
                        // Set before cycle update
                        AdvancedStatsAndEffectsAPI.AddBeforeCycleCallback((playerId, character, statComponent) =>
                        {
                            if (playerId != 0 && 
                                character.IsValidPlayer() && 
                                !character.IsDead && 
                                !PlayerDeathController.PlayerHasDied(playerId) && 
                                !PlayerDeathController.PlayerNeedWaitFullCycle(playerId))
                            {
                                WeatherConstants.RefreshWeatherInfo(character);
                                if (character.IsOnValidBathroom())
                                {
                                    PlayerMetabolismController.DoCleanYourself(playerId);
                                    PlayerMetabolismController.DoBodyNeeds(playerId, statComponent);
                                }
                                PlayerActionsController.ProcessEffectsTimers(playerId, character, statComponent, 1000);
                                FatigueController.DoCycle(playerId, character, statComponent);
                                //return !character.IsOnCryoChamber();
                            }
                            return true;
                        }, int.MaxValue);
                        // Set after cycle update
                        AdvancedStatsAndEffectsAPI.AddAfterCycleCallback((playerId, character, statComponent) =>
                        {
                            if (playerId != 0 && character.IsValidPlayer() && !character.IsDead)
                            {
                                PlayerActionsController.DoPlayerCycle(playerId, 1000, character, statComponent);
                                PlayerHealthController.ProcessHealth(playerId, statComponent);
                            }
                        }, int.MaxValue);
                        // Set Stamina before cycle
                        AdvancedStatsAndEffectsAPI.AddBeforeCycleStatCallback(
                            StatsConstants.ValidStats.Stamina.ToString(),
                            StaminaController.DoCycle,
                            int.MaxValue
                        );
                        // Set after moviment change event
                        AdvancedStatsAndEffectsAPI.AddOnMovementStateChanged(
                            (playerId, character, statComponent, oldValue, newValue) =>
                            {
                                if (newValue == MyCharacterMovementEnum.Jump)
                                {
                                    if (playerId != 0 && character.IsValidPlayer() && !character.IsDead)
                                    {
                                        StaminaController.ProcessJump(playerId, character);
                                    }
                                }
                            },
                            int.MaxValue
                        );
                        // Set after health change
                        AdvancedStatsAndEffectsAPI.AddOnHealthChanged(
                            (playerId, character, statComponent, newValue, oldValue, statChangeData) =>
                            {
                                if (playerId != 0 && character.IsValidPlayer())
                                {
                                    if (newValue < oldValue)
                                    {
                                        PlayerHealthController.CheckHealthDamage(playerId, statComponent, oldValue - newValue);
                                    }
                                    else
                                    {
                                        PlayerHealthController.CheckHealthValue(playerId, statComponent);
                                    }
                                }
                            },
                            int.MaxValue
                        );
                        // Set on player on reset
                        AdvancedStatsAndEffectsAPI.AddAfterPlayerReset(
                            (playerId, character, statComponent) =>
                            {
                                PlayerMetabolismController.DoEatStartFood(playerId);
                            },
                            int.MaxValue
                        );
                        // Set on player on respawn
                        AdvancedStatsAndEffectsAPI.AddAfterPlayerRespawn(
                            (playerId, character, statComponent, newPod) =>
                            {
                                if (newPod)
                                {
                                    PlayerMetabolismController.DoEatStartFood(playerId);
                                }
                            },
                            int.MaxValue
                        );
                        // Set on bot add event
                        AdvancedStatsAndEffectsAPI.AddAfterBotAdd(
                            (playerId, character) =>
                            {
                                character.CharacterDied += BotCharacterDied;
                            },
                            int.MaxValue
                        );
                        // Check after player consume item
                        AdvancedStatsAndEffectsAPI.AddAfterPlayerConsume(
                            (playerId, character, statComponent, itemId) =>
                            {
                                if (playerId != 0 && character.IsValidPlayer())
                                {
                                    PlayerInventoryController.DoProcessItemConsume(playerId, statComponent, new UniqueEntityId(itemId));
                                }
                            },
                            int.MaxValue
                        );
                        AdvancedStatsAndEffectsAPI.AddOnBeginConfigureCharacter(
                            (playerId, character, statComponent, hasDied, storeStats) =>
                            {
                                if (playerId != 0 && character.IsValidPlayer())
                                {
                                    if (hasDied)
                                    {
                                        PlayerDeathController.DoProcessPlayerDeath(playerId, character, statComponent, storeStats);
                                    }
                                }
                            },
                            int.MaxValue
                        );
                        AdvancedStatsAndEffectsAPI.AddAfterRemoveFixedEffect(
                            (playerId, character, statComponent, id, stack, max) =>
                            {
                                if (playerId != 0 && character.IsValidPlayer())
                                {
                                    PlayerActionsController.DoProcessPlayerRemoveFixedEffect(playerId, character, statComponent, id, stack, max);
                                }
                            },
                            int.MaxValue
                        );
                        AdvancedStatsAndEffectsAPI.AddAfterCharacterDied(
                            (playerId, character, statComponent) =>
                            {
                                if (playerId != 0 && character.IsValidPlayer())
                                {
                                    PlayerDeathController.DoProcessPlayerDied(playerId, character, statComponent);
                                }
                            },
                            int.MaxValue
                        );
                    }
                });
                APUCoreAPI = new AdvancedPlayerUICoreAPI(() =>
                {
                    if (AdvancedPlayerUICoreAPI.Registered)
                    {
                        AdvancedPlayerUICoreAPI.RegisterGetHelpTopics("ESSTATS", HelpController.GetHelpTopics);
                        AdvancedPlayerUICoreAPI.RegisterGetHelpTopicEntries("ESSTATS", HelpController.GetHelpTopicEntries);
                        AdvancedPlayerUICoreAPI.RegisterGetHelpEntryPageData("ESSTATS", HelpController.GetHelpEntryPageData);
                    }
                });
                APECoreAPI = new AdvancedPlayerEquipCoreAPI(() =>
                {
                    if (AdvancedPlayerEquipCoreAPI.Registered)
                    {
                        /* Categories */
                        var categories = ((EquipmentConstants.EquipableItemCategory[])Enum.GetValues(typeof(EquipmentConstants.EquipableItemCategory))).ToList();
                        foreach (EquipmentConstants.EquipableItemCategory item in categories)
                        {
                            AdvancedPlayerEquipCoreAPI.ConfigureEquipableItemCategory(new EquipableItemCategoryData()
                            {
                                Id = item.ToString(),
                                Name = EquipmentConstants.GetEquipableItemCategoryName(item)
                            });
                        }
                        /* Slots */
                        var slots = ((EquipmentConstants.EquipableSlot[])Enum.GetValues(typeof(EquipmentConstants.EquipableSlot))).ToList();
                        foreach (EquipmentConstants.EquipableSlot item in slots)
                        {
                            AdvancedPlayerEquipCoreAPI.ConfigurePlayerSlot(new PlayerSlotData()
                            {
                                Id = item.ToString(),
                                Name = EquipmentConstants.GetEquipableSlotName(item),
                                ValidCategories = EquipmentConstants.GetSlotCategories(item).Select(x => new ValidCategoryData() 
                                { 
                                    Id = x.ToString()
                                }).ToList()
                            });
                        }
                        /* Equipments */
                        foreach (var key in EquipmentConstants.BODYTRACKERS.Keys)
                        {
                            AdvancedPlayerEquipCoreAPI.ConfigureEquipableItem(new EquipableItemData()
                            {
                                Id = key.DefinitionId,
                                TextureName = key.subtypeId.String,
                                ItemCategory = EquipmentConstants.EquipableItemCategory.BodyTracker.ToString()
                            });
                        }
                        foreach (var key in EquipmentConstants.ARMORS_DEFINITIONS.Keys)
                        {
                            var info = new EquipableItemData()
                            {
                                Id = key.DefinitionId,
                                TextureName = key.subtypeId.String,
                                ItemCategory = EquipmentConstants.EquipableItemCategory.BodyArmor.ToString()
                            };
                            for (int i = 0; i < EquipmentConstants.ARMORS_DEFINITIONS[key].ModuleSlots; i++)
                            {
                                info.Sockets.Add(new EquipableItemSocketData() 
                                { 
                                    Order = i,
                                    ValidCategories = EquipmentConstants.GetSlotCategories(EquipmentConstants.ARMORS_DEFINITIONS[key].Category).Select(x => new ValidCategoryData()
                                    {
                                        Id = x.ToString()
                                    }).ToList()
                                });
                            }
                            AdvancedPlayerEquipCoreAPI.ConfigureEquipableItem(info);
                        }
                        /* Sockets */
                        foreach (var key in EquipmentConstants.ARMOR_MODULES_DEFINITIONS.Keys)
                        {
                            AdvancedPlayerEquipCoreAPI.ConfigureSocketItem(new SocketItemData()
                            {
                                Id = key.DefinitionId,
                                TextureName = key.subtypeId.String,
                                ItemCategory = EquipmentConstants.GetUseCategory(EquipmentConstants.ARMOR_MODULES_DEFINITIONS[key].UseCategory)
                            });
                        }
                        /* Register a Callback */
                        AdvancedPlayerEquipCoreAPI.RegisterOnStoredDataChange("ESSS", (playerId) =>
                        {
                            PlayerArmorController.GetEquipedArmor(playerId, false); /* Force Armor Info Refresh */
                        });
                    }
                });
            }
            else
            {
                ASECoreClientAPI = new AdvancedStatsAndEffectsClientAPI(() => 
                {
                    if (AdvancedStatsAndEffectsClientAPI.Registered)
                    {

                    }
                });
                APECoreClientAPI = new AdvancedPlayerEquipCoreClientAPI(() =>
                {
                    if (AdvancedPlayerEquipCoreClientAPI.Registered)
                    {
                        AdvancedPlayerEquipCoreClientAPI.RegisterOnStoredDataChange("ESSS", () =>
                        {
                            PlayerArmorController.GetEquipedArmor(0, false); /* Force Armor Info Refresh */
                        });
                    }
                });
            }
            base.LoadData();
        }

        public static void CheckBotLoot(IMyCharacter character)
        {
            try
            {
                var inventory = character.GetInventory();
                if (inventory != null && inventory.ItemCount >= 0)
                {
                    Vector3D upp = character.WorldMatrix.Up;
                    Vector3D fww = character.WorldMatrix.Forward;
                    Vector3D rtt = character.WorldMatrix.Right;
                    Vector3D pos = character.GetPosition();
                    for (int i = 0; i < inventory.ItemCount; i++)
                    {
                        var item = inventory.GetItemAt(i);
                        MyFloatingObjects.Spawn(
                            new MyPhysicalInventoryItem(item.Value.Amount, 
                            ItensConstants.GetPhysicalObjectBuilder(new UniqueEntityId(item.Value.Type))),
                            pos + (upp * 1.5) + (fww * (0.33 * GetRandon())) + (rtt * 0.33 * GetRandon()), 
                            fww, 
                            upp
                        );
                    }
                    inventory.Clear();
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(typeof(DefinitionUtils), ex);
            }
        }

        private static int GetRandon()
        {
            var key = "0e3adb60-c593-4813-b39a-1508eb7d9849";
            return (((((byte)(key[MyUtils.GetRandomInt(1, key.Length)])) + 128) % 6) - 3);
        }

        private static void BotCharacterDied(IMyCharacter obj)
        {
            CheckBotLoot(obj);
        }

        private bool definitionsChecked = false;
        private bool definitionsCheckedToTheEnd = false;
        private bool markAsAllItensLoadedCalled = false;
        private void CheckDefinitions()
        {
            ExtendedSurvivalStatsLogging.Instance.LogInfo(GetType(), $"CheckDefinitions Called");
            if (!definitionsChecked)
            {
                definitionsChecked = true;

                DefinitionUtils.ReplaceContainerTypeDefinition("WolfLoot", new Vector2I(2, 3), true, GetAnimalLoot());
                DefinitionUtils.ReplaceContainerTypeDefinition("DeerLoot", new Vector2I(2, 3), true, GetAnimalLoot(2));
                DefinitionUtils.ReplaceContainerTypeDefinition("CowLoot", new Vector2I(2, 3), true, GetAnimalLoot(3));
                DefinitionUtils.ReplaceContainerTypeDefinition("SheepLoot", new Vector2I(2, 3), true, GetAnimalLoot());
                DefinitionUtils.ReplaceContainerTypeDefinition("HorseLoot", new Vector2I(2, 3), true, GetAnimalLoot(2));
                DefinitionUtils.ReplaceContainerTypeDefinition("SpiderLoot", new Vector2I(2, 4), true, GetSpiderLoot());

                DefinitionUtils.ChangeInventoryContainerType("deer_bot", "DeerLoot");
                DefinitionUtils.ChangeInventoryContainerType("deerbuck_bot", "DeerLoot");
                DefinitionUtils.ChangeInventoryContainerType("Cow_Bot", "CowLoot");
                DefinitionUtils.ChangeInventoryContainerType("Sheep_Bot", "SheepLoot");
                DefinitionUtils.ChangeInventoryContainerType("Horse_Bot", "HorseLoot");

                DefinitionUtils.ReplaceContainerTypeDefinition("PersonalContainerSmall", new Vector2I(2, 5), false, GetUnknownSignalLoot());

                DefinitionUtils.ChangeStatValue("AnimalHealth", new Vector3(0, 150, 150));
                DefinitionUtils.ChangeStatValue("Health", new Vector3(0, 250, 250));
                DefinitionUtils.ChangeStatValue("SpaceCharacterHealth", new Vector3(0, 250, 250));
                DefinitionUtils.ChangeStatValue("WolfHealth", new Vector3(0, 250, 250));
                DefinitionUtils.ChangeStatValue("SpiderHealth", new Vector3(0, 500, 500));

                DefinitionUtils.ChangeStatValue(
                    StatsConstants.ValidStats.Bladder.ToString(), 
                    new Vector3(0, PlayerBodyConstants.BladderSize.W, 0)
                );
                DefinitionUtils.ChangeStatValue(
                    StatsConstants.ValidStats.Stomach.ToString(),
                    new Vector3(0, PlayerBodyConstants.StomachSize.W, 0)
                );
                DefinitionUtils.ChangeStatValue(
                    StatsConstants.ValidStats.Intestine.ToString(),
                    new Vector3(0, PlayerBodyConstants.IntestineSize.W, 0)
                );
                DefinitionUtils.ChangeStatValue(
                    StatsConstants.ValidStats.BodyWater.ToString(),
                    new Vector3(0, PlayerBodyConstants.WaterReserveSize.W, PlayerBodyConstants.StartWaterReserve)
                );
                DefinitionUtils.ChangeStatValue(
                    StatsConstants.ValidStats.BodyCalories.ToString(),
                    new Vector3(PlayerBodyConstants.CaloriesLimit.X, PlayerBodyConstants.CaloriesLimit.Y, PlayerBodyConstants.StartCalories)
                );
                DefinitionUtils.ChangeStatValue(
                    StatsConstants.ValidStats.BodyWeight.ToString(),
                    new Vector3(0, PlayerBodyConstants.WeightLimit.Y, PlayerBodyConstants.StartWeight)
                );
                DefinitionUtils.ChangeStatValue(
                    StatsConstants.ValidStats.BodyMusclesWeight.ToString(),
                    new Vector3(0, PlayerBodyConstants.WeightLimit.Y, PlayerBodyConstants.StartWeight * PlayerBodyConstants.StartMuscle)
                );
                DefinitionUtils.ChangeStatValue(
                    StatsConstants.ValidStats.BodyFatWeight.ToString(),
                    new Vector3(0, PlayerBodyConstants.WeightLimit.Y, PlayerBodyConstants.StartWeight * PlayerBodyConstants.StartFat)
                );
                DefinitionUtils.ChangeStatValue(
                    StatsConstants.ValidStats.BodyMuscles.ToString(),
                    new Vector3(0, 1, PlayerBodyConstants.StartMuscle)
                );
                DefinitionUtils.ChangeStatValue(
                    StatsConstants.ValidStats.BodyFat.ToString(),
                    new Vector3(0, 1, PlayerBodyConstants.StartFat)
                );
                DefinitionUtils.ChangeStatValue(
                    StatsConstants.ValidStats.BodyPerformance.ToString(),
                    new Vector3(0, 1, PlayerBodyConstants.StartPerformance)
                );
                DefinitionUtils.ChangeStatValue(
                    StatsConstants.ValidStats.BodyImmune.ToString(),
                    new Vector3(0, 1, PlayerBodyConstants.StartImunity)
                );
                DefinitionUtils.ChangeStatValue(
                    StatsConstants.ValidStats.BodyEnergy.ToString(),
                    new Vector3(0, 1, 1)
                );
                DefinitionUtils.ChangeStatValue(
                    StatsConstants.ValidStats.BodyProtein.ToString(),
                    new Vector3(0, 1000, PlayerBodyConstants.StartProteins)
                );
                DefinitionUtils.ChangeStatValue(
                    StatsConstants.ValidStats.BodyCarbohydrate.ToString(),
                    new Vector3(0, 1000, PlayerBodyConstants.StartCarbohydrates)
                );
                DefinitionUtils.ChangeStatValue(
                    StatsConstants.ValidStats.BodyLipids.ToString(),
                    new Vector3(0, 1000, PlayerBodyConstants.StartLipids)
                );
                DefinitionUtils.ChangeStatValue(
                    StatsConstants.ValidStats.BodyVitamins.ToString(),
                    new Vector3(0, 100, PlayerBodyConstants.StartVitamins)
                );
                DefinitionUtils.ChangeStatValue(
                    StatsConstants.ValidStats.BodyMinerals.ToString(),
                    new Vector3(0, 100, PlayerBodyConstants.StartMinerals)
                );

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

                definitionsCheckedToTheEnd = true;
                if (ExtendedSurvivalCoreAPI.Registered && !markAsAllItensLoadedCalled)
                {
                    ExtendedSurvivalCoreAPI.MarkAsAllItensLoaded(ES_STATS_EFFECTS_MODID);
                    markAsAllItensLoadedCalled = true;
                }

            }
        }

        private MyObjectBuilder_ContainerTypeDefinition.ContainerTypeItem[] GetUnknownSignalLoot(float multiplier = 1f)
        {
            return new MyObjectBuilder_ContainerTypeDefinition.ContainerTypeItem[]
            {
                DefinitionUtils.GetLootItem(new Vector2(1, 5).GetMultiplier(multiplier), MedicalConstants.BANDAGES_ID, 0.1f),
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
                DefinitionUtils.GetLootItem(new Vector2(6, 12).GetMultiplier(multiplier), FoodConstants.MEAT_ID, 6),
                DefinitionUtils.GetLootItem(new Vector2(3, 6).GetMultiplier(multiplier), FoodConstants.NOBLE_MEAT_ID, 1),
                DefinitionUtils.GetLootItem(new Vector2(10, 20).GetMultiplier(multiplier), OreConstants.BONES_ID, 3)
            };
        }

        private MyObjectBuilder_ContainerTypeDefinition.ContainerTypeItem[] GetSpiderLoot(float multiplier = 1f)
        {
            return new MyObjectBuilder_ContainerTypeDefinition.ContainerTypeItem[]
            {
                DefinitionUtils.GetLootItem(new Vector2(12, 24).GetMultiplier(multiplier), FoodConstants.ALIEN_MEAT_ID, 6),
                DefinitionUtils.GetLootItem(new Vector2(6, 12).GetMultiplier(multiplier), FoodConstants.ALIEN_NOBLE_MEAT_ID, 1),
                DefinitionUtils.GetLootItem(new Vector2(20, 40).GetMultiplier(multiplier), OreConstants.BONES_ID, 3),
                DefinitionUtils.GetLootItem(new Vector2(4, 8).GetMultiplier(multiplier), FoodConstants.ALIEN_EGG_ID, 2)
            };
        }

        protected override void UnloadData()
        {
            try
            {
                TextAPI.Close();
                ESCoreAPI.Unregister();
                ASECoreAPI.Unregister();

                if (!IsDedicated)
                    MyAPIGateway.Multiplayer.UnregisterSecureMessageHandler(NETWORK_ID_STATSSYSTEM, ClientUpdateMsgHandler);

            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(GetType(), ex);
            }
            base.UnloadData();
        }

        private static void ForceWolfAndSpiders()
        {
            try
            {
                if (ExtendedSurvivalSettings.Instance.ForceCreatureSpawn)
                {
                    MyAPIGateway.Session.SessionSettings.EnableSpiders = true;
                    MyAPIGateway.Session.SessionSettings.EnableWolfs = true;
                }
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
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(GetType(), ex);
            }
        }

        public IMyCharacter TargetCharacter { get; private set; }
        private MyEntityStatComponent targetStatsComp;
        public MyEntityStatComponent TargetStatsComp
        { 
            get
            {
                if (TargetCharacter != null && TargetCharacter?.Components != null)
                {
                    if (targetStatsComp == null || targetStatsComp.Entity?.EntityId != TargetCharacter.EntityId)
                    {
                        targetName = null;
                        targetStatsComp = TargetCharacter?.Components?.Get<MyEntityStatComponent>();
                    }
                    return targetStatsComp;
                }
                return null;
            }
        }
        private string targetName;
        public string TargetName
        {
            get
            {
                if (TargetCharacter != null && TargetStatsComp != null)
                {
                    if (!string.IsNullOrWhiteSpace(targetName))
                        return targetName;
                    if (TargetCharacter.IsValidPlayer())
                    {
                        targetName = TargetCharacter.GetPlayer().DisplayName;
                    }
                    else
                    {
                        var baseName = TargetCharacter.Definition.Id.SubtypeName.ToLower().Replace("_bot", "").Split('_');
                        for (int i = 0; i < baseName.Length; i++)
                        {
                            baseName[i] = (baseName[i][0].ToString().ToUpper() + baseName[i].Substring(1)).Trim();
                        }
                        targetName = string.Join(" ", baseName);
                    }
                    return targetName;
                }
                return null;
            }
        }
        private long LastHitTime = 0;

        public const long TIME_SAVE_TARGET = 10000;
        public readonly DateTime TIME_START = DateTime.Now;
        public const float DEFAULT_CAMERA_SEARCH_TARGET = 100;
        protected override void DoUpdate60()
        {
            base.DoUpdate60();
            try
            {
                if (!IsDedicated && (IsClient || ExtendedSurvivalCoreAPI.Registered))
                {
                    var character = MyAPIGateway.Session.Player?.Character;
                    if (character != null)
                    {
                        var time = IsServer ? ExtendedSurvivalCoreAPI.GetGameTime() : (long)(TIME_START - DateTime.Now).TotalMilliseconds;
                        var pos = character.GetPosition() + (character.WorldMatrix.Up * 0.75f);
                        var targetPos = pos + (MyAPIGateway.Session.Camera.WorldMatrix.Forward * DEFAULT_CAMERA_SEARCH_TARGET);
                        List<IHitInfo> hitInfos = new List<IHitInfo>();
                        MyAPIGateway.Physics.CastRay(pos, targetPos, hitInfos);
                        if (hitInfos.Any(x => x.HitEntity as IMyCharacter != null && x.HitEntity?.EntityId != character.EntityId))
                        {
                            var hitInfo = hitInfos.FirstOrDefault(x => x.HitEntity?.EntityId != character.EntityId);
                            var targetCharacter = hitInfo.HitEntity as IMyCharacter;
                            if (targetCharacter != null)
                            {
                                TargetCharacter = targetCharacter;
                                LastHitTime = time;
                            }
                        }
                        else if (LastHitTime == 0 || (time - LastHitTime) > TIME_SAVE_TARGET)
                        {
                            TargetCharacter = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(GetType(), ex);
            }
        }

    }

}
