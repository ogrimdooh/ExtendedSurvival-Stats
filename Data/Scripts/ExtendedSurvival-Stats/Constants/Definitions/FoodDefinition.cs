using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRageMath;

namespace ExtendedSurvival.Stats
{

    public class FoodDefinition : SimpleDefinition
    {

        public enum FoodDefinitionType
        {

            Consumable = 0,
            Ore = 1,
            Ingot = 2

        }

        public float Solid { get; set; }
        public float Liquid { get; set; }
        public float ExtraWeight { get; set; }
        public float Protein { get; set; }
        public float Carbohydrate { get; set; }
        public float Lipids { get; set; }
        public float Vitamins { get; set; }
        public float Minerals { get; set; }
        public float Calories { get; set; }
        public float TimeToConsume { get; set; }
        public FoodDefinitionType DefinitionType { get; set; } = FoodDefinitionType.Consumable;
        public bool IgnoreDefinition { get; set; } = false;
        public bool SimpleDescription { get; set; } = false;

        public List<ConsumibleEffect> Effects { get; set; } = new List<ConsumibleEffect>();
        public Dictionary<StatsConstants.DiseaseEffects, float> DiseaseChance { get; set; } = new Dictionary<StatsConstants.DiseaseEffects, float>();
        public List<StatsConstants.DiseaseEffects> CureDisease { get; set; } = new List<StatsConstants.DiseaseEffects>();
        public Dictionary<StatsConstants.TemperatureEffects, int> TemperatureEffects { get; set; } = new Dictionary<StatsConstants.TemperatureEffects, int>();
        public Dictionary<FoodEffectConstants.FoodEffects, int> FoodEffects { get; set; } = new Dictionary<FoodEffectConstants.FoodEffects, int>();
        public Dictionary<FoodEffectConstants.FoodEffectsPart2, int> FoodEffects2 { get; set; } = new Dictionary<FoodEffectConstants.FoodEffectsPart2, int>();

        public bool NeedConservation { get; set; } = false;
        public long StartConservationTime { get; set; } = 0;

        private string GetFoodEffectTargetName(FoodEffectTarget target)
        {
            switch (target)
            {
                case FoodEffectTarget.Health:
                    return "Health";
                case FoodEffectTarget.StaminaAmount:
                    return "Stamina";
                case FoodEffectTarget.Fatigue:
                    return "Fatigue";
                default:
                    return "";
            }
        }

