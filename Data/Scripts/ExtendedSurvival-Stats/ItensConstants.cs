using Sandbox.Common.ObjectBuilders.Definitions;
using System.Collections.Concurrent;
using System.Collections.Generic;
using VRage.Game;
using VRage.Game.ObjectBuilders.Definitions;
using VRage.ObjectBuilders;
using System;

namespace ExtendedSurvival.Stats
{

    public static class ItensConstants
    {

        public const string ASSEMBLER_BOTTLES_BLUEPRINTS = "Assembler_Bottles_Blueprints";

        public const string BASICASSEMBLER_BOTTLES_BLUEPRINTS = "BasicAssembler_Bottles_Blueprints";

        public const string ALCHEMYBENCH_MORTARANDPASTE_BLUEPRINTS = "AlchemyBench_MortarAndPaste_Blueprints";
        public const string ALCHEMYBENCH_CONCENTRATE_BLUEPRINTS = "AlchemyBench_Concentrate_Blueprints";
        public const string ALCHEMYBENCH_MEDICAL_BLUEPRINTS = "AlchemyBench_Medical_Blueprints";
        public const string ALCHEMYBENCH_FERTILIZER_BLUEPRINTS = "AlchemyBench_Fertilizer_Blueprints";

        public const string BASICALCHEMYBENCH_CONCENTRATE_BLUEPRINTS = "BasicAlchemyBench_Concentrate_Blueprints";
        public const string BASICALCHEMYBENCH_MEDICAL_BLUEPRINTS = "BasicAlchemyBench_Medical_Blueprints";
        public const string BASICALCHEMYBENCH_FERTILIZER_BLUEPRINTS = "BasicAlchemyBench_Fertilizer_Blueprints";

        public const string SURVIVALKIT_SURVIVAL_BLUEPRINTS = "SurvivalKit_Survival_Blueprints";
        public const string SURVIVALKIT_MEDICAL_BLUEPRINTS = "SurvivalKit_Medical_Blueprints";

