using Sandbox.Common.ObjectBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRage.Game.Components;
using VRage.Game.ModAPI;

namespace ExtendedSurvival.Stats
{

    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_Assembler), false, 
        "BasicSlaughterhouse", 
        "Slaughterhouse", 
        "SlaughterhouseIndustrial"
    )]
    public class SlaughterhouseBlock : BaseAssemblerBlock 
    {

        public static string BASIC_BLOCK_NAME
        {
            get
            {
                return LanguageProvider.GetEntry(LanguageEntries.CUBEBLOCK_SLAUGHTERHOUSE_BASIC);
            }
        }

        public static string BLOCK_NAME
        {
            get
            {
                return LanguageProvider.GetEntry(LanguageEntries.CUBEBLOCK_SLAUGHTERHOUSE);
            }
        }

        public static string INDUSTRIAL_BLOCK_NAME
        {
            get
            {
                return LanguageProvider.GetEntry(LanguageEntries.CUBEBLOCK_SLAUGHTERHOUSE_INDUSTRIAL);
            }
        }

        public static string GetFullDescription()
        {
            return LanguageProvider.GetEntry(LanguageEntries.CUBEBLOCK_SLAUGHTERHOUSE_DESCRIPTION);
        }

        public static readonly string[] REFRIGERATOS_IDS = new string[] { "SmallBlockRefrigerator", "LargeBlockRefrigerator", "LargeBlockLargeRefrigerator" };

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