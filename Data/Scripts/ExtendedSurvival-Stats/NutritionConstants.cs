using Sandbox.Definitions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRage.Game;

namespace ExtendedSurvival
{

    public static class NutritionConstants
    {

        public const float BASE_TIME = 5;

        public enum PreparationType
        {

            Cutting = 0,
            Cooking = 1,
            Frying = 2,
            Baking = 3,
            Mixing = 4,
            Processing = 5,
            Drying = 6

        }

        public struct FoodNutrition
        {

            public static FoodNutrition Increment(FoodNutrition source, FoodNutrition other)
            {
                var r = new FoodNutrition();
                r.Assign(source);
                r.Increment(other);
                return r;
            }

            public static FoodNutrition Decrement(FoodNutrition source, FoodNutrition other)
            {
                var r = new FoodNutrition();
                r.Assign(source);
                r.Decrement(other);
                return r;
            }

            public static FoodNutrition Multiply(FoodNutrition source, float multiplier)
            {
                var r = new FoodNutrition();
                r.Assign(source);
                r.Multiply(multiplier);
                return r;
            }

            public static FoodNutrition Divide(FoodNutrition source, float multiplier)
            {
                var r = new FoodNutrition();
                r.Assign(source);
                r.Divide(multiplier);
                return r;
            }

            public bool Consumable { get; set; }
            public float Health { get; set; }
            public float Hunger { get; set; }
            public float Thirst { get; set; }
            public float Stamina { get; set; }
            public float IntakeBodyFood { get; set; }
            public float IntakeBodyWater { get; set; }
            public float IntakeCarbohydrates { get; set; }
            public float IntakeProtein { get; set; }
            public float IntakeLipids { get; set; }
            public float IntakeVitamins { get; set; }
            public float IntakeMinerals { get; set; }
            public float TemperatureTime { get; set; }

            private void NoNegativeHealth()
            {
                if (Health < 0)
                    Health *= -0.25f;
            }

            private void NoNegativeTemperature()
            {
                if (TemperatureTime < 0)
                    TemperatureTime *= -1f;
            }

            private void ChangeLipids(float multiplier)
            {
                IntakeLipids *= multiplier;
            }

            private void ChangeWater(float multiplier)
            {
                IntakeBodyWater *= multiplier;
                TemperatureTime *= multiplier;
                if (Thirst > 0)
                    Thirst *= multiplier;
            }

            public void ApplyPreparation(PreparationType preparation)
            {
                switch (preparation)
                {
                    case PreparationType.Cooking:
                        NoNegativeHealth();
                        NoNegativeTemperature();
                        ChangeLipids(0.9f);
                        ChangeWater(0.75f);
                        break;
                    case PreparationType.Frying:
                        NoNegativeHealth();
                        NoNegativeTemperature();
                        ChangeLipids(1.25f);
                        ChangeWater(0.25f);
                        break;
                    case PreparationType.Baking:
                        NoNegativeHealth();
                        NoNegativeTemperature();
                        ChangeLipids(0.8f);
                        ChangeWater(0.5f);
                        break;
                    case PreparationType.Drying:
                        NoNegativeHealth();
                        ChangeWater(0.1f);
                        break;
                }
            }

            public void Assign(FoodNutrition other)
            {
                Consumable = other.Consumable;
                Health = other.Health;
                Hunger = other.Hunger;
                Thirst = other.Thirst;
                Stamina = other.Stamina;
                IntakeBodyFood = other.IntakeBodyFood;
                IntakeBodyWater = other.IntakeBodyWater;
                IntakeCarbohydrates = other.IntakeCarbohydrates;
                IntakeProtein = other.IntakeProtein;
                IntakeLipids = other.IntakeLipids;
                IntakeVitamins = other.IntakeVitamins;
                IntakeMinerals = other.IntakeMinerals;
                TemperatureTime = other.TemperatureTime;
            }

            public void Increment(FoodNutrition other)
            {
                Health += other.Health;
                Hunger += other.Hunger;
                Thirst += other.Thirst;
                Stamina += other.Stamina;
                IntakeBodyFood += other.IntakeBodyFood;
                IntakeBodyWater += other.IntakeBodyWater;
                IntakeCarbohydrates += other.IntakeCarbohydrates;
                IntakeProtein += other.IntakeProtein;
                IntakeLipids += other.IntakeLipids;
                IntakeVitamins += other.IntakeVitamins;
                IntakeMinerals += other.IntakeMinerals;
                TemperatureTime += other.TemperatureTime;
            }

            public void Decrement(FoodNutrition other)
            {
                Health -= other.Health;
                Hunger -= other.Hunger;
                Thirst -= other.Thirst;
                Stamina -= other.Stamina;
                IntakeBodyFood -= other.IntakeBodyFood;
                IntakeBodyWater -= other.IntakeBodyWater;
                IntakeCarbohydrates -= other.IntakeCarbohydrates;
                IntakeProtein -= other.IntakeProtein;
                IntakeLipids -= other.IntakeLipids;
                IntakeVitamins -= other.IntakeVitamins;
                IntakeMinerals -= other.IntakeMinerals;
                TemperatureTime -= other.TemperatureTime;
            }