        private string GetNutritionDescription()
        {
            var values = new StringBuilder();
            values.AppendLine(string.Format(
                LanguageProvider.GetEntry(LanguageEntries.FOODDEFINITION_DESCRIPTION),
                Liquid.ToString("#0.00"),
                Solid.ToString("#0.00"),
                (GetMass() * 100 / PlayerBodyConstants.StomachSize.W).ToString("#0.00"),
                Protein.ToString("#0.00"),
                Carbohydrate.ToString("#0.00"),
                Lipids.ToString("#0.00"),
                Vitamins.ToString("#0.00"),
                Minerals.ToString("#0.00"),
                Calories.ToString("#0.00"),
                TimeToConsume.ToString("#0.0")
            ));
            if (NeedConservation)
            {
                values.AppendLine(string.Format(
                    LanguageProvider.GetEntry(LanguageEntries.FOODDEFINITION_ROTTING_DESCRIPTION), 
                    (StartConservationTime / 1000).ToString("#0.0")
                ));
            }
            if (Effects != null && Effects.Any())
            {
                values.AppendLine(" ");
                foreach (var effect in Effects)
                {
                    switch (effect.EffectType)
                    {
                        case FoodEffectType.Instant:
                            values.AppendLine(string.Format(
                                LanguageProvider.GetEntry(LanguageEntries.FOODDEFINITION_EFFECT_INSTANT_DESCRIPTION),
                                GetFoodEffectTargetName(effect.EffectTarget),
                                effect.Ammount.ToString("#0.00")
                            ));
                            break;
                        case FoodEffectType.OverTime:
                            values.AppendLine(string.Format(
                                LanguageProvider.GetEntry(LanguageEntries.FOODDEFINITION_EFFECT_OVERTIME_DESCRIPTION),
                                GetFoodEffectTargetName(effect.EffectTarget),
                                effect.Ammount.ToString("#0.00"),
                                effect.TimeToEffect.ToString("#0.0")
                            ));
                            break;
                    }
                }
            }
            var hadDiseaseChance = DiseaseChance != null && DiseaseChance.Any();
            var hadTemperatureEffectsToAdd = TemperatureEffects != null && TemperatureEffects.Any(x => x.Value > 0);
            if (hadDiseaseChance || hadTemperatureEffectsToAdd)
            {
                values.AppendLine(" ");
                if (hadDiseaseChance)
                {
                    foreach (var disease in DiseaseChance.Keys)
                    {
                        values.AppendLine(string.Format(
                            LanguageProvider.GetEntry(LanguageEntries.FOODDEFINITION_DISEASECHANCE_DESCRIPTION),
                            DiseaseChance[disease].ToString("P1"),
                            StatsConstants.GetDiseaseEffectDescription(disease)
                        ));
                    }
                }
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
            }
            var hadFoodEffectsToAdd = FoodEffects != null && FoodEffects.Any();
            if (hadFoodEffectsToAdd)
            {
                values.AppendLine(" ");
                foreach (var foodEffects in FoodEffects.Keys)
                {
                    if (FoodEffects[foodEffects] > 0)
                    {
                        values.AppendLine(string.Format(
                            LanguageProvider.GetEntry(LanguageEntries.FOODDEFINITION_DISEASECHANCE_DESCRIPTION),
                            (1).ToString("P1"),
                            FoodEffectConstants.GetFoodEffectsDescription(foodEffects)
                        ));
                        var extraInfo = PlayerActionsController.GetStatMultiplierInfo(foodEffects);
                        if (extraInfo != null && extraInfo.Any())
                        {
                            foreach (var item in extraInfo)
                            {
                                values.AppendLine(string.Format("  {0}{1} {2}", item.Value > 0 ? "+" : "", item.FormatedValue, item.Name));
                            }
                        }
                    }
                }
            }
            var hadFoodEffectsToAdd2 = FoodEffects2 != null && FoodEffects2.Any();
            if (hadFoodEffectsToAdd2)
            {
                values.AppendLine(" ");
                foreach (var foodEffects in FoodEffects2.Keys)
                {
                    if (FoodEffects2[foodEffects] > 0)
                    {
                        values.AppendLine(string.Format(
                            LanguageProvider.GetEntry(LanguageEntries.FOODDEFINITION_DISEASECHANCE_DESCRIPTION),
                            (1).ToString("P1"),
                            FoodEffectConstants.GetFoodEffectsDescription(foodEffects)
                        ));
                        var extraInfo = PlayerActionsController.GetStatMultiplierInfo(foodEffects);
                        if (extraInfo != null && extraInfo.Any())
                        {
                            foreach (var item in extraInfo)
                            {
                                values.AppendLine(string.Format("  {0}{1} {2}", item.Value > 0 ? "+" : "", item.FormatedValue, item.Name));
                            }
                        }
                    }
                }
            }
            var hadCureDisease = CureDisease != null && CureDisease.Any();
            var hadTemperatureEffectsToCure = TemperatureEffects != null && TemperatureEffects.Any(x => x.Value <= 0);
            if (hadCureDisease || hadTemperatureEffectsToCure)
            {
                values.AppendLine(" ");
                if (hadCureDisease)
                {
                    foreach (var disease in CureDisease)
                    {
                        values.AppendLine(string.Format(
                            LanguageProvider.GetEntry(LanguageEntries.FOODDEFINITION_CUREDISEASE_DESCRIPTION),
                            StatsConstants.GetDiseaseEffectDescription(disease)
                        ));
                    }
                }
                if (hadTemperatureEffectsToCure)
                {
                    foreach (var temperatureEffects in TemperatureEffects.Keys)
                    {
                        if (TemperatureEffects[temperatureEffects] <= 0)
                        {
                            values.AppendLine(string.Format(
                                LanguageProvider.GetEntry(LanguageEntries.FOODDEFINITION_CUREDISEASE_DESCRIPTION),
                                StatsConstants.GetTemperatureEffectDescription(temperatureEffects)
                            ));
                        }
                    }
                }
            }
            if (FarmConstants.DEFINITIONS.ContainsKey(Id))
            {
                var farmDef = FarmConstants.DEFINITIONS[Id];
                var fertilizerDef = SeedsAndFertilizerConstants.FERTILIZERS_DEFINITIONS[farmDef.PreferredFertilizer];
                values.AppendLine(" ");
                values.AppendLine(string.Format(
                    LanguageProvider.GetEntry(LanguageEntries.FOODDEFINITION_MUSHROOMS_DESCRIPTION), 
                    farmDef.SunRequired ? 
                        LanguageProvider.GetEntry(LanguageEntries.TERMS_YES_NAME) :
                        LanguageProvider.GetEntry(LanguageEntries.TERMS_NO_NAME),
                    fertilizerDef.Name
                ));
            }
            return values.ToString();
        }

