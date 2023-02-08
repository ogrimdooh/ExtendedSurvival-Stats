using System;
using System.Text;

namespace ExtendedSurvival.Stats
{

    public class SeedDefinition : SimpleDefinition
    {

        private string GetFarmDescription()
        {
            var values = new StringBuilder();
            var farmDef = FarmConstants.DEFINITIONS[Id];
            var fertilizerDef = SeedsAndFertilizerConstants.FERTILIZERS_DEFINITIONS[farmDef.PreferredFertilizer];
            values.AppendLine(string.Format(
                LanguageProvider.GetEntry(LanguageEntries.SEEDDEFINITION_DESCRIPTION), 
                farmDef.SunRequired ? 
                    LanguageProvider.GetEntry(LanguageEntries.TERMS_YES_NAME) : 
                    LanguageProvider.GetEntry(LanguageEntries.TERMS_NO_NAME), 
                fertilizerDef.Name
            ));
            return values.ToString();
        }

        public override string GetFullDescription()
        {
            return base.GetFullDescription() + Environment.NewLine + GetFarmDescription();
        }

    }

}