            public void Multiply(float multiplier)
            {
                Health *= multiplier;
                Hunger *= multiplier;
                Thirst *= multiplier;
                Stamina *= multiplier;
                IntakeBodyFood *= multiplier;
                IntakeBodyWater *= multiplier;
                IntakeCarbohydrates *= multiplier;
                IntakeProtein *= multiplier;
                IntakeLipids *= multiplier;
                IntakeVitamins *= multiplier;
                IntakeMinerals *= multiplier;
                TemperatureTime *= multiplier;
            }

            public void Divide(float multiplier)
            {
                Health /= multiplier;
                Hunger /= multiplier;
                Thirst /= multiplier;
                Stamina /= multiplier;
                IntakeBodyFood /= multiplier;
                IntakeBodyWater /= multiplier;
                IntakeCarbohydrates /= multiplier;
                IntakeProtein /= multiplier;
                IntakeLipids /= multiplier;
                IntakeVitamins /= multiplier;
                IntakeMinerals /= multiplier;
                TemperatureTime /= multiplier;
            }

            public void LoadValue(List<MyConsumableItemDefinition.StatValue> stats)
            {
                if (Health != 0)
                    stats.Add(new MyConsumableItemDefinition.StatValue(nameof(Health), Health, BASE_TIME));
                if (Hunger != 0)
                    stats.Add(new MyConsumableItemDefinition.StatValue(nameof(Hunger), Hunger, BASE_TIME));
                if (Thirst != 0)
                    stats.Add(new MyConsumableItemDefinition.StatValue(nameof(Thirst), Thirst, BASE_TIME));
                if (Stamina != 0)
                    stats.Add(new MyConsumableItemDefinition.StatValue(nameof(Stamina), Stamina, BASE_TIME));
                if (IntakeBodyFood != 0)
                    stats.Add(new MyConsumableItemDefinition.StatValue(nameof(IntakeBodyFood), IntakeBodyFood, BASE_TIME));
                if (IntakeBodyWater != 0)
                    stats.Add(new MyConsumableItemDefinition.StatValue(nameof(IntakeBodyWater), IntakeBodyWater, BASE_TIME));
                if (IntakeCarbohydrates != 0)
                    stats.Add(new MyConsumableItemDefinition.StatValue(nameof(IntakeCarbohydrates), IntakeCarbohydrates, BASE_TIME));
                if (IntakeProtein != 0)
                    stats.Add(new MyConsumableItemDefinition.StatValue(nameof(IntakeProtein), IntakeProtein, BASE_TIME));
                if (IntakeLipids != 0)
                    stats.Add(new MyConsumableItemDefinition.StatValue(nameof(IntakeLipids), IntakeLipids, BASE_TIME));
                if (IntakeVitamins != 0)
                    stats.Add(new MyConsumableItemDefinition.StatValue(nameof(IntakeVitamins), IntakeVitamins, BASE_TIME));
                if (IntakeMinerals != 0)
                    stats.Add(new MyConsumableItemDefinition.StatValue(nameof(IntakeMinerals), IntakeMinerals, BASE_TIME));
                if (TemperatureTime != 0)
                    stats.Add(new MyConsumableItemDefinition.StatValue(nameof(TemperatureTime), TemperatureTime, BASE_TIME));
            }

            public override string ToString()
            {
                var sb = new StringBuilder();
                if (Health != 0)
                    sb.AppendFormat("{0}={1} ", nameof(Health), Health);
                if (Hunger != 0)
                    sb.AppendFormat("{0}={1} ", nameof(Hunger), Hunger);
                if (Thirst != 0)
                    sb.AppendFormat("{0}={1} ", nameof(Thirst), Thirst);
                if (Stamina != 0)
                    sb.AppendFormat("{0}={1} ", nameof(Stamina), Stamina);
                if (IntakeBodyFood != 0)
                    sb.AppendFormat("{0}={1} ", nameof(IntakeBodyFood), IntakeBodyFood);
                if (IntakeBodyWater != 0)
                    sb.AppendFormat("{0}={1} ", nameof(IntakeBodyWater), IntakeBodyWater);
                if (IntakeCarbohydrates != 0)
                    sb.AppendFormat("{0}={1} ", nameof(IntakeCarbohydrates), IntakeCarbohydrates);
                if (IntakeProtein != 0)
                    sb.AppendFormat("{0}={1} ", nameof(IntakeProtein), IntakeProtein);
                if (IntakeLipids != 0)
                    sb.AppendFormat("{0}={1} ", nameof(IntakeLipids), IntakeLipids);
                if (IntakeVitamins != 0)
                    sb.AppendFormat("{0}={1} ", nameof(IntakeVitamins), IntakeVitamins);
                if (IntakeMinerals != 0)
                    sb.AppendFormat("{0}={1} ", nameof(IntakeMinerals), IntakeMinerals);
                if (TemperatureTime != 0)
                    sb.AppendFormat("{0}={1} ", nameof(TemperatureTime), TemperatureTime);
                return sb.ToString();
            }

            public static FoodNutrition operator +(FoodNutrition l, FoodNutrition r)
            {
                return Increment(l, r);
            }

            public static FoodNutrition operator -(FoodNutrition l, FoodNutrition r)
            {
                return Decrement(l, r);
            }

            public static FoodNutrition operator *(FoodNutrition l, float r)
            {
                return Multiply(l, r);
            }

