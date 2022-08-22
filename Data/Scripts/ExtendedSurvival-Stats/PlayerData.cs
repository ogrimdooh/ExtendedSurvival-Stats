using System;
using VRageMath;

namespace ExtendedSurvival.Stats
{

    public class PlayerData
    {

        public long EntityId { get; set; }
        public long PlayerId { get; set; }
        public ulong SteamPlayerId { get; set; }
        public bool HasDied { get; set; }
        public float Depth { get; set; }
        public string PlanetAtRange { get; set; }
        public bool? PlanetHasWater { get; set; }
        public DateTime LastTimeDied { get; set; }
        public Vector2 Temperature { get; set; }

        public Vector4 Hunger { get; set; }
        public Vector4 Thirst { get; set; }
        public Vector4 Health { get; set; }
        public Vector4 Stamina { get; set; }
        public Vector4 WoundedTime { get; set; }
        public Vector4 TemperatureTime { get; set; }
        public Vector4 WetTime { get; set; }
        public Vector4 IntakeBodyFood { get; set; }
        public Vector4 IntakeBodyWater { get; set; }
        public Vector4 BodyEnergy { get; set; }
        public Vector4 BodyWater { get; set; }
        public Vector4 IntakeCarbohydrates { get; set; }
        public Vector4 IntakeProtein { get; set; }
        public Vector4 IntakeLipids { get; set; }
        public Vector4 IntakeVitamins { get; set; }
        public Vector4 IntakeMinerals { get; set; }
        public Vector4 BodyMuscles { get; set; }
        public Vector4 BodyFat { get; set; }
        public Vector4 BodyPerformance { get; set; }
        public StatsConstants.DamageEffects CurrentDamageEffects { get; set; }
        public StatsConstants.DiseaseEffects CurrentDiseaseEffects { get; set; }
        public StatsConstants.SurvivalEffects CurrentSurvivalEffects { get; set; }
        public StatsConstants.TemperatureEffects CurrentTemperatureEffects { get; set; }
        public StatsConstants.OtherEffects CurrentOtherEffects { get; set; }
        public WeatherConstants.EnvironmentDetector CurrentEnvironmentType { get; set; }

        public bool ThirstEnabled { get; set; }
        public bool HungerEnabled { get; set; }
        public bool StaminaEnabled { get; set; }
        public bool BodyTemperatureEnabled { get; set; }
        public bool UseMetabolism { get; set; }
        public bool UseNutrition { get; set; }

        public bool NeedToUpdateLocal { get; set; }
        public float O2Level { get; set; }

        public float CurrentCargoMass { get; set; }
        public float CurrentCargoVolume { get; set; }

    }

}