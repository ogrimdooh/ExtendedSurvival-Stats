﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRageMath;

namespace ExtendedSurvival.Stats
{
    public class MedicalDefinition : SimpleFactoringDefinition<SimpleRecipeDefinition>
    {

        public List<StatsConstants.DamageEffects> CureDamage { get; set; }
        public List<StatsConstants.DiseaseEffects> CureDisease { get; set; }
        public List<ConsumibleEffect> Effects { get; set; }
        
        public override string GetFullDescription()
        {
            return base.GetFullDescription() + Environment.NewLine + Environment.NewLine + GetApplicationDescription();
        }

        private string GetApplicationDescription()
        {
            var values = new StringBuilder();
            if (Effects != null && Effects.Any())
            {
                foreach (var effect in Effects)
                {
                    switch (effect.EffectType)
                    {
                        case FoodEffectType.Instant:
                            values.AppendLine(string.Format(
                                LanguageProvider.GetEntry(LanguageEntries.FOODDEFINITION_EFFECT_INSTANT_DESCRIPTION),
                                effect.EffectTarget.ToString(),
                                effect.Ammount.ToString("#0.00")
                            ));
                            break;
                        case FoodEffectType.OverTime:
                            values.AppendLine(string.Format(
                                LanguageProvider.GetEntry(LanguageEntries.FOODDEFINITION_EFFECT_OVERTIME_DESCRIPTION),
                                effect.EffectTarget.ToString(),
                                effect.Ammount.ToString("#0.00"),
                                effect.TimeToEffect.ToString("#0.0")
                            ));
                            break;
                    }
                }
            }
            if (CureDamage != null && CureDamage.Any())
            {
                values.AppendLine(" ");
                foreach (var damage in CureDamage)
                {
                    values.AppendLine(string.Format(
                        LanguageProvider.GetEntry(LanguageEntries.FOODDEFINITION_CUREDISEASE_DESCRIPTION), 
                        StatsConstants.GetDamageEffectDescription(damage)
                    ));
                }
            }
            if (CureDisease != null && CureDisease.Any())
            {
                values.AppendLine(" ");
                foreach (var disease in CureDisease)
                {
                    values.AppendLine(string.Format(
                        LanguageProvider.GetEntry(LanguageEntries.FOODDEFINITION_CUREDISEASE_DESCRIPTION), 
                        StatsConstants.GetDiseaseEffectDescription(disease)
                    ));
                }
            }
            return values.ToString();
        }

    }

}