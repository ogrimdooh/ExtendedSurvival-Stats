using VRage;
using VRageMath;

namespace ExtendedSurvival.Stats
{
    public static class PlayerBodyConstants
    {

        public struct BodyStomachComparer
        {

            public float From { get; set; }
            public float To { get; set; }
            public float TargetStomachSize { get; set; }
            public float MinToReturn { get; set; }

        }

        public const float CAL_RESERVER_MIN = 0f;
        public const float CAL_RESERVER_MAX = 2000f;

        public const float CAL_LIMIT_MIN = -5000f;
        public const float CAL_LIMIT_MAX = 5000f;

        public const float STOMACH_SIZE_NOHUNGRY = 0.3f;
        public const float STOMACH_SIZE_SATISFIED = 0.6f;
        public const float STOMACH_SIZE_FEELINGSICK = 0.9f;
        public const float STOMACH_SIZE_VOMITS = 1.2f;

        /// <summary>
        /// X: Start to lose weight, Y: Starts to gain weight
        /// </summary>
        public static readonly SerializableVector2 CaloriesReserveSize = new Vector2(CAL_RESERVER_MIN, CAL_RESERVER_MAX);

        /// <summary>
        /// X: Min, Y: Max
        /// </summary>
        public static readonly SerializableVector2 CaloriesLimit = new Vector2(CAL_LIMIT_MIN, CAL_LIMIT_MAX);

        /// <summary>
        /// X: Sem fome, Y: Satisfeito, Z: Passando mal, W: Vomita
        /// </summary>
        public static readonly Vector4 StomachSize = new Vector4(STOMACH_SIZE_NOHUNGRY, STOMACH_SIZE_SATISFIED, STOMACH_SIZE_FEELINGSICK, STOMACH_SIZE_VOMITS);

        public static readonly BodyStomachComparer[] BodyCalorieStats = new BodyStomachComparer[]
        {
            new BodyStomachComparer()
            {
                From = CAL_LIMIT_MIN,
                To = CAL_RESERVER_MIN,
                TargetStomachSize = STOMACH_SIZE_FEELINGSICK,
                MinToReturn = 0
            },
            new BodyStomachComparer()
            {
                From = CAL_RESERVER_MIN,
                To = 400f,
                TargetStomachSize = STOMACH_SIZE_SATISFIED,
                MinToReturn = 0.15f
            },
            new BodyStomachComparer()
            {
                From = 400f,
                To = 800f,
                TargetStomachSize = STOMACH_SIZE_SATISFIED,
                MinToReturn = 0.3f
            },
            new BodyStomachComparer()
            {
                From = 800f,
                To = 1200f,
                TargetStomachSize = STOMACH_SIZE_SATISFIED,
                MinToReturn = 0.45f
            },
            new BodyStomachComparer()
            {
                From = 1200f,
                To = 1600f,
                TargetStomachSize = STOMACH_SIZE_SATISFIED,
                MinToReturn = 0.6f
            },
            new BodyStomachComparer()
            {
                From = 1600f,
                To = CAL_RESERVER_MAX,
                TargetStomachSize = STOMACH_SIZE_SATISFIED,
                MinToReturn = 0.75f
            },
            new BodyStomachComparer
            {
                From = CAL_RESERVER_MAX,
                To = CAL_LIMIT_MAX + 1,
                TargetStomachSize = STOMACH_SIZE_NOHUNGRY,
                MinToReturn = 0.9f
            }
        };

        public const float WATER_RESERVE_DEAD = 0.0f;
        public const float WATER_RESERVE_DEHYDRATING = 0.5f;
        public const float WATER_RESERVE_THIRSTY = 1.0f;
        public const float WATER_RESERVE_FULL = 2.0f;

        /// <summary>
        /// X: Dead, Y: Dehydrating, Z: Thirsty, W: Full
        /// </summary>
        public static readonly Vector4 WaterReserveSize = new Vector4(WATER_RESERVE_DEAD, WATER_RESERVE_DEHYDRATING, WATER_RESERVE_THIRSTY, WATER_RESERVE_FULL);

        public static readonly BodyStomachComparer[] BodyWaterStats = new BodyStomachComparer[]
        {
            new BodyStomachComparer()
            {
                From = WATER_RESERVE_DEAD,
                To = WATER_RESERVE_DEHYDRATING,
                TargetStomachSize = STOMACH_SIZE_FEELINGSICK,
                MinToReturn = 0
            },
            new BodyStomachComparer()
            {
                From = WATER_RESERVE_DEHYDRATING,
                To = WATER_RESERVE_THIRSTY,
                TargetStomachSize = STOMACH_SIZE_SATISFIED,
                MinToReturn = 0.25f
            },
            new BodyStomachComparer()
            {
                From = WATER_RESERVE_THIRSTY,
                To = WATER_RESERVE_FULL + 1,
                TargetStomachSize = STOMACH_SIZE_NOHUNGRY,
                MinToReturn = 0.5f
            }
        };

        /// <summary>
        /// X: Já pode fazer, Y: Precisa fazer, Z: Passando mal, W: Faz na roupa
        /// </summary>
        public static readonly Vector4 IntestineSize = new Vector4(0.5f, 0.75f, 1.0f, 1.25f);

        /// <summary>
        /// X: Já pode fazer, Y: Precisa fazer, Z: Passando mal, W: Faz na roupa
        /// </summary>
        public static readonly Vector4 BladderSize = new Vector4(0.15f, 0.3f, 0.4f, 0.5f);

        /// <summary>
        /// X: Min, Y: Max
        /// </summary>
        public static readonly SerializableVector2 WeightLimit = new Vector2(40.0f, 200.0f);

        /// <summary>
        /// X: Min, Y: Max
        /// </summary>
        public static readonly SerializableVector2 MuscleLimit = new Vector2(5.0f, 150.0f);

        /// <summary>
        /// X: Min, Y: Max
        /// </summary>
        public static readonly SerializableVector2 FatLimit = new Vector2(5.0f, 150.0f);

        /// <summary>
        /// X: Stopped, Y: Stamina Spended
        /// </summary>
        public static readonly SerializableVector2 CaloriesConsumption = new SerializableVector2(0.1f, 0.5f);

        /// <summary>
        /// X: Stopped, Y: Stamina Spended
        /// </summary>
        public static readonly SerializableVector2 WaterConsumption = new SerializableVector2(0.0005f, 0.001f);

        /// <summary>
        /// X: Stopped, Y: Stamina Spended
        /// </summary>
        public static readonly SerializableVector2 ProteinConsumption = new SerializableVector2(0.05f, 0.1f);

        /// <summary>
        /// X: Stopped, Y: Stamina Spended
        /// </summary>
        public static readonly SerializableVector2 LipidConsumption = new SerializableVector2(0.05f, 0.1f);

        /// <summary>
        /// X: Stopped, Y: Stamina Spended
        /// </summary>
        public static readonly SerializableVector2 CarbohydrateConsumption = new SerializableVector2(0.05f, 0.1f);

        /// <summary>
        /// X: Stopped, Y: Stamina Spended
        /// </summary>
        public static readonly SerializableVector2 VitaminsConsumption = new SerializableVector2(0.005f, 0.01f);

        /// <summary>
        /// X: Stopped, Y: Stamina Spended
        /// </summary>
        public static readonly SerializableVector2 MineralsConsumption = new SerializableVector2(0.005f, 0.01f);
        
        /// <summary>
        /// X: Loss amount, Y: Gain amount
        /// </summary>
        public static readonly SerializableVector2 WeightChange = new Vector2(1f / 1800f, 1f / 1800f);

        /// <summary>
        /// Minimum amount of water that goes to the bladder
        /// </summary>
        public const float WaterToBladder = 0.00025f; /* ~30 minutes to full Bladder */

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
        public const float StartCalories = 1500f;

        /// <summary>
        /// Start ammount of body calories
        /// </summary>
        public const float StartProteins = 250f;

        /// <summary>
        /// Start ammount of body calories
        /// </summary>
        public const float StartCarbohydrates = 200f;

        /// <summary>
        /// Start ammount of body calories
        /// </summary>
        public const float StartLipids = 150f;

        /// <summary>
        /// Start ammount of body calories
        /// </summary>
        public const float StartVitamins = 25f;

        /// <summary>
        /// Start ammount of body calories
        /// </summary>
        public const float StartMinerals = 25f;

    }

}