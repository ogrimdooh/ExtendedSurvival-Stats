using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRageMath;

namespace ExtendedSurvival.Stats
{

    public class FoodDefinition
    {

        public enum FoodDefinitionType
        {

            Consumable = 0,
            Ore = 1,
            Ingot = 2

        }

        public UniqueEntityId Id { get; set; }
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
        public string Name { get; set; }
        public string Description { get; set; }
        public FoodDefinitionType DefinitionType { get; set; } = FoodDefinitionType.Consumable;
        public bool IgnoreDefinition { get; set; } = false;
        public bool SimpleDescription { get; set; } = false;
        public Vector2I AcquisitionAmount { get; set; } = Vector2I.Zero;
        public Vector2I OrderAmount { get; set; } = Vector2I.Zero;
        public Vector2I OfferAmount { get; set; } = Vector2I.Zero;
        public int MinimalPricePerUnit { get; set; }
        public bool CanPlayerOrder { get; set; } = false;

        public List<ConsumibleEffect> Effects { get; set; }
        public Dictionary<StatsConstants.DiseaseEffects, float> DiseaseChance { get; set; }
        public List<StatsConstants.DiseaseEffects> CureDisease { get; set; }

        public bool NeedConservation { get; set; } = false;
        public long StartConservationTime { get; set; } = 0;

        private string GetNutritionDescription()
        {
            var values = new StringBuilder();
            values.AppendLine(string.Format("Liquid: {0}L", Liquid.ToString("#0.00")));
            values.AppendLine(string.Format("Solid: {0}Kg", Solid.ToString("#0.00")));
            values.AppendLine(string.Format("Stomach: {0}%", (GetMass() * 100 / PlayerBodyConstants.StomachSize.W).ToString("#0.00")));
            values.AppendLine(" ");
            values.AppendLine(string.Format("Protein: {0}g", Protein.ToString("#0.00")));
            values.AppendLine(string.Format("Carbohydrate: {0}g", Carbohydrate.ToString("#0.00")));
            values.AppendLine(string.Format("Lipids: {0}g", Lipids.ToString("#0.00")));
            values.AppendLine(string.Format("Vitamins: {0}g", Vitamins.ToString("#0.00")));
            values.AppendLine(string.Format("Minerals: {0}g", Minerals.ToString("#0.00")));
            values.AppendLine(string.Format("Calories: {0}Cal", Calories.ToString("#0.00")));
            values.AppendLine(" ");
            values.AppendLine(string.Format("Digestion Time: {0}s", TimeToConsume.ToString("#0.0")));
            if (NeedConservation)
            {
                values.AppendLine(string.Format("Rotting time: {0}s", (StartConservationTime / 1000).ToString("#0.0")));
            }
            if (Effects != null && Effects.Any())
            {
                values.AppendLine(" ");
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
            if (DiseaseChance != null && DiseaseChance.Any())
            {
                values.AppendLine(" ");
                foreach (var disease in DiseaseChance.Keys)
                {
                    values.AppendLine(string.Format("{0} chance to get {1} when eat", DiseaseChance[disease].ToString("P1"), StatsConstants.GetDiseaseEffectDescription(disease)));
                }
            }
            if (CureDisease != null && CureDisease.Any())
            {
                values.AppendLine(" ");
                foreach (var disease in CureDisease)
                {
                    values.AppendLine(string.Format("Can cure {0} when eat", StatsConstants.GetDiseaseEffectDescription(disease)));
                }
            }
            return values.ToString();
        }

        public string GetFullDescription()
        {
            if (SimpleDescription)
                return Description;
            return Description + Environment.NewLine + Environment.NewLine + GetNutritionDescription();
        }

        public float GetVolume()
        {
            return GetMass() / 1000;
        }

        public float GetMass()
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

        public ExtendedSurvivalCoreAPI.ItemExtraInfo GetItemExtraInfo()
        {
            return new ExtendedSurvivalCoreAPI.ItemExtraInfo()
            {
                DefinitionId = Id.DefinitionId,
                StartConservationTime = StartConservationTime,
                NeedUpdate = true,
                NeedConservation = true,
                RemoveWhenSpoil = true,
                RemoveAmmount = 1,
                AddNewItemWhenSpoil = true,
                AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                {
                    new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
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
                    NoNegativeTemperature();
                    ChangeLipids(0.9f);
                    ChangeWater(0.75f);
                    break;
                case FoodRecipeDefinition.RecipePreparationType.Frying:
                    StartConservationTime = maxTime * 2;
                    NoNegativeHealth();
                    NoDiseaseChance();
                    NoTemperatureChange();
                    ChangeLipids(1.25f);
                    ChangeWater(0.25f);
                    break;
                case FoodRecipeDefinition.RecipePreparationType.Baking:
                    StartConservationTime = maxTime * 4;
                    NoNegativeHealth();
                    NoDiseaseChance();
                    NoTemperatureChange();
                    ChangeLipids(0.8f);
                    ChangeWater(0.5f);
                    break;
                case FoodRecipeDefinition.RecipePreparationType.Drying:
                    StartConservationTime = maxTime * 5;
                    NoNegativeHealth();
                    NoDiseaseChance();
                    NoTemperatureChange();
                    var removedWater = ChangeWater(0.1f);
                    Solid += removedWater * -1;
                    ChangeSolid(0.5f);
                    break;
            }
        }

        private void NoTemperatureChange()
        {
            if (Effects != null)
                Effects.RemoveAll(x => x.EffectTarget == FoodEffectTarget.Temperature);
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

        private void NoNegativeTemperature()
        {
            if (Effects != null && Effects.Any(x => x.EffectTarget == FoodEffectTarget.Temperature && x.Ammount < 0))
            {
                foreach (var effect in Effects.Where(x => x.EffectTarget == FoodEffectTarget.Temperature && x.Ammount < 0))
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

    }

}