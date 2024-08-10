using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRageMath;

namespace ExtendedSurvival.Stats
{
    public class MedicalDefinition : SimpleFactoringDefinition<SimpleRecipeDefinition>
    {

        public Dictionary<StatsConstants.TemperatureEffects, int> TemperatureEffects { get; set; } = new Dictionary<StatsConstants.TemperatureEffects, int>();
        public List<StatsConstants.TemperatureEffects> CureTemperature { get; set; }
        public Dictionary<StatsConstants.TemperatureEffects, float> ReduceTemperature { get; set; }
        public List<StatsConstants.DamageEffects> CureDamage { get; set; }
        public Dictionary<StatsConstants.DamageEffects, float> ReduceDamage { get; set; }
        public List<StatsConstants.DiseaseEffects> CureDisease { get; set; }
        public Dictionary<StatsConstants.DiseaseEffects, float> ReduceDisease { get; set; }
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
            var hadTemperatureEffectsToAdd = TemperatureEffects != null && TemperatureEffects.Any(x => x.Value > 0);
            if (hadTemperatureEffectsToAdd)
            {
                foreach (var temperatureEffects in TemperatureEffects.Keys)
                {
                    if (TemperatureEffects[temperatureEffects] > 0)
                    {
                        values.AppendLine(string.Format(
                            LanguageProvider.GetEntry(LanguageEntries.FOODDEFINITION_DISEASECHANCE_DESCRIPTION),
                            (1).ToString("P1"),
                            StatsConstants.GetTemperatureEffectDescription(temperatureEffects)
                        ));
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
            if (CureTemperature != null && CureTemperature.Any())
            {
                values.AppendLine(" ");
                foreach (var Temperature in CureTemperature)
                {
                    values.AppendLine(string.Format(
                        LanguageProvider.GetEntry(LanguageEntries.FOODDEFINITION_CUREDISEASE_DESCRIPTION),
                        StatsConstants.GetTemperatureEffectDescription(Temperature)
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
            if (ReduceDamage != null && ReduceDamage.Any())
            {
                values.AppendLine(" ");
                foreach (var damage in ReduceDamage.Keys)
                {
                    var timeToShow = TimeSpan.FromMilliseconds(ReduceDamage[damage]);
                    var mask = @"mm\:ss";
                    if (timeToShow.TotalMinutes > 60)
                    {
                        mask = @"hh\:mm\:ss";
                    }
                    values.AppendLine(string.Format(
                        LanguageProvider.GetEntry(LanguageEntries.FOODDEFINITION_REDUCEDISEASE_DESCRIPTION),
                        StatsConstants.GetDamageEffectDescription(damage),
                        timeToShow.ToString(mask)
                    ));
                }
            }
            if (ReduceTemperature != null && ReduceTemperature.Any())
            {
                values.AppendLine(" ");
                foreach (var Temperature in ReduceTemperature.Keys)
                {
                    var timeToShow = TimeSpan.FromMilliseconds(ReduceTemperature[Temperature]);
                    var mask = @"mm\:ss";
                    if (timeToShow.TotalMinutes > 60)
                    {
                        mask = @"hh\:mm\:ss";
                    }
                    values.AppendLine(string.Format(
                        LanguageProvider.GetEntry(LanguageEntries.FOODDEFINITION_REDUCEDISEASE_DESCRIPTION),
                        StatsConstants.GetTemperatureEffectDescription(Temperature),
                        timeToShow.ToString(mask)
                    ));
                }
            }
            if (ReduceDisease != null && ReduceDisease.Any())
            {
                values.AppendLine(" ");
                foreach (var disease in ReduceDisease.Keys)
                {
                    var timeToShow = TimeSpan.FromMilliseconds(ReduceDisease[disease]);
                    var mask = @"mm\:ss";
                    if (timeToShow.TotalMinutes > 60)
                    {
                        mask = @"hh\:mm\:ss";
                    }
                    values.AppendLine(string.Format(
                        LanguageProvider.GetEntry(LanguageEntries.FOODDEFINITION_REDUCEDISEASE_DESCRIPTION),
                        StatsConstants.GetDiseaseEffectDescription(disease),
                        timeToShow.ToString(mask)
                    ));
                }
            }
            return values.ToString();
        }

        public ConsumableInfo GetConsumableConfigure(UniqueEntityId id)
        {
            var info = new ConsumableInfo()
            {
                DefinitionId = id.DefinitionId,
                StatTrigger = StatsConstants.ValidStats.MedicalDetector.ToString()
            };
            if (Effects != null)
            {
                foreach (var effect in Effects)
                {
                    info.OverTimeEffects.Add(new OverTimeEffectInfo()
                    {
                        Target = effect.EffectTarget.ToString(),
                        TimeToEffect = effect.TimeToEffect,
                        Amount = effect.Ammount,
                        Type = (OverTimeEffectType)((int)effect.EffectType)
                    });
                }
            }
            if (TemperatureEffects != null)
            {
                foreach (var effect in TemperatureEffects.Keys)
                {
                    info.FixedEffects.Add(new FixedEffectInConsumableInfo()
                    {
                        Type = TemperatureEffects[effect] > 0 ? FixedEffectInConsumableType.Add : FixedEffectInConsumableType.Remove,
                        Target = effect.ToString(),
                        Stacks = (byte)Math.Max(TemperatureEffects[effect], 0),
                        MaxStacks = TemperatureEffects[effect] <= 0
                    });
                }
            }
            if (CureDamage != null)
            {
                foreach (var cure in CureDamage)
                {
                    info.FixedEffects.Add(new FixedEffectInConsumableInfo()
                    {
                        Type = FixedEffectInConsumableType.Remove,
                        Target = cure.ToString(),
                        MaxStacks = true
                    });
                }
            }
            if (CureDisease != null)
            {
                foreach (var cure in CureDisease)
                {
                    info.FixedEffects.Add(new FixedEffectInConsumableInfo()
                    {
                        Type = FixedEffectInConsumableType.Remove,
                        Target = cure.ToString(),
                        MaxStacks = true
                    });
                }
            }
            if (CureTemperature != null)
            {
                foreach (var cure in CureTemperature)
                {
                    info.FixedEffects.Add(new FixedEffectInConsumableInfo()
                    {
                        Type = FixedEffectInConsumableType.Remove,
                        Target = cure.ToString(),
                        MaxStacks = true
                    });
                }
            }
            return info;
        }

    }

}