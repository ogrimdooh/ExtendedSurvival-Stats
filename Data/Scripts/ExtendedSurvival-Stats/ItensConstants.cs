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

        public const string STEEL_SUBTYPEID = "Steel";
        public static readonly UniqueEntityId STEEL_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), STEEL_SUBTYPEID);

        public const string CARBONGEAR_SUBTYPEID = "CarbonGear";
        public static readonly UniqueEntityId CARBONGEAR_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), CARBONGEAR_SUBTYPEID);

        public const string NICKELGEAR_SUBTYPEID = "NickelGear";
        public static readonly UniqueEntityId NICKELGEAR_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), NICKELGEAR_SUBTYPEID);

        public const string COPPERWIRE_SUBTYPEID = "CopperWire";
        public static readonly UniqueEntityId COPPERWIRE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), COPPERWIRE_SUBTYPEID);

        public const string TRANSISTOR_SUBTYPEID = "Transistor";
        public static readonly UniqueEntityId TRANSISTOR_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), TRANSISTOR_SUBTYPEID);

        public const string CAPACITOR_SUBTYPEID = "Capacitor";
        public static readonly UniqueEntityId CAPACITOR_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), CAPACITOR_SUBTYPEID);

        public const string CHIP_SUBTYPEID = "Chip";
        public static readonly UniqueEntityId CHIP_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), CHIP_SUBTYPEID);

        public const string LEAF_SUBTYPEID = "Leaf";
        public static readonly UniqueEntityId LEAF_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), LEAF_SUBTYPEID);

        public const string TWIG_SUBTYPEID = "Twig";
        public static readonly UniqueEntityId TWIG_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), TWIG_SUBTYPEID);

        public const string BRANCH_SUBTYPEID = "Branch";
        public static readonly UniqueEntityId BRANCH_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), BRANCH_SUBTYPEID);

        public const string SOILPOWDER_SUBTYPEID = "Soil";
        public static readonly UniqueEntityId SOILPOWDER_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), SOILPOWDER_SUBTYPEID);
        
        public const string COBALTSTEEL_SUBTYPEID = "CobaltSteel";
        public static readonly UniqueEntityId COBALTSTEEL_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), COBALTSTEEL_SUBTYPEID);

        public const string ENHANCEDCHIP_SUBTYPEID = "EnhancedChip";
        public static readonly UniqueEntityId ENHANCEDCHIP_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), ENHANCEDCHIP_SUBTYPEID);

        public const string SILICON_SUBTYPEID = "Silicon";
        public static readonly UniqueEntityId SILICON_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), SILICON_SUBTYPEID);
        public static readonly UniqueEntityId SILICON_Ore_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), SILICON_SUBTYPEID);

        public const string COBALT_SUBTYPEID = "Cobalt";
        public static readonly UniqueEntityId COBALT_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), COBALT_SUBTYPEID);
        public static readonly UniqueEntityId COBALT_Ore_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), COBALT_SUBTYPEID);

        public const string PLATINUM_SUBTYPEID = "Platinum";
        public static readonly UniqueEntityId PLATINUM_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), PLATINUM_SUBTYPEID);
        public static readonly UniqueEntityId PLATINUM_Ore_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), PLATINUM_SUBTYPEID);

        public const string URANIUM_SUBTYPEID = "Platinum";
        public static readonly UniqueEntityId URANIUM_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), URANIUM_SUBTYPEID);
        public static readonly UniqueEntityId URANIUM_Ore_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), URANIUM_SUBTYPEID);

        public const string CARBON_SUBTYPEID = "Carbon";
        public static readonly UniqueEntityId CARBON_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), CARBON_SUBTYPEID);
        public static readonly UniqueEntityId CARBON_Ore_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), CARBON_SUBTYPEID);

        public const string IRON_SUBTYPEID = "Iron";
        public static readonly UniqueEntityId IRON_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), IRON_SUBTYPEID);
        public static readonly UniqueEntityId IRON_Ore_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), IRON_SUBTYPEID);

        public const string NICKEL_SUBTYPEID = "Nickel";
        public static readonly UniqueEntityId NICKEL_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), NICKEL_SUBTYPEID);
        public static readonly UniqueEntityId NICKEL_Ore_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), NICKEL_SUBTYPEID);
        
        public const string STEELGEAR_SUBTYPEID = "SteelGear";
        public static readonly UniqueEntityId STEELGEAR_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), STEELGEAR_SUBTYPEID);

        public const string SILVERCONNECTOR_SUBTYPEID = "SilverConnector";
        public static readonly UniqueEntityId SILVERCONNECTOR_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), SILVERCONNECTOR_SUBTYPEID);

        public const string ELITECHIP_SUBTYPEID = "EliteChip";
        public static readonly UniqueEntityId ELITECHIP_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), ELITECHIP_SUBTYPEID);

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

        public const string HEALTHINJECTION_SUBTYPEID = "HealthInjection";
        public static readonly UniqueEntityId HEALTHINJECTION_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), HEALTHINJECTION_SUBTYPEID);

        public const string HEALTHPOWERINJECTION_SUBTYPEID = "HealthPowerInjection";
        public static readonly UniqueEntityId HEALTHPOWERINJECTION_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), HEALTHPOWERINJECTION_SUBTYPEID);

        public const string SIMPLEMEDICINE_SUBTYPEID = "SimpleMedicine";
        public static readonly UniqueEntityId SIMPLEMEDICINE_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), SIMPLEMEDICINE_SUBTYPEID);

        public const string MEDICINE_SUBTYPEID = "Medicine";
        public static readonly UniqueEntityId MEDICINE_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), MEDICINE_SUBTYPEID);

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

        public const string SMALLALOEVERAEXTRACT_SUBTYPEID = "SmallAloeVeraExtract";
        public static readonly UniqueEntityId SMALLALOEVERAEXTRACT_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), SMALLALOEVERAEXTRACT_SUBTYPEID);
        
        public const string ALOEVERAEXTRACT_SUBTYPEID = "AloeVeraExtract";
        public static readonly UniqueEntityId ALOEVERAEXTRACT_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), ALOEVERAEXTRACT_SUBTYPEID);
        
        public const string SILVERSULFADIAZINE_SUBTYPEID = "SilverSulfadiazine";
        public static readonly UniqueEntityId SILVERSULFADIAZINE_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), SILVERSULFADIAZINE_SUBTYPEID);
        
        public const string ARNICAEXTRACT_SUBTYPEID = "ArnicaExtract";
        public static readonly UniqueEntityId ARNICAEXTRACT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), ARNICAEXTRACT_SUBTYPEID);

        public const string MINTEXTRACT_SUBTYPEID = "MintExtract";
        public static readonly UniqueEntityId MINTEXTRACT_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), MINTEXTRACT_SUBTYPEID);

        public const string CHAMOMILEEXTRACT_SUBTYPEID = "ChamomileExtract";
        public static readonly UniqueEntityId CHAMOMILEEXTRACT_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), CHAMOMILEEXTRACT_SUBTYPEID);

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
            { SIMPLEMEDICINE_ID, StatsConstants.DamageEffects.Contusion | StatsConstants.DamageEffects.Wounded },
            { MEDICINE_ID, StatsConstants.DamageEffects.Contusion | StatsConstants.DamageEffects.Wounded },
            { POWER_BANDAGES_ID, StatsConstants.DamageEffects.Contusion | StatsConstants.DamageEffects.Wounded },
            { HEALTH_BUSTER_ID, StatsConstants.DamageEffects.Contusion | StatsConstants.DamageEffects.Wounded | StatsConstants.DamageEffects.DeepWounded },
            { HEALTHINJECTION_ID, StatsConstants.DamageEffects.Contusion | StatsConstants.DamageEffects.Wounded | StatsConstants.DamageEffects.DeepWounded },
            { HEALTHPOWERINJECTION_ID, StatsConstants.DamageEffects.Contusion | StatsConstants.DamageEffects.Wounded | StatsConstants.DamageEffects.DeepWounded },
            { MEDKIT_ID, StatsConstants.DamageEffects.Contusion | StatsConstants.DamageEffects.Wounded | StatsConstants.DamageEffects.DeepWounded | StatsConstants.DamageEffects.BrokenBones }
        };

        public static Dictionary<UniqueEntityId, StatsConstants.DiseaseEffects> REMOVE_DISEASE_EFFECTS = new Dictionary<UniqueEntityId, StatsConstants.DiseaseEffects>()
        {
            { HEALTHINJECTION_ID, StatsConstants.DiseaseEffects.Infected },
            { HEALTHPOWERINJECTION_ID, StatsConstants.DiseaseEffects.Pneumonia },
            { SIMPLEMEDICINE_ID, StatsConstants.DiseaseEffects.Dysentery | StatsConstants.DiseaseEffects.Queasy },
            { MEDICINE_ID, StatsConstants.DiseaseEffects.Poison }
        };

        public static readonly List<UniqueEntityId> TREE_IDS = new List<UniqueEntityId>()
        {
            APPLETREESEEDLING_ID,
            APPLETREE_ID
        };

        public static readonly long BASE_RAW_MEAT_SPOIL_TIME = 5 * 60 * 1000;
        public static readonly long BASE_RAW_VEGETABLE_SPOIL_TIME = (long)(7.5f * 60 * 1000);
        public static readonly long BASE_MEAT_SPOIL_TIME = 10 * 60 * 1000;
        public static readonly long BASE_VEGETABLE_SPOIL_TIME = 15 * 60 * 1000;
        public static readonly long BASE_MEAL_SPOIL_TIME = 20 * 60 * 1000;

        public static readonly Dictionary<UniqueEntityId, ExtendedSurvivalCoreAPI.ItemExtraInfo> ITEM_EXTRA_INFO_DEF = new Dictionary<UniqueEntityId, ExtendedSurvivalCoreAPI.ItemExtraInfo>()
        {            
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
