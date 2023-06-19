using System;
using System.Collections.Generic;
using System.Linq;
using VRage.Game;
using VRage.Utils;

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

        [Flags]
        public enum ArmorCategory
        {

            None = 0,
            Work = 1 << 1,
            Combat = 1 << 2

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
            Tool = 1 << 8,
            Environment = 1 << 9,
            Other = 1 << 10

        }

        public enum ArmorEffect
        {

            Gathering = 0,
            CargoLoad = 1,
            MovementSpeed = 2,
            CreatureDamage = 3,
            TorporBonus = 4

        }

        public enum ModuleAttribute
        {

            Efficiency = 0,
            Capacity = 1,
            RechargeSpeed = 2,
            EnergyConsumption = 3,
            CapacityBonus = 4,
            RechargeSpeedBonus = 5,
            EnergyConsumptionBonus = 6,
            SpikeDamage = 7

        }

        public static readonly Dictionary<DamageType, MyStringHash[]> DAMAGE_TYPES_EQUIVALENCE = new Dictionary<DamageType, MyStringHash[]>()
        {
            { DamageType.Creature, new MyStringHash[] { MyDamageType.Wolf, MyDamageType.Spider } },
            { DamageType.Bullet, new MyStringHash[] { MyDamageType.Bolt, MyDamageType.Bullet, MyDamageType.Rocket, MyDamageType.Weapon } },
            { DamageType.Explosion, new MyStringHash[] { MyDamageType.Explosion, MyDamageType.Mine, MyDamageType.Rocket } },
            { DamageType.Radioactivity, new MyStringHash[] { MyDamageType.Radioactivity } },
            { DamageType.Fire, new MyStringHash[] { MyDamageType.Fire } },
            { DamageType.Toxicity, new MyStringHash[] { MyDamageType.Debug } },
            { DamageType.Fall, new MyStringHash[] { MyDamageType.Environment, MyDamageType.Deformation, MyDamageType.Fall, MyDamageType.Squeez, MyDamageType.Destruction } },
            { DamageType.Tool, new MyStringHash[] { MyDamageType.Weld, MyDamageType.Grind, MyDamageType.Drill } },
            { DamageType.Environment, new MyStringHash[] { MyDamageType.Temperature } },
            { DamageType.Other, new MyStringHash[] { MyDamageType.Suicide, MyDamageType.Asphyxia, MyDamageType.LowPressure } }
        };

        public static DamageType GetDamageType(MyStringHash source)
        {
            var query = DAMAGE_TYPES_EQUIVALENCE.Where(x => x.Value.Contains(source));
            if (query.Any())
                return query.FirstOrDefault().Key;
            return DamageType.None;
        }

        public static string FormatArmorEffectValue(ArmorEffect type, float value)
        {
            switch (type)
            {
                case ArmorEffect.Gathering:
                case ArmorEffect.CargoLoad:
                case ArmorEffect.MovementSpeed:
                case ArmorEffect.CreatureDamage:
                case ArmorEffect.TorporBonus:
                    return value.ToString("P2");
            }
            return value.ToString("#0.00");
        }

        public static string FormatModuleAttributeValue(ModuleAttribute type, float value)
        {
            switch (type)
            {
                case ModuleAttribute.Efficiency:
                case ModuleAttribute.RechargeSpeedBonus:
                case ModuleAttribute.EnergyConsumptionBonus:
                case ModuleAttribute.CapacityBonus:
                case ModuleAttribute.SpikeDamage:
                    return value.ToString("P2");
                case ModuleAttribute.RechargeSpeed:
                    return value.ToString("#0.00") + " P\\S";
                case ModuleAttribute.EnergyConsumption:
                    return value.ToString("#0.00") + " W\\S";
            }
            return value.ToString("#0.00");
        }

        public static string GetModuleAttributeName(ModuleAttribute type)
        {
            switch (type)
            {
                case ModuleAttribute.Efficiency:
                    return LanguageProvider.GetEntry(LanguageEntries.MODULEATTRIBUTE_EFFICIENCY_NAME);
                case ModuleAttribute.RechargeSpeed:
                    return LanguageProvider.GetEntry(LanguageEntries.MODULEATTRIBUTE_RECHARGESPEED_NAME);
                case ModuleAttribute.EnergyConsumption:
                    return LanguageProvider.GetEntry(LanguageEntries.MODULEATTRIBUTE_ENERGYCONSUMPTION_NAME);
                case ModuleAttribute.Capacity:
                    return LanguageProvider.GetEntry(LanguageEntries.MODULEATTRIBUTE_CAPACITY_NAME);
                case ModuleAttribute.RechargeSpeedBonus:
                    return LanguageProvider.GetEntry(LanguageEntries.MODULEATTRIBUTE_RECHARGESPEEDBONUS_NAME);
                case ModuleAttribute.EnergyConsumptionBonus:
                    return LanguageProvider.GetEntry(LanguageEntries.MODULEATTRIBUTE_ENERGYCONSUMPTIONBONUS_NAME);
                case ModuleAttribute.CapacityBonus:
                    return LanguageProvider.GetEntry(LanguageEntries.MODULEATTRIBUTE_CAPACITYBONUS_NAME);
                case ModuleAttribute.SpikeDamage:
                    return LanguageProvider.GetEntry(LanguageEntries.MODULEATTRIBUTE_SPIKEDAMAGE_NAME);
            }
            return "";
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
                case ArmorEffect.CreatureDamage:
                    return LanguageProvider.GetEntry(LanguageEntries.ARMOREFFECT_CREATUREDAMAGE_NAME);
                case ArmorEffect.TorporBonus:
                    return LanguageProvider.GetEntry(LanguageEntries.ARMOREFFECT_TORPORBONUS_NAME);
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
                case DamageType.Environment:
                    return LanguageProvider.GetEntry(LanguageEntries.DAMAGETYPE_ENVIRONMENT_NAME);
                case DamageType.Other:
                    return LanguageProvider.GetEntry(LanguageEntries.DAMAGETYPE_OTHER_NAME);
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
