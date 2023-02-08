using System;
using System.Text;

namespace ExtendedSurvival.Stats
{
    public class TreeDefinition : SimpleFactoringDefinition<SimpleIngredientRecipeDefinition>
    {

        private bool HasFarmDescription()
        {
            return FarmConstants.TREE_DEFINITIONS.ContainsKey(Id);
        }

        private string GetFarmDescription()
        {
            var values = new StringBuilder();
            var farmDef = FarmConstants.TREE_DEFINITIONS[Id];
            var fertilizerDef = SeedsAndFertilizerConstants.FERTILIZERS_DEFINITIONS[farmDef.PreferredFertilizer];
            values.AppendLine(string.Format(
                LanguageProvider.GetEntry(LanguageEntries.TREEDEFINITION_DESCRIPTION),
                farmDef.SunRequired ?
                    LanguageProvider.GetEntry(LanguageEntries.TERMS_YES_NAME) :
                    LanguageProvider.GetEntry(LanguageEntries.TERMS_NO_NAME),
                fertilizerDef.Name
            ));
            return values.ToString();
        }

        public override string GetFullDescription()
        {
            return base.GetFullDescription() + (HasFarmDescription() ? Environment.NewLine + GetFarmDescription() : "");
        }

    }

}