using Sandbox.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using VRage;
using VRage.Game;
using VRageMath;

namespace ExtendedSurvival.Stats
{
    public static class FoodConstants
    {

        public const string CONCENTRATEDFAT_SUBTYPEID = "ConcentratedFat";
        public static readonly UniqueEntityId CONCENTRATEDFAT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), CONCENTRATEDFAT_SUBTYPEID);

        public const string CONCENTRATEDPROTEIN_SUBTYPEID = "ConcentratedProtein";
        public static readonly UniqueEntityId CONCENTRATEDPROTEIN_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), CONCENTRATEDPROTEIN_SUBTYPEID);

        public const string CONCENTRATEDVITAMIN_SUBTYPEID = "ConcentratedVitamin";
        public static readonly UniqueEntityId CONCENTRATEDVITAMIN_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), CONCENTRATEDVITAMIN_SUBTYPEID);

        public static readonly UniqueEntityId WHEATSACK_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), OreConstants.WHEAT_SUBTYPEID);

        public static readonly UniqueEntityId COFFEESACK_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), OreConstants.COFFEE_SUBTYPEID);

        public const string CEREAL_SUBTYPEID = "Cereal";
        public static readonly UniqueEntityId CEREAL_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), CEREAL_SUBTYPEID);

        public const string FATPORRIDGE_SUBTYPEID = "FatPorridge";
        public static readonly UniqueEntityId FATPORRIDGE_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), FATPORRIDGE_SUBTYPEID);

        public const string VITAMINPILLS_SUBTYPEID = "VitaminPills";
        public static readonly UniqueEntityId VITAMINPILLS_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), VITAMINPILLS_SUBTYPEID);

        public const string PROTEINBAR_SUBTYPEID = "ProteinBar";
        public static readonly UniqueEntityId PROTEINBAR_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), PROTEINBAR_SUBTYPEID);

        public const string SHRIMPMEAT_SUBTYPEID = "ShrimpMeat";
        public static readonly UniqueEntityId SHRIMPMEAT_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), SHRIMPMEAT_SUBTYPEID);

        public const string CHEESE_SUBTYPEID = "Cheese";
        public static readonly UniqueEntityId CHEESE_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), CHEESE_SUBTYPEID);

        public const string PASTA_SUBTYPEID = "Pasta";
        public static readonly UniqueEntityId PASTA_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), PASTA_SUBTYPEID);

        public const string ALIEN_PASTA_SUBTYPEID = "AlienPasta";
        public static readonly UniqueEntityId ALIEN_PASTA_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), ALIEN_PASTA_SUBTYPEID);

        public const string VEGETABLEPASTA_SUBTYPEID = "VegetablePasta";
        public static readonly UniqueEntityId VEGETABLEPASTA_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), VEGETABLEPASTA_SUBTYPEID);

        public const string VEGETABLEALIENPASTA_SUBTYPEID = "VegetableAlienPasta";
        public static readonly UniqueEntityId VEGETABLEALIENPASTA_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), VEGETABLEALIENPASTA_SUBTYPEID);

        public const string MEATPASTA_SUBTYPEID = "MeatPasta";
        public static readonly UniqueEntityId MEATPASTA_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), MEATPASTA_SUBTYPEID);

        public const string ALIENMEATPASTA_SUBTYPEID = "AlienMeatPasta";
        public static readonly UniqueEntityId ALIENMEATPASTA_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), ALIENMEATPASTA_SUBTYPEID);

        public const string WATERBREAD_SUBTYPEID = "WaterBread";
        public static readonly UniqueEntityId WATERBREAD_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), WATERBREAD_SUBTYPEID);

        public const string CHICKENMEAT_SUBTYPEID = "ChickenMeat";
        public static readonly UniqueEntityId CHICKENMEAT_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), CHICKENMEAT_SUBTYPEID);

        public const string BACON_SUBTYPEID = "Bacon";
        public static readonly UniqueEntityId BACON_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), BACON_SUBTYPEID);

        public const string CAKEDOUGH_SUBTYPEID = "CakeDough";
        public static readonly UniqueEntityId CAKEDOUGH_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), CAKEDOUGH_SUBTYPEID);

        public const string ALIEN_CAKEDOUGH_SUBTYPEID = "AlienCakeDough";
        public static readonly UniqueEntityId ALIEN_CAKEDOUGH_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), ALIEN_CAKEDOUGH_SUBTYPEID);

        public const string DOUGH_SUBTYPEID = "Dough";
        public static readonly UniqueEntityId DOUGH_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), DOUGH_SUBTYPEID);

        public const string ALIEN_DOUGH_SUBTYPEID = "AlienDough";
        public static readonly UniqueEntityId ALIEN_DOUGH_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), ALIEN_DOUGH_SUBTYPEID);

        public const string ROASTEDCHICKEN_SUBTYPEID = "RoastedChicken";
        public static readonly UniqueEntityId ROASTEDCHICKEN_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), ROASTEDCHICKEN_SUBTYPEID);

        public const string ROASTEDBACON_SUBTYPEID = "RoastedBacon";
        public static readonly UniqueEntityId ROASTEDBACON_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), ROASTEDBACON_SUBTYPEID);

        public const string APPLEPIE_SUBTYPEID = "ApplePie";
        public static readonly UniqueEntityId APPLEPIE_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), APPLEPIE_SUBTYPEID);

        public const string ALIEN_APPLEPIE_SUBTYPEID = "AlienApplePie";
        public static readonly UniqueEntityId ALIEN_APPLEPIE_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), ALIEN_APPLEPIE_SUBTYPEID);

        public const string CHICKENPIE_SUBTYPEID = "ChickenPie";
        public static readonly UniqueEntityId CHICKENPIE_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), CHICKENPIE_SUBTYPEID);

        public const string ALIEN_CHICKENPIE_SUBTYPEID = "AlienChickenPie";
        public static readonly UniqueEntityId ALIEN_CHICKENPIE_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), ALIEN_CHICKENPIE_SUBTYPEID);

        public const string FISHMEAT_SUBTYPEID = "FishMeat";
        public static readonly UniqueEntityId FISHMEAT_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), FISHMEAT_SUBTYPEID);

        public const string NOBLEFISHMEAT_SUBTYPEID = "NobleFishMeat";
        public static readonly UniqueEntityId NOBLEFISHMEAT_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), NOBLEFISHMEAT_SUBTYPEID);

        public const string RAWFISHMEATBOWL_SUBTYPEID = "RawFishMeatBowl";
        public static readonly UniqueEntityId RAWFISHMEATBOWL_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), RAWFISHMEATBOWL_SUBTYPEID);

        public const string RAWNOBLEFISHMEATBOWL_SUBTYPEID = "RawNobleFishMeatBowl";
        public static readonly UniqueEntityId RAWNOBLEFISHMEATBOWL_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), RAWNOBLEFISHMEATBOWL_SUBTYPEID);

        public const string ROASTEDSHRIMP_SUBTYPEID = "RoastedShrimp";
        public static readonly UniqueEntityId ROASTEDSHRIMP_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), ROASTEDSHRIMP_SUBTYPEID);

        public const string ROASTEDFISH_SUBTYPEID = "RoastedFish";
        public static readonly UniqueEntityId ROASTEDFISH_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), ROASTEDFISH_SUBTYPEID);

        public const string ROASTEDNOBLEFISH_SUBTYPEID = "RoastedNobleFish";
        public static readonly UniqueEntityId ROASTEDNOBLEFISH_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), ROASTEDNOBLEFISH_SUBTYPEID);

        public const string FISHMUSHROOM_SUBTYPEID = "FishMushroom";
        public static readonly UniqueEntityId FISHMUSHROOM_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), FISHMUSHROOM_SUBTYPEID);

        public const string FISHSOUPBOWL_SUBTYPEID = "FishSoupBowl";
        public static readonly UniqueEntityId FISHSOUPBOWL_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), FISHSOUPBOWL_SUBTYPEID);

        public const string SHRIMPSOUPBOWL_SUBTYPEID = "ShrimpSoupBowl";
        public static readonly UniqueEntityId SHRIMPSOUPBOWL_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), SHRIMPSOUPBOWL_SUBTYPEID);

        public const string APPLE_JUICE_SUBTYPEID = "AppleJuice";
        public static readonly UniqueEntityId APPLE_JUICE_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), APPLE_JUICE_SUBTYPEID);

        public const string MILK_SUBTYPEID = "Milk";
        public static readonly UniqueEntityId MILK_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), MILK_SUBTYPEID);

        public const string SODA_SUBTYPEID = "ClangCola";
        public static readonly UniqueEntityId SODA_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), SODA_SUBTYPEID);

        public const string COFFEE_CAN_SUBTYPEID = "CosmicCoffee";
        public static readonly UniqueEntityId COFFEE_CAN_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), COFFEE_CAN_SUBTYPEID);

        public const string ROASTED_MEAT_SUBTYPEID = "RoastedMeat";
        public static readonly UniqueEntityId ROASTED_MEAT_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), ROASTED_MEAT_SUBTYPEID);

        public const string ROASTED_ALIEN_MEAT_SUBTYPEID = "RoastedAlienMeat";
        public static readonly UniqueEntityId ROASTED_ALIEN_MEAT_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), ROASTED_ALIEN_MEAT_SUBTYPEID);

        public const string CEREALBAR_SUBTYPEID = "CerealBar";
        public static readonly UniqueEntityId CEREALBAR_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), CEREALBAR_SUBTYPEID);

        public const string ROASTED_SAUSAGE_SUBTYPEID = "RoastedSausage";
        public static readonly UniqueEntityId ROASTED_SAUSAGE_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), ROASTED_SAUSAGE_SUBTYPEID);

        public const string ROASTED_ALIEN_SAUSAGE_SUBTYPEID = "RoastedAlienSausage";
        public static readonly UniqueEntityId ROASTED_ALIEN_SAUSAGE_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), ROASTED_ALIEN_SAUSAGE_SUBTYPEID);

        public const string FRIED_EGG_SUBTYPEID = "FriedEgg";
        public static readonly UniqueEntityId FRIED_EGG_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), FRIED_EGG_SUBTYPEID);

        public const string FRIED_ALIEN_EGG_SUBTYPEID = "FriedAlienEgg";
        public static readonly UniqueEntityId FRIED_ALIEN_EGG_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), FRIED_ALIEN_EGG_SUBTYPEID);

        public const string STEW_SUBTYPEID = "StewBowl";
        public static readonly UniqueEntityId STEW_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), STEW_SUBTYPEID);

        public const string ALIEN_STEW_SUBTYPEID = "AlienStewBowl";
        public static readonly UniqueEntityId ALIEN_STEW_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), ALIEN_STEW_SUBTYPEID);

        public const string MEATLOAF_SUBTYPEID = "MeatloafBowl";
        public static readonly UniqueEntityId MEATLOAF_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), MEATLOAF_SUBTYPEID);

        public const string ALIENMEATLOAF_SUBTYPEID = "AlienMeatloafBowl";
        public static readonly UniqueEntityId ALIENMEATLOAF_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), ALIENMEATLOAF_SUBTYPEID);

        public const string SALAD_SUBTYPEID = "SaladBowl";
        public static readonly UniqueEntityId SALAD_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), SALAD_SUBTYPEID);

        public const string BREAD_SUBTYPEID = "Bread";
        public static readonly UniqueEntityId BREAD_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), BREAD_SUBTYPEID);

        public const string ALIEN_BREAD_SUBTYPEID = "AlienBread";
        public static readonly UniqueEntityId ALIEN_BREAD_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), ALIEN_BREAD_SUBTYPEID);

        public const string ROAST_CHAMPIGNON_SUBTYPEID = "RoastChampignons";
        public static readonly UniqueEntityId ROAST_CHAMPIGNON_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), ROAST_CHAMPIGNON_SUBTYPEID);

        public const string ROAST_SHIITAKE_SUBTYPEID = "RoastShiitake";
        public static readonly UniqueEntityId ROAST_SHIITAKE_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), ROAST_SHIITAKE_SUBTYPEID);

        public const string MEAT_VEGETABLES_SUBTYPEID = "MeatVegetablesBowl";
        public static readonly UniqueEntityId MEAT_VEGETABLES_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), MEAT_VEGETABLES_SUBTYPEID);

        public const string ALIEN_MEAT_VEGETABLES_SUBTYPEID = "AlienMeatVegetablesBowl";
        public static readonly UniqueEntityId ALIEN_MEAT_VEGETABLES_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), ALIEN_MEAT_VEGETABLES_SUBTYPEID);

        public const string MEAT_MUSHROOMS_SUBTYPEID = "MeatMushroom";
        public static readonly UniqueEntityId MEAT_MUSHROOMS_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), MEAT_MUSHROOMS_SUBTYPEID);

        public const string ALIEN_MEAT_MUSHROOMS_SUBTYPEID = "AlienMeatMushroom";
        public static readonly UniqueEntityId ALIEN_MEAT_MUSHROOMS_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), ALIEN_MEAT_MUSHROOMS_SUBTYPEID);

        public const string SANDWICH_SUBTYPEID = "Sandwich";
        public static readonly UniqueEntityId SANDWICH_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), SANDWICH_SUBTYPEID);

        public const string ALIEN_SANDWICH_SUBTYPEID = "AlienSandwich";
        public static readonly UniqueEntityId ALIEN_SANDWICH_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), ALIEN_SANDWICH_SUBTYPEID);

        public const string CHAMPIGNONS_SUBTYPEID = "Champignons";
        public static readonly UniqueEntityId CHAMPIGNONS_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), CHAMPIGNONS_SUBTYPEID);

        public const string SHIITAKE_SUBTYPEID = "Shiitake";
        public static readonly UniqueEntityId SHIITAKE_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), SHIITAKE_SUBTYPEID);

        public const string AMANITAMUSCARIA_SUBTYPEID = "AmanitaMuscaria";
        public static readonly UniqueEntityId AMANITAMUSCARIA_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), AMANITAMUSCARIA_SUBTYPEID);

        public const string BEETROOT_SUBTYPEID = "Beetroot";
        public static readonly UniqueEntityId BEETROOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), BEETROOT_SUBTYPEID);

        public const string CAROOT_SUBTYPEID = "Carrot";
        public static readonly UniqueEntityId CAROOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), CAROOT_SUBTYPEID);

        public const string BROCCOLI_SUBTYPEID = "Broccoli";
        public static readonly UniqueEntityId BROCCOLI_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), BROCCOLI_SUBTYPEID);

        public const string TOMATO_SUBTYPEID = "Tomato";
        public static readonly UniqueEntityId TOMATO_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), TOMATO_SUBTYPEID);

        public const string NOBLE_MEAT_SUBTYPEID = "NobleMeat";
        public static readonly UniqueEntityId NOBLE_MEAT_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), NOBLE_MEAT_SUBTYPEID);

        public const string ALIEN_MEAT_SUBTYPEID = "AlienMeat";
        public static readonly UniqueEntityId ALIEN_MEAT_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), ALIEN_MEAT_SUBTYPEID);

        public const string ALIEN_NOBLE_MEAT_SUBTYPEID = "AlienNobleMeat";
        public static readonly UniqueEntityId ALIEN_NOBLE_MEAT_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), ALIEN_NOBLE_MEAT_SUBTYPEID);

        public const string ALIEN_EGG_SUBTYPEID = "AlienEgg";
        public static readonly UniqueEntityId ALIEN_EGG_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), ALIEN_EGG_SUBTYPEID);

        public const string EGG_SUBTYPEID = "Egg";
        public static readonly UniqueEntityId EGG_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), EGG_SUBTYPEID);

        public const string RAW_SAUSAGE_SUBTYPEID = "RawSausage";
        public static readonly UniqueEntityId RAW_SAUSAGE_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), RAW_SAUSAGE_SUBTYPEID);

        public const string RAW_ALIEN_SAUSAGE_SUBTYPEID = "RawAlienSausage";
        public static readonly UniqueEntityId RAW_ALIEN_SAUSAGE_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), RAW_ALIEN_SAUSAGE_SUBTYPEID);

        public const string RAW_MEAT_BOWL_SUBTYPEID = "RawMeatBowl";
        public static readonly UniqueEntityId RAW_MEAT_BOWL_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), RAW_MEAT_BOWL_SUBTYPEID);

        public const string RAW_ALIEN_MEAT_BOWL_SUBTYPEID = "RawAlienMeatBowl";
        public static readonly UniqueEntityId RAW_ALIEN_MEAT_BOWL_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), RAW_ALIEN_MEAT_BOWL_SUBTYPEID);

        public const string RAW_NOBLE_MEAT_BOWL_SUBTYPEID = "RawNobleMeatBowl";
        public static readonly UniqueEntityId RAW_NOBLE_MEAT_BOWL_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), RAW_NOBLE_MEAT_BOWL_SUBTYPEID);

        public const string RAW_ALIEN_NOBLE_MEAT_BOWL_SUBTYPEID = "RawAlienNobleMeatBowl";
        public static readonly UniqueEntityId RAW_ALIEN_NOBLE_MEAT_BOWL_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), RAW_ALIEN_NOBLE_MEAT_BOWL_SUBTYPEID);

        public const string RAW_BROCCOLI_BOWL_SUBTYPEID = "RawBroccoliBowl";
        public static readonly UniqueEntityId RAW_BROCCOLI_BOWL_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), RAW_BROCCOLI_BOWL_SUBTYPEID);

        public const string RAW_CARROT_BOWL_SUBTYPEID = "RawCarrotBowl";
        public static readonly UniqueEntityId RAW_CARROT_BOWL_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), RAW_CARROT_BOWL_SUBTYPEID);

        public const string RAW_BEETROOT_BOWL_SUBTYPEID = "RawBeetrootBowl";
        public static readonly UniqueEntityId RAW_BEETROOT_BOWL_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), RAW_BEETROOT_BOWL_SUBTYPEID);

        public const string VEGETABLE_SOUP_BOWL_SUBTYPEID = "VegetableSoupBowl";
        public static readonly UniqueEntityId VEGETABLE_SOUP_BOWL_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), VEGETABLE_SOUP_BOWL_SUBTYPEID);

        public const string MEAT_SOUP_BOWL_SUBTYPEID = "MeatSoupBowl";
        public static readonly UniqueEntityId MEAT_SOUP_BOWL_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), MEAT_SOUP_BOWL_SUBTYPEID);

        public const string ALIEN_MEAT_SOUP_BOWL_SUBTYPEID = "AlienMeatSoupBowl";
        public static readonly UniqueEntityId ALIEN_MEAT_SOUP_BOWL_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), ALIEN_MEAT_SOUP_BOWL_SUBTYPEID);

        public const string MUSHROOMPATE_BOWL_SUBTYPEID = "MushroomPateBowl";
        public static readonly UniqueEntityId MUSHROOMPATE_BOWL_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), MUSHROOMPATE_BOWL_SUBTYPEID);

        public const string MEAT_SUBTYPEID = "Meat";
        public static readonly UniqueEntityId MEAT_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), MEAT_SUBTYPEID);

        public const string APPLE_SUBTYPEID = "Apple";
        public static readonly UniqueEntityId APPLE_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), APPLE_SUBTYPEID);

        public const string TOFU_SUBTYPEID = "Tofu";
        public static readonly UniqueEntityId TOFU_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), TOFU_SUBTYPEID);

        public const string MRE_SUBTYPEID = "Mre";
        public static readonly UniqueEntityId MRE_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), MRE_SUBTYPEID);

        public static readonly long BASE_RAW_MEAT_SPOIL_TIME = 5 * 60 * 1000;
        public static readonly long BASE_RAW_VEGETABLE_SPOIL_TIME = (long)(7.5f * 60 * 1000);
        public static readonly long BASE_RAW_FRUIT_SPOIL_TIME = 10 * 60 * 1000;
        public static readonly long BASE_RAW_MUSHROOM_SPOIL_TIME = (long)(12.5f * 60 * 1000);
        public static readonly long BASE_MILK_SPOIL_TIME = 15 * 60 * 1000;
        public static readonly long BASE_EGG_SPOIL_TIME = 15 * 60 * 1000;

        public static readonly FoodDefinition APPLE_DEFINITION = new FoodDefinition()
        {
            Id = APPLE_ID,
            Solid = 0.09f,
            Liquid = 0.06f,
            Protein = 0.36f,
            Carbohydrate = 19.06f,
            Lipids = 0.24f,
            Vitamins = 0.075f,
            Minerals = 0.165f,
            Calories = 71f,
            TimeToConsume = 80f,
            NeedConservation = true,
            StartConservationTime = BASE_RAW_FRUIT_SPOIL_TIME,
            Name = LanguageProvider.GetEntry(LanguageEntries.APPLE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.APPLE_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 10,
            OfferAmount = new Vector2I(15000, 45000),
            OrderAmount = new Vector2I(5000, 15000),
            AcquisitionAmount = new Vector2I(10000, 30000),
            DiseaseChance = new Dictionary<StatsConstants.DiseaseEffects, float>()
            {
                { StatsConstants.DiseaseEffects.Dysentery, 0.025f }
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.StaminaAmount,
                    EffectType = FoodEffectType.Instant,
                    Ammount = 25
                },
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.StaminaAmount,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = 25,
                    TimeToEffect = 5
                },
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Health,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = 10,
                    TimeToEffect = 5
                }
            },
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.FreshFruit, 1 }
            }
        };

        public static readonly FoodDefinition BROCCOLI_DEFINITION = new FoodDefinition()
        {
            Id = BROCCOLI_ID,
            Solid = 0.22f,
            Liquid = 0.08f,
            Protein = 11.2f,
            Carbohydrate = 28f,
            Lipids = 1.6f,
            Vitamins = 0.360f,
            Minerals = 0.272f,
            Calories = 136f,
            TimeToConsume = 60f,
            NeedConservation = true,
            StartConservationTime = BASE_RAW_VEGETABLE_SPOIL_TIME,
            Name = LanguageProvider.GetEntry(LanguageEntries.BROCCOLI_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.BROCCOLI_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 15,
            OfferAmount = new Vector2I(15000, 45000),
            OrderAmount = new Vector2I(5000, 15000),
            AcquisitionAmount = new Vector2I(10000, 30000),
            DiseaseChance = new Dictionary<StatsConstants.DiseaseEffects, float>()
            {
                { StatsConstants.DiseaseEffects.Dysentery, 0.05f }
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Health,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = 25,
                    TimeToEffect = 5
                }
            },
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.RawVegetable, 1 }
            }
        };

        public static readonly FoodDefinition BEETROOT_DEFINITION = new FoodDefinition()
        {
            Id = BEETROOT_ID,
            Solid = 0.1f,
            Liquid = 0.05f,
            Protein = 1.92f,
            Carbohydrate = 11.472f,
            Lipids = 0.204f,
            Vitamins = 0.006f,
            Minerals = 0.5784f,
            Calories = 51.6f,
            TimeToConsume = 120f,
            NeedConservation = true,
            StartConservationTime = BASE_RAW_VEGETABLE_SPOIL_TIME,
            Name = LanguageProvider.GetEntry(LanguageEntries.BEETROOT_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.BEETROOT_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 10,
            OfferAmount = new Vector2I(15000, 45000),
            OrderAmount = new Vector2I(5000, 15000),
            AcquisitionAmount = new Vector2I(10000, 30000),
            DiseaseChance = new Dictionary<StatsConstants.DiseaseEffects, float>()
            {
                { StatsConstants.DiseaseEffects.Dysentery, 0.05f }
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Health,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = 25,
                    TimeToEffect = 5
                }
            },
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.RawVegetable, 1 }
            }
        };

        public static readonly FoodDefinition CAROOT_DEFINITION = new FoodDefinition()
        {
            Id = CAROOT_ID,
            Solid = 0.1f,
            Liquid = 0.05f,
            Protein = 1.116f,
            Carbohydrate = 11.52f,
            Lipids = 0.288f,
            Vitamins = 0.0024f,
            Minerals = 0.7344f,
            Calories = 49.5f,
            TimeToConsume = 120f,
            NeedConservation = true,
            StartConservationTime = BASE_RAW_VEGETABLE_SPOIL_TIME,
            Name = LanguageProvider.GetEntry(LanguageEntries.CAROOT_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.CAROOT_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 10,
            OfferAmount = new Vector2I(15000, 45000),
            OrderAmount = new Vector2I(5000, 15000),
            AcquisitionAmount = new Vector2I(10000, 30000),
            DiseaseChance = new Dictionary<StatsConstants.DiseaseEffects, float>()
            {
                { StatsConstants.DiseaseEffects.Dysentery, 0.05f }
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Health,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = 25,
                    TimeToEffect = 5
                }
            },
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.RawVegetable, 1 }
            }
        };

        public static readonly FoodDefinition SHIITAKE_DEFINITION = new FoodDefinition()
        {
            Id = SHIITAKE_ID,
            Solid = 0.02f,
            Liquid = 0.01f,
            Protein = 0.66f,
            Carbohydrate = 2.04f,
            Lipids = 0.15f,
            Vitamins = 0.0027f,
            Minerals = 0.1341f,
            Calories = 10.2f,
            TimeToConsume = 10f,
            NeedConservation = true,
            StartConservationTime = BASE_RAW_MUSHROOM_SPOIL_TIME,
            Name = LanguageProvider.GetEntry(LanguageEntries.SHIITAKE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.SHIITAKE_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 5,
            OfferAmount = new Vector2I(15000, 45000),
            OrderAmount = new Vector2I(5000, 15000),
            AcquisitionAmount = new Vector2I(10000, 30000),
            DiseaseChance = new Dictionary<StatsConstants.DiseaseEffects, float>()
            {
                { StatsConstants.DiseaseEffects.Dysentery, 0.05f }
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Fatigue,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = -25,
                    TimeToEffect = 5
                }
            },
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.WildMushroom, 1 }
            }
        };

        public static readonly FoodDefinition CHAMPIGNONS_DEFINITION = new FoodDefinition()
        {
            Id = CHAMPIGNONS_ID,
            Solid = 0.02f,
            Liquid = 0.01f,
            Protein = 0.618f,
            Carbohydrate = 0.652f,
            Lipids = 0.048f,
            Vitamins = 0.0014f,
            Minerals = 0.0832f,
            Calories = 4.4f,
            TimeToConsume = 10f,
            NeedConservation = true,
            StartConservationTime = BASE_RAW_MUSHROOM_SPOIL_TIME,
            Name = LanguageProvider.GetEntry(LanguageEntries.CHAMPIGNONS_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.CHAMPIGNONS_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 5,
            OfferAmount = new Vector2I(15000, 45000),
            OrderAmount = new Vector2I(5000, 15000),
            AcquisitionAmount = new Vector2I(10000, 30000),
            DiseaseChance = new Dictionary<StatsConstants.DiseaseEffects, float>()
            {
                { StatsConstants.DiseaseEffects.Dysentery, 0.05f }
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Fatigue,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = -25,
                    TimeToEffect = 5
                }
            },
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.WildMushroom, 1 }
            }
        };

        public static readonly FoodDefinition AMANITAMUSCARIA_DEFINITION = new FoodDefinition()
        {
            Id = AMANITAMUSCARIA_ID,
            Solid = 0.02f,
            Liquid = 0.01f,
            Protein = 0.218f,
            Carbohydrate = 0.352f,
            Lipids = 0.045f,
            Vitamins = 0.0012f,
            Minerals = 0.0838f,
            Calories = 7.2f,
            TimeToConsume = 10f,
            NeedConservation = true,
            StartConservationTime = BASE_RAW_MUSHROOM_SPOIL_TIME,
            Name = LanguageProvider.GetEntry(LanguageEntries.AMANITAMUSCARIA_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.AMANITAMUSCARIA_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 25,
            OfferAmount = new Vector2I(15000, 45000),
            OrderAmount = new Vector2I(5000, 15000),
            AcquisitionAmount = new Vector2I(10000, 30000),
            DiseaseChance = new Dictionary<StatsConstants.DiseaseEffects, float>()
            {
                { StatsConstants.DiseaseEffects.Poison, 1.0f }
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Fatigue,
                    EffectType = FoodEffectType.Instant,
                    Ammount = 250
                },
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Fatigue,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = 750,
                    TimeToEffect = 30
                }
            },
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.PoisonMushroom, 1 }
            }
        };

        public static readonly FoodDefinition TOMATO_DEFINITION = new FoodDefinition()
        {
            Id = TOMATO_ID,
            Solid = 0.07f,
            Liquid = 0.08f,
            Protein = 1.08f,
            Carbohydrate = 4.29f,
            Lipids = 0.24f,
            Vitamins = 0.018f,
            Minerals = 0.3444f,
            Calories = 21.6f,
            TimeToConsume = 60f,
            NeedConservation = true,
            StartConservationTime = BASE_RAW_FRUIT_SPOIL_TIME,
            Name = LanguageProvider.GetEntry(LanguageEntries.TOMATO_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.TOMATO_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 15,
            OfferAmount = new Vector2I(15000, 45000),
            OrderAmount = new Vector2I(5000, 15000),
            AcquisitionAmount = new Vector2I(10000, 30000),
            DiseaseChance = new Dictionary<StatsConstants.DiseaseEffects, float>()
            {
                { StatsConstants.DiseaseEffects.Dysentery, 0.025f }
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.StaminaAmount,
                    EffectType = FoodEffectType.Instant,
                    Ammount = 25
                },
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Health,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = 25,
                    TimeToEffect = 5
                }
            },
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.JuicyRed, 1 }
            }
        };

        public static readonly FoodDefinition CEREAL_DEFINITION = new FoodDefinition()
        {
            Id = CEREAL_ID,
            Solid = 0.9f,
            Liquid = 0.1f,
            Protein = 150.0f,
            Carbohydrate = 575.0f,
            Lipids = 75.0f,
            Vitamins = 0,
            Minerals = 28.5f,
            Calories = 3500.0f,
            TimeToConsume = 1200f,
            DefinitionType = FoodDefinition.FoodDefinitionType.Ingot,
            Name = LanguageProvider.GetEntry(LanguageEntries.CEREAL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.CEREAL_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 25,
            OfferAmount = new Vector2I(15000, 45000),
            OrderAmount = new Vector2I(5000, 15000),
            AcquisitionAmount = new Vector2I(10000, 30000)
        };

        public static readonly FoodDefinition WHEATSACK_DEFINITION = new FoodDefinition()
        {
            Id = WHEATSACK_ID,
            Solid = 0.9f,
            Liquid = 0.1f,
            Protein = 137.4f,
            Carbohydrate = 752.0f,
            Lipids = 21.0f,
            Vitamins = 0,
            Minerals = 15.0f,
            Calories = 3746.0f,
            TimeToConsume = 1200f,
            DefinitionType = FoodDefinition.FoodDefinitionType.Ingot,
            Name = LanguageProvider.GetEntry(LanguageEntries.WHEATSACK_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.WHEATSACK_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 18,
            OfferAmount = new Vector2I(15000, 45000),
            OrderAmount = new Vector2I(5000, 15000),
            AcquisitionAmount = new Vector2I(10000, 30000)
        };

        public static readonly FoodDefinition COFFEESACK_DEFINITION = new FoodDefinition()
        {
            Id = COFFEESACK_ID,
            Solid = 0.9f,
            Liquid = 0.1f,
            Protein = 1.0f,
            Carbohydrate = 0.0f,
            Lipids = 0.0f,
            Vitamins = 0.0f,
            Minerals = 0.5f,
            Calories = 0.0f,
            TimeToConsume = 1200f,
            DefinitionType = FoodDefinition.FoodDefinitionType.Ingot,
            Name = LanguageProvider.GetEntry(LanguageEntries.COFFEESACK_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.COFFEESACK_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 22,
            OfferAmount = new Vector2I(15000, 45000),
            OrderAmount = new Vector2I(5000, 15000),
            AcquisitionAmount = new Vector2I(10000, 30000)
        };

        public static readonly FoodDefinition ICE_DEFINITION = new FoodDefinition()
        {
            Id = ItensConstants.ICE_ID,
            Solid = 0.0f,
            Liquid = 1.0f,
            TimeToConsume = 240f,
            DefinitionType = FoodDefinition.FoodDefinitionType.Ore,
            IgnoreDefinition = true
        };

        public static readonly FoodDefinition ORGANIC_DEFINITION = new FoodDefinition()
        {
            Id = ItensConstants.SPOILED_MATERIAL_ID,
            Solid = 0.7f,
            Liquid = 0.3f,
            Protein = 6.25f,
            Carbohydrate = 27.5f,
            Lipids = 3.75f,
            Vitamins = 0,
            Minerals = 0f,
            Calories = 250.0f,
            TimeToConsume = 1200f,
            DefinitionType = FoodDefinition.FoodDefinitionType.Ore,
            IgnoreDefinition = true
        };

        public static readonly FoodDefinition CARBON_DEFINITION = new FoodDefinition()
        {
            Id = ItensConstants.CARBON_INGOT_ID,
            Solid = 1.0f,
            Liquid = 0f,
            Protein = 12.5f,
            Carbohydrate = 13.75f,
            Lipids = 7.5f,
            Vitamins = 0,
            Minerals = 0f,
            Calories = 375.0f,
            TimeToConsume = 800f,
            DefinitionType = FoodDefinition.FoodDefinitionType.Ore,
            IgnoreDefinition = true
        };

        public static readonly FoodDefinition MILK_DEFINITION = new FoodDefinition()
        {
            Id = MILK_ID,
            Solid = 0.15f,
            Liquid = 0.35f,
            Protein = 12.8f,
            Carbohydrate = 19.2f,
            Lipids = 15.6f,
            Vitamins = 0.0f,
            Minerals = 0.480f,
            Calories = 264.0f,
            TimeToConsume = 60f,
            NeedConservation = true,
            StartConservationTime = BASE_MILK_SPOIL_TIME,
            Name = LanguageProvider.GetEntry(LanguageEntries.MILK_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.MILK_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 50,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300),
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.StaminaAmount,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = 60,
                    TimeToEffect = 5
                },
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Health,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = 30,
                    TimeToEffect = 5
                }
            },
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.StraightFromTheCow, 1 }
            }
        };

        public static readonly FoodDefinition MEAT_DEFINITION = new FoodDefinition()
        {
            Id = MEAT_ID,
            Solid = 0.075f,
            Liquid = 0.025f,
            Protein = 26.0f,
            Carbohydrate = 0.0f,
            Lipids = 15.0f,
            Vitamins = 0.001f,
            Minerals = 0.039f,
            Calories = 264.0f,
            TimeToConsume = 180f,
            NeedConservation = true,
            StartConservationTime = BASE_RAW_MEAT_SPOIL_TIME,
            Name = LanguageProvider.GetEntry(LanguageEntries.MEAT_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.MEAT_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 25,
            OfferAmount = new Vector2I(1500, 4500),
            OrderAmount = new Vector2I(500, 1500),
            AcquisitionAmount = new Vector2I(1000, 3000),
            DiseaseChance = new Dictionary<StatsConstants.DiseaseEffects, float>()
            {
                { StatsConstants.DiseaseEffects.Dysentery, 1.0f }
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Health,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = -50,
                    TimeToEffect = 5
                }
            },
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.RawMeat, 1 }
            }
        };

        public static readonly FoodDefinition ALIENMEAT_DEFINITION = new FoodDefinition()
        {
            Id = ALIEN_MEAT_ID,
            Solid = 0.075f,
            Liquid = 0.025f,
            Protein = 28.0f,
            Carbohydrate = 0.0f,
            Lipids = 16.0f,
            Vitamins = 0.009f,
            Minerals = 0.049f,
            Calories = 292.0f,
            TimeToConsume = 180f,
            NeedConservation = true,
            StartConservationTime = BASE_RAW_MEAT_SPOIL_TIME,
            Name = LanguageProvider.GetEntry(LanguageEntries.ALIEN_MEAT_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ALIEN_MEAT_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 25,
            OfferAmount = new Vector2I(1500, 4500),
            OrderAmount = new Vector2I(500, 1500),
            AcquisitionAmount = new Vector2I(1000, 3000),
            DiseaseChance = new Dictionary<StatsConstants.DiseaseEffects, float>()
            {
                { StatsConstants.DiseaseEffects.Dysentery, 1.0f }
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Health,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = -50,
                    TimeToEffect = 5
                }
            },
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.RawMeat, 1 }
            }
        };

        public static readonly FoodDefinition CHICKENMEAT_DEFINITION = new FoodDefinition()
        {
            Id = CHICKENMEAT_ID,
            Solid = 0.075f,
            Liquid = 0.025f,
            Protein = 27.0f,
            Carbohydrate = 0.0f,
            Lipids = 14.0f,
            Vitamins = 0.005f,
            Minerals = 0.038f,
            Calories = 219.0f,
            TimeToConsume = 180f,
            NeedConservation = true,
            StartConservationTime = BASE_RAW_MEAT_SPOIL_TIME,
            Name = LanguageProvider.GetEntry(LanguageEntries.CHICKENMEAT_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.CHICKENMEAT_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 35,
            OfferAmount = new Vector2I(1500, 4500),
            OrderAmount = new Vector2I(500, 1500),
            AcquisitionAmount = new Vector2I(1000, 3000),
            DiseaseChance = new Dictionary<StatsConstants.DiseaseEffects, float>()
            {
                { StatsConstants.DiseaseEffects.Dysentery, 1.0f }
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Health,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = -50,
                    TimeToEffect = 5
                }
            },
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.RawMeat, 1 }
            }
        };

        public static readonly FoodDefinition BACON_DEFINITION = new FoodDefinition()
        {
            Id = BACON_ID,
            Solid = 0.075f,
            Liquid = 0.025f,
            Protein = 37.0f,
            Carbohydrate = 1.4f,
            Lipids = 42.0f,
            Vitamins = 0.012f,
            Minerals = 0.033f,
            Calories = 541.0f,
            TimeToConsume = 180f,
            NeedConservation = true,
            StartConservationTime = BASE_RAW_MEAT_SPOIL_TIME,
            Name = LanguageProvider.GetEntry(LanguageEntries.BACON_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.BACON_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 35,
            OfferAmount = new Vector2I(1500, 4500),
            OrderAmount = new Vector2I(500, 1500),
            AcquisitionAmount = new Vector2I(1000, 3000),
            DiseaseChance = new Dictionary<StatsConstants.DiseaseEffects, float>()
            {
                { StatsConstants.DiseaseEffects.Dysentery, 1.0f }
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Health,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = -50,
                    TimeToEffect = 5
                }
            },
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.RawMeat, 1 }
            }
        };

        public static readonly FoodDefinition NOBLE_MEAT_DEFINITION = new FoodDefinition()
        {
            Id = NOBLE_MEAT_ID,
            Solid = 0.07f,
            Liquid = 0.03f,
            Protein = 52.0f,
            Carbohydrate = 0.0f,
            Lipids = 30.0f,
            Vitamins = 0.002f,
            Minerals = 0.078f,
            Calories = 528.0f,
            TimeToConsume = 240f,
            NeedConservation = true,
            StartConservationTime = BASE_RAW_MEAT_SPOIL_TIME,
            Name = LanguageProvider.GetEntry(LanguageEntries.NOBLE_MEAT_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.NOBLE_MEAT_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 45,
            OfferAmount = new Vector2I(1500, 4500),
            OrderAmount = new Vector2I(500, 1500),
            AcquisitionAmount = new Vector2I(1000, 3000),
            DiseaseChance = new Dictionary<StatsConstants.DiseaseEffects, float>()
            {
                { StatsConstants.DiseaseEffects.Dysentery, 1.0f }
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Health,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = -50,
                    TimeToEffect = 5
                }
            },
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.RawMeat, 1 }
            }
        };

        public static readonly FoodDefinition ALIEN_NOBLE_MEAT_DEFINITION = new FoodDefinition()
        {
            Id = ALIEN_NOBLE_MEAT_ID,
            Solid = 0.07f,
            Liquid = 0.03f,
            Protein = 56.0f,
            Carbohydrate = 0.0f,
            Lipids = 32.0f,
            Vitamins = 0.018f,
            Minerals = 0.098f,
            Calories = 584.0f,
            TimeToConsume = 240f,
            NeedConservation = true,
            StartConservationTime = BASE_RAW_MEAT_SPOIL_TIME,
            Name = LanguageProvider.GetEntry(LanguageEntries.ALIEN_NOBLE_MEAT_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ALIEN_NOBLE_MEAT_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 45,
            OfferAmount = new Vector2I(1500, 4500),
            OrderAmount = new Vector2I(500, 1500),
            AcquisitionAmount = new Vector2I(1000, 3000),
            DiseaseChance = new Dictionary<StatsConstants.DiseaseEffects, float>()
            {
                { StatsConstants.DiseaseEffects.Dysentery, 1.0f }
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Health,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = -50,
                    TimeToEffect = 5
                }
            },
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.RawMeat, 1 }
            }
        };

        public static readonly FoodDefinition EGG_DEFINITION = new FoodDefinition()
        {
            Id = EGG_ID,
            Solid = 0.02f,
            Liquid = 0.03f,
            Protein = 7.8f,
            Carbohydrate = 0.66f,
            Lipids = 6.6f,
            Vitamins = 0.001f,
            Minerals = 0.0366f,
            Calories = 93.0f,
            TimeToConsume = 120f,
            NeedConservation = true,
            StartConservationTime = BASE_EGG_SPOIL_TIME,
            Name = LanguageProvider.GetEntry(LanguageEntries.EGG_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.EGG_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 15,
            OfferAmount = new Vector2I(1500, 4500),
            OrderAmount = new Vector2I(500, 1500),
            AcquisitionAmount = new Vector2I(1000, 3000),
            DiseaseChance = new Dictionary<StatsConstants.DiseaseEffects, float>()
            {
                { StatsConstants.DiseaseEffects.Dysentery, 0.1f }
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Fatigue,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = -250,
                    TimeToEffect = 5
                }
            },
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.ViscousAndDelicious, 1 }
            }
        };

        public static readonly FoodDefinition ALIEN_EGG_DEFINITION = new FoodDefinition()
        {
            Id = ALIEN_EGG_ID,
            Solid = 0.02f,
            Liquid = 0.03f,
            Protein = 13.0f,
            Carbohydrate = 1.1f,
            Lipids = 11.0f,
            Vitamins = 0.001f,
            Minerals = 0.061f,
            Calories = 155.0f,
            TimeToConsume = 160f,
            NeedConservation = true,
            StartConservationTime = BASE_EGG_SPOIL_TIME,
            Name = LanguageProvider.GetEntry(LanguageEntries.ALIEN_EGG_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ALIEN_EGG_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 15,
            OfferAmount = new Vector2I(1500, 4500),
            OrderAmount = new Vector2I(500, 1500),
            AcquisitionAmount = new Vector2I(1000, 3000),
            DiseaseChance = new Dictionary<StatsConstants.DiseaseEffects, float>()
            {
                { StatsConstants.DiseaseEffects.Dysentery, 0.25f }
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Health,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = -25,
                    TimeToEffect = 5
                }
            },
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.ViscousAndDelicious, 1 }
            }
        };

        public static readonly FoodDefinition SHRIMPMEAT_DEFINITION = new FoodDefinition()
        {
            Id = SHRIMPMEAT_ID,
            Solid = 0.006f,
            Liquid = 0.004f,
            Protein = 2.4f,
            Carbohydrate = 0.02f,
            Lipids = 0.03f,
            Vitamins = 0.0f,
            Minerals = 0.011f,
            Calories = 9.9f,
            TimeToConsume = 50f,
            NeedConservation = true,
            StartConservationTime = BASE_RAW_MEAT_SPOIL_TIME,
            Name = LanguageProvider.GetEntry(LanguageEntries.SHRIMPMEAT_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.SHRIMPMEAT_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 5,
            OfferAmount = new Vector2I(1500, 4500),
            OrderAmount = new Vector2I(500, 1500),
            AcquisitionAmount = new Vector2I(1000, 3000),
            DiseaseChance = new Dictionary<StatsConstants.DiseaseEffects, float>()
            {
                { StatsConstants.DiseaseEffects.Dysentery, 1.0f }
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Health,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = -25,
                    TimeToEffect = 5
                }
            },
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.RawMeat, 1 }
            }
        };

        public static readonly FoodDefinition FISHMEAT_DEFINITION = new FoodDefinition()
        {
            Id = FISHMEAT_ID,
            Solid = 0.06f,
            Liquid = 0.04f,
            Protein = 22.0f,
            Carbohydrate = 0.0f,
            Lipids = 12.0f,
            Vitamins = 0.005f,
            Minerals = 0.045f,
            Calories = 206.0f,
            TimeToConsume = 100f,
            NeedConservation = true,
            StartConservationTime = BASE_RAW_MEAT_SPOIL_TIME,
            Name = LanguageProvider.GetEntry(LanguageEntries.FISHMEAT_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.FISHMEAT_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 15,
            OfferAmount = new Vector2I(1500, 4500),
            OrderAmount = new Vector2I(500, 1500),
            AcquisitionAmount = new Vector2I(1000, 3000),
            DiseaseChance = new Dictionary<StatsConstants.DiseaseEffects, float>()
            {
                { StatsConstants.DiseaseEffects.Dysentery, 0.75f }
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.StaminaAmount,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = 25,
                    TimeToEffect = 5
                }
            },
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.GlubGlub, 1 }
            }
        };

        public static readonly FoodDefinition NOBLEFISHMEAT_DEFINITION = new FoodDefinition()
        {
            Id = NOBLEFISHMEAT_ID,
            Solid = 0.05f,
            Liquid = 0.05f,
            Protein = 44.0f,
            Carbohydrate = 0.0f,
            Lipids = 24.0f,
            Vitamins = 0.010f,
            Minerals = 0.090f,
            Calories = 412.0f,
            TimeToConsume = 160f,
            NeedConservation = true,
            StartConservationTime = BASE_RAW_MEAT_SPOIL_TIME,
            Name = LanguageProvider.GetEntry(LanguageEntries.NOBLEFISHMEAT_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.NOBLEFISHMEAT_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 25,
            OfferAmount = new Vector2I(1500, 4500),
            OrderAmount = new Vector2I(500, 1500),
            AcquisitionAmount = new Vector2I(1000, 3000),
            DiseaseChance = new Dictionary<StatsConstants.DiseaseEffects, float>()
            {
                { StatsConstants.DiseaseEffects.Dysentery, 0.75f }
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Health,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = -25,
                    TimeToEffect = 5
                }
            },
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.GlubGlub, 1 }
            }
        };

        public static readonly FoodDefinition CONCENTRATEDFAT_DEFINITION = new FoodDefinition()
        {
            Id = CONCENTRATEDFAT_ID,
            Solid = 1.0f,
            Liquid = 0.0f,
            Protein = 0.0f,
            Carbohydrate = 0.0f,
            Lipids = 1000.0f,
            Vitamins = 0.0f,
            Minerals = 0.0f,
            Calories = 0.0f,
            TimeToConsume = 600f,
            DefinitionType = FoodDefinition.FoodDefinitionType.Ore,
            Name = LanguageProvider.GetEntry(LanguageEntries.CONCENTRATEDFAT_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.CONCENTRATEDFAT_DESCRIPTION),
            SimpleDescription = true,
            MinimalPricePerUnit = 5
        };

        public static readonly FoodDefinition CONCENTRATEDPROTEIN_DEFINITION = new FoodDefinition()
        {
            Id = CONCENTRATEDPROTEIN_ID,
            Solid = 1.0f,
            Liquid = 0.0f,
            Protein = 1000.0f,
            Carbohydrate = 0.0f,
            Lipids = 0.0f,
            Vitamins = 0.0f,
            Minerals = 0.0f,
            Calories = 0.0f,
            TimeToConsume = 600f,
            DefinitionType = FoodDefinition.FoodDefinitionType.Ore,
            Name = LanguageProvider.GetEntry(LanguageEntries.CONCENTRATEDPROTEIN_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.CONCENTRATEDPROTEIN_DESCRIPTION),
            SimpleDescription = true,
            MinimalPricePerUnit = 5
        };

        public static readonly FoodDefinition CONCENTRATEDVITAMIN_DEFINITION = new FoodDefinition()
        {
            Id = CONCENTRATEDVITAMIN_ID,
            Solid = 1.0f,
            Liquid = 0.0f,
            Protein = 0.0f,
            Carbohydrate = 0.0f,
            Lipids = 0.0f,
            Vitamins = 10.0f,
            Minerals = 0.0f,
            Calories = 0.0f,
            TimeToConsume = 600f,
            DefinitionType = FoodDefinition.FoodDefinitionType.Ore,
            Name = LanguageProvider.GetEntry(LanguageEntries.CONCENTRATEDVITAMIN_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.CONCENTRATEDVITAMIN_DESCRIPTION),
            SimpleDescription = true,
            MinimalPricePerUnit = 5
        };

        public static Dictionary<UniqueEntityId, FoodDefinition> FOOD_DEFINITIONS = new Dictionary<UniqueEntityId, FoodDefinition>()
        {
            { APPLE_ID, APPLE_DEFINITION },
            { BROCCOLI_ID, BROCCOLI_DEFINITION },
            { BEETROOT_ID, BEETROOT_DEFINITION },
            { CAROOT_ID, CAROOT_DEFINITION },
            { SHIITAKE_ID, SHIITAKE_DEFINITION },
            { CHAMPIGNONS_ID, CHAMPIGNONS_DEFINITION },
            { AMANITAMUSCARIA_ID, AMANITAMUSCARIA_DEFINITION },
            { TOMATO_ID, TOMATO_DEFINITION },
            { CEREAL_ID, CEREAL_DEFINITION },
            { WHEATSACK_ID, WHEATSACK_DEFINITION },
            { COFFEESACK_ID, COFFEESACK_DEFINITION },
            { ItensConstants.ICE_ID, ICE_DEFINITION },
            { ItensConstants.SPOILED_MATERIAL_ID, ORGANIC_DEFINITION },
            { ItensConstants.CARBON_INGOT_ID, CARBON_DEFINITION },
            { MILK_ID, MILK_DEFINITION },
            { MEAT_ID, MEAT_DEFINITION },
            { ALIEN_MEAT_ID, ALIENMEAT_DEFINITION },
            { CHICKENMEAT_ID, CHICKENMEAT_DEFINITION },
            { BACON_ID, BACON_DEFINITION },
            { NOBLE_MEAT_ID, NOBLE_MEAT_DEFINITION },
            { ALIEN_NOBLE_MEAT_ID, ALIEN_NOBLE_MEAT_DEFINITION },
            { EGG_ID, EGG_DEFINITION },
            { ALIEN_EGG_ID, ALIEN_EGG_DEFINITION },
            { SHRIMPMEAT_ID, SHRIMPMEAT_DEFINITION },
            { FISHMEAT_ID, FISHMEAT_DEFINITION },
            { NOBLEFISHMEAT_ID, NOBLEFISHMEAT_DEFINITION },
            { CONCENTRATEDFAT_ID, CONCENTRATEDFAT_DEFINITION },
            { CONCENTRATEDPROTEIN_ID, CONCENTRATEDPROTEIN_DEFINITION },
            { CONCENTRATEDVITAMIN_ID, CONCENTRATEDVITAMIN_DEFINITION }
        };

        public static readonly FoodRecipeDefinition WATER_FLASK_SMALL_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.WATER_FLASK_SMALL_ID,
                Ammount = 1
            },
            RecipeName = "Water_Flask_Small_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Mixing,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.FLASK_SMALL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.ICE_ID,
                    Ammount = 0.125f
                }
            },
            ProductionTime = 1.28f,
            Name = LanguageProvider.GetEntry(LanguageEntries.WATER_FLASK_SMALL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.WATER_FLASK_SMALL_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 50,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300),
            CureDisease = new List<StatsConstants.DiseaseEffects>()
            {
                StatsConstants.DiseaseEffects.Hyperthermia
            },
            TemperatureEffects = new Dictionary<StatsConstants.TemperatureEffects, int>()
            {
                { StatsConstants.TemperatureEffects.Overheating, -1 },
                { StatsConstants.TemperatureEffects.LesserResistenceToHot, 1 }
            }
        };

        public static readonly FoodRecipeDefinition WATER_FLASK_MEDIUM_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.WATER_FLASK_MEDIUM_ID,
                Ammount = 1
            },
            RecipeName = "Water_Flask_Medium_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Mixing,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.FLASK_MEDIUM_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.ICE_ID,
                    Ammount = 0.25f
                }
            },
            ProductionTime = 2.56f,
            Name = LanguageProvider.GetEntry(LanguageEntries.WATER_FLASK_MEDIUM_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.WATER_FLASK_MEDIUM_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 100,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300),
            CureDisease = new List<StatsConstants.DiseaseEffects>()
            {
                StatsConstants.DiseaseEffects.Hyperthermia
            },
            TemperatureEffects = new Dictionary<StatsConstants.TemperatureEffects, int>()
            {
                { StatsConstants.TemperatureEffects.Overheating, -1 },
                { StatsConstants.TemperatureEffects.ResistenceToHot, 1 }
            }
        };

        public static readonly FoodRecipeDefinition WATER_FLASK_BIG_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.WATER_FLASK_BIG_ID,
                Ammount = 1
            },
            RecipeName = "Water_Flask_Big_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Mixing,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.FLASK_BIG_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.ICE_ID,
                    Ammount = 0.5f
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.WATER_FLASK_BIG_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.WATER_FLASK_BIG_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 150,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300),
            CureDisease = new List<StatsConstants.DiseaseEffects>()
            {
                StatsConstants.DiseaseEffects.Hyperthermia
            },
            TemperatureEffects = new Dictionary<StatsConstants.TemperatureEffects, int>()
            {
                { StatsConstants.TemperatureEffects.Overheating, -1 },
                { StatsConstants.TemperatureEffects.OnFire, -1 },
                { StatsConstants.TemperatureEffects.GreaterResistenceToHot, 1 }
            }
        };

        public static readonly FoodRecipeDefinition APPLE_JUICE_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = APPLE_JUICE_ID,
                Ammount = 1
            },
            RecipeName = "AppleJuice_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Processing,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.FLASK_BIG_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WATER_FLASK_MEDIUM_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = APPLE_ID,
                    Ammount = 4
                }
            },
            ProductionTime = 2.56f,
            Name = LanguageProvider.GetEntry(LanguageEntries.APPLE_JUICE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.APPLE_JUICE_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 200,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300),
            CureDisease = new List<StatsConstants.DiseaseEffects>()
            {
                StatsConstants.DiseaseEffects.Hyperthermia
            },
            TemperatureEffects = new Dictionary<StatsConstants.TemperatureEffects, int>()
            {
                { StatsConstants.TemperatureEffects.Overheating, -1 },
                { StatsConstants.TemperatureEffects.ResistenceToHot, 1 }
            },
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.RefreshingJuice, 1 }
            }
        };

        public static readonly FoodRecipeDefinition SODA_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = SODA_ID,
                Ammount = 4
            },
            RecipeName = "ClangCola",
            Preparation = FoodRecipeDefinition.RecipePreparationType.IndustrialProcessing,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RecipientConstants.ALUMINUMCAN_ID,
                    Ammount = 4
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = APPLE_JUICE_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.SODA_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.SODA_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 50,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300),
            CureDisease = new List<StatsConstants.DiseaseEffects>()
            {
                StatsConstants.DiseaseEffects.Hyperthermia
            },
            TemperatureEffects = new Dictionary<StatsConstants.TemperatureEffects, int>()
            {
                { StatsConstants.TemperatureEffects.Overheating, -1 },
                { StatsConstants.TemperatureEffects.LesserResistenceToHot, 1 }
            },
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.Bubbly, 1 }
            }
        };

        public static readonly FoodRecipeDefinition COFFEE_CAN_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = COFFEE_CAN_ID,
                Ammount = 4
            },
            RecipeName = "CosmicCoffee",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RecipientConstants.ALUMINUMCAN_ID,
                    Ammount = 4
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WATER_FLASK_BIG_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = COFFEESACK_ID,
                    Ammount = 0.4f
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.COFFEE_CAN_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.COFFEE_CAN_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 50,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300),
            CureDisease = new List<StatsConstants.DiseaseEffects>()
            {
                StatsConstants.DiseaseEffects.Hypothermia
            },
            TemperatureEffects = new Dictionary<StatsConstants.TemperatureEffects, int>()
            {
                { StatsConstants.TemperatureEffects.Cold, -1 },
                { StatsConstants.TemperatureEffects.Frosty, -1 },
                { StatsConstants.TemperatureEffects.ResistenceToCold, 1 }
            },
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.EyesOpen, 1 }
            }
        };

        public static readonly FoodRecipeDefinition DOUGH_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = DOUGH_ID,
                Ammount = 2
            },
            RecipeName = "Dough_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Mixing,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = MILK_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = WHEATSACK_ID,
                    Ammount = 0.5f
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = EGG_ID,
                    Ammount = 4
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.DOUGH_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.DOUGH_DESCRIPTION),
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.ViscousAndDelicious, 1 }
            }
        };

        public static readonly FoodRecipeDefinition ALIEN_DOUGH_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ALIEN_DOUGH_ID,
                Ammount = 2
            },
            RecipeName = "AlienDough_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Mixing,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = MILK_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = WHEATSACK_ID,
                    Ammount = 0.5f
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ALIEN_EGG_ID,
                    Ammount = 4
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ALIEN_DOUGH_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ALIEN_DOUGH_DESCRIPTION),
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.ViscousAndDelicious, 1 }
            }
        };

        public static readonly FoodRecipeDefinition CAKEDOUGH_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = CAKEDOUGH_ID,
                Ammount = 2
            },
            RecipeName = "CakeDough_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Mixing,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = MILK_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = WHEATSACK_ID,
                    Ammount = 0.25f
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = EGG_ID,
                    Ammount = 2
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.CAKEDOUGH_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.CAKEDOUGH_DESCRIPTION),
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.ViscousAndDelicious, 1 }
            }
        };

        public static readonly FoodRecipeDefinition ALIEN_CAKEDOUGH_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ALIEN_CAKEDOUGH_ID,
                Ammount = 2
            },
            RecipeName = "AlienCakeDough_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Mixing,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = MILK_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = WHEATSACK_ID,
                    Ammount = 0.25f
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ALIEN_EGG_ID,
                    Ammount = 2
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ALIEN_CAKEDOUGH_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ALIEN_CAKEDOUGH_DESCRIPTION),
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.ViscousAndDelicious, 1 }
            }
        };

        public static readonly FoodRecipeDefinition RAW_BROCCOLI_BOWL_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = RAW_BROCCOLI_BOWL_ID,
                Ammount = 1
            },
            RecipeName = "RawBroccoliBowl_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cutting,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RecipientConstants.BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = BROCCOLI_ID,
                    Ammount = 2
                }
            },
            ProductionTime = 2.56f,
            Name = LanguageProvider.GetEntry(LanguageEntries.RAW_BROCCOLI_BOWL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.RAW_BROCCOLI_BOWL_DESCRIPTION),
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.RawVegetable, 1 }
            }
        };

        public static readonly FoodRecipeDefinition RAW_CARROT_BOWL_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = RAW_CARROT_BOWL_ID,
                Ammount = 1
            },
            RecipeName = "RawCarrotBowl_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cutting,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RecipientConstants.BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = CAROOT_ID,
                    Ammount = 5
                }
            },
            ProductionTime = 2.56f,
            Name = LanguageProvider.GetEntry(LanguageEntries.RAW_CARROT_BOWL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.RAW_CARROT_BOWL_DESCRIPTION),
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.RawVegetable, 1 }
            }
        };

        public static readonly FoodRecipeDefinition RAW_BEETROOT_BOWL_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = RAW_BEETROOT_BOWL_ID,
                Ammount = 1
            },
            RecipeName = "RawBeetrootBowl_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cutting,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RecipientConstants.BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = BEETROOT_ID,
                    Ammount = 5
                }
            },
            ProductionTime = 2.56f,
            Name = LanguageProvider.GetEntry(LanguageEntries.RAW_BEETROOT_BOWL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.RAW_BEETROOT_BOWL_DESCRIPTION),
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.RawVegetable, 1 }
            }
        };

        public static readonly FoodRecipeDefinition RAW_MEAT_BOWL_RECIPE_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = RAW_MEAT_BOWL_ID,
                Ammount = 1
            },
            RecipeName = "RawMeatBowl_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cutting,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RecipientConstants.BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = MEAT_ID,
                    Ammount = 2
                }
            },
            ProductionTime = 2.56f,
            Name = LanguageProvider.GetEntry(LanguageEntries.RAW_MEAT_BOWL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.RAW_MEAT_BOWL_DESCRIPTION),
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.RawMeat, 1 }
            }
        };

        public static readonly FoodRecipeDefinition RAW_ALIEN_MEAT_BOWL_RECIPE_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = RAW_ALIEN_MEAT_BOWL_ID,
                Ammount = 1
            },
            RecipeName = "RawAlienMeatBowl_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cutting,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RecipientConstants.BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ALIEN_MEAT_ID,
                    Ammount = 2
                }
            },
            ProductionTime = 2.56f,
            Name = LanguageProvider.GetEntry(LanguageEntries.RAW_ALIEN_MEAT_BOWL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.RAW_ALIEN_MEAT_BOWL_DESCRIPTION),
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.RawMeat, 1 }
            }
        };

        public static readonly FoodRecipeDefinition RAW_NOBLE_MEAT_BOWL_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = RAW_NOBLE_MEAT_BOWL_ID,
                Ammount = 1
            },
            RecipeName = "RawNobleMeatBowl_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cutting,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RecipientConstants.BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = NOBLE_MEAT_ID,
                    Ammount = 2
                }
            },
            ProductionTime = 2.56f,
            Name = LanguageProvider.GetEntry(LanguageEntries.RAW_NOBLE_MEAT_BOWL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.RAW_NOBLE_MEAT_BOWL_DESCRIPTION),
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.RawMeat, 1 }
            }
        };

        public static readonly FoodRecipeDefinition RAW_ALIEN_NOBLE_MEAT_BOWL_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = RAW_ALIEN_NOBLE_MEAT_BOWL_ID,
                Ammount = 1
            },
            RecipeName = "RawAlienNobleMeatBowl_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cutting,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RecipientConstants.BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ALIEN_NOBLE_MEAT_ID,
                    Ammount = 2
                }
            },
            ProductionTime = 2.56f,
            Name = LanguageProvider.GetEntry(LanguageEntries.RAW_ALIEN_NOBLE_MEAT_BOWL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.RAW_ALIEN_NOBLE_MEAT_BOWL_DESCRIPTION),
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.RawMeat, 1 }
            }
        };

        public static readonly FoodRecipeDefinition RAWFISHMEATBOWL_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = RAWFISHMEATBOWL_ID,
                Ammount = 1
            },
            RecipeName = "RawFishMeatBowl_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cutting,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RecipientConstants.BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = FISHMEAT_ID,
                    Ammount = 2
                }
            },
            ProductionTime = 2.56f,
            Name = LanguageProvider.GetEntry(LanguageEntries.RAWFISHMEATBOWL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.RAWFISHMEATBOWL_DESCRIPTION),
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.GlubGlub, 1 }
            }
        };

        public static readonly FoodRecipeDefinition RAWNOBLEFISHMEATBOWL_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = RAWNOBLEFISHMEATBOWL_ID,
                Ammount = 1
            },
            RecipeName = "RawNobleFishMeatBowl_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cutting,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RecipientConstants.BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = NOBLEFISHMEAT_ID,
                    Ammount = 2
                }
            },
            ProductionTime = 2.56f,
            Name = LanguageProvider.GetEntry(LanguageEntries.RAWNOBLEFISHMEATBOWL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.RAWNOBLEFISHMEATBOWL_DESCRIPTION),
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.GlubGlub, 1 }
            }
        };

        public static readonly FoodRecipeDefinition RAW_SAUSAGE_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = RAW_SAUSAGE_ID,
                Ammount = 1
            },
            RecipeName = "RawSausage_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Mixing,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RAW_MEAT_BOWL_ID,
                    Ammount = 2
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.RAW_SAUSAGE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.RAW_SAUSAGE_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 175,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300),
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.RawMeat, 1 }
            }
        };

        public static readonly FoodRecipeDefinition RAW_ALIEN_SAUSAGE_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = RAW_ALIEN_SAUSAGE_ID,
                Ammount = 1
            },
            RecipeName = "RawAlienSausage_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Mixing,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RAW_ALIEN_MEAT_BOWL_ID,
                    Ammount = 2
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.RAW_ALIEN_SAUSAGE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.RAW_ALIEN_SAUSAGE_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 175,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300),
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.RawMeat, 1 }
            }
        };

        public static readonly FoodRecipeDefinition ROAST_CHAMPIGNON_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ROAST_CHAMPIGNON_ID,
                Ammount = 1
            },
            RecipeName = "RoastChampignonMushrooms_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Baking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = CHAMPIGNONS_ID,
                    Ammount = 10
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ROAST_CHAMPIGNON_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ROAST_CHAMPIGNON_DESCRIPTION),
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.MariosParty, 1 }
            }
        };

        public static readonly FoodRecipeDefinition ROAST_SHIITAKE_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ROAST_SHIITAKE_ID,
                Ammount = 1
            },
            RecipeName = "RoastShiitakeMushrooms_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Baking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = SHIITAKE_ID,
                    Ammount = 10
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ROAST_SHIITAKE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ROAST_SHIITAKE_DESCRIPTION),
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.MariosParty, 1 }
            }
        };

        public static readonly FoodRecipeDefinition FRIED_EGG_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = FRIED_EGG_ID,
                Ammount = 1
            },
            RecipeName = "FriedEgg_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Frying,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = EGG_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 1.28f,
            Name = LanguageProvider.GetEntry(LanguageEntries.FRIED_EGG_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.FRIED_EGG_DESCRIPTION),
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.BreakingTheShell, 1 }
            }
        };

        public static readonly FoodRecipeDefinition FRIED_ALIEN_EGG_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = FRIED_ALIEN_EGG_ID,
                Ammount = 1
            },
            RecipeName = "FriedAlienEgg_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Frying,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ALIEN_EGG_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 1.28f,
            Name = LanguageProvider.GetEntry(LanguageEntries.FRIED_ALIEN_EGG_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.FRIED_ALIEN_EGG_DESCRIPTION),
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.BreakingTheShell, 1 }
            }
        };

        public static readonly FoodRecipeDefinition ROASTEDBACON_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ROASTEDBACON_ID,
                Ammount = 1
            },
            RecipeName = "RoastedBacon_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Baking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = BACON_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ROASTEDBACON_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ROASTEDBACON_DESCRIPTION),
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.BreakfastOfChampions, 1 }
            }
        };

        public static readonly FoodRecipeDefinition ROASTEDCHICKEN_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ROASTEDCHICKEN_ID,
                Ammount = 1
            },
            RecipeName = "RoastedChicken_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Baking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = CHICKENMEAT_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ROASTEDCHICKEN_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ROASTEDCHICKEN_DESCRIPTION),
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.PoPoPo, 1 }
            }
        };

        public static readonly FoodRecipeDefinition ROASTED_SAUSAGE_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ROASTED_SAUSAGE_ID,
                Ammount = 1
            },
            RecipeName = "RoastedSausage_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Baking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RAW_SAUSAGE_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ROASTED_SAUSAGE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ROASTED_SAUSAGE_DESCRIPTION),
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.SooBig, 1 }
            }
        };

        public static readonly FoodRecipeDefinition ROASTED_ALIEN_SAUSAGE_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ROASTED_ALIEN_SAUSAGE_ID,
                Ammount = 1
            },
            RecipeName = "RoastedAlienSausage_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Baking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RAW_ALIEN_SAUSAGE_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ROASTED_ALIEN_SAUSAGE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ROASTED_ALIEN_SAUSAGE_DESCRIPTION),
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.SooBig, 1 }
            }
        };

        public static readonly FoodRecipeDefinition ROASTED_MEAT_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ROASTED_MEAT_ID,
                Ammount = 1
            },
            RecipeName = "RoastedMeat_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Baking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = MEAT_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ROASTED_MEAT_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ROASTED_MEAT_DESCRIPTION),
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.Barbecue, 1 }
            }
        };

        public static readonly FoodRecipeDefinition ROASTED_ALIEN_MEAT_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ROASTED_ALIEN_MEAT_ID,
                Ammount = 1
            },
            RecipeName = "RoastedAlienMeat_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Baking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ALIEN_MEAT_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ROASTED_ALIEN_MEAT_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ROASTED_ALIEN_MEAT_DESCRIPTION),
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.Barbecue, 1 }
            }
        };

        public static readonly FoodRecipeDefinition CEREALBAR_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = CEREALBAR_ID,
                Ammount = 1
            },
            RecipeName = "CerealBar_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.IndustrialProcessing,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = CEREAL_ID,
                    Ammount = 0.1f
                }
            },
            ProductionTime = 2.56f,
            Name = LanguageProvider.GetEntry(LanguageEntries.CEREALBAR_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.CEREALBAR_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 8,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300),
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.TastyLikeSawdust, 1 }
            }
        };

        public static readonly FoodRecipeDefinition WATERBREAD_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = WATERBREAD_ID,
                Ammount = 1
            },
            RecipeName = "WaterBread_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Baking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WATER_FLASK_SMALL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = WHEATSACK_ID,
                    Ammount = 0.25f
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.WATERBREAD_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.WATERBREAD_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 10,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300),
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.Blessed, 1 }
            }
        };

        public static readonly FoodRecipeDefinition BREAD_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = BREAD_ID,
                Ammount = 2
            },
            RecipeName = "Bread_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Baking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = DOUGH_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.BREAD_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.BREAD_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 15,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300),
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.Sanctified, 1 }
            }
        };

        public static readonly FoodRecipeDefinition ALIEN_BREAD_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ALIEN_BREAD_ID,
                Ammount = 2
            },
            RecipeName = "AlienBread_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Baking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ALIEN_DOUGH_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ALIEN_BREAD_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ALIEN_BREAD_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 15,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300),
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.Sanctified, 1 }
            }
        };

        public static readonly FoodRecipeDefinition PASTA_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = PASTA_ID,
                Ammount = 1
            },
            RecipeName = "Pasta_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = DOUGH_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = WHEATSACK_ID,
                    Ammount = 0.1f
                }
            },
            ProductionTime = 2.56f,
            Name = LanguageProvider.GetEntry(LanguageEntries.PASTA_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.PASTA_DESCRIPTION),
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.MamaMia, 1 }
            }
        };

        public static readonly FoodRecipeDefinition ALIEN_PASTA_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ALIEN_PASTA_ID,
                Ammount = 1
            },
            RecipeName = "AlienPasta_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ALIEN_DOUGH_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = WHEATSACK_ID,
                    Ammount = 0.1f
                }
            },
            ProductionTime = 2.56f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ALIEN_PASTA_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ALIEN_PASTA_DESCRIPTION),
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.MamaMia, 1 }
            }
        };

        public static readonly FoodRecipeDefinition VEGETABLEPASTA_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = VEGETABLEPASTA_ID,
                Ammount = 2
            },
            RecipeName = "VegetablePasta_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = PASTA_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = TOMATO_ID,
                    Ammount = 2
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RAW_BROCCOLI_BOWL_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.VEGETABLEPASTA_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.VEGETABLEPASTA_DESCRIPTION),
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.HooMamaMia, 1 }
            }
        };

        public static readonly FoodRecipeDefinition VEGETABLEALIENPASTA_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = VEGETABLEALIENPASTA_ID,
                Ammount = 2
            },
            RecipeName = "VegetableAlienPasta_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ALIEN_PASTA_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = TOMATO_ID,
                    Ammount = 2
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RAW_BROCCOLI_BOWL_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.VEGETABLEALIENPASTA_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.VEGETABLEALIENPASTA_DESCRIPTION),
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.HooMamaMia, 1 }
            }
        };

        public static readonly FoodRecipeDefinition MEATPASTA_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = MEATPASTA_ID,
                Ammount = 2
            },
            RecipeName = "MeatPasta_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = PASTA_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = TOMATO_ID,
                    Ammount = 2
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RAW_MEAT_BOWL_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.MEATPASTA_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.MEATPASTA_DESCRIPTION),
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.WowMamaMia, 1 }
            }
        };

        public static readonly FoodRecipeDefinition ALIENMEATPASTA_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ALIENMEATPASTA_ID,
                Ammount = 2
            },
            RecipeName = "AlienMeatPasta_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ALIEN_PASTA_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = TOMATO_ID,
                    Ammount = 2
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RAW_ALIEN_MEAT_BOWL_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ALIENMEATPASTA_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ALIENMEATPASTA_DESCRIPTION),
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.WowMamaMia, 1 }
            }
        };

        public static readonly FoodRecipeDefinition CHEESE_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = CHEESE_ID,
                Ammount = 1
            },
            RecipeName = "Cheese_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Drying,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = MILK_ID,
                    Ammount = 2
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.CHEESE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.CHEESE_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 125,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300),
            FoodEffects2 = new Dictionary<FoodEffectConstants.FoodEffectsPart2, int>()
            {
                { FoodEffectConstants.FoodEffectsPart2.MouseChoice, 1 }
            }
        };

        public static readonly FoodRecipeDefinition SALAD_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = SALAD_ID,
                Ammount = 3
            },
            RecipeName = "Salad_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Processing,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = TOMATO_ID,
                    Ammount = 3
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RAW_BROCCOLI_BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RAW_CARROT_BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RAW_BEETROOT_BOWL_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.SALAD_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.SALAD_DESCRIPTION),
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.SafeVegan, 1 }
            }
        };

        public static readonly FoodRecipeDefinition VEGETABLE_SOUP_BOWL_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = VEGETABLE_SOUP_BOWL_ID,
                Ammount = 2
            },
            RecipeName = "VegetableSoupBowl_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WATER_FLASK_MEDIUM_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RAW_CARROT_BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RAW_BEETROOT_BOWL_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.VEGETABLE_SOUP_BOWL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.VEGETABLE_SOUP_BOWL_DESCRIPTION),
            CureDisease = new List<StatsConstants.DiseaseEffects>()
            {
                StatsConstants.DiseaseEffects.Hypothermia
            },
            TemperatureEffects = new Dictionary<StatsConstants.TemperatureEffects, int>()
            {
                { StatsConstants.TemperatureEffects.Cold, -1 },
                { StatsConstants.TemperatureEffects.Frosty, -1 },
                { StatsConstants.TemperatureEffects.ResistenceToCold, 1 }
            },
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.WinterIsComing, 1 }
            }
        };

        public static readonly FoodRecipeDefinition STEW_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = STEW_ID,
                Ammount = 2
            },
            RecipeName = "StewBowl_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WATER_FLASK_MEDIUM_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RAW_MEAT_BOWL_ID,
                    Ammount = 2
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.STEW_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.STEW_DESCRIPTION),
            TemperatureEffects = new Dictionary<StatsConstants.TemperatureEffects, int>()
            {
                { StatsConstants.TemperatureEffects.Cold, -1 },
                { StatsConstants.TemperatureEffects.LesserResistenceToCold, 1 }
            },
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.MomsFood, 1 }
            }
        };

        public static readonly FoodRecipeDefinition ALIEN_STEW_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ALIEN_STEW_ID,
                Ammount = 2
            },
            RecipeName = "AlienStewBowl_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WATER_FLASK_MEDIUM_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RAW_ALIEN_MEAT_BOWL_ID,
                    Ammount = 2
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ALIEN_STEW_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ALIEN_STEW_DESCRIPTION),
            TemperatureEffects = new Dictionary<StatsConstants.TemperatureEffects, int>()
            {
                { StatsConstants.TemperatureEffects.Cold, -1 },
                { StatsConstants.TemperatureEffects.LesserResistenceToCold, 1 }
            },
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.MomsFood, 1 }
            }
        };

        public static readonly FoodRecipeDefinition MEAT_VEGETABLES_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = MEAT_VEGETABLES_ID,
                Ammount = 2
            },
            RecipeName = "MeatVegetablesBowl_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WATER_FLASK_MEDIUM_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = NOBLE_MEAT_ID,
                    Ammount = 2
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RAW_CARROT_BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RAW_BEETROOT_BOWL_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.MEAT_VEGETABLES_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.MEAT_VEGETABLES_DESCRIPTION),
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.BalancedDiet, 1 }
            }
        };

        public static readonly FoodRecipeDefinition ALIEN_MEAT_VEGETABLES_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ALIEN_MEAT_VEGETABLES_ID,
                Ammount = 2
            },
            RecipeName = "AlienMeatVegetablesBowl_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WATER_FLASK_MEDIUM_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ALIEN_NOBLE_MEAT_ID,
                    Ammount = 2
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RAW_CARROT_BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RAW_BEETROOT_BOWL_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ALIEN_MEAT_VEGETABLES_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ALIEN_MEAT_VEGETABLES_DESCRIPTION),
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.BalancedDiet, 1 }
            }
        };

        public static readonly FoodRecipeDefinition MEATLOAF_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = MEATLOAF_ID,
                Ammount = 2
            },
            RecipeName = "MeatloafBowl_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WATER_FLASK_MEDIUM_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RAW_MEAT_BOWL_ID,
                    Ammount = 2
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RAW_NOBLE_MEAT_BOWL_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.MEATLOAF_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.MEATLOAF_DESCRIPTION),
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.SundayFood, 1 }
            }
        };

        public static readonly FoodRecipeDefinition ALIENMEATLOAF_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ALIENMEATLOAF_ID,
                Ammount = 2
            },
            RecipeName = "AlienMeatloafBowl_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WATER_FLASK_MEDIUM_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RAW_ALIEN_MEAT_BOWL_ID,
                    Ammount = 2
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RAW_ALIEN_NOBLE_MEAT_BOWL_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ALIENMEATLOAF_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ALIENMEATLOAF_DESCRIPTION),
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.SundayFood, 1 }
            }
        };

        public static readonly FoodRecipeDefinition MEAT_SOUP_BOWL_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = MEAT_SOUP_BOWL_ID,
                Ammount = 2
            },
            RecipeName = "MeatSoupBowl_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WATER_FLASK_MEDIUM_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RAW_CARROT_BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RAW_BEETROOT_BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RAW_NOBLE_MEAT_BOWL_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.MEAT_SOUP_BOWL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.MEAT_SOUP_BOWL_DESCRIPTION),
            CureDisease = new List<StatsConstants.DiseaseEffects>()
            {
                StatsConstants.DiseaseEffects.Hypothermia
            },
            TemperatureEffects = new Dictionary<StatsConstants.TemperatureEffects, int>()
            {
                { StatsConstants.TemperatureEffects.Cold, -1 },
                { StatsConstants.TemperatureEffects.Frosty, -1 },
                { StatsConstants.TemperatureEffects.GreaterResistenceToCold, 1 }
            },
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.WinterProtection, 1 }
            }
        };

        public static readonly FoodRecipeDefinition ALIEN_MEAT_SOUP_BOWL_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ALIEN_MEAT_SOUP_BOWL_ID,
                Ammount = 2
            },
            RecipeName = "AlienMeatSoupBowl_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WATER_FLASK_MEDIUM_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RAW_CARROT_BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RAW_BEETROOT_BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RAW_ALIEN_NOBLE_MEAT_BOWL_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ALIEN_MEAT_SOUP_BOWL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ALIEN_MEAT_SOUP_BOWL_DESCRIPTION),
            CureDisease = new List<StatsConstants.DiseaseEffects>()
            {
                StatsConstants.DiseaseEffects.Hypothermia
            },
            TemperatureEffects = new Dictionary<StatsConstants.TemperatureEffects, int>()
            {
                { StatsConstants.TemperatureEffects.Cold, -1 },
                { StatsConstants.TemperatureEffects.Frosty, -1 },
                { StatsConstants.TemperatureEffects.GreaterResistenceToCold, 1 }
            },
            FoodEffects = new Dictionary<FoodEffectConstants.FoodEffects, int>()
            {
                { FoodEffectConstants.FoodEffects.WinterProtection, 1 }
            }
        };

        public static readonly FoodRecipeDefinition MUSHROOMPATE_BOWL_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = MUSHROOMPATE_BOWL_ID,
                Ammount = 2
            },
            RecipeName = "MushroomPate_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WATER_FLASK_MEDIUM_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RecipientConstants.BOWL_ID,
                    Ammount = 2
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = CHAMPIGNONS_ID,
                    Ammount = 10
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = SHIITAKE_ID,
                    Ammount = 10
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.MUSHROOMPATE_BOWL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.MUSHROOMPATE_BOWL_DESCRIPTION),
            CureDisease = new List<StatsConstants.DiseaseEffects>()
            {
                StatsConstants.DiseaseEffects.Hypothermia
            },
            TemperatureEffects = new Dictionary<StatsConstants.TemperatureEffects, int>()
            {
                { StatsConstants.TemperatureEffects.Cold, -1 },
                { StatsConstants.TemperatureEffects.LesserResistenceToCold, 1 }
            },
            FoodEffects2 = new Dictionary<FoodEffectConstants.FoodEffectsPart2, int>()
            {
                { FoodEffectConstants.FoodEffectsPart2.GoombasEnd, 1 }
            }
        };

        public static readonly FoodRecipeDefinition MEAT_MUSHROOMS_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = MEAT_MUSHROOMS_ID,
                Ammount = 2
            },
            RecipeName = "MeatMushroom_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WATER_FLASK_MEDIUM_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = NOBLE_MEAT_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = CHAMPIGNONS_ID,
                    Ammount = 10
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = SHIITAKE_ID,
                    Ammount = 10
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RecipientConstants.BOWL_ID,
                    Ammount = 2
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.MEAT_MUSHROOMS_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.MEAT_MUSHROOMS_DESCRIPTION),
            FoodEffects2 = new Dictionary<FoodEffectConstants.FoodEffectsPart2, int>()
            {
                { FoodEffectConstants.FoodEffectsPart2.GoombasProtection, 1 }
            }
        };

        public static readonly FoodRecipeDefinition ALIEN_MEAT_MUSHROOMS_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ALIEN_MEAT_MUSHROOMS_ID,
                Ammount = 2
            },
            RecipeName = "AlienMeatMushroom_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WATER_FLASK_MEDIUM_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ALIEN_NOBLE_MEAT_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = CHAMPIGNONS_ID,
                    Ammount = 10
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = SHIITAKE_ID,
                    Ammount = 10
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RecipientConstants.BOWL_ID,
                    Ammount = 2
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ALIEN_MEAT_MUSHROOMS_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ALIEN_MEAT_MUSHROOMS_DESCRIPTION),
            FoodEffects2 = new Dictionary<FoodEffectConstants.FoodEffectsPart2, int>()
            {
                { FoodEffectConstants.FoodEffectsPart2.GoombasProtection, 1 }
            }
        };

        public static readonly FoodRecipeDefinition SANDWICH_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = SANDWICH_ID,
                Ammount = 3
            },
            RecipeName = "Sandwich_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Processing,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = TOMATO_ID,
                    Ammount = 3
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = BREAD_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = CHEESE_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ROASTED_SAUSAGE_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.SANDWICH_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.SANDWICH_DESCRIPTION),
            FoodEffects2 = new Dictionary<FoodEffectConstants.FoodEffectsPart2, int>()
            {
                { FoodEffectConstants.FoodEffectsPart2.BestFriend, 1 }
            }
        };

        public static readonly FoodRecipeDefinition ALIEN_SANDWICH_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ALIEN_SANDWICH_ID,
                Ammount = 3
            },
            RecipeName = "AlienSandwich_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Processing,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = TOMATO_ID,
                    Ammount = 3
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ALIEN_BREAD_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = CHEESE_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ROASTED_ALIEN_SAUSAGE_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ALIEN_SANDWICH_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ALIEN_SANDWICH_DESCRIPTION),
            FoodEffects2 = new Dictionary<FoodEffectConstants.FoodEffectsPart2, int>()
            {
                { FoodEffectConstants.FoodEffectsPart2.BestFriend, 1 }
            }
        };

        public static readonly FoodRecipeDefinition ROASTEDSHRIMP_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ROASTEDSHRIMP_ID,
                Ammount = 1
            },
            RecipeName = "RoastedShrimp_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Frying,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = SHRIMPMEAT_ID,
                    Ammount = 10
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ROASTEDSHRIMP_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ROASTEDSHRIMP_DESCRIPTION),
            FoodEffects2 = new Dictionary<FoodEffectConstants.FoodEffectsPart2, int>()
            {
                { FoodEffectConstants.FoodEffectsPart2.SeaCockroach, 1 }
            }
        };

        public static readonly FoodRecipeDefinition ROASTEDFISH_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ROASTEDFISH_ID,
                Ammount = 1
            },
            RecipeName = "RoastedFish_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Baking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = FISHMEAT_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ROASTEDFISH_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ROASTEDFISH_DESCRIPTION),
            FoodEffects2 = new Dictionary<FoodEffectConstants.FoodEffectsPart2, int>()
            {
                { FoodEffectConstants.FoodEffectsPart2.CampFeeling, 1 }
            }
        };

        public static readonly FoodRecipeDefinition ROASTEDNOBLEFISH_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ROASTEDNOBLEFISH_ID,
                Ammount = 1
            },
            RecipeName = "RoastedNobleFish_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Baking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = NOBLEFISHMEAT_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ROASTEDNOBLEFISH_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ROASTEDNOBLEFISH_DESCRIPTION),
            FoodEffects2 = new Dictionary<FoodEffectConstants.FoodEffectsPart2, int>()
            {
                { FoodEffectConstants.FoodEffectsPart2.ExplosiveJuiciness, 1 }
            }
        };

        public static readonly FoodRecipeDefinition FISHMUSHROOM_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = FISHMUSHROOM_ID,
                Ammount = 2
            },
            RecipeName = "FishMushroom_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WATER_FLASK_MEDIUM_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = NOBLEFISHMEAT_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = CHAMPIGNONS_ID,
                    Ammount = 10
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = SHIITAKE_ID,
                    Ammount = 10
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RecipientConstants.BOWL_ID,
                    Ammount = 2
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.FISHMUSHROOM_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.FISHMUSHROOM_DESCRIPTION),
            FoodEffects2 = new Dictionary<FoodEffectConstants.FoodEffectsPart2, int>()
            {
                { FoodEffectConstants.FoodEffectsPart2.GoombasBreath, 1 }
            }
        };

        public static readonly FoodRecipeDefinition FISHSOUPBOWL_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = FISHSOUPBOWL_ID,
                Ammount = 2
            },
            RecipeName = "FishSoupBowl_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WATER_FLASK_MEDIUM_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RAW_CARROT_BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RAW_BEETROOT_BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RAWNOBLEFISHMEATBOWL_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.FISHSOUPBOWL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.FISHSOUPBOWL_DESCRIPTION),
            CureDisease = new List<StatsConstants.DiseaseEffects>()
            {
                StatsConstants.DiseaseEffects.Hypothermia
            },
            TemperatureEffects = new Dictionary<StatsConstants.TemperatureEffects, int>()
            {
                { StatsConstants.TemperatureEffects.Cold, -1 },
                { StatsConstants.TemperatureEffects.Frosty, -1 },
                { StatsConstants.TemperatureEffects.GreaterResistenceToCold, 1 }
            },
            FoodEffects2 = new Dictionary<FoodEffectConstants.FoodEffectsPart2, int>()
            {
                { FoodEffectConstants.FoodEffectsPart2.WinterBreath, 1 }
            }
        };

        public static readonly FoodRecipeDefinition SHRIMPSOUPBOWL_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = SHRIMPSOUPBOWL_ID,
                Ammount = 2
            },
            RecipeName = "ShrimpSoupBowl_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WATER_FLASK_MEDIUM_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RAW_CARROT_BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RAW_BEETROOT_BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = SHRIMPMEAT_ID,
                    Ammount = 5
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RAWFISHMEATBOWL_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.SHRIMPSOUPBOWL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.SHRIMPSOUPBOWL_DESCRIPTION),
            CureDisease = new List<StatsConstants.DiseaseEffects>()
            {
                StatsConstants.DiseaseEffects.Hypothermia
            },
            TemperatureEffects = new Dictionary<StatsConstants.TemperatureEffects, int>()
            {
                { StatsConstants.TemperatureEffects.Cold, -1 },
                { StatsConstants.TemperatureEffects.Frosty, -1 },
                { StatsConstants.TemperatureEffects.ResistenceToCold, 1 }
            },
            FoodEffects2 = new Dictionary<FoodEffectConstants.FoodEffectsPart2, int>()
            {
                { FoodEffectConstants.FoodEffectsPart2.WinterBreath, 1 }
            }
        };

        public static readonly FoodRecipeDefinition APPLEPIE_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = APPLEPIE_ID,
                Ammount = 2
            },
            RecipeName = "ApplePie_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Baking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = CAKEDOUGH_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = APPLE_ID,
                    Ammount = 12f
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.APPLEPIE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.APPLEPIE_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 275,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300),
            FoodEffects2 = new Dictionary<FoodEffectConstants.FoodEffectsPart2, int>()
            {
                { FoodEffectConstants.FoodEffectsPart2.FingerLicking, 1 }
            }
        };

        public static readonly FoodRecipeDefinition ALIEN_APPLEPIE_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ALIEN_APPLEPIE_ID,
                Ammount = 2
            },
            RecipeName = "AlienApplePie_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Baking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ALIEN_CAKEDOUGH_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = APPLE_ID,
                    Ammount = 12f
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ALIEN_APPLEPIE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ALIEN_APPLEPIE_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 275,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300),
            FoodEffects2 = new Dictionary<FoodEffectConstants.FoodEffectsPart2, int>()
            {
                { FoodEffectConstants.FoodEffectsPart2.FingerLicking, 1 }
            }
        };

        public static readonly FoodRecipeDefinition CHICKENPIE_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = CHICKENPIE_ID,
                Ammount = 2
            },
            RecipeName = "ChickenPie_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Baking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = CAKEDOUGH_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = CHICKENMEAT_ID,
                    Ammount = 2
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = BACON_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.CHICKENPIE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.CHICKENPIE_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 250,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300),
            FoodEffects2 = new Dictionary<FoodEffectConstants.FoodEffectsPart2, int>()
            {
                { FoodEffectConstants.FoodEffectsPart2.MesmerizingSmell, 1 }
            }
        };

        public static readonly FoodRecipeDefinition ALIEN_CHICKENPIE_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ALIEN_CHICKENPIE_ID,
                Ammount = 2
            },
            RecipeName = "AlienChickenPie_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Baking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ALIEN_CAKEDOUGH_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = CHICKENMEAT_ID,
                    Ammount = 2
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = BACON_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ALIEN_CHICKENPIE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ALIEN_CHICKENPIE_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 250,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300),
            FoodEffects2 = new Dictionary<FoodEffectConstants.FoodEffectsPart2, int>()
            {
                { FoodEffectConstants.FoodEffectsPart2.MesmerizingSmell, 1 }
            }
        };

        public static readonly FoodRecipeDefinition FATPORRIDGE_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = FATPORRIDGE_ID,
                Ammount = 1
            },
            RecipeName = "FatPorridge_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WATER_FLASK_SMALL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RecipientConstants.BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = CONCENTRATEDFAT_ID,
                    Ammount = 0.15f
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.FATPORRIDGE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.FATPORRIDGE_DESCRIPTION),
            FoodEffects2 = new Dictionary<FoodEffectConstants.FoodEffectsPart2, int>()
            {
                { FoodEffectConstants.FoodEffectsPart2.TastyLikeButter, 1 }
            }
        };

        public static readonly FoodRecipeDefinition PROTEINBAR_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = PROTEINBAR_ID,
                Ammount = 1
            },
            RecipeName = "ProteinBar_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.IndustrialProcessing,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = CONCENTRATEDPROTEIN_ID,
                    Ammount = 0.075f
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = CEREAL_ID,
                    Ammount = 0.025f
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.PROTEINBAR_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.PROTEINBAR_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 45,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300),
            FoodEffects2 = new Dictionary<FoodEffectConstants.FoodEffectsPart2, int>()
            {
                { FoodEffectConstants.FoodEffectsPart2.TastyLikeBeefJerky, 1 }
            }
        };

        public static readonly FoodRecipeDefinition VITAMINPILLS_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = VITAMINPILLS_ID,
                Ammount = 1
            },
            RecipeName = "VitaminPills_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.IndustrialProcessing,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = CONCENTRATEDVITAMIN_ID,
                    Ammount = 0.1f
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.POLIETILENOGLICOL_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.VITAMINPILLS_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.VITAMINPILLS_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 475,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300),
            FoodEffects2 = new Dictionary<FoodEffectConstants.FoodEffectsPart2, int>()
            {
                { FoodEffectConstants.FoodEffectsPart2.ImprovedMetabolism, 1 }
            }
        };

        public static readonly FoodRecipeDefinition TOFU_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = TOFU_ID,
                Ammount = 1
            },
            RecipeName = "Tofu_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.SPOILED_MATERIAL_ID,
                    Ammount = 0.4f
                }
            },
            ProductionTime = 2.56f,
            Name = LanguageProvider.GetEntry(LanguageEntries.TOFU_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.TOFU_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 50,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300),
            FoodEffects2 = new Dictionary<FoodEffectConstants.FoodEffectsPart2, int>()
            {
                { FoodEffectConstants.FoodEffectsPart2.TastyLikePoop, 1 }
            }
        };

        public static readonly FoodRecipeDefinition MRE_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = MRE_ID,
                Ammount = 1
            },
            RecipeName = "Mre_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.SPOILED_MATERIAL_ID,
                    Ammount = 0.25f
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.CARBON_INGOT_ID,
                    Ammount = 0.15f
                }
            },
            ProductionTime = 2.56f,
            Name = LanguageProvider.GetEntry(LanguageEntries.MRE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.MRE_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 50,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300),
            FoodEffects2 = new Dictionary<FoodEffectConstants.FoodEffectsPart2, int>()
            {
                { FoodEffectConstants.FoodEffectsPart2.TastyLikeCharcoal, 1 }
            }
        };

        public static readonly Dictionary<UniqueEntityId, FoodRecipeDefinition> FOOD_RECIPES = new Dictionary<UniqueEntityId, FoodRecipeDefinition>()
        {
            { ItensConstants.WATER_FLASK_SMALL_ID, WATER_FLASK_SMALL_DEFINITION },
            { ItensConstants.WATER_FLASK_MEDIUM_ID, WATER_FLASK_MEDIUM_DEFINITION },
            { ItensConstants.WATER_FLASK_BIG_ID, WATER_FLASK_BIG_DEFINITION },
            { APPLE_JUICE_ID, APPLE_JUICE_DEFINITION },
            { TOFU_ID, TOFU_DEFINITION },
            { MRE_ID, MRE_DEFINITION },
            { SODA_ID, SODA_DEFINITION },
            { COFFEE_CAN_ID, COFFEE_CAN_DEFINITION },
            { DOUGH_ID, DOUGH_DEFINITION },
            { ALIEN_DOUGH_ID, ALIEN_DOUGH_DEFINITION },
            { CAKEDOUGH_ID, CAKEDOUGH_DEFINITION },
            { ALIEN_CAKEDOUGH_ID, ALIEN_CAKEDOUGH_DEFINITION },
            { RAW_BROCCOLI_BOWL_ID, RAW_BROCCOLI_BOWL_DEFINITION },
            { RAW_CARROT_BOWL_ID, RAW_CARROT_BOWL_DEFINITION },
            { RAW_BEETROOT_BOWL_ID, RAW_BEETROOT_BOWL_DEFINITION },
            { RAW_MEAT_BOWL_ID, RAW_MEAT_BOWL_RECIPE_DEFINITION },
            { RAW_ALIEN_MEAT_BOWL_ID, RAW_ALIEN_MEAT_BOWL_RECIPE_DEFINITION },
            { RAW_NOBLE_MEAT_BOWL_ID, RAW_NOBLE_MEAT_BOWL_DEFINITION },
            { RAW_ALIEN_NOBLE_MEAT_BOWL_ID, RAW_ALIEN_NOBLE_MEAT_BOWL_DEFINITION },
            { RAWFISHMEATBOWL_ID, RAWFISHMEATBOWL_DEFINITION },
            { RAWNOBLEFISHMEATBOWL_ID, RAWNOBLEFISHMEATBOWL_DEFINITION },
            { RAW_SAUSAGE_ID, RAW_SAUSAGE_DEFINITION },
            { RAW_ALIEN_SAUSAGE_ID, RAW_ALIEN_SAUSAGE_DEFINITION },
            { ROAST_CHAMPIGNON_ID, ROAST_CHAMPIGNON_DEFINITION },
            { ROAST_SHIITAKE_ID, ROAST_SHIITAKE_DEFINITION },
            { FRIED_EGG_ID, FRIED_EGG_DEFINITION },
            { FRIED_ALIEN_EGG_ID, FRIED_ALIEN_EGG_DEFINITION },
            { ROASTEDBACON_ID, ROASTEDBACON_DEFINITION },
            { ROASTEDCHICKEN_ID, ROASTEDCHICKEN_DEFINITION },
            { ROASTED_SAUSAGE_ID, ROASTED_SAUSAGE_DEFINITION },
            { ROASTED_ALIEN_SAUSAGE_ID, ROASTED_ALIEN_SAUSAGE_DEFINITION },
            { ROASTED_MEAT_ID, ROASTED_MEAT_DEFINITION },
            { ROASTED_ALIEN_MEAT_ID, ROASTED_ALIEN_MEAT_DEFINITION },
            { CEREALBAR_ID, CEREALBAR_DEFINITION },
            { WATERBREAD_ID, WATERBREAD_DEFINITION },
            { BREAD_ID, BREAD_DEFINITION },
            { ALIEN_BREAD_ID, ALIEN_BREAD_DEFINITION },
            { PASTA_ID, PASTA_DEFINITION },
            { ALIEN_PASTA_ID, ALIEN_PASTA_DEFINITION },
            { VEGETABLEPASTA_ID, VEGETABLEPASTA_DEFINITION },
            { VEGETABLEALIENPASTA_ID, VEGETABLEALIENPASTA_DEFINITION },
            { MEATPASTA_ID, MEATPASTA_DEFINITION },
            { ALIENMEATPASTA_ID, ALIENMEATPASTA_DEFINITION },
            { CHEESE_ID, CHEESE_DEFINITION },
            { SALAD_ID, SALAD_DEFINITION },
            { VEGETABLE_SOUP_BOWL_ID, VEGETABLE_SOUP_BOWL_DEFINITION },
            { STEW_ID, STEW_DEFINITION },
            { ALIEN_STEW_ID, ALIEN_STEW_DEFINITION },
            { MEAT_VEGETABLES_ID, MEAT_VEGETABLES_DEFINITION },
            { ALIEN_MEAT_VEGETABLES_ID, ALIEN_MEAT_VEGETABLES_DEFINITION },
            { MEATLOAF_ID, MEATLOAF_DEFINITION },
            { ALIENMEATLOAF_ID, ALIENMEATLOAF_DEFINITION },
            { MEAT_SOUP_BOWL_ID, MEAT_SOUP_BOWL_DEFINITION },
            { ALIEN_MEAT_SOUP_BOWL_ID, ALIEN_MEAT_SOUP_BOWL_DEFINITION },
            { MUSHROOMPATE_BOWL_ID, MUSHROOMPATE_BOWL_DEFINITION },
            { MEAT_MUSHROOMS_ID, MEAT_MUSHROOMS_DEFINITION },
            { ALIEN_MEAT_MUSHROOMS_ID, ALIEN_MEAT_MUSHROOMS_DEFINITION },
            { SANDWICH_ID, SANDWICH_DEFINITION },
            { ALIEN_SANDWICH_ID, ALIEN_SANDWICH_DEFINITION },
            { ROASTEDSHRIMP_ID, ROASTEDSHRIMP_DEFINITION },
            { ROASTEDFISH_ID, ROASTEDFISH_DEFINITION },
            { ROASTEDNOBLEFISH_ID, ROASTEDNOBLEFISH_DEFINITION },
            { FISHMUSHROOM_ID, FISHMUSHROOM_DEFINITION },
            { FISHSOUPBOWL_ID, FISHSOUPBOWL_DEFINITION },
            { SHRIMPSOUPBOWL_ID, SHRIMPSOUPBOWL_DEFINITION },
            { APPLEPIE_ID, APPLEPIE_DEFINITION },
            { ALIEN_APPLEPIE_ID, ALIEN_APPLEPIE_DEFINITION },
            { CHICKENPIE_ID, CHICKENPIE_DEFINITION },
            { ALIEN_CHICKENPIE_ID, ALIEN_CHICKENPIE_DEFINITION },
            { FATPORRIDGE_ID, FATPORRIDGE_DEFINITION },
            { PROTEINBAR_ID, PROTEINBAR_DEFINITION },
            { VITAMINPILLS_ID, VITAMINPILLS_DEFINITION }
        };

        public static readonly List<UniqueEntityId> FOOD_RECIPIENTS = new List<UniqueEntityId>()
        {
            { ItensConstants.FLASK_BIG_ID },
            { ItensConstants.FLASK_SMALL_ID },
            { ItensConstants.FLASK_MEDIUM_ID },
            { RecipientConstants.ALUMINUMCAN_ID },
            { RecipientConstants.BOWL_ID }
        };

        public static readonly List<UniqueEntityId> MEDICAL_INGREDIENTS = new List<UniqueEntityId>()
        {
            { ItensConstants.POLIETILENOGLICOL_ID }
        };

        public static readonly FoodConcentratedExtractDefinition TOMATO_TO_CONCENTRATED_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = TOMATO_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.TOMATOTOCONCENTRATED_CONSTRUCTION_NAME),
            Description = "",            
            RecipeName = "TomatoToConcentrated_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition APPLE_TO_CONCENTRATED_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = APPLE_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.APPLETOCONCENTRATED_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "AppleToConcentrated_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition ALIENEGG_TO_CONCENTRATED_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = ALIEN_EGG_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.ALIENEGGTOCONCENTRATED_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "AlienEggToConcentrated_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition EGG_TO_CONCENTRATED_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = EGG_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.EGGTOCONCENTRATED_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "EggToConcentrated_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition SHRIMPMEAT_TO_CONCENTRATED_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = SHRIMPMEAT_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.SHRIMPMEATTOCONCENTRATED_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "ShrimpMeatToConcentrated_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition SHRIMPMEAT_TO_CONCENTRATED_FAT_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = SHRIMPMEAT_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.SHRIMPMEATTOCONCENTRATEDFAT_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "ShrimpMeatToConcentratedFat_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition FISHMEAT_TO_CONCENTRATED_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = FISHMEAT_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.FISHMEATTOCONCENTRATED_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "FishMeatToConcentrated_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition FISHMEAT_TO_CONCENTRATED_FAT_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = FISHMEAT_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.FISHMEATTOCONCENTRATEDFAT_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "FishMeatToConcentratedFat_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition ALIEN_MEAT_TO_CONCENTRATED_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = ALIEN_MEAT_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.ALIENMEATTOCONCENTRATED_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "AlienMeatToConcentrated_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition ALIEN_MEAT_TO_CONCENTRATED_FAT_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = ALIEN_MEAT_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.ALIENMEATTOCONCENTRATEDFAT_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "AlienMeatToConcentratedFat_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition MEAT_TO_CONCENTRATED_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = MEAT_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.MEATTOCONCENTRATED_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "MeatToConcentrated_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition MEAT_TO_CONCENTRATED_FAT_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = MEAT_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.MEATTOCONCENTRATEDFAT_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "MeatToConcentratedFat_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition CHICKENMEAT_TO_CONCENTRATED_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = CHICKENMEAT_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.CHICKENMEATTOCONCENTRATED_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "ChickenMeatToConcentrated_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition CHICKENMEAT_TO_CONCENTRATED_FAT_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = CHICKENMEAT_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.CHICKENMEATTOCONCENTRATEDFAT_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "ChickenMeatToConcentratedFat_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition MILK_TO_CONCENTRATED_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = MILK_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.MILKTOCONCENTRATED_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "MilkToConcentrated_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition MILK_TO_CONCENTRATED_FAT_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = MILK_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.MILKTOCONCENTRATEDFAT_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "MilkToConcentratedFat_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition BACON_TO_CONCENTRATED_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = BACON_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.BACONTOCONCENTRATED_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "BaconToConcentrated_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition BACON_TO_CONCENTRATED_FAT_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = BACON_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.BACONTOCONCENTRATEDFAT_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "BaconToConcentratedFat_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition NOBLEFISHMEAT_TO_CONCENTRATED_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = NOBLEFISHMEAT_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.NOBLEFISHMEATTOCONCENTRATED_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "NobleFishMeatToConcentrated_Construction",
            ProductionTime = 2.56f 
        };

        public static readonly FoodConcentratedExtractDefinition NOBLEFISHMEAT_TO_CONCENTRATED_FAT_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = NOBLEFISHMEAT_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.NOBLEFISHMEATTOCONCENTRATEDFAT_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "NobleFishMeatToConcentratedFat_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition ALIEN_NOBLE_MEAT_TO_CONCENTRATED_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = ALIEN_NOBLE_MEAT_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.NOBLEALIENMEATTOCONCENTRATED_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "NobleAlienMeatToConcentrated_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition ALIEN_NOBLE_MEAT_TO_CONCENTRATED_FAT_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = ALIEN_NOBLE_MEAT_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.NOBLEALIENMEATTOCONCENTRATEDFAT_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "NobleAlienMeatToConcentratedFat_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition NOBLE_MEAT_TO_CONCENTRATED_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = NOBLE_MEAT_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.NOBLEMEATTOCONCENTRATED_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "NobleMeatToConcentrated_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition NOBLE_MEAT_TO_CONCENTRATED_FAT_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = NOBLE_MEAT_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.NOBLEMEATTOCONCENTRATEDFAT_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "NobleMeatToConcentratedFat_Construction",
            ProductionTime = 2.56f
        };

        public static readonly Dictionary<UniqueEntityId, List<FoodConcentratedExtractDefinition>> FOOD_CONCENTRATED_EXTRACTORS = new Dictionary<UniqueEntityId, List<FoodConcentratedExtractDefinition>>()
        {
            { 
                CONCENTRATEDVITAMIN_ID,  
                new List<FoodConcentratedExtractDefinition>()
                {
                    TOMATO_TO_CONCENTRATED_DEFINITION,
                    APPLE_TO_CONCENTRATED_DEFINITION
                }
            },
            {
                CONCENTRATEDPROTEIN_ID,
                new List<FoodConcentratedExtractDefinition>()
                {
                    ALIENEGG_TO_CONCENTRATED_DEFINITION,
                    EGG_TO_CONCENTRATED_DEFINITION,
                    SHRIMPMEAT_TO_CONCENTRATED_DEFINITION,
                    FISHMEAT_TO_CONCENTRATED_DEFINITION,
                    ALIEN_MEAT_TO_CONCENTRATED_DEFINITION,
                    MEAT_TO_CONCENTRATED_DEFINITION,
                    CHICKENMEAT_TO_CONCENTRATED_DEFINITION,
                    MILK_TO_CONCENTRATED_DEFINITION,
                    BACON_TO_CONCENTRATED_DEFINITION,
                    NOBLEFISHMEAT_TO_CONCENTRATED_DEFINITION,
                    ALIEN_NOBLE_MEAT_TO_CONCENTRATED_DEFINITION,
                    NOBLE_MEAT_TO_CONCENTRATED_DEFINITION
                }
            },
            {
                CONCENTRATEDFAT_ID,
                new List<FoodConcentratedExtractDefinition>()
                {
                    SHRIMPMEAT_TO_CONCENTRATED_FAT_DEFINITION,
                    FISHMEAT_TO_CONCENTRATED_FAT_DEFINITION,
                    ALIEN_MEAT_TO_CONCENTRATED_FAT_DEFINITION,
                    MEAT_TO_CONCENTRATED_FAT_DEFINITION,
                    CHICKENMEAT_TO_CONCENTRATED_FAT_DEFINITION,
                    MILK_TO_CONCENTRATED_FAT_DEFINITION,
                    BACON_TO_CONCENTRATED_FAT_DEFINITION,
                    NOBLEFISHMEAT_TO_CONCENTRATED_FAT_DEFINITION,
                    ALIEN_NOBLE_MEAT_TO_CONCENTRATED_FAT_DEFINITION,
                    NOBLE_MEAT_TO_CONCENTRATED_FAT_DEFINITION
                }
            }
        };

        public static void TryOverrideDefinitions()
        {
            try
            {
                // Apply Settings to Base Ingredients
                foreach (var food in FOOD_DEFINITIONS.Keys)
                {
                    var foodDef = FOOD_DEFINITIONS[food];
                    foodDef.Protein *= ExtendedSurvivalSettings.Instance.FoodSettings.ProteinsMultiplier;
                    foodDef.Carbohydrate *= ExtendedSurvivalSettings.Instance.FoodSettings.CarbohydratesMultiplier;
                    foodDef.Lipids *= ExtendedSurvivalSettings.Instance.FoodSettings.LipidsMultiplier;
                    foodDef.Minerals *= ExtendedSurvivalSettings.Instance.FoodSettings.MineralsMultiplier;
                    foodDef.Vitamins *= ExtendedSurvivalSettings.Instance.FoodSettings.VitaminsMultiplier;
                    foodDef.Calories *= ExtendedSurvivalSettings.Instance.FoodSettings.CaloriesMultiplier;
                    foodDef.TimeToConsume *= ExtendedSurvivalSettings.Instance.MetabolismSpeedMultiplier * ExtendedSurvivalSettings.Instance.FoodSettings.DigestionTimeMultiplier;
                }
                // Override recipes and add food definition
                var recipesToPostprocess = new List<MyBlueprintDefinitionBase>();
                foreach (var food in FOOD_RECIPES.Keys)
                {
                    if (FOOD_DEFINITIONS.ContainsKey(food))
                        continue;
                    var preparationDef = FOOD_RECIPES[food];
                    var recipeDef = DefinitionUtils.TryGetBlueprintDefinition(preparationDef.RecipeName);
                    if (recipeDef != null)
                    {
                        recipesToPostprocess.Add(recipeDef);
                        recipeDef.Prerequisites = preparationDef.GetIngredients();
                        recipeDef.Results = preparationDef.GetProduct();
                        recipeDef.BaseProductionTimeInSeconds = preparationDef.ProductionTime;
                        recipeDef.DisplayNameEnum = null;
                        recipeDef.DisplayNameString = preparationDef.Name;
                        recipeDef.DescriptionEnum = null;
                        recipeDef.DescriptionString = preparationDef.GetFullDescription();
                        // Add item definition based as recipes values
                        var foodDef = new FoodDefinition()
                        {
                            Id = preparationDef.Product.Id,
                            Name = preparationDef.Name,
                            Description = preparationDef.Description,
                            DefinitionType = preparationDef.DefinitionType,
                            AcquisitionAmount = preparationDef.AcquisitionAmount,
                            OrderAmount = preparationDef.OrderAmount,
                            OfferAmount = preparationDef.OfferAmount,
                            MinimalPricePerUnit = preparationDef.MinimalPricePerUnit,
                            CanPlayerOrder = preparationDef.CanPlayerOrder,
                            CureDisease = preparationDef.CureDisease,
                            TemperatureEffects = preparationDef.TemperatureEffects,
                            FoodEffects = preparationDef.FoodEffects,
                            FoodEffects2 = preparationDef.FoodEffects2
                        };
                        bool needConservation = false;
                        long maxTime = 0;
                        foreach (var item in preparationDef.Ingredients)
                        {
                            if (FOOD_RECIPIENTS.Contains(item.Id) || MEDICAL_INGREDIENTS.Contains(item.Id) || !FOOD_DEFINITIONS.ContainsKey(item.Id))
                                continue;
                            var ingredientDef = FOOD_DEFINITIONS[item.Id];
                            needConservation = needConservation || ingredientDef.NeedConservation;
                            if (ingredientDef.StartConservationTime > 0)
                            {
                                maxTime = Math.Max(maxTime, ingredientDef.StartConservationTime);
                            }
                            foodDef.Increment(ingredientDef, item.Ammount);
                        }
                        foodDef.Divide(preparationDef.Product.Ammount);
                        foodDef.ApplyPreparation(preparationDef.Preparation, needConservation, maxTime);
                        FOOD_DEFINITIONS.Add(food, foodDef);
                    }
                    else
                        ExtendedSurvivalStatsLogging.Instance.LogInfo(typeof(FoodConstants), $"CalculateRecipesNutrition recipe not found. Recipe=[{preparationDef.RecipeName}]");
                }
                // Override food definition
                foreach (var food in FOOD_DEFINITIONS.Keys)
                {
                    var foodDef = FOOD_DEFINITIONS[food];
                    if (foodDef.IgnoreDefinition)
                        continue;
                    // Apply Custom Volume
                    if (ExtendedSurvivalSettings.Instance.FoodSettings.Volumes.Any(x=>x.Id == food.DefinitionId))
                    {
                        var settings = ExtendedSurvivalSettings.Instance.FoodSettings.Volumes.FirstOrDefault(x => x.Id == food.DefinitionId);
                        foodDef.Solid *= settings.Multiplier;
                        foodDef.Liquid *= settings.Multiplier;
                    }
                    // Aplly Definition
                    switch (foodDef.DefinitionType)
                    {
                        case FoodDefinition.FoodDefinitionType.Consumable:
                            var consumableDef = DefinitionUtils.TryGetDefinition<MyConsumableItemDefinition>(food.DefinitionId);
                            if (consumableDef != null)
                            {
                                if (consumableDef.Stats == null)
                                    consumableDef.Stats = new List<MyConsumableItemDefinition.StatValue>();
                                consumableDef.Stats.Clear();
                                consumableDef.Stats.Add(new MyConsumableItemDefinition.StatValue()
                                {
                                    Name = StatsConstants.ValidStats.FoodDetector.ToString(),
                                    Time = 3,
                                    Value = 0.025f
                                });
                                consumableDef.Volume = foodDef.GetVolume();
                                consumableDef.Mass = foodDef.GetMass();
                                consumableDef.DisplayNameEnum = null;
                                consumableDef.DisplayNameString = foodDef.Name;
                                consumableDef.DescriptionEnum = null;
                                consumableDef.DescriptionString = null;
                                consumableDef.MinimumAcquisitionAmount = foodDef.AcquisitionAmount.X;
                                consumableDef.MaximumAcquisitionAmount = foodDef.AcquisitionAmount.Y;
                                consumableDef.MinimumOrderAmount = foodDef.OrderAmount.X;
                                consumableDef.MaximumOrderAmount = foodDef.OrderAmount.Y;
                                consumableDef.MinimumOfferAmount = foodDef.OfferAmount.X;
                                consumableDef.MaximumOfferAmount = foodDef.OfferAmount.Y;
                                consumableDef.MinimalPricePerUnit = foodDef.MinimalPricePerUnit;
                                consumableDef.CanPlayerOrder = foodDef.CanPlayerOrder;
                                consumableDef.ExtraInventoryTooltipLine.AppendLine(Environment.NewLine + foodDef.GetFullDescription());
                                consumableDef.Postprocess();
                            }
                            else
                                ExtendedSurvivalStatsLogging.Instance.LogInfo(typeof(FoodConstants), $"TryOverrideRecipes item not found. Food=[{food}]");
                            break;
                        case FoodDefinition.FoodDefinitionType.Ore:
                        case FoodDefinition.FoodDefinitionType.Ingot:
                            var physicalItemDef = DefinitionUtils.TryGetDefinition<MyPhysicalItemDefinition>(food.DefinitionId);
                            if (physicalItemDef != null)
                            {
                                physicalItemDef.DisplayNameEnum = null;
                                physicalItemDef.DisplayNameString = foodDef.Name;
                                physicalItemDef.DescriptionEnum = null;
                                physicalItemDef.DescriptionString = null;
                                physicalItemDef.ExtraInventoryTooltipLine.AppendLine(Environment.NewLine + foodDef.GetFullDescription());
                                physicalItemDef.Postprocess();
                            }
                            else
                                ExtendedSurvivalStatsLogging.Instance.LogInfo(typeof(FoodConstants), $"TryOverrideRecipes item not found. Food=[{food}]");
                            break;
                    }
                }
                // Override Concentrated Recipes
                foreach (var targetFood in FOOD_CONCENTRATED_EXTRACTORS.Keys)
                {
                    var targetFoodDef = FOOD_DEFINITIONS[targetFood];
                    foreach (var targetIngredient in FOOD_CONCENTRATED_EXTRACTORS[targetFood])
                    {
                        var targetIngredientDef = FOOD_DEFINITIONS[targetIngredient.Ingredient.Id];
                        var recipeDef = DefinitionUtils.TryGetBlueprintDefinition(targetIngredient.RecipeName);
                        if (recipeDef != null)
                        {
                            recipesToPostprocess.Add(recipeDef);
                            recipeDef.Prerequisites = new MyBlueprintDefinitionBase.Item[] { 
                                new MyBlueprintDefinitionBase.Item()
                                {
                                    Id = targetIngredient.Ingredient.Id.DefinitionId,
                                    Amount = (MyFixedPoint)targetIngredient.Ingredient.Ammount
                                }
                            };
                            float resultAmmount = 0;
                            if (targetFood == CONCENTRATEDVITAMIN_ID)
                                resultAmmount = targetIngredientDef.Vitamins;
                            if (targetFood == CONCENTRATEDPROTEIN_ID)
                                resultAmmount = targetIngredientDef.Protein;
                            if (targetFood == CONCENTRATEDFAT_ID)
                                resultAmmount = targetIngredientDef.Lipids;
                            recipeDef.Results = new MyBlueprintDefinitionBase.Item[] {
                                new MyBlueprintDefinitionBase.Item()
                                {
                                    Id = targetFood.DefinitionId,
                                    Amount = (MyFixedPoint)resultAmmount
                                }
                            };
                            recipeDef.BaseProductionTimeInSeconds = targetIngredient.ProductionTime;
                            recipeDef.DisplayNameEnum = null;
                            recipeDef.DisplayNameString = targetIngredient.Name;
                            recipeDef.DescriptionEnum = null;
                            recipeDef.DescriptionString = null;
                        }
                        else
                            ExtendedSurvivalStatsLogging.Instance.LogInfo(typeof(FoodConstants), $"CalculateRecipesNutrition recipe not found. Recipe=[{targetIngredient.RecipeName}]");
                    }
                }
                // Post process recipes
                foreach (var recipe in recipesToPostprocess)
                {
                    recipe.Postprocess();
                }
                // Add itens to faction types
                var targetFaction = FactionTypeConstants.FACTION_TYPES_DEFINITIONS[FactionTypeConstants.TRADER_ID];
                foreach (var food in FOOD_DEFINITIONS.Where(x => x.Value.CanPlayerOrder))
                {
                    targetFaction.OffersList.Add(food.Key);
                    targetFaction.OrdersList.Add(food.Key);
                }
            }
            catch (System.Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(typeof(FoodConstants), ex);
            }
        }

        public static void RegisterShopItens()
        {
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = CONCENTRATEDFAT_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                ForceMinimalPrice = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = CONCENTRATEDPROTEIN_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                ForceMinimalPrice = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = CONCENTRATEDVITAMIN_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                ForceMinimalPrice = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = WHEATSACK_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Farming }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = COFFEESACK_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Farming }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = CEREAL_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                ForceMinimalPrice = true,
                TargetFactions = new FactionType[] { FactionType.Farming }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = FATPORRIDGE_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = VITAMINPILLS_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = PROTEINBAR_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = SHRIMPMEAT_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Livestock }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = CHEESE_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = VEGETABLEPASTA_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = VEGETABLEALIENPASTA_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = MEATPASTA_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = ALIENMEATPASTA_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = WATERBREAD_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = CHICKENMEAT_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                ForceMinimalPrice = true,
                TargetFactions = new FactionType[] { FactionType.Livestock }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = BACON_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                ForceMinimalPrice = true,
                TargetFactions = new FactionType[] { FactionType.Livestock }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = ROASTEDCHICKEN_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = ROASTEDBACON_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = APPLEPIE_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = ALIEN_APPLEPIE_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = CHICKENPIE_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = ALIEN_CHICKENPIE_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = FISHMEAT_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Livestock }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = NOBLEFISHMEAT_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Livestock }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = ROASTEDSHRIMP_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = ROASTEDFISH_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = ROASTEDNOBLEFISH_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = FISHMUSHROOM_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = FISHSOUPBOWL_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = SHRIMPSOUPBOWL_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = APPLE_JUICE_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Farming }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = MILK_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                ForceMinimalPrice = true,
                TargetFactions = new FactionType[] { FactionType.Livestock }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = SODA_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = COFFEE_CAN_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = ROASTED_MEAT_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = ROASTED_ALIEN_MEAT_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = CEREALBAR_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = ROASTED_SAUSAGE_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = ROASTED_ALIEN_SAUSAGE_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = FRIED_EGG_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = FRIED_ALIEN_EGG_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = STEW_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = ALIEN_STEW_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = MEATLOAF_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = ALIENMEATLOAF_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = SALAD_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = BREAD_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = ALIEN_BREAD_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = ROAST_CHAMPIGNON_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = ROAST_SHIITAKE_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = MEAT_VEGETABLES_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = ALIEN_MEAT_VEGETABLES_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = MEAT_MUSHROOMS_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = ALIEN_MEAT_MUSHROOMS_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = SANDWICH_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = ALIEN_SANDWICH_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = CHAMPIGNONS_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                ForceMinimalPrice = true,
                TargetFactions = new FactionType[] { FactionType.Farming }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = SHIITAKE_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                ForceMinimalPrice = true,
                TargetFactions = new FactionType[] { FactionType.Farming }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = AMANITAMUSCARIA_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                ForceMinimalPrice = true,
                TargetFactions = new FactionType[] { FactionType.Farming }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = BEETROOT_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                ForceMinimalPrice = true,
                TargetFactions = new FactionType[] { FactionType.Farming }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = CAROOT_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                ForceMinimalPrice = true,
                TargetFactions = new FactionType[] { FactionType.Farming }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = BROCCOLI_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                ForceMinimalPrice = true,
                TargetFactions = new FactionType[] { FactionType.Farming }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = TOMATO_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                ForceMinimalPrice = true,
                TargetFactions = new FactionType[] { FactionType.Farming }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = NOBLE_MEAT_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                ForceMinimalPrice = true,
                TargetFactions = new FactionType[] { FactionType.Livestock }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = ALIEN_MEAT_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                ForceMinimalPrice = true,
                TargetFactions = new FactionType[] { FactionType.Livestock }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = ALIEN_NOBLE_MEAT_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                ForceMinimalPrice = true,
                TargetFactions = new FactionType[] { FactionType.Livestock }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = ALIEN_EGG_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                ForceMinimalPrice = true,
                TargetFactions = new FactionType[] { FactionType.Livestock }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = EGG_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                ForceMinimalPrice = true,
                TargetFactions = new FactionType[] { FactionType.Livestock }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = RAW_SAUSAGE_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Livestock }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = RAW_ALIEN_SAUSAGE_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Livestock }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = VEGETABLE_SOUP_BOWL_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = MEAT_SOUP_BOWL_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = ALIEN_MEAT_SOUP_BOWL_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = MUSHROOMPATE_BOWL_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = MEAT_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                ForceMinimalPrice = true,
                TargetFactions = new FactionType[] { FactionType.Livestock }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = APPLE_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                ForceMinimalPrice = true,
                TargetFactions = new FactionType[] { FactionType.Farming }
            });
        }

    }

}