        public override string GetFullDescription()
        {
            if (SimpleDescription)
                return base.GetFullDescription();
            return base.GetFullDescription() + Environment.NewLine + Environment.NewLine + GetNutritionDescription();
        }

        public override float GetVolume()
        {
            return GetMass() / 1000;
        }

        public override float GetMass()
        {
            return Solid + Liquid + ExtraWeight;
        }

        public IngestedFood GetAsIngestedFood()
        {
            return new IngestedFood()
            {
                Id = Id,
                Solid = new IngestedFoodProperty(Solid, Solid / TimeToConsume),
                Liquid = new IngestedFoodProperty(Liquid, Liquid / TimeToConsume),
                Protein = new IngestedFoodProperty(Protein, Protein / TimeToConsume),
                Carbohydrate = new IngestedFoodProperty(Carbohydrate, Carbohydrate / TimeToConsume),
                Lipids = new IngestedFoodProperty(Lipids, Lipids / TimeToConsume),
                Vitamins = new IngestedFoodProperty(Vitamins, Vitamins / TimeToConsume),
                Minerals = new IngestedFoodProperty(Minerals, Minerals / TimeToConsume),
                Calories = new IngestedFoodProperty(Calories, Calories / TimeToConsume)
            };
        }

        public ItemExtraInfo GetItemExtraInfo()
        {
            return new ItemExtraInfo()
            {
                DefinitionId = Id.DefinitionId,
                StartConservationTime = StartConservationTime,
                NeedUpdate = true,
                NeedConservation = true,
                RemoveWhenSpoil = true,
                RemoveAmmount = 1,
                AddNewItemWhenSpoil = true,
                AddDefinitionId = new List<ItemExtraDefinitionAmmountInfo>()
                {
                    new ItemExtraDefinitionAmmountInfo()
                    {
                        DefinitionId = ItensConstants.SPOILED_MATERIAL_ID.DefinitionId,
                        Ammount = GetMass()
                    }
                }
            };
        }

        public void AddToIngestedFood(IngestedFood target)
        {
            target.Solid.AddAmmount(Solid);
            target.Liquid.AddAmmount(Liquid);
            target.Protein.AddAmmount(Protein);
            target.Carbohydrate.AddAmmount(Carbohydrate);
            target.Lipids.AddAmmount(Lipids);
            target.Vitamins.AddAmmount(Vitamins);
            target.Minerals.AddAmmount(Minerals);
            target.Calories.AddAmmount(Calories);
        }

        public void ApplyPreparation(FoodRecipeDefinition.RecipePreparationType preparation, bool needConservation, long maxTime)
        {
            NeedConservation = needConservation;
            StartConservationTime = maxTime;
            switch (preparation)
            {
                case FoodRecipeDefinition.RecipePreparationType.IndustrialProcessing:
                    NeedConservation = false;
                    NoNegativeHealth();
                    NoDiseaseChance();
                    break;
                case FoodRecipeDefinition.RecipePreparationType.Processing:
                    NoNegativeHealth();
                    NoDiseaseChance();
                    break;
                case FoodRecipeDefinition.RecipePreparationType.Cooking:
                    StartConservationTime = maxTime * 3;
                    NoNegativeHealth();
                    NoDiseaseChance();
                    ChangeLipids(0.9f);
                    ChangeWater(0.75f);
                    break;
                case FoodRecipeDefinition.RecipePreparationType.Frying:
                    StartConservationTime = maxTime * 2;
                    NoNegativeHealth();
                    NoDiseaseChance();
                    ChangeLipids(1.25f);
                    ChangeWater(0.25f);
                    break;
                case FoodRecipeDefinition.RecipePreparationType.Baking:
                    StartConservationTime = maxTime * 4;
                    NoNegativeHealth();
                    NoDiseaseChance();
                    ChangeLipids(0.8f);
                    ChangeWater(0.5f);
                    break;
                case FoodRecipeDefinition.RecipePreparationType.Drying:
                    StartConservationTime = maxTime * 5;
                    NoNegativeHealth();
                    NoDiseaseChance();
                    var removedWater = ChangeWater(0.1f);
                    Solid += removedWater * -1;
                    ChangeSolid(0.5f);
                    break;
            }
        }