            public static FoodNutrition operator /(FoodNutrition l, float r)
            {
                return Divide(l, r);
            }

        }

        public struct FoodPreparation
        {

            public string RecipeName { get; set; }
            public PreparationType Preparation { get; set; }
            public string[] OtherRecipes { get; set; }

        }

        private static readonly FoodNutrition BASE_CONCENTRATED_FAT_NUTRITION = new FoodNutrition()
        {
            Consumable = false,
            Health = 0,
            Hunger = 0,
            Thirst = -0.05f,
            Stamina = 0,
            IntakeBodyFood = 0.025f,
            IntakeBodyWater = 0,
            IntakeCarbohydrates = 0,
            IntakeProtein = 0,
            IntakeLipids = 0.2f,
            IntakeVitamins = 0,
            IntakeMinerals = 0,
            TemperatureTime = 0
        };

        private static readonly FoodNutrition BASE_CONCENTRATED_PROTEIN_NUTRITION = new FoodNutrition()
        {
            Consumable = false,
            Health = 0,
            Hunger = 0,
            Thirst = -0.05f,
            Stamina = 0,
            IntakeBodyFood = 0.025f,
            IntakeBodyWater = 0,
            IntakeCarbohydrates = 0,
            IntakeProtein = 0.2f,
            IntakeLipids = 0,
            IntakeVitamins = 0,
            IntakeMinerals = 0,
            TemperatureTime = 0
        };

        private static readonly FoodNutrition BASE_CONCENTRATED_VITAMIN_NUTRITION = new FoodNutrition()
        {
            Consumable = false,
            Health = 0,
            Hunger = 0,
            Thirst = 0,
            Stamina = 0,
            IntakeBodyFood = 0,
            IntakeBodyWater = 0,
            IntakeCarbohydrates = 0,
            IntakeProtein = 0,
            IntakeLipids = 0,
            IntakeVitamins = 0.2f,
            IntakeMinerals = 0,
            TemperatureTime = 0
        };

        private static readonly FoodNutrition BASE_MILK_NUTRITION = new FoodNutrition()
        {
            Consumable = true,
            Health = 0,
            Hunger = 0,
            Thirst = 0.02f,
            Stamina = 0.005f,
            IntakeBodyFood = 0,
            IntakeBodyWater = 0.05f,
            IntakeCarbohydrates = 0.0125f,
            IntakeProtein = 0.00125f,
            IntakeLipids = 0.0025f,
            IntakeVitamins = 0.05f,
            IntakeMinerals = 0.01f,
            TemperatureTime = -0.05f
        };

        private static readonly FoodNutrition BASE_ICE_NUTRITION = new FoodNutrition()
        {
            Consumable = false,
            Health = 0,
            Hunger = 0,
            Thirst = 0.005f,
            Stamina = 0.00125f,
            IntakeBodyFood = 0,
            IntakeBodyWater = 0.0025f,
            IntakeCarbohydrates = 0,
            IntakeProtein = 0,
            IntakeLipids = 0,
            IntakeVitamins = 0,
            IntakeMinerals = 0.0002f,
            TemperatureTime = -0.005f
        };

        private static readonly FoodNutrition BASE_CEREAL_NUTRITION = new FoodNutrition()
        {
            Consumable = false,
            Health = 0.005f,
            Hunger = 0.025f,
            Thirst = -0.005f,
            Stamina = 0,
            IntakeBodyFood = 0.0125f,
            IntakeBodyWater = 0,
            IntakeCarbohydrates = 0.0075f,
            IntakeProtein = 0.001f,
            IntakeLipids = 0.001f,
            IntakeVitamins = 0,
            IntakeMinerals = 0,
            TemperatureTime = 0
        };

        private static readonly FoodNutrition BASE_WHEAT_NUTRITION = new FoodNutrition()
        {
            Consumable = false,
            Health = 0.01f,
            Hunger = 0.025f,
            Thirst = -0.005f,
            Stamina = 0,
            IntakeBodyFood = 0.0125f,
            IntakeBodyWater = 0,
            IntakeCarbohydrates = 0.01f,
            IntakeProtein = 0.001f,
            IntakeLipids = 0.005f,
            IntakeVitamins = 0,
            IntakeMinerals = 0,
            TemperatureTime = 0
        };

        private static readonly FoodNutrition BASE_COFFEE_NUTRITION = new FoodNutrition()
        {
            Consumable = false,
            Health = 0,
            Hunger = 0,
            Thirst = 0,
            Stamina = 0.075f,
            IntakeBodyFood = 0,
            IntakeBodyWater = 0,
            IntakeCarbohydrates = 0,
            IntakeProtein = 0,
            IntakeLipids = 0,
            IntakeVitamins = 0,
            IntakeMinerals = 0.001f,
            TemperatureTime = 0.075f
        };

        private static readonly FoodNutrition BASE_VEGETABLE_NUTRITION = new FoodNutrition()
        {
            Consumable = true,
            Health = 0.005f,
            Hunger = 0.01f,
            Thirst = 0.005f,
            Stamina = 0,
            IntakeBodyFood = 0.005f,
            IntakeBodyWater = 0.0025f,
            IntakeCarbohydrates = 0.005f,
            IntakeProtein = 0.001f,
            IntakeLipids = 0,
            IntakeVitamins = 0.001f,
            IntakeMinerals = 0,
            TemperatureTime = 0
        };

