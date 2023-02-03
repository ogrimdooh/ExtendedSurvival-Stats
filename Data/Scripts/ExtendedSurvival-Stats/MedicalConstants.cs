using Sandbox.Definitions;
using System.Collections.Generic;
using System.Linq;
using VRageMath;

namespace ExtendedSurvival.Stats
{

    public static class MedicalConstants
    {

        public static readonly MedicalDefinition BANDAGES_DEFINITION = new MedicalDefinition()
        {
            Id = ItensConstants.BANDAGES_ID,
            Name = "Simple Bandages",
            Description = "Simple bandages that can be used for first aid.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 1500,
            OfferAmount = new Vector2I(10000, 30000),
            OrderAmount = new Vector2I(2500, 7500),
            AcquisitionAmount = new Vector2I(5000, 15000),
            Mass = 2.5f,
            Volume = 3.0f,
            CureDamage = new List<StatsConstants.DamageEffects>()
            {
                StatsConstants.DamageEffects.Contusion,
                StatsConstants.DamageEffects.Wounded
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectType = FoodEffectType.OverTime,
                    EffectTarget = FoodEffectTarget.Health,
                    TimeToEffect = 20,
                    Ammount = 40
                }
            },
            RecipeDefinition = new SimpleRecipeDefinition()
            {
                RecipeName = "Bandages_Construction",
                ProductAmmount = 1,
                ProductionTime = 2.56f,
                Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                {
                    new SimpleRecipeDefinition.RecipeItem()
                    {
                        Id = ItensConstants.SILICON_INGOT_ID,
                        Ammount = 0.25f
                    },
                    new SimpleRecipeDefinition.RecipeItem()
                    {
                        Id = ItensConstants.SMALLALOEVERAEXTRACT_ID,
                        Ammount = 1
                    }
                }
            }
        };

