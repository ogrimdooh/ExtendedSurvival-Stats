using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using VRage.Utils;
using VRageMath;
using static ExtendedSurvival.Stats.StatsConstants;

namespace ExtendedSurvival.Stats
{

    public static class FoodEffectConstants
    {

        [Flags]
        public enum FoodEffects
        {

            None = 0,
            FreshFruit = 1 << 1

        }

        public static Dictionary<FoodEffects, FixedStatDataInfo> FOOD_EFFECTS = new Dictionary<FoodEffects, FixedStatDataInfo>()
        {
            {
                FoodEffects.FreshFruit,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffects.FreshFruit),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 10 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            }
        };

        public static string GetFoodEffectsDescription(FoodEffects effect)
        {
            switch (effect)
            {
                case FoodEffects.FreshFruit:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTS_FRESHFRUIT_NAME);
            }
            return "";
        }

        public static int GetFoodEffectsFeelingLevel(FoodEffects effect)
        {
            switch (effect)
            {
                case FoodEffects.FreshFruit:
                    return 0;
            }
            return 0;
        }

        public static int GetFoodEffectsTrackLevel(FoodEffects effect)
        {
            switch (effect)
            {
                case FoodEffects.FreshFruit:
                    return 0;
            }
            return 0;
        }

    }

    public static class StatsConstants
    {

        public class FixedStatDataInfo
        {

            public string Name { get; set; }
            public bool CanStack { get; set; }
            public byte MaxStacks { get; set; }
            public bool CanSelfRemove { get; set; }
            public int TimeToSelfRemove { get; set; }
            public bool CompleteRemove { get; set; }
            public byte StacksWhenRemove { get; set; }
            public bool IsInverseTime { get; set; }
            public int MaxInverseTime { get; set; }
            public bool SelfRemoveWhenMaxInverse { get; set; }
            public bool IsPositive { get; set; }

        }

        static StatsConstants()
        {
            HelpController.AddLoadAction(BuildHelpTopics);
        }

        public const float CHANCE_TO_VOMIT = 0.1f;
        public const float CHANCE_TO_POOP = 0.05f;

        public const int POISON_DAMAGE = 4;
        public const int TEMPERATURE_DAMAGE = 2;

        public static readonly Vector3 BODY_MUSCLE_MOVE_GAIN = new Vector3(0.01f, 0.03f, 0.26f);
        public const float BODY_MUSCLE_NOMOVE_DRAIN = 0.005f;
        public const float BODY_MUSCLE_PROTEIN_DRAIN = 0.01f;

        public static readonly Vector3 BODY_FAT_MOVE_DRAIN = new Vector3(0.02f, 0.06f, 0.52f);
        public static readonly Vector2 BODY_FAT_NOMOVE_LC_GAIN = new Vector2(0.03f, 0.015f);
        public static readonly Vector2 BODY_FAT_LC_DRAIN = new Vector2(0.0025f, 0.005f);

        public const float BODY_PERFORMANCE_V_GAIN = 0.02f;
        public const float BODY_PERFORMANCE_M_GAIN = 0.01f;
        public const float BODY_PERFORMANCE_CYCLE_DRAIN = 0.0025f;
        public const float BODY_PERFORMANCE_CYCLE_DRAIN_INC = 0.0025f;
        public const float BODY_PERFORMANCE_CYCLE_MAXDRAIN = 0.1f;
        public const float BODY_PERFORMANCE_V_DRAIN = 0.01f;
        public const float BODY_PERFORMANCE_M_DRAIN = 0.02f;

        public const float MIN_CHAR_SPEED = 1.0f;
        public const float MAX_CHAR_SPEED = 15.0f;

        public const float BASE_HEALTH_REGEN_FACTOR = 0.2f;
        public const float MAX_HEALTH_REGEN_AT_SURVIVAL_KIT = 0.2f;

        public const float BASE_FATIGUE_INCREASE_FACTOR = 1.0f;
        public const float BASE_FATIGUE_INCREASE_MULTIPLIER = 2.5f;
        public const float BASE_FATIGUE_DECREASE_FACTOR = 5.0f;
        public const float BASE_FATIGUE_DECREASE_MULTIPLIER = 10.0f;

        public const float BASE_STAMINA_DAMAGE_FACTOR = 2.5f;
        public const float BASE_STAMINA_DECREASE_FACTOR = 2.5f;
        public const float BASE_TOOL_STAMINA_DECREASE_FACTOR = 1.25f;
        public const float BASE_STAMINA_INCREASE_FACTOR = 5.0f;
        public const float BASE_RUNING_MULTIPLIER = 1.5f;
        public const float BASE_TREADMILL_MULTIPLIER = 0.5f;
        public const float BASE_TOTAL_STAMINA_REMOVE_PER_STACK = 0.1f; /* DISEASE AND OUT O2 */
        public const float MAX_STAMINA_REMOVE_WHEN_STACK = 0.85f;

        public const float MIN_STAMINA_TO_USE = 5;
        public const float JUMP_COST_MULTIPLIER = 2.75f;

        public const float BASE_WATER_METABOLISM = 0.24f;
        public const float BASE_FOOD_METABOLISM = 0.20f;

        public const float BASE_USE_WATER_FACTOR = 0.12f;
        public static readonly Vector2 BASE_USE_WATER_MOVE_MULTIPLIER = new Vector2(1.25f, 1.5f);
        public static readonly Vector4 BASE_USE_WATER_TEMPERATURE_MULTIPLIER = new Vector4(1.0f, 1.0f, 1.25f, 1.5f);
        public static readonly Vector2 BASE_USE_WATER_THIRST_MULTIPLIER = new Vector2(1.25f, 1.5f);

        public const float BASE_USE_ENERGY_FACTOR = 0.10f;
        public static readonly Vector2 BASE_USE_ENERGY_MOVE_MULTIPLIER = new Vector2(1.25f, 1.5f);
        public static readonly Vector4 BASE_USE_ENERGY_TEMPERATURE_MULTIPLIER = new Vector4(1.5f, 1.25f, 1.0f, 1.0f);
        public static readonly Vector2 BASE_USE_ENERGY_HUNGER_MULTIPLIER = new Vector2(1.25f, 1.5f);

        public static readonly Dictionary<DamageEffects, float> TIME_MULTIPLIER_FACTOR = new Dictionary<DamageEffects, float>()
        {
            { DamageEffects.Wounded, 1f },
            { DamageEffects.DeepWounded, 1.25f },
            { DamageEffects.BrokenBones, 1.50f }
        };

        public static readonly Dictionary<DamageEffects, float> DAMAGE_HEALTH_START_VALUE = new Dictionary<DamageEffects, float>()
        {
            { DamageEffects.Contusion, 0.75f },
            { DamageEffects.Wounded, 0.55f },
            { DamageEffects.DeepWounded, 0.35f },
            { DamageEffects.BrokenBones, 0.15f }
        };

        public static readonly Dictionary<DamageEffects, KeyValuePair<DamageEffects, DamageEffects[]>> ON_DEATH_APPLY_DAMAGE = new Dictionary<DamageEffects, KeyValuePair<DamageEffects, DamageEffects[]>>()
        {
            { DamageEffects.None, new KeyValuePair<DamageEffects, DamageEffects[]>(DamageEffects.Wounded, new DamageEffects[] { }) },
            { DamageEffects.Contusion, new KeyValuePair<DamageEffects, DamageEffects[]>(DamageEffects.Wounded, new DamageEffects[] { DamageEffects.Contusion }) },
            { DamageEffects.Wounded, new KeyValuePair<DamageEffects, DamageEffects[]>(DamageEffects.DeepWounded, new DamageEffects[] { DamageEffects.Contusion, DamageEffects.Wounded }) },
            { DamageEffects.DeepWounded, new KeyValuePair<DamageEffects, DamageEffects[]>(DamageEffects.BrokenBones, new DamageEffects[] { DamageEffects.Contusion, DamageEffects.Wounded, DamageEffects.DeepWounded }) },
            { DamageEffects.BrokenBones, new KeyValuePair<DamageEffects, DamageEffects[]>(DamageEffects.BrokenBones, new DamageEffects[] { DamageEffects.Contusion, DamageEffects.Wounded, DamageEffects.DeepWounded, DamageEffects.BrokenBones }) }
        };

        public static readonly Dictionary<DamageEffects, DamageEffects> ON_SELFREMOVE_APPLY_DAMAGE = new Dictionary<DamageEffects, DamageEffects>()
        {
            { DamageEffects.BrokenBones, DamageEffects.DeepWounded },
            { DamageEffects.DeepWounded, DamageEffects.Wounded },
            { DamageEffects.Wounded, DamageEffects.Contusion }
        };

        public const float BASE_WET_FACTOR_RAIN = 0.15f;
        public const float BASE_WET_FACTOR_THUNDER = 0.3f;
        public const float BASE_WET_FACTOR_UNDERWATER = 5.0f;

        public static readonly Vector2 RAIN_WET_FACTOR = new Vector2(1.25f, 1.5f);
        public static readonly Vector2 THUNDER_WET_FACTOR = new Vector2(1.25f, 1.5f);

        public const float BASE_REMOVE_WET_FACTOR_IN_VOID = 1.5f;
        public const float BASE_REMOVE_WET_FACTOR_IN_SHIP = 1.25f;
        public const float BASE_REMOVE_WET_FACTOR_IN_ATM = 1f;
        public const float BASE_REMOVE_WET_FACTOR = 1.5f;
        public const float BASE_REMOVE_WET_FACTOR_NOO2_BONUS = 1.5f;
        public const float MIN_TO_GET_EFFECT_WET = 25f;

        public const float TEMPERATURE_CHANGE_MULTIPLIER = 2.5f;
        public const float HYPOTHERMIA_CHANGE_MULTIPLIER = 0.2f;
        public const float HYPERTHERMIA_CHANGE_MULTIPLIER = 0.2f;

        public const float MIN_TO_GET_EFFECT_OVERHITING = 100000f;
        public const float MIN_TO_GET_EFFECT_ONFIRE = 300000f;
        public const float MIN_TO_GET_EFFECT_COLD = -100000f;
        public const float MIN_TO_GET_EFFECT_FROSTY = -300000f;

        public const float CHANCE_TO_GET_PNEUMONIA = 1.5f; /* 1.5% */
        public const float PNEUMONIA_CHANCE_INCRISE = 0.5f; /* 0.5% */
        /* WITH ALL ODDS CAN GET 2.5% */

        public enum CreatureValidStats
        {

            Torpor

        }

        public enum VirtualStats
        {

            Solid,
            Liquid

        }

        public enum FixedStats
        {

            StatsGroup01, /* Survival Effects */
            StatsGroup02, /* Damage Effects */
            StatsGroup03, /* Temperature Effects */
            StatsGroup04, /* Disease Effects */
            StatsGroup05, /* Other Effects */
            StatsGroup06, /* Food Effects */
            StatsGroup07,
            StatsGroup08,
            StatsGroup09,
            StatsGroup10

        }

        public enum ValidStats
        {

            Hunger,
            Thirst,
            Stamina,
            Fatigue,
            WoundedTime,
            BodyEnergy,
            BodyWater,
            BodyPerformance,
            BodyImmune,
            Stomach,
            Intestine,
            Bladder,
            BodyWeight,
            BodyMuscles,
            BodyFat,
            BodyMusclesWeight,
            BodyFatWeight,
            FoodDetector,
            MedicalDetector,
            BodyCalories,
            BodyProtein,
            BodyCarbohydrate,
            BodyLipids,
            BodyMinerals,
            BodyVitamins,
            IntoxicationTime,
            RadiationTime,
            HotThermalFluid,
            ColdThermalFluid,
            EnergyShield,
            StaminaAmount

        }

        [Flags]
        public enum SurvivalEffects
        {

            None = 0,
            /* Hunger Effects */
            Hungry = 1 << 1, /* Have less than 10% Hunger */
            Famished = 1 << 2, /* Have 5% Hunger */
            /* Thirst Effects */
            Thirsty = 1 << 3, /* Have less than 10% Thirst */
            Dehydrating = 1 << 4, /* Have 5% Thirst */
            /* Oxygen Effects */
            Disoriented = 1 << 5, /* Have less than 10% Oxygen */
            Suffocation = 1 << 6, /* Have 5% Oxygen */
            FullStomach = 1 << 7,
            StomachBursting = 1 << 8,
            FullGut = 1 << 9,
            GutBurst = 1 << 10,
            FullBladder = 1 << 11,
            BladderBurst = 1 << 12,
            Tired = 1 << 13,
            ExtremelyTired = 1 << 14,
            StomachGrowling = 1 << 15,
            EmptyStomach = 1 << 16

        }

        [Flags]
        public enum DamageEffects
        {

            None = 0,
            Contusion = 1 << 1, /* Take damage more than 10% Max Life */
            Wounded = 1 << 2, /* Take damage more than 20% Max Life */
            DeepWounded = 1 << 3, /* Take damage more than 40% Max Life, replace Wounded */
            BrokenBones = 1 << 4 /* Take damage more than 60% Max Life, replace Contusion */

        }

        [Flags]
        public enum TemperatureEffects
        {

            None = 0,
            Overheating = 1 << 1, 
            OnFire = 1 << 2, 
            Cold = 1 << 3, 
            Frosty = 1 << 4, 
            Wet = 1 << 5,
            ExposedToCold = 1 << 6,
            ExposedToFreeze = 1 << 7,
            ExposedToHot = 1 << 8,
            ExposedToBoiling = 1 << 9,
            RecoveringFromExposure = 1 << 10,
            LesserResistenceToCold = 1 << 11,
            ResistenceToCold = 1 << 12,
            GreaterResistenceToCold = 1 << 13,
            LesserResistenceToHot = 1 << 14,
            ResistenceToHot = 1 << 15,
            GreaterResistenceToHot = 1 << 16

        }

        public static readonly TemperatureEffects[] COLD_RESISTENCES = new TemperatureEffects[]
        {
            TemperatureEffects.LesserResistenceToCold,
            TemperatureEffects.ResistenceToCold,
            TemperatureEffects.GreaterResistenceToCold
        };

        public static readonly TemperatureEffects[] HOT_RESISTENCES = new TemperatureEffects[]
        {
            TemperatureEffects.LesserResistenceToHot,
            TemperatureEffects.ResistenceToHot,
            TemperatureEffects.GreaterResistenceToHot
        };

        public static Dictionary<TemperatureEffects, FixedStatDataInfo> TEMPERATURE_EFFECTS = new Dictionary<TemperatureEffects, FixedStatDataInfo>()
        {
            {
                TemperatureEffects.Overheating,
                new FixedStatDataInfo()
                {
                    Name = GetTemperatureEffectDescription(TemperatureEffects.Overheating),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 5 * 60 * 1000,
                    CompleteRemove = true                    
                }
            },
            {
                TemperatureEffects.OnFire,
                new FixedStatDataInfo()
                {
                    Name = GetTemperatureEffectDescription(TemperatureEffects.OnFire),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 10 * 60 * 1000,
                    CompleteRemove = true
                }
            },
            {
                TemperatureEffects.Cold,
                new FixedStatDataInfo()
                {
                    Name = GetTemperatureEffectDescription(TemperatureEffects.Cold),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 5 * 60 * 1000,
                    CompleteRemove = true
                }
            },
            {
                TemperatureEffects.Frosty,
                new FixedStatDataInfo()
                {
                    Name = GetTemperatureEffectDescription(TemperatureEffects.Frosty),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 10 * 60 * 1000,
                    CompleteRemove = true
                }
            },
            {
                TemperatureEffects.Wet,
                new FixedStatDataInfo()
                {
                    Name = GetTemperatureEffectDescription(TemperatureEffects.Wet),
                    CanSelfRemove = true,
                    TimeToSelfRemove = (int)(2.5f * 60 * 1000),
                    CompleteRemove = true
                }
            },
            {
                TemperatureEffects.ExposedToCold,
                new FixedStatDataInfo()
                {
                    Name = GetTemperatureEffectDescription(TemperatureEffects.ExposedToCold),
                    IsInverseTime = true,
                    MaxInverseTime = 5 * 60 * 1000
                }
            },
            {
                TemperatureEffects.ExposedToFreeze,
                new FixedStatDataInfo()
                {
                    Name = GetTemperatureEffectDescription(TemperatureEffects.ExposedToCold),
                    IsInverseTime = true,
                    MaxInverseTime = 5 * 60 * 1000
                }
            },
            {
                TemperatureEffects.ExposedToHot,
                new FixedStatDataInfo()
                {
                    Name = GetTemperatureEffectDescription(TemperatureEffects.ExposedToCold),
                    IsInverseTime = true,
                    MaxInverseTime = 5 * 60 * 1000
                }
            },
            {
                TemperatureEffects.ExposedToBoiling,
                new FixedStatDataInfo()
                {
                    Name = GetTemperatureEffectDescription(TemperatureEffects.ExposedToCold),
                    IsInverseTime = true,
                    MaxInverseTime = 5 * 60 * 1000
                }
            },
            {
                TemperatureEffects.RecoveringFromExposure,
                new FixedStatDataInfo()
                {
                    Name = GetTemperatureEffectDescription(TemperatureEffects.RecoveringFromExposure),
                    CanSelfRemove = true,
                    TimeToSelfRemove = (int)(2.5f * 60 * 1000),
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                TemperatureEffects.LesserResistenceToCold,
                new FixedStatDataInfo()
                {
                    Name = GetTemperatureEffectDescription(TemperatureEffects.LesserResistenceToCold),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 5 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                TemperatureEffects.ResistenceToCold,
                new FixedStatDataInfo()
                {
                    Name = GetTemperatureEffectDescription(TemperatureEffects.ResistenceToCold),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 10 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                TemperatureEffects.GreaterResistenceToCold,
                new FixedStatDataInfo()
                {
                    Name = GetTemperatureEffectDescription(TemperatureEffects.GreaterResistenceToCold),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 15 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                TemperatureEffects.LesserResistenceToHot,
                new FixedStatDataInfo()
                {
                    Name = GetTemperatureEffectDescription(TemperatureEffects.LesserResistenceToHot),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 5 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                TemperatureEffects.ResistenceToHot,
                new FixedStatDataInfo()
                {
                    Name = GetTemperatureEffectDescription(TemperatureEffects.ResistenceToHot),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 10 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                TemperatureEffects.GreaterResistenceToHot,
                new FixedStatDataInfo()
                {
                    Name = GetTemperatureEffectDescription(TemperatureEffects.GreaterResistenceToHot),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 15 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            }
        };

        [Flags]
        public enum DiseaseEffects
        {

            None = 0,
            Pneumonia = 1 << 1, /* After getting cold or frosty can get Pneumonia by chance, wet incrise that chance */
            Dysentery = 1 << 2, /* Recived by eating raw meat food, with raw vegetables or fruits has a little chance */
            Poison = 1 << 3, /* Recived by food or poison damage */
            Infected = 1 << 4, /* Dont remove Wounded, DeepWounded or BrokenBones in 10 minutes */
            Hypothermia = 1 << 5, /* Get max temperature negative timer */
            Hyperthermia = 1 << 6, /* Get max temperature positive timer */
            Starvation = 1 << 7,
            SevereStarvation = 1 << 8,
            Dehydration = 1 << 9,
            SevereDehydration = 1 << 10,
            Obesity = 1 << 11,
            SevereObesity = 1 << 12,
            Rickets = 1 << 13,
            SevereRickets = 1 << 14,
            Hypolipidemia = 1 << 15,
            Queasy = 1 << 16,
            Flu = 1 << 17
            
        }

        [Flags]
        public enum OtherEffects
        {

            None = 0,
            PoopOnClothes = 1 << 1,
            PeeOnClothes = 1 << 2

        }

        public static int GetDiseaseEffectFeelingLevel(DiseaseEffects effect)
        {
            switch (effect)
            {
                case DiseaseEffects.Dysentery:
                case DiseaseEffects.Poison:
                case DiseaseEffects.Queasy:
                case DiseaseEffects.Flu:
                    return 1;
                case DiseaseEffects.Hypothermia:
                case DiseaseEffects.Hyperthermia:
                case DiseaseEffects.Infected:
                case DiseaseEffects.Pneumonia:
                case DiseaseEffects.Starvation:
                case DiseaseEffects.Dehydration:
                case DiseaseEffects.Obesity:
                case DiseaseEffects.Rickets:
                case DiseaseEffects.Hypolipidemia:
                    return 2;
                case DiseaseEffects.SevereDehydration:
                case DiseaseEffects.SevereStarvation:
                case DiseaseEffects.SevereObesity:
                case DiseaseEffects.SevereRickets:
                    return 3;
            }
            return 0;
        }

        public static int GetDiseaseEffectTrackLevel(DiseaseEffects effect)
        {
            switch (effect)
            {
                case DiseaseEffects.Dysentery:
                case DiseaseEffects.Poison:
                case DiseaseEffects.Queasy:
                case DiseaseEffects.Flu:
                case DiseaseEffects.Pneumonia:
                case DiseaseEffects.Infected:
                case DiseaseEffects.Hypothermia:
                case DiseaseEffects.Hyperthermia:
                case DiseaseEffects.Starvation:
                case DiseaseEffects.SevereStarvation:
                case DiseaseEffects.Dehydration:
                case DiseaseEffects.SevereDehydration:
                case DiseaseEffects.Obesity:
                case DiseaseEffects.SevereObesity:
                case DiseaseEffects.Rickets:
                case DiseaseEffects.SevereRickets:
                case DiseaseEffects.Hypolipidemia:
                    return 0;
            }
            return 0;
        }

        public static string GetFixedStatsDescription(FixedStats stat)
        {
            switch (stat)
            {
                case FixedStats.StatsGroup01:
                    return LanguageProvider.GetEntry(LanguageEntries.SURVIVALEFFECTS_NAME);
                case FixedStats.StatsGroup02:
                    return LanguageProvider.GetEntry(LanguageEntries.DAMAGEEFFECTS_NAME);
                case FixedStats.StatsGroup03:
                    return LanguageProvider.GetEntry(LanguageEntries.TEMPERATUREEFFECTS_NAME);
                case FixedStats.StatsGroup04:
                    return LanguageProvider.GetEntry(LanguageEntries.DISEASEEFFECTS_NAME);
                case FixedStats.StatsGroup05:
                    return LanguageProvider.GetEntry(LanguageEntries.OTHEREFFECTS_NAME);
                case FixedStats.StatsGroup06:
                case FixedStats.StatsGroup07:
                case FixedStats.StatsGroup08:
                case FixedStats.StatsGroup09:
                case FixedStats.StatsGroup10:
                    return "";
            }
            return "";
        }

        public static string GetValidStatsHelpInfo(ValidStats stat)
        {
            switch (stat)
            {
                case ValidStats.Hunger:
                    return LanguageProvider.GetEntry(LanguageEntries.HUNGER_DESCRIPTION);
                case ValidStats.Thirst:
                    return LanguageProvider.GetEntry(LanguageEntries.THIRST_DESCRIPTION);
                case ValidStats.Stamina:
                    return LanguageProvider.GetEntry(LanguageEntries.STAMINA_DESCRIPTION);
                case ValidStats.Fatigue:
                    return LanguageProvider.GetEntry(LanguageEntries.FATIGUE_DESCRIPTION);
                case ValidStats.WoundedTime:
                    return LanguageProvider.GetEntry(LanguageEntries.WOUNDEDTIME_DESCRIPTION);
                case ValidStats.BodyEnergy:
                    return LanguageProvider.GetEntry(LanguageEntries.BODYENERGY_DESCRIPTION);
                case ValidStats.BodyWater:
                    return LanguageProvider.GetEntry(LanguageEntries.BODYWATER_DESCRIPTION);
                case ValidStats.BodyPerformance:
                    return LanguageProvider.GetEntry(LanguageEntries.BODYPERFORMANCE_DESCRIPTION);
                case ValidStats.BodyImmune:
                    return LanguageProvider.GetEntry(LanguageEntries.BODYIMMUNE_DESCRIPTION);
                case ValidStats.Stomach:
                    return LanguageProvider.GetEntry(LanguageEntries.STOMACH_DESCRIPTION);
                case ValidStats.Intestine:
                    return LanguageProvider.GetEntry(LanguageEntries.INTESTINE_DESCRIPTION);
                case ValidStats.Bladder:
                    return LanguageProvider.GetEntry(LanguageEntries.BLADDER_DESCRIPTION);
                case ValidStats.BodyWeight:
                    return LanguageProvider.GetEntry(LanguageEntries.BODYWEIGHT_DESCRIPTION);
                case ValidStats.BodyMuscles:
                    return LanguageProvider.GetEntry(LanguageEntries.BODYMUSCLES_DESCRIPTION);
                case ValidStats.BodyFat:
                    return LanguageProvider.GetEntry(LanguageEntries.BODYFAT_DESCRIPTION);
                case ValidStats.BodyMusclesWeight:
                    return LanguageProvider.GetEntry(LanguageEntries.BODYMUSCLESWEIGHT_DESCRIPTION);
                case ValidStats.BodyFatWeight:
                    return LanguageProvider.GetEntry(LanguageEntries.BODYFATWEIGHT_DESCRIPTION);
                case ValidStats.FoodDetector:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODDETECTOR_DESCRIPTION);
                case ValidStats.MedicalDetector:
                    return LanguageProvider.GetEntry(LanguageEntries.MEDICALDETECTOR_DESCRIPTION);
                case ValidStats.BodyCalories:
                    return LanguageProvider.GetEntry(LanguageEntries.BODYCALORIES_DESCRIPTION);
                case ValidStats.BodyProtein:
                    return LanguageProvider.GetEntry(LanguageEntries.BODYPROTEIN_DESCRIPTION);
                case ValidStats.BodyCarbohydrate:
                    return LanguageProvider.GetEntry(LanguageEntries.BODYCARBOHYDRATE_DESCRIPTION);
                case ValidStats.BodyLipids:
                    return LanguageProvider.GetEntry(LanguageEntries.BODYLIPIDS_DESCRIPTION);
                case ValidStats.BodyMinerals:
                    return LanguageProvider.GetEntry(LanguageEntries.BODYMINERALS_DESCRIPTION);
                case ValidStats.BodyVitamins:
                    return LanguageProvider.GetEntry(LanguageEntries.BODYVITAMINS_DESCRIPTION);
                case ValidStats.IntoxicationTime:
                    return LanguageProvider.GetEntry(LanguageEntries.INTOXICATIONTIME_DESCRIPTION);
                case ValidStats.RadiationTime:
                    return LanguageProvider.GetEntry(LanguageEntries.RADIATIONTIME_DESCRIPTION);
                case ValidStats.HotThermalFluid:
                    return LanguageProvider.GetEntry(LanguageEntries.HOTTHERMALFLUID_DESCRIPTION);
                case ValidStats.ColdThermalFluid:
                    return LanguageProvider.GetEntry(LanguageEntries.COLDTHERMALFLUID_DESCRIPTION);
                case ValidStats.EnergyShield:
                    return LanguageProvider.GetEntry(LanguageEntries.ENERGYSHIELD_DESCRIPTION);
                case ValidStats.StaminaAmount:
                    return LanguageProvider.GetEntry(LanguageEntries.STAMINAAMOUNT_DESCRIPTION);
            }
            return "";
        }

        public static string GetValidStatsDescription(ValidStats stat)
        {
            switch (stat)
            {
                case ValidStats.Hunger:
                    return LanguageProvider.GetEntry(LanguageEntries.HUNGER_NAME);
                case ValidStats.Thirst:
                    return LanguageProvider.GetEntry(LanguageEntries.THIRST_NAME);
                case ValidStats.Stamina:
                    return LanguageProvider.GetEntry(LanguageEntries.STAMINA_NAME);
                case ValidStats.Fatigue:
                    return LanguageProvider.GetEntry(LanguageEntries.FATIGUE_NAME); 
                case ValidStats.WoundedTime:
                    return LanguageProvider.GetEntry(LanguageEntries.WOUNDEDTIME_NAME);
                case ValidStats.BodyEnergy:
                    return LanguageProvider.GetEntry(LanguageEntries.BODYENERGY_NAME);
                case ValidStats.BodyWater:
                    return LanguageProvider.GetEntry(LanguageEntries.BODYWATER_NAME);
                case ValidStats.BodyPerformance:
                    return LanguageProvider.GetEntry(LanguageEntries.BODYPERFORMANCE_NAME);
                case ValidStats.BodyImmune:
                    return LanguageProvider.GetEntry(LanguageEntries.BODYIMMUNE_NAME);
                case ValidStats.Stomach:
                    return LanguageProvider.GetEntry(LanguageEntries.STOMACH_NAME);
                case ValidStats.Intestine:
                    return LanguageProvider.GetEntry(LanguageEntries.INTESTINE_NAME);
                case ValidStats.Bladder:
                    return LanguageProvider.GetEntry(LanguageEntries.BLADDER_NAME);
                case ValidStats.BodyWeight:
                    return LanguageProvider.GetEntry(LanguageEntries.BODYWEIGHT_NAME);
                case ValidStats.BodyMuscles:
                    return LanguageProvider.GetEntry(LanguageEntries.BODYMUSCLES_NAME);
                case ValidStats.BodyFat:
                    return LanguageProvider.GetEntry(LanguageEntries.BODYFAT_NAME);
                case ValidStats.BodyMusclesWeight:
                    return LanguageProvider.GetEntry(LanguageEntries.BODYMUSCLESWEIGHT_NAME);
                case ValidStats.BodyFatWeight:
                    return LanguageProvider.GetEntry(LanguageEntries.BODYFATWEIGHT_NAME);
                case ValidStats.FoodDetector:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODDETECTOR_NAME);
                case ValidStats.MedicalDetector:
                    return LanguageProvider.GetEntry(LanguageEntries.MEDICALDETECTOR_NAME);
                case ValidStats.BodyCalories:
                    return LanguageProvider.GetEntry(LanguageEntries.BODYCALORIES_NAME);
                case ValidStats.BodyProtein:
                    return LanguageProvider.GetEntry(LanguageEntries.BODYPROTEIN_NAME);
                case ValidStats.BodyCarbohydrate:
                    return LanguageProvider.GetEntry(LanguageEntries.BODYCARBOHYDRATE_NAME);
                case ValidStats.BodyLipids:
                    return LanguageProvider.GetEntry(LanguageEntries.BODYLIPIDS_NAME);
                case ValidStats.BodyMinerals:
                    return LanguageProvider.GetEntry(LanguageEntries.BODYMINERALS_NAME);
                case ValidStats.BodyVitamins:
                    return LanguageProvider.GetEntry(LanguageEntries.BODYVITAMINS_NAME);
                case ValidStats.IntoxicationTime:
                    return LanguageProvider.GetEntry(LanguageEntries.INTOXICATIONTIME_NAME);
                case ValidStats.RadiationTime:
                    return LanguageProvider.GetEntry(LanguageEntries.RADIATIONTIME_NAME);
                case ValidStats.HotThermalFluid:
                    return LanguageProvider.GetEntry(LanguageEntries.HOTTHERMALFLUID_NAME);
                case ValidStats.ColdThermalFluid:
                    return LanguageProvider.GetEntry(LanguageEntries.COLDTHERMALFLUID_NAME);
                case ValidStats.EnergyShield:
                    return LanguageProvider.GetEntry(LanguageEntries.ENERGYSHIELD_NAME);
                case ValidStats.StaminaAmount:
                    return LanguageProvider.GetEntry(LanguageEntries.STAMINAAMOUNT_NAME);
            }
            return "";
        }

        public static string GetCreatureValidStatsDescription(CreatureValidStats stat)
        {
            switch (stat)
            {
                case CreatureValidStats.Torpor:
                    return LanguageProvider.GetEntry(LanguageEntries.TORPOR_NAME);
            }
            return "";
        }

        public static string GetDiseaseEffectDescription(DiseaseEffects effect)
        {
            switch (effect)
            {
                case DiseaseEffects.Flu:
                    return LanguageProvider.GetEntry(LanguageEntries.DISEASEEFFECTS_FLU_NAME);
                case DiseaseEffects.Pneumonia:
                    return LanguageProvider.GetEntry(LanguageEntries.DISEASEEFFECTS_PNEUMONIA_NAME);
                case DiseaseEffects.Dysentery:
                    return LanguageProvider.GetEntry(LanguageEntries.DISEASEEFFECTS_DYSENTERY_NAME);
                case DiseaseEffects.Poison:
                    return LanguageProvider.GetEntry(LanguageEntries.DISEASEEFFECTS_POISON_NAME);
                case DiseaseEffects.Infected:
                    return LanguageProvider.GetEntry(LanguageEntries.DISEASEEFFECTS_INFECTED_NAME);
                case DiseaseEffects.Hypothermia:
                    return LanguageProvider.GetEntry(LanguageEntries.DISEASEEFFECTS_HYPOTHERMIA_NAME);
                case DiseaseEffects.Hyperthermia:
                    return LanguageProvider.GetEntry(LanguageEntries.DISEASEEFFECTS_HYPERTHERMIA_NAME);
                case DiseaseEffects.Starvation:
                    return LanguageProvider.GetEntry(LanguageEntries.DISEASEEFFECTS_STARVATION_NAME);
                case DiseaseEffects.SevereStarvation:
                    return LanguageProvider.GetEntry(LanguageEntries.DISEASEEFFECTS_SEVERESTARVATION_NAME);
                case DiseaseEffects.Dehydration:
                    return LanguageProvider.GetEntry(LanguageEntries.DISEASEEFFECTS_DEHYDRATION_NAME);
                case DiseaseEffects.SevereDehydration:
                    return LanguageProvider.GetEntry(LanguageEntries.DISEASEEFFECTS_SEVEREDEHYDRATION_NAME);
                case DiseaseEffects.Obesity:
                    return LanguageProvider.GetEntry(LanguageEntries.DISEASEEFFECTS_OBESITY_NAME);
                case DiseaseEffects.SevereObesity:
                    return LanguageProvider.GetEntry(LanguageEntries.DISEASEEFFECTS_SEVEREOBESITY_NAME);
                case DiseaseEffects.Rickets:
                    return LanguageProvider.GetEntry(LanguageEntries.DISEASEEFFECTS_RICKETS_NAME);
                case DiseaseEffects.SevereRickets:
                    return LanguageProvider.GetEntry(LanguageEntries.DISEASEEFFECTS_SEVERERICKETS_NAME);
                case DiseaseEffects.Hypolipidemia:
                    return LanguageProvider.GetEntry(LanguageEntries.DISEASEEFFECTS_HYPOLIPIDEMIA_NAME);
                case DiseaseEffects.Queasy:
                    return LanguageProvider.GetEntry(LanguageEntries.DISEASEEFFECTS_QUEASY_NAME);
            }
            return "";
        }
        
        public static bool CanDiseaseEffectStack(DiseaseEffects effect)
        {
            switch (effect)
            {
                case DiseaseEffects.Dysentery:
                case DiseaseEffects.Poison:
                case DiseaseEffects.Infected:
                case DiseaseEffects.Queasy:
                case DiseaseEffects.Hypothermia:
                case DiseaseEffects.Hyperthermia:
                    return true;
                case DiseaseEffects.None:
                case DiseaseEffects.Pneumonia:
                case DiseaseEffects.Starvation:
                case DiseaseEffects.SevereStarvation:
                case DiseaseEffects.Dehydration:
                case DiseaseEffects.SevereDehydration:
                case DiseaseEffects.Obesity:
                case DiseaseEffects.SevereObesity:
                case DiseaseEffects.Rickets:
                case DiseaseEffects.SevereRickets:
                case DiseaseEffects.Hypolipidemia:
                case DiseaseEffects.Flu:
                default:
                    return false;
            }
        }

        public static byte GetDiseaseEffectMaxStack(DiseaseEffects effect)
        {
            switch (effect)
            {
                case DiseaseEffects.Dysentery:
                case DiseaseEffects.Poison:
                case DiseaseEffects.Infected:
                case DiseaseEffects.Queasy:
                    return 5;
                case DiseaseEffects.Hypothermia:
                case DiseaseEffects.Hyperthermia:
                    return 2;
                default:
                    return 0;
            }
        }

        public static bool CanDiseaseEffectSelfRemove(DiseaseEffects effect)
        {
            switch (effect)
            {
                case DiseaseEffects.Poison:
                case DiseaseEffects.Pneumonia:
                case DiseaseEffects.Queasy:
                case DiseaseEffects.Dysentery:
                case DiseaseEffects.Infected:
                case DiseaseEffects.Flu:
                case DiseaseEffects.Hyperthermia:
                case DiseaseEffects.Hypothermia:
                    return true;
                default:
                    return false;
            }
        }

        public static int GetDiseaseEffectTimeToRemove(DiseaseEffects effect)
        {
            switch (effect)
            {
                case DiseaseEffects.Poison:
                    return 60 * 1000; /* 60 segundos */
                case DiseaseEffects.Hypothermia:
                case DiseaseEffects.Hyperthermia:
                    return 150 * 1000; /* 150 segundos */
                case DiseaseEffects.Dysentery:
                case DiseaseEffects.Queasy:
                    return 120 * 60 * 1000; /* 120 minutos */
                case DiseaseEffects.Pneumonia:
                case DiseaseEffects.Flu:
                case DiseaseEffects.Infected:
                    return 240 * 60 * 1000; /* 240 minutos */
                default:
                    return 0;
            }
        }

        public static bool IsDiseaseEffectCompleteRemove(DiseaseEffects effect)
        {
            switch (effect)
            {
                case DiseaseEffects.Flu:
                case DiseaseEffects.Pneumonia:
                case DiseaseEffects.Infected:
                case DiseaseEffects.Hypothermia:
                case DiseaseEffects.Hyperthermia:
                    return true;
                default:
                    return false;
            }
        }

        public static byte GetDiseaseEffectStacksWhenRemove(DiseaseEffects effect)
        {
            switch (effect)
            {
                case DiseaseEffects.Poison:
                case DiseaseEffects.Queasy:
                case DiseaseEffects.Dysentery:
                    return 1;
                default:
                    return 0;
            }
        }

        public static string GetOtherEffectDescription(OtherEffects effect)
        {
            switch (effect)
            {
                case OtherEffects.PoopOnClothes:
                    return LanguageProvider.GetEntry(LanguageEntries.OTHEREFFECTS_POOPONCLOTHES_NAME);
                case OtherEffects.PeeOnClothes:
                    return LanguageProvider.GetEntry(LanguageEntries.OTHEREFFECTS_PEEONCLOTHES_NAME);
            }
            return "";
        }

        public static int GetOtherEffectTrackLevel(OtherEffects effect)
        {
            return 0;
        }

        public static int GetOtherEffectFeelingLevel(OtherEffects effect)
        {
            switch (effect)
            {
                case OtherEffects.PoopOnClothes:
                case OtherEffects.PeeOnClothes:
                    return 1;
            }
            return 0;
        }

        public static string GetTemperatureEffectDescription(TemperatureEffects effect)
        {
            switch (effect)
            {
                case TemperatureEffects.Overheating:
                    return LanguageProvider.GetEntry(LanguageEntries.TEMPERATUREEFFECTS_OVERHEATING_NAME);
                case TemperatureEffects.OnFire:
                    return LanguageProvider.GetEntry(LanguageEntries.TEMPERATUREEFFECTS_ONFIRE_NAME);
                case TemperatureEffects.Cold:
                    return LanguageProvider.GetEntry(LanguageEntries.TEMPERATUREEFFECTS_COLD_NAME);
                case TemperatureEffects.Frosty:
                    return LanguageProvider.GetEntry(LanguageEntries.TEMPERATUREEFFECTS_FROSTY_NAME);
                case TemperatureEffects.Wet:
                    return LanguageProvider.GetEntry(LanguageEntries.TEMPERATUREEFFECTS_WET_NAME);
                case TemperatureEffects.ExposedToCold:
                    return LanguageProvider.GetEntry(LanguageEntries.TEMPERATUREEFFECTS_EXPOSEDTOCOLD_NAME);
                case TemperatureEffects.ExposedToFreeze:
                    return LanguageProvider.GetEntry(LanguageEntries.TEMPERATUREEFFECTS_EXPOSEDTOFREEZE_NAME);
                case TemperatureEffects.ExposedToHot:
                    return LanguageProvider.GetEntry(LanguageEntries.TEMPERATUREEFFECTS_EXPOSEDTOHOT_NAME);
                case TemperatureEffects.ExposedToBoiling:
                    return LanguageProvider.GetEntry(LanguageEntries.TEMPERATUREEFFECTS_EXPOSEDTOBOILING_NAME);
                case TemperatureEffects.RecoveringFromExposure:
                    return LanguageProvider.GetEntry(LanguageEntries.TEMPERATUREEFFECTS_RECOVERINGFROMEXPOSURE_NAME);
                case TemperatureEffects.LesserResistenceToCold:
                    return LanguageProvider.GetEntry(LanguageEntries.TEMPERATUREEFFECTS_LESSERRESISTENCETOCOLD_NAME);
                case TemperatureEffects.ResistenceToCold:
                    return LanguageProvider.GetEntry(LanguageEntries.TEMPERATUREEFFECTS_RESISTENCETOCOLD_NAME);
                case TemperatureEffects.GreaterResistenceToCold:
                    return LanguageProvider.GetEntry(LanguageEntries.TEMPERATUREEFFECTS_GREATERRESISTENCETOCOLD_NAME);
                case TemperatureEffects.LesserResistenceToHot:
                    return LanguageProvider.GetEntry(LanguageEntries.TEMPERATUREEFFECTS_LESSERRESISTENCETOHOT_NAME);
                case TemperatureEffects.ResistenceToHot:
                    return LanguageProvider.GetEntry(LanguageEntries.TEMPERATUREEFFECTS_RESISTENCETOHOT_NAME);
                case TemperatureEffects.GreaterResistenceToHot:
                    return LanguageProvider.GetEntry(LanguageEntries.TEMPERATUREEFFECTS_GREATERRESISTENCETOHOT_NAME);
            }
            return "";
        }
        
        public static int GetTemperatureEffectTrackLevel(TemperatureEffects effect)
        {
            switch (effect)
            {
                case TemperatureEffects.Overheating:
                case TemperatureEffects.OnFire:
                case TemperatureEffects.Cold:
                case TemperatureEffects.Frosty:
                case TemperatureEffects.LesserResistenceToCold:
                case TemperatureEffects.ResistenceToCold:
                case TemperatureEffects.GreaterResistenceToCold:
                case TemperatureEffects.LesserResistenceToHot:
                case TemperatureEffects.ResistenceToHot:
                case TemperatureEffects.GreaterResistenceToHot:
                case TemperatureEffects.Wet:
                case TemperatureEffects.ExposedToCold:
                case TemperatureEffects.ExposedToFreeze:
                case TemperatureEffects.ExposedToHot:
                case TemperatureEffects.ExposedToBoiling:
                    return 0;
            }
            return 0;
        }

        public static int GetTemperatureEffectFeelingLevel(TemperatureEffects effect)
        {
            switch (effect)
            {
                case TemperatureEffects.Overheating:
                case TemperatureEffects.Cold:
                case TemperatureEffects.Wet:
                case TemperatureEffects.ExposedToCold:
                case TemperatureEffects.ExposedToFreeze:
                case TemperatureEffects.ExposedToHot:
                case TemperatureEffects.ExposedToBoiling:
                    return 1;
                case TemperatureEffects.OnFire:
                case TemperatureEffects.Frosty:
                    return 2;
            }
            return 0;
        }

        public static string GetDamageEffectDescription(DamageEffects effect)
        {
            switch (effect)
            {
                case DamageEffects.Contusion:
                    return LanguageProvider.GetEntry(LanguageEntries.DAMAGEEFFECTS_CONTUSION_NAME);
                case DamageEffects.Wounded:
                    return LanguageProvider.GetEntry(LanguageEntries.DAMAGEEFFECTS_WOUNDED_NAME);
                case DamageEffects.DeepWounded:
                    return LanguageProvider.GetEntry(LanguageEntries.DAMAGEEFFECTS_DEEPWOUNDED_NAME);
                case DamageEffects.BrokenBones:
                    return LanguageProvider.GetEntry(LanguageEntries.DAMAGEEFFECTS_BROKENBONES_NAME);
            }
            return "";
        }

        public static int GetDamageEffectTrackLevel(DamageEffects effect)
        {
            switch (effect)
            {
                case DamageEffects.Contusion:
                case DamageEffects.Wounded:
                case DamageEffects.DeepWounded:
                case DamageEffects.BrokenBones:
                    return 0;
            }
            return 0;
        }

        public static int GetDamageEffectFeelingLevel(DamageEffects effect)
        {
            switch (effect)
            {
                case DamageEffects.Contusion:
                    return 1;
                case DamageEffects.Wounded:
                    return 2;
                case DamageEffects.DeepWounded:
                    return 3;
                case DamageEffects.BrokenBones:
                    return 4;
            }
            return 0;
        }

        public static bool CanDamageEffectSelfRemove(DamageEffects effect)
        {
            switch (effect)
            {
                case DamageEffects.Contusion:
                case DamageEffects.Wounded:
                case DamageEffects.DeepWounded:
                case DamageEffects.BrokenBones:
                    return true;
                default:
                    return false;
            }
        }

        public static int GetDamageEffectTimeToRemove(DamageEffects effect)
        {
            switch (effect)
            {
                case DamageEffects.Contusion:
                    return 30 * 60 * 1000; /* 30 minutos */
                case DamageEffects.Wounded:
                    return 60 * 60 * 1000; /* 60 minutos */
                case DamageEffects.DeepWounded:
                    return 120 * 60 * 1000; /* 120 minutos */
                case DamageEffects.BrokenBones:
                    return 240 * 60 * 1000; /* 240 minutos */
                default:
                    return 0;
            }
        }

        public static bool GetDamageEffectSelfRemove(DamageEffects effect)
        {
            switch (effect)
            {
                case DamageEffects.Contusion:
                case DamageEffects.Wounded:
                case DamageEffects.DeepWounded:
                case DamageEffects.BrokenBones:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsDamageEffectCompleteRemove(DamageEffects effect)
        {
            switch (effect)
            {
                case DamageEffects.Contusion:
                case DamageEffects.Wounded:
                case DamageEffects.DeepWounded:
                case DamageEffects.BrokenBones:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsDamageEffectCanStack(DamageEffects effect)
        {
            switch (effect)
            {
                case DamageEffects.Contusion:
                case DamageEffects.Wounded:
                case DamageEffects.DeepWounded:
                case DamageEffects.BrokenBones:
                default:
                    return false;
            }
        }

        public static byte GetDamageEffectStacksWhenRemove(DamageEffects effect)
        {
            switch (effect)
            {
                case DamageEffects.Contusion:
                case DamageEffects.Wounded:
                case DamageEffects.DeepWounded:
                case DamageEffects.BrokenBones:
                default:
                    return 0;
            }
        }

        public static int GetSurvivalEffectMaxInverseTime(SurvivalEffects effect)
        {
            if (effect == SurvivalEffects.EmptyStomach)
                return 5 * 60 * 1000;
            return 0;
        }

        public static bool GetSurvivalEffectIsInverseTime(SurvivalEffects effect)
        {
            if (effect == SurvivalEffects.EmptyStomach)
                return true;
            return false;
        }

        public static bool GetSurvivalEffectCanStack(SurvivalEffects effect)
        {
            if (effect == SurvivalEffects.EmptyStomach)
                return true;
            return false;
        }

        public static byte GetSurvivalEffectMaxStacks(SurvivalEffects effect)
        {
            if (effect == SurvivalEffects.EmptyStomach)
                return 5;
            return 0;
        }

        public static string GetSurvivalEffectDescription(SurvivalEffects effect)
        {
            switch (effect)
            {
                case SurvivalEffects.Hungry:
                    return LanguageProvider.GetEntry(LanguageEntries.SURVIVALEFFECTS_HUNGRY_NAME);
                case SurvivalEffects.Famished:
                    return LanguageProvider.GetEntry(LanguageEntries.SURVIVALEFFECTS_FAMISHED_NAME);
                case SurvivalEffects.Thirsty:
                    return LanguageProvider.GetEntry(LanguageEntries.SURVIVALEFFECTS_THIRSTY_NAME);
                case SurvivalEffects.Dehydrating:
                    return LanguageProvider.GetEntry(LanguageEntries.SURVIVALEFFECTS_DEHYDRATING_NAME);
                case SurvivalEffects.Disoriented:
                    return LanguageProvider.GetEntry(LanguageEntries.SURVIVALEFFECTS_DISORIENTED_NAME);
                case SurvivalEffects.Suffocation:
                    return LanguageProvider.GetEntry(LanguageEntries.SURVIVALEFFECTS_SUFFOCATION_NAME);
                case SurvivalEffects.FullStomach:
                    return LanguageProvider.GetEntry(LanguageEntries.SURVIVALEFFECTS_FULLSTOMACH_NAME);
                case SurvivalEffects.StomachBursting:
                    return LanguageProvider.GetEntry(LanguageEntries.SURVIVALEFFECTS_STOMACHBURSTING_NAME);
                case SurvivalEffects.FullGut:
                    return LanguageProvider.GetEntry(LanguageEntries.SURVIVALEFFECTS_FULLGUT_NAME);
                case SurvivalEffects.GutBurst:
                    return LanguageProvider.GetEntry(LanguageEntries.SURVIVALEFFECTS_GUTBURST_NAME);
                case SurvivalEffects.FullBladder:
                    return LanguageProvider.GetEntry(LanguageEntries.SURVIVALEFFECTS_FULLBLADDER_NAME);
                case SurvivalEffects.BladderBurst:
                    return LanguageProvider.GetEntry(LanguageEntries.SURVIVALEFFECTS_BLADDERBURST_NAME);
                case SurvivalEffects.Tired:
                    return LanguageProvider.GetEntry(LanguageEntries.SURVIVALEFFECTS_TIRED_NAME);
                case SurvivalEffects.ExtremelyTired:
                    return LanguageProvider.GetEntry(LanguageEntries.SURVIVALEFFECTS_EXTREMELYTIRED_NAME);
                case SurvivalEffects.StomachGrowling:
                    return LanguageProvider.GetEntry(LanguageEntries.SURVIVALEFFECTS_STOMACHGROWLING_NAME);
                case SurvivalEffects.EmptyStomach:
                    return LanguageProvider.GetEntry(LanguageEntries.SURVIVALEFFECTS_EMPTYSTOMACH_NAME);
            }
            return "";
        }

        public static int GetSurvivalEffectTrackLevel(SurvivalEffects effect)
        {
            switch (effect)
            {
                case SurvivalEffects.Hungry:
                case SurvivalEffects.Famished:
                case SurvivalEffects.Thirsty:
                case SurvivalEffects.Dehydrating:
                case SurvivalEffects.Disoriented:
                case SurvivalEffects.Suffocation:
                case SurvivalEffects.FullStomach:
                case SurvivalEffects.StomachBursting:
                case SurvivalEffects.FullGut:
                case SurvivalEffects.GutBurst:
                case SurvivalEffects.FullBladder:
                case SurvivalEffects.BladderBurst:
                case SurvivalEffects.Tired:
                case SurvivalEffects.ExtremelyTired:
                case SurvivalEffects.StomachGrowling:
                case SurvivalEffects.EmptyStomach:
                    return 0;
            }
            return 0;
        }

        public static int GetSurvivalEffectFeelingLevel(SurvivalEffects effect)
        {
            switch (effect)
            {
                case SurvivalEffects.Hungry:
                case SurvivalEffects.Thirsty:
                case SurvivalEffects.Disoriented:
                case SurvivalEffects.Tired:
                case SurvivalEffects.FullBladder:
                case SurvivalEffects.FullGut:
                case SurvivalEffects.FullStomach:
                case SurvivalEffects.StomachGrowling:
                    return 1;
                case SurvivalEffects.Famished:
                case SurvivalEffects.Dehydrating:
                case SurvivalEffects.Suffocation:
                case SurvivalEffects.ExtremelyTired:
                case SurvivalEffects.BladderBurst:
                case SurvivalEffects.GutBurst:
                case SurvivalEffects.StomachBursting:
                case SurvivalEffects.EmptyStomach:
                    return 2;
            }
            return 0;
        }

        public static string GetFeelingByTotalEffects(int ammount)
        {
            if (ammount == 0)
                return LanguageProvider.GetEntry(LanguageEntries.FEELING_LEVEL0_NAME);
            if (ammount <= 3)
                return LanguageProvider.GetEntry(LanguageEntries.FEELING_LEVEL1_NAME);
            if (ammount <= 6)
                return LanguageProvider.GetEntry(LanguageEntries.FEELING_LEVEL2_NAME);
            if (ammount <= 9)
                return LanguageProvider.GetEntry(LanguageEntries.FEELING_LEVEL3_NAME);
            return LanguageProvider.GetEntry(LanguageEntries.FEELING_LEVEL4_NAME);
        }

        public static IEnumerable<T> GetFlags<T>(this T value) where T : struct
        {
            foreach (T flag in Enum.GetValues(typeof(T)).Cast<T>())
            {
                if (value.IsFlagSet(flag))
                    yield return flag;
            }
        }

        public static bool IsFlagSet<T>(this T value, T flag) where T : struct
        {
            long lValue = Convert.ToInt64(value);
            long lFlag = Convert.ToInt64(flag);
            return (lValue & lFlag) != 0;
        }

        public static int GetMaxSetFlagValue<T>(T flags) where T : struct
        {
            int value = (int)Convert.ChangeType(flags, typeof(int));
            IEnumerable<int> setValues = Enum.GetValues(flags.GetType()).Cast<int>().Where(f => (f & value) == f);
            return setValues.Any() ? setValues.Max() : 0;
        }

        public static bool IsStringInFlag<T>(string key, out T id) where T : struct
        {
            id = default(T);
            foreach (T flag in Enum.GetValues(typeof(T)).Cast<T>())
            {
                if (key.CompareTo(flag.ToString()) == 0)
                {
                    id = flag;
                    return true;
                }
            }
            return false;
        }

        public static readonly string BASE_TOPIC_ID = HelpController.BASE_TOPIC_TYPE + "." + HelpController.HELP_SYSTEM_TOPIC_SUBTYPE;
        public static readonly string HELP_TOPIC_PLAYERSTATS = "PlayerStats";
        public static readonly string HELP_TOPIC_ATTRIBUTES = "Attributes";

        public static void BuildHelpTopics()
        {
            /* Added Start System Page */
            var playerStatsId = new UniqueNameId(BASE_TOPIC_ID, HELP_TOPIC_PLAYERSTATS);
            HelpController.AddEntry(
                HelpController.HelpSystemTopicId,
                playerStatsId,
                LanguageProvider.GetEntry(LanguageEntries.HELP_TOPIC_PLAYERSTATS_TITLE),
                1
            );
            HelpController.AddPage(
                HelpController.HelpSystemTopicId,
                playerStatsId,
                LanguageProvider.GetEntry(LanguageEntries.HELP_TOPIC_PLAYERSTATS_DESCRIPTION)
            );
            /* Added Attribute Entry */
            var attributesId = new UniqueNameId(BASE_TOPIC_ID, HELP_TOPIC_ATTRIBUTES);
            HelpController.AddEntry(
                HelpController.HelpSystemTopicId,
                attributesId,
                LanguageProvider.GetEntry(LanguageEntries.HELP_TOPIC_ATTRIBUTES_TITLE),
                2
            );
            HelpController.AddPage(
                HelpController.HelpSystemTopicId,
                attributesId,
                LanguageProvider.GetEntry(LanguageEntries.HELP_TOPIC_ATTRIBUTES_DESCRIPTION)
            );
            foreach (ValidStats item in Enum.GetValues(typeof(ValidStats)).Cast<ValidStats>())
            {
                var itemId = new UniqueNameId(BASE_TOPIC_ID + "." + HELP_TOPIC_ATTRIBUTES, item.ToString());
                HelpController.AddEntry(
                    HelpController.HelpSystemTopicId,
                    itemId,
                    GetValidStatsDescription(item),
                    3
                );
                HelpController.AddPage(
                    HelpController.HelpSystemTopicId,
                    itemId,
                    GetValidStatsHelpInfo(item)
                );
            }
        }

    }

}