        private static readonly FoodNutrition BASE_MUSHROOM_NUTRITION = new FoodNutrition()
        {
            Consumable = true,
            Health = 0.001f,
            Hunger = 0.005f,
            Thirst = 0.001f,
            Stamina = 0,
            IntakeBodyFood = 0.0025f,
            IntakeBodyWater = 0.0005f,
            IntakeCarbohydrates = 0.0025f,
            IntakeProtein = 0.0005f,
            IntakeLipids = 0,
            IntakeVitamins = 0.0005f,
            IntakeMinerals = 0,
            TemperatureTime = 0
        };

        private static readonly FoodNutrition BASE_FRUIT_NUTRITION = new FoodNutrition()
        {
            Consumable = true,
            Health = 0.005f,
            Hunger = 0.015f,
            Thirst = 0.005f,
            Stamina = 0.0025f,
            IntakeBodyFood = 0.0075f,
            IntakeBodyWater = 0.0025f,
            IntakeCarbohydrates = 0.0025f,
            IntakeProtein = 0,
            IntakeLipids = 0,
            IntakeVitamins = 0.005f,
            IntakeMinerals = 0.001f,
            TemperatureTime = 0
        };

        private static readonly FoodNutrition BASE_MEAT_NUTRITION = new FoodNutrition()
        {
            Consumable = true,
            Health = -0.04f,
            Hunger = 0.0125f,
            Thirst = -0.0125f,
            Stamina = 0f,
            IntakeBodyFood = 0.0125f,
            IntakeBodyWater = 0,
            IntakeCarbohydrates = 0,
            IntakeProtein = 0.005f,
            IntakeLipids = 0.0025f,
            IntakeVitamins = 0,
            IntakeMinerals = 0.001f,
            TemperatureTime = 0
        };

        private static readonly FoodNutrition BASE_CHICKEN_MEAT_NUTRITION = new FoodNutrition()
        {
            Consumable = true,
            Health = -0.08f,
            Hunger = 0.05f,
            Thirst = -0.05f,
            Stamina = 0f,
            IntakeBodyFood = 0.05f,
            IntakeBodyWater = 0,
            IntakeCarbohydrates = 0,
            IntakeProtein = 0.025f,
            IntakeLipids = 0.01f,
            IntakeVitamins = 0,
            IntakeMinerals = 0.005f,
            TemperatureTime = 0
        };

        private static readonly FoodNutrition BASE_BACON_NUTRITION = new FoodNutrition()
        {
            Consumable = true,
            Health = -0.04f,
            Hunger = 0.025f,
            Thirst = -0.025f,
            Stamina = 0f,
            IntakeBodyFood = 0.0175f,
            IntakeBodyWater = 0,
            IntakeCarbohydrates = 0,
            IntakeProtein = 0.0075f,
            IntakeLipids = 0.005f,
            IntakeVitamins = 0,
            IntakeMinerals = 0.002f,
            TemperatureTime = 0
        };

        private static readonly FoodNutrition BASE_NOBLE_MEAT_NUTRITION = new FoodNutrition()
        {
            Consumable = true,
            Health = -0.04f,
            Hunger = 0.025f,
            Thirst = -0.025f,
            Stamina = 0f,
            IntakeBodyFood = 0.0175f,
            IntakeBodyWater = 0,
            IntakeCarbohydrates = 0,
            IntakeProtein = 0.0075f,
            IntakeLipids = 0.005f,
            IntakeVitamins = 0,
            IntakeMinerals = 0.002f,
            TemperatureTime = 0
        };

        private static readonly FoodNutrition BASE_EGG_NUTRITION = new FoodNutrition()
        {
            Consumable = true,
            Health = -0.02f,
            Hunger = 0.007f,
            Thirst = -0.007f,
            Stamina = 0f,
            IntakeBodyFood = 0.0075f,
            IntakeBodyWater = 0.0025f,
            IntakeCarbohydrates = 0,
            IntakeProtein = 0.0025f,
            IntakeLipids = 0.00125f,
            IntakeVitamins = 0,
            IntakeMinerals = 0.0005f,
            TemperatureTime = 0
        };

        private static readonly FoodNutrition BASE_SHRIMP_MEAT_NUTRITION = new FoodNutrition()
        {
            Consumable = true,
            Health = -0.02f,
            Hunger = 0.007f,
            Thirst = -0.007f,
            Stamina = 0f,
            IntakeBodyFood = 0.0075f,
            IntakeBodyWater = 0,
            IntakeCarbohydrates = 0,
            IntakeProtein = 0.0025f,
            IntakeLipids = 0.00125f,
            IntakeVitamins = 0,
            IntakeMinerals = 0.0005f,
            TemperatureTime = 0
        };

        private static readonly FoodNutrition BASE_FISH_MEAT_NUTRITION = new FoodNutrition()
        {
            Consumable = true,
            Health = -0.04f,
            Hunger = 0.0125f,
            Thirst = -0.0125f,
            Stamina = 0f,
            IntakeBodyFood = 0.0125f,
            IntakeBodyWater = 0,
            IntakeCarbohydrates = 0,
            IntakeProtein = 0.005f,
            IntakeLipids = 0.0025f,
            IntakeVitamins = 0,
            IntakeMinerals = 0.001f,
            TemperatureTime = 0
        };

