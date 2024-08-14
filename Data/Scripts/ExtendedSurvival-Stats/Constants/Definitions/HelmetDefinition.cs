namespace ExtendedSurvival.Stats
{
    public class HelmetDefinition : BaseArmorPieceDefinition<ArmorSystemConstants.ArmorType, ArmorSystemConstants.HelmetCategory>
    {

        protected override string GetCategoryName()
        {
            return ArmorSystemConstants.GetHelmetCategoryName(Category);
        }

        protected override string GetTypeName()
        {
            return ArmorSystemConstants.GetArmorTypeDescription(Type);
        }

    }

}
