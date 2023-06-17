using Sandbox.Common.ObjectBuilders;
using Sandbox.Definitions;
using System.Collections.Generic;
using VRage.Game;

namespace ExtendedSurvival.Stats
{
    public sealed class DescriptionBlocksOverride : BaseModIntegrationOverride
    {

        public static void TryOverride()
        {
            new DescriptionBlocksOverride().SetDefinitions();
        }

        public struct BlockDescriptionInfo
        {

            public string Name;
            public string Description;

        }

        public static readonly UniqueEntityId COMPOSTER_BLOCK = new UniqueEntityId(typeof(MyObjectBuilder_OxygenGenerator), "LargeBlockComposter");
        public static readonly UniqueEntityId FISHTRAP_BLOCK = new UniqueEntityId(typeof(MyObjectBuilder_OxygenGenerator), "FishTrap");
        public static readonly UniqueEntityId SMALL_REFRIGERATOR_BLOCK = new UniqueEntityId(typeof(MyObjectBuilder_OxygenGenerator), "SmallBlockRefrigerator");
        public static readonly UniqueEntityId LARGE_REFRIGERATOR_BLOCK = new UniqueEntityId(typeof(MyObjectBuilder_OxygenGenerator), "LargeBlockRefrigerator");
        public static readonly UniqueEntityId FARM_BLOCK = new UniqueEntityId(typeof(MyObjectBuilder_OxygenFarm), "LargeBlockFarm");
        public static readonly UniqueEntityId TREE_FARM_BLOCK = new UniqueEntityId(typeof(MyObjectBuilder_OxygenFarm), "LargeBlockTreeFarm");
        public static readonly UniqueEntityId BASIC_FOOD_PROCESSOR_BLOCK = new UniqueEntityId(typeof(MyObjectBuilder_Assembler), "BasicFoodProcessor");
        public static readonly UniqueEntityId FOOD_PROCESSOR_BLOCK = new UniqueEntityId(typeof(MyObjectBuilder_Assembler), "FoodProcessor");
        public static readonly UniqueEntityId INDUSTRIAL_FOOD_PROCESSOR_BLOCK = new UniqueEntityId(typeof(MyObjectBuilder_Assembler), "FoodProcessorIndustrial");
        public static readonly UniqueEntityId BASIC_SLAUGHTERHOUSE_BLOCK = new UniqueEntityId(typeof(MyObjectBuilder_Assembler), "BasicSlaughterhouse");
        public static readonly UniqueEntityId SLAUGHTERHOUSE_BLOCK = new UniqueEntityId(typeof(MyObjectBuilder_Assembler), "Slaughterhouse");
        public static readonly UniqueEntityId INDUSTRIAL_SLAUGHTERHOUSE_BLOCK = new UniqueEntityId(typeof(MyObjectBuilder_Assembler), "SlaughterhouseIndustrial");
        public static readonly UniqueEntityId SB_SMALL_CAGE_BLOCK = new UniqueEntityId(typeof(MyObjectBuilder_CargoContainer), "SmallBlockSmallCage");
        public static readonly UniqueEntityId LB_SMALL_CAGE_BLOCK = new UniqueEntityId(typeof(MyObjectBuilder_CargoContainer), "LargeBlockSmallCage");
        public static readonly UniqueEntityId LB_LARGE_CAGE_BLOCK = new UniqueEntityId(typeof(MyObjectBuilder_CargoContainer), "LargeBlockLargeCage");
        public static readonly UniqueEntityId SMALL_THERMALGENERATOR_BLOCK = new UniqueEntityId(typeof(MyObjectBuilder_OxygenGenerator), "ThermalFluidGenerator");
        public static readonly UniqueEntityId LARGE_THERMALGENERATOR_BLOCK = new UniqueEntityId(typeof(MyObjectBuilder_OxygenGenerator), "ThermalFluidGeneratorSmall");

