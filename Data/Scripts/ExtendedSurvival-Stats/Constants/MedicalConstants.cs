using Sandbox.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using VRage.Game;
using VRageMath;

namespace ExtendedSurvival.Stats
{

    public static class MedicalConstants
    {

        public const string BANDAGES_SUBTYPEID = "Bandages";
        public static readonly UniqueEntityId BANDAGES_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), BANDAGES_SUBTYPEID);

        public const string POWER_BANDAGES_SUBTYPEID = "PowerBandages";
        public static readonly UniqueEntityId POWER_BANDAGES_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), POWER_BANDAGES_SUBTYPEID);

        public const string HEALTH_BUSTER_SUBTYPEID = "HealthBuster";
        public static readonly UniqueEntityId HEALTH_BUSTER_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), HEALTH_BUSTER_SUBTYPEID);

        public const string MEDKIT_SUBTYPEID = "Medkit";
        public static readonly UniqueEntityId MEDKIT_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), MEDKIT_SUBTYPEID);

        public const string HEALTHINJECTION_SUBTYPEID = "HealthInjection";
        public static readonly UniqueEntityId HEALTHINJECTION_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), HEALTHINJECTION_SUBTYPEID);

        public const string HEALTHPOWERINJECTION_SUBTYPEID = "HealthPowerInjection";
        public static readonly UniqueEntityId HEALTHPOWERINJECTION_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), HEALTHPOWERINJECTION_SUBTYPEID);

        public const string SIMPLEMEDICINE_SUBTYPEID = "SimpleMedicine";
        public static readonly UniqueEntityId SIMPLEMEDICINE_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), SIMPLEMEDICINE_SUBTYPEID);

        public const string MEDICINE_SUBTYPEID = "Medicine";
        public static readonly UniqueEntityId MEDICINE_ID = new UniqueEntityId(typeof(MyObjectBuilder_ConsumableItem), MEDICINE_SUBTYPEID);

        public static readonly MedicalDefinition BANDAGES_DEFINITION = new MedicalDefinition()
        {
            Id = BANDAGES_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.BANDAGES_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.BANDAGES_DESCRIPTION),
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
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
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
                            Id = QuimicalConstants.SMALLALOEVERAEXTRACT_ID,
                            Ammount = 1
                        }
                    }
                }
            }
        };

        public static readonly MedicalDefinition POWER_BANDAGES_DEFINITION = new MedicalDefinition()
        {
            Id = POWER_BANDAGES_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.POWER_BANDAGES_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.POWER_BANDAGES_DESCRIPTION),
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
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
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
                            Id = QuimicalConstants.ALOEVERAEXTRACT_ID,
                            Ammount = 1
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.POLIETILENOGLICOL_ID,
                            Ammount = 1
                        }
                    }
                }
            }
        };

        public static readonly MedicalDefinition SIMPLEMEDICINE_DEFINITION = new MedicalDefinition()
        {
            Id = SIMPLEMEDICINE_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.SIMPLEMEDICINE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.SIMPLEMEDICINE_DESCRIPTION),
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
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
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
                            Id = QuimicalConstants.MINTEXTRACT_ID,
                            Ammount = 1
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = QuimicalConstants.CHAMOMILEEXTRACT_ID,
                            Ammount = 1
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.POLIETILENOGLICOL_ID,
                            Ammount = 1
                        }
                    }
                }
            }
        };

        public static readonly MedicalDefinition MEDICINE_DEFINITION = new MedicalDefinition()
        {
            Id = MEDICINE_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.MEDICINE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.MEDICINE_DESCRIPTION),
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
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
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
                            Id = QuimicalConstants.SMALLALOEVERAEXTRACT_ID,
                            Ammount = 1
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.POLIETILENOGLICOL_ID,
                            Ammount = 1
                        }
                    }
                }
            }
        };

        public static readonly MedicalDefinition HEALTH_BUSTER_DEFINITION = new MedicalDefinition()
        {
            Id = HEALTH_BUSTER_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.HEALTH_BUSTER_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.HEALTH_BUSTER_DESCRIPTION),
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
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
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
                            Id = QuimicalConstants.ALOEVERAEXTRACT_ID,
                            Ammount = 1
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILVERSULFADIAZINE_ID,
                            Ammount = 1
                        }
                    }
                }
            }
        };

        public static readonly MedicalDefinition HEALTHINJECTION_DEFINITION = new MedicalDefinition()
        {
            Id = HEALTHINJECTION_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.HEALTHINJECTION_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.HEALTHINJECTION_DESCRIPTION),
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
                StatsConstants.DiseaseEffects.Infected,
                StatsConstants.DiseaseEffects.Pneumonia
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
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
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
                            Id = QuimicalConstants.ARNICAEXTRACT_ID,
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
            }
        };

        public static readonly MedicalDefinition HEALTHPOWERINJECTION_DEFINITION = new MedicalDefinition()
        {
            Id = HEALTHPOWERINJECTION_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.HEALTHPOWERINJECTION_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.HEALTHPOWERINJECTION_DESCRIPTION),
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
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
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
                            Id = QuimicalConstants.ALOEVERAEXTRACT_ID,
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
            }
        };

        public static readonly MedicalDefinition MEDKIT_DEFINITION = new MedicalDefinition()
        {
            Id = MEDKIT_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.MEDKIT_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.MEDKIT_DESCRIPTION),
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
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
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
                            Id = QuimicalConstants.ALOEVERAEXTRACT_ID,
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
            }
        };

        public static Dictionary<UniqueEntityId, MedicalDefinition> MEDICAL_DEFINITIONS = new Dictionary<UniqueEntityId, MedicalDefinition>()
        {
            { BANDAGES_ID, BANDAGES_DEFINITION },
            { POWER_BANDAGES_ID, POWER_BANDAGES_DEFINITION },
            { SIMPLEMEDICINE_ID, SIMPLEMEDICINE_DEFINITION },
            { MEDICINE_ID, MEDICINE_DEFINITION },
            { HEALTH_BUSTER_ID, HEALTH_BUSTER_DEFINITION },
            { HEALTHINJECTION_ID, HEALTHINJECTION_DEFINITION },
            { HEALTHPOWERINJECTION_ID, HEALTHPOWERINJECTION_DEFINITION },
            { MEDKIT_ID, MEDKIT_DEFINITION }
        };

        public static void TryOverrideDefinitions()
        {
            PhysicalItemDefinitionOverride.TryOverrideDefinitions<MedicalDefinition, MyConsumableItemDefinition>(MEDICAL_DEFINITIONS, (definitionDef, consumableDef) => {
                consumableDef.Stats.Clear();
                consumableDef.Stats.Add(new MyConsumableItemDefinition.StatValue()
                {
                    Name = StatsConstants.ValidStats.MedicalDetector.ToString(),
                    Time = 3,
                    Value = 0.025f
                });
            });
        }

    }

}