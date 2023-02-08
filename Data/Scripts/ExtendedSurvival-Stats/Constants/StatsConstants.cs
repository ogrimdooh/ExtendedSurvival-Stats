using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using VRage.Utils;
using VRageMath;

namespace ExtendedSurvival.Stats
{

    public static class StatsConstants
    {

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

        public static readonly Dictionary<TemperatureEffects, float> TEMPERATURE_STAMINA_CONSUME_FACTOR = new Dictionary<TemperatureEffects, float>()
        {
            { TemperatureEffects.Cold, 1.15f },
            { TemperatureEffects.Overheating, 1.15f },
            { TemperatureEffects.Frosty, 1.30f },
            { TemperatureEffects.OnFire, 1.30f }
        };

        public static readonly Dictionary<DamageEffects, float> DAMAGE_STAMINA_REGEN_FACTOR = new Dictionary<DamageEffects, float>()
        {
            { DamageEffects.Contusion, 0.9f },
            { DamageEffects.Wounded, 0.8f },
            { DamageEffects.DeepWounded, 0.7f },
            { DamageEffects.BrokenBones, 0.6f }
        };

        public static readonly Dictionary<DamageEffects, Vector2> DAMAGE_HEALTH_REGEN_FACTOR = new Dictionary<DamageEffects, Vector2>()
        {
            { DamageEffects.Contusion, new Vector2(0.9f, 0.8f) },
            { DamageEffects.Wounded, new Vector2(0.7f, 0.6f) },
            { DamageEffects.DeepWounded, new Vector2(0.5f, 0.4f) },
            { DamageEffects.BrokenBones, new Vector2(0.3f, 0.2f) }
        };

        public static readonly Dictionary<DamageEffects, float> DAMAGE_HEALTH_START_VALUE = new Dictionary<DamageEffects, float>()
        {
            { DamageEffects.Contusion, 0.75f },
            { DamageEffects.Wounded, 0.55f },
            { DamageEffects.DeepWounded, 0.35f },
            { DamageEffects.BrokenBones, 0.15f }
        };

        public static readonly Dictionary<DamageEffects, float> TIME_MULTIPLIER_FACTOR = new Dictionary<DamageEffects, float>()
        {
            { DamageEffects.Wounded, 1f },
            { DamageEffects.DeepWounded, 1.25f },
            { DamageEffects.BrokenBones, 1.50f }
        };

        public static readonly Dictionary<string, float> STATS_MIN_VALUE = new Dictionary<string, float>()
        {
            { ValidStats.Hunger.ToString(), HungerConstants.MIN_HUNGER_AT_START },
            { ValidStats.Thirst.ToString(), HungerConstants.MIN_THIRST_AT_START },
            { ValidStats.Stamina.ToString(), HungerConstants.MIN_STAMINA_AT_START },
            { ValidStats.BodyEnergy.ToString(), HungerConstants.MIN_BODYENERGY_AT_START },
            { ValidStats.BodyWater.ToString(), HungerConstants.MIN_BODYWATER_AT_START }
        };

        public const DamageEffects ON_DEATH_NO_CHANGE_IF = DamageEffects.BrokenBones;
        public const DamageEffects ON_DEATH_APPLY_DAMAGE = DamageEffects.DeepWounded;
        public const DamageEffects ON_DEATH_REMOVE_DAMAGE = DamageEffects.Contusion | DamageEffects.Wounded;

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

        public enum ValidStats
        {

