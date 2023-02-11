using System;
using System.Linq;
using System.Text;

namespace ExtendedSurvival.Stats
{

    public class FishBaitDefinition : SimpleDefinition
    {

        private string GetFishingDescription()
        {
            var values = new StringBuilder();
            if (FishTrapBlock.BAIT_RESULT.ContainsKey(Id))
            {
                var trapInfo = FishTrapBlock.BAIT_RESULT[Id];
                values.AppendLine(" ");
                values.AppendLine(string.Format(
                    LanguageProvider.GetEntry(LanguageEntries.FISHBAITDEFINITION_DESCRIPTION), 
                    trapInfo.ConsumeFactor.X.ToString("#0.00"), 
                    trapInfo.ConsumeFactor.Y.ToString("#0.00"),
                    trapInfo.MaxGenerates
                ));
                foreach (var result in trapInfo.Results)
                {
                    if (FishingConstants.FISHS_DEFINITIONS.ContainsKey(result.Product))
                    {
                        var fishDef = FishingConstants.FISHS_DEFINITIONS[result.Product];
                        values.AppendLine(string.Format(
                            LanguageProvider.GetEntry(LanguageEntries.FISHBAITDEFINITION_FISH_DESCRIPTION), 
                            fishDef.Name, 
                            result.ChanceToGenerate.ToString("#0.00"),
                            result.MinDepth.ToString("#0.0")
                        ));
                    }
                }
            }
            if (ComposterBlock.DECOMPOSITION_RESULT.Any(x => x.Product == Id))
            {
                var compInfo = ComposterBlock.DECOMPOSITION_RESULT.FirstOrDefault(x => x.Product == Id);
                values.AppendLine(" ");
                values.AppendLine(string.Format(
                    LanguageProvider.GetEntry(LanguageEntries.FISHBAITDEFINITION_DECOMPOSITION_DESCRIPTION), 
                    compInfo.ChanceToGenerate.ToString("#0.00"), 
                    compInfo.BaseFactor.X.ToString("#0.0"), 
                    compInfo.BaseFactor.Y.ToString("#0.0"),
                    ComposterBlock.CICLE_CONSUMEFACTOR.X.ToString("#0.0"),
                    ComposterBlock.CICLE_CONSUMEFACTOR.Y.ToString("#0.0")
                ));
            }
            return values.ToString();
        }

        public override string GetFullDescription()
        {
            return base.GetFullDescription() + Environment.NewLine + GetFishingDescription();
        }

    }

}