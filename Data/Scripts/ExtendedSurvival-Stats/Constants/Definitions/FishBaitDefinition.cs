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
                values.AppendLine("Can be used in traps to catch fish.");
                values.AppendLine(string.Format("Will consume from {0} to {1} per cycle.", trapInfo.ConsumeFactor.X.ToString("#0.00"), trapInfo.ConsumeFactor.Y.ToString("#0.00")));
                values.AppendLine(string.Format("Can capture up to {0} fish per cicle.", trapInfo.MaxGenerates));
                values.AppendLine("Valid targets:");
                foreach (var result in trapInfo.Results)
                {
                    if (FishingConstants.FISHS_DEFINITIONS.ContainsKey(result.Product))
                    {
                        var fishDef = FishingConstants.FISHS_DEFINITIONS[result.Product];
                        values.AppendLine(string.Format("- {1}% to get {0} at minimum depth of {2}m", fishDef.Name, result.ChanceToGenerate.ToString("#0.00"), result.MinDepth.ToString("#0.0")));
                    }
                }
            }
            if (ComposterBlock.DECOMPOSITION_RESULT.Any(x => x.Product == Id))
            {
                var compInfo = ComposterBlock.DECOMPOSITION_RESULT.FirstOrDefault(x => x.Product == Id);
                values.AppendLine(" ");
                values.AppendLine("It can be generated in composters.");
                values.AppendLine(string.Format("{0}% chance to spawn {1} to {2} per cycle.", compInfo.ChanceToGenerate.ToString("#0.00"), compInfo.BaseFactor.X.ToString("#0.00"), compInfo.BaseFactor.Y.ToString("#0.0")));
            }
            return values.ToString();
        }

        public override string GetFullDescription()
        {
            return base.GetFullDescription() + Environment.NewLine + GetFishingDescription();
        }

    }

}