            Hunger,
            Thirst,
            Stamina,
            Fatigue,
            SurvivalEffects,
            DamageEffects,
            TemperatureEffects,
            DiseaseEffects,
            OtherEffects,
            WoundedTime,
            TemperatureTime,
            WetTime,
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
            FoodDetector,
            MedicalDetector,
            BodyCalories

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
            ExtremelyTired = 1 << 14

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
            Overheating = 1 << 1, /* Stay in a hot place more than 6 minutes, or burning more than 3 minutes */
            OnFire = 1 << 2, /* Stay in a burning more than 6 minutes, replace Overheating */
            Cold = 1 << 3, /* Stay in a cold place more than 6 minutes, or freezing more than 3 minutes */
            Frosty = 1 << 4, /* Stay in a freezing more than 6 minutes, replace Cold */
            Wet = 1 << 5 /* Stay in the rain or enter under water (Water Mod)  */

        }

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
            Queasy = 1 << 16

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
                    return 0;
                case DiseaseEffects.Pneumonia:
                case DiseaseEffects.Infected:
                case DiseaseEffects.Hypothermia:
                case DiseaseEffects.Hyperthermia:
                    return 1;
                case DiseaseEffects.Starvation:
                case DiseaseEffects.SevereStarvation:
                case DiseaseEffects.Dehydration:
                case DiseaseEffects.SevereDehydration:
                    return 2;
                case DiseaseEffects.Obesity:
                case DiseaseEffects.SevereObesity:
                case DiseaseEffects.Rickets:
                case DiseaseEffects.SevereRickets:
                case DiseaseEffects.Hypolipidemia:
                    return 3;
            }
            return 0;
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
                case ValidStats.SurvivalEffects:
                    return LanguageProvider.GetEntry(LanguageEntries.SURVIVALEFFECTS_NAME);
                case ValidStats.DamageEffects:
                    return LanguageProvider.GetEntry(LanguageEntries.DAMAGEEFFECTS_NAME);
                case ValidStats.TemperatureEffects:
                    return LanguageProvider.GetEntry(LanguageEntries.TEMPERATUREEFFECTS_NAME);
                case ValidStats.DiseaseEffects:
                    return LanguageProvider.GetEntry(LanguageEntries.DISEASEEFFECTS_NAME);
                case ValidStats.OtherEffects:
                    return LanguageProvider.GetEntry(LanguageEntries.OTHEREFFECTS_NAME);
                case ValidStats.WoundedTime:
                    return LanguageProvider.GetEntry(LanguageEntries.WOUNDEDTIME_NAME);
                case ValidStats.TemperatureTime:
                    return LanguageProvider.GetEntry(LanguageEntries.TEMPERATURETIME_NAME);
                case ValidStats.WetTime:
                    return LanguageProvider.GetEntry(LanguageEntries.WETTIME_NAME);
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
                case ValidStats.FoodDetector:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODDETECTOR_NAME);
                case ValidStats.MedicalDetector:
                    return LanguageProvider.GetEntry(LanguageEntries.MEDICALDETECTOR_NAME);
                case ValidStats.BodyCalories:
                    return LanguageProvider.GetEntry(LanguageEntries.BODYCALORIES_NAME);
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
                    return 1;
                case TemperatureEffects.Wet:
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
                    return 1;
                case DamageEffects.DeepWounded:
                case DamageEffects.BrokenBones:
                    return 2;
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
                    return 1;
                case SurvivalEffects.Famished:
                case SurvivalEffects.Dehydrating:
                case SurvivalEffects.Suffocation:
                case SurvivalEffects.ExtremelyTired:
                case SurvivalEffects.BladderBurst:
                case SurvivalEffects.GutBurst:
                case SurvivalEffects.StomachBursting:
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

        public static readonly Dictionary<SurvivalEffects, MyStringId> SurvivalEffectsIcons = new Dictionary<SurvivalEffects, MyStringId>()
        {
            { SurvivalEffects.Hungry, MyStringId.GetOrCompute("Hungry_White") },
            { SurvivalEffects.Famished, MyStringId.GetOrCompute("Famished_White") },
            { SurvivalEffects.Thirsty, MyStringId.GetOrCompute("Thirsty_White") },
            { SurvivalEffects.Dehydrating, MyStringId.GetOrCompute("Dehydrating_White") },
            { SurvivalEffects.Disoriented, MyStringId.GetOrCompute("Disoriented_White") },
            { SurvivalEffects.Suffocation, MyStringId.GetOrCompute("Suffocation_White") }
        };

        public static readonly Dictionary<DamageEffects, MyStringId> DamageEffectsIcons = new Dictionary<DamageEffects, MyStringId>()
        {
            { DamageEffects.Contusion, MyStringId.GetOrCompute("Contusion_White") },
            { DamageEffects.Wounded, MyStringId.GetOrCompute("Wounded_White") },
            { DamageEffects.DeepWounded, MyStringId.GetOrCompute("DeepWounded_White") },
            { DamageEffects.BrokenBones, MyStringId.GetOrCompute("BrokenBones_White") }
        };

        public static readonly Dictionary<TemperatureEffects, MyStringId> TemperatureEffectsIcons = new Dictionary<TemperatureEffects, MyStringId>()
        {
            { TemperatureEffects.Overheating, MyStringId.GetOrCompute("Overheating_White") },
            { TemperatureEffects.OnFire, MyStringId.GetOrCompute("OnFire_White") },
            { TemperatureEffects.Cold, MyStringId.GetOrCompute("Cold_White") },
            { TemperatureEffects.Frosty, MyStringId.GetOrCompute("Frosty_White") },
            { TemperatureEffects.Wet, MyStringId.GetOrCompute("Wet_White") }
        };

        public static readonly Dictionary<DiseaseEffects, MyStringId> DiseaseEffectsIcons = new Dictionary<DiseaseEffects, MyStringId>()
        {
            { DiseaseEffects.Pneumonia, MyStringId.GetOrCompute("Pneumonia_White") },
            { DiseaseEffects.Dysentery, MyStringId.GetOrCompute("Dysentery_White") },
            { DiseaseEffects.Poison, MyStringId.GetOrCompute("Poison_White") },
            { DiseaseEffects.Infected, MyStringId.GetOrCompute("Infected_White") },
            { DiseaseEffects.Hypothermia, MyStringId.GetOrCompute("Hypothermia_White") },
            { DiseaseEffects.Hyperthermia, MyStringId.GetOrCompute("Hyperthermia_White") },
            { DiseaseEffects.Starvation, MyStringId.GetOrCompute("Starvation_White") },
            { DiseaseEffects.SevereStarvation, MyStringId.GetOrCompute("SevereStarvation_White") },
            { DiseaseEffects.Dehydration, MyStringId.GetOrCompute("Dehydration_White") },
            { DiseaseEffects.SevereDehydration, MyStringId.GetOrCompute("SevereDehydration_White") },
            { DiseaseEffects.Obesity, MyStringId.GetOrCompute("Obesity_White") },
            { DiseaseEffects.SevereObesity, MyStringId.GetOrCompute("SevereObesity_White") },
            { DiseaseEffects.Rickets, MyStringId.GetOrCompute("Rickets_White") },
            { DiseaseEffects.SevereRickets, MyStringId.GetOrCompute("SevereRickets_White") },
            { DiseaseEffects.Hypolipidemia, MyStringId.GetOrCompute("Hypolipidemia_White") }
        };

        public static readonly Dictionary<OtherEffects, MyStringId> OtherEffectsIcons = new Dictionary<OtherEffects, MyStringId>()
        {

        };

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

    }

}