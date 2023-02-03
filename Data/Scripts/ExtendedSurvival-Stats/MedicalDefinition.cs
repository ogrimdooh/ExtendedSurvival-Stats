using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRageMath;

namespace ExtendedSurvival.Stats
{
    public class MedicalDefinition
    {

        public UniqueEntityId Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Volume { get; set; }
        public float Mass { get; set; }
        public Vector2I AcquisitionAmount { get; set; } = Vector2I.Zero;
        public Vector2I OrderAmount { get; set; } = Vector2I.Zero;
        public Vector2I OfferAmount { get; set; } = Vector2I.Zero;
        public int MinimalPricePerUnit { get; set; }
        public bool CanPlayerOrder { get; set; } = false;
        public List<StatsConstants.DamageEffects> CureDamage { get; set; }
        public List<StatsConstants.DiseaseEffects> CureDisease { get; set; }
        public List<ConsumibleEffect> Effects { get; set; }
        public SimpleRecipeDefinition RecipeDefinition { get; set; }

        public string GetFullDescription()
        {
            return Description + Environment.NewLine + Environment.NewLine + GetApplicationDescription();
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
                            values.AppendLine(string.Format("{1} {0} instantly",
                                effect.EffectTarget.ToString(),
                                effect.Ammount.ToString("#0.00")
                            ));
                            break;
                        case FoodEffectType.OverTime:
                            values.AppendLine(string.Format("{1} {0} over {2}s",
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
                    values.AppendLine(string.Format("Can cure {0} when use", StatsConstants.GetDamageEffectDescription(damage)));
                }
            }
            if (CureDisease != null && CureDisease.Any())
            {
                values.AppendLine(" ");
                foreach (var disease in CureDisease)
                {
                    values.AppendLine(string.Format("Can cure {0} when use", StatsConstants.GetDiseaseEffectDescription(disease)));
                }
            }
            return values.ToString();
        }

    }

}