        private static readonly FoodNutrition BASE_NOBLE_FISH_MEAT_NUTRITION = new FoodNutrition()
        {
            Consumable = true,
            Health = -0.04f,
            Hunger = 0.025f,
            Thirst = -0.025f,
            Stamina = 0f,
            IntakeBodyFood = 0.0175f,
            IntakeBodyWater = 0,
            IntakeCarbohydrates = 0,
            IntakeProtein = 0.0075f,
            IntakeLipids = 0.005f,
            IntakeVitamins = 0,
            IntakeMinerals = 0.002f,
            TemperatureTime = 0
        };

        public static readonly List<UniqueEntityId> RECIPIENTS = new List<UniqueEntityId>()
        {
            ItensConstants.BOWL_ID,
            ItensConstants.FLASK_SMALL_ID,
            ItensConstants.FLASK_MEDIUM_ID,
            ItensConstants.FLASK_BIG_ID,
            ItensConstants.ALUMINUMCAN_ID
        };

        public static readonly Dictionary<UniqueEntityId, FoodNutrition> FOOD_INGREDIENTS = new Dictionary<UniqueEntityId, FoodNutrition>()
        {
            { ItensConstants.BROCCOLI_ID, BASE_VEGETABLE_NUTRITION },
            { ItensConstants.BEETROOT_ID, BASE_VEGETABLE_NUTRITION },
            { ItensConstants.CAROOT_ID, BASE_VEGETABLE_NUTRITION },
            { ItensConstants.SHIITAKE_ID, BASE_MUSHROOM_NUTRITION },
            { ItensConstants.CHAMPIGNONS_ID, BASE_MUSHROOM_NUTRITION },
            { ItensConstants.APPLE_ID, BASE_FRUIT_NUTRITION },
            { ItensConstants.TOMATO_ID, BASE_FRUIT_NUTRITION },
            { ItensConstants.CEREAL_ID, BASE_CEREAL_NUTRITION },
            { ItensConstants.WHEAT_ID, BASE_WHEAT_NUTRITION },
            { ItensConstants.ICE_ID, BASE_ICE_NUTRITION },
            { ItensConstants.MILK_ID, BASE_MILK_NUTRITION },
            { ItensConstants.MEAT_ID, BASE_MEAT_NUTRITION },
            { ItensConstants.ALIEN_MEAT_ID, BASE_MEAT_NUTRITION },
            { ItensConstants.CHICKENMEAT_ID, BASE_CHICKEN_MEAT_NUTRITION },
            { ItensConstants.BACON_ID, BASE_BACON_NUTRITION },
            { ItensConstants.NOBLE_MEAT_ID, BASE_NOBLE_MEAT_NUTRITION },
            { ItensConstants.ALIEN_NOBLE_MEAT_ID, BASE_NOBLE_MEAT_NUTRITION },
            { ItensConstants.EGG_ID, BASE_EGG_NUTRITION },
            { ItensConstants.ALIEN_EGG_ID, BASE_EGG_NUTRITION },
            { ItensConstants.COFFEE_ID, BASE_COFFEE_NUTRITION },
            { ItensConstants.SHRIMPMEAT_ID, BASE_SHRIMP_MEAT_NUTRITION },
            { ItensConstants.FISHMEAT_ID, BASE_FISH_MEAT_NUTRITION },
            { ItensConstants.NOBLEFISHMEAT_ID, BASE_NOBLE_FISH_MEAT_NUTRITION },
            { ItensConstants.CONCENTRATEDFAT_ID, BASE_CONCENTRATED_FAT_NUTRITION },
            { ItensConstants.CONCENTRATEDPROTEIN_ID, BASE_CONCENTRATED_PROTEIN_NUTRITION },
            { ItensConstants.CONCENTRATEDVITAMIN_ID, BASE_CONCENTRATED_VITAMIN_NUTRITION }
        };

        public static readonly Dictionary<UniqueEntityId, UniqueEntityId> FOOD_RECIPIENTS = new Dictionary<UniqueEntityId, UniqueEntityId>()
        {
            { ItensConstants.MILK_ID, ItensConstants.FLASK_BIG_ID },
            { ItensConstants.WATER_FLASK_SMALL_ID, ItensConstants.FLASK_SMALL_ID },
            { ItensConstants.WATER_FLASK_MEDIUM_ID, ItensConstants.FLASK_MEDIUM_ID },
            { ItensConstants.WATER_FLASK_BIG_ID, ItensConstants.FLASK_BIG_ID },
            { ItensConstants.APPLE_JUICE_ID, ItensConstants.FLASK_BIG_ID },
            { ItensConstants.SODA_ID, ItensConstants.ALUMINUMCAN_ID },
            { ItensConstants.COFFEE_CAN_ID, ItensConstants.ALUMINUMCAN_ID },
            { ItensConstants.CAKEDOUGH_ID, ItensConstants.BOWL_ID },
            { ItensConstants.RAW_VEGETABLE_BOWL_ID, ItensConstants.BOWL_ID },
            { ItensConstants.RAW_MEAT_BOWL_ID, ItensConstants.BOWL_ID },
            { ItensConstants.RAW_NOBLE_MEAT_BOWL_ID, ItensConstants.BOWL_ID },
            { ItensConstants.SALAD_ID, ItensConstants.BOWL_ID },
            { ItensConstants.VEGETABLE_SOUP_BOWL_ID, ItensConstants.BOWL_ID },
            { ItensConstants.STEW_ID, ItensConstants.BOWL_ID },
            { ItensConstants.MEAT_VEGETABLES_ID, ItensConstants.BOWL_ID },
            { ItensConstants.MEATLOAF_ID, ItensConstants.BOWL_ID },
            { ItensConstants.MEAT_SOUP_BOWL_ID, ItensConstants.BOWL_ID },
            { ItensConstants.MUSHROOMPATE_BOWL_ID, ItensConstants.BOWL_ID },
            { ItensConstants.RAWFISHMEATBOWL_ID, ItensConstants.BOWL_ID },
            { ItensConstants.FISHSOUPBOWL_ID, ItensConstants.BOWL_ID },
            { ItensConstants.SHRIMPSOUPBOWL_ID, ItensConstants.BOWL_ID },
            { ItensConstants.FATPORRIDGE_ID, ItensConstants.BOWL_ID }
        };

        public static readonly Dictionary<UniqueEntityId, FoodPreparation> FOOD_PREPARATIONS = new Dictionary<UniqueEntityId, FoodPreparation>()
        {
            {
                ItensConstants.WATER_FLASK_SMALL_ID,
                new FoodPreparation()
                {
                    RecipeName = "Water_Flask_Small_Construction",
                    Preparation = PreparationType.Mixing
                }
            },
            {
                ItensConstants.WATER_FLASK_MEDIUM_ID,
                new FoodPreparation()
                {
                    RecipeName = "Water_Flask_Medium_Construction",
                    Preparation = PreparationType.Mixing
                }
            },
            {
                ItensConstants.WATER_FLASK_BIG_ID,
                new FoodPreparation()
                {
                    RecipeName = "Water_Flask_Big_Construction",
                    Preparation = PreparationType.Mixing
                }
            },
            {
                ItensConstants.APPLE_JUICE_ID,
                new FoodPreparation()
                {
                    RecipeName = "AppleJuice_Construction",
                    Preparation = PreparationType.Mixing
                }
            },
            {
                ItensConstants.SODA_ID,
                new FoodPreparation()
                {
                    RecipeName = "ClangCola",
                    Preparation = PreparationType.Processing
                }
            },
            {
                ItensConstants.COFFEE_CAN_ID,
                new FoodPreparation()
                {
                    RecipeName = "CosmicCoffee",
                    Preparation = PreparationType.Cooking
                }
            },
            {
                ItensConstants.DOUGH_ID,
                new FoodPreparation()
                {
                    RecipeName = "Dough_Construction",
                    Preparation = PreparationType.Mixing,
                    OtherRecipes = new string[] { "AlienDough_Construction" }
                }
            },
            {
                ItensConstants.CAKEDOUGH_ID,
                new FoodPreparation()
                {
                    RecipeName = "CakeDough_Construction",
                    Preparation = PreparationType.Mixing,
                    OtherRecipes = new string[] { "AlienCakeDough_Construction" }
                }
            },
            {
                ItensConstants.APPLEPIE_ID,
                new FoodPreparation()
                {
                    RecipeName = "ApplePie_Construction",
                    Preparation = PreparationType.Baking
                }
            },
            {
                ItensConstants.CHICKENPIE_ID,
                new FoodPreparation()
                {
                    RecipeName = "ChickenPie_Construction",
                    Preparation = PreparationType.Baking
                }
            },
            { 
                ItensConstants.RAW_VEGETABLE_BOWL_ID,
                new FoodPreparation()
                {
                    RecipeName = "RawBroccoliBowl_Construction",
                    Preparation = PreparationType.Cutting,
                    OtherRecipes = new string[] { "RawBeetrootBowl_Construction", "RawCarrotBowl_Construction" }
                }
            },
            {
                ItensConstants.RAW_MEAT_BOWL_ID,
                new FoodPreparation()
                {
                    RecipeName = "RawMeatBowl_Construction",
                    Preparation = PreparationType.Cutting,
                    OtherRecipes = new string[] { "RawAlienMeatBowl_Construction" }
                }
            },
            {
                ItensConstants.RAW_NOBLE_MEAT_BOWL_ID,
                new FoodPreparation()
                {
                    RecipeName = "RawNobleMeatBowl_Construction",
                    Preparation = PreparationType.Cutting,
                    OtherRecipes = new string[] { "RawAlienNobleMeatBowl_Construction" }
                }
            },
            {
                ItensConstants.RAW_SAUSAGE_ID,
                new FoodPreparation()
                {
                    RecipeName = "RawSausage_Construction",
                    Preparation = PreparationType.Cutting
                }
            },
            {
                ItensConstants.ROAST_MUSHROOMS_ID,
                new FoodPreparation()
                {
                    RecipeName = "RoastChampignonMushrooms_Construction",
                    Preparation = PreparationType.Baking,
                    OtherRecipes = new string[] { "RoastShiitakeMushrooms_Construction" }
                }
            },
            {
                ItensConstants.FRIED_EGG_ID,
                new FoodPreparation()
                {
                    RecipeName = "FriedEgg_Construction",
                    Preparation = PreparationType.Frying,
                    OtherRecipes = new string[] { "FriedAlienEgg_Construction" }
                }
            },
            {
                ItensConstants.ROASTED_SAUSAGE_ID,
                new FoodPreparation()
                {
                    RecipeName = "RoastedSausage_Construction",
                    Preparation = PreparationType.Baking
                }
            },
            {
                ItensConstants.ROASTEDBACON_ID,
                new FoodPreparation()
                {
                    RecipeName = "RoastedBacon_Construction",
                    Preparation = PreparationType.Frying
                }
            },
            {
                ItensConstants.ROASTEDCHICKEN_ID,
                new FoodPreparation()
                {
                    RecipeName = "RoastedChicken_Construction",
                    Preparation = PreparationType.Baking
                }
            },
            {
                ItensConstants.ROASTED_MEAT_ID,
                new FoodPreparation()
                {
                    RecipeName = "RoastedMeat_Construction",
                    Preparation = PreparationType.Baking,
                    OtherRecipes = new string[] { "RoastedAlienMeat_Construction" }
                }
            },
            {
                ItensConstants.CEREALBAR_ID,
                new FoodPreparation()
                {
                    RecipeName = "CerealBar_Construction",
                    Preparation = PreparationType.Processing
                }
            },
            {
                ItensConstants.WATERBREAD_ID,
                new FoodPreparation()
                {
                    RecipeName = "WaterBread_Construction",
                    Preparation = PreparationType.Baking
                }
            },
            {
                ItensConstants.BREAD_ID,
                new FoodPreparation()
                {
                    RecipeName = "Bread_Construction",
                    Preparation = PreparationType.Baking
                }
            },
            {
                ItensConstants.PASTA_ID,
                new FoodPreparation()
                {
                    RecipeName = "Pasta_Construction",
                    Preparation = PreparationType.Mixing
                }
            },
            {
                ItensConstants.VEGETABLEPASTA_ID,
                new FoodPreparation()
                {
                    RecipeName = "VegetablePasta_Construction",
                    Preparation = PreparationType.Cooking
                }
            },
            {
                ItensConstants.MEATPASTA_ID,
                new FoodPreparation()
                {
                    RecipeName = "MeatPasta_Construction",
                    Preparation = PreparationType.Cooking
                }
            },
            {
                ItensConstants.CHEESE_ID,
                new FoodPreparation()
                {
                    RecipeName = "Cheese_Construction",
                    Preparation = PreparationType.Drying
                }
            },
            {
                ItensConstants.SALAD_ID,
                new FoodPreparation()
                {
                    RecipeName = "Salad_Construction",
                    Preparation = PreparationType.Mixing
                }
            },
            {
                ItensConstants.VEGETABLE_SOUP_BOWL_ID,
                new FoodPreparation()
                {
                    RecipeName = "VegetableSoupBowl_Construction",
                    Preparation = PreparationType.Cooking
                }
            },
            {
                ItensConstants.STEW_ID,
                new FoodPreparation()
                {
                    RecipeName = "StewBowl_Construction",
                    Preparation = PreparationType.Cooking
                }
            },
            {
                ItensConstants.MEAT_VEGETABLES_ID,
                new FoodPreparation()
                {
                    RecipeName = "MeatVegetablesBowl_Construction",
                    Preparation = PreparationType.Cooking,
                    OtherRecipes = new string[] { "AlienMeatVegetablesBowl_Construction" }
                }
            },
            {
                ItensConstants.MEATLOAF_ID,
                new FoodPreparation()
                {
                    RecipeName = "MeatloafBowl_Construction",
                    Preparation = PreparationType.Cooking
                }
            },
            {
                ItensConstants.MEAT_SOUP_BOWL_ID,
                new FoodPreparation()
                {
                    RecipeName = "MeatSoupBowl_Construction",
                    Preparation = PreparationType.Cooking
                }
            },
            {
                ItensConstants.MUSHROOMPATE_BOWL_ID,
                new FoodPreparation()
                {
                    RecipeName = "MushroomPate_Construction",
                    Preparation = PreparationType.Cooking
                }
            },
            {
                ItensConstants.MEAT_MUSHROOMS_ID,
                new FoodPreparation()
                {
                    RecipeName = "MeatMushroom_Construction",
                    Preparation = PreparationType.Cooking,
                    OtherRecipes = new string[] { "AlienMeatMushroom_Construction" }
                }
            },
            {
                ItensConstants.SANDWICH_ID,
                new FoodPreparation()
                {
                    RecipeName = "Sandwich_Construction",
                    Preparation = PreparationType.Mixing
                }
            },
            {
                ItensConstants.RAWFISHMEATBOWL_ID,
                new FoodPreparation()
                {
                    RecipeName = "RawFishMeatBowl_Construction",
                    Preparation = PreparationType.Cooking,
                    OtherRecipes = new string[] { "RawFishMeatBowl_Construction2" }
                }
            },
            {
                ItensConstants.ROASTEDSHRIMP_ID,
                new FoodPreparation()
                {
                    RecipeName = "RoastedShrimp_Construction",
                    Preparation = PreparationType.Frying
                }
            },
            {
                ItensConstants.ROASTEDFISH_ID,
                new FoodPreparation()
                {
                    RecipeName = "RoastedFish_Construction",
                    Preparation = PreparationType.Baking
                }
            },
            {
                ItensConstants.ROASTEDNOBLEFISH_ID,
                new FoodPreparation()
                {
                    RecipeName = "RoastedNobleFish_Construction",
                    Preparation = PreparationType.Baking
                }
            },
            {
                ItensConstants.FISHMUSHROOM_ID,
                new FoodPreparation()
                {
                    RecipeName = "FishMushroom_Construction",
                    Preparation = PreparationType.Cooking
                }
            },
            {
                ItensConstants.FISHSOUPBOWL_ID,
                new FoodPreparation()
                {
                    RecipeName = "FishSoupBowl_Construction",
                    Preparation = PreparationType.Cooking
                }
            },
            {
                ItensConstants.SHRIMPSOUPBOWL_ID,
                new FoodPreparation()
                {
                    RecipeName = "ShrimpSoupBowl_Construction",
                    Preparation = PreparationType.Cooking
                }
            },
            {
                ItensConstants.FATPORRIDGE_ID,
                new FoodPreparation()
                {
                    RecipeName = "FatPorridge_Construction",
                    Preparation = PreparationType.Cooking
                }
            },
            {
                ItensConstants.PROTEINBAR_ID,
                new FoodPreparation()
                {
                    RecipeName = "ProteinBar_Construction",
                    Preparation = PreparationType.Processing
                }
            },
            {
                ItensConstants.VITAMINPILLS_ID,
                new FoodPreparation()
                {
                    RecipeName = "VitaminPills_Construction",
                    Preparation = PreparationType.Processing
                }
            }
        };

        public static void CalculateRecipesNutrition()
        {
            try
            {
                bool needToCallAgain = false;
                foreach (var food in FOOD_PREPARATIONS.Keys)
                {
                    if (!FOOD_INGREDIENTS.ContainsKey(food))
                    {
                        var preparation = FOOD_PREPARATIONS[food];
                        var recipeDef = DefinitionUtils.TryGetBlueprintDefinition(preparation.RecipeName);
                        if (recipeDef != null)
                        {
                            if (recipeDef.Results.Any(x => x.Id == food.DefinitionId))
                            {
                                var recipeResult = recipeDef.Results.FirstOrDefault(x => x.Id == food.DefinitionId);
                                FoodNutrition nutrition = new FoodNutrition();
                                bool addToList = true;
                                foreach (var prerequisite in recipeDef.Prerequisites)
                                {
                                    var preId = new UniqueEntityId(prerequisite.Id);
                                    if (FOOD_INGREDIENTS.ContainsKey(preId))
                                    {
                                        var preNutrition = FOOD_INGREDIENTS[preId];
                                        preNutrition.ApplyPreparation(FOOD_PREPARATIONS[food].Preparation);
                                        nutrition += preNutrition * (float)prerequisite.Amount;
                                    }
                                    else if (!RECIPIENTS.Contains(preId) && FOOD_PREPARATIONS.ContainsKey(preId))
                                    {
                                        // Is a food that need process, need to call again
                                        needToCallAgain = true;
                                        addToList = false;
                                        break;
                                    }
                                }
                                if (addToList)
                                {
                                    nutrition /= (float)recipeResult.Amount;
                                    nutrition.Consumable = food.typeId == typeof(MyObjectBuilder_ConsumableItem);
                                    FOOD_INGREDIENTS.Add(food, nutrition);
                                }
                            }
                            else
                                ExtendedSurvivalLogging.Instance.LogInfo(typeof(NutritionConstants), $"CalculateRecipesNutrition recipe has not valid result. Recipe=[{preparation.RecipeName}] Result=[{food}]");
                        }
                        else
                            ExtendedSurvivalLogging.Instance.LogInfo(typeof(NutritionConstants), $"CalculateRecipesNutrition recipe not found. Recipe=[{preparation.RecipeName}]");
                    }
                }
                if (needToCallAgain)
                    CalculateRecipesNutrition();
            }
            catch (System.Exception ex)
            {
                ExtendedSurvivalLogging.Instance.LogError(typeof(NutritionConstants), ex);
            }
        }

        public static void TryOverrideRecipes()
        {
            try
            {
                foreach (var food in FOOD_INGREDIENTS.Keys)
                {
                    var foodDef = FOOD_INGREDIENTS[food];
                    if (foodDef.Consumable)
                    {
                        var consumableDef = DefinitionUtils.TryGetDefinition<MyConsumableItemDefinition>(food.subtypeId.String);
                        if (consumableDef != null)
                        {
                            if (consumableDef.Stats == null)
                                consumableDef.Stats = new List<MyConsumableItemDefinition.StatValue>();
                            consumableDef.Stats.Clear();
                            FOOD_INGREDIENTS[food].LoadValue(consumableDef.Stats);
                        }
                        else
                            ExtendedSurvivalLogging.Instance.LogInfo(typeof(NutritionConstants), $"TryOverrideRecipes item not found. Food=[{food}]");
                    }
                }
            }
            catch (System.Exception ex)
            {
                ExtendedSurvivalLogging.Instance.LogError(typeof(NutritionConstants), ex);
            }
        }

    }

}