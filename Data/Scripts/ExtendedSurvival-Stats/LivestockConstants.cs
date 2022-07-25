using System.Collections.Generic;
using System.Linq;
using VRageMath;

namespace ExtendedSurvival
{

    public static class LivestockConstants
    {

        public enum AnimalGender
        {

            Baby = 0,
            Male = 1,
            Female = 2

        }

        public const string ANIMAL_CATEGORY = "ANIMALS";

        public const string PIG_ID = "Pig_Bot";
        public const string CHICKEN_ID = "Chicken_Bot";

        public const string COW_ID = "Cow_Bot";
        public const string DEER_ID = "deer_bot";
        public const string DEER_ID_2 = "deerbuck_bot";
        public const string SHEEP_ID = "Sheep_Bot";
        public const string HORSE_ID = "Horse_Bot";
        public const string WOLF_ID = "Space_Wolf";
        public const string SPIDER_ID = "Space_spider";
        public const string SPIDER_ID_2 = "Space_spider_black";
        public const string SPIDER_ID_3 = "Space_spider_brown";
        public const string SPIDER_ID_4 = "Space_spider_green";

        public const string CREATURE_HEALTH = "CreatureHealth";
        public const string TREE_HEALTH = "TreeHealth";

        public const string CREATURE_EAT_FACTOR_ID = "EatFactor";
        public const string CREATURE_ABSORCION_FACTOR_ID = "AbsorcionFactor";
        public const string CREATURE_POOP_FACTOR_ID = "PoopFactor";

        public const string BASE_EAT_FACTOR = "0.005";
        public const string BASE_POOP_FACTOR = "0.01";
        public const string BASE_ABSORCION_FACTOR = "0.01";
        public const float BASE_HUNGRY_FACTOR = 0.0025f;

        public const long FEED_TIME_CICLE = 5000;
        public const long REPRODUCTION_TIME_CICLE = 900000; // 15 minutes

        public struct AnimalInfo
        {

            public string botId;
            public Dictionary<AnimalGender, UniqueEntityId> genderIds;
            public int genderFormula;
            public float startItemHealth;
            public CustomProduction[] customProductions;

        }

        public struct CustomProduction
        {

            public AnimalGender gender;

            public UniqueEntityId product;
            public Vector2 baseFactor;
            public bool allowDecimal;
            public Vector2I chanceToGenerate;

            public bool hasRequiredProduct;
            public UniqueEntityId requiredProduct;
            public float requiredAmmount;

        }

        private static AnimalInfo BASE_PIG_INFO = new AnimalInfo()
        {
            botId = PIG_ID,
            genderIds = new Dictionary<AnimalGender, UniqueEntityId>()
            {
                { AnimalGender.Baby, ItensConstants.PIGBABY_ID },
                { AnimalGender.Male, ItensConstants.PIGMALE_ID },
                { AnimalGender.Female, ItensConstants.PIGFEMALE_ID }
            },
            genderFormula = 50,
            startItemHealth = 0.6f
        };

        private static AnimalInfo BASE_CHICKEN_INFO = new AnimalInfo()
        {
            botId = CHICKEN_ID,
            genderIds = new Dictionary<AnimalGender, UniqueEntityId>()
            {
                { AnimalGender.Baby, ItensConstants.CHICKENBABY_ID },
                { AnimalGender.Male, ItensConstants.CHICKENMALE_ID },
                { AnimalGender.Female, ItensConstants.CHICKENFEMALE_ID }
            },
            genderFormula = 50,
            startItemHealth = 0.6f,
            customProductions = new CustomProduction[]
            {
                new CustomProduction()
                {
                    gender = AnimalGender.Female,
                    chanceToGenerate = new Vector2I(10, 1000),
                    baseFactor = new Vector2(1, 1),
                    product = ItensConstants.EGG_ID
                }
            }
        };

        private static AnimalInfo BASE_COW_INFO = new AnimalInfo()
        {
            botId = COW_ID,
            genderIds = new Dictionary<AnimalGender, UniqueEntityId>()
            {
                { AnimalGender.Baby, ItensConstants.COWBABY_ID },
                { AnimalGender.Male, ItensConstants.COWMALE_ID },
                { AnimalGender.Female, ItensConstants.COWFEMALE_ID }
            },
            genderFormula = 50,
            startItemHealth = 0.6f,
            customProductions = new CustomProduction[] 
            { 
                new CustomProduction()
                {
                    gender = AnimalGender.Female,
                    chanceToGenerate = new Vector2I(10, 1000),
                    baseFactor = new Vector2(1, 1),
                    product = ItensConstants.MILK_ID,
                    hasRequiredProduct = true,
                    requiredAmmount = 1,
                    requiredProduct = ItensConstants.FLASK_BIG_ID
                }
            }
        };

