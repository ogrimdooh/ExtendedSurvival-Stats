﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtendedSurvival.Stats
{

    public class FishDefinition : SimpleFactoringDefinition<SimpleIngredientRecipeDefinition>
    {

        public long StartConservationTime { get; set; }

        private string GetFishingDescription()
        {
            var values = new StringBuilder();
            if (FishTrapBlock.BAIT_RESULT.Values.Any(x => x.Results.Any(y => y.Product == Id)))
            {
                values.AppendLine(string.Format("Rotting time: {0}s", (StartConservationTime / 1000).ToString("#0.0")));
                values.AppendLine(" ");
                values.AppendLine("Can be captured in traps:");
                var baits = FishTrapBlock.BAIT_RESULT.Where(x => x.Value.Results.Any(y => y.Product == Id));
                foreach (var bait in baits)
                {
                    if (FishingConstants.FISH_BAITS_DEFINITIONS.ContainsKey(bait.Key))
                    {
                        var baitInfo = FishingConstants.FISH_BAITS_DEFINITIONS[bait.Key];
                        var result = bait.Value.Results.FirstOrDefault(y => y.Product == Id);
                        values.AppendLine(string.Format("- {1}% using {0} at minimum depth of {2}m", baitInfo.Name, result.ChanceToGenerate.ToString("#0.00"), result.MinDepth.ToString("#0.0")));
                    }
                }
                values.AppendLine("Note: They can have their meat extracted in food processors.");
            }
            return values.ToString();
        }

        public override string GetFullDescription()
        {
            return base.GetFullDescription() + Environment.NewLine + GetFishingDescription();
        }

        public ExtendedSurvivalCoreAPI.ItemExtraInfo GetItemExtraInfo()
        {
            var extraInfo = new ExtendedSurvivalCoreAPI.ItemExtraInfo()
            {
                DefinitionId = Id.DefinitionId,
                StartConservationTime = StartConservationTime,
                NeedUpdate = true,
                NeedConservation = true,
                RemoveWhenSpoil = true,
                RemoveAmmount = 1,
                AddNewItemWhenSpoil = true
            };
            extraInfo.AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                {
                    new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                    {
                        DefinitionId = ItensConstants.SPOILED_MATERIAL_ID.DefinitionId,
                        Ammount = Mass * 0.75f
                    },
                    new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                    {
                        DefinitionId = ItensConstants.FISH_BONES_ID.DefinitionId,
                        Ammount = Mass * 0.25f
                    }
                };
            return extraInfo;
        }

    }

}