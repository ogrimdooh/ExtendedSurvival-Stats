using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static ExtendedSurvival.Stats.ArmorSystemConstants;

namespace ExtendedSurvival.Stats
{
    public abstract class BaseArmorPieceDefinition<T, C> : EquipmentDefinition
    {

        public T Type { get; set; }
        public C Category { get; set; }
        public int ModuleSlots { get; set; }
        public float StaminaCost { get; set; }
        public float HotResistence { get; set; }
        public float ColdResistence { get; set; }
        public Dictionary<ArmorSystemConstants.DamageType, float> Resistences { get; set; }
        public Dictionary<ArmorSystemConstants.ArmorEffect, float> Effects { get; set; }

        protected abstract string GetCategoryName();
        protected abstract string GetTypeName();

        public float GetEffect(ArmorSystemConstants.ArmorEffect armorEffect)
        {
            if (Effects.ContainsKey(armorEffect))
                return Effects[armorEffect];
            return 0f;
        }

        public float GetResistence(ArmorSystemConstants.DamageType damageType)
        {
            if (Resistences.ContainsKey(damageType))
                return Resistences[damageType];
            return 0f;
        }

        protected string GetEffectsDescription()
        {
            var values = new StringBuilder();
            values.AppendLine(string.Format(
                LanguageProvider.GetEntry(LanguageEntries.ARMORDESC_CATEGORY_ENTRY),
                GetCategoryName()
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

        private string GetArmorTypeDescription()
        {
            var s = GetTypeName();
            if (s.Length > 0)
                return Environment.NewLine + s;
            return "";
        }

        public override string GetFullDescription()
        {
            return base.GetFullDescription() + GetArmorTypeDescription() +
                Environment.NewLine + GetEffectsDescription() + Environment.NewLine +
                LanguageProvider.GetEntry(LanguageEntries.ARMOR_DESCRIPTION);
        }

    }

}
