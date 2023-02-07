using VRage;

namespace ExtendedSurvival.Stats
{

    public class EnglishLanguageTemplate : BaseLanguageTemplate
    {

        public EnglishLanguageTemplate() 
            : base(MyLanguagesEnum.English)
        {
        }

        protected override void DoLoadEntries()
        {
            AddEntry(
                LanguageEntries.CUBEBLOCK_SMALL_CAGE,
                "Small Cage"
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_LARGE_CAGE,
                "Large Cage"
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_CAGE_DESCRIPTION,
                "Cage are blocks used to store and keep captured animals alive. " +
                "When you feed the animals they will eat to stay alive, and in some " +
                "cases produce products."
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_COMPOSTER,
                "Composter"
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_COMPOSTER_DESCRIPTION,
                "Composters are blocks that can speed up up to {0}x the " +
                "rotting of itens. If it had organic material in the inventory, " +
                "will spawn fish baits in time cicle, this cicles can ranges from " +
                "{1}s to {2}s based in amount of organic material." +
                "The energy cost varies based in inventory volume, " +
                "from {3}kW/h up to {4}kW/h."
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_FARM,
                "Farm"
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_FARM_DESCRIPTION,
                "Farms are blocks that generate vegetables, mushrooms and herbs " +
                "when seeds, ice and fertilizers are placed in the inventory. " +
                "Resource cost increases by {0}% for extra seed type and rotting " +
                "time decreases by {0}% when producing."
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_TREEFARM,
                "Tree Farm"
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_TREEFARM_DESCRIPTION,
                "Tree farms are blocks that can grow and keep trees alive to produce " +
                "fruit when you have ice and fertilizer in your inventory. " +
                "Rotting time decreases by {0}% when producing."
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_FISHTRAP,
                "Tree Farm"
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_FISHTRAP_DESCRIPTION,
                "Fish traps are blocks that can capture fish by consuming baits, they need " +
                "to be submerged and connected to submerged collectors to work. " +
                "The fishing cycles are {0}s and cost of energy can vary from {1}kW/h up to {2}kW/h."
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_FOODPROCESSOR,
                "Food Processor"
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_FOODPROCESSOR_BASIC,
                "Basic Food Processor"
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_FOODPROCESSOR_INDUSTRIAL,
                "Industrial Food Processor"
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_FOODPROCESSOR_DESCRIPTION,
                "Food processors are blocks that can prepare and cook food. " +
                "At the end of production, if you have a refrigerator connected, " +
                "it will store food automatically."
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_SLAUGHTERHOUSE,
                "Slaughterhouse"
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_SLAUGHTERHOUSE_BASIC,
                "Basic Slaughterhouse"
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_SLAUGHTERHOUSE_INDUSTRIAL,
                "Industrial Slaughterhouse"
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_SLAUGHTERHOUSE_DESCRIPTION,
                "Slaughterhouses are blocks that can slaughter farmed " +
                "animals and extract their meat. At the end of production, " +
                "if you have a refrigerator connected, it will store food " +
                "automatically."
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_SMALL_REFRIGERATOR,
                "Small Refrigerator"
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_LARGE_REFRIGERATOR,
                "Large Refrigerator"
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_REFRIGERATOR_DESCRIPTION,
                "Refrigerator are blocks that can keep items from rotting. " +
                "The energy cost varies based in inventory volume, " +
                "from {0}kW/h up to {1}kW/h."
            );
        }

    }

}
