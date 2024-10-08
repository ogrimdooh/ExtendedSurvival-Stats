﻿namespace ExtendedSurvival.Stats
{

    public class ArmorDefinition : BaseArmorPieceDefinition<ArmorSystemConstants.ArmorType, ArmorSystemConstants.ArmorCategory>
    {
        
        protected override string GetCategoryName()
        {
            return ArmorSystemConstants.GetArmorCategoryName(Category);
        }

        protected override string GetTypeName()
        {
            return ArmorSystemConstants.GetArmorTypeDescription(Type);
        }

    }

}
