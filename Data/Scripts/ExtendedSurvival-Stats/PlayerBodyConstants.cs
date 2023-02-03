using VRage;
using VRageMath;

namespace ExtendedSurvival.Stats
{
    public static class PlayerBodyConstants
    {

        /// <summary>
        /// X: Sem fome, Y: Satisfeito, Z: Passando mal, W: Vomita
        /// </summary>
        public static readonly Vector4 StomachSize = new Vector4(0.25f, 0.5f, 0.75f, 1.0f);

        /// <summary>
        /// X: Já pode fazer, Y: Precisa fazer, Z: Passando mal, W: Faz na roupa
        /// </summary>
        public static readonly Vector4 IntestineSize = new Vector4(0.5f, 0.75f, 1.0f, 1.25f);

        /// <summary>
        /// X: Já pode fazer, Y: Precisa fazer, Z: Passando mal, W: Faz na roupa
        /// </summary>
        public static readonly Vector4 BladderSize = new Vector4(0.15f, 0.3f, 0.4f, 0.5f);

        /// <summary>
        /// X: Dead, Y: Dehydrating, Z: Thirsty, W: Full
        /// </summary>
        public static readonly Vector4 WaterReserveSize = new Vector4(0.0f, 0.5f, 1.0f, 2.0f);

        /// <summary>
        /// X: Start to lose weight, Y: Starts to gain weight
        /// </summary>
        public static readonly SerializableVector2 CaloriesReserveSize = new Vector2(0.0f, 1000.0f);

        /// <summary>
        /// X: Min, Y: Max
        /// </summary>
        public static readonly SerializableVector2 CaloriesLimit = new Vector2(-5000.0f, 5000.0f);

        /// <summary>
        /// X: Stopped, Y: Stamina Spended
        /// </summary>
        public static readonly SerializableVector2 CaloriesConsumption = new SerializableVector2(0.1f, 0.25f);

        /// <summary>
        /// X: Stopped, Y: Stamina Spended
        /// </summary>
        public static readonly SerializableVector2 WaterConsumption = new SerializableVector2(0.00005f, 0.0001f);

        /// <summary>
        /// X: Loss amount, Y: Gain amount
        /// </summary>
        public static readonly SerializableVector2 WeightChange = new Vector2(1f / 1800f, 1f / 1800f);

        /// <summary>
        /// Minimum amount of water that goes to the bladder
        /// </summary>
        public const float WaterToBladder = 0.0005f;

        /// <summary>
        /// Start ammount of body water
        /// </summary>
        public const float StartWaterReserve = 1.75f;

        /// <summary>
        ///  ammount of body water
        /// </summary>
        public const float ReviveWaterReserve = 0.5f;

        /// <summary>
        /// Start body weight
        /// </summary>
        public const float StartWeight = 80f;

        /// <summary>
        /// Start body Muscle
        /// </summary>
        public const float StartMuscle = 0.35f;

        /// <summary>
        /// Start body Fat
        /// </summary>
        public const float StartFat = 0.25f;

        /// <summary>
        /// Start body Performance
        /// </summary>
        public const float StartPerformance = 0.75f;

        /// <summary>
        /// Start body Imunity
        /// </summary>
        public const float StartImunity = 0.5f;

        /// <summary>
        /// Start ammount of body calories
        /// </summary>
        public const float StartCalories = 1000f;

    }

}