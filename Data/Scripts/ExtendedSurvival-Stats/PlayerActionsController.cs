using Sandbox.Common.ObjectBuilders.Definitions;
using Sandbox.Definitions;
using Sandbox.Game;
using Sandbox.Game.Components;
using Sandbox.Game.Entities;
using Sandbox.Game.Entities.Character.Components;
using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using VRage.Game;
using VRage.Game.ModAPI;
using VRage.Utils;
using VRageMath;

namespace ExtendedSurvival.Stats
{

    public static class PlayerActionsController
    {

        public sealed class PlayerStatsEasyAcess
        {

            private MyCharacterStatComponent statComponent;
            public MyCharacterStatComponent StatComponent
            {
                get
                {
                    return statComponent;
                }
                set
                {
                    if (statComponent == null || statComponent?.Entity?.EntityId != value?.Entity?.EntityId)
                    {
                        statComponent = value;
                        DoLoadStats();
                    }
                }
            }

            public bool IsValid
            {
                get
                {
                    return statComponent != null;
                }
            }

            public long PlayerId { get; private set; }

            public ConcurrentDictionary<StatsConstants.FixedStats, MyEntityStat> FixedStats { get; private set; } = new ConcurrentDictionary<StatsConstants.FixedStats, MyEntityStat>();
            public ConcurrentDictionary<StatsConstants.ValidStats, MyEntityStat> Stats { get; private set; } = new ConcurrentDictionary<StatsConstants.ValidStats, MyEntityStat>();

            public MyEntityStat SurvivalEffects { get { return FixedStats[StatsConstants.FixedStats.StatsGroup01]; } }
            public MyEntityStat DamageEffects { get { return FixedStats[StatsConstants.FixedStats.StatsGroup02]; } }
            public MyEntityStat TemperatureEffects { get { return FixedStats[StatsConstants.FixedStats.StatsGroup03]; } }
            public MyEntityStat DiseaseEffects { get { return FixedStats[StatsConstants.FixedStats.StatsGroup04]; } }
            public MyEntityStat OtherEffects { get { return FixedStats[StatsConstants.FixedStats.StatsGroup05]; } }

            public MyEntityStat FoodDetector { get { return Stats[StatsConstants.ValidStats.FoodDetector]; } }
            public MyEntityStat MedicalDetector { get { return Stats[StatsConstants.ValidStats.MedicalDetector]; } }

            public MyEntityStat Hunger { get { return Stats[StatsConstants.ValidStats.Hunger]; } }
            public MyEntityStat Thirst { get { return Stats[StatsConstants.ValidStats.Thirst]; } }
            public MyEntityStat Stamina { get { return Stats[StatsConstants.ValidStats.Stamina]; } }
            public MyEntityStat Fatigue { get { return Stats[StatsConstants.ValidStats.Fatigue]; } }

            public MyEntityStat WoundedTime { get { return Stats[StatsConstants.ValidStats.WoundedTime]; } }

            public MyEntityStat BodyEnergy { get { return Stats[StatsConstants.ValidStats.BodyEnergy]; } }
            public MyEntityStat BodyWater { get { return Stats[StatsConstants.ValidStats.BodyWater]; } }
            public MyEntityStat BodyPerformance { get { return Stats[StatsConstants.ValidStats.BodyPerformance]; } }
            public MyEntityStat BodyImmune { get { return Stats[StatsConstants.ValidStats.BodyImmune]; } }
            public MyEntityStat BodyCalories { get { return Stats[StatsConstants.ValidStats.BodyCalories]; } }

            public MyEntityStat Stomach { get { return Stats[StatsConstants.ValidStats.Stomach]; } }
            public MyEntityStat Intestine { get { return Stats[StatsConstants.ValidStats.Intestine]; } }
            public MyEntityStat Bladder { get { return Stats[StatsConstants.ValidStats.Bladder]; } }

            public MyEntityStat BodyWeight { get { return Stats[StatsConstants.ValidStats.BodyWeight]; } }
            public MyEntityStat BodyMuscles { get { return Stats[StatsConstants.ValidStats.BodyMuscles]; } }
            public MyEntityStat BodyFat { get { return Stats[StatsConstants.ValidStats.BodyFat]; } }

            public MyEntityStat BodyProtein { get { return Stats[StatsConstants.ValidStats.BodyProtein]; } }
            public MyEntityStat BodyCarbohydrate { get { return Stats[StatsConstants.ValidStats.BodyCarbohydrate]; } }
            public MyEntityStat BodyLipids { get { return Stats[StatsConstants.ValidStats.BodyLipids]; } }
            public MyEntityStat BodyMinerals { get { return Stats[StatsConstants.ValidStats.BodyMinerals]; } }
            public MyEntityStat BodyVitamins { get { return Stats[StatsConstants.ValidStats.BodyVitamins]; } }

            public MyEntityStat RadiationTime { get { return Stats[StatsConstants.ValidStats.RadiationTime]; } }
            public MyEntityStat IntoxicationTime { get { return Stats[StatsConstants.ValidStats.IntoxicationTime]; } }

            public MyEntityStat HotThermalFluid { get { return Stats[StatsConstants.ValidStats.HotThermalFluid]; } }
            public MyEntityStat ColdThermalFluid { get { return Stats[StatsConstants.ValidStats.ColdThermalFluid]; } }
            public MyEntityStat EnergyShield { get { return Stats[StatsConstants.ValidStats.EnergyShield]; } }

            public StatsConstants.SurvivalEffects CurrentSurvivalEffects
            {
                get
                {
                    return SurvivalEffects != null ? (StatsConstants.SurvivalEffects)((int)SurvivalEffects.Value) : StatsConstants.SurvivalEffects.None;
                }
                set
                {
                    SurvivalEffects.Value = (int)value;
                }
            }

            public StatsConstants.DamageEffects CurrentDamageEffects
            {
                get
                {
                    return DamageEffects != null ? (StatsConstants.DamageEffects)((int)DamageEffects.Value) : StatsConstants.DamageEffects.None;
                }
                set
                {
                    DamageEffects.Value = (int)value;
                }
            }

            public StatsConstants.TemperatureEffects CurrentTemperatureEffects
            {
                get
                {
                    return TemperatureEffects != null ? (StatsConstants.TemperatureEffects)((int)TemperatureEffects.Value) : StatsConstants.TemperatureEffects.None;
                }
                set
                {
                    TemperatureEffects.Value = (int)value;
                }
            }

            public StatsConstants.DiseaseEffects CurrentDiseaseEffects
            {
                get
                {
                    return DiseaseEffects != null ? (StatsConstants.DiseaseEffects)((int)DiseaseEffects.Value) : StatsConstants.DiseaseEffects.None;
                }
                set
                {
                    DiseaseEffects.Value = (int)value;
                }
            }

            public StatsConstants.OtherEffects CurrentOtherEffects
            {
                get
                {
                    return OtherEffects != null ? (StatsConstants.OtherEffects)((int)OtherEffects.Value) : StatsConstants.OtherEffects.None;
                }
                set
                {
                    OtherEffects.Value = (int)value;
                }
            }

            public PlayerStatsEasyAcess(long playerId, MyCharacterStatComponent statComponent)
            {
                PlayerId = playerId;
                StatComponent = statComponent;
            }

            private void DoLoadStats()
            {
                Stats.Clear();
                if (IsValid)
                {
                    foreach (StatsConstants.ValidStats stat in Enum.GetValues(typeof(StatsConstants.ValidStats)).Cast<StatsConstants.ValidStats>())
                    {
                        MyEntityStat Stat;
                        if (statComponent.TryGetStat(MyStringHash.GetOrCompute(stat.ToString()), out Stat))
                            Stats[stat] = Stat;
                    }
                    FixedStats.Clear();
                    foreach (StatsConstants.FixedStats stat in Enum.GetValues(typeof(StatsConstants.FixedStats)).Cast<StatsConstants.FixedStats>())
                    {
                        MyEntityStat Stat;
                        if (statComponent.TryGetStat(MyStringHash.GetOrCompute(stat.ToString()), out Stat))
                            FixedStats[stat] = Stat;
                    }
                }
            }

        }

