using System;

namespace ExtendedSurvival.Stats
{
    public static class ArmorSystemConstants
    {
        
        public enum ArmorType
        {

            Normal = 0,
            Light = 1,
            Heavy = 2,
            Expanded = 3

        }

        public enum ArmorCategory
        {

            Work = 0,
            Combat = 1

        }

        [Flags]
        public enum DamageType
        {

            None = 0,
            Creature = 1 << 1,
            Bullet = 1 << 2,
            Explosion = 1 << 3,
            Radioactivity = 1 << 4,
            Fire = 1 << 5,
            Toxicity = 1 << 6,
            Fall = 1 << 7,
            Tool = 1 << 8

        }

        public enum ArmorEffect
        {

            Gathering = 0,
            CargoLoad = 1,
            MovementSpeed = 2

        }

        public static string FormatArmorEffectValue(ArmorEffect type, float value)
        {
            switch (type)
            {
                case ArmorEffect.Gathering:
                case ArmorEffect.CargoLoad:
                case ArmorEffect.MovementSpeed:
                    return value.ToString("P2");
            }
            return value.ToString("#0.00");
        }

        public static string GetArmorEffectName(ArmorEffect type)
        {
            switch (type)
            {
                case ArmorEffect.Gathering:
                    return LanguageProvider.GetEntry(LanguageEntries.ARMOREFFECT_GATHERING_NAME);
                case ArmorEffect.CargoLoad:
                    return LanguageProvider.GetEntry(LanguageEntries.ARMOREFFECT_CARGOLOAD_NAME);
                case ArmorEffect.MovementSpeed:
                    return LanguageProvider.GetEntry(LanguageEntries.ARMOREFFECT_MOVEMENTSPEED_NAME);
            }
            return "";
        }

        public static string GetDamageTypeName(DamageType type)
        {
            switch (type)
            {
                case DamageType.Creature:
                    return LanguageProvider.GetEntry(LanguageEntries.DAMAGETYPE_CREATURE_NAME);
                case DamageType.Bullet:
                    return LanguageProvider.GetEntry(LanguageEntries.DAMAGETYPE_BULLET_NAME);
                case DamageType.Explosion:
                    return LanguageProvider.GetEntry(LanguageEntries.DAMAGETYPE_EXPLOSION_NAME);
                case DamageType.Radioactivity:
                    return LanguageProvider.GetEntry(LanguageEntries.DAMAGETYPE_RADIOACTIVITY_NAME);
                case DamageType.Fire:
                    return LanguageProvider.GetEntry(LanguageEntries.DAMAGETYPE_FIRE_NAME);
                case DamageType.Toxicity:
                    return LanguageProvider.GetEntry(LanguageEntries.DAMAGETYPE_TOXICITY_NAME);
                case DamageType.Fall:
                    return LanguageProvider.GetEntry(LanguageEntries.DAMAGETYPE_FALL_NAME);
                case DamageType.Tool:
                    return LanguageProvider.GetEntry(LanguageEntries.DAMAGETYPE_TOOL_NAME);
            }
            return "";
        }

        public static string GetArmorTypeDescription(ArmorType type)
        {
            switch (type)
            {
                case ArmorType.Light:
                    return LanguageProvider.GetEntry(LanguageEntries.ARMORLIGHT_DESCRIPTION);
                case ArmorType.Heavy:
                    return LanguageProvider.GetEntry(LanguageEntries.ARMORHEAVY_DESCRIPTION);
                case ArmorType.Expanded:
                    return LanguageProvider.GetEntry(LanguageEntries.ARMOREXPANDED_DESCRIPTION);
            }
            return "";
        }

        public static string GetArmorCategoryName(ArmorCategory type)
        {
            switch (type)
            {
                case ArmorCategory.Work:
                    return LanguageProvider.GetEntry(LanguageEntries.ARMORCATEGORY_WORK_NAME);
                case ArmorCategory.Combat:
                    return LanguageProvider.GetEntry(LanguageEntries.ARMORCATEGORY_COMBAT_NAME);
            }
            return "";
        }

    }

}
