using VRageMath;

namespace ExtendedSurvival.Stats
{

    public class PlayerData
    {

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

    }

}