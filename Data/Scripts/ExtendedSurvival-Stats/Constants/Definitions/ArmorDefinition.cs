using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtendedSurvival.Stats
{
    public class ArmorDefinition : EquipmentDefinition
    {
    
        public ArmorSystemConstants.ArmorType Type { get; set; }
        public ArmorSystemConstants.ArmorCategory Category { get; set; }
        public int ModuleSlots { get; set; }
        public float StaminaCost { get; set; }
        public float HotResistence { get; set; }
        public float ColdResistence { get; set; }
        public float ToxicityResistence { get; set; }
        public float RadioactivityResistence { get; set; }
        public Dictionary<ArmorSystemConstants.DamageType, float> Resistences { get; set; }
        public Dictionary<ArmorSystemConstants.ArmorEffect, float> Effects { get; set; }

        private string GetArmorTypeDescription()
        {
            var s = ArmorSystemConstants.GetArmorTypeDescription(Type);
            if (s.Length > 0)
                return Environment.NewLine + s;
            return "";
        }

        private string GetEffectsDescription()
        {
            var values = new StringBuilder();
            values.AppendLine(string.Format(
                LanguageProvider.GetEntry(LanguageEntries.ARMORDESC_CATEGORY_ENTRY),
                ArmorSystemConstants.GetArmorCategoryName(Category)
            ));
            values.AppendLine(string.Format(
                LanguageProvider.GetEntry(LanguageEntries.ARMORDESC_MODULES_ENTRY),
                ModuleSlots
            ));
            values.AppendLine(string.Format(
                LanguageProvider.GetEntry(LanguageEntries.ARMORDESC_STAMINA_ENTRY),
                (StaminaCost > 0 ? "+" : "") + StaminaCost.ToString("P2")
            ));
            if (HotResistence != 0)
            {
                values.AppendLine(string.Format(
                    LanguageProvider.GetEntry(LanguageEntries.ARMORDESC_RESISTENCE_ENTRY),
                    (HotResistence > 0 ? "+" : "") + HotResistence.ToString("#0.00") + " ºC",
                    StatsConstants.GetTemperatureEffectDescription(StatsConstants.TemperatureEffects.ExposedToHot)
                ));
            }
            if (ColdResistence != 0)
            {
                values.AppendLine(string.Format(
                    LanguageProvider.GetEntry(LanguageEntries.ARMORDESC_RESISTENCE_ENTRY),
                    (ColdResistence > 0 ? "+" : "") + ColdResistence.ToString("#0.00") + " ºC",
                    StatsConstants.GetTemperatureEffectDescription(StatsConstants.TemperatureEffects.ExposedToCold)
                ));
            }
            if (Resistences != null && Resistences.Any())
            {
                foreach (var key in Resistences.Keys)
                {
                    values.AppendLine(string.Format(
                        LanguageProvider.GetEntry(LanguageEntries.ARMORDESC_RESISTENCE_ENTRY),
                        (Resistences[key] > 0 ? "+" : "") + Resistences[key].ToString("P2"),
                        ArmorSystemConstants.GetDamageTypeName(key)
                    ));
                }
            }
            if (Effects != null && Effects.Any())
            {
                foreach (var key in Effects.Keys)
                {
                    values.AppendLine(string.Format(
                        LanguageProvider.GetEntry(LanguageEntries.ARMORDESC_EFFECT_ENTRY),
                        (Effects[key] > 0 ? "+" : "") + ArmorSystemConstants.FormatArmorEffectValue(key, Effects[key]),
                        ArmorSystemConstants.GetArmorEffectName(key)
                    ));
                }
            }
            return values.ToString();
        }

        public override string GetFullDescription()
        {
            return base.GetFullDescription() + GetArmorTypeDescription() + 
                Environment.NewLine + GetEffectsDescription() + Environment.NewLine +
                LanguageProvider.GetEntry(LanguageEntries.ARMOR_DESCRIPTION);
        }

    }

}