        public static readonly Dictionary<UniqueEntityId, BlockDescriptionInfo> BLOCKS_DESCRIPTIONS = new Dictionary<UniqueEntityId, BlockDescriptionInfo>()
        {
            { 
                COMPOSTER_BLOCK, 
                new BlockDescriptionInfo() 
                { 
                    Name = ComposterBlock.BLOCK_NAME, 
                    Description = ComposterBlock.GetFullDescription() 
                }
            },
            {
                FISHTRAP_BLOCK,
                new BlockDescriptionInfo()
                {
                    Name = FishTrapBlock.BLOCK_NAME,
                    Description = FishTrapBlock.GetFullDescription()
                }
            },
            {
                SMALL_REFRIGERATOR_BLOCK,
                new BlockDescriptionInfo()
                {
                    Name = RefrigeratorBlock.SMALL_BLOCK_NAME,
                    Description = RefrigeratorBlock.GetFullDescription(true)
                }
            },
            {
                LARGE_REFRIGERATOR_BLOCK,
                new BlockDescriptionInfo()
                {
                    Name = RefrigeratorBlock.LARGE_BLOCK_NAME,
                    Description = RefrigeratorBlock.GetFullDescription(false)
                }
            },
            {
                FARM_BLOCK,
                new BlockDescriptionInfo()
                {
                    Name = FarmBlock.BLOCK_NAME,
                    Description = FarmBlock.GetFullDescription()
                }
            },
            {
                TREE_FARM_BLOCK,
                new BlockDescriptionInfo()
                {
                    Name = TreeFarmBlock.BLOCK_NAME,
                    Description = TreeFarmBlock.GetFullDescription()
                }
            },
            {
                BASIC_FOOD_PROCESSOR_BLOCK,
                new BlockDescriptionInfo()
                {
                    Name = FoodProcessorBlock.BASIC_BLOCK_NAME,
                    Description = FoodProcessorBlock.GetFullDescription()
                }
            },
            {
                FOOD_PROCESSOR_BLOCK,
                new BlockDescriptionInfo()
                {
                    Name = FoodProcessorBlock.BLOCK_NAME,
                    Description = FoodProcessorBlock.GetFullDescription()
                }
            },
            {
                INDUSTRIAL_FOOD_PROCESSOR_BLOCK,
                new BlockDescriptionInfo()
                {
                    Name = FoodProcessorBlock.INDUSTRIAL_BLOCK_NAME,
                    Description = FoodProcessorBlock.GetFullDescription()
                }
            },
            {
                BASIC_SLAUGHTERHOUSE_BLOCK,
                new BlockDescriptionInfo()
                {
                    Name = SlaughterhouseBlock.BASIC_BLOCK_NAME,
                    Description = SlaughterhouseBlock.GetFullDescription()
                }
            },
            {
                SLAUGHTERHOUSE_BLOCK,
                new BlockDescriptionInfo()
                {
                    Name = SlaughterhouseBlock.BLOCK_NAME,
                    Description = SlaughterhouseBlock.GetFullDescription()
                }
            },
            {
                INDUSTRIAL_SLAUGHTERHOUSE_BLOCK,
                new BlockDescriptionInfo()
                {
                    Name = SlaughterhouseBlock.INDUSTRIAL_BLOCK_NAME,
                    Description = SlaughterhouseBlock.GetFullDescription()
                }
            },
            {
                SB_SMALL_CAGE_BLOCK,
                new BlockDescriptionInfo()
                {
                    Name = CageBlock.SMALL_BLOCK_NAME,
                    Description = CageBlock.GetFullDescription()
                }
            },
            {
                LB_SMALL_CAGE_BLOCK,
                new BlockDescriptionInfo()
                {
                    Name = CageBlock.BLOCK_NAME,
                    Description = CageBlock.GetFullDescription()
                }
            },
            {
                LB_LARGE_CAGE_BLOCK,
                new BlockDescriptionInfo()
                {
                    Name = CageBlock.LARGE_BLOCK_NAME,
                    Description = CageBlock.GetFullDescription()
                }
            },
            {
                SMALL_THERMALGENERATOR_BLOCK,
                new BlockDescriptionInfo()
                {
                    Name = ThermalFluidGeneratorBlock.BLOCK_NAME,
                    Description = ThermalFluidGeneratorBlock.GetFullDescription()
                }
            },
            {
                LARGE_THERMALGENERATOR_BLOCK,
                new BlockDescriptionInfo()
                {
                    Name = ThermalFluidGeneratorBlock.BLOCK_NAME,
                    Description = ThermalFluidGeneratorBlock.GetFullDescription()
                }
            }
        };

        protected override ulong[] GetModId()
        {
            return new ulong[] { };
        }

        protected override void OnSetDefinitions()
        {
            foreach (var block in GetBlocks())
            {
                var blockDefinition = DefinitionUtils.TryGetDefinition<MyCubeBlockDefinition>(block.DefinitionId);
                if (blockDefinition != null)
                {
                    blockDefinition.DisplayNameEnum = null;
                    blockDefinition.DisplayNameString = BLOCKS_DESCRIPTIONS[block].Name;
                    blockDefinition.DescriptionEnum = null;
                    blockDefinition.DescriptionString = BLOCKS_DESCRIPTIONS[block].Description;
                }
                else
                    ExtendedSurvivalStatsLogging.Instance.LogWarning(GetType(), $"Override block not found. ID=[{block}]");
            }
        }

        private IEnumerable<UniqueEntityId> GetBlocks()
        {
            return BLOCKS_DESCRIPTIONS.Keys;
        }

    }

}