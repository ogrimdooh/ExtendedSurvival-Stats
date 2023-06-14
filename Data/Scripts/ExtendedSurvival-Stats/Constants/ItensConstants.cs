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
        public const string ASSEMBLER_ARMORS_BLUEPRINTS = "Assembler_Armors_Blueprints";
        public const string ASSEMBLER_ARMORS_VANILLA_BLUEPRINTS = "Assembler_Armors_Vanilla_Blueprints";

        public const string BASICASSEMBLER_BOTTLES_BLUEPRINTS = "BasicAssembler_Bottles_Blueprints";
        public const string BASICASSEMBLER_ARMORS_BLUEPRINTS = "BasicAssembler_Armors_Blueprints";
        public const string BASICASSEMBLER_ARMORS_VANILLA_BLUEPRINTS = "BasicAssembler_Armors_Vanilla_Blueprints";

        public const string ALCHEMYBENCH_MORTARANDPASTE_BLUEPRINTS = "AlchemyBench_MortarAndPaste_Blueprints";
        public const string ALCHEMYBENCH_CONCENTRATE_BLUEPRINTS = "AlchemyBench_Concentrate_Blueprints";
        public const string ALCHEMYBENCH_MEDICAL_BLUEPRINTS = "AlchemyBench_Medical_Blueprints";
        public const string ALCHEMYBENCH_FERTILIZER_BLUEPRINTS = "AlchemyBench_Fertilizer_Blueprints";

        public const string ALCHEMYBENCH_LIQUIDALCHEMY_BLUEPRINTS = "AlchemyBench_LiquidAlchemy_Blueprints";
        public const string BASICALCHEMYBENCH_LIQUIDALCHEMY_BLUEPRINTS = "BasicAlchemyBench_LiquidAlchemy_Blueprints";
        public const string SMALLBASICALCHEMYBENCH_LIQUIDALCHEMY_BLUEPRINTS = "SmallBasicAlchemyBench_LiquidAlchemy_Blueprints";

        public const string BASICALCHEMYBENCH_CONCENTRATE_BLUEPRINTS = "BasicAlchemyBench_Concentrate_Blueprints";
        public const string BASICALCHEMYBENCH_MEDICAL_BLUEPRINTS = "BasicAlchemyBench_Medical_Blueprints";
        public const string BASICALCHEMYBENCH_FERTILIZER_BLUEPRINTS = "BasicAlchemyBench_Fertilizer_Blueprints";

        public const string SURVIVALKIT_SURVIVAL_BLUEPRINTS = "SurvivalKit_Survival_Blueprints";
        public const string SURVIVALKIT_MEDICAL_BLUEPRINTS = "SurvivalKit_Medical_Blueprints";
        public const string SURVIVALKIT_ARMORS_BLUEPRINTS = "SurvivalKit_Armors_Blueprints";
        public const string SURVIVALKIT_ARMORS_VANILLA_BLUEPRINTS = "SurvivalKit_Armors_Vanilla_Blueprints";
        public const string SURVIVALKIT_REFINE_BLUEPRINTS = "SurvivalKit_Refine_Blueprints";
        public const string SURVIVALKIT_BOTTLES_BLUEPRINTS = "SurvivalKit_Bottles_Blueprints";
        public const string SURVIVALKIT_ALCHEMY_BLUEPRINTS = "SurvivalKit_Alchemy_Blueprints";
        public const string SURVIVALKIT_CONSUMABLES_BLUEPRINTS = "SurvivalKit_Consumables";

        public const string WOOD_SUBTYPEID = "Wood";
        public static readonly UniqueEntityId WOODLOG_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), WOOD_SUBTYPEID);

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

        public const string EMPTYPISTOLMAGAZINE_SUBTYPEID = "EmptyPistolMagazine";
        public static readonly UniqueEntityId EMPTYPISTOLMAGAZINE_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), EMPTYPISTOLMAGAZINE_SUBTYPEID);

        public const string IRONSCREW_SUBTYPEID = "IronScrew";
        public static readonly UniqueEntityId IRONSCREW_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), IRONSCREW_SUBTYPEID);

        public const string STEELSCREW_SUBTYPEID = "SteelScrew";
        public static readonly UniqueEntityId STEELSCREW_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), STEELSCREW_SUBTYPEID);

        public const string SAND_SUBTYPEID = "Sand";
        public static readonly UniqueEntityId SAND_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), SAND_SUBTYPEID);

        public const string ALUMINUMMG_INGOT_SUBTYPEID = "AluminumMg";
        public static readonly UniqueEntityId ALUMINUMMG_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), ALUMINUMMG_INGOT_SUBTYPEID);

        public const string BRASS_SUBTYPEID = "Brass";
        public static readonly UniqueEntityId BRASS_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), BRASS_SUBTYPEID);

        public const string PLATINUMIR_SUBTYPEID = "PlatinumIr";
        public static readonly UniqueEntityId PLATINUMIR_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), PLATINUMIR_SUBTYPEID);

        public const string BERYLLIUMSTEEL_SUBTYPEID = "BerylliumSteel";
        public static readonly UniqueEntityId BERYLLIUMSTEEL_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), BERYLLIUMSTEEL_SUBTYPEID);

        public const string BERYLLIUMCOPPER_SUBTYPEID = "BerylliumCopper";
        public static readonly UniqueEntityId BERYLLIUMCOPPER_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), BERYLLIUMCOPPER_SUBTYPEID);

        public const string TUNGSTENSTEEL_SUBTYPEID = "TungstenSteel";
        public static readonly UniqueEntityId TUNGSTENSTEEL_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), TUNGSTENSTEEL_SUBTYPEID);

        public const string TITANIUMSTEEL_SUBTYPEID = "TitaniumSteel";
        public static readonly UniqueEntityId TITANIUMSTEEL_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), TITANIUMSTEEL_SUBTYPEID);

        public const string SILICON_SUBTYPEID = "Silicon";
        public static readonly UniqueEntityId SILICON_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), SILICON_SUBTYPEID);
        public static readonly UniqueEntityId SILICON_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), SILICON_SUBTYPEID);

        public const string COBALT_SUBTYPEID = "Cobalt";
        public static readonly UniqueEntityId COBALT_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), COBALT_SUBTYPEID);
        public static readonly UniqueEntityId COBALT_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), COBALT_SUBTYPEID);

        public const string SILVER_SUBTYPEID = "Silver";
        public static readonly UniqueEntityId SILVER_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), SILVER_SUBTYPEID);
        public static readonly UniqueEntityId SILVER_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), SILVER_SUBTYPEID);

        public const string GOLD_SUBTYPEID = "Gold";
        public static readonly UniqueEntityId GOLD_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), GOLD_SUBTYPEID);
        public static readonly UniqueEntityId GOLD_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), GOLD_SUBTYPEID);

        public const string PLATINUM_SUBTYPEID = "Platinum";
        public static readonly UniqueEntityId PLATINUM_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), PLATINUM_SUBTYPEID);
        public static readonly UniqueEntityId PLATINUM_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), PLATINUM_SUBTYPEID);

        public const string URANIUM_SUBTYPEID = "Platinum";
        public static readonly UniqueEntityId URANIUM_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), URANIUM_SUBTYPEID);
        public static readonly UniqueEntityId URANIUM_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), URANIUM_SUBTYPEID);

        public const string CARBON_SUBTYPEID = "Carbon";
        public static readonly UniqueEntityId CARBON_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), CARBON_SUBTYPEID);
        public static readonly UniqueEntityId CARBON_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), CARBON_SUBTYPEID);

        public const string IRON_SUBTYPEID = "Iron";
        public static readonly UniqueEntityId IRON_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), IRON_SUBTYPEID);
        public static readonly UniqueEntityId IRON_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), IRON_SUBTYPEID);

        public const string NICKEL_SUBTYPEID = "Nickel";
        public static readonly UniqueEntityId NICKEL_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), NICKEL_SUBTYPEID);
        public static readonly UniqueEntityId NICKEL_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), NICKEL_SUBTYPEID);

        public const string ZINC_SUBTYPEID = "Zinc";
        public static readonly UniqueEntityId ZINC_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), ZINC_SUBTYPEID);
        public static readonly UniqueEntityId ZINC_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), ZINC_SUBTYPEID);

        public const string COPPER_SUBTYPEID = "Copper";
        public static readonly UniqueEntityId COPPER_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), COPPER_SUBTYPEID);
        public static readonly UniqueEntityId COPPER_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), COPPER_SUBTYPEID);

        public const string LEAD_SUBTYPEID = "Lead";
        public static readonly UniqueEntityId LEAD_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), LEAD_SUBTYPEID);
        public static readonly UniqueEntityId LEAD_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), LEAD_SUBTYPEID);

        public const string LITHIUM_SUBTYPEID = "Lithium";
        public static readonly UniqueEntityId LITHIUM_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), LITHIUM_SUBTYPEID);
        public static readonly UniqueEntityId LITHIUM_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), LITHIUM_SUBTYPEID);

        public const string TUNGSTEN_SUBTYPEID = "Tungsten";
        public static readonly UniqueEntityId TUNGSTEN_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), TUNGSTEN_SUBTYPEID);
        public static readonly UniqueEntityId TUNGSTEN_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), TUNGSTEN_SUBTYPEID);

        public const string TITANIUM_SUBTYPEID = "Titanium";
        public static readonly UniqueEntityId TITANIUM_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), TITANIUM_SUBTYPEID);
        public static readonly UniqueEntityId TITANIUM_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), TITANIUM_SUBTYPEID);

        public const string IRIDIUM_SUBTYPEID = "Iridium";
        public static readonly UniqueEntityId IRIDIUM_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), IRIDIUM_SUBTYPEID);
        public static readonly UniqueEntityId IRIDIUM_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), IRIDIUM_SUBTYPEID);

        public const string MERCURY_SUBTYPEID = "Mercury";
        public static readonly UniqueEntityId MERCURY_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), MERCURY_SUBTYPEID);
        public static readonly UniqueEntityId MERCURY_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), MERCURY_SUBTYPEID);

        public const string ALUMINUM_SUBTYPEID = "Aluminum";
        public static readonly UniqueEntityId ALUMINUM_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), ALUMINUM_SUBTYPEID);
        public static readonly UniqueEntityId ALUMINUM_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), ALUMINUM_SUBTYPEID);

        public const string MAGNESIUM_SUBTYPEID = "Magnesium";
        public static readonly UniqueEntityId MAGNESIUM_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), MAGNESIUM_SUBTYPEID);
        public static readonly UniqueEntityId MAGNESIUM_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), MAGNESIUM_SUBTYPEID);

        public const string POTASSIUM_SUBTYPEID = "Potassium";
        public static readonly UniqueEntityId POTASSIUM_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), POTASSIUM_SUBTYPEID);
        public static readonly UniqueEntityId POTASSIUM_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), POTASSIUM_SUBTYPEID);

        public const string SULFUR_SUBTYPEID = "Sulfur";
        public static readonly UniqueEntityId SULFUR_INGOT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), SULFUR_SUBTYPEID);
        public static readonly UniqueEntityId SULFUR_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), SULFUR_SUBTYPEID);

        public const string STEELGEAR_SUBTYPEID = "SteelGear";
        public static readonly UniqueEntityId STEELGEAR_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), STEELGEAR_SUBTYPEID);

        public const string SILVERCONNECTOR_SUBTYPEID = "SilverConnector";
        public static readonly UniqueEntityId SILVERCONNECTOR_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), SILVERCONNECTOR_SUBTYPEID);

        public const string SUPERCONDUCTOR_SUBTYPEID = "Superconductor";
        public static readonly UniqueEntityId SUPERCONDUCTOR_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), SUPERCONDUCTOR_SUBTYPEID);

        public const string BERYLLIUMCOPPERWIRE_SUBTYPEID = "BerylliumCopperWire";
        public static readonly UniqueEntityId BERYLLIUMCOPPERWIRE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), BERYLLIUMCOPPERWIRE_SUBTYPEID);

        public const string ELITECHIP_SUBTYPEID = "EliteChip";
        public static readonly UniqueEntityId ELITECHIP_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), ELITECHIP_SUBTYPEID);

        public const string PROFICIENTCHIP_SUBTYPEID = "ProficientChip";
        public static readonly UniqueEntityId PROFICIENTCHIP_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), PROFICIENTCHIP_SUBTYPEID);

        public const string ICE_SUBTYPEID = "Ice";
        public static readonly UniqueEntityId ICE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), ICE_SUBTYPEID);

        public const string OXYGEN_SUBTYPEID = "Oxygen";
        public static readonly UniqueEntityId OXYGEN_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasProperties), OXYGEN_SUBTYPEID);

        public const string SPOILED_MATERIAL_SUBTYPEID = "Organic";
        public static readonly UniqueEntityId SPOILED_MATERIAL_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), SPOILED_MATERIAL_SUBTYPEID);

        public const string SILVERSULFADIAZINE_SUBTYPEID = "SilverSulfadiazine";
        public static readonly UniqueEntityId SILVERSULFADIAZINE_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), SILVERSULFADIAZINE_SUBTYPEID);

        public const string WATER_FLASK_SMALL_SUBTYPEID = "Water_Flask_Small";
        public static readonly UniqueEntityId WATER_FLASK_SMALL_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), WATER_FLASK_SMALL_SUBTYPEID);

        public const string WATER_FLASK_MEDIUM_SUBTYPEID = "Water_Flask_Medium";
        public static readonly UniqueEntityId WATER_FLASK_MEDIUM_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), WATER_FLASK_MEDIUM_SUBTYPEID);

        public const string WATER_FLASK_BIG_SUBTYPEID = "Water_Flask_Big";
        public static readonly UniqueEntityId WATER_FLASK_BIG_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), WATER_FLASK_BIG_SUBTYPEID);

        public const string FLASK_SMALL_SUBTYPEID = "Flask_Small";
        public static readonly UniqueEntityId FLASK_SMALL_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), FLASK_SMALL_SUBTYPEID);

        public const string FLASK_MEDIUM_SUBTYPEID = "Flask_Medium";
        public static readonly UniqueEntityId FLASK_MEDIUM_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), FLASK_MEDIUM_SUBTYPEID);

        public const string FLASK_BIG_SUBTYPEID = "Flask_Big";
        public static readonly UniqueEntityId FLASK_BIG_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), FLASK_BIG_SUBTYPEID);

        public const string PRESSUREREGULATOR_SUBTYPEID = "PressureRegulator";
        public static readonly UniqueEntityId PRESSUREREGULATOR_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), PRESSUREREGULATOR_SUBTYPEID);

        public static readonly long BASE_RAW_MEAT_SPOIL_TIME = 5 * 60 * 1000;
        public static readonly long BASE_RAW_VEGETABLE_SPOIL_TIME = (long)(7.5f * 60 * 1000);
        public static readonly long BASE_MEAT_SPOIL_TIME = 10 * 60 * 1000;
        public static readonly long BASE_VEGETABLE_SPOIL_TIME = 15 * 60 * 1000;
        public static readonly long BASE_MEAL_SPOIL_TIME = 20 * 60 * 1000;

        public static readonly Dictionary<UniqueEntityId, ItemExtraInfo> ITEM_EXTRA_INFO_DEF = new Dictionary<UniqueEntityId, ItemExtraInfo>()
        {
            {
                SeedsAndFertilizerConstants.APPLETREESEEDLING_ID,
                new ItemExtraInfo()
                {
                    DefinitionId = SeedsAndFertilizerConstants.APPLETREESEEDLING_ID.DefinitionId,
                    NeedUpdate = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ItemExtraDefinitionAmmountInfo>()
                    {
                        new ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SPOILED_MATERIAL_ID.DefinitionId,
                            Ammount = 2.5f
                        }
                    }
                }
            },
            {
                SeedsAndFertilizerConstants.APPLETREE_ID,
                new ItemExtraInfo()
                {
                    DefinitionId = SeedsAndFertilizerConstants.APPLETREE_ID.DefinitionId,
                    NeedUpdate = true,
                    RemoveWhenSpoil = true,
                    RemoveAmmount = 1,
                    AddNewItemWhenSpoil = true,
                    AddDefinitionId = new List<ItemExtraDefinitionAmmountInfo>()
                    {
                        new ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = SeedsAndFertilizerConstants.TREEDEAD_ID.DefinitionId,
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
