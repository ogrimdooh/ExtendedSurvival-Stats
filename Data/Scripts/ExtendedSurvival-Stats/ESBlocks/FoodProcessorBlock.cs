using Sandbox.Common.ObjectBuilders;
using Sandbox.Definitions;
using Sandbox.ModAPI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRage.Game.Components;
using VRage.Game.ModAPI;
using VRage.ObjectBuilders;

namespace ExtendedSurvival.Stats
{
    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_Assembler), false, "BasicFoodProcessor", "FoodProcessor", "FoodProcessorIndustrial")]
    public class FoodProcessorBlock : BaseAssemblerBlock
    {

        public static string BASIC_BLOCK_NAME
        {
            get
            {
                return LanguageProvider.GetEntry(LanguageEntries.CUBEBLOCK_FOODPROCESSOR_BASIC);
            }
        }

        public static string BLOCK_NAME
        {
            get
            {
                return LanguageProvider.GetEntry(LanguageEntries.CUBEBLOCK_FOODPROCESSOR);
            }
        }

        public static string INDUSTRIAL_BLOCK_NAME
        {
            get
            {
                return LanguageProvider.GetEntry(LanguageEntries.CUBEBLOCK_FOODPROCESSOR_INDUSTRIAL);
            }
        }

        public static string GetFullDescription()
        {
            return LanguageProvider.GetEntry(LanguageEntries.CUBEBLOCK_FOODPROCESSOR_DESCRIPTION);
        }

        public static readonly string[] REFRIGERATOS_IDS = new string[] { "SmallBlockRefrigerator", "LargeBlockRefrigerator" };
        public static readonly string[] RISHTRAPS_IDS = new string[] { "FishTrap" };
        
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

        protected List<IMySlimBlock> fishtraps = new List<IMySlimBlock>();
        protected virtual void RefreshFishTraps()
        {
            try
            {
                fishtraps.Clear();
                Grid.GetBlocks(fishtraps, x => RISHTRAPS_IDS.Contains(x.BlockDefinition.Id.SubtypeName));
            }
            catch (System.Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(GetType(), ex);
            }
        }

        protected override void CurrentEntity_StoppedProducing()
        {
            RefreshRefrigerators();
            RefreshFishTraps();
            base.CurrentEntity_StoppedProducing();
            CheckOutputInventory();
        }

        private bool DoCheckBlockListForResource(List<IMySlimBlock> blocks, MyProductionQueueItem queue, MyBlueprintDefinitionBase.Item item)
        {
            if (blocks.Count > 0)
            {
                foreach (var block in blocks.Where(x => x.FatBlock != null && x.FatBlock.GetInventory().CanTransferItemTo(InputInventory, item.Id)))
                {
                    var inventory = block.FatBlock.GetInventory();
                    if (inventory != null)
                    {
                        var amountOnOutput = inventory.GetItemAmount(item.Id);
                        if (amountOnOutput > 0)
                        {
                            var requiredAmount = queue.Amount * item.Amount;
                            if (amountOnOutput < requiredAmount)
                            {
                                requiredAmount = amountOnOutput;
                            }
                            var amountAdded = (InputInventory as IMyInventory).AddMaxItems(requiredAmount, ItensConstants.GetPhysicalObjectBuilder(new UniqueEntityId(item.Id)));
                            inventory.RemoveItemsOfType(amountAdded, item.Id);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        protected override void OnCheckQueueNotFoundPrerequisiteInOutputInventory(MyProductionQueueItem queue, MyBlueprintDefinitionBase blueprint, MyBlueprintDefinitionBase.Item item)
        {
            base.OnCheckQueueNotFoundPrerequisiteInOutputInventory(queue, blueprint, item);
            if (!DoCheckBlockListForResource(refrigerators, queue, item))
                DoCheckBlockListForResource(fishtraps, queue, item);            
        }

    }

}