        private static AnimalInfo BASE_DEER_INFO = new AnimalInfo()
        {
            botId = DEER_ID,
            genderIds = new Dictionary<AnimalGender, UniqueEntityId>()
            {
                { AnimalGender.Baby, ItensConstants.DEERBABY_ID },
                { AnimalGender.Male, ItensConstants.DEERMALE_ID },
                { AnimalGender.Female, ItensConstants.DEERFEMALE_ID }
            },
            genderFormula = 50,
            startItemHealth = 0.6f
        };

        private static AnimalInfo BASE_SHEEP_INFO = new AnimalInfo()
        {
            botId = SHEEP_ID,
            genderIds = new Dictionary<AnimalGender, UniqueEntityId>()
            {
                { AnimalGender.Baby, ItensConstants.SHEEPBABY_ID },
                { AnimalGender.Male, ItensConstants.SHEEPMALE_ID },
                { AnimalGender.Female, ItensConstants.SHEEPFEMALE_ID }
            },
            genderFormula = 50,
            startItemHealth = 0.6f
        };

        private static AnimalInfo BASE_HORSE_INFO = new AnimalInfo()
        {
            botId = HORSE_ID,
            genderIds = new Dictionary<AnimalGender, UniqueEntityId>()
            {
                { AnimalGender.Baby, ItensConstants.HORSEBABY_ID },
                { AnimalGender.Male, ItensConstants.HORSEMALE_ID },
                { AnimalGender.Female, ItensConstants.HORSEFEMALE_ID }
            },
            genderFormula = 50,
            startItemHealth = 0.6f
        };

        private static AnimalInfo BASE_WOLF_INFO = new AnimalInfo()
        {
            botId = WOLF_ID,
            genderIds = new Dictionary<AnimalGender, UniqueEntityId>()
            {
                { AnimalGender.Baby, ItensConstants.WOLFBABY_ID },
                { AnimalGender.Male, ItensConstants.WOLFMALE_ID },
                { AnimalGender.Female, ItensConstants.WOLFFEMALE_ID }
            },
            genderFormula = 50,
            startItemHealth = 0.6f
        };

        private static AnimalInfo BASE_SPIDER_INFO = new AnimalInfo()
        {
            botId = SPIDER_ID,
            genderIds = new Dictionary<AnimalGender, UniqueEntityId>()
            {
                { AnimalGender.Baby, ItensConstants.SPIDERBABY_ID },
                { AnimalGender.Male, ItensConstants.SPIDERMALE_ID },
                { AnimalGender.Female, ItensConstants.SPIDERFEMALE_ID }
            },
            genderFormula = 50,
            startItemHealth = 0.6f,
            customProductions = new CustomProduction[] 
            { 
                new CustomProduction()
                {
                    gender = AnimalGender.Female,
                    chanceToGenerate = new Vector2I(10, 1000),
                    baseFactor = new Vector2(1, 1),
                    product = ItensConstants.ALIEN_EGG_ID
                }
            }
        };

        public static readonly Dictionary<string, AnimalInfo> ANIMALS = new Dictionary<string, AnimalInfo>()
        {
            { WOLF_ID, BASE_WOLF_INFO },
            { SPIDER_ID, BASE_SPIDER_INFO },
            { SPIDER_ID_2, BASE_SPIDER_INFO },
            { SPIDER_ID_3, BASE_SPIDER_INFO },
            { SPIDER_ID_4, BASE_SPIDER_INFO },
            { HORSE_ID, BASE_HORSE_INFO },
            { SHEEP_ID, BASE_SHEEP_INFO },
            { DEER_ID, BASE_DEER_INFO },
            { DEER_ID_2, BASE_DEER_INFO },            
            { COW_ID, BASE_COW_INFO },
            { PIG_ID, BASE_PIG_INFO },
            { CHICKEN_ID, BASE_CHICKEN_INFO }
        };

        public static AnimalInfo? GetAnimalInfo(UniqueEntityId itemId)
        {
            if (ANIMALS.Values.Any(x => x.genderIds.Any(y => y.Value == itemId)))
                return ANIMALS.Values.FirstOrDefault(x => x.genderIds.Any(y => y.Value == itemId));
            return null;
        }

    }

}