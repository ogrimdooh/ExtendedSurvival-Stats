using Sandbox.Common.ObjectBuilders;
using Sandbox.Definitions;
using System.Collections.Generic;

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

        public static readonly Dictionary<UniqueEntityId, BlockDescriptionInfo> BLOCKS_DESCRIPTIONS = new Dictionary<UniqueEntityId, BlockDescriptionInfo>()
        {
            { 
                COMPOSTER_BLOCK, 
                new BlockDescriptionInfo() 
                { 
                    Name = ComposterBlock.BLOCK_NAME, 
                    Description = ComposterBlock.GetFullDescription() 
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