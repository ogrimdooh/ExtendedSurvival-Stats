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
            { DamageEffects.Wounded, 0.7f },
            { DamageEffects.DeepWounded, 0.5f },
            { DamageEffects.BrokenBones, 0.3f }
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
            IntakeBodyWater,
            IntakeCarbohydrates,
            IntakeProtein,
            IntakeLipids,
            IntakeVitamins,
            IntakeMinerals,
            BodyWeight,
            BodyMuscles,
            BodyFat,
            FoodDetector

        }

        [Flags]
        public enum SurvivalEffects
        {

            None = 0,
            /* Hunger Effects */
            Hungry = 1, /* Have less than 10% Hunger */
            Famished = 2, /* Have 5% Hunger */
            /* Thirst Effects */
            Thirsty = 4, /* Have less than 10% Thirst */
            Dehydrating = 8, /* Have 5% Thirst */
            /* Oxygen Effects */
            Disoriented = 16, /* Have less than 10% Oxygen */
            Suffocation = 32 /* Have 5% Oxygen */

        }

        [Flags]
        public enum DamageEffects
        {

            None = 0,
            Contusion = 1, /* Take damage more than 10% Max Life */
            Wounded = 2, /* Take damage more than 20% Max Life */
            DeepWounded = 4, /* Take damage more than 40% Max Life, replace Wounded */
            BrokenBones = 8 /* Take damage more than 60% Max Life, replace Contusion */

        }

        [Flags]
        public enum TemperatureEffects
        {

            None = 0,
            Overheating = 1, /* Stay in a hot place more than 6 minutes, or burning more than 3 minutes */
            OnFire = 2, /* Stay in a burning more than 6 minutes, replace Overheating */
            Cold = 4, /* Stay in a cold place more than 6 minutes, or freezing more than 3 minutes */
            Frosty = 8, /* Stay in a freezing more than 6 minutes, replace Cold */
            Wet = 16 /* Stay in the rain or enter under water (Water Mod)  */

        }

        [Flags]
        public enum DiseaseEffects
        {

            None = 0,
            Pneumonia = 1, /* After getting cold or frosty can get Pneumonia by chance, wet incrise that chance */
            Dysentery = 2, /* Recived by eating raw meat food, with raw vegetables or fruits has a little chance */
            Poison = 4, /* Recived by food or poison damage */
            Infected = 8, /* Dont remove Wounded, DeepWounded or BrokenBones in 10 minutes */
            Hypothermia = 16, /* Get max temperature negative timer */
            Hyperthermia = 32, /* Get max temperature positive timer */
            Starvation = 64,
            SevereStarvation = 128,
            Dehydration = 256,
            SevereDehydration = 512,
            Obesity = 1024,
            SevereObesity = 2048,
            Rickets = 4096,
            SevereRickets = 8192,
            Hypolipidemia = 16384

        }

        [Flags]
        public enum OtherEffects
        {

            None = 0

        }

        public static int GetDiseaseEffectFeelingLevel(DiseaseEffects effect)
        {
            switch (effect)
            {
                case DiseaseEffects.Dysentery:
                case DiseaseEffects.Poison:
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

        public static string GetDiseaseEffectDescription(DiseaseEffects effect)
        {
            switch (effect)
            {
                case DiseaseEffects.Pneumonia:
                    return "Pneumonia";
                case DiseaseEffects.Dysentery:
                    return "Dysentery";
                case DiseaseEffects.Poison:
                    return "Poison";
                case DiseaseEffects.Infected:
                    return "Infected";
                case DiseaseEffects.Hypothermia:
                    return "Hypothermia";
                case DiseaseEffects.Hyperthermia:
                    return "Hyperthermia";
                case DiseaseEffects.Starvation:
                    return "Starvation";
                case DiseaseEffects.SevereStarvation:
                    return "Severe Starvation";
                case DiseaseEffects.Dehydration:
                    return "Dehydration";
                case DiseaseEffects.SevereDehydration:
                    return "Severe Dehydration";
                case DiseaseEffects.Obesity:
                    return "Obesity";
                case DiseaseEffects.SevereObesity:
                    return "Severe Obesity";
                case DiseaseEffects.Rickets:
                    return "Rickets";
                case DiseaseEffects.SevereRickets:
                    return "Severe Rickets";
                case DiseaseEffects.Hypolipidemia:
                    return "Hypolipidemia";
            }
            return "";
        }

        public static string GetOtherEffectDescription(OtherEffects effect)
        {
            return "";
        }

        public static int GetOtherEffectTrackLevel(OtherEffects effect)
        {
            return 0;
        }

        public static int GetOtherEffectFeelingLevel(OtherEffects effect)
        {
            return 0;
        }

        public static string GetTemperatureEffectDescription(TemperatureEffects effect)
        {
            switch (effect)
            {
                case TemperatureEffects.Overheating:
                    return "Overheating";
                case TemperatureEffects.OnFire:
                    return "On Fire";
                case TemperatureEffects.Cold:
                    return "Cold";
                case TemperatureEffects.Frosty:
                    return "Frosty";
                case TemperatureEffects.Wet:
                    return "Wet";
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
                    return "Contusion";
                case DamageEffects.Wounded:
                    return "Wounded";
                case DamageEffects.DeepWounded:
                    return "Deep Wounded";
                case DamageEffects.BrokenBones:
                    return "Broken Bones";
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
                    return "Hungry";
                case SurvivalEffects.Famished:
                    return "Famished";
                case SurvivalEffects.Thirsty:
                    return "Thirsty";
                case SurvivalEffects.Dehydrating:
                    return "Dehydrating";
                case SurvivalEffects.Disoriented:
                    return "Disoriented";
                case SurvivalEffects.Suffocation:
                    return "Suffocation";
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
                    return 1;
                case SurvivalEffects.Famished:
                case SurvivalEffects.Dehydrating:
                case SurvivalEffects.Suffocation:
                    return 2;
            }
            return 0;
        }

        public static string GetFeelingByTotalEffects(int ammount)
        {
            if (ammount == 0)
                return "I am feeling good and healthy.";
            if (ammount <= 3)
                return "I'm not feeling very well.";
            if (ammount <= 6)
                return "There's something wrong with me.";
            if (ammount <= 9)
                return "I need to do something before it's too late.";
            return "I need to find help, I think I'm dying.";
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