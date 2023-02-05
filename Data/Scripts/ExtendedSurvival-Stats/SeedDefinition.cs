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
            values.AppendLine(string.Format("Need sunlight: {0}", farmDef.SunRequired ? "Yes" : "No"));
            values.AppendLine(string.Format("Favorite Fertilizer: {0}", fertilizerDef.Name));
            return values.ToString();
        }

        public override string GetFullDescription()
        {
            return base.GetFullDescription() + Environment.NewLine + GetFarmDescription();
        }

    }

}