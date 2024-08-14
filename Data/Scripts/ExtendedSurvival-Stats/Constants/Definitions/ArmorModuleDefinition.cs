using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtendedSurvival.Stats
{

    public abstract class BaseArmorPieceDefinition<T> : EquipmentDefinition
    {

        public T UseCategory { get; set; }
        public Dictionary<ArmorSystemConstants.ModuleAttribute, float> Attributes { get; set; }

        protected abstract string GetCategoryName();

        public string GetOperationalDescription()
        {
            var values = new StringBuilder();
            string[] categoryText = new string[] { GetCategoryName() };
            values.AppendLine(string.Format(
                LanguageProvider.GetEntry(LanguageEntries.ARMORDESC_CATEGORY_ENTRY),
                string.Join(", ", categoryText)
            ));
            if (Attributes != null && Attributes.Count > 0)
            {
                foreach (var key in Attributes.Keys)
                {
                    values.AppendLine(string.Format(
                        LanguageProvider.GetEntry(LanguageEntries.ARMORDESC_EFFECT_ENTRY),
                        (Attributes[key] > 0 ? "+" : "") + ArmorSystemConstants.FormatModuleAttributeValue(key, Attributes[key]),
                        ArmorSystemConstants.GetModuleAttributeName(key)
                    ));
                }
            }
            return values.ToString();
        }

        public float GetAttribute(ArmorSystemConstants.ModuleAttribute attribute)
        {
            if (Attributes.ContainsKey(attribute))
                return Attributes[attribute];
            return 0f;
        }

        public override string GetFullDescription()
        {
            return base.GetFullDescription() +
                Environment.NewLine + GetOperationalDescription() + Environment.NewLine +
                LanguageProvider.GetEntry(LanguageEntries.ARMORMODULE_DESCRIPTION);
        }

    }

    public class HelmetModuleDefinition : BaseArmorPieceDefinition<ArmorSystemConstants.HelmetCategory>
    {

        protected override string GetCategoryName()
        {
            return ArmorSystemConstants.GetHelmetCategoryName(UseCategory);
        }

    }

    public class ArmorModuleDefinition : BaseArmorPieceDefinition<ArmorSystemConstants.ArmorCategory>
    {
        
        protected override string GetCategoryName()
        {
            return ArmorSystemConstants.GetArmorCategoryName(UseCategory);
        }

    }

}
