using Sandbox.Game.Components;
using Sandbox.Game.Entities;
using System;
using System.Collections.Concurrent;
using System.Linq;
using VRage.Utils;

namespace ExtendedSurvival.Stats
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
        public MyEntityStat FoodEffects { get { return FixedStats[StatsConstants.FixedStats.StatsGroup06]; } }

        public MyEntityStat FoodDetector { get { return Stats[StatsConstants.ValidStats.FoodDetector]; } }
        public MyEntityStat MedicalDetector { get { return Stats[StatsConstants.ValidStats.MedicalDetector]; } }

        public MyEntityStat Hunger { get { return Stats[StatsConstants.ValidStats.Hunger]; } }
        public MyEntityStat Thirst { get { return Stats[StatsConstants.ValidStats.Thirst]; } }
        public MyEntityStat Stamina { get { return Stats[StatsConstants.ValidStats.Stamina]; } }
        public MyEntityStat StaminaAmount { get { return Stats[StatsConstants.ValidStats.StaminaAmount]; } }
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

        public FoodEffectConstants.FoodEffects CurrentFoodEffects
        {
            get
            {
                return OtherEffects != null ? (FoodEffectConstants.FoodEffects)((int)FoodEffects.Value) : FoodEffectConstants.FoodEffects.None;
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

}