        public static void DoCleanYourself(long playerId)
        {
            AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.OtherEffects.PoopOnClothes.ToString(), 0, true);
            AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.OtherEffects.PeeOnClothes.ToString(), 0, true);
        }

        public static void DoBodyNeeds(long playerId, MyCharacterStatComponent statComponent)
        {
            RefreshPlayerStatComponent(playerId, statComponent);
            var CurrentBladderAmmount = statsEasyAcess[playerId].Bladder.MaxValue / statsEasyAcess[playerId].Bladder.Value;
            var CurrentIntestineAmmount = statsEasyAcess[playerId].Intestine.MaxValue / statsEasyAcess[playerId].Intestine.Value;
            if (CurrentBladderAmmount >= 0.075f)
                statsEasyAcess[playerId].Bladder.Value = 0;
            if (CurrentIntestineAmmount >= 0.5f)
                statsEasyAcess[playerId].Intestine.Value = 0;
        }

        public static void DoEmptyBladder(long playerId)
        {
            statsEasyAcess[playerId].Bladder.Value = 0;
        }

        public static void DoEmptyIntestine(long playerId)
        {
            statsEasyAcess[playerId].Intestine.Value = 0;
        }

        public static void DoEmptyStomach(long playerId)
        {
            AdvancedStatsAndEffectsAPI.ClearOverTimeConsumable(playerId);
        }

        public static void DoShitYourself(long playerId)
        {
            AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.OtherEffects.PoopOnClothes.ToString(), 0, true);
            DoEmptyIntestine(playerId);
        }

        public static void DoTakeAPiss(long playerId)
        {
            AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.OtherEffects.PeeOnClothes.ToString(), 0, true);
            DoEmptyBladder(playerId);
        }

        public static void DoVomit(long playerId)
        {
            AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DiseaseEffects.Queasy.ToString(), 1, false);
            DoEmptyStomach(playerId);
        }

        public static void ProcessEffectsTimers(long playerId, IMyCharacter character, MyCharacterStatComponent statComponent, long timePassed)
        {
            RefreshPlayerStatComponent(playerId, statComponent);

            var weatherInfo = WeatherConstants.GetWeatherInfo(character);

            if (character.Parent == null && weatherInfo.CurrentEnvironmentType == WeatherConstants.EnvironmentDetector.Atmosphere)
            {
                switch (weatherInfo.WeatherEffect)
                {
                    case WeatherConstants.WeatherEffects.Rain:
                    case WeatherConstants.WeatherEffects.Thunderstorm:
                        IncriseWetTimer(playerId, weatherInfo.WeatherEffect, weatherInfo.WeatherLevel, weatherInfo.WeatherIntensity);
                        break;
                }
            }
            else if (character.Parent == null && weatherInfo.CurrentEnvironmentType == WeatherConstants.EnvironmentDetector.Underwater)
            {
                IncriseUnderwaterWetTimer(playerId);
            }

            if (timePassed > 0)
            {
                var playerStats = GetStatsEasyAcess(playerId);
                if (playerStats == null)
                    return;
                var armor = PlayerArmorController.GetEquipedArmor(playerId, useCache: true);
                IncDecWoundedTimer(playerId, timePassed);
                CheckWoundedEffect(playerId);
                IncDevTemperatureTimer(playerStats, playerId, timePassed, weatherInfo, armor);
                CheckTemperatureEffect(playerId);
                UpdateShieldStats(playerStats, armor, playerId);
            }
            CheckIfGetDiseases(playerId);
            CheckHungerValues(playerId);
            CheckThirstValues(playerId);
            CheckOxygenValue(playerId, character, weatherInfo.CurrentEnvironmentType);
        }

        private static void CheckOxygenValue(long playerId, IMyCharacter character, WeatherConstants.EnvironmentDetector currentEnvironmentType)
        {
            float percentValue;
            bool usingSuit = character.EnabledHelmet;
            if (currentEnvironmentType == WeatherConstants.EnvironmentDetector.Underwater)
            {
                CheckIfO2ControllerIsReady(playerId);
                percentValue = usingSuit ?
                    enterUnderWaterO2Level[playerId] :
                    0f;
            }
            else
            {
                percentValue = usingSuit ?
                    character.GetSuitGasFillLevel(ItensConstants.OXYGEN_ID.DefinitionId) :
                    character.OxygenLevel;
            }
            var checkValue = usingSuit ?
                new Vector2(0.05f, 0.2f) :
                new Vector2(0.1f, 0.8f);
            if (percentValue <= checkValue.X)
            {
                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.Suffocation.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Disoriented.ToString(), 0, true);
            }
            else if (percentValue <= checkValue.Y)
            {
                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.Disoriented.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Suffocation.ToString(), 0, true);
            }
            else
            {
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Disoriented.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Suffocation.ToString(), 0, true);
            }
        }

        private static void CheckHungerValues(long playerId)
        {
            var percentValue = statsEasyAcess[playerId].Hunger.Value / statsEasyAcess[playerId].Hunger.MaxValue;
            if (percentValue <= 0.05f)
            {
                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.Famished.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Hungry.ToString(), 0, true);
            }
            else if (percentValue <= 0.2f)
            {
                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.Hungry.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Famished.ToString(), 0, true);
            }
            else
            {
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Hungry.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Famished.ToString(), 0, true);
            }
        }

        private static void CheckThirstValues(long playerId)
        {
            var percentValue = statsEasyAcess[playerId].Thirst.Value / statsEasyAcess[playerId].Thirst.MaxValue;
            if (percentValue <= 0.05f)
            {
                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.Dehydrating.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Thirsty.ToString(), 0, true);
            }
            else if (percentValue <= 0.2f)
            {
                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.Thirsty.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Dehydrating.ToString(), 0, true);
            }
            else
            {
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Thirsty.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Dehydrating.ToString(), 0, true);
            }
        }

        private static void CheckTemperatureEffect(long playerId)
        {
            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToCold))
            {
                var exposedToCold = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToCold.ToString());
                if (exposedToCold >= StatsConstants.TEMPERATURE_EFFECTS[StatsConstants.TemperatureEffects.ExposedToCold].MaxInverseTime)
                {
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.OnFire.ToString(), 0, true);
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.Overheating.ToString(), 0, true);
                    AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.Cold.ToString(), 0, true);
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.Frosty.ToString(), 0, true);
                }
            }
            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToFreeze))
            {
                var exposedToFreeze = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToFreeze.ToString());
                if (exposedToFreeze >= StatsConstants.TEMPERATURE_EFFECTS[StatsConstants.TemperatureEffects.ExposedToFreeze].MaxInverseTime)
                {
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.OnFire.ToString(), 0, true);
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.Overheating.ToString(), 0, true);
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.Cold.ToString(), 0, true);
                    AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.Frosty.ToString(), 0, true);
                }
            }
            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToHot))
            {
                var exposedToHot = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToHot.ToString());
                if (exposedToHot >= StatsConstants.TEMPERATURE_EFFECTS[StatsConstants.TemperatureEffects.ExposedToHot].MaxInverseTime)
                {
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.OnFire.ToString(), 0, true);
                    AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.Overheating.ToString(), 0, true);
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.Cold.ToString(), 0, true);
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.Frosty.ToString(), 0, true);
                }
            }
            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToBoiling))
            {
                var exposedToBoiling = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToBoiling.ToString());
                if (exposedToBoiling >= StatsConstants.TEMPERATURE_EFFECTS[StatsConstants.TemperatureEffects.ExposedToBoiling].MaxInverseTime)
                {
                    AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.OnFire.ToString(), 0, true);
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.Overheating.ToString(), 0, true);
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.Cold.ToString(), 0, true);
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.Frosty.ToString(), 0, true);
                }
            }
        }

        private static bool HasResistenceToHot(long playerId)
        {
            foreach (var stat in StatsConstants.HOT_RESISTENCES)
            {
                if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, stat))
                    return true;
            }
            return false;
        }

        private static bool HasResistenceToCold(long playerId)
        {
            foreach (var stat in StatsConstants.COLD_RESISTENCES)
            {
                if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, stat))
                    return true;
            }
            return false;
        }

        private static Vector4 GetTemperatureRange(long playerId)
        {
            var baseRange = new Vector4(TEMPERATURE_HARD_RANGE.X, TEMPERATURE_RANGE.X, TEMPERATURE_RANGE.Y, TEMPERATURE_HARD_RANGE.Y);
            var armorInfo = PlayerArmorController.GetEquipedArmor(playerId, useCache: true);
            if (armorInfo != null && armorInfo.HasArmor)
            {
                baseRange = new Vector4(
                    baseRange.X,
                    baseRange.Y - armorInfo.ArmorDefinition.ColdResistence,
                    baseRange.Z + armorInfo.ArmorDefinition.HotResistence, 
                    baseRange.W
                );                
            }
            return baseRange;
        }

        private static readonly ConcurrentDictionary<long, PlayerShieldInfo> player_shield_status = new ConcurrentDictionary<long, PlayerShieldInfo>();
        private static readonly ConcurrentDictionary<long, bool> hasDied = new ConcurrentDictionary<long, bool>();
        private static readonly ConcurrentDictionary<long, bool> waitFullCycle = new ConcurrentDictionary<long, bool>();
        public const long TIME_BEFORE_CAN_REGENERATE = 10000;
        public const long TIME_BETWEEN_EACH_REGENERATE = 1000;
        public class PlayerShieldInfo
        {
            public long LastHit { get; set; }
            public long LastRegen { get; set; }
            public bool CanRegenerate 
            {
                get
                {
                    if (ExtendedSurvivalCoreAPI.Registered)
                    {
                        var gameTime = ExtendedSurvivalCoreAPI.GetGameTime();
                        if (LastHit == 0 || (gameTime - LastHit) > TIME_BEFORE_CAN_REGENERATE)
                        {
                            return LastRegen == 0 || (gameTime - LastRegen) > TIME_BETWEEN_EACH_REGENERATE;
                        }
                    }
                    return false;
                }
            }
        }
        public static PlayerShieldInfo GetPlayerShieldInfo(long playerId)
        {
            if (!player_shield_status.ContainsKey(playerId))
                player_shield_status[playerId] = new PlayerShieldInfo();
            return player_shield_status[playerId];
        }
        
        private static void UpdateShieldStats(PlayerStatsEasyAcess playerStats, PlayerArmorController.PlayerEquipInfo armor, long playerId)
        {
            if (playerStats != null)
            {
                if (armor != null && armor.HasArmor && armor.Shield.HasShield)
                {
                    var shieldInfo = GetPlayerShieldInfo(playerId); 
                    var energy = MyVisualScriptLogicProvider.GetPlayersEnergyLevel(playerId);
                    var drainEnergy = armor.Shield.PowerCost / 10;
                    if (playerStats.EnergyShield.Value < 1 && energy >= drainEnergy && shieldInfo.CanRegenerate)
                    {
                        var currentAmount = armor.Shield.MaxShield * playerStats.EnergyShield.Value;
                        currentAmount += armor.Shield.RechargeRate;
                        playerStats.EnergyShield.Value = currentAmount / armor.Shield.MaxShield;
                        if (playerStats.EnergyShield.Value > 1)
                            playerStats.EnergyShield.Value = 1;
                        shieldInfo.LastRegen = ExtendedSurvivalCoreAPI.GetGameTime();
                        /* Power Consume */
                        MyVisualScriptLogicProvider.SetPlayersEnergyLevel(playerId, energy - drainEnergy);
                    }
                }
                else
                {
                    playerStats.EnergyShield.Value = 0;
                }
            }
        }

        private static void UpdateFluidStats(PlayerStatsEasyAcess playerStats, PlayerArmorController.PlayerEquipInfo armor, long playerId, out bool hasCold, out bool hasHot, out IMyInventoryItem[] coldBottles, out IMyInventoryItem[] hotBottles)
        {
            hasCold = false;
            hasHot = false;
            var listaColdBottles = new List<IMyInventoryItem>();
            var listaHotBottles = new List<IMyInventoryItem>();
            if (playerStats != null)
            {
                if (armor != null && armor.HasArmor)
                {
                    hasCold = armor.HasAnyModule(EquipmentConstants.COLDTHERMALREGULATORS_MODULES);
                    hasHot = armor.HasAnyModule(EquipmentConstants.HOTTHERMALREGULATORS_MODULES);
                    if (hasCold || hasHot)
                    {
                        var inventory = playerStats.StatComponent.Entity.GetInventory();
                        if (inventory != null)
                        {
                            var bottles = new List<VRage.Game.ModAPI.Ingame.MyInventoryItem>();
                            inventory.GetItems(bottles, x => new UniqueEntityId(x.Type).typeId == typeof(MyObjectBuilder_GasContainerObject));
                            var queryColdBottle = bottles.Where(x => EquipmentConstants.COLDTHERMALBOTTLES.Contains(new UniqueEntityId(x.Type)));
                            var queryHotBottle = bottles.Where(x => EquipmentConstants.HOTTHERMALBOTTLES.Contains(new UniqueEntityId(x.Type)));
                            if (hasCold && queryColdBottle.Any())
                            {
                                foreach (var item in queryColdBottle)
                                {
                                    var itemObj = inventory.GetItemByID(item.ItemId);
                                    listaColdBottles.Add(itemObj);
                                }
                            }
                            if (hasHot && queryHotBottle.Any())
                            {
                                foreach (var item in queryHotBottle)
                                {
                                    var itemObj = inventory.GetItemByID(item.ItemId);
                                    listaHotBottles.Add(itemObj);
                                }
                            }
                        }
                    }
                }
                if (listaColdBottles.Count > 0)
                {
                    playerStats.ColdThermalFluid.Value = listaColdBottles.Sum(x => (x.Content as MyObjectBuilder_GasContainerObject).GasLevel) / listaColdBottles.Count;
                }
                else
                {
                    playerStats.ColdThermalFluid.Value = 0;
                }
                if (listaHotBottles.Count > 0)
                {
                    playerStats.HotThermalFluid.Value = listaHotBottles.Sum(x => (x.Content as MyObjectBuilder_GasContainerObject).GasLevel) / listaHotBottles.Count;
                }
                else
                {
                    playerStats.HotThermalFluid.Value = 0;
                }
            }
            coldBottles = listaColdBottles.ToArray();
            hotBottles = listaHotBottles.ToArray();
        }

        public const float THERMAL_BOTTLE_CAPACITY = 500;
        public const float THERMAL_GAS_CICLE_BASE = 1.25f;
        public static bool DoGetGasToCool(float overTemperature, PlayerArmorController.PlayerEquipInfo armor, IMyInventoryItem[] bottles, params UniqueEntityId[] ids)
        {
            var needToContinue = true;
            var module = armor.GetFirstModule(ids);
            if (module != null)
            {
                if (overTemperature < 0)
                    overTemperature *= -1;
                if (overTemperature == 0)
                    overTemperature = 0.1f;
                overTemperature = overTemperature / 30;
                var baseCost = Math.Min(THERMAL_GAS_CICLE_BASE * overTemperature, THERMAL_GAS_CICLE_BASE);
                var efficiency = module.Definition.Attributes[ArmorSystemConstants.ModuleAttribute.Efficiency];
                var gasLevelNeeded = (baseCost - (baseCost * efficiency)) / THERMAL_BOTTLE_CAPACITY;
                var inv = armor.Inventory as MyInventory;
                foreach (var bottle in bottles)
                {
                    var bottleContent = bottle.Content as MyObjectBuilder_GasContainerObject;
                    if (bottleContent.GasLevel >= gasLevelNeeded)
                    {
                        bottleContent.GasLevel -= gasLevelNeeded;
                        needToContinue = false;
                        break;
                    }
                    else
                    {
                        gasLevelNeeded -= bottleContent.GasLevel;
                        bottleContent.GasLevel = 0;
                        needToContinue = false;
                    }
                }
            }
            return needToContinue;
        }

        private static void InvokeOnGameThread(Action action, bool wait = true)
        {
            bool isExecuting = true;
            MyAPIGateway.Utilities.InvokeOnGameThread(() =>
            {
                try
                {
                    action.Invoke();
                }
                finally
                {
                    isExecuting = false;
                }
            });
            while (wait && isExecuting)
            {
                if (MyAPIGateway.Parallel != null)
                    MyAPIGateway.Parallel.Sleep(25);
            }
        }

        public static readonly Vector2 TEMPERATURE_RANGE = new Vector2(10f, 40f);
        public static readonly Vector2 TEMPERATURE_HARD_RANGE = new Vector2(0f, 50f);
        public static readonly ConcurrentDictionary<StatsConstants.TemperatureEffects, long> LAST_TEMP_TIME = new ConcurrentDictionary<StatsConstants.TemperatureEffects, long>();
        private static void IncDevTemperatureTimer(PlayerStatsEasyAcess playerStats, long playerId, long timePassed, WeatherConstants.WeatherInfo weatherInfo, PlayerArmorController.PlayerEquipInfo armor)
        {
            if (playerStats != null)
            {
                IMyInventoryItem[] coldBottles;
                IMyInventoryItem[] hotBottles;
                bool hasCold;
                bool hasHot;
                UpdateFluidStats(playerStats, armor, playerId, out hasCold, out hasHot, out coldBottles, out hotBottles);
                var needToRemove = true;
                var temperature = weatherInfo.CurrentTemperature.Y;
                var range = GetTemperatureRange(playerId);
                if (temperature > range.Z)
                {
                    if (temperature >= range.W)
                    {
                        bool needToContinue = true;
                        if (hasHot && playerStats.HotThermalFluid.Value > 0 && hotBottles.Any())
                        {
                            needToContinue = DoGetGasToCool(temperature - range.W, armor, hotBottles, EquipmentConstants.HOTTHERMALREGULATORS_MODULES);
                        }
                        if (needToContinue)
                        {
                            AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToBoiling.ToString(), 0, true);
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToHot))
                            {
                                LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToHot] = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToHot.ToString());
                                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToHot.ToString(), 0, true);
                                AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToBoiling.ToString(), LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToHot]);
                            }
                            else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.RecoveringFromExposure))
                            {
                                if (LAST_TEMP_TIME.ContainsKey(StatsConstants.TemperatureEffects.ExposedToBoiling))
                                    AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToBoiling.ToString(), LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToBoiling]);
                                else if (LAST_TEMP_TIME.ContainsKey(StatsConstants.TemperatureEffects.ExposedToHot))
                                    AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToBoiling.ToString(), LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToHot]);
                                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.RecoveringFromExposure.ToString(), 0, true);
                            }
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToFreeze))
                                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToFreeze.ToString(), 0, true);
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToCold))
                                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToCold.ToString(), 0, true);
                            needToRemove = false;
                        }
                    }
                    else
                    {
                        if (!HasResistenceToHot(playerId))
                        {
                            bool needToContinue = true;
                            if (hasHot && playerStats.HotThermalFluid.Value > 0 && hotBottles.Any())
                            {
                                needToContinue = DoGetGasToCool(temperature - range.Z, armor, hotBottles, EquipmentConstants.HOTTHERMALREGULATORS_MODULES);
                            }
                            if (needToContinue)
                            {
                                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToHot.ToString(), 0, true);
                                if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToBoiling))
                                {
                                    LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToBoiling] = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToBoiling.ToString());
                                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToBoiling.ToString(), 0, true);
                                    AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToHot.ToString(), LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToBoiling]);
                                }
                                else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.RecoveringFromExposure))
                                {
                                    if (LAST_TEMP_TIME.ContainsKey(StatsConstants.TemperatureEffects.ExposedToHot))
                                        AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToHot.ToString(), LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToHot]);
                                    else if (LAST_TEMP_TIME.ContainsKey(StatsConstants.TemperatureEffects.ExposedToBoiling))
                                        AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToHot.ToString(), LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToBoiling]);
                                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.RecoveringFromExposure.ToString(), 0, true);
                                }
                                if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToFreeze))
                                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToFreeze.ToString(), 0, true);
                                if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToCold))
                                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToCold.ToString(), 0, true);
                                needToRemove = false;
                            }
                        }
                    }
                }
                if (temperature < range.Y)
                {
                    if (temperature <= range.X)
                    {
                        bool needToContinue = true;
                        if (hasCold && playerStats.ColdThermalFluid.Value > 0 && coldBottles.Any())
                        {
                            needToContinue = DoGetGasToCool(range.X - temperature, armor, coldBottles, EquipmentConstants.COLDTHERMALREGULATORS_MODULES);
                        }
                        if (needToContinue)
                        {
                            AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToFreeze.ToString(), 0, true);
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToCold))
                            {
                                LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToCold] = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToCold.ToString());
                                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToCold.ToString(), 0, true);
                                AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToFreeze.ToString(), LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToCold]);
                            }
                            else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.RecoveringFromExposure))
                            {
                                if (LAST_TEMP_TIME.ContainsKey(StatsConstants.TemperatureEffects.ExposedToFreeze))
                                    AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToFreeze.ToString(), LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToFreeze]);
                                else if (LAST_TEMP_TIME.ContainsKey(StatsConstants.TemperatureEffects.ExposedToCold))
                                    AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToFreeze.ToString(), LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToCold]);
                                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.RecoveringFromExposure.ToString(), 0, true);
                            }
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToBoiling))
                                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToBoiling.ToString(), 0, true);
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToHot))
                                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToHot.ToString(), 0, true);
                            needToRemove = false;
                        }
                    }
                    else
                    {
                        if (!HasResistenceToCold(playerId))
                        {
                            bool needToContinue = true;
                            if (hasCold && playerStats.ColdThermalFluid.Value > 0 && coldBottles.Any())
                            {
                                needToContinue = DoGetGasToCool(range.Y - temperature, armor, coldBottles, EquipmentConstants.COLDTHERMALREGULATORS_MODULES);
                            }
                            if (needToContinue)
                            {
                                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToCold.ToString(), 0, true);
                                if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToFreeze))
                                {
                                    LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToFreeze] = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToFreeze.ToString());
                                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToFreeze.ToString(), 0, true);
                                    AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToCold.ToString(), LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToFreeze]);
                                }
                                else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.RecoveringFromExposure))
                                {
                                    if (LAST_TEMP_TIME.ContainsKey(StatsConstants.TemperatureEffects.ExposedToCold))
                                        AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToCold.ToString(), LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToCold]);
                                    else if (LAST_TEMP_TIME.ContainsKey(StatsConstants.TemperatureEffects.ExposedToFreeze))
                                        AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToCold.ToString(), LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToFreeze]);
                                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.RecoveringFromExposure.ToString(), 0, true);
                                }
                                if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToBoiling))
                                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToBoiling.ToString(), 0, true);
                                if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToHot))
                                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToHot.ToString(), 0, true);
                                needToRemove = false;
                            }
                        }
                    }
                }
                if (needToRemove)
                {
                    if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToBoiling))
                    {
                        LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToBoiling] = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToBoiling.ToString());
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToBoiling.ToString(), 0, true);
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.RecoveringFromExposure.ToString(), 0, true);
                    }
                    if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToHot))
                    {
                        LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToHot] = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToHot.ToString());
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToHot.ToString(), 0, true);
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.RecoveringFromExposure.ToString(), 0, true);
                    }
                    if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToFreeze))
                    {
                        LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToFreeze] = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToFreeze.ToString());
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToFreeze.ToString(), 0, true);
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.RecoveringFromExposure.ToString(), 0, true);
                    }
                    if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToCold))
                    {
                        LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToCold] = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToCold.ToString());
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToCold.ToString(), 0, true);
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.RecoveringFromExposure.ToString(), 0, true);
                    }
                    if (!StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.RecoveringFromExposure))
                    {
                        LAST_TEMP_TIME.Clear();
                    }
                }
            }
        }

        public static bool PlayerHasDied(long playerId)
        {
            return hasDied.ContainsKey(playerId) && hasDied[playerId];
        }

        public static bool PlayerNeedWaitFullCycle(long playerId)
        {
            return waitFullCycle.ContainsKey(playerId) && waitFullCycle[playerId];
        }

        public static void DoProcessPlayerDied(long playerId, IMyCharacter character, MyCharacterStatComponent statComponent)
        {
            try
            {
                hasDied[playerId] = true;
                waitFullCycle[playerId] = true;
            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(typeof(PlayerActionsController), ex);
            }
        }

        public static void DoProcessPlayerRemoveFixedEffect(long playerId, IMyCharacter character, MyCharacterStatComponent statComponent, string id, byte stack, bool max)
        {
            try
            {
                RefreshPlayerStatComponent(playerId, statComponent);
                var playerStats = GetStatsEasyAcess(playerId);
                if (playerStats == null)
                    return;
                StatsConstants.DamageEffects effect = StatsConstants.DamageEffects.None;
                if (StatsConstants.IsStringInFlag(id, out effect))
                {
                    if (!playerStats.MedicalDetector.HasAnyEffect() && !PlayerHasDied(playerId))
                    {
                        if (StatsConstants.ON_SELFREMOVE_APPLY_DAMAGE.ContainsKey(effect))
                        {
                            AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.ON_SELFREMOVE_APPLY_DAMAGE[effect].ToString(), 0, true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(typeof(PlayerActionsController), ex);
            }
        }

        public static void DoProcessPlayerDeath(long playerId, IMyCharacter character, MyCharacterStatComponent statComponent, Dictionary<string, float> storeStats)
        {
            try
            {
                RefreshPlayerStatComponent(playerId, statComponent);
                var playerStats = GetStatsEasyAcess(playerId);
                if (playerStats == null)
                    return;
                playerStats.SurvivalEffects.Value = storeStats[StatsConstants.FixedStats.StatsGroup01.ToString()];
                playerStats.DamageEffects.Value = storeStats[StatsConstants.FixedStats.StatsGroup02.ToString()];
                playerStats.TemperatureEffects.Value = storeStats[StatsConstants.FixedStats.StatsGroup03.ToString()];
                playerStats.DiseaseEffects.Value = storeStats[StatsConstants.FixedStats.StatsGroup04.ToString()];
                playerStats.OtherEffects.Value = storeStats[StatsConstants.FixedStats.StatsGroup05.ToString()];
                playerStats.WoundedTime.Value = storeStats[StatsConstants.ValidStats.WoundedTime.ToString()];
                playerStats.Stamina.Value = storeStats[StatsConstants.ValidStats.Stamina.ToString()];
                playerStats.Fatigue.Value = storeStats[StatsConstants.ValidStats.Fatigue.ToString()];
                playerStats.BodyEnergy.Value = storeStats[StatsConstants.ValidStats.BodyEnergy.ToString()];
                playerStats.BodyWater.Value = storeStats[StatsConstants.ValidStats.BodyWater.ToString()];
                playerStats.BodyPerformance.Value = storeStats[StatsConstants.ValidStats.BodyPerformance.ToString()];
                playerStats.BodyImmune.Value = storeStats[StatsConstants.ValidStats.BodyImmune.ToString()];
                playerStats.BodyCalories.Value = storeStats[StatsConstants.ValidStats.BodyCalories.ToString()];
                playerStats.Intestine.Value = storeStats[StatsConstants.ValidStats.Intestine.ToString()];
                playerStats.Bladder.Value = storeStats[StatsConstants.ValidStats.Bladder.ToString()];
                playerStats.BodyWeight.Value = storeStats[StatsConstants.ValidStats.BodyWeight.ToString()];
                playerStats.BodyMuscles.Value = storeStats[StatsConstants.ValidStats.BodyMuscles.ToString()];
                playerStats.BodyFat.Value = storeStats[StatsConstants.ValidStats.BodyFat.ToString()];
                playerStats.BodyProtein.Value = storeStats[StatsConstants.ValidStats.BodyProtein.ToString()];
                playerStats.BodyCarbohydrate.Value = storeStats[StatsConstants.ValidStats.BodyCarbohydrate.ToString()];
                playerStats.BodyLipids.Value = storeStats[StatsConstants.ValidStats.BodyLipids.ToString()];
                playerStats.BodyMinerals.Value = storeStats[StatsConstants.ValidStats.BodyMinerals.ToString()];
                playerStats.BodyVitamins.Value = storeStats[StatsConstants.ValidStats.BodyVitamins.ToString()];
                playerStats.RadiationTime.Value = storeStats[StatsConstants.ValidStats.RadiationTime.ToString()];
                playerStats.IntoxicationTime.Value = storeStats[StatsConstants.ValidStats.IntoxicationTime.ToString()];                
                if (playerStats.CurrentDiseaseEffects.IsFlagSet(StatsConstants.DiseaseEffects.Hyperthermia))
                {
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Hyperthermia.ToString(), 0, true);
                }
                if (playerStats.CurrentDiseaseEffects.IsFlagSet(StatsConstants.DiseaseEffects.Hypothermia))
                {
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Hypothermia.ToString(), 0, true);
                }
                if (ExtendedSurvivalSettings.Instance.HardModeEnabled)
                {
                    foreach (var item in StatsConstants.ON_DEATH_APPLY_DAMAGE)
                    {
                        if (playerStats.CurrentDamageEffects.IsFlagSet(item.Key) || playerStats.CurrentDamageEffects == item.Key)
                        {
                            foreach (var target in item.Value.Value)
                            {
                                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, target.ToString(), 0, true);
                            }
                            AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, item.Value.Key.ToString(), 0, true);
                            break;
                        }
                    }
                    if (playerStats.CurrentDamageEffects != StatsConstants.DamageEffects.None)
                    {
                        statComponent.Health.Value = statComponent.Health.MaxValue * StatsConstants.DAMAGE_HEALTH_START_VALUE[(StatsConstants.DamageEffects)StatsConstants.GetMaxSetFlagValue(playerStats.CurrentDamageEffects)];
                    }
                    var OxygenComponent = character.Components.Get<MyCharacterOxygenComponent>();
                    if (OxygenComponent != null)
                    {
                        var gasId = MyCharacterOxygenComponent.OxygenId;
                        OxygenComponent.UpdateStoredGasLevel(ref gasId, 0.25f);
                        gasId = MyCharacterOxygenComponent.HydrogenId;
                        OxygenComponent.UpdateStoredGasLevel(ref gasId, 0.1f);
                    }
                }
                else
                {
                    playerStats.DamageEffects.Value = (int)StatsConstants.DamageEffects.None;
                }
                CheckMinimalToLive(playerStats);
                hasDied[playerId] = false;
            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(typeof(PlayerActionsController), ex);
            }
        }

        private static void CheckMinimalToLive(PlayerStatsEasyAcess playerStats)
        {
            if (playerStats.BodyWater.Value <= 0)
            {
                playerStats.BodyWater.Value = PlayerBodyConstants.ReviveWaterReserve;
            }
        }

        private static void IncDecWoundedTimer(long playerId, long timePassed)
        {
            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDamageEffects, StatsConstants.DamageEffects.Wounded) ||
                StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDamageEffects, StatsConstants.DamageEffects.DeepWounded) ||
                StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDamageEffects, StatsConstants.DamageEffects.BrokenBones))
            {
                if (statsEasyAcess[playerId].WoundedTime.Value < statsEasyAcess[playerId].WoundedTime.MaxValue)
                {
                    var finalValue = (float)timePassed;
                    var maxDamageEffect = (StatsConstants.DamageEffects)StatsConstants.GetMaxSetFlagValue(statsEasyAcess[playerId].CurrentDamageEffects);
                    statsEasyAcess[playerId].WoundedTime.Increase(finalValue * StatsConstants.TIME_MULTIPLIER_FACTOR[maxDamageEffect], null);
                }
            }
            else
            {
                statsEasyAcess[playerId].WoundedTime.Value = 0;
            }
        }


        private static void CheckWoundedEffect(long playerId)
        {
            if (statsEasyAcess[playerId].WoundedTime.Value >= statsEasyAcess[playerId].WoundedTime.MaxValue)
            {
                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DiseaseEffects.Infected.ToString(), 1, false);
                statsEasyAcess[playerId].WoundedTime.Value = 0;
            }
        }

        private static void IncriseUnderwaterWetTimer(long playerId)
        {
            AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.Wet.ToString(), 0, true);
        }

        private static void IncriseWetTimer(long playerId, WeatherConstants.WeatherEffects effect, WeatherConstants.WeatherEffectsLevel level, float intensity)
        {
            AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.Wet.ToString(), 0, true);
        }

        private static bool CheckChance(float chance)
        {
            return MyUtils.GetRandomFloat(0, 1) <= chance;
        }

        private static void CheckIfGetDiseases(long playerId)
        {
            float chance = ChanceToGetDisease(playerId, StatsConstants.DiseaseEffects.Flu);
            if (chance > 0)
            {
                if (CheckChance(chance))
                {
                    AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DiseaseEffects.Flu.ToString(), 0, true);
                }
            }
            chance = ChanceToGetDisease(playerId, StatsConstants.DiseaseEffects.Pneumonia);
            if (chance > 0)
            {
                if (CheckChance(chance))
                {
                    AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DiseaseEffects.Pneumonia.ToString(), 0, true);
                }
            }
            chance = ChanceToGetDisease(playerId, StatsConstants.DiseaseEffects.Hypothermia);
            if (chance > 0)
            {
                if (CheckChance(chance))
                {
                    AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DiseaseEffects.Hypothermia.ToString(), 1, true);
                }
            }
            chance = ChanceToGetDisease(playerId, StatsConstants.DiseaseEffects.Hyperthermia);
            if (chance > 0)
            {
                if (CheckChance(chance))
                {
                    AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DiseaseEffects.Hyperthermia.ToString(), 1, true);
                }
            }
            CheckStomach(playerId);
            CheckIntestine(playerId);
            CheckBladder(playerId);
            CheckStarvation(playerId);
            CheckDehydration(playerId);
            CheckFatigue(playerId);
            CheckWeight(playerId);
        }

        private static void CheckStomach(long playerId)
        {
            var percent = statsEasyAcess[playerId].Stomach.Value / statsEasyAcess[playerId].Stomach.MaxValue;
            var needToCheckStomach = true;
            if (!StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.StomachBursting))
            {
                if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.FullStomach))
                {
                    if (percent >= 0.9f)
                    {
                        needToCheckStomach = false;
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.FullStomach.ToString(), 0, true);
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.StomachBursting.ToString(), 0, true);
                    }
                }
            }
            else
            {
                needToCheckStomach = false;
                if (percent < 0.9f)
                {
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.StomachBursting.ToString(), 0, true);
                    needToCheckStomach = true;
                }
            }
            if (needToCheckStomach)
            {
                if (!StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.FullStomach))
                {
                    if (percent >= 0.75f)
                    {
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.FullStomach.ToString(), 0, true);
                        needToCheckStomach = false;
                    }
                }
                else
                {
                    if (percent < 0.75f)
                    {
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.FullStomach.ToString(), 0, true);
                        needToCheckStomach = true;
                    }
                }
                if (needToCheckStomach)
                {
                    if (!StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.EmptyStomach))
                    {
                        if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.StomachGrowling))
                        {
                            if (percent <= 0.05f)
                            {
                                needToCheckStomach = false;
                                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.StomachGrowling.ToString(), 0, true);
                                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.EmptyStomach.ToString(), 1, false);
                            }
                        }
                    }
                    else
                    {
                        needToCheckStomach = false;
                        if (percent > 0.05f)
                        {
                            AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.EmptyStomach.ToString(), 0, true);
                            needToCheckStomach = true;
                        }
                        else
                        {
                            var emptyStomach = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.SurvivalEffects.EmptyStomach.ToString());
                            if (emptyStomach >= StatsConstants.GetSurvivalEffectMaxInverseTime(StatsConstants.SurvivalEffects.EmptyStomach))
                            {
                                AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, StatsConstants.SurvivalEffects.EmptyStomach.ToString(), 0);
                                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.EmptyStomach.ToString(), 1, false);
                            }
                        }
                    }
                    if (needToCheckStomach)
                    {
                        if (!StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.StomachGrowling))
                        {
                            if (percent <= 0.15f)
                            {
                                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.StomachGrowling.ToString(), 0, true);
                            }
                        }
                        else
                        {
                            if (percent > 0.15f)
                            {
                                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.StomachGrowling.ToString(), 0, true);
                            }
                        }
                    }
                }
            }
        }

        public static void DoEatStartFood(long playerId)
        {
            AdvancedStatsAndEffectsAPI.DoPlayerConsume(playerId, FoodConstants.SANDWICH_ID.DefinitionId);
            AdvancedStatsAndEffectsAPI.DoPlayerConsume(playerId, ItensConstants.WATER_FLASK_SMALL_ID.DefinitionId);
        }

        private static void CheckIntestine(long playerId)
        {
            var percent = statsEasyAcess[playerId].Intestine.Value / statsEasyAcess[playerId].Intestine.MaxValue;
            var needToCheckStarvation = true;
            if (!StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.GutBurst))
            {
                if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.FullGut))
                {
                    if (percent >= 0.9f)
                    {
                        needToCheckStarvation = false;
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.FullGut.ToString(), 0, true);
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.GutBurst.ToString(), 0, true);
                    }
                }
            }
            else
            {
                needToCheckStarvation = false;
                if (percent < 0.9f)
                {
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.GutBurst.ToString(), 0, true);
                    needToCheckStarvation = true;
                }
            }
            if (needToCheckStarvation)
            {
                if (!StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.FullGut))
                {
                    if (percent >= 0.75f)
                    {
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.FullGut.ToString(), 0, true);
                    }
                }
                else
                {
                    if (percent < 0.75f)
                    {
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.FullGut.ToString(), 0, true);
                    }
                }
            }
        }

        private static void CheckBladder(long playerId)
        {
            var percent = statsEasyAcess[playerId].Bladder.Value / statsEasyAcess[playerId].Bladder.MaxValue;
            var needToCheckStarvation = true;
            if (!StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.BladderBurst))
            {
                if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.FullBladder))
                {
                    if (percent >= 0.9f)
                    {
                        needToCheckStarvation = false;
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.FullBladder.ToString(), 0, true);
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.BladderBurst.ToString(), 0, true);
                    }
                }
            }
            else
            {
                needToCheckStarvation = false;
                if (percent < 0.9f)
                {
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.BladderBurst.ToString(), 0, true);
                    needToCheckStarvation = true;
                }
            }
            if (needToCheckStarvation)
            {
                if (!StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.FullBladder))
                {
                    if (percent >= 0.75f)
                    {
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.FullBladder.ToString(), 0, true);
                    }
                }
                else
                {
                    if (percent < 0.75f)
                    {
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.FullBladder.ToString(), 0, true);
                    }
                }
            }
        }

        private static void CheckFatigue(long playerId)
        {
            var percent = statsEasyAcess[playerId].Fatigue.Value / statsEasyAcess[playerId].Fatigue.MaxValue;
            var needToCheckStarvation = true;
            if (!StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.ExtremelyTired))
            {
                if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.Tired))
                {
                    if (percent >= 0.8f)
                    {
                        needToCheckStarvation = false;
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Tired.ToString(), 0, true);
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.ExtremelyTired.ToString(), 0, true);
                    }
                }
            }
            else
            {
                needToCheckStarvation = false;
                if (percent < 0.8f)
                {
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.ExtremelyTired.ToString(), 0, true);
                    needToCheckStarvation = true;
                }
            }
            if (needToCheckStarvation)
            {
                if (!StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.Tired))
                {
                    if (percent >= 0.6f)
                    {
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.Tired.ToString(), 0, true);
                    }
                }
                else
                {
                    if (percent < 0.6f)
                    {
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Tired.ToString(), 0, true);
                    }
                }
            }
        }

        private static void CheckWeight(long playerId)
        {
            var height = 1.8f;
            var bmi = statsEasyAcess[playerId].BodyWeight.Value / (height * height);
            if (bmi >= 40)
            {
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Obesity.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereObesity.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Rickets.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereRickets.ToString(), 0, true);
            }
            else if (bmi >= 30)
            {
                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DiseaseEffects.Obesity.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereObesity.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Rickets.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereRickets.ToString(), 0, true);
            }
            else if (bmi <= 17)
            {
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Obesity.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereObesity.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DiseaseEffects.Rickets.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereRickets.ToString(), 0, true);
            }
            else if (bmi <= 14)
            {
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Obesity.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereObesity.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Rickets.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereRickets.ToString(), 0, true);
            }
            else
            {
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Obesity.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereObesity.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Rickets.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereRickets.ToString(), 0, true);
            }
        }

        private static void CheckDehydration(long playerId)
        {
            var percent = statsEasyAcess[playerId].BodyWater.Value / statsEasyAcess[playerId].BodyWater.MaxValue;
            var needToCheckDehydration = true;
            if (!StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.SevereDehydration))
            {
                if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Dehydration))
                {
                    if (percent <= 0.05f)
                    {
                        needToCheckDehydration = false;
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Dehydration.ToString(), 0, true);
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereDehydration.ToString(), 0, true);
                    }
                }
            }
            else
            {
                needToCheckDehydration = false;
                if (percent > 0.05f)
                {
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereDehydration.ToString(), 0, true);
                    needToCheckDehydration = true;
                }
            }
            if (needToCheckDehydration)
            {
                if (!StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Dehydration))
                {
                    if (percent <= 0.25f)
                    {
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DiseaseEffects.Dehydration.ToString(), 0, true);
                    }
                }
                else
                {
                    if (percent > 0.25f)
                    {
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Dehydration.ToString(), 0, true);
                    }
                }
            }
        }

        private static void CheckStarvation(long playerId)
        {
            var percent = statsEasyAcess[playerId].BodyEnergy.Value / statsEasyAcess[playerId].BodyEnergy.MaxValue;
            var needToCheckStarvation = true;
            if (!StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.SevereStarvation))
            {
                if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Starvation))
                {
                    if (percent <= 0.05f)
                    {
                        needToCheckStarvation = false;
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Starvation.ToString(), 0, true);
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereStarvation.ToString(), 0, true);
                    }
                }
            }
            else
            {
                needToCheckStarvation = false;
                if (percent > 0.05f)
                {
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereStarvation.ToString(), 0, true);
                    needToCheckStarvation = true;
                }
            }
            if (needToCheckStarvation)
            {
                if (!StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Starvation))
                {
                    if (percent <= 0.25f)
                    {
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DiseaseEffects.Starvation.ToString(), 0, true);
                    }
                }
                else
                {
                    if (percent > 0.25f)
                    {
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Starvation.ToString(), 0, true);
                    }
                }
            }
        }

        private static ConcurrentDictionary<long, float> enterUnderWaterO2Level = new ConcurrentDictionary<long, float>();
        private static ConcurrentDictionary<long, float> enterUnderWaterO2Consumption = new ConcurrentDictionary<long, float>();
        private static ConcurrentDictionary<long, bool> enterUnderWater = new ConcurrentDictionary<long, bool>();

        private static float GasRefillRation
        {
            get
            {
                return MyCharacterOxygenComponent.GAS_REFILL_RATION * 1.25f;
            }
        }

        private static float GetNoO2DamageAmount(IMyCharacter character)
        {
            return (character.Definition as MyCharacterDefinition).DamageAmountAtZeroPressure;
        }

        private static void CheckIfO2ControllerIsReady(long playerId)
        {
            if (!enterUnderWaterO2Level.ContainsKey(playerId))
                enterUnderWaterO2Level[playerId] = 0;
        }

        public static void ProcessUnderwater(long playerId, IMyCharacter character, WeatherConstants.EnvironmentDetector currentEnvironmentType)
        {
            CheckIfO2ControllerIsReady(playerId);
            if (currentEnvironmentType == WeatherConstants.EnvironmentDetector.Underwater && !character.IsDead)
            {
                var OxygenComponent = character.Components.Get<MyCharacterOxygenComponent>();
                if (!enterUnderWater.ContainsKey(playerId) || !enterUnderWater[playerId])
                {
                    enterUnderWater[playerId] = true;
                    enterUnderWaterO2Level[playerId] = OxygenComponent.GetGasFillLevel(MyCharacterOxygenComponent.OxygenId);
                    enterUnderWaterO2Consumption[playerId] = (character.Definition as MyCharacterDefinition).OxygenConsumption / OxygenComponent.OxygenCapacity;
                }
                if (MyAPIGateway.Session.SessionSettings.EnableOxygen)
                {
                    if (character.EnabledHelmet)
                    {
                        if (enterUnderWaterO2Level[playerId] > 0)
                            enterUnderWaterO2Level[playerId] -= enterUnderWaterO2Consumption[playerId];
                    }
                    else if (character.CanTakeDamage())
                    {
                        character.DoDamage(GetNoO2DamageAmount(character), MyDamageType.Asphyxia, true);
                    }
                    if (enterUnderWaterO2Level[playerId] < 0)
                        enterUnderWaterO2Level[playerId] = 0;

                    if (OxygenComponent.SuitOxygenLevel < GasRefillRation)
                    {
                        if (ExtendedSurvivalCoreAPI.Registered)
                        {
                            var InventoryObserver = ExtendedSurvivalCoreAPI.GetInventoryObserver(character, 0);
                            if (InventoryObserver != Guid.Empty)
                            {
                                var bottles = ExtendedSurvivalCoreAPI.GetItemInfoByGasId(InventoryObserver, ItensConstants.OXYGEN_ID.DefinitionId);
                                if (bottles != null && bottles.Length > 0)
                                {
                                    var Inventory = character.GetInventory();
                                    foreach (var bottle in bottles)
                                    {
                                        var item = Inventory.GetItemByID(bottle.ItemId);
                                        if (item != null)
                                        {
                                            var gasContainer = item.Content as MyObjectBuilder_GasContainerObject;
                                            if (gasContainer != null)
                                            {
                                                var physicalItem = MyDefinitionManager.Static.GetPhysicalItemDefinition(gasContainer) as MyOxygenContainerDefinition;
                                                if (physicalItem.StoredGasId != ItensConstants.OXYGEN_ID.DefinitionId)
                                                    continue;
                                                float gasAmount = gasContainer.GasLevel * physicalItem.Capacity;
                                                float transferredAmount = Math.Min(gasAmount, (1f - enterUnderWaterO2Level[playerId]) * OxygenComponent.OxygenCapacity);
                                                gasContainer.GasLevel = Math.Max((gasAmount - transferredAmount) / physicalItem.Capacity, 0f);
                                                float trasnferredFillLevel = transferredAmount / OxygenComponent.OxygenCapacity;
                                                enterUnderWaterO2Level[playerId] += trasnferredFillLevel;
                                                if (enterUnderWaterO2Level[playerId] == 1f)
                                                    break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    OxygenComponent.SuitOxygenLevel = enterUnderWaterO2Level[playerId];

                    if (enterUnderWaterO2Level[playerId] <= 0 && character.CanTakeDamage())
                    {
                        character.DoDamage(GetNoO2DamageAmount(character), MyDamageType.Asphyxia, true);
                    }
                }
            }
            else
            {
                enterUnderWater[playerId] = false;
            }
        }

        public static float CurrentBaseCargoVolume
        {
            get
            {
                return MyAPIGateway.Session.SessionSettings.InventorySizeMultiplier * 0.4f;
            }
        }

        public static float CurrentCargoVolume
        {
            get
            {
                return CurrentBaseCargoVolume;
            }
        }

        public static float CurrentBaseCargoMass
        {
            get
            {
                return MyAPIGateway.Session.SessionSettings.InventorySizeMultiplier * 1000f;
            }
        }

        public static float CurrentCargoMass
        {
            get
            {
                return CurrentBaseCargoMass;
            }
        }

        public static void ProcessCargoMax(IMyCharacter character)
        {
            var Inventory = character.GetInventory() as MyInventory;
            if (Inventory != null)
            {
                if ((float)Inventory.MaxVolume != CurrentCargoVolume)
                {
                    var definition = new MyInventoryComponentDefinition
                    {
                        RemoveEntityOnEmpty = false,
                        MultiplierEnabled = false,
                        MaxItemCount = int.MaxValue,
                        Mass = CurrentCargoMass,
                        Volume = CurrentCargoVolume,
                        InputConstraint = new MyInventoryConstraint("PlayerInventory", null, false)
                    };
                    Inventory.Init(definition);
                }
            }
        }

        public static void CheckHealthValue(long playerId, MyCharacterStatComponent statComponent)
        {
            var percentValue = statComponent.Health.Value / statComponent.Health.MaxValue;
            if (percentValue == 1)
            {
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DamageEffects.Contusion.ToString(), 0, true);
            }
        }

        public static void CheckHealthDamage(long playerId, MyCharacterStatComponent statComponent, float damage)
        {
            RefreshPlayerStatComponent(playerId, statComponent);
            var percentDamage = damage / statComponent.Health.MaxValue;
            var finalHealth = statComponent.Health.Value - damage;
            if (finalHealth > 0 && !PlayerHasDied(playerId)) /* No effect on isntant death */
            {
                var percentValue = finalHealth / statComponent.Health.MaxValue;
                if (percentDamage >= 0.6f || percentValue <= 0.15f)
                {
                    AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DamageEffects.BrokenBones.ToString(), 0, true);
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DamageEffects.DeepWounded.ToString(), 0, true);
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DamageEffects.Wounded.ToString(), 0, true);
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DamageEffects.Contusion.ToString(), 0, true);
                }
                else if (percentDamage >= 0.4f || percentValue <= 0.3f)
                {
                    if (!StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDamageEffects, StatsConstants.DamageEffects.BrokenBones))
                    {
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DamageEffects.DeepWounded.ToString(), 0, true);
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DamageEffects.Wounded.ToString(), 0, true);
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DamageEffects.Contusion.ToString(), 0, true);
                    }
                }
                else if (percentDamage >= 0.2f || percentValue <= 0.45f)
                {
                    if (!StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDamageEffects, StatsConstants.DamageEffects.BrokenBones) &&
                        !StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDamageEffects, StatsConstants.DamageEffects.DeepWounded))
                    {
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DamageEffects.Wounded.ToString(), 0, true);
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DamageEffects.Contusion.ToString(), 0, true);
                    }
                }
                else if (percentDamage >= 0.1f || percentValue <= 0.6f)
                {
                    if (!StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDamageEffects, StatsConstants.DamageEffects.BrokenBones) &&
                        !StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDamageEffects, StatsConstants.DamageEffects.DeepWounded) &&
                        !StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDamageEffects, StatsConstants.DamageEffects.Wounded))
                    {
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DamageEffects.Contusion.ToString(), 0, true);
                    }
                }
            }
        }

        public static void CheckValuesToDoDamage(long playerId, IMyCharacter character, MyCharacterStatComponent statComponent)
        {
            if (character.CanTakeDamage())
            {
                try
                {
                    RefreshPlayerStatComponent(playerId, statComponent);
                    if (statsEasyAcess[playerId].BodyWater.Value == 0)
                    {
                        character.Kill();
                    }
                }
                catch (Exception ex)
                {
                    ExtendedSurvivalStatsLogging.Instance.LogError(typeof(PlayerActionsController), ex);
                }
            }
        }

        private static ConcurrentDictionary<long, float> sedentaryTime = new ConcurrentDictionary<long, float>();
        private static ConcurrentDictionary<long, float> waterToConsume = new ConcurrentDictionary<long, float>();
        private static ConcurrentDictionary<long, float> lastCaloriesValue = new ConcurrentDictionary<long, float>();
        private static ConcurrentDictionary<long, float> lastCaloriesChange = new ConcurrentDictionary<long, float>();
        private static ConcurrentDictionary<long, PlayerStatsEasyAcess> statsEasyAcess = new ConcurrentDictionary<long, PlayerStatsEasyAcess>();

        public static PlayerStatsEasyAcess GetStatsEasyAcess(long playerId)
        {
            if (statsEasyAcess.ContainsKey(playerId) && statsEasyAcess[playerId].IsValid)
                return statsEasyAcess[playerId];
            return null;
        }

        public static void RefreshPlayerStatComponent(long playerId, MyCharacterStatComponent statComponent)
        {
            if (!statsEasyAcess.ContainsKey(playerId))
                statsEasyAcess[playerId] = new PlayerStatsEasyAcess(playerId, statComponent);
            else
                statsEasyAcess[playerId].StatComponent = statComponent;
        }

        public static void DoProcessItemConsume(long playerId, MyCharacterStatComponent statComponent, UniqueEntityId itemId)
        {
            if (FoodConstants.FOOD_DEFINITIONS.ContainsKey(itemId))
            {
                RefreshPlayerStatComponent(playerId, statComponent);
                var statControl = GetStatsEasyAcess(playerId);
                bool hasVomit = false;
                if (statControl.CurrentDiseaseEffects.IsFlagSet(StatsConstants.DiseaseEffects.Queasy))
                {
                    var stack = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatStack(playerId, StatsConstants.DiseaseEffects.Queasy.ToString());
                    var chanceToVomit = stack * StatsConstants.CHANCE_TO_VOMIT;
                    if (CheckChance(chanceToVomit))
                    {
                        DoVomit(playerId);
                        hasVomit = true;
                    }
                }
                if (statControl.CurrentDiseaseEffects.IsFlagSet(StatsConstants.DiseaseEffects.Dysentery))
                {
                    var stack = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatStack(playerId, StatsConstants.DiseaseEffects.Dysentery.ToString());
                    var chanceToVomit = stack * StatsConstants.CHANCE_TO_VOMIT / 2;
                    var chanceToPoop = stack * StatsConstants.CHANCE_TO_POOP;
                    if (!hasVomit && CheckChance(chanceToVomit))
                    {
                        DoVomit(playerId);
                    }
                    if (CheckChance(chanceToPoop))
                    {
                        DoShitYourself(playerId);
                    }
                }
            }
            if (MedicalConstants.MEDICAL_DEFINITIONS.ContainsKey(itemId))
            {
                RefreshPlayerStatComponent(playerId, statComponent);
                var statControl = GetStatsEasyAcess(playerId);
                var def = MedicalConstants.MEDICAL_DEFINITIONS[itemId];
                if (def.ReduceDisease != null && def.ReduceDisease.Any())
                {
                    foreach (var disease in def.ReduceDisease.Keys)
                    {
                        if (statControl.CurrentDiseaseEffects.IsFlagSet(disease))
                        {
                            var timeToRemove = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, disease.ToString());
                            if (timeToRemove > 0)
                            {
                                timeToRemove -= (long)def.ReduceDisease[disease];
                                if (timeToRemove <= 0)
                                    statControl.MedicalDetector.ClearEffects();
                                AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, disease.ToString(), Math.Max(timeToRemove, 0));
                            }
                        }
                    }
                }
                if (def.ReduceDamage != null && def.ReduceDamage.Any())
                {
                    foreach (var damage in def.ReduceDamage.Keys)
                    {
                        if (statControl.CurrentDamageEffects.IsFlagSet(damage))
                        {
                            var timeToRemove = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, damage.ToString());
                            if (timeToRemove > 0)
                            {
                                timeToRemove -= (long)def.ReduceDamage[damage];
                                if (timeToRemove <= 0)
                                    statControl.MedicalDetector.ClearEffects();
                                AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, damage.ToString(), Math.Max(timeToRemove, 0));
                            }
                        }
                    }
                }
            }
        }

        public static void DoPlayerCycle(long playerId, long spendTime, MyCharacterStatComponent statComponent)
        {
            var staminaSpended = StaminaController.GetSpendedStamina(playerId);

            if (!sedentaryTime.ContainsKey(playerId))
                sedentaryTime[playerId] = 0;
            if (staminaSpended == 0)
            {
                sedentaryTime[playerId] += spendTime;
            }
            else if (sedentaryTime[playerId] > 0)
            {
                sedentaryTime[playerId] -= spendTime * 10;
                if (sedentaryTime[playerId] < 0)
                    sedentaryTime[playerId] = 0;
            }
            RefreshPlayerStatComponent(playerId, statComponent);

            DoConsumeCicle(playerId, staminaSpended);

            var currentCaloriesValue = statsEasyAcess[playerId].BodyCalories.Value;
            lastCaloriesChange[playerId] = !lastCaloriesValue.ContainsKey(playerId) ? 0 : currentCaloriesValue - lastCaloriesValue[playerId];
            lastCaloriesValue[playerId] = currentCaloriesValue;

            DoBladderCicle(playerId);
            DoCheckBodyState(playerId);
            DoStomachCicle(playerId);
            float weightChange = DoCheckBodyWeight(playerId, lastCaloriesChange[playerId]);
            if (weightChange < 0)
            {
                /* The body always consumes muscle first during body loss with no protein reserve and is sedentary */

            }
            if (weightChange > 0)
            {
                /* The body always gain fat with no stamina spend or no protein reserve */

            }
            else
            {
                /* No body change, but transform fat into muscle with stamina spend and protein reserve */

            }
            StaminaController.ClearSpendedStamina(playerId);
            waitFullCycle[playerId] = false;
        }

        public static float ChanceToGetDisease(long playerId, StatsConstants.DiseaseEffects disease)
        {
            float baseValue = 0;
            switch (disease)
            {
                case StatsConstants.DiseaseEffects.Flu:
                    // Temperature Effects
                    if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.Cold))
                    {
                        baseValue += 0.015f;
                    }
                    else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.Frosty))
                    {
                        baseValue += 0.03f;
                    }
                    if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.Wet))
                    {
                        baseValue *= 2f;
                    }
                    break;
                case StatsConstants.DiseaseEffects.Pneumonia:
                    // Temperature Effects
                    if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Flu))
                    {
                        if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.Cold))
                        {
                            baseValue += 0.005f;
                        }
                        else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.Frosty))
                        {
                            baseValue += 0.01f;
                        }
                    }
                    if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.Wet))
                    {
                        baseValue *= 2f;
                    }
                    break;
                case StatsConstants.DiseaseEffects.Hypothermia:
                    if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.Frosty))
                    {
                        var exposedToCold = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToCold.ToString());
                        var exposedToFreeze = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToFreeze.ToString());
                        if (exposedToCold > 0)
                            baseValue += 0.005f;
                        if (exposedToFreeze > 0)
                            baseValue += 0.01f;
                        if (baseValue > 0)
                        {
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Rickets))
                                baseValue *= 2f;
                            else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.SevereRickets))
                                baseValue *= 4f;
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.Wet))
                                baseValue *= 2f;
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Obesity))
                                baseValue /= 2f;
                            else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.SevereObesity))
                                baseValue /= 4f;
                            var hypothermiaStack = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatStack(playerId, StatsConstants.DiseaseEffects.Hypothermia.ToString());
                            if (hypothermiaStack > 0)
                                baseValue /= hypothermiaStack + 1;
                        }
                    }
                    break;
                case StatsConstants.DiseaseEffects.Hyperthermia:
                    if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.OnFire))
                    {
                        var exposedToHot = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToHot.ToString());
                        var exposedToBoiling = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToBoiling.ToString());
                        if (exposedToHot > 0)
                            baseValue += 0.005f;
                        if (exposedToBoiling > 0)
                            baseValue += 0.01f;
                        if (baseValue > 0)
                        {
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Obesity))
                                baseValue *= 2f;
                            else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.SevereObesity))
                                baseValue *= 4f;
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.Wet))
                                baseValue /= 2f;
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Rickets))
                                baseValue /= 2f;
                            else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.SevereRickets))
                                baseValue /= 4f;
                            var hyperthermiaStack = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatStack(playerId, StatsConstants.DiseaseEffects.Hyperthermia.ToString());
                            if (hyperthermiaStack > 0)
                                baseValue /= hyperthermiaStack + 1;
                        }
                    }
                    break;
            }
            return baseValue;
        }

        public static float NegativeStatsMultiplier(long playerId, HealthController.HealthValueModifier option)
        {
            float baseValue = 1;
            switch (option)
            {
                case HealthController.HealthValueModifier.RegenerationFactor:
                    // Damage Effects
                    if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDamageEffects, StatsConstants.DamageEffects.Contusion))
                    {
                        baseValue -= 0.1f;
                    }
                    else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDamageEffects, StatsConstants.DamageEffects.Wounded))
                    {
                        baseValue -= 0.3f;
                    }
                    else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDamageEffects, StatsConstants.DamageEffects.DeepWounded))
                    {
                        baseValue -= 0.5f;
                    }
                    else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDamageEffects, StatsConstants.DamageEffects.BrokenBones))
                    {
                        baseValue -= 0.7f;
                    }
                    // Disease Effects
                    if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Infected))
                    {
                        var stack = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatStack(playerId, StatsConstants.DiseaseEffects.Infected.ToString());
                        baseValue -= 0.25f * stack;
                    }

                    break;
                case HealthController.HealthValueModifier.MaximumRegenerationHealth:
                    // Damage Effects
                    if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDamageEffects, StatsConstants.DamageEffects.Contusion))
                    {
                        baseValue -= 0.2f;
                    }
                    else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDamageEffects, StatsConstants.DamageEffects.Wounded))
                    {
                        baseValue -= 0.4f;
                    }
                    else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDamageEffects, StatsConstants.DamageEffects.DeepWounded))
                    {
                        baseValue -= 0.6f;
                    }
                    else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDamageEffects, StatsConstants.DamageEffects.BrokenBones))
                    {
                        baseValue -= 0.8f;
                    }
                    // Disease Effects
                    if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Infected))
                    {
                        var stack = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatStack(playerId, StatsConstants.DiseaseEffects.Infected.ToString());
                        baseValue -= 0.05f * stack;
                    }

                    break;
                case HealthController.HealthValueModifier.MaxHealth:
                    // Damage Effects
                    if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDamageEffects, StatsConstants.DamageEffects.Contusion))
                    {
                        baseValue -= 0.15f;
                    }
                    else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDamageEffects, StatsConstants.DamageEffects.Wounded))
                    {
                        baseValue -= 0.3f;
                    }
                    else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDamageEffects, StatsConstants.DamageEffects.DeepWounded))
                    {
                        baseValue -= 0.45f;
                    }
                    else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDamageEffects, StatsConstants.DamageEffects.BrokenBones))
                    {
                        baseValue -= 0.6f;
                    }
                    // Disease Effects
                    if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Infected))
                    {
                        var stack = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatStack(playerId, StatsConstants.DiseaseEffects.Infected.ToString());
                        baseValue -= 0.05f * stack;
                    }

                    break;
            }
            return Math.Max(baseValue, 0);
        }

        public static float NegativeStatsMultiplier(long playerId, StatsConstants.ValidStats targetStat, int option = 0)
        {
            float baseValue = 1;
            switch (targetStat)
            {
                case StatsConstants.ValidStats.Stamina:

                    switch ((StaminaController.StaminaValueModifier)option)
                    {
                        case StaminaController.StaminaValueModifier.HigherStaminaExpenditure:
                            // Survival Effects
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.Thirsty))
                            {
                                baseValue += 0.15f;
                            }
                            else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.Dehydrating))
                            {
                                baseValue += 0.3f;
                            }
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.Hungry))
                            {
                                baseValue += 0.15f;
                            }
                            else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.Famished))
                            {
                                baseValue += 0.3f;
                            }
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.FullStomach))
                            {
                                baseValue += 0.125f;
                            }
                            else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.StomachBursting))
                            {
                                baseValue += 0.25f;
                            }
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.FullGut))
                            {
                                baseValue += 0.125f;
                            }
                            else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.GutBurst))
                            {
                                baseValue += 0.25f;
                            }
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.FullBladder))
                            {
                                baseValue += 0.125f;
                            }
                            else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.BladderBurst))
                            {
                                baseValue += 0.25f;
                            }
                            // Temperature Effects
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.Overheating))
                            {
                                baseValue += 0.15f;
                            }
                            else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.OnFire))
                            {
                                baseValue += 0.3f;
                            }
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.Cold))
                            {
                                baseValue += 0.15f;
                            }
                            else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.Frosty))
                            {
                                baseValue += 0.3f;
                            }
                            // Disease Effects
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Queasy))
                            {
                                var stack = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatStack(playerId, StatsConstants.DiseaseEffects.Queasy.ToString());
                                baseValue += 0.15f * stack;
                            }
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Dysentery))
                            {
                                var stack = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatStack(playerId, StatsConstants.DiseaseEffects.Dysentery.ToString());
                                baseValue += 0.3f * stack;
                            }
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Starvation))
                            {
                                baseValue += 0.2f;
                            }
                            else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.SevereStarvation))
                            {
                                baseValue += 0.4f;
                            }
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Dehydration))
                            {
                                baseValue += 0.2f;
                            }
                            else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.SevereDehydration))
                            {
                                baseValue += 0.4f;
                            }
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Obesity))
                            {
                                baseValue += 0.25f;
                            }
                            else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.SevereObesity))
                            {
                                baseValue += 0.5f;
                            }
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Rickets))
                            {
                                baseValue += 0.25f;
                            }
                            else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.SevereRickets))
                            {
                                baseValue += 0.5f;
                            }
                            // Other Effects
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentOtherEffects, StatsConstants.OtherEffects.PoopOnClothes))
                            {
                                baseValue += 0.3f;
                            }
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentOtherEffects, StatsConstants.OtherEffects.PeeOnClothes))
                            {
                                baseValue += 0.15f;
                            }

                            break;
                        case StaminaController.StaminaValueModifier.MaximumStaminaReduction:
                            // Survival Effects
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.Disoriented))
                            {
                                baseValue -= 0.25f;
                            }
                            else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.Suffocation))
                            {
                                baseValue -= 0.5f;
                            }
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.Tired))
                            {
                                baseValue -= 0.25f;
                            }
                            else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.ExtremelyTired))
                            {
                                baseValue -= 0.5f;
                            }
                            // Damage Effects
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDamageEffects, StatsConstants.DamageEffects.Contusion))
                            {
                                baseValue -= 0.1f;
                            }
                            else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDamageEffects, StatsConstants.DamageEffects.Wounded))
                            {
                                baseValue -= 0.2f;
                            }
                            else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDamageEffects, StatsConstants.DamageEffects.DeepWounded))
                            {
                                baseValue -= 0.3f;
                            }
                            else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDamageEffects, StatsConstants.DamageEffects.BrokenBones))
                            {
                                baseValue -= 0.4f;
                            }
                            // Disease Effects
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Flu))
                            {
                                baseValue -= 0.25f;
                            }
                            else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Pneumonia))
                            {
                                baseValue -= 0.5f;
                            }
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Infected))
                            {
                                var stack = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatStack(playerId, StatsConstants.DiseaseEffects.Infected.ToString());
                                baseValue -= 0.15f * stack;
                            }
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Obesity))
                            {
                                baseValue -= 0.15f;
                            }
                            else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.SevereObesity))
                            {
                                baseValue -= 0.3f;
                            }
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Rickets))
                            {
                                baseValue -= 0.15f;
                            }
                            else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.SevereRickets))
                            {
                                baseValue -= 0.3f;
                            }
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Hypolipidemia))
                            {
                                baseValue -= 0.5f;
                            }

                            break;
                        case StaminaController.StaminaValueModifier.LongerStaminaRechargeTime:
                            // Survival Effects
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.Disoriented))
                            {
                                baseValue += 0.25f;
                            }
                            else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.Suffocation))
                            {
                                baseValue += 0.5f;
                            }
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.FullStomach))
                            {
                                baseValue += 0.15f;
                            }
                            else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.StomachBursting))
                            {
                                baseValue += 0.3f;
                            }
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.FullGut))
                            {
                                baseValue += 0.15f;
                            }
                            else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.GutBurst))
                            {
                                baseValue += 0.3f;
                            }
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.FullBladder))
                            {
                                baseValue += 0.15f;
                            }
                            else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.BladderBurst))
                            {
                                baseValue += 0.3f;
                            }
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.Tired))
                            {
                                baseValue += 0.25f;
                            }
                            else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.ExtremelyTired))
                            {
                                baseValue += 0.5f;
                            }
                            // Disease Effects
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Queasy))
                            {
                                var stack = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatStack(playerId, StatsConstants.DiseaseEffects.Queasy.ToString());
                                baseValue += 0.25f * stack;
                            }
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Dysentery))
                            {
                                var stack = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatStack(playerId, StatsConstants.DiseaseEffects.Dysentery.ToString());
                                baseValue += 0.5f * stack;
                            }
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Hypolipidemia))
                            {
                                baseValue += 0.5f;
                            }
                            // Other Effects
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentOtherEffects, StatsConstants.OtherEffects.PoopOnClothes))
                            {
                                baseValue += 0.15f;
                            }
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentOtherEffects, StatsConstants.OtherEffects.PeeOnClothes))
                            {
                                baseValue += 0.075f;
                            }

                            break;
                        case StaminaController.StaminaValueModifier.StaminaRegeneration:
                            // Damage Effects
                            if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDamageEffects, StatsConstants.DamageEffects.Contusion))
                            {
                                baseValue -= 0.1f;
                            }
                            else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDamageEffects, StatsConstants.DamageEffects.Wounded))
                            {
                                baseValue -= 0.2f;
                            }
                            else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDamageEffects, StatsConstants.DamageEffects.DeepWounded))
                            {
                                baseValue -= 0.3f;
                            }
                            else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDamageEffects, StatsConstants.DamageEffects.BrokenBones))
                            {
                                baseValue -= 0.4f;
                            }

                            break;
                    }
                    break;
                case StatsConstants.ValidStats.BodyWater:
                    // Survival Effects
                    if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.Thirsty))
                    {
                        baseValue += 0.125f;
                    }
                    else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.Dehydrating))
                    {
                        baseValue += 0.25f;
                    }
                    // Temperature Effects
                    if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.Overheating))
                    {
                        baseValue += 0.125f;
                    }
                    else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.OnFire))
                    {
                        baseValue += 0.25f;
                    }
                    // Disease Effects
                    if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Queasy))
                    {
                        var stack = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatStack(playerId, StatsConstants.DiseaseEffects.Queasy.ToString());
                        baseValue += 0.075f * stack;
                    }
                    if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Dysentery))
                    {
                        var stack = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatStack(playerId, StatsConstants.DiseaseEffects.Dysentery.ToString());
                        baseValue += 0.075f * stack;
                    }
                    if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Dehydration))
                    {
                        baseValue += 0.15f;
                    }
                    else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.SevereDehydration))
                    {
                        baseValue += 0.3f;
                    }
                    break;
                case StatsConstants.ValidStats.BodyCalories:
                    // Survival Effects
                    if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.Hungry))
                    {
                        baseValue += 0.125f;
                    }
                    else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.Famished))
                    {
                        baseValue += 0.25f;
                    }
                    // Temperature Effects
                    if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.Cold))
                    {
                        baseValue += 0.125f;
                    }
                    else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.Frosty))
                    {
                        baseValue += 0.25f;
                    }
                    // Disease Effects
                    if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Queasy))
                    {
                        var stack = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatStack(playerId, StatsConstants.DiseaseEffects.Queasy.ToString());
                        baseValue += 0.075f * stack;
                    }
                    if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Dysentery))
                    {
                        var stack = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatStack(playerId, StatsConstants.DiseaseEffects.Dysentery.ToString());
                        baseValue += 0.075f * stack;
                    }
                    if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Starvation))
                    {
                        baseValue += 0.15f;
                    }
                    else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.SevereStarvation))
                    {
                        baseValue += 0.3f;
                    }
                    break;
                case StatsConstants.ValidStats.BodyProtein:
                case StatsConstants.ValidStats.BodyCarbohydrate:
                case StatsConstants.ValidStats.BodyLipids:
                case StatsConstants.ValidStats.BodyMinerals:
                case StatsConstants.ValidStats.BodyVitamins:
                    // Survival Effects
                    if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.Hungry))
                    {
                        baseValue += 0.125f;
                    }
                    else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.Famished))
                    {
                        baseValue += 0.25f;
                    }
                    if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.Thirsty))
                    {
                        baseValue += 0.125f;
                    }
                    else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentSurvivalEffects, StatsConstants.SurvivalEffects.Dehydrating))
                    {
                        baseValue += 0.25f;
                    }
                    // Temperature Effects
                    if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.Overheating))
                    {
                        baseValue += 0.125f;
                    }
                    else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.OnFire))
                    {
                        baseValue += 0.25f;
                    }
                    if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.Cold))
                    {
                        baseValue += 0.125f;
                    }
                    else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentTemperatureEffects, StatsConstants.TemperatureEffects.Frosty))
                    {
                        baseValue += 0.25f;
                    }
                    // Disease Effects
                    if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Queasy))
                    {
                        var stack = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatStack(playerId, StatsConstants.DiseaseEffects.Queasy.ToString());
                        baseValue += 0.075f * stack;
                    }
                    if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Dysentery))
                    {
                        var stack = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatStack(playerId, StatsConstants.DiseaseEffects.Dysentery.ToString());
                        baseValue += 0.075f * stack;
                    }
                    if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Starvation))
                    {
                        baseValue += 0.16f;
                    }
                    else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.SevereStarvation))
                    {
                        baseValue += 0.30f;
                    }
                    if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Dehydration))
                    {
                        baseValue += 0.15f;
                    }
                    else if (StatsConstants.IsFlagSet(statsEasyAcess[playerId].CurrentDiseaseEffects, StatsConstants.DiseaseEffects.SevereDehydration))
                    {
                        baseValue += 0.30f;
                    }
                    break;
            }
            return Math.Max(baseValue, 0);
        }

        private static void DoConsumeCicle(long playerId, float staminaSpended)
        {
            var _caloriesToConsume = PlayerBodyConstants.CaloriesConsumption.X;
            waterToConsume[playerId] = PlayerBodyConstants.WaterConsumption.X;
            var _proteinToConsume = PlayerBodyConstants.ProteinConsumption.X;
            var _carbohydrateToConsume = PlayerBodyConstants.CarbohydrateConsumption.X;
            var _lipidsToConsume = PlayerBodyConstants.LipidConsumption.X;
            var _mineralsToConsume = PlayerBodyConstants.MineralsConsumption.X;
            var _vitaminsToConsume = PlayerBodyConstants.VitaminsConsumption.X;
            if (staminaSpended > 0)
            {
                staminaSpended *= ExtendedSurvivalSettings.Instance.MetabolismSettings.StaminaSpendedMultiplier;
                _caloriesToConsume += PlayerBodyConstants.CaloriesConsumption.Y * staminaSpended;
                waterToConsume[playerId] += PlayerBodyConstants.WaterConsumption.Y * staminaSpended;
                _proteinToConsume += PlayerBodyConstants.ProteinConsumption.Y * staminaSpended;
                _carbohydrateToConsume += PlayerBodyConstants.CarbohydrateConsumption.Y * staminaSpended;
                _lipidsToConsume += PlayerBodyConstants.LipidConsumption.Y * staminaSpended;
                _mineralsToConsume += PlayerBodyConstants.MineralsConsumption.Y * staminaSpended;
                _vitaminsToConsume += PlayerBodyConstants.VitaminsConsumption.Y * staminaSpended;
            }
            _caloriesToConsume *= NegativeStatsMultiplier(playerId, StatsConstants.ValidStats.BodyCalories);
            waterToConsume[playerId] *= NegativeStatsMultiplier(playerId, StatsConstants.ValidStats.BodyWater);
            _proteinToConsume *= NegativeStatsMultiplier(playerId, StatsConstants.ValidStats.BodyProtein);
            _carbohydrateToConsume *= NegativeStatsMultiplier(playerId, StatsConstants.ValidStats.BodyCarbohydrate);
            _lipidsToConsume *= NegativeStatsMultiplier(playerId, StatsConstants.ValidStats.BodyLipids);
            _mineralsToConsume *= NegativeStatsMultiplier(playerId, StatsConstants.ValidStats.BodyMinerals);
            _vitaminsToConsume *= NegativeStatsMultiplier(playerId, StatsConstants.ValidStats.BodyVitamins);
            var mSpeed = ExtendedSurvivalSettings.Instance.MetabolismSpeedMultiplier;
            statsEasyAcess[playerId].BodyCalories.Value -= _caloriesToConsume * ExtendedSurvivalSettings.Instance.MetabolismSettings.CaloriesConsumeMultiplier / mSpeed;
            statsEasyAcess[playerId].BodyWater.Value -= waterToConsume[playerId] * ExtendedSurvivalSettings.Instance.MetabolismSettings.WaterConsumeMultiplier / mSpeed;
            statsEasyAcess[playerId].BodyProtein.Value -= _proteinToConsume * ExtendedSurvivalSettings.Instance.MetabolismSettings.ProteinConsumeMultiplier / mSpeed;
            statsEasyAcess[playerId].BodyCarbohydrate.Value -= _carbohydrateToConsume * ExtendedSurvivalSettings.Instance.MetabolismSettings.CarbohydrateConsumeMultiplier / mSpeed;
            statsEasyAcess[playerId].BodyLipids.Value -= _lipidsToConsume * ExtendedSurvivalSettings.Instance.MetabolismSettings.LipidsConsumeMultiplier / mSpeed;
            statsEasyAcess[playerId].BodyMinerals.Value -= _mineralsToConsume * ExtendedSurvivalSettings.Instance.MetabolismSettings.MineralsConsumeMultiplier / mSpeed;
            statsEasyAcess[playerId].BodyVitamins.Value -= _vitaminsToConsume * ExtendedSurvivalSettings.Instance.MetabolismSettings.VitaminsConsumeMultiplier / mSpeed;
        }

        private static float GetTargetStomachSize(long playerId, float baseValue, ref float baseMinToReturn, float maxValue = 1f)
        {
            var stack = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatStack(playerId, StatsConstants.SurvivalEffects.EmptyStomach.ToString());
            if (stack > 0)
            {
                var increase = (maxValue - baseValue) / StatsConstants.GetSurvivalEffectMaxStacks(StatsConstants.SurvivalEffects.EmptyStomach);
                var increaseMinToReturn = baseMinToReturn / StatsConstants.GetSurvivalEffectMaxStacks(StatsConstants.SurvivalEffects.EmptyStomach);
                baseMinToReturn -= increaseMinToReturn * stack;
                return baseValue + (increase * stack);
            }
            return baseValue;
        }

        private static float GetCurrentHungerAmmount(long playerId, float CaloriesAmmount, float CurrentStomachVolume)
        {
            var cal = Math.Max(Math.Min(CaloriesAmmount, PlayerBodyConstants.CAL_LIMIT_MAX), PlayerBodyConstants.CAL_LIMIT_MIN);
            var target = PlayerBodyConstants.BodyCalorieStats.FirstOrDefault(x => cal >= x.From && cal < x.To);
            var minToReturn = target.MinToReturn;
            var targetStomachSize = GetTargetStomachSize(playerId, target.TargetStomachSize, ref minToReturn);
            if (CurrentStomachVolume >= targetStomachSize)
                return 1.0f;
            var finalValue = CurrentStomachVolume / targetStomachSize;
            return minToReturn > 0 ? Math.Max(finalValue, minToReturn) : finalValue;
        }

        private static float GetCurrentThirstAmmount(long playerId, float WaterAmmount, float CurrentStomachLiquid)
        {
            var water = Math.Max(Math.Min(WaterAmmount, PlayerBodyConstants.WATER_RESERVE_DEAD), PlayerBodyConstants.WATER_RESERVE_FULL);
            var target = PlayerBodyConstants.BodyWaterStats.FirstOrDefault(x => water >= x.From && water < x.To);
            var minToReturn = target.MinToReturn;
            var targetStomachSize = GetTargetStomachSize(playerId, target.TargetStomachSize, ref minToReturn, 0.75f);
            if (CurrentStomachLiquid >= targetStomachSize)
                return 1.0f;
            var finalValue = CurrentStomachLiquid / targetStomachSize;
            return minToReturn > 0 ? Math.Max(finalValue, minToReturn) : finalValue;
        }

        private static float GetCurrentBodyEnergy(float CaloriesAmmount)
        {
            if (CaloriesAmmount < 0)
                return 0;
            if (CaloriesAmmount >= PlayerBodyConstants.CaloriesReserveSize.Y)
                return 1;
            return CaloriesAmmount / PlayerBodyConstants.CaloriesReserveSize.Y;
        }

        private static void DoStomachCicle(long playerId)
        {
            var solid = AdvancedStatsAndEffectsAPI.GetRemainOverTimeConsumable(playerId, StatsConstants.VirtualStats.Solid.ToString());
            var liquid = AdvancedStatsAndEffectsAPI.GetRemainOverTimeConsumable(playerId, StatsConstants.VirtualStats.Liquid.ToString());
            statsEasyAcess[playerId].Stomach.Value = solid + liquid;
            statsEasyAcess[playerId].Hunger.Value = GetCurrentHungerAmmount(playerId, statsEasyAcess[playerId].BodyCalories.Value, statsEasyAcess[playerId].Stomach.Value) * statsEasyAcess[playerId].Hunger.MaxValue;
            statsEasyAcess[playerId].Thirst.Value = GetCurrentThirstAmmount(playerId, statsEasyAcess[playerId].BodyWater.Value, liquid) * statsEasyAcess[playerId].Thirst.MaxValue;
            statsEasyAcess[playerId].BodyEnergy.Value = GetCurrentBodyEnergy(statsEasyAcess[playerId].BodyCalories.Value) * statsEasyAcess[playerId].BodyEnergy.MaxValue;
        }

        private static void DoBladderCicle(long playerId)
        {
            statsEasyAcess[playerId].Bladder.Value += PlayerBodyConstants.WaterToBladder / ExtendedSurvivalSettings.Instance.MetabolismSpeedMultiplier;
        }

        private static void DoCheckBodyState(long playerId)
        {
            if (statsEasyAcess[playerId].Bladder.Value >= statsEasyAcess[playerId].Bladder.MaxValue)
            {
                DoTakeAPiss(playerId);
            }
            if (statsEasyAcess[playerId].Intestine.Value >= statsEasyAcess[playerId].Intestine.MaxValue)
            {
                DoShitYourself(playerId);
            }
            if (statsEasyAcess[playerId].Stomach.Value >= statsEasyAcess[playerId].Stomach.MaxValue)
            {
                DoVomit(playerId);
            }
        }

        private static float DoCheckBodyWeight(long playerId, float lastCaloriesChange)
        {
            float bodyChance = 0;
            if (statsEasyAcess[playerId].BodyCalories.Value < PlayerBodyConstants.CaloriesReserveSize.X &&
                lastCaloriesChange < 0) /* Esta com baixa energia e não consumiu calorias */
            {
                bodyChance -= PlayerBodyConstants.WeightChange.X;
            }
            else if (statsEasyAcess[playerId].BodyCalories.Value > PlayerBodyConstants.CaloriesReserveSize.Y &&
                lastCaloriesChange > 0) /* Esta com alta energia e não esta gastando ela */
            {
                bodyChance += PlayerBodyConstants.WeightChange.Y;
            }
            statsEasyAcess[playerId].BodyWeight.Value += bodyChance;
            return bodyChance;
        }

        public static void ProcessHealth(long playerId, MyCharacterStatComponent statComponent)
        {
            RefreshPlayerStatComponent(playerId, statComponent);
            
            var maxDamage = (StatsConstants.DamageEffects)StatsConstants.GetMaxSetFlagValue(statsEasyAcess[playerId].CurrentDamageEffects);
            var finalRegen = StatsConstants.BASE_HEALTH_REGEN_FACTOR;
            var maxRegen = 1f;
            var maxValue = statComponent.Health.MaxValue;
            if (maxDamage != StatsConstants.DamageEffects.None)
            {
                finalRegen *= NegativeStatsMultiplier(playerId, HealthController.HealthValueModifier.RegenerationFactor);
                maxRegen = NegativeStatsMultiplier(playerId, HealthController.HealthValueModifier.MaximumRegenerationHealth);
                maxValue *= NegativeStatsMultiplier(playerId, HealthController.HealthValueModifier.MaxHealth);
            }
            var currentStatusValue = statComponent.Health.Value / statComponent.Health.MaxValue;
            if (currentStatusValue < maxRegen)
            {
                statComponent.Health.Increase(finalRegen, null);
            }
            if (statComponent.Health.Value > maxValue)
            {
                statComponent.Health.Value = maxValue;
            }
        }

        private const float MAX_HEALTH_REGEN_AT_SURVIVAL_KIT = 0.5f;
        public static void PlayerHealthRecharging(long playerId, MyCharacterStatComponent statComponent)
        {
            var maxLife = MAX_HEALTH_REGEN_AT_SURVIVAL_KIT * statComponent.Health.MaxValue;
            var lastHealthChanged  = AdvancedStatsAndEffectsAPI.GetLastHealthChange(playerId);
            if (lastHealthChanged.X > maxLife)
            {
                if (lastHealthChanged.Y > maxLife)
                    statComponent.Health.Value = lastHealthChanged.Y;
                else
                    statComponent.Health.Value = maxLife;
            }
        }

        public static void DoReciveDamage(IMyCharacter character, ref MyDamageInformation damage)
        {
            var playerId = character.GetPlayerId();
            var armorInfo = PlayerArmorController.GetEquipedArmor(playerId, useCache: true);
            if (armorInfo != null && armorInfo.HasArmor)
            {
                var damageType = ArmorSystemConstants.GetDamageType(damage.Type);
                if (armorInfo.Shield.HasShield && ExtendedSurvivalCoreAPI.Registered)
                {
                    var stats = GetStatsEasyAcess(playerId);
                    if (stats != null && stats.EnergyShield.Value > 0)
                    {
                        var currentShield = stats.EnergyShield.Value * armorInfo.Shield.MaxShield;
                        var baseDamage = damage.Amount;
                        if (currentShield > damage.Amount)
                        {
                            currentShield -= damage.Amount;
                            damage.Amount = 0;
                        }
                        else
                        {
                            damage.Amount -= currentShield;
                            baseDamage = currentShield;
                            currentShield = 0;
                        }
                        stats.EnergyShield.Value = currentShield / armorInfo.Shield.MaxShield;
                        var shieldInfo = GetPlayerShieldInfo(playerId);
                        shieldInfo.LastHit = ExtendedSurvivalCoreAPI.GetGameTime();
                        if (armorInfo.Shield.HasSpike)
                        {
                            var spikeDamage = baseDamage * armorInfo.Shield.SpikeTurn;
                            if (spikeDamage > 0)
                            {
                                IMyCharacter attackerCharacter = null;
                                if (damageType == ArmorSystemConstants.DamageType.Creature)
                                {
                                    var attacker = MyAPIGateway.Entities.GetEntityById(damage.AttackerId);
                                    if (attacker != null)
                                    {
                                        attackerCharacter = attacker as IMyCharacter;
                                    }
                                }
                                else if (damageType == ArmorSystemConstants.DamageType.Tool)
                                {
                                    var attackerTool = MyAPIGateway.Entities.GetEntityById(damage.AttackerId);
                                    if (attackerTool != null)
                                    {
                                        var handTool = attackerTool as Sandbox.ModAPI.Weapons.IMyEngineerToolBase;
                                        if (handTool != null)
                                        {
                                            var attacker = MyAPIGateway.Entities.GetEntityById(handTool.OwnerId);
                                            if (attacker != null)
                                            {
                                                attackerCharacter = attacker as IMyCharacter;
                                            }
                                        }
                                        else
                                        {
                                            var handDrill = attackerTool as Sandbox.ModAPI.Weapons.IMyHandDrill;
                                            if (handDrill != null)
                                            {
                                                var attacker = MyAPIGateway.Entities.GetEntityById((handDrill as IMyGunBaseUser).OwnerId);
                                                if (attacker != null)
                                                {
                                                    attackerCharacter = attacker as IMyCharacter;
                                                }
                                            }
                                        }
                                    }
                                }
                                if (attackerCharacter != null)
                                {
                                    attackerCharacter.DoDamage(spikeDamage, MyDamageType.Radioactivity, true, attackerId: character.EntityId);
                                }
                            }
                        }
                    }
                }
                if (damage.Amount > 0)
                {
                    if (damageType != ArmorSystemConstants.DamageType.None)
                    {
                        if (armorInfo.ArmorDefinition.Resistences.ContainsKey(damageType))
                        {
                            var amountToChange = damage.Amount * armorInfo.ArmorDefinition.Resistences[damageType];
                            damage.Amount -= amountToChange;
                        }
                    }
                }
            }
        }

    }

}