        private void NoDiseaseChance()
        {
            if (DiseaseChance != null && DiseaseChance.Any())
                DiseaseChance.Clear();
        }

        private void NoNegativeHealth()
        {
            if (Effects != null && Effects.Any(x => x.EffectTarget == FoodEffectTarget.Health && x.Ammount < 0))
            {
                foreach (var effect in Effects.Where(x => x.EffectTarget == FoodEffectTarget.Health && x.Ammount < 0))
                {
                    effect.Ammount *= -1;
                }
            }
        }

        private void ChangeLipids(float multiplier)
        {
            Lipids *= multiplier;
        }

        private float ChangeWater(float multiplier)
        {
            var oldValue = Liquid;
            Liquid *= multiplier;
            return Liquid - oldValue;
        }

        private float ChangeSolid(float multiplier)
        {
            var oldValue = Solid;
            Solid *= multiplier;
            return Solid - oldValue;
        }

        public void Assign(FoodDefinition other)
        {
            Solid = other.Solid;
            Liquid = other.Liquid;
            Protein = other.Protein;
            Carbohydrate = other.Carbohydrate;
            Lipids = other.Lipids;
            Vitamins = other.Vitamins;
            Minerals = other.Minerals;
            Calories = other.Calories;
            TimeToConsume = other.TimeToConsume;
            Effects = other.Effects;
            DiseaseChance = other.DiseaseChance;
        }

        public void Increment(FoodDefinition other, float multiplier = 1)
        {
            Solid += other.Solid * multiplier;
            Liquid += other.Liquid * multiplier;
            Protein += other.Protein * multiplier;
            Carbohydrate += other.Carbohydrate * multiplier;
            Lipids += other.Lipids * multiplier;
            Vitamins += other.Vitamins * multiplier;
            Minerals += other.Minerals * multiplier;
            Calories += other.Calories * multiplier;
            TimeToConsume += other.TimeToConsume * multiplier;
            if (other.DiseaseChance != null && other.DiseaseChance.Any())
            {
                if (DiseaseChance == null)
                    DiseaseChance = new Dictionary<StatsConstants.DiseaseEffects, float>();
                foreach (var disease in other.DiseaseChance.Keys)
                {
                    if (!DiseaseChance.ContainsKey(disease))
                        DiseaseChance.Add(disease, other.DiseaseChance[disease]);
                    else
                        DiseaseChance[disease] += other.DiseaseChance[disease];
                    DiseaseChance[disease] = Math.Min(DiseaseChance[disease], 1f);
                }
            }
            if (other.Effects != null && other.Effects.Any())
            {
                if (Effects == null)
                    Effects = new List<ConsumibleEffect>();
                foreach (var effect in other.Effects)
                {
                    if (Effects.Any(x => x.EffectTarget == effect.EffectTarget && x.EffectType == effect.EffectType))
                    {
                        Effects.First(x => x.EffectTarget == effect.EffectTarget && x.EffectType == effect.EffectType).Increment(effect, multiplier);
                    }
                    else
                    {
                        Effects.Add(effect.GetNew(multiplier));
                    }
                }
            }
        }

        public void Decrement(FoodDefinition other)
        {
            Solid -= other.Solid;
            Liquid -= other.Liquid;
            Protein -= other.Protein;
            Carbohydrate -= other.Carbohydrate;
            Lipids -= other.Lipids;
            Vitamins -= other.Vitamins;
            Minerals -= other.Minerals;
            Calories -= other.Calories;
            TimeToConsume -= other.TimeToConsume;
        }

        public void Multiply(float multiplier)
        {
            Solid *= multiplier;
            Liquid *= multiplier;
            Protein *= multiplier;
            Carbohydrate *= multiplier;
            Lipids *= multiplier;
            Vitamins *= multiplier;
            Minerals *= multiplier;
            Calories *= multiplier;
            TimeToConsume *= multiplier;
        }

        public void Divide(float multiplier)
        {
            if (multiplier != 1)
            {
                Solid /= multiplier;
                Liquid /= multiplier;
                Protein /= multiplier;
                Carbohydrate /= multiplier;
                Lipids /= multiplier;
                Vitamins /= multiplier;
                Minerals /= multiplier;
                Calories /= multiplier;
                TimeToConsume /= multiplier;
                if (Effects != null && Effects.Any())
                {
                    foreach (var effect in Effects)
                    {
                        effect.Divide(multiplier);
                    }
                }
            }
        }

        public ConsumableInfo GetConsumableConfigure(UniqueEntityId id)
        {
            var info = new ConsumableInfo()
            {
                DefinitionId = id.DefinitionId,
                TimeToConsume = TimeToConsume,
                StatTrigger = StatsConstants.ValidStats.FoodDetector.ToString()
            };
            info.OverTimeConsumables.Add(new OverTimeConsumableInfo() 
            { 
                Target = StatsConstants.VirtualStats.Solid.ToString(),
                Amount = Solid
            });
            info.OverTimeConsumables.Add(new OverTimeConsumableInfo()
            {
                Target = StatsConstants.VirtualStats.Liquid.ToString(),
                Amount = Liquid
            });
            info.OverTimeConsumables.Add(new OverTimeConsumableInfo()
            {
                Target = StatsConstants.ValidStats.BodyProtein.ToString(),
                Amount = Protein
            });
            info.OverTimeConsumables.Add(new OverTimeConsumableInfo()
            {
                Target = StatsConstants.ValidStats.BodyCarbohydrate.ToString(),
                Amount = Carbohydrate
            });
            info.OverTimeConsumables.Add(new OverTimeConsumableInfo()
            {
                Target = StatsConstants.ValidStats.BodyLipids.ToString(),
                Amount = Lipids
            });
            info.OverTimeConsumables.Add(new OverTimeConsumableInfo()
            {
                Target = StatsConstants.ValidStats.BodyVitamins.ToString(),
                Amount = Vitamins
            });
            info.OverTimeConsumables.Add(new OverTimeConsumableInfo()
            {
                Target = StatsConstants.ValidStats.BodyMinerals.ToString(),
                Amount = Minerals
            });
            info.OverTimeConsumables.Add(new OverTimeConsumableInfo()
            {
                Target = StatsConstants.ValidStats.BodyCalories.ToString(),
                Amount = Calories
            });
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
            if (DiseaseChance != null)
            {
                foreach (var disease in DiseaseChance)
                {
                    info.FixedEffects.Add(new FixedEffectInConsumableInfo()
                    {
                        Type = FixedEffectInConsumableType.ChanceAdd,
                        Chance = disease.Value,
                        Target = disease.Key.ToString(),
                        Stacks = 1
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
            if (FoodEffects != null)
            {
                foreach (var effect in FoodEffects.Keys)
                {
                    info.FixedEffects.Add(new FixedEffectInConsumableInfo()
                    {
                        Type = FoodEffects[effect] > 0 ? FixedEffectInConsumableType.Add : FixedEffectInConsumableType.Remove,
                        Target = effect.ToString(),
                        Stacks = (byte)Math.Max(FoodEffects[effect], 0),
                        MaxStacks = FoodEffects[effect] <= 0
                    });
                }
            }
            if (FoodEffects2 != null)
            {
                foreach (var effect in FoodEffects2.Keys)
                {
                    info.FixedEffects.Add(new FixedEffectInConsumableInfo()
                    {
                        Type = FoodEffects2[effect] > 0 ? FixedEffectInConsumableType.Add : FixedEffectInConsumableType.Remove,
                        Target = effect.ToString(),
                        Stacks = (byte)Math.Max(FoodEffects2[effect], 0),
                        MaxStacks = FoodEffects2[effect] <= 0
                    });
                }
            }
            return info;
        }

    }

}