        public static readonly MedicalDefinition POWER_BANDAGES_DEFINITION = new MedicalDefinition()
        {
            Id = ItensConstants.POWER_BANDAGES_ID,
            Name = "Power Bandages",
            Description = "Simple bandages that can be used for first aid.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 3750,
            OfferAmount = new Vector2I(1000, 3000),
            OrderAmount = new Vector2I(250, 750),
            AcquisitionAmount = new Vector2I(500, 1500),
            Mass = 2.5f,
            Volume = 3.0f,
            CureDamage = new List<StatsConstants.DamageEffects>()
            {
                StatsConstants.DamageEffects.Contusion,
                StatsConstants.DamageEffects.Wounded
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectType = FoodEffectType.OverTime,
                    EffectTarget = FoodEffectTarget.Health,
                    TimeToEffect = 20,
                    Ammount = 80
                }
            },
            RecipeDefinition = new SimpleRecipeDefinition()
            {
                RecipeName = "PowerBandages_Construction",
                ProductAmmount = 1,
                ProductionTime = 5.12f,
                Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                {
                    new SimpleRecipeDefinition.RecipeItem()
                    {
                        Id = ItensConstants.SILICON_INGOT_ID,
                        Ammount = 0.25f
                    },
                    new SimpleRecipeDefinition.RecipeItem()
                    {
                        Id = ItensConstants.ALOEVERAEXTRACT_ID,
                        Ammount = 1
                    },
                    new SimpleRecipeDefinition.RecipeItem()
                    {
                        Id = ItensConstants.POLIETILENOGLICOL_ID,
                        Ammount = 1
                    }
                }
            }
        };

        public static readonly MedicalDefinition SIMPLEMEDICINE_DEFINITION = new MedicalDefinition()
        {
            Id = ItensConstants.SIMPLEMEDICINE_ID,
            Name = "Simple Medicine",
            Description = "A useful remedy for digestive problems or mild pain.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 1500,
            OfferAmount = new Vector2I(10000, 30000),
            OrderAmount = new Vector2I(2500, 7500),
            AcquisitionAmount = new Vector2I(5000, 15000),
            Mass = 2.5f,
            Volume = 3.0f,
            CureDamage = new List<StatsConstants.DamageEffects>()
            {
                StatsConstants.DamageEffects.Contusion
            },
            CureDisease = new List<StatsConstants.DiseaseEffects>()
            {
                StatsConstants.DiseaseEffects.Dysentery,
                StatsConstants.DiseaseEffects.Queasy
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectType = FoodEffectType.OverTime,
                    EffectTarget = FoodEffectTarget.Health,
                    TimeToEffect = 10,
                    Ammount = 20
                },
                new ConsumibleEffect()
                {
                    EffectType = FoodEffectType.OverTime,
                    EffectTarget = FoodEffectTarget.Fatigue,
                    TimeToEffect = 10,
                    Ammount = 50
                }
            },
            RecipeDefinition = new SimpleRecipeDefinition()
            {
                RecipeName = "SimpleMedicine_Construction",
                ProductAmmount = 1,
                ProductionTime = 5.12f,
                Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                {
                    new SimpleRecipeDefinition.RecipeItem()
                    {
                        Id = ItensConstants.SILICON_INGOT_ID,
                        Ammount = 0.15f
                    },
                    new SimpleRecipeDefinition.RecipeItem()
                    {
                        Id = ItensConstants.MINTEXTRACT_ID,
                        Ammount = 1
                    },
                    new SimpleRecipeDefinition.RecipeItem()
                    {
                        Id = ItensConstants.CHAMOMILEEXTRACT_ID,
                        Ammount = 1
                    },
                    new SimpleRecipeDefinition.RecipeItem()
                    {
                        Id = ItensConstants.POLIETILENOGLICOL_ID,
                        Ammount = 1
                    }
                }
            }
        };

        public static readonly MedicalDefinition MEDICINE_DEFINITION = new MedicalDefinition()
        {
            Id = ItensConstants.MEDICINE_ID,
            Name = "Medicine",
            Description = "A useful remedy against poisons, and minor injuries.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 3750,
            OfferAmount = new Vector2I(1000, 3000),
            OrderAmount = new Vector2I(250, 750),
            AcquisitionAmount = new Vector2I(500, 1500),
            Mass = 2.5f,
            Volume = 3.0f,
            CureDamage = new List<StatsConstants.DamageEffects>()
            {
                StatsConstants.DamageEffects.Contusion,
                StatsConstants.DamageEffects.Wounded
            },
            CureDisease = new List<StatsConstants.DiseaseEffects>()
            {
                StatsConstants.DiseaseEffects.Poison
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectType = FoodEffectType.OverTime,
                    EffectTarget = FoodEffectTarget.Health,
                    TimeToEffect = 20,
                    Ammount = 40
                }
            },
            RecipeDefinition = new SimpleRecipeDefinition()
            {
                RecipeName = "Medicine_Construction",
                ProductAmmount = 1,
                ProductionTime = 5.12f,
                Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                {
                    new SimpleRecipeDefinition.RecipeItem()
                    {
                        Id = ItensConstants.SILICON_INGOT_ID,
                        Ammount = 0.15f
                    },
                    new SimpleRecipeDefinition.RecipeItem()
                    {
                        Id = ItensConstants.SMALLALOEVERAEXTRACT_ID,
                        Ammount = 1
                    },
                    new SimpleRecipeDefinition.RecipeItem()
                    {
                        Id = ItensConstants.POLIETILENOGLICOL_ID,
                        Ammount = 1
                    }
                }
            }
        };

        public static readonly MedicalDefinition HEALTH_BUSTER_DEFINITION = new MedicalDefinition()
        {
            Id = ItensConstants.HEALTH_BUSTER_ID,
            Name = "Health Buster",
            Description = "A powerful injectable that causes spontaneous regeneration in the body.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 7500,
            OfferAmount = new Vector2I(100, 300),
            OrderAmount = new Vector2I(25, 75),
            AcquisitionAmount = new Vector2I(50, 150),
            Mass = 2.5f,
            Volume = 3.0f,
            CureDamage = new List<StatsConstants.DamageEffects>()
            {
                StatsConstants.DamageEffects.Contusion,
                StatsConstants.DamageEffects.Wounded,
                StatsConstants.DamageEffects.DeepWounded
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectType = FoodEffectType.Instant,
                    EffectTarget = FoodEffectTarget.Health,
                    Ammount = 25
                },
                new ConsumibleEffect()
                {
                    EffectType = FoodEffectType.OverTime,
                    EffectTarget = FoodEffectTarget.Health,
                    TimeToEffect = 30,
                    Ammount = 75
                }
            },
            RecipeDefinition = new SimpleRecipeDefinition()
            {
                RecipeName = "HealthBuster_Construction",
                ProductAmmount = 1,
                ProductionTime = 10.24f,
                Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                {
                    new SimpleRecipeDefinition.RecipeItem()
                    {
                        Id = ItensConstants.IRON_INGOT_ID,
                        Ammount = 0.05f
                    },
                    new SimpleRecipeDefinition.RecipeItem()
                    {
                        Id = ItensConstants.SILICON_INGOT_ID,
                        Ammount = 0.25f
                    },
                    new SimpleRecipeDefinition.RecipeItem()
                    {
                        Id = ItensConstants.ALOEVERAEXTRACT_ID,
                        Ammount = 1
                    },
                    new SimpleRecipeDefinition.RecipeItem()
                    {
                        Id = ItensConstants.SILVERSULFADIAZINE_ID,
                        Ammount = 1
                    }
                }
            }
        };

        public static readonly MedicalDefinition HEALTHINJECTION_DEFINITION = new MedicalDefinition()
        {
            Id = ItensConstants.HEALTHINJECTION_ID,
            Name = "Health Injection",
            Description = "A powerful injectable capable of curing infections and reducing fatigue.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 7500,
            OfferAmount = new Vector2I(100, 300),
            OrderAmount = new Vector2I(25, 75),
            AcquisitionAmount = new Vector2I(50, 150),
            Mass = 2.5f,
            Volume = 3.0f,
            CureDamage = new List<StatsConstants.DamageEffects>()
            {
                StatsConstants.DamageEffects.Contusion
            },
            CureDisease = new List<StatsConstants.DiseaseEffects>()
            { 
                StatsConstants.DiseaseEffects.Infected 
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectType = FoodEffectType.Instant,
                    EffectTarget = FoodEffectTarget.Fatigue,
                    Ammount = 50
                },
                new ConsumibleEffect()
                {
                    EffectType = FoodEffectType.OverTime,
                    EffectTarget = FoodEffectTarget.Fatigue,
                    TimeToEffect = 25,
                    Ammount = 250
                }
            },
            RecipeDefinition = new SimpleRecipeDefinition()
            {
                RecipeName = "HealthInjection_Construction",
                ProductAmmount = 1,
                ProductionTime = 10.24f,
                Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                {
                    new SimpleRecipeDefinition.RecipeItem()
                    {
                        Id = ItensConstants.IRON_INGOT_ID,
                        Ammount = 0.05f
                    },
                    new SimpleRecipeDefinition.RecipeItem()
                    {
                        Id = ItensConstants.SILICON_INGOT_ID,
                        Ammount = 0.15f
                    },
                    new SimpleRecipeDefinition.RecipeItem()
                    {
                        Id = ItensConstants.ARNICAEXTRACT_ID,
                        Ammount = 1
                    },
                    new SimpleRecipeDefinition.RecipeItem()
                    {
                        Id = ItensConstants.SILVERSULFADIAZINE_ID,
                        Ammount = 1
                    },
                    new SimpleRecipeDefinition.RecipeItem()
                    {
                        Id = ItensConstants.POLIETILENOGLICOL_ID,
                        Ammount = 1
                    }
                }
            }
        };

        public static readonly MedicalDefinition HEALTHPOWERINJECTION_DEFINITION = new MedicalDefinition()
        {
            Id = ItensConstants.HEALTHPOWERINJECTION_ID,
            Name = "Health Power Injection",
            Description = "A very powerful injectable that causes spontaneous regeneration in the body.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 7500,
            OfferAmount = new Vector2I(100, 300),
            OrderAmount = new Vector2I(25, 75),
            AcquisitionAmount = new Vector2I(50, 150),
            Mass = 2.5f,
            Volume = 3.0f,
            CureDamage = new List<StatsConstants.DamageEffects>()
            {
                StatsConstants.DamageEffects.Contusion,
                StatsConstants.DamageEffects.Wounded,
                StatsConstants.DamageEffects.DeepWounded
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectType = FoodEffectType.Instant,
                    EffectTarget = FoodEffectTarget.Health,
                    Ammount = 50
                },
                new ConsumibleEffect()
                {
                    EffectType = FoodEffectType.OverTime,
                    EffectTarget = FoodEffectTarget.Health,
                    TimeToEffect = 60,
                    Ammount = 150
                }
            },
            RecipeDefinition = new SimpleRecipeDefinition()
            {
                RecipeName = "HealthPowerInjection_Construction",
                ProductAmmount = 1,
                ProductionTime = 10.24f,
                Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                {
                    new SimpleRecipeDefinition.RecipeItem()
                    {
                        Id = ItensConstants.IRON_INGOT_ID,
                        Ammount = 0.05f
                    },
                    new SimpleRecipeDefinition.RecipeItem()
                    {
                        Id = ItensConstants.SILICON_INGOT_ID,
                        Ammount = 0.15f
                    },
                    new SimpleRecipeDefinition.RecipeItem()
                    {
                        Id = ItensConstants.ALOEVERAEXTRACT_ID,
                        Ammount = 2
                    },
                    new SimpleRecipeDefinition.RecipeItem()
                    {
                        Id = ItensConstants.SILVERSULFADIAZINE_ID,
                        Ammount = 1
                    },
                    new SimpleRecipeDefinition.RecipeItem()
                    {
                        Id = ItensConstants.POLIETILENOGLICOL_ID,
                        Ammount = 1
                    }
                }
            }
        };

        public static readonly MedicalDefinition MEDKIT_DEFINITION = new MedicalDefinition()
        {
            Id = ItensConstants.MEDKIT_ID,
            Name = "Medkit",
            Description = "An injectable capable of regenerating even bones.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 15000,
            OfferAmount = new Vector2I(100, 300),
            OrderAmount = new Vector2I(25, 75),
            AcquisitionAmount = new Vector2I(50, 150),
            Mass = 2.5f,
            Volume = 3.0f,
            CureDamage = new List<StatsConstants.DamageEffects>()
            {
                StatsConstants.DamageEffects.Contusion,
                StatsConstants.DamageEffects.Wounded,
                StatsConstants.DamageEffects.DeepWounded,
                StatsConstants.DamageEffects.BrokenBones
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectType = FoodEffectType.Instant,
                    EffectTarget = FoodEffectTarget.Health,
                    Ammount = 100
                },
                new ConsumibleEffect()
                {
                    EffectType = FoodEffectType.OverTime,
                    EffectTarget = FoodEffectTarget.Health,
                    TimeToEffect = 120,
                    Ammount = 300
                }
            },
            RecipeDefinition = new SimpleRecipeDefinition()
            {
                RecipeName = "Medkit_Construction",
                ProductAmmount = 1,
                ProductionTime = 20.48f,
                Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                {
                    new SimpleRecipeDefinition.RecipeItem()
                    {
                        Id = ItensConstants.IRON_INGOT_ID,
                        Ammount = 0.05f
                    },
                    new SimpleRecipeDefinition.RecipeItem()
                    {
                        Id = ItensConstants.SILICON_INGOT_ID,
                        Ammount = 0.15f
                    },
                    new SimpleRecipeDefinition.RecipeItem()
                    {
                        Id = ItensConstants.ALOEVERAEXTRACT_ID,
                        Ammount = 3
                    },
                    new SimpleRecipeDefinition.RecipeItem()
                    {
                        Id = ItensConstants.SILVERSULFADIAZINE_ID,
                        Ammount = 2
                    },
                    new SimpleRecipeDefinition.RecipeItem()
                    {
                        Id = ItensConstants.POLIETILENOGLICOL_ID,
                        Ammount = 1
                    }
                }
            }
        };

        public static Dictionary<UniqueEntityId, MedicalDefinition> MEDICAL_DEFINITIONS = new Dictionary<UniqueEntityId, MedicalDefinition>()
        {
            { ItensConstants.BANDAGES_ID, BANDAGES_DEFINITION },
            { ItensConstants.POWER_BANDAGES_ID, POWER_BANDAGES_DEFINITION },
            { ItensConstants.SIMPLEMEDICINE_ID, SIMPLEMEDICINE_DEFINITION },
            { ItensConstants.MEDICINE_ID, MEDICINE_DEFINITION },
            { ItensConstants.HEALTH_BUSTER_ID, HEALTH_BUSTER_DEFINITION },
            { ItensConstants.HEALTHINJECTION_ID, HEALTHINJECTION_DEFINITION },
            { ItensConstants.HEALTHPOWERINJECTION_ID, HEALTHPOWERINJECTION_DEFINITION },
            { ItensConstants.MEDKIT_ID, MEDKIT_DEFINITION }
        };

        public static void TryOverrideDefinitions()
        {
            try
            {
                var targetFaction = FactionTypeConstants.FACTION_TYPES_DEFINITIONS[FactionTypeConstants.TRADER_ID];
                // Override medical definition
                foreach (var medical in MEDICAL_DEFINITIONS.Keys)
                {
                    var medicalDef = MEDICAL_DEFINITIONS[medical];
                    // Item definition
                    var consumableDef = DefinitionUtils.TryGetDefinition<MyConsumableItemDefinition>(medical.subtypeId.String);
                    if (consumableDef != null)
                    {
                        if (consumableDef.Stats == null)
                            consumableDef.Stats = new List<MyConsumableItemDefinition.StatValue>();
                        consumableDef.Stats.Clear();
                        consumableDef.Stats.Add(new MyConsumableItemDefinition.StatValue()
                        {
                            Name = StatsConstants.ValidStats.MedicalDetector.ToString(),
                            Time = 3,
                            Value = 0.025f
                        });
                        consumableDef.Volume = medicalDef.Volume;
                        consumableDef.Mass = medicalDef.Mass;
                        consumableDef.DisplayNameEnum = null;
                        consumableDef.DisplayNameString = medicalDef.Name;
                        consumableDef.DescriptionEnum = null;
                        consumableDef.DescriptionString = medicalDef.GetFullDescription();
                        consumableDef.MinimumAcquisitionAmount = medicalDef.AcquisitionAmount.X;
                        consumableDef.MaximumAcquisitionAmount = medicalDef.AcquisitionAmount.Y;
                        consumableDef.MinimumOrderAmount = medicalDef.OrderAmount.X;
                        consumableDef.MaximumOrderAmount = medicalDef.OrderAmount.Y;
                        consumableDef.MinimumOfferAmount = medicalDef.OfferAmount.X;
                        consumableDef.MaximumOfferAmount = medicalDef.OfferAmount.Y;
                        consumableDef.MinimalPricePerUnit = medicalDef.MinimalPricePerUnit;
                        consumableDef.CanPlayerOrder = medicalDef.CanPlayerOrder;
                        consumableDef.Postprocess();
                    }
                    else
                        ExtendedSurvivalStatsLogging.Instance.LogInfo(typeof(FoodConstants), $"TryOverrideRecipes item not found. Food=[{medical}]");
                    // Recipe definition
                    var recipeDef = DefinitionUtils.TryGetBlueprintDefinition(medicalDef.RecipeDefinition.RecipeName);
                    if (recipeDef != null)
                    {
                        recipeDef.Prerequisites = medicalDef.RecipeDefinition.GetIngredients();
                        recipeDef.Results = medicalDef.RecipeDefinition.GetProduct(medicalDef.Id);
                        recipeDef.BaseProductionTimeInSeconds = medicalDef.RecipeDefinition.ProductionTime;
                        recipeDef.DisplayNameEnum = null;
                        recipeDef.DisplayNameString = medicalDef.Name;
                        recipeDef.DescriptionEnum = null;
                        recipeDef.DescriptionString = medicalDef.GetFullDescription();
                        recipeDef.Postprocess();
                    }
                    else
                        ExtendedSurvivalStatsLogging.Instance.LogInfo(typeof(FoodConstants), $"CalculateRecipesNutrition recipe not found. Recipe=[{medicalDef.RecipeDefinition.RecipeName}]");
                    // Add itens to faction types
                    if (medicalDef.CanPlayerOrder)
                    {
                        targetFaction.OffersList.Add(medical);
                        targetFaction.OrdersList.Add(medical);
                    }
                }
            }
            catch (System.Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(typeof(FoodConstants), ex);
            }
        }

    }

}