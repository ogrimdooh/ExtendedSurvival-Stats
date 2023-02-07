using VRageMath;

namespace ExtendedSurvival.Stats
{

    public static class HungerConstants
    {

        public static readonly string BOWL_KEY = "Bowl";

        public static readonly string FLASK_KEY = "Flask";
        public static readonly string FLASK_KEY_SMALL = "Small";
        public static readonly string FLASK_KEY_MEDIUM = "Medium";
        public static readonly string FLASK_KEY_BIG = "Big";

        public const float MIN_HUNGER_AT_START = 0.1f;
        public const float MIN_THIRST_AT_START = 0.1f;
        public const float MIN_STAMINA_AT_START = 0.25f;

        public const float MIN_BODYENERGY_AT_START = 0.1f;
        public const float MIN_BODYWATER_AT_START = 0.1f;

        public static readonly float BASE_HUNGER_FACTOR = 0.05f;
        public static readonly float BASE_THIRST_FACTOR = 0.05f;
        public static readonly float BASE_DAMAGE_FACTOR = 1.0f;
        public static readonly float BASE_HUNGER_DAMAGE_FACTOR = 1.0f;
        public static readonly float BASE_THIRST_DAMAGE_FACTOR = 1.0f;

        public static readonly float MOVE_INC_HUNGER_FACTOR = 0.02f;
        public static readonly float MIVE_INC_THIRST_FACTOR = 0.02f;

        public static readonly Vector2 TEMPERATURE_HUNGER_FACTOR = new Vector2(1.25f, 1.5f);
        public static readonly Vector2 TEMPERATURE_THIRST_FACTOR = new Vector2(1.25f, 1.5f);

        public static readonly float RAIN_INC_THIRST_FACTOR = 0.02f;
        public static readonly float THUNDER_INC_THIRST_FACTOR = 0.02f;

        public static readonly Vector2 RAIN_THIRST_FACTOR = new Vector2(1.25f, 1.5f);
        public static readonly Vector2 THUNDER_THIRST_FACTOR = new Vector2(1.25f, 1.5f);

        public static readonly float HUNGER_HARD_TEMPERATURE_RANGE = 0f;
        public static readonly float HUNGER_TEMPERATURE_RANGE = 10f;

        public static readonly float THIRST_HARD_TEMPERATURE_RANGE = 55f;
        public static readonly float THIRST_TEMPERATURE_RANGE = 35f;

    }

}