using Sandbox.Common.ObjectBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRage.Game.Components;
using VRage.Game.ModAPI;

namespace ExtendedSurvival.Stats
{

    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_Assembler), false, "BasicSlaughterhouse", "Slaughterhouse", "SlaughterhouseIndustrial")]
    public class SlaughterhouseBlock : BaseAssemblerBlock 
    {

        public const string BASIC_BLOCK_NAME = "Basic Slaughterhouse";
        public const string BLOCK_NAME = "Slaughterhouse";
        public const string INDUSTRIAL_BLOCK_NAME = "Industrial Slaughterhouse";

        public static string GetFullDescription()
        {
            var values = new StringBuilder();
            values.AppendLine(string.Format(
                "Slaughterhouses are blocks that can slaughter farmed animals and extract their meat. " +
                "At the end of production, if you have a refrigerator connected, it will store food automatically."
            ));
            return values.ToString();
        }

        public static readonly string[] REFRIGERATOS_IDS = new string[] { "SmallBlockRefrigerator", "LargeBlockRefrigerator" };

        private void CheckOutputInventory()
        {
            try
            {
                for (int i = 0; i < OutputInventory.GetItemsCount(); i++)
                {
                    var item = OutputInventory.GetItemByIndex(i);
                    if (item.HasValue)
                    {
                        var targetId = new UniqueEntityId(item.Value.Content.TypeId, item.Value.Content.SubtypeId);
                        if (FoodConstants.FOOD_DEFINITIONS.ContainsKey(targetId))
                        {
                            if (FoodConstants.FOOD_DEFINITIONS[targetId].NeedConservation)
                            {
                                var targetToMove = refrigerators.FirstOrDefault(x => x.FatBlock != null && (OutputInventory as IMyInventory).CanTransferItemTo(x.FatBlock.GetInventory(), targetId.DefinitionId));
                                if (targetToMove != null)
                                {
                                    var amountOnOutput = OutputInventory.GetItemAmount(targetId.DefinitionId);
                                    var amountAdded = targetToMove.FatBlock.GetInventory().AddMaxItems(amountOnOutput, ItensConstants.GetPhysicalObjectBuilder(targetId));
                                    OutputInventory.RemoveItemsOfType(amountAdded, targetId.DefinitionId);
                                }
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(GetType(), ex);
            }
        }

        protected List<IMySlimBlock> refrigerators = new List<IMySlimBlock>();
        protected virtual void RefreshRefrigerators()
        {
            try
            {
                refrigerators.Clear();
                Grid.GetBlocks(refrigerators, x => REFRIGERATOS_IDS.Contains(x.BlockDefinition.Id.SubtypeName));
            }
            catch (System.Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(GetType(), ex);
            }
        }

        protected override void CurrentEntity_StoppedProducing()
        {
            RefreshRefrigerators();
            base.CurrentEntity_StoppedProducing();
            CheckOutputInventory();
        }

    }

}