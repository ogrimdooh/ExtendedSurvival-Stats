using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtendedSurvival.Stats
{
    public class ArmorModuleDefinition : EquipmentDefinition
    {

        public ArmorSystemConstants.ArmorCategory UseCategory { get; set; }
        public Dictionary<ArmorSystemConstants.ModuleAttribute, float> Attributes { get; set; }

        public string GetOperationalDescription()
        {
            var values = new StringBuilder();
            string[] categoryText = new string[] { ArmorSystemConstants.GetArmorCategoryName(UseCategory) };
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

        public override string GetFullDescription()
        {
            return base.GetFullDescription() + 
                Environment.NewLine + GetOperationalDescription() + Environment.NewLine +
                LanguageProvider.GetEntry(LanguageEntries.ARMORMODULE_DESCRIPTION);
        }

    }

}
