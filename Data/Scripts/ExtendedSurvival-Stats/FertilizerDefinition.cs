using System;
using System.Linq;
using System.Text;

namespace ExtendedSurvival.Stats
{
    public class FertilizerDefinition : SimpleFactoringDefinition<SimpleRecipeDefinition>
    {

        private string GetFarmDescription()
        {
            var values = new StringBuilder();
            if (Id == FarmConstants.POWER_FERTILIZER)
            {
                values.AppendLine(string.Format("Provides a {0}% production multiplier when used.", (FarmConstants.POWER_FERTILIZER_MULTIPLIER * 100).ToString("#0.00")));
                values.AppendLine("It is compatible with all plants."); 
            }
            else
            {
                values.AppendLine(string.Format("Provides a {0}% production multiplier when used with compatible plants.", (FarmConstants.PREFER_FERTILIZER_MULTIPLIER * 100).ToString("#0.00")));
                values.AppendLine("It is compatible with:");
                foreach (var farmDefKey in FarmConstants.DEFINITIONS.Where(x => x.Value.PreferredFertilizer == Id).Select(x => x.Key))
                {
                    if (SeedsAndFertilizerConstants.SEEDS_DEFINITIONS.ContainsKey(farmDefKey))
                    {
                        var seedDef = SeedsAndFertilizerConstants.SEEDS_DEFINITIONS[farmDefKey];
                        values.AppendLine(string.Format("- {0}", seedDef.Name));
                    }
                    else if (FoodConstants.FOOD_DEFINITIONS.ContainsKey(farmDefKey))
                    {
                        var foodDef = FoodConstants.FOOD_DEFINITIONS[farmDefKey];
                        values.AppendLine(string.Format("- {0}", foodDef.Name));
                    }
                }
                foreach (var farmDefKey in FarmConstants.TREE_DEFINITIONS.Where(x => x.Value.PreferredFertilizer == Id).Select(x => x.Key))
                {
                    if (SeedsAndFertilizerConstants.TREES_DEFINITIONS.ContainsKey(farmDefKey))
                    {
                        var seedDef = SeedsAndFertilizerConstants.TREES_DEFINITIONS[farmDefKey];
                        values.AppendLine(string.Format("- {0}", seedDef.Name));
                    }
                }
            }
            return values.ToString();
        }

        public override string GetFullDescription()
        {
            return base.GetFullDescription() + Environment.NewLine + GetFarmDescription();
        }

    }

}