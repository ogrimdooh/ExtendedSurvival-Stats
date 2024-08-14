namespace ExtendedSurvival.Stats
{
    public class HelmetModuleDefinition : BaseArmorPieceDefinition<ArmorSystemConstants.HelmetCategory>
    {

        protected override string GetCategoryName()
        {
            return ArmorSystemConstants.GetHelmetCategoryName(UseCategory);
        }

    }

}
