using System.Linq;

namespace ExtendedSurvival.Stats
{

    public class ArmorModuleDefinition : BaseArmorPieceDefinition<ArmorSystemConstants.ArmorCategory>
    {
        
        protected override string GetCategoryName()
        {
            return ArmorSystemConstants.GetArmorCategoryName(UseCategory);
        }

    }

}