        public const string POLIETILENOGLICOL_SUBTYPEID = "Polietilenoglicol";
        public static readonly UniqueEntityId POLIETILENOGLICOL_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), POLIETILENOGLICOL_SUBTYPEID);

        public const string BODYTRACKER_SUBTYPEID = "BodyTracker";
        public static readonly UniqueEntityId BODYTRACKER_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), BODYTRACKER_SUBTYPEID);

        public const string ENHANCEDBODYTRACKER_SUBTYPEID = "EnhancedBodyTracker";
        public static readonly UniqueEntityId ENHANCEDBODYTRACKER_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), ENHANCEDBODYTRACKER_SUBTYPEID);

        public const string PROFICIENTBODYTRACKER_SUBTYPEID = "ProficientBodyTracker";
        public static readonly UniqueEntityId PROFICIENTBODYTRACKER_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), PROFICIENTBODYTRACKER_SUBTYPEID);

        public const string ELITEBODYTRACKER_SUBTYPEID = "EliteBodyTracker";
        public static readonly UniqueEntityId ELITEBODYTRACKER_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), ELITEBODYTRACKER_SUBTYPEID);

        public const string PISTOL_PROPOFOL_MAGZINE_SUBTYPEID = "PropofolPistolMagazine";
        public static readonly UniqueEntityId PISTOL_PROPOFOL_MAGZINE_ID = new UniqueEntityId(typeof(MyObjectBuilder_AmmoMagazine), PISTOL_PROPOFOL_MAGZINE_SUBTYPEID);

        public const string PISTOL_LIDOCAIN_MAGZINE_SUBTYPEID = "LidocainPistolMagazine";
        public static readonly UniqueEntityId PISTOL_LIDOCAIN_MAGZINE_ID = new UniqueEntityId(typeof(MyObjectBuilder_AmmoMagazine), PISTOL_LIDOCAIN_MAGZINE_SUBTYPEID);

        public const string LEAF_SUBTYPEID = "Leaf";
        public static readonly UniqueEntityId LEAF_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), LEAF_SUBTYPEID);

        public const string TWIG_SUBTYPEID = "Twig";
        public static readonly UniqueEntityId TWIG_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), TWIG_SUBTYPEID);

        public const string BRANCH_SUBTYPEID = "Branch";
        public static readonly UniqueEntityId BRANCH_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), BRANCH_SUBTYPEID);

        public const string SOILPOWDER_SUBTYPEID = "Soil";
        public static readonly UniqueEntityId SOILPOWDER_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), SOILPOWDER_SUBTYPEID);

        public const string ICE_SUBTYPEID = "Ice";
        public static readonly UniqueEntityId ICE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), ICE_SUBTYPEID);

        public const string OXYGEN_SUBTYPEID = "Oxygen";
        public static readonly UniqueEntityId OXYGEN_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasProperties), OXYGEN_SUBTYPEID);

        public const string BANDAGES_SUBTYPEID = "Bandages";
        public static readonly UniqueEntityId BANDAGES_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), BANDAGES_SUBTYPEID);

        public const string POWER_BANDAGES_SUBTYPEID = "PowerBandages";
        public static readonly UniqueEntityId POWER_BANDAGES_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), POWER_BANDAGES_SUBTYPEID);

        public const string HEALTH_BUSTER_SUBTYPEID = "HealthBuster";
        public static readonly UniqueEntityId HEALTH_BUSTER_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), HEALTH_BUSTER_SUBTYPEID);

        public const string MEDKIT_SUBTYPEID = "Medkit";
        public static readonly UniqueEntityId MEDKIT_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), MEDKIT_SUBTYPEID);

        public const string ANTI_INFRAMMATORY_SUBTYPEID = "HealthInjection";
        public static readonly UniqueEntityId ANTI_INFRAMMATORY_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), ANTI_INFRAMMATORY_SUBTYPEID);

        public const string ANTIBIOTIC_SUBTYPEID = "HealthPowerInjection";
        public static readonly UniqueEntityId ANTIBIOTIC_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), ANTIBIOTIC_SUBTYPEID);

        public const string DIGESTIVE_SUBTYPEID = "SimpleMedicine";
        public static readonly UniqueEntityId DIGESTIVE_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), DIGESTIVE_SUBTYPEID);

        public const string DETOXIFYING_SUBTYPEID = "Medicine";
        public static readonly UniqueEntityId DETOXIFYING_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), DETOXIFYING_SUBTYPEID);

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

        public const string SPOILED_MATERIAL_SUBTYPEID = "Organic";
        public static readonly UniqueEntityId SPOILED_MATERIAL_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), SPOILED_MATERIAL_SUBTYPEID);

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

        public const string SHRIMP_SUBTYPEID = "Shrimp";
        public static readonly UniqueEntityId SHRIMP_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), SHRIMP_SUBTYPEID);

        public const string FISH_SUBTYPEID = "Fish";
        public static readonly UniqueEntityId FISH_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), FISH_SUBTYPEID);

        public const string ALIENFISH_SUBTYPEID = "AlienFish";
        public static readonly UniqueEntityId ALIENFISH_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), ALIENFISH_SUBTYPEID);

        public const string NOBLEFISH_SUBTYPEID = "NobleFish";
        public static readonly UniqueEntityId NOBLEFISH_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), NOBLEFISH_SUBTYPEID);

        public const string ALIENNOBLEFISH_SUBTYPEID = "AlienNobleFish";
        public static readonly UniqueEntityId ALIENNOBLEFISH_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), ALIENNOBLEFISH_SUBTYPEID);

        public const string FISH_BAIT_SUBTYPEID = "FishBait";
        public static readonly UniqueEntityId FISH_BAIT_SMALL_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), FISH_BAIT_SUBTYPEID);

        public const string FISH_NOBLE_BAIT_SUBTYPEID = "FishNobleBait";
        public static readonly UniqueEntityId FISH_NOBLE_BAIT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), FISH_NOBLE_BAIT_SUBTYPEID);

        public const string BONES_SUBTYPEID = "Bones";
        public static readonly UniqueEntityId BONES_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), BONES_SUBTYPEID);

        public const string FISH_BONES_SUBTYPEID = "FishBones";
        public static readonly UniqueEntityId FISH_BONES_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), FISH_BONES_SUBTYPEID);

        public const string POOP_SUBTYPEID = "Poop";
        public static readonly UniqueEntityId POOP_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), POOP_SUBTYPEID);

        public const string MEATRATION_SUBTYPEID = "MeatRation";
        public static readonly UniqueEntityId MEATRATION_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), MEATRATION_SUBTYPEID);

        public const string VEGETABLERATION_SUBTYPEID = "VegetablesRation";
        public static readonly UniqueEntityId VEGETABLERATION_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), VEGETABLERATION_SUBTYPEID);

        public const string GRAINSRATION_SUBTYPEID = "GrainsRation";
        public static readonly UniqueEntityId GRAINSRATION_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), GRAINSRATION_SUBTYPEID);

        public const string CONCENTRATEDFAT_SUBTYPEID = "ConcentratedFat";
        public static readonly UniqueEntityId CONCENTRATEDFAT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), CONCENTRATEDFAT_SUBTYPEID);

        public const string CONCENTRATEDPROTEIN_SUBTYPEID = "ConcentratedProtein";
        public static readonly UniqueEntityId CONCENTRATEDPROTEIN_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), CONCENTRATEDPROTEIN_SUBTYPEID);

        public const string CONCENTRATEDVITAMIN_SUBTYPEID = "ConcentratedVitamin";
        public static readonly UniqueEntityId CONCENTRATEDVITAMIN_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), CONCENTRATEDVITAMIN_SUBTYPEID);

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

        public const string ARNICA_SUBTYPEID = "Arnica";
        public static readonly UniqueEntityId ARNICA_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), ARNICA_SUBTYPEID);

        public const string CHAMOMILE_SUBTYPEID = "Chamomile";
        public static readonly UniqueEntityId CHAMOMILE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), CHAMOMILE_SUBTYPEID);

        public const string ALOEVERA_SUBTYPEID = "AloeVera";
        public static readonly UniqueEntityId ALOEVERA_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), ALOEVERA_SUBTYPEID);

        public const string MINT_SUBTYPEID = "Mint";
        public static readonly UniqueEntityId MINT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), MINT_SUBTYPEID);

        public const string ERYTHROXYLUM_SUBTYPEID = "Erythroxylum";
        public static readonly UniqueEntityId ERYTHROXYLUM_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), ERYTHROXYLUM_SUBTYPEID);

        public const string WHEAT_SUBTYPEID = "Wheat";
        public static readonly UniqueEntityId WHEAT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), WHEAT_SUBTYPEID);

        public const string COFFEE_SUBTYPEID = "Coffee";
        public static readonly UniqueEntityId COFFEE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), COFFEE_SUBTYPEID);

        public const string WHEATSACK_SUBTYPEID = "Wheat";
        public static readonly UniqueEntityId WHEATSACK_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), WHEATSACK_SUBTYPEID);

        public const string COFFEESACK_SUBTYPEID = "Coffee";
        public static readonly UniqueEntityId COFFEESACK_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), COFFEESACK_SUBTYPEID);

        public const string FERTILIZER_SUBTYPEID = "Fertilizer";
        public static readonly UniqueEntityId FERTILIZER_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), FERTILIZER_SUBTYPEID);

        public const string MINERALFERTILIZER_SUBTYPEID = "MineralFertilizer";
        public static readonly UniqueEntityId MINERALFERTILIZER_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), MINERALFERTILIZER_SUBTYPEID);

        public const string SUPERFERTILIZER_SUBTYPEID = "SuperFertilizer";
        public static readonly UniqueEntityId SUPERFERTILIZER_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), SUPERFERTILIZER_SUBTYPEID);

        public const string ARNICA_SEEDS_SUBTYPEID = "ArnicaSeeds";
        public static readonly UniqueEntityId ARNICA_SEEDS_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), ARNICA_SEEDS_SUBTYPEID);

        public const string BEETROOT_SEEDS_SUBTYPEID = "BeetrootSeeds";
        public static readonly UniqueEntityId BEETROOT_SEEDS_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), BEETROOT_SEEDS_SUBTYPEID);

        public const string BROCCOLI_SEEDS_SUBTYPEID = "BroccoliSeeds";
        public static readonly UniqueEntityId BROCCOLI_SEEDS_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), BROCCOLI_SEEDS_SUBTYPEID);

        public const string CARROT_SEEDS_SUBTYPEID = "CarrotSeeds";
        public static readonly UniqueEntityId CARROT_SEEDS_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), CARROT_SEEDS_SUBTYPEID);

        public const string COFFEE_SEEDS_SUBTYPEID = "CoffeeSeeds";
        public static readonly UniqueEntityId COFFEE_SEEDS_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), COFFEE_SEEDS_SUBTYPEID);

        public const string MINT_SEEDS_SUBTYPEID = "MintSeeds";
        public static readonly UniqueEntityId MINT_SEEDS_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), MINT_SEEDS_SUBTYPEID);

        public const string TOMATO_SEEDS_SUBTYPEID = "TomatoSeeds";
        public static readonly UniqueEntityId TOMATO_SEEDS_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), TOMATO_SEEDS_SUBTYPEID);

        public const string WHEAT_SEEDS_SUBTYPEID = "WheatSeeds";
        public static readonly UniqueEntityId WHEAT_SEEDS_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), WHEAT_SEEDS_SUBTYPEID);

        public const string CHAMOMILE_SEEDS_SUBTYPEID = "ChamomileSeeds";
        public static readonly UniqueEntityId CHAMOMILE_SEEDS_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), CHAMOMILE_SEEDS_SUBTYPEID);

        public const string ALOEVERA_SEEDS_SUBTYPEID = "AloeVeraSeeds";
        public static readonly UniqueEntityId ALOEVERA_SEEDS_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), ALOEVERA_SEEDS_SUBTYPEID);

        public const string ERYTHROXYLUM_SEEDS_SUBTYPEID = "ErythroxylumSeeds";
        public static readonly UniqueEntityId ERYTHROXYLUM_SEEDS_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), ERYTHROXYLUM_SEEDS_SUBTYPEID);

        public const string COWMALE_SUBTYPEID = "CowMale";
        public static readonly UniqueEntityId COWMALE_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), COWMALE_SUBTYPEID);

        public const string COWFEMALE_SUBTYPEID = "CowFemale";
        public static readonly UniqueEntityId COWFEMALE_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), COWFEMALE_SUBTYPEID);

        public const string COWBABY_SUBTYPEID = "CowBaby";
        public static readonly UniqueEntityId COWBABY_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), COWBABY_SUBTYPEID);

        public const string DEERMALE_SUBTYPEID = "DeerMale";
        public static readonly UniqueEntityId DEERMALE_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), DEERMALE_SUBTYPEID);

        public const string DEERFEMALE_SUBTYPEID = "DeerFemale";
        public static readonly UniqueEntityId DEERFEMALE_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), DEERFEMALE_SUBTYPEID);

        public const string DEERBABY_SUBTYPEID = "DeerBaby";
        public static readonly UniqueEntityId DEERBABY_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), DEERBABY_SUBTYPEID);

        public const string HORSEMALE_SUBTYPEID = "HorseMale";
        public static readonly UniqueEntityId HORSEMALE_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), HORSEMALE_SUBTYPEID);

        public const string HORSEFEMALE_SUBTYPEID = "HorseFemale";
        public static readonly UniqueEntityId HORSEFEMALE_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), HORSEFEMALE_SUBTYPEID);

        public const string HORSEBABY_SUBTYPEID = "HorseBaby";
        public static readonly UniqueEntityId HORSEBABY_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), HORSEBABY_SUBTYPEID);

        public const string SHEEPMALE_SUBTYPEID = "SheepMale";
        public static readonly UniqueEntityId SHEEPMALE_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), SHEEPMALE_SUBTYPEID);

        public const string SHEEPFEMALE_SUBTYPEID = "SheepFemale";
        public static readonly UniqueEntityId SHEEPFEMALE_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), SHEEPFEMALE_SUBTYPEID);

        public const string SHEEPBABY_SUBTYPEID = "SheepBaby";
        public static readonly UniqueEntityId SHEEPBABY_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), SHEEPBABY_SUBTYPEID);

        public const string SPIDERMALE_SUBTYPEID = "SpiderMale";
        public static readonly UniqueEntityId SPIDERMALE_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), SPIDERMALE_SUBTYPEID);

        public const string SPIDERFEMALE_SUBTYPEID = "SpiderFemale";
        public static readonly UniqueEntityId SPIDERFEMALE_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), SPIDERFEMALE_SUBTYPEID);

        public const string SPIDERBABY_SUBTYPEID = "SpiderBaby";
        public static readonly UniqueEntityId SPIDERBABY_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), SPIDERBABY_SUBTYPEID);

        public const string WOLFMALE_SUBTYPEID = "WolfMale";
        public static readonly UniqueEntityId WOLFMALE_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), WOLFMALE_SUBTYPEID);

        public const string WOLFFEMALE_SUBTYPEID = "WolfFemale";
        public static readonly UniqueEntityId WOLFFEMALE_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), WOLFFEMALE_SUBTYPEID);

        public const string WOLFBABY_SUBTYPEID = "WolfBaby";
        public static readonly UniqueEntityId WOLFBABY_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), WOLFBABY_SUBTYPEID);

        public const string COWDEAD_SUBTYPEID = "CowDead";
        public static readonly UniqueEntityId COWDEAD_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), COWDEAD_SUBTYPEID);

        public const string DEERDEAD_SUBTYPEID = "DeerDead";
        public static readonly UniqueEntityId DEERDEAD_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), DEERDEAD_SUBTYPEID);

        public const string HORSEDEAD_SUBTYPEID = "HorseDead";
        public static readonly UniqueEntityId HORSEDEAD_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), HORSEDEAD_SUBTYPEID);

        public const string SHEEPDEAD_SUBTYPEID = "SheepDead";
        public static readonly UniqueEntityId SHEEPDEAD_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), SHEEPDEAD_SUBTYPEID);

        public const string SPIDERDEAD_SUBTYPEID = "SpiderDead";
        public static readonly UniqueEntityId SPIDERDEAD_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), SPIDERDEAD_SUBTYPEID);

        public const string WOLFDEAD_SUBTYPEID = "WolfDead";
        public static readonly UniqueEntityId WOLFDEAD_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), WOLFDEAD_SUBTYPEID);

        public const string COWBABYDEAD_SUBTYPEID = "CowBabyDead";
        public static readonly UniqueEntityId COWBABYDEAD_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), COWBABYDEAD_SUBTYPEID);

        public const string DEERBABYDEAD_SUBTYPEID = "DeerBabyDead";
        public static readonly UniqueEntityId DEERBABYDEAD_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), DEERBABYDEAD_SUBTYPEID);

        public const string HORSEBABYDEAD_SUBTYPEID = "HorseBabyDead";
        public static readonly UniqueEntityId HORSEBABYDEAD_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), HORSEBABYDEAD_SUBTYPEID);

        public const string SHEEPBABYDEAD_SUBTYPEID = "SheepBabyDead";
        public static readonly UniqueEntityId SHEEPBABYDEAD_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), SHEEPBABYDEAD_SUBTYPEID);

        public const string SPIDERBABYDEAD_SUBTYPEID = "SpiderBabyDead";
        public static readonly UniqueEntityId SPIDERBABYDEAD_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), SPIDERBABYDEAD_SUBTYPEID);

        public const string WOLFBABYDEAD_SUBTYPEID = "WolfBabyDead";
        public static readonly UniqueEntityId WOLFBABYDEAD_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), WOLFBABYDEAD_SUBTYPEID);

        public const string PIGBABYDEAD_SUBTYPEID = "PigBabyDead";
        public static readonly UniqueEntityId PIGBABYDEAD_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), PIGBABYDEAD_SUBTYPEID);

        public const string CHICKENBABYDEAD_SUBTYPEID = "ChickenBabyDead";
        public static readonly UniqueEntityId CHICKENBABYDEAD_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), CHICKENBABYDEAD_SUBTYPEID);

        public const string PIGDEAD_SUBTYPEID = "PigDead";
        public static readonly UniqueEntityId PIGDEAD_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), PIGDEAD_SUBTYPEID);

        public const string CHICKENDEAD_SUBTYPEID = "ChickenDead";
        public static readonly UniqueEntityId CHICKENDEAD_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), CHICKENDEAD_SUBTYPEID);

        public const string PIGMALE_SUBTYPEID = "PigMale";
        public static readonly UniqueEntityId PIGMALE_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), PIGMALE_SUBTYPEID);

        public const string PIGFEMALE_SUBTYPEID = "PigFemale";
        public static readonly UniqueEntityId PIGFEMALE_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), PIGFEMALE_SUBTYPEID);

        public const string PIGBABY_SUBTYPEID = "PigBaby";
        public static readonly UniqueEntityId PIGBABY_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), PIGBABY_SUBTYPEID);

        public const string CHICKENMALE_SUBTYPEID = "ChickenMale";
        public static readonly UniqueEntityId CHICKENMALE_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), CHICKENMALE_SUBTYPEID);

        public const string CHICKENFEMALE_SUBTYPEID = "ChickenFemale";
        public static readonly UniqueEntityId CHICKENFEMALE_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), CHICKENFEMALE_SUBTYPEID);

        public const string CHICKENBABY_SUBTYPEID = "ChickenBaby";
        public static readonly UniqueEntityId CHICKENBABY_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), CHICKENBABY_SUBTYPEID);

        public const string TREEDEAD_SUBTYPEID = "TreeDead";
        public static readonly UniqueEntityId TREEDEAD_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), TREEDEAD_SUBTYPEID);

        public const string APPLETREESEEDLING_SUBTYPEID = "AppleTreeSeedling";
        public static readonly UniqueEntityId APPLETREESEEDLING_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), APPLETREESEEDLING_SUBTYPEID);

        public const string APPLETREE_SUBTYPEID = "AppleTree";
        public static readonly UniqueEntityId APPLETREE_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), APPLETREE_SUBTYPEID);

        public const string CEREAL_SUBTYPEID = "Cereal";
        public static readonly UniqueEntityId CEREAL_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), CEREAL_SUBTYPEID);

        public const string APPLE_SUBTYPEID = "Apple";
        public static readonly UniqueEntityId APPLE_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), APPLE_SUBTYPEID);

        public const string WATER_FLASK_SMALL_SUBTYPEID = "Water_Flask_Small";
        public static readonly UniqueEntityId WATER_FLASK_SMALL_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), WATER_FLASK_SMALL_SUBTYPEID);

        public const string WATER_FLASK_MEDIUM_SUBTYPEID = "Water_Flask_Medium";
        public static readonly UniqueEntityId WATER_FLASK_MEDIUM_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), WATER_FLASK_MEDIUM_SUBTYPEID);

        public const string WATER_FLASK_BIG_SUBTYPEID = "Water_Flask_Big";
        public static readonly UniqueEntityId WATER_FLASK_BIG_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), WATER_FLASK_BIG_SUBTYPEID);

        public const string BOWL_SUBTYPEID = "Bowl";
        public static readonly UniqueEntityId BOWL_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), BOWL_SUBTYPEID);

        public const string ALUMINUMCAN_SUBTYPEID = "AluminumCan";
        public static readonly UniqueEntityId ALUMINUMCAN_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), ALUMINUMCAN_SUBTYPEID);

        public const string FLASK_SMALL_SUBTYPEID = "Flask_Small";
        public static readonly UniqueEntityId FLASK_SMALL_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), FLASK_SMALL_SUBTYPEID);

        public const string FLASK_MEDIUM_SUBTYPEID = "Flask_Medium";
        public static readonly UniqueEntityId FLASK_MEDIUM_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), FLASK_MEDIUM_SUBTYPEID);

        public const string FLASK_BIG_SUBTYPEID = "Flask_Big";
        public static readonly UniqueEntityId FLASK_BIG_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), FLASK_BIG_SUBTYPEID);

        public static Dictionary<UniqueEntityId, StatsConstants.DamageEffects> REMOVE_DAMAGE_EFFECTS = new Dictionary<UniqueEntityId, StatsConstants.DamageEffects>()
        {
            { BANDAGES_ID, StatsConstants.DamageEffects.Contusion | StatsConstants.DamageEffects.Wounded },
            { DIGESTIVE_ID, StatsConstants.DamageEffects.Contusion | StatsConstants.DamageEffects.Wounded },
            { DETOXIFYING_ID, StatsConstants.DamageEffects.Contusion | StatsConstants.DamageEffects.Wounded },
            { POWER_BANDAGES_ID, StatsConstants.DamageEffects.Contusion | StatsConstants.DamageEffects.Wounded },
            { HEALTH_BUSTER_ID, StatsConstants.DamageEffects.Contusion | StatsConstants.DamageEffects.Wounded | StatsConstants.DamageEffects.DeepWounded },
            { ANTI_INFRAMMATORY_ID, StatsConstants.DamageEffects.Contusion | StatsConstants.DamageEffects.Wounded | StatsConstants.DamageEffects.DeepWounded },
            { ANTIBIOTIC_ID, StatsConstants.DamageEffects.Contusion | StatsConstants.DamageEffects.Wounded | StatsConstants.DamageEffects.DeepWounded },
            { MEDKIT_ID, StatsConstants.DamageEffects.Contusion | StatsConstants.DamageEffects.Wounded | StatsConstants.DamageEffects.DeepWounded | StatsConstants.DamageEffects.BrokenBones }
        };

        public static Dictionary<UniqueEntityId, StatsConstants.DiseaseEffects> REMOVE_DISEASE_EFFECTS = new Dictionary<UniqueEntityId, StatsConstants.DiseaseEffects>()
        {
            { ANTI_INFRAMMATORY_ID, StatsConstants.DiseaseEffects.Infected },
            { ANTIBIOTIC_ID, StatsConstants.DiseaseEffects.Pneumonia },
            { DIGESTIVE_ID, StatsConstants.DiseaseEffects.Dysentery },
            { DETOXIFYING_ID, StatsConstants.DiseaseEffects.Poison },
            { VEGETABLE_SOUP_BOWL_ID, StatsConstants.DiseaseEffects.Hypothermia },
            { MEAT_SOUP_BOWL_ID, StatsConstants.DiseaseEffects.Hypothermia },
            { MUSHROOMPATE_BOWL_ID, StatsConstants.DiseaseEffects.Hypothermia },
            { FISHSOUPBOWL_ID, StatsConstants.DiseaseEffects.Hypothermia },
            { SHRIMPSOUPBOWL_ID, StatsConstants.DiseaseEffects.Hypothermia },
            { COFFEE_CAN_ID, StatsConstants.DiseaseEffects.Hypothermia },
            { WATER_FLASK_MEDIUM_ID, StatsConstants.DiseaseEffects.Hyperthermia },
            { WATER_FLASK_BIG_ID, StatsConstants.DiseaseEffects.Hyperthermia },
            { APPLE_JUICE_ID, StatsConstants.DiseaseEffects.Hyperthermia },
            { SODA_ID, StatsConstants.DiseaseEffects.Hyperthermia }
        };

        public static Dictionary<UniqueEntityId, KeyValuePair<StatsConstants.DiseaseEffects, float>[]> GIVE_DISEASE_EFFECTS = new Dictionary<UniqueEntityId, KeyValuePair<StatsConstants.DiseaseEffects, float>[]>()
        {
            {
                MEAT_ID,
                new KeyValuePair<StatsConstants.DiseaseEffects, float>[]
                {
                    new KeyValuePair<StatsConstants.DiseaseEffects, float>(StatsConstants.DiseaseEffects.Dysentery, 100)
                }
            },
            {
                NOBLE_MEAT_ID,
                new KeyValuePair<StatsConstants.DiseaseEffects, float>[]
                {
                    new KeyValuePair<StatsConstants.DiseaseEffects, float>(StatsConstants.DiseaseEffects.Dysentery, 100)
                }
            },
            {
                ALIEN_MEAT_ID,
                new KeyValuePair<StatsConstants.DiseaseEffects, float>[]
                {
                    new KeyValuePair<StatsConstants.DiseaseEffects, float>(StatsConstants.DiseaseEffects.Dysentery, 100)
                }
            },
            {
                ALIEN_NOBLE_MEAT_ID,
                new KeyValuePair<StatsConstants.DiseaseEffects, float>[]
                {
                    new KeyValuePair<StatsConstants.DiseaseEffects, float>(StatsConstants.DiseaseEffects.Dysentery, 100)
                }
            },
            {
                ALIEN_EGG_ID,
                new KeyValuePair<StatsConstants.DiseaseEffects, float>[]
                {
                    new KeyValuePair<StatsConstants.DiseaseEffects, float>(StatsConstants.DiseaseEffects.Dysentery, 25)
                }
            },
            {
                RAW_SAUSAGE_ID,
                new KeyValuePair<StatsConstants.DiseaseEffects, float>[]
                {
                    new KeyValuePair<StatsConstants.DiseaseEffects, float>(StatsConstants.DiseaseEffects.Dysentery, 100)
                }
            },
            {
                RAW_MEAT_BOWL_ID,
                new KeyValuePair<StatsConstants.DiseaseEffects, float>[]
                {
                    new KeyValuePair<StatsConstants.DiseaseEffects, float>(StatsConstants.DiseaseEffects.Dysentery, 100)
                }
            },
            {
                RAW_NOBLE_MEAT_BOWL_ID,
                new KeyValuePair<StatsConstants.DiseaseEffects, float>[]
                {
                    new KeyValuePair<StatsConstants.DiseaseEffects, float>(StatsConstants.DiseaseEffects.Dysentery, 100)
                }
            },
            {
                AMANITAMUSCARIA_ID,
                new KeyValuePair<StatsConstants.DiseaseEffects, float>[]
                {
                    new KeyValuePair<StatsConstants.DiseaseEffects, float>(StatsConstants.DiseaseEffects.Poison, 100)
                }
            },
            {
                RAW_BROCCOLI_BOWL_ID,
                new KeyValuePair<StatsConstants.DiseaseEffects, float>[]
                {
                    new KeyValuePair<StatsConstants.DiseaseEffects, float>(StatsConstants.DiseaseEffects.Dysentery, 5)
                }
            },
            {
                BROCCOLI_ID,
                new KeyValuePair<StatsConstants.DiseaseEffects, float>[]
                {
                    new KeyValuePair<StatsConstants.DiseaseEffects, float>(StatsConstants.DiseaseEffects.Dysentery, 5)
                }
            },
            {
                BEETROOT_ID,
                new KeyValuePair<StatsConstants.DiseaseEffects, float>[]
                {
                    new KeyValuePair<StatsConstants.DiseaseEffects, float>(StatsConstants.DiseaseEffects.Dysentery, 5)
                }
            },
            {
                CAROOT_ID,
                new KeyValuePair<StatsConstants.DiseaseEffects, float>[]
                {
                    new KeyValuePair<StatsConstants.DiseaseEffects, float>(StatsConstants.DiseaseEffects.Dysentery, 5)
                }
            },
            {
                TOMATO_ID,
                new KeyValuePair<StatsConstants.DiseaseEffects, float>[]
                {
                    new KeyValuePair<StatsConstants.DiseaseEffects, float>(StatsConstants.DiseaseEffects.Dysentery, 5)
                }
            },
            {
                APPLE_ID,
                new KeyValuePair<StatsConstants.DiseaseEffects, float>[]
                {
                    new KeyValuePair<StatsConstants.DiseaseEffects, float>(StatsConstants.DiseaseEffects.Dysentery, 5)
                }
            },
            {
                CHAMPIGNONS_ID,
                new KeyValuePair<StatsConstants.DiseaseEffects, float>[]
                {
                    new KeyValuePair<StatsConstants.DiseaseEffects, float>(StatsConstants.DiseaseEffects.Dysentery, 5)
                }
            },
            {
                SHIITAKE_ID,
                new KeyValuePair<StatsConstants.DiseaseEffects, float>[]
                {
                    new KeyValuePair<StatsConstants.DiseaseEffects, float>(StatsConstants.DiseaseEffects.Dysentery, 5)
                }
            },
            {
                FISHMEAT_ID,
                new KeyValuePair<StatsConstants.DiseaseEffects, float>[]
                {
                    new KeyValuePair<StatsConstants.DiseaseEffects, float>(StatsConstants.DiseaseEffects.Dysentery, 100)
                }
            },
            {
                NOBLEFISHMEAT_ID,
                new KeyValuePair<StatsConstants.DiseaseEffects, float>[]
                {
                    new KeyValuePair<StatsConstants.DiseaseEffects, float>(StatsConstants.DiseaseEffects.Dysentery, 100)
                }
            },
            {
                RAWFISHMEATBOWL_ID,
                new KeyValuePair<StatsConstants.DiseaseEffects, float>[]
                {
                    new KeyValuePair<StatsConstants.DiseaseEffects, float>(StatsConstants.DiseaseEffects.Dysentery, 100)
                }
            },
            {
                SHRIMPMEAT_ID,
                new KeyValuePair<StatsConstants.DiseaseEffects, float>[]
                {
                    new KeyValuePair<StatsConstants.DiseaseEffects, float>(StatsConstants.DiseaseEffects.Dysentery, 100)
                }
            }
        };

        public static readonly List<UniqueEntityId> TREE_IDS = new List<UniqueEntityId>()
        {
            APPLETREESEEDLING_ID,
            APPLETREE_ID
        };

        public static readonly List<UniqueEntityId> ANIMALS_HERBICORES_IDS = new List<UniqueEntityId>()
        {
            COWMALE_ID,
            COWFEMALE_ID,
            COWBABY_ID,
            DEERMALE_ID,
            DEERFEMALE_ID,
            DEERBABY_ID,
            HORSEMALE_ID,
            HORSEFEMALE_ID,
            HORSEBABY_ID,
            SHEEPMALE_ID,
            SHEEPFEMALE_ID,
            SHEEPBABY_ID,
            PIGMALE_ID,
            PIGFEMALE_ID,
            PIGBABY_ID
        };

        public static readonly List<UniqueEntityId> ANIMALS_CARNIVORES_IDS = new List<UniqueEntityId>()
        {
            SPIDERMALE_ID,
            SPIDERFEMALE_ID,
            SPIDERBABY_ID,
            WOLFMALE_ID,
            WOLFFEMALE_ID,
            WOLFBABY_ID,
            PIGMALE_ID,
            PIGFEMALE_ID,
            PIGBABY_ID
        };

        public static readonly List<UniqueEntityId> ANIMALS_BIRDS_IDS = new List<UniqueEntityId>()
        {
            CHICKENMALE_ID,
            CHICKENFEMALE_ID,
            CHICKENBABY_ID
        };

        public static readonly List<UniqueEntityId> ANIMALS_IDS = new List<UniqueEntityId>()
        {
            COWMALE_ID,
            COWFEMALE_ID,
            COWBABY_ID,
            DEERMALE_ID,
            DEERFEMALE_ID,
            DEERBABY_ID,
            HORSEMALE_ID,
            HORSEFEMALE_ID,
            HORSEBABY_ID,
            SHEEPMALE_ID,
            SHEEPFEMALE_ID,
            SHEEPBABY_ID,
            SPIDERMALE_ID,
            SPIDERFEMALE_ID,
            SPIDERBABY_ID,
            WOLFMALE_ID,
            WOLFFEMALE_ID,
            WOLFBABY_ID,
            PIGMALE_ID,
            PIGFEMALE_ID,
            PIGBABY_ID,
            CHICKENMALE_ID,
            CHICKENFEMALE_ID,
            CHICKENBABY_ID
        };

        public static readonly List<UniqueEntityId> DEAD_ANIMALS_IDS = new List<UniqueEntityId>()
        {
            COWDEAD_ID,
            DEERDEAD_ID,
            HORSEDEAD_ID,
            SHEEPDEAD_ID,
            SPIDERDEAD_ID,
            WOLFDEAD_ID,
            PIGDEAD_ID,
            CHICKENDEAD_ID,
            COWBABYDEAD_ID,
            DEERBABYDEAD_ID,
            HORSEBABYDEAD_ID,
            SHEEPBABYDEAD_ID,
            SPIDERBABYDEAD_ID,
            WOLFBABYDEAD_ID,
            PIGBABYDEAD_ID,
            CHICKENBABYDEAD_ID
        };

        public static readonly List<UniqueEntityId> FOODS_IDS = new List<UniqueEntityId>()
        {
            /* WATER FOOD */
            SHRIMP_ID,
            FISH_ID,
            ALIENFISH_ID,
            NOBLEFISH_ID,
            ALIENNOBLEFISH_ID,
            SHRIMPMEAT_ID,
            FISHMEAT_ID,
            NOBLEFISHMEAT_ID,
            RAWFISHMEATBOWL_ID,
            ROASTEDSHRIMP_ID,
            ROASTEDFISH_ID,
            ROASTEDNOBLEFISH_ID,
            FISHMUSHROOM_ID,
            FISHSOUPBOWL_ID,
            SHRIMPSOUPBOWL_ID,
            /* RAW MEAT */
            MEAT_ID,
            ALIEN_MEAT_ID,
            NOBLE_MEAT_ID,
            ALIEN_NOBLE_MEAT_ID,
            RAW_MEAT_BOWL_ID,
            RAW_NOBLE_MEAT_BOWL_ID,
            ALIEN_EGG_ID,
            EGG_ID,
            RAW_SAUSAGE_ID,
            CHICKENMEAT_ID,
            BACON_ID,
            /* MEAT FOOD */
            ROASTED_MEAT_ID,
            ROASTED_SAUSAGE_ID,
            MEATLOAF_ID,
            FRIED_EGG_ID,
            STEW_ID,
            MEATPASTA_ID,
            ROASTEDCHICKEN_ID,
            ROASTEDBACON_ID,
            /* RAW VEGETABLES */
            BROCCOLI_ID,
            BEETROOT_ID,
            CAROOT_ID,
            CHAMPIGNONS_ID,
            SHIITAKE_ID,
            AMANITAMUSCARIA_ID,
            APPLE_ID,
            TOMATO_ID,
            RAW_BROCCOLI_BOWL_ID,
            CAKEDOUGH_ID,
            DOUGH_ID,
            /* VEGETABLE FOOD */
            SALAD_ID,
            BREAD_ID,
            CEREALBAR_ID,
            ROAST_CHAMPIGNON_ID,
            MUSHROOMPATE_BOWL_ID,
            VEGETABLE_SOUP_BOWL_ID,
            VEGETABLEPASTA_ID,
            WATERBREAD_ID,
            FATPORRIDGE_ID,
            PROTEINBAR_ID,
            /* MEALS */
            MEAT_MUSHROOMS_ID,
            MEAT_SOUP_BOWL_ID,
            MEAT_VEGETABLES_ID,
            SANDWICH_ID,
            CHEESE_ID,
            APPLEPIE_ID,
            CHICKENPIE_ID,
            PASTA_ID,
            /* ROT FOOD */
            SPOILED_MATERIAL_ID
        };

        public static readonly long BASE_RAW_MEAT_SPOIL_TIME = 5 * 60 * 1000;
        public static readonly long BASE_RAW_VEGETABLE_SPOIL_TIME = (long)(7.5f * 60 * 1000);
        public static readonly long BASE_MEAT_SPOIL_TIME = 10 * 60 * 1000;
        public static readonly long BASE_VEGETABLE_SPOIL_TIME = 15 * 60 * 1000;
        public static readonly long BASE_MEAL_SPOIL_TIME = 20 * 60 * 1000;

        public static readonly Dictionary<UniqueEntityId, ExtendedSurvivalCoreAPI.ItemExtraInfo> ITEM_EXTRA_INFO_DEF = new Dictionary<UniqueEntityId, ExtendedSurvivalCoreAPI.ItemExtraInfo>()
        {
            {
                MEAT_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = MEAT_ID.DefinitionId,
                    StartConservationTime = BASE_RAW_MEAT_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.1f
                        }
                    }
                }
            },
            {
                ALIEN_MEAT_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = ALIEN_MEAT_ID.DefinitionId,
                    StartConservationTime = BASE_RAW_MEAT_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.1f
                        }
                    }
                }
            },
            {
                CHICKENMEAT_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = CHICKENMEAT_ID.DefinitionId,
                    StartConservationTime = BASE_RAW_MEAT_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.5f
                        }
                    }
                }
            },
            {
                BACON_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = BACON_ID.DefinitionId,
                    StartConservationTime = BASE_RAW_MEAT_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.2f
                        }
                    }
                }
            },
            {
                NOBLE_MEAT_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = NOBLE_MEAT_ID.DefinitionId,
                    StartConservationTime = BASE_RAW_MEAT_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.2f
                        }
                    }
                }
            },
            {
                ALIEN_NOBLE_MEAT_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = ALIEN_NOBLE_MEAT_ID.DefinitionId,
                    StartConservationTime = BASE_RAW_MEAT_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.2f
                        }
                    }
                }
            },
            {
                ALIEN_EGG_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = ALIEN_EGG_ID.DefinitionId,
                    StartConservationTime = BASE_RAW_MEAT_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.05f
                        }
                    }
                }
            },
            {
                EGG_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = EGG_ID.DefinitionId,
                    StartConservationTime = BASE_RAW_MEAT_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.05f
                        }
                    }
                }
            },
            {
                RAW_MEAT_BOWL_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = RAW_MEAT_BOWL_ID.DefinitionId,
                    StartConservationTime = BASE_RAW_MEAT_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.4f
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = BOWL_ID.DefinitionId,
                            Ammount = 1
                        }
                    }
                }
            },
            {
                RAW_NOBLE_MEAT_BOWL_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = RAW_NOBLE_MEAT_BOWL_ID.DefinitionId,
                    StartConservationTime = BASE_RAW_MEAT_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.4f
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = BOWL_ID.DefinitionId,
                            Ammount = 1
                        }
                    }
                }
            },
            {
                RAW_SAUSAGE_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = RAW_SAUSAGE_ID.DefinitionId,
                    StartConservationTime = BASE_RAW_MEAT_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.8f
                        }
                    }
                }
            },
            {
                BROCCOLI_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = BROCCOLI_ID.DefinitionId,
                    StartConservationTime = BASE_RAW_VEGETABLE_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.1f
                        }
                    }
                }
            },
            {
                CAKEDOUGH_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = CAKEDOUGH_ID.DefinitionId,
                    StartConservationTime = BASE_RAW_VEGETABLE_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.5f
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = BOWL_ID.DefinitionId,
                            Ammount = 1
                        }
                    }
                }
            },
            {
                DOUGH_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = DOUGH_ID.DefinitionId,
                    StartConservationTime = BASE_RAW_VEGETABLE_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.5f
                        }
                    }
                }
            },
            {
                BEETROOT_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = BEETROOT_ID.DefinitionId,
                    StartConservationTime = BASE_RAW_VEGETABLE_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.1f
                        }
                    }
                }
            },
            {
                CAROOT_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = CAROOT_ID.DefinitionId,
                    StartConservationTime = BASE_RAW_VEGETABLE_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.1f
                        }
                    }
                }
            },
            {
                TOMATO_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = TOMATO_ID.DefinitionId,
                    StartConservationTime = BASE_RAW_VEGETABLE_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.15f
                        }
                    }
                }
            },
            {
                APPLE_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = APPLE_ID.DefinitionId,
                    StartConservationTime = BASE_RAW_VEGETABLE_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.15f
                        }
                    }
                }
            },
            {
                CHAMPIGNONS_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = CHAMPIGNONS_ID.DefinitionId,
                    StartConservationTime = BASE_RAW_VEGETABLE_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.05f
                        }
                    }
                }
            },
            {
                SHIITAKE_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = SHIITAKE_ID.DefinitionId,
                    StartConservationTime = BASE_RAW_VEGETABLE_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.05f
                        }
                    }
                }
            },
            {
                AMANITAMUSCARIA_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = AMANITAMUSCARIA_ID.DefinitionId,
                    StartConservationTime = BASE_RAW_VEGETABLE_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.05f
                        }
                    }
                }
            },
            {
                RAW_BROCCOLI_BOWL_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = RAW_BROCCOLI_BOWL_ID.DefinitionId,
                    StartConservationTime = BASE_RAW_VEGETABLE_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.5f
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = BOWL_ID.DefinitionId,
                            Ammount = 1
                        }
                    }
                }
            },
            {
                ROASTED_MEAT_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = ROASTED_MEAT_ID.DefinitionId,
                    StartConservationTime = BASE_MEAL_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.1f
                        }
                    }
                }
            },
            {
                ROASTEDCHICKEN_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = ROASTEDCHICKEN_ID.DefinitionId,
                    StartConservationTime = BASE_MEAL_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.8f
                        }
                    }
                }
            },
            {
                ROASTEDBACON_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = ROASTEDBACON_ID.DefinitionId,
                    StartConservationTime = BASE_MEAL_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.8f
                        }
                    }
                }
            },
            {
                ROASTED_SAUSAGE_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = ROASTED_SAUSAGE_ID.DefinitionId,
                    StartConservationTime = BASE_MEAL_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.8f
                        }
                    }
                }
            },
            {
                FRIED_EGG_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = FRIED_EGG_ID.DefinitionId,
                    StartConservationTime = BASE_MEAL_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.05f
                        }
                    }
                }
            },
            {
                STEW_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = STEW_ID.DefinitionId,
                    StartConservationTime = BASE_MEAL_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.55f
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = BOWL_ID.DefinitionId,
                            Ammount = 1
                        }
                    }
                }
            },
            {
                MEATLOAF_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = MEATLOAF_ID.DefinitionId,
                    StartConservationTime = BASE_MEAL_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.95f
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = BOWL_ID.DefinitionId,
                            Ammount = 1
                        }
                    }
                }
            },
            {
                SALAD_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = SALAD_ID.DefinitionId,
                    StartConservationTime = BASE_VEGETABLE_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 1.25f
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = BOWL_ID.DefinitionId,
                            Ammount = 1
                        }
                    }
                }
            },
            {
                BREAD_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = BREAD_ID.DefinitionId,
                    StartConservationTime = BASE_VEGETABLE_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.1f
                        }
                    }
                }
            },
            {
                WATERBREAD_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = WATERBREAD_ID.DefinitionId,
                    StartConservationTime = BASE_VEGETABLE_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.1f
                        }
                    }
                }
            },
            {
                PASTA_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = PASTA_ID.DefinitionId,
                    StartConservationTime = BASE_VEGETABLE_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.1f
                        }
                    }
                }
            },
            {
                ROAST_CHAMPIGNON_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = ROAST_CHAMPIGNON_ID.DefinitionId,
                    StartConservationTime = BASE_VEGETABLE_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.5f
                        }
                    }
                }
            },
            {
                MUSHROOMPATE_BOWL_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = MUSHROOMPATE_BOWL_ID.DefinitionId,
                    StartConservationTime = BASE_VEGETABLE_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.5f
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = BOWL_ID.DefinitionId,
                            Ammount = 1
                        }
                    }
                }
            },
            {
                VEGETABLE_SOUP_BOWL_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = VEGETABLE_SOUP_BOWL_ID.DefinitionId,
                    StartConservationTime = BASE_VEGETABLE_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.75f
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = BOWL_ID.DefinitionId,
                            Ammount = 1
                        }
                    }
                }
            },
            {
                MEAT_VEGETABLES_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = MEAT_VEGETABLES_ID.DefinitionId,
                    StartConservationTime = BASE_MEAL_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 1
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = BOWL_ID.DefinitionId,
                            Ammount = 1
                        }
                    }
                }
            },
            {
                MEAT_MUSHROOMS_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = MEAT_MUSHROOMS_ID.DefinitionId,
                    StartConservationTime = BASE_MEAL_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.8f
                        }
                    }
                }
            },
            {
                VEGETABLEPASTA_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = VEGETABLEPASTA_ID.DefinitionId,
                    StartConservationTime = BASE_MEAL_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.8f
                        }
                    }
                }
            },
            {
                MEATPASTA_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = MEATPASTA_ID.DefinitionId,
                    StartConservationTime = BASE_MEAL_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.8f
                        }
                    }
                }
            },
            {
                APPLEPIE_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = APPLEPIE_ID.DefinitionId,
                    StartConservationTime = BASE_MEAL_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.8f
                        }
                    }
                }
            },
            {
                CHICKENPIE_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = CHICKENPIE_ID.DefinitionId,
                    StartConservationTime = BASE_MEAL_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.8f
                        }
                    }
                }
            },
            {
                CHEESE_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = CHEESE_ID.DefinitionId,
                    StartConservationTime = BASE_MEAL_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.8f
                        }
                    }
                }
            },
            {
                MEAT_SOUP_BOWL_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = MEAT_SOUP_BOWL_ID.DefinitionId,
                    StartConservationTime = BASE_MEAL_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 1.25f
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = BOWL_ID.DefinitionId,
                            Ammount = 1
                        }
                    }
                }
            },
            {
                FATPORRIDGE_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = FATPORRIDGE_ID.DefinitionId,
                    StartConservationTime = BASE_MEAL_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 1.25f
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = BOWL_ID.DefinitionId,
                            Ammount = 1
                        }
                    }
                }
            },
            {
                SANDWICH_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = SANDWICH_ID.DefinitionId,
                    StartConservationTime = BASE_MEAL_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.6f
                        }
                    }
                }
            },
            {
                SHRIMP_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = SHRIMP_ID.DefinitionId,
                    StartConservationTime = BASE_RAW_MEAT_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.1f
                        }
                    }
                }
            },
            {
                FISH_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = FISH_ID.DefinitionId,
                    StartConservationTime = BASE_RAW_MEAT_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.3f
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = FISH_BONES_ID.DefinitionId,
                            Ammount = 0.3f
                        }
                    }
                }
            },
            {
                ALIENFISH_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = ALIENFISH_ID.DefinitionId,
                    StartConservationTime = BASE_RAW_MEAT_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.3f
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = FISH_BONES_ID.DefinitionId,
                            Ammount = 0.3f
                        }
                    }
                }
            },
            {
                NOBLEFISH_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = NOBLEFISH_ID.DefinitionId,
                    StartConservationTime = BASE_RAW_MEAT_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.6f
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = FISH_BONES_ID.DefinitionId,
                            Ammount = 0.6f
                        }
                    }
                }
            },
            {
                ALIENNOBLEFISH_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = ALIENNOBLEFISH_ID.DefinitionId,
                    StartConservationTime = BASE_RAW_MEAT_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.6f
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = FISH_BONES_ID.DefinitionId,
                            Ammount = 0.6f
                        }
                    }
                }
            },
            {
                SHRIMPMEAT_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = SHRIMPMEAT_ID.DefinitionId,
                    StartConservationTime = BASE_RAW_MEAT_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.025f
                        }
                    }
                }
            },
            {
                FISHMEAT_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = FISHMEAT_ID.DefinitionId,
                    StartConservationTime = BASE_RAW_MEAT_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.1f
                        }
                    }
                }
            },
            {
                NOBLEFISHMEAT_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = NOBLEFISHMEAT_ID.DefinitionId,
                    StartConservationTime = BASE_RAW_MEAT_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.2f
                        }
                    }
                }
            },
            {
                RAWFISHMEATBOWL_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = RAWFISHMEATBOWL_ID.DefinitionId,
                    StartConservationTime = BASE_RAW_MEAT_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.4f
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = BOWL_ID.DefinitionId,
                            Ammount = 1
                        }
                    }
                }
            },
            {
                ROASTEDSHRIMP_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = ROASTEDSHRIMP_ID.DefinitionId,
                    StartConservationTime = BASE_MEAT_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.025f
                        }
                    }
                }
            },
            {
                ROASTEDFISH_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = ROASTEDFISH_ID.DefinitionId,
                    StartConservationTime = BASE_MEAT_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.1f
                        }
                    }
                }
            },
            {
                ROASTEDNOBLEFISH_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = ROASTEDNOBLEFISH_ID.DefinitionId,
                    StartConservationTime = BASE_MEAT_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.2f
                        }
                    }
                }
            },
            {
                FISHMUSHROOM_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = FISHMUSHROOM_ID.DefinitionId,
                    StartConservationTime = BASE_MEAL_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.8f
                        }
                    }
                }
            },
            {
                FISHSOUPBOWL_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = FISHSOUPBOWL_ID.DefinitionId,
                    StartConservationTime = BASE_MEAL_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 1.25f
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = BOWL_ID.DefinitionId,
                            Ammount = 1
                        }
                    }
                }
            },
            {
                SHRIMPSOUPBOWL_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = SHRIMPSOUPBOWL_ID.DefinitionId,
                    StartConservationTime = BASE_MEAL_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 1.25f
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = BOWL_ID.DefinitionId,
                            Ammount = 1
                        }
                    }
                }
            },
            {
                COWDEAD_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = COWDEAD_ID.DefinitionId,
                    StartConservationTime = BASE_MEAL_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 60
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = BONES_ID.DefinitionId,
                            Ammount = 45
                        }
                    }
                }
            },
            {
                DEERDEAD_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = DEERDEAD_ID.DefinitionId,
                    StartConservationTime = BASE_MEAL_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 40
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = BONES_ID.DefinitionId,
                            Ammount = 30
                        }
                    }
                }
            },
            {
                HORSEDEAD_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = HORSEDEAD_ID.DefinitionId,
                    StartConservationTime = BASE_MEAL_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 40
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = BONES_ID.DefinitionId,
                            Ammount = 30
                        }
                    }
                }
            },
            {
                SHEEPDEAD_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = SHEEPDEAD_ID.DefinitionId,
                    StartConservationTime = BASE_MEAL_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 20
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = BONES_ID.DefinitionId,
                            Ammount = 15
                        }
                    }
                }
            },
            {
                SPIDERDEAD_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = SPIDERDEAD_ID.DefinitionId,
                    StartConservationTime = BASE_MEAL_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 40
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = BONES_ID.DefinitionId,
                            Ammount = 30
                        }
                    }
                }
            },
            {
                WOLFDEAD_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = WOLFDEAD_ID.DefinitionId,
                    StartConservationTime = BASE_MEAL_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 20
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = BONES_ID.DefinitionId,
                            Ammount = 15
                        }
                    }
                }
            },
            {
                COWBABYDEAD_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = COWBABYDEAD_ID.DefinitionId,
                    StartConservationTime = BASE_MEAL_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 30
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = BONES_ID.DefinitionId,
                            Ammount = 15
                        }
                    }
                }
            },
            {
                DEERBABYDEAD_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = DEERBABYDEAD_ID.DefinitionId,
                    StartConservationTime = BASE_MEAL_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 20
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = BONES_ID.DefinitionId,
                            Ammount = 10
                        }
                    }
                }
            },
            {
                HORSEBABYDEAD_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = HORSEBABYDEAD_ID.DefinitionId,
                    StartConservationTime = BASE_MEAL_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 20
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = BONES_ID.DefinitionId,
                            Ammount = 10
                        }
                    }
                }
            },
            {
                SHEEPBABYDEAD_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = SHEEPBABYDEAD_ID.DefinitionId,
                    StartConservationTime = BASE_MEAL_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 10
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = BONES_ID.DefinitionId,
                            Ammount = 7.5f
                        }
                    }
                }
            },
            {
                SPIDERBABYDEAD_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = SPIDERBABYDEAD_ID.DefinitionId,
                    StartConservationTime = BASE_MEAL_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 20
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = BONES_ID.DefinitionId,
                            Ammount = 10
                        }
                    }
                }
            },
            {
                WOLFBABYDEAD_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = WOLFBABYDEAD_ID.DefinitionId,
                    StartConservationTime = BASE_MEAL_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 10
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = BONES_ID.DefinitionId,
                            Ammount = 7.5f
                        }
                    }
                }
            },
            {
                COWMALE_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = COWMALE_ID.DefinitionId,
                    NeedUpdate = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = COWDEAD_ID.DefinitionId,
                            Ammount = 1
                        }
                    },
                    CustomAttributes = new List<ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_EAT_FACTOR_ID,
                            Value = LivestockConstants.BASE_EAT_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_ABSORCION_FACTOR_ID,
                            Value = LivestockConstants.BASE_ABSORCION_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_POOP_FACTOR_ID,
                            Value = LivestockConstants.BASE_POOP_FACTOR
                        }
                    }
                }
            },
            {
                COWFEMALE_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = COWFEMALE_ID.DefinitionId,
                    NeedUpdate = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = COWDEAD_ID.DefinitionId,
                            Ammount = 1
                        }
                    },
                    CustomAttributes = new List<ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_EAT_FACTOR_ID,
                            Value = LivestockConstants.BASE_EAT_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_ABSORCION_FACTOR_ID,
                            Value = LivestockConstants.BASE_ABSORCION_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_POOP_FACTOR_ID,
                            Value = LivestockConstants.BASE_POOP_FACTOR
                        }
                    }
                }
            },
            {
                COWBABY_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = COWBABY_ID.DefinitionId,
                    NeedUpdate = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = COWBABYDEAD_ID.DefinitionId,
                            Ammount = 1
                        }
                    },
                    CustomAttributes = new List<ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_EAT_FACTOR_ID,
                            Value = LivestockConstants.BASE_EAT_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_ABSORCION_FACTOR_ID,
                            Value = LivestockConstants.BASE_ABSORCION_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_POOP_FACTOR_ID,
                            Value = LivestockConstants.BASE_POOP_FACTOR
                        }
                    }
                }
            },
            {
                DEERMALE_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = DEERMALE_ID.DefinitionId,
                    NeedUpdate = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = DEERDEAD_ID.DefinitionId,
                            Ammount = 1
                        }
                    },
                    CustomAttributes = new List<ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_EAT_FACTOR_ID,
                            Value = LivestockConstants.BASE_EAT_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_ABSORCION_FACTOR_ID,
                            Value = LivestockConstants.BASE_ABSORCION_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_POOP_FACTOR_ID,
                            Value = LivestockConstants.BASE_POOP_FACTOR
                        }
                    }
                }
            },
            {
                DEERFEMALE_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = DEERFEMALE_ID.DefinitionId,
                    NeedUpdate = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = DEERDEAD_ID.DefinitionId,
                            Ammount = 1
                        }
                    },
                    CustomAttributes = new List<ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_EAT_FACTOR_ID,
                            Value = LivestockConstants.BASE_EAT_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_ABSORCION_FACTOR_ID,
                            Value = LivestockConstants.BASE_ABSORCION_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_POOP_FACTOR_ID,
                            Value = LivestockConstants.BASE_POOP_FACTOR
                        }
                    }
                }
            },
            {
                DEERBABY_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = DEERBABY_ID.DefinitionId,
                    NeedUpdate = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = DEERBABYDEAD_ID.DefinitionId,
                            Ammount = 1
                        }
                    },
                    CustomAttributes = new List<ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_EAT_FACTOR_ID,
                            Value = LivestockConstants.BASE_EAT_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_ABSORCION_FACTOR_ID,
                            Value = LivestockConstants.BASE_ABSORCION_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_POOP_FACTOR_ID,
                            Value = LivestockConstants.BASE_POOP_FACTOR
                        }
                    }
                }
            },
            {
                HORSEMALE_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = HORSEMALE_ID.DefinitionId,
                    NeedUpdate = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = HORSEDEAD_ID.DefinitionId,
                            Ammount = 1
                        }
                    },
                    CustomAttributes = new List<ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_EAT_FACTOR_ID,
                            Value = LivestockConstants.BASE_EAT_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_ABSORCION_FACTOR_ID,
                            Value = LivestockConstants.BASE_ABSORCION_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_POOP_FACTOR_ID,
                            Value = LivestockConstants.BASE_POOP_FACTOR
                        }
                    }
                }
            },
            {
                HORSEFEMALE_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = HORSEFEMALE_ID.DefinitionId,
                    NeedUpdate = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = HORSEDEAD_ID.DefinitionId,
                            Ammount = 1
                        }
                    },
                    CustomAttributes = new List<ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_EAT_FACTOR_ID,
                            Value = LivestockConstants.BASE_EAT_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_ABSORCION_FACTOR_ID,
                            Value = LivestockConstants.BASE_ABSORCION_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_POOP_FACTOR_ID,
                            Value = LivestockConstants.BASE_POOP_FACTOR
                        }
                    }
                }
            },
            {
                HORSEBABY_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = HORSEBABY_ID.DefinitionId,
                    NeedUpdate = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = HORSEBABYDEAD_ID.DefinitionId,
                            Ammount = 1
                        }
                    },
                    CustomAttributes = new List<ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_EAT_FACTOR_ID,
                            Value = LivestockConstants.BASE_EAT_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_ABSORCION_FACTOR_ID,
                            Value = LivestockConstants.BASE_ABSORCION_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_POOP_FACTOR_ID,
                            Value = LivestockConstants.BASE_POOP_FACTOR
                        }
                    }
                }
            },
            {
                SHEEPMALE_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = SHEEPMALE_ID.DefinitionId,
                    NeedUpdate = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SHEEPDEAD_ID.DefinitionId,
                            Ammount = 1
                        }
                    },
                    CustomAttributes = new List<ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_EAT_FACTOR_ID,
                            Value = LivestockConstants.BASE_EAT_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_ABSORCION_FACTOR_ID,
                            Value = LivestockConstants.BASE_ABSORCION_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_POOP_FACTOR_ID,
                            Value = LivestockConstants.BASE_POOP_FACTOR
                        }
                    }
                }
            },
            {
                SHEEPFEMALE_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = SHEEPFEMALE_ID.DefinitionId,
                    NeedUpdate = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SHEEPDEAD_ID.DefinitionId,
                            Ammount = 1
                        }
                    },
                    CustomAttributes = new List<ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_EAT_FACTOR_ID,
                            Value = LivestockConstants.BASE_EAT_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_ABSORCION_FACTOR_ID,
                            Value = LivestockConstants.BASE_ABSORCION_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_POOP_FACTOR_ID,
                            Value = LivestockConstants.BASE_POOP_FACTOR
                        }
                    }
                }
            },
            {
                SHEEPBABY_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = SHEEPBABY_ID.DefinitionId,
                    NeedUpdate = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SHEEPBABYDEAD_ID.DefinitionId,
                            Ammount = 1
                        }
                    },
                    CustomAttributes = new List<ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_EAT_FACTOR_ID,
                            Value = LivestockConstants.BASE_EAT_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_ABSORCION_FACTOR_ID,
                            Value = LivestockConstants.BASE_ABSORCION_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_POOP_FACTOR_ID,
                            Value = LivestockConstants.BASE_POOP_FACTOR
                        }
                    }
                }
            },
            {
                SPIDERMALE_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = SPIDERMALE_ID.DefinitionId,
                    NeedUpdate = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPIDERDEAD_ID.DefinitionId,
                            Ammount = 1
                        }
                    },
                    CustomAttributes = new List<ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_EAT_FACTOR_ID,
                            Value = LivestockConstants.BASE_EAT_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_ABSORCION_FACTOR_ID,
                            Value = LivestockConstants.BASE_ABSORCION_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_POOP_FACTOR_ID,
                            Value = LivestockConstants.BASE_POOP_FACTOR
                        }
                    }
                }
            },
            {
                SPIDERFEMALE_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = SPIDERFEMALE_ID.DefinitionId,
                    NeedUpdate = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPIDERDEAD_ID.DefinitionId,
                            Ammount = 1
                        }
                    },
                    CustomAttributes = new List<ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_EAT_FACTOR_ID,
                            Value = LivestockConstants.BASE_EAT_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_ABSORCION_FACTOR_ID,
                            Value = LivestockConstants.BASE_ABSORCION_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_POOP_FACTOR_ID,
                            Value = LivestockConstants.BASE_POOP_FACTOR
                        }
                    }
                }
            },
            {
                SPIDERBABY_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = SPIDERBABY_ID.DefinitionId,
                    NeedUpdate = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPIDERBABYDEAD_ID.DefinitionId,
                            Ammount = 1
                        }
                    },
                    CustomAttributes = new List<ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_EAT_FACTOR_ID,
                            Value = LivestockConstants.BASE_EAT_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_ABSORCION_FACTOR_ID,
                            Value = LivestockConstants.BASE_ABSORCION_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_POOP_FACTOR_ID,
                            Value = LivestockConstants.BASE_POOP_FACTOR
                        }
                    }
                }
            },
            {
                WOLFMALE_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = WOLFMALE_ID.DefinitionId,
                    NeedUpdate = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = WOLFDEAD_ID.DefinitionId,
                            Ammount = 1
                        }
                    },
                    CustomAttributes = new List<ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_EAT_FACTOR_ID,
                            Value = LivestockConstants.BASE_EAT_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_ABSORCION_FACTOR_ID,
                            Value = LivestockConstants.BASE_ABSORCION_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_POOP_FACTOR_ID,
                            Value = LivestockConstants.BASE_POOP_FACTOR
                        }
                    }
                }
            },
            {
                WOLFFEMALE_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = WOLFFEMALE_ID.DefinitionId,
                    NeedUpdate = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = WOLFDEAD_ID.DefinitionId,
                            Ammount = 1
                        }
                    },
                    CustomAttributes = new List<ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_EAT_FACTOR_ID,
                            Value = LivestockConstants.BASE_EAT_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_ABSORCION_FACTOR_ID,
                            Value = LivestockConstants.BASE_ABSORCION_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_POOP_FACTOR_ID,
                            Value = LivestockConstants.BASE_POOP_FACTOR
                        }
                    }
                }
            },
            {
                WOLFBABY_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = WOLFBABY_ID.DefinitionId,
                    NeedUpdate = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = WOLFBABYDEAD_ID.DefinitionId,
                            Ammount = 1
                        }
                    },
                    CustomAttributes = new List<ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_EAT_FACTOR_ID,
                            Value = LivestockConstants.BASE_EAT_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_ABSORCION_FACTOR_ID,
                            Value = LivestockConstants.BASE_ABSORCION_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_POOP_FACTOR_ID,
                            Value = LivestockConstants.BASE_POOP_FACTOR
                        }
                    }
                }
            },
            {
                CHICKENBABYDEAD_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = CHICKENBABYDEAD_ID.DefinitionId,
                    StartConservationTime = BASE_MEAL_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 0.8f
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = BONES_ID.DefinitionId,
                            Ammount = 0.2f
                        }
                    }
                }
            },
            {
                PIGBABYDEAD_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = PIGBABYDEAD_ID.DefinitionId,
                    StartConservationTime = BASE_MEAL_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 20
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = BONES_ID.DefinitionId,
                            Ammount = 10
                        }
                    }
                }
            },
            {
                CHICKENDEAD_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = CHICKENDEAD_ID.DefinitionId,
                    StartConservationTime = BASE_MEAL_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 8
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = BONES_ID.DefinitionId,
                            Ammount = 2
                        }
                    }
                }
            },
            {
                PIGDEAD_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = PIGDEAD_ID.DefinitionId,
                    StartConservationTime = BASE_MEAL_SPOIL_TIME,
                    NeedUpdate = true,
                    NeedConservation = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 40
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = BONES_ID.DefinitionId,
                            Ammount = 30
                        }
                    }
                }
            },
            {
                CHICKENMALE_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = CHICKENMALE_ID.DefinitionId,
                    NeedUpdate = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = CHICKENDEAD_ID.DefinitionId,
                            Ammount = 1
                        }
                    },
                    CustomAttributes = new List<ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_EAT_FACTOR_ID,
                            Value = LivestockConstants.BASE_EAT_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_ABSORCION_FACTOR_ID,
                            Value = LivestockConstants.BASE_ABSORCION_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_POOP_FACTOR_ID,
                            Value = LivestockConstants.BASE_POOP_FACTOR
                        }
                    }
                }
            },
            {
                CHICKENFEMALE_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = CHICKENFEMALE_ID.DefinitionId,
                    NeedUpdate = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = CHICKENDEAD_ID.DefinitionId,
                            Ammount = 1
                        }
                    },
                    CustomAttributes = new List<ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_EAT_FACTOR_ID,
                            Value = LivestockConstants.BASE_EAT_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_ABSORCION_FACTOR_ID,
                            Value = LivestockConstants.BASE_ABSORCION_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_POOP_FACTOR_ID,
                            Value = LivestockConstants.BASE_POOP_FACTOR
                        }
                    }
                }
            },
            {
                CHICKENBABY_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = CHICKENBABY_ID.DefinitionId,
                    NeedUpdate = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = CHICKENBABYDEAD_ID.DefinitionId,
                            Ammount = 1
                        }
                    },
                    CustomAttributes = new List<ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_EAT_FACTOR_ID,
                            Value = LivestockConstants.BASE_EAT_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_ABSORCION_FACTOR_ID,
                            Value = LivestockConstants.BASE_ABSORCION_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_POOP_FACTOR_ID,
                            Value = LivestockConstants.BASE_POOP_FACTOR
                        }
                    }
                }
            },
            {
                PIGMALE_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = PIGMALE_ID.DefinitionId,
                    NeedUpdate = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = PIGDEAD_ID.DefinitionId,
                            Ammount = 1
                        }
                    },
                    CustomAttributes = new List<ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_EAT_FACTOR_ID,
                            Value = LivestockConstants.BASE_EAT_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_ABSORCION_FACTOR_ID,
                            Value = LivestockConstants.BASE_ABSORCION_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_POOP_FACTOR_ID,
                            Value = LivestockConstants.BASE_POOP_FACTOR
                        }
                    }
                }
            },
            {
                PIGFEMALE_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = PIGFEMALE_ID.DefinitionId,
                    NeedUpdate = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = PIGDEAD_ID.DefinitionId,
                            Ammount = 1
                        }
                    },
                    CustomAttributes = new List<ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_EAT_FACTOR_ID,
                            Value = LivestockConstants.BASE_EAT_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_ABSORCION_FACTOR_ID,
                            Value = LivestockConstants.BASE_ABSORCION_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_POOP_FACTOR_ID,
                            Value = LivestockConstants.BASE_POOP_FACTOR
                        }
                    }
                }
            },
            {
                PIGBABY_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = PIGBABY_ID.DefinitionId,
                    NeedUpdate = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = PIGBABYDEAD_ID.DefinitionId,
                            Ammount = 1
                        }
                    },
                    CustomAttributes = new List<ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_EAT_FACTOR_ID,
                            Value = LivestockConstants.BASE_EAT_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_ABSORCION_FACTOR_ID,
                            Value = LivestockConstants.BASE_ABSORCION_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_POOP_FACTOR_ID,
                            Value = LivestockConstants.BASE_POOP_FACTOR
                        }
                    }
                }
            },
            {
                APPLETREESEEDLING_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = APPLETREESEEDLING_ID.DefinitionId,
                    NeedUpdate = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 2.5f
                        }
                    }
                }
            },
            {
                APPLETREE_ID,
                new ExtendedSurvivalCoreAPI.ItemExtraInfo()
                {
                    DefinitionId = APPLETREE_ID.DefinitionId,
                    NeedUpdate = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = TREEDEAD_ID.DefinitionId,
                            Ammount = 1
                        }
                    }
                }
            }
        };

        private static ConcurrentDictionary<UniqueEntityId, MyObjectBuilder_Base> BUILDERS_CACHE = new ConcurrentDictionary<UniqueEntityId, MyObjectBuilder_Base>();

        public static T GetBuilder<T>(UniqueEntityId id, bool cache = true) where T : MyObjectBuilder_Base
        {
            if (cache && BUILDERS_CACHE.ContainsKey(id))
                return BUILDERS_CACHE[id] as T;
            var builder = MyObjectBuilderSerializer.CreateNewObject(id.DefinitionId) as T;
            BUILDERS_CACHE[id] = builder;
            return builder as T;
        }

        public static MyObjectBuilder_PhysicalObject GetPhysicalObjectBuilder(UniqueEntityId id)
        {
            return GetBuilder<MyObjectBuilder_PhysicalObject>(id);
        }

        public static MyObjectBuilder_GasContainerObject GetGasContainerBuilder(UniqueEntityId id, float gasLevel = 0)
        {
            var builder = GetBuilder<MyObjectBuilder_GasContainerObject>(id, false);
            builder.GasLevel = gasLevel;
            return builder;
        }

    }

}
