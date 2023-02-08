using Sandbox.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using VRage;
using VRageMath;

namespace ExtendedSurvival.Stats
{
    public static class FoodConstants
    {

        public static readonly long BASE_RAW_MEAT_SPOIL_TIME = 5 * 60 * 1000;
        public static readonly long BASE_RAW_VEGETABLE_SPOIL_TIME = (long)(7.5f * 60 * 1000);
        public static readonly long BASE_RAW_FRUIT_SPOIL_TIME = 10 * 60 * 1000;
        public static readonly long BASE_RAW_MUSHROOM_SPOIL_TIME = (long)(12.5f * 60 * 1000);
        public static readonly long BASE_MILK_SPOIL_TIME = 15 * 60 * 1000;
        public static readonly long BASE_EGG_SPOIL_TIME = 15 * 60 * 1000;

        public static readonly FoodDefinition APPLE_DEFINITION = new FoodDefinition()
        {
            Id = ItensConstants.APPLE_ID,
            Solid = 0.03f,
            Liquid = 0.120f,
            Protein = 0.36f,
            Carbohydrate = 19.06f,
            Lipids = 0.24f,
            Vitamins = 0.075f,
            Minerals = 0.165f,
            Calories = 71f,
            TimeToConsume = 80f,
            NeedConservation = true,
            StartConservationTime = BASE_RAW_FRUIT_SPOIL_TIME,
            Name = LanguageProvider.GetEntry(LanguageEntries.APPLE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.APPLE_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 10,
            OfferAmount = new Vector2I(15000, 45000),
            OrderAmount = new Vector2I(5000, 15000),
            AcquisitionAmount = new Vector2I(10000, 30000),
            DiseaseChance = new Dictionary<StatsConstants.DiseaseEffects, float>()
            {
                { StatsConstants.DiseaseEffects.Dysentery, 0.025f }
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Stamina,
                    EffectType = FoodEffectType.Instant,
                    Ammount = 5
                },
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Health,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = 10,
                    TimeToEffect = 5
                }
            }
        };

        public static readonly FoodDefinition BROCCOLI_DEFINITION = new FoodDefinition()
        {
            Id = ItensConstants.BROCCOLI_ID,
            Solid = 0.08f,
            Liquid = 0.320f,
            Protein = 11.2f,
            Carbohydrate = 28f,
            Lipids = 1.6f,
            Vitamins = 0.360f,
            Minerals = 0.272f,
            Calories = 136f,
            TimeToConsume = 60f,
            NeedConservation = true,
            StartConservationTime = BASE_RAW_VEGETABLE_SPOIL_TIME,
            Name = LanguageProvider.GetEntry(LanguageEntries.BROCCOLI_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.BROCCOLI_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 15,
            OfferAmount = new Vector2I(15000, 45000),
            OrderAmount = new Vector2I(5000, 15000),
            AcquisitionAmount = new Vector2I(10000, 30000),
            DiseaseChance = new Dictionary<StatsConstants.DiseaseEffects, float>()
            {
                { StatsConstants.DiseaseEffects.Dysentery, 0.025f }
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Health,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = 10,
                    TimeToEffect = 5
                }
            }
        };

        public static readonly FoodDefinition BEETROOT_DEFINITION = new FoodDefinition()
        {
            Id = ItensConstants.BEETROOT_ID,
            Solid = 0.015f,
            Liquid = 0.105f,
            Protein = 1.92f,
            Carbohydrate = 11.472f,
            Lipids = 0.204f,
            Vitamins = 0.006f,
            Minerals = 0.5784f,
            Calories = 51.6f,
            TimeToConsume = 120f,
            NeedConservation = true,
            StartConservationTime = BASE_RAW_VEGETABLE_SPOIL_TIME,
            Name = LanguageProvider.GetEntry(LanguageEntries.BEETROOT_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.BEETROOT_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 10,
            OfferAmount = new Vector2I(15000, 45000),
            OrderAmount = new Vector2I(5000, 15000),
            AcquisitionAmount = new Vector2I(10000, 30000),
            DiseaseChance = new Dictionary<StatsConstants.DiseaseEffects, float>()
            {
                { StatsConstants.DiseaseEffects.Dysentery, 0.025f }
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Health,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = 10,
                    TimeToEffect = 5
                }
            }
        };

        public static readonly FoodDefinition CAROOT_DEFINITION = new FoodDefinition()
        {
            Id = ItensConstants.CAROOT_ID,
            Solid = 0.015f,
            Liquid = 0.105f,
            Protein = 1.116f,
            Carbohydrate = 11.52f,
            Lipids = 0.288f,
            Vitamins = 0.0024f,
            Minerals = 0.7344f,
            Calories = 49.5f,
            TimeToConsume = 120f,
            NeedConservation = true,
            StartConservationTime = BASE_RAW_VEGETABLE_SPOIL_TIME,
            Name = LanguageProvider.GetEntry(LanguageEntries.CAROOT_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.CAROOT_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 10,
            OfferAmount = new Vector2I(15000, 45000),
            OrderAmount = new Vector2I(5000, 15000),
            AcquisitionAmount = new Vector2I(10000, 30000),
            DiseaseChance = new Dictionary<StatsConstants.DiseaseEffects, float>()
            {
                { StatsConstants.DiseaseEffects.Dysentery, 0.025f }
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Health,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = 10,
                    TimeToEffect = 5
                }
            }
        };

        public static readonly FoodDefinition SHIITAKE_DEFINITION = new FoodDefinition()
        {
            Id = ItensConstants.SHIITAKE_ID,
            Solid = 0.003f,
            Liquid = 0.027f,
            Protein = 0.66f,
            Carbohydrate = 2.04f,
            Lipids = 0.15f,
            Vitamins = 0.0027f,
            Minerals = 0.1341f,
            Calories = 10.2f,
            TimeToConsume = 10f,
            NeedConservation = true,
            StartConservationTime = BASE_RAW_MUSHROOM_SPOIL_TIME,
            Name = LanguageProvider.GetEntry(LanguageEntries.SHIITAKE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.SHIITAKE_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 5,
            OfferAmount = new Vector2I(15000, 45000),
            OrderAmount = new Vector2I(5000, 15000),
            AcquisitionAmount = new Vector2I(10000, 30000),
            DiseaseChance = new Dictionary<StatsConstants.DiseaseEffects, float>()
            {
                { StatsConstants.DiseaseEffects.Dysentery, 0.05f }
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Fatigue,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = 10,
                    TimeToEffect = 5
                }
            }
        };

        public static readonly FoodDefinition CHAMPIGNONS_DEFINITION = new FoodDefinition()
        {
            Id = ItensConstants.CHAMPIGNONS_ID,
            Solid = 0.004f,
            Liquid = 0.016f,
            Protein = 0.618f,
            Carbohydrate = 0.652f,
            Lipids = 0.048f,
            Vitamins = 0.0014f,
            Minerals = 0.0832f,
            Calories = 4.4f,
            TimeToConsume = 10f,
            NeedConservation = true,
            StartConservationTime = BASE_RAW_MUSHROOM_SPOIL_TIME,
            Name = LanguageProvider.GetEntry(LanguageEntries.CHAMPIGNONS_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.CHAMPIGNONS_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 5,
            OfferAmount = new Vector2I(15000, 45000),
            OrderAmount = new Vector2I(5000, 15000),
            AcquisitionAmount = new Vector2I(10000, 30000),
            DiseaseChance = new Dictionary<StatsConstants.DiseaseEffects, float>()
            {
                { StatsConstants.DiseaseEffects.Dysentery, 0.05f }
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Fatigue,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = 10,
                    TimeToEffect = 5
                }
            }
        };

        public static readonly FoodDefinition AMANITAMUSCARIA_DEFINITION = new FoodDefinition()
        {
            Id = ItensConstants.AMANITAMUSCARIA_ID,
            Solid = 0.004f,
            Liquid = 0.016f,
            Protein = 0.218f,
            Carbohydrate = 0.352f,
            Lipids = 0.045f,
            Vitamins = 0.0012f,
            Minerals = 0.0838f,
            Calories = 7.2f,
            TimeToConsume = 10f,
            NeedConservation = true,
            StartConservationTime = BASE_RAW_MUSHROOM_SPOIL_TIME,
            Name = LanguageProvider.GetEntry(LanguageEntries.AMANITAMUSCARIA_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.AMANITAMUSCARIA_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 25,
            OfferAmount = new Vector2I(15000, 45000),
            OrderAmount = new Vector2I(5000, 15000),
            AcquisitionAmount = new Vector2I(10000, 30000),
            DiseaseChance = new Dictionary<StatsConstants.DiseaseEffects, float>()
            {
                { StatsConstants.DiseaseEffects.Poison, 1.0f }
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Health,
                    EffectType = FoodEffectType.Instant,
                    Ammount = -50
                },
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Health,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = -150,
                    TimeToEffect = 30
                }
            }
        };

        public static readonly FoodDefinition TOMATO_DEFINITION = new FoodDefinition()
        {
            Id = ItensConstants.TOMATO_ID,
            Solid = 0.05f,
            Liquid = 0.104f,
            Protein = 1.08f,
            Carbohydrate = 4.29f,
            Lipids = 0.24f,
            Vitamins = 0.018f,
            Minerals = 0.3444f,
            Calories = 21.6f,
            TimeToConsume = 60f,
            NeedConservation = true,
            StartConservationTime = BASE_RAW_FRUIT_SPOIL_TIME,
            Name = LanguageProvider.GetEntry(LanguageEntries.TOMATO_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.TOMATO_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 15,
            OfferAmount = new Vector2I(15000, 45000),
            OrderAmount = new Vector2I(5000, 15000),
            AcquisitionAmount = new Vector2I(10000, 30000),
            DiseaseChance = new Dictionary<StatsConstants.DiseaseEffects, float>()
            {
                { StatsConstants.DiseaseEffects.Dysentery, 0.025f }
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Stamina,
                    EffectType = FoodEffectType.Instant,
                    Ammount = 5
                },
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Health,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = 10,
                    TimeToEffect = 5
                }
            }
        };

        public static readonly FoodDefinition CEREAL_DEFINITION = new FoodDefinition()
        {
            Id = ItensConstants.CEREAL_ID,
            Solid = 0.83f,
            Liquid = 0.17f,
            Protein = 150.0f,
            Carbohydrate = 575.0f,
            Lipids = 75.0f,
            Vitamins = 0,
            Minerals = 28.5f,
            Calories = 3500.0f,
            TimeToConsume = 1200f,
            DefinitionType = FoodDefinition.FoodDefinitionType.Ingot,
            Name = LanguageProvider.GetEntry(LanguageEntries.CEREAL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.CEREAL_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 12,
            OfferAmount = new Vector2I(15000, 45000),
            OrderAmount = new Vector2I(5000, 15000),
            AcquisitionAmount = new Vector2I(10000, 30000)
        };

        public static readonly FoodDefinition WHEATSACK_DEFINITION = new FoodDefinition()
        {
            Id = ItensConstants.WHEATSACK_ID,
            Solid = 0.83f,
            Liquid = 0.17f,
            Protein = 137.4f,
            Carbohydrate = 752.0f,
            Lipids = 21.0f,
            Vitamins = 0,
            Minerals = 15.0f,
            Calories = 3746.0f,
            TimeToConsume = 1200f,
            DefinitionType = FoodDefinition.FoodDefinitionType.Ingot,
            Name = LanguageProvider.GetEntry(LanguageEntries.WHEATSACK_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.WHEATSACK_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 18,
            OfferAmount = new Vector2I(15000, 45000),
            OrderAmount = new Vector2I(5000, 15000),
            AcquisitionAmount = new Vector2I(10000, 30000)
        };

        public static readonly FoodDefinition COFFEESACK_DEFINITION = new FoodDefinition()
        {
            Id = ItensConstants.COFFEESACK_ID,
            Solid = 0.8f,
            Liquid = 0.2f,
            Protein = 1.0f,
            Carbohydrate = 0.0f,
            Lipids = 0.0f,
            Vitamins = 0.0f,
            Minerals = 0.5f,
            Calories = 0.0f,
            TimeToConsume = 1200f,
            DefinitionType = FoodDefinition.FoodDefinitionType.Ingot,
            Name = LanguageProvider.GetEntry(LanguageEntries.COFFEESACK_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.COFFEESACK_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 22,
            OfferAmount = new Vector2I(15000, 45000),
            OrderAmount = new Vector2I(5000, 15000),
            AcquisitionAmount = new Vector2I(10000, 30000),
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Temperature,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = 6000,
                    TimeToEffect = 600
                }
            }
        };

        public static readonly FoodDefinition ICE_DEFINITION = new FoodDefinition()
        {
            Id = ItensConstants.ICE_ID,
            Solid = 0.0f,
            Liquid = 1.0f,
            TimeToConsume = 600f,
            DefinitionType = FoodDefinition.FoodDefinitionType.Ore,
            IgnoreDefinition = true,
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Temperature,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = -3000,
                    TimeToEffect = 600
                }
            }
        };

        public static readonly FoodDefinition MILK_DEFINITION = new FoodDefinition()
        {
            Id = ItensConstants.MILK_ID,
            Solid = 0.05f,
            Liquid = 0.35f,
            Protein = 12.8f,
            Carbohydrate = 19.2f,
            Lipids = 15.6f,
            Vitamins = 0.0f,
            Minerals = 0.480f,
            Calories = 264.0f,
            TimeToConsume = 60f,
            NeedConservation = true,
            StartConservationTime = BASE_MILK_SPOIL_TIME,
            Name = LanguageProvider.GetEntry(LanguageEntries.MILK_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.MILK_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 50,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300),
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Temperature,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = -300,
                    TimeToEffect = 60
                },
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Stamina,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = 25,
                    TimeToEffect = 5
                },
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Health,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = 15,
                    TimeToEffect = 5
                }
            }
        };

        public static readonly FoodDefinition MEAT_DEFINITION = new FoodDefinition()
        {
            Id = ItensConstants.MEAT_ID,
            Solid = 0.025f,
            Liquid = 0.075f,
            Protein = 26.0f,
            Carbohydrate = 0.0f,
            Lipids = 15.0f,
            Vitamins = 0.001f,
            Minerals = 0.039f,
            Calories = 264.0f,
            TimeToConsume = 180f,
            NeedConservation = true,
            StartConservationTime = BASE_RAW_MEAT_SPOIL_TIME,
            Name = LanguageProvider.GetEntry(LanguageEntries.MEAT_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.MEAT_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 25,
            OfferAmount = new Vector2I(1500, 4500),
            OrderAmount = new Vector2I(500, 1500),
            AcquisitionAmount = new Vector2I(1000, 3000),
            DiseaseChance = new Dictionary<StatsConstants.DiseaseEffects, float>()
            {
                { StatsConstants.DiseaseEffects.Dysentery, 1.0f }
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Health,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = -25,
                    TimeToEffect = 5
                }
            }
        };

        public static readonly FoodDefinition ALIENMEAT_DEFINITION = new FoodDefinition()
        {
            Id = ItensConstants.ALIEN_MEAT_ID,
            Solid = 0.025f,
            Liquid = 0.075f,
            Protein = 28.0f,
            Carbohydrate = 0.0f,
            Lipids = 16.0f,
            Vitamins = 0.009f,
            Minerals = 0.049f,
            Calories = 292.0f,
            TimeToConsume = 180f,
            NeedConservation = true,
            StartConservationTime = BASE_RAW_MEAT_SPOIL_TIME,
            Name = LanguageProvider.GetEntry(LanguageEntries.ALIEN_MEAT_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ALIEN_MEAT_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 25,
            OfferAmount = new Vector2I(1500, 4500),
            OrderAmount = new Vector2I(500, 1500),
            AcquisitionAmount = new Vector2I(1000, 3000),
            DiseaseChance = new Dictionary<StatsConstants.DiseaseEffects, float>()
            {
                { StatsConstants.DiseaseEffects.Dysentery, 1.0f }
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Health,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = -25,
                    TimeToEffect = 5
                }
            }
        };

        public static readonly FoodDefinition CHICKENMEAT_DEFINITION = new FoodDefinition()
        {
            Id = ItensConstants.CHICKENMEAT_ID,
            Solid = 0.04f,
            Liquid = 0.06f,
            Protein = 27.0f,
            Carbohydrate = 0.0f,
            Lipids = 14.0f,
            Vitamins = 0.005f,
            Minerals = 0.038f,
            Calories = 219.0f,
            TimeToConsume = 180f,
            NeedConservation = true,
            StartConservationTime = BASE_RAW_MEAT_SPOIL_TIME,
            Name = LanguageProvider.GetEntry(LanguageEntries.CHICKENMEAT_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.CHICKENMEAT_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 35,
            OfferAmount = new Vector2I(1500, 4500),
            OrderAmount = new Vector2I(500, 1500),
            AcquisitionAmount = new Vector2I(1000, 3000),
            DiseaseChance = new Dictionary<StatsConstants.DiseaseEffects, float>()
            {
                { StatsConstants.DiseaseEffects.Dysentery, 1.0f }
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Health,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = -25,
                    TimeToEffect = 5
                }
            }
        };

        public static readonly FoodDefinition BACON_DEFINITION = new FoodDefinition()
        {
            Id = ItensConstants.BACON_ID,
            Solid = 0.03f,
            Liquid = 0.07f,
            Protein = 37.0f,
            Carbohydrate = 1.4f,
            Lipids = 42.0f,
            Vitamins = 0.012f,
            Minerals = 0.033f,
            Calories = 541.0f,
            TimeToConsume = 180f,
            NeedConservation = true,
            StartConservationTime = BASE_RAW_MEAT_SPOIL_TIME,
            Name = LanguageProvider.GetEntry(LanguageEntries.BACON_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.BACON_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 35,
            OfferAmount = new Vector2I(1500, 4500),
            OrderAmount = new Vector2I(500, 1500),
            AcquisitionAmount = new Vector2I(1000, 3000),
            DiseaseChance = new Dictionary<StatsConstants.DiseaseEffects, float>()
            {
                { StatsConstants.DiseaseEffects.Dysentery, 1.0f }
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Health,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = -25,
                    TimeToEffect = 5
                }
            }
        };

        public static readonly FoodDefinition NOBLE_MEAT_DEFINITION = new FoodDefinition()
        {
            Id = ItensConstants.NOBLE_MEAT_ID,
            Solid = 0.045f,
            Liquid = 0.055f,
            Protein = 52.0f,
            Carbohydrate = 0.0f,
            Lipids = 30.0f,
            Vitamins = 0.002f,
            Minerals = 0.078f,
            Calories = 528.0f,
            TimeToConsume = 240f,
            NeedConservation = true,
            StartConservationTime = BASE_RAW_MEAT_SPOIL_TIME,
            Name = LanguageProvider.GetEntry(LanguageEntries.NOBLE_MEAT_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.NOBLE_MEAT_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 45,
            OfferAmount = new Vector2I(1500, 4500),
            OrderAmount = new Vector2I(500, 1500),
            AcquisitionAmount = new Vector2I(1000, 3000),
            DiseaseChance = new Dictionary<StatsConstants.DiseaseEffects, float>()
            {
                { StatsConstants.DiseaseEffects.Dysentery, 1.0f }
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Health,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = -25,
                    TimeToEffect = 5
                }
            }
        };

        public static readonly FoodDefinition ALIEN_NOBLE_MEAT_DEFINITION = new FoodDefinition()
        {
            Id = ItensConstants.ALIEN_NOBLE_MEAT_ID,
            Solid = 0.045f,
            Liquid = 0.055f,
            Protein = 56.0f,
            Carbohydrate = 0.0f,
            Lipids = 32.0f,
            Vitamins = 0.018f,
            Minerals = 0.098f,
            Calories = 584.0f,
            TimeToConsume = 240f,
            NeedConservation = true,
            StartConservationTime = BASE_RAW_MEAT_SPOIL_TIME,
            Name = LanguageProvider.GetEntry(LanguageEntries.ALIEN_NOBLE_MEAT_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ALIEN_NOBLE_MEAT_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 45,
            OfferAmount = new Vector2I(1500, 4500),
            OrderAmount = new Vector2I(500, 1500),
            AcquisitionAmount = new Vector2I(1000, 3000),
            DiseaseChance = new Dictionary<StatsConstants.DiseaseEffects, float>()
            {
                { StatsConstants.DiseaseEffects.Dysentery, 1.0f }
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Health,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = -25,
                    TimeToEffect = 5
                }
            }
        };

        public static readonly FoodDefinition EGG_DEFINITION = new FoodDefinition()
        {
            Id = ItensConstants.EGG_ID,
            Solid = 0.010f,
            Liquid = 0.050f,
            Protein = 7.8f,
            Carbohydrate = 0.66f,
            Lipids = 6.6f,
            Vitamins = 0.001f,
            Minerals = 0.0366f,
            Calories = 93.0f,
            TimeToConsume = 120f,
            NeedConservation = true,
            StartConservationTime = BASE_EGG_SPOIL_TIME,
            Name = LanguageProvider.GetEntry(LanguageEntries.EGG_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.EGG_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 15,
            OfferAmount = new Vector2I(1500, 4500),
            OrderAmount = new Vector2I(500, 1500),
            AcquisitionAmount = new Vector2I(1000, 3000),
            DiseaseChance = new Dictionary<StatsConstants.DiseaseEffects, float>()
            {
                { StatsConstants.DiseaseEffects.Dysentery, 0.25f }
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Health,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = -25,
                    TimeToEffect = 5
                }
            }
        };

        public static readonly FoodDefinition ALIEN_EGG_DEFINITION = new FoodDefinition()
        {
            Id = ItensConstants.ALIEN_EGG_ID,
            Solid = 0.015f,
            Liquid = 0.085f,
            Protein = 13.0f,
            Carbohydrate = 1.1f,
            Lipids = 11.0f,
            Vitamins = 0.001f,
            Minerals = 0.061f,
            Calories = 155.0f,
            TimeToConsume = 160f,
            NeedConservation = true,
            StartConservationTime = BASE_EGG_SPOIL_TIME,
            Name = LanguageProvider.GetEntry(LanguageEntries.ALIEN_EGG_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ALIEN_EGG_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 15,
            OfferAmount = new Vector2I(1500, 4500),
            OrderAmount = new Vector2I(500, 1500),
            AcquisitionAmount = new Vector2I(1000, 3000),
            DiseaseChance = new Dictionary<StatsConstants.DiseaseEffects, float>()
            {
                { StatsConstants.DiseaseEffects.Dysentery, 0.35f }
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Health,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = -25,
                    TimeToEffect = 5
                }
            }
        };

        public static readonly FoodDefinition SHRIMPMEAT_DEFINITION = new FoodDefinition()
        {
            Id = ItensConstants.SHRIMPMEAT_ID,
            Solid = 0.002f,
            Liquid = 0.008f,
            Protein = 2.4f,
            Carbohydrate = 0.02f,
            Lipids = 0.03f,
            Vitamins = 0.0f,
            Minerals = 0.011f,
            Calories = 9.9f,
            TimeToConsume = 50f,
            NeedConservation = true,
            StartConservationTime = BASE_RAW_MEAT_SPOIL_TIME,
            Name = LanguageProvider.GetEntry(LanguageEntries.SHRIMPMEAT_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.SHRIMPMEAT_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 5,
            OfferAmount = new Vector2I(1500, 4500),
            OrderAmount = new Vector2I(500, 1500),
            AcquisitionAmount = new Vector2I(1000, 3000),
            DiseaseChance = new Dictionary<StatsConstants.DiseaseEffects, float>()
            {
                { StatsConstants.DiseaseEffects.Dysentery, 0.75f }
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Health,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = -25,
                    TimeToEffect = 5
                }
            }
        };

        public static readonly FoodDefinition FISHMEAT_DEFINITION = new FoodDefinition()
        {
            Id = ItensConstants.FISHMEAT_ID,
            Solid = 0.02f,
            Liquid = 0.08f,
            Protein = 22.0f,
            Carbohydrate = 0.0f,
            Lipids = 12.0f,
            Vitamins = 0.005f,
            Minerals = 0.045f,
            Calories = 206.0f,
            TimeToConsume = 100f,
            NeedConservation = true,
            StartConservationTime = BASE_RAW_MEAT_SPOIL_TIME,
            Name = LanguageProvider.GetEntry(LanguageEntries.FISHMEAT_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.FISHMEAT_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 15,
            OfferAmount = new Vector2I(1500, 4500),
            OrderAmount = new Vector2I(500, 1500),
            AcquisitionAmount = new Vector2I(1000, 3000),
            DiseaseChance = new Dictionary<StatsConstants.DiseaseEffects, float>()
            {
                { StatsConstants.DiseaseEffects.Dysentery, 0.75f }
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Health,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = -25,
                    TimeToEffect = 5
                }
            }
        };

        public static readonly FoodDefinition NOBLEFISHMEAT_DEFINITION = new FoodDefinition()
        {
            Id = ItensConstants.NOBLEFISHMEAT_ID,
            Solid = 0.02f,
            Liquid = 0.08f,
            Protein = 44.0f,
            Carbohydrate = 0.0f,
            Lipids = 24.0f,
            Vitamins = 0.010f,
            Minerals = 0.090f,
            Calories = 412.0f,
            TimeToConsume = 160f,
            NeedConservation = true,
            StartConservationTime = BASE_RAW_MEAT_SPOIL_TIME,
            Name = LanguageProvider.GetEntry(LanguageEntries.NOBLEFISHMEAT_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.NOBLEFISHMEAT_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 25,
            OfferAmount = new Vector2I(1500, 4500),
            OrderAmount = new Vector2I(500, 1500),
            AcquisitionAmount = new Vector2I(1000, 3000),
            DiseaseChance = new Dictionary<StatsConstants.DiseaseEffects, float>()
            {
                { StatsConstants.DiseaseEffects.Dysentery, 0.75f }
            },
            Effects = new List<ConsumibleEffect>()
            {
                new ConsumibleEffect()
                {
                    EffectTarget = FoodEffectTarget.Health,
                    EffectType = FoodEffectType.OverTime,
                    Ammount = -25,
                    TimeToEffect = 5
                }
            }
        };

        public static readonly FoodDefinition CONCENTRATEDFAT_DEFINITION = new FoodDefinition()
        {
            Id = ItensConstants.CONCENTRATEDFAT_ID,
            Solid = 1.0f,
            Liquid = 0.0f,
            Protein = 0.0f,
            Carbohydrate = 0.0f,
            Lipids = 1000.0f,
            Vitamins = 0.0f,
            Minerals = 0.0f,
            Calories = 0.0f,
            TimeToConsume = 600f,
            DefinitionType = FoodDefinition.FoodDefinitionType.Ore,
            Name = LanguageProvider.GetEntry(LanguageEntries.CONCENTRATEDFAT_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.CONCENTRATEDFAT_DESCRIPTION),
            SimpleDescription = true
        };

        public static readonly FoodDefinition CONCENTRATEDPROTEIN_DEFINITION = new FoodDefinition()
        {
            Id = ItensConstants.CONCENTRATEDPROTEIN_ID,
            Solid = 1.0f,
            Liquid = 0.0f,
            Protein = 1000.0f,
            Carbohydrate = 0.0f,
            Lipids = 0.0f,
            Vitamins = 0.0f,
            Minerals = 0.0f,
            Calories = 0.0f,
            TimeToConsume = 600f,
            DefinitionType = FoodDefinition.FoodDefinitionType.Ore,
            Name = LanguageProvider.GetEntry(LanguageEntries.CONCENTRATEDPROTEIN_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.CONCENTRATEDPROTEIN_DESCRIPTION),
            SimpleDescription = true
        };

        public static readonly FoodDefinition CONCENTRATEDVITAMIN_DEFINITION = new FoodDefinition()
        {
            Id = ItensConstants.CONCENTRATEDVITAMIN_ID,
            Solid = 1.0f,
            Liquid = 0.0f,
            Protein = 0.0f,
            Carbohydrate = 0.0f,
            Lipids = 0.0f,
            Vitamins = 10.0f,
            Minerals = 0.0f,
            Calories = 0.0f,
            TimeToConsume = 600f,
            DefinitionType = FoodDefinition.FoodDefinitionType.Ore,
            Name = LanguageProvider.GetEntry(LanguageEntries.CONCENTRATEDVITAMIN_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.CONCENTRATEDVITAMIN_DESCRIPTION),
            SimpleDescription = true
        };

        public static Dictionary<UniqueEntityId, FoodDefinition> FOOD_DEFINITIONS = new Dictionary<UniqueEntityId, FoodDefinition>()
        {
            { ItensConstants.APPLE_ID, APPLE_DEFINITION },
            { ItensConstants.BROCCOLI_ID, BROCCOLI_DEFINITION },
            { ItensConstants.BEETROOT_ID, BEETROOT_DEFINITION },
            { ItensConstants.CAROOT_ID, CAROOT_DEFINITION },
            { ItensConstants.SHIITAKE_ID, SHIITAKE_DEFINITION },
            { ItensConstants.CHAMPIGNONS_ID, CHAMPIGNONS_DEFINITION },
            { ItensConstants.AMANITAMUSCARIA_ID, AMANITAMUSCARIA_DEFINITION },
            { ItensConstants.TOMATO_ID, TOMATO_DEFINITION },
            { ItensConstants.CEREAL_ID, CEREAL_DEFINITION },
            { ItensConstants.WHEATSACK_ID, WHEATSACK_DEFINITION },
            { ItensConstants.COFFEESACK_ID, COFFEESACK_DEFINITION },
            { ItensConstants.ICE_ID, ICE_DEFINITION },
            { ItensConstants.MILK_ID, MILK_DEFINITION },
            { ItensConstants.MEAT_ID, MEAT_DEFINITION },
            { ItensConstants.ALIEN_MEAT_ID, ALIENMEAT_DEFINITION },
            { ItensConstants.CHICKENMEAT_ID, CHICKENMEAT_DEFINITION },
            { ItensConstants.BACON_ID, BACON_DEFINITION },
            { ItensConstants.NOBLE_MEAT_ID, NOBLE_MEAT_DEFINITION },
            { ItensConstants.ALIEN_NOBLE_MEAT_ID, ALIEN_NOBLE_MEAT_DEFINITION },
            { ItensConstants.EGG_ID, EGG_DEFINITION },
            { ItensConstants.ALIEN_EGG_ID, ALIEN_EGG_DEFINITION },
            { ItensConstants.SHRIMPMEAT_ID, SHRIMPMEAT_DEFINITION },
            { ItensConstants.FISHMEAT_ID, FISHMEAT_DEFINITION },
            { ItensConstants.NOBLEFISHMEAT_ID, NOBLEFISHMEAT_DEFINITION },
            { ItensConstants.CONCENTRATEDFAT_ID, CONCENTRATEDFAT_DEFINITION },
            { ItensConstants.CONCENTRATEDPROTEIN_ID, CONCENTRATEDPROTEIN_DEFINITION },
            { ItensConstants.CONCENTRATEDVITAMIN_ID, CONCENTRATEDVITAMIN_DEFINITION }
        };

        public static readonly FoodRecipeDefinition WATER_FLASK_SMALL_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.WATER_FLASK_SMALL_ID,
                Ammount = 1
            },
            RecipeName = "Water_Flask_Small_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Mixing,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.FLASK_SMALL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.ICE_ID,
                    Ammount = 0.1f
                }
            },
            ProductionTime = 1.28f,
            Name = LanguageProvider.GetEntry(LanguageEntries.WATER_FLASK_SMALL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.WATER_FLASK_SMALL_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 50,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300),
            CureDisease = new List<StatsConstants.DiseaseEffects>()
            {
                StatsConstants.DiseaseEffects.Hyperthermia
            }
        };

        public static readonly FoodRecipeDefinition WATER_FLASK_MEDIUM_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.WATER_FLASK_MEDIUM_ID,
                Ammount = 1
            },
            RecipeName = "Water_Flask_Medium_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Mixing,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.FLASK_MEDIUM_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.ICE_ID,
                    Ammount = 0.2f
                }
            },
            ProductionTime = 2.56f,
            Name = LanguageProvider.GetEntry(LanguageEntries.WATER_FLASK_MEDIUM_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.WATER_FLASK_MEDIUM_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 100,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300),
            CureDisease = new List<StatsConstants.DiseaseEffects>()
            {
                StatsConstants.DiseaseEffects.Hyperthermia
            }
        };

        public static readonly FoodRecipeDefinition WATER_FLASK_BIG_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.WATER_FLASK_BIG_ID,
                Ammount = 1
            },
            RecipeName = "Water_Flask_Big_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Mixing,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.FLASK_BIG_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.ICE_ID,
                    Ammount = 0.4f
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.WATER_FLASK_BIG_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.WATER_FLASK_BIG_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 150,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300),
            CureDisease = new List<StatsConstants.DiseaseEffects>()
            {
                StatsConstants.DiseaseEffects.Hyperthermia
            }
        };

        public static readonly FoodRecipeDefinition APPLE_JUICE_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.APPLE_JUICE_ID,
                Ammount = 1
            },
            RecipeName = "AppleJuice_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Processing,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.FLASK_BIG_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WATER_FLASK_MEDIUM_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.APPLE_ID,
                    Ammount = 4
                }
            },
            ProductionTime = 2.56f,
            Name = LanguageProvider.GetEntry(LanguageEntries.APPLE_JUICE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.APPLE_JUICE_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 200,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300),
            CureDisease = new List<StatsConstants.DiseaseEffects>()
            {
                StatsConstants.DiseaseEffects.Hyperthermia
            }
        };

        public static readonly FoodRecipeDefinition SODA_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.SODA_ID,
                Ammount = 4
            },
            RecipeName = "ClangCola",
            Preparation = FoodRecipeDefinition.RecipePreparationType.IndustrialProcessing,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RecipientConstants.ALUMINUMCAN_ID,
                    Ammount = 4
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.APPLE_JUICE_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.SODA_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.SODA_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 50,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300),
            CureDisease = new List<StatsConstants.DiseaseEffects>()
            {
                StatsConstants.DiseaseEffects.Hyperthermia
            }
        };

        public static readonly FoodRecipeDefinition COFFEE_CAN_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.COFFEE_CAN_ID,
                Ammount = 4
            },
            RecipeName = "CosmicCoffee",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RecipientConstants.ALUMINUMCAN_ID,
                    Ammount = 4
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WATER_FLASK_BIG_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.COFFEESACK_ID,
                    Ammount = 0.4f
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.COFFEE_CAN_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.COFFEE_CAN_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 50,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300),
            CureDisease = new List<StatsConstants.DiseaseEffects>()
            {
                StatsConstants.DiseaseEffects.Hypothermia
            }
        };

        public static readonly FoodRecipeDefinition DOUGH_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.DOUGH_ID,
                Ammount = 2
            },
            RecipeName = "Dough_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Mixing,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.MILK_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WHEATSACK_ID,
                    Ammount = 0.5f
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.EGG_ID,
                    Ammount = 4
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.DOUGH_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.DOUGH_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition ALIEN_DOUGH_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.ALIEN_DOUGH_ID,
                Ammount = 2
            },
            RecipeName = "AlienDough_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Mixing,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.MILK_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WHEATSACK_ID,
                    Ammount = 0.5f
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.ALIEN_EGG_ID,
                    Ammount = 4
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ALIEN_DOUGH_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ALIEN_DOUGH_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition CAKEDOUGH_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.CAKEDOUGH_ID,
                Ammount = 2
            },
            RecipeName = "CakeDough_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Mixing,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.MILK_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WHEATSACK_ID,
                    Ammount = 0.25f
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.EGG_ID,
                    Ammount = 2
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.CAKEDOUGH_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.CAKEDOUGH_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition ALIEN_CAKEDOUGH_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.ALIEN_CAKEDOUGH_ID,
                Ammount = 2
            },
            RecipeName = "AlienCakeDough_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Mixing,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.MILK_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WHEATSACK_ID,
                    Ammount = 0.25f
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.ALIEN_EGG_ID,
                    Ammount = 2
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ALIEN_CAKEDOUGH_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ALIEN_CAKEDOUGH_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition RAW_BROCCOLI_BOWL_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.RAW_BROCCOLI_BOWL_ID,
                Ammount = 1
            },
            RecipeName = "RawBroccoliBowl_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cutting,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RecipientConstants.BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.BROCCOLI_ID,
                    Ammount = 2
                }
            },
            ProductionTime = 2.56f,
            Name = LanguageProvider.GetEntry(LanguageEntries.RAW_BROCCOLI_BOWL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.RAW_BROCCOLI_BOWL_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition RAW_CARROT_BOWL_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.RAW_CARROT_BOWL_ID,
                Ammount = 1
            },
            RecipeName = "RawCarrotBowl_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cutting,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RecipientConstants.BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.CAROOT_ID,
                    Ammount = 5
                }
            },
            ProductionTime = 2.56f,
            Name = LanguageProvider.GetEntry(LanguageEntries.RAW_CARROT_BOWL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.RAW_CARROT_BOWL_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition RAW_BEETROOT_BOWL_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.RAW_BEETROOT_BOWL_ID,
                Ammount = 1
            },
            RecipeName = "RawBeetrootBowl_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cutting,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RecipientConstants.BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.BEETROOT_ID,
                    Ammount = 5
                }
            },
            ProductionTime = 2.56f,
            Name = LanguageProvider.GetEntry(LanguageEntries.RAW_BEETROOT_BOWL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.RAW_BEETROOT_BOWL_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition RAW_MEAT_BOWL_RECIPE_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.RAW_MEAT_BOWL_ID,
                Ammount = 1
            },
            RecipeName = "RawMeatBowl_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cutting,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RecipientConstants.BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.MEAT_ID,
                    Ammount = 2
                }
            },
            ProductionTime = 2.56f,
            Name = LanguageProvider.GetEntry(LanguageEntries.RAW_MEAT_BOWL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.RAW_MEAT_BOWL_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition RAW_ALIEN_MEAT_BOWL_RECIPE_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.RAW_ALIEN_MEAT_BOWL_ID,
                Ammount = 1
            },
            RecipeName = "RawAlienMeatBowl_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cutting,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RecipientConstants.BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.ALIEN_MEAT_ID,
                    Ammount = 2
                }
            },
            ProductionTime = 2.56f,
            Name = LanguageProvider.GetEntry(LanguageEntries.RAW_ALIEN_MEAT_BOWL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.RAW_ALIEN_MEAT_BOWL_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition RAW_NOBLE_MEAT_BOWL_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.RAW_NOBLE_MEAT_BOWL_ID,
                Ammount = 1
            },
            RecipeName = "RawNobleMeatBowl_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cutting,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RecipientConstants.BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.NOBLE_MEAT_ID,
                    Ammount = 2
                }
            },
            ProductionTime = 2.56f,
            Name = LanguageProvider.GetEntry(LanguageEntries.RAW_NOBLE_MEAT_BOWL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.RAW_NOBLE_MEAT_BOWL_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition RAW_ALIEN_NOBLE_MEAT_BOWL_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.RAW_ALIEN_NOBLE_MEAT_BOWL_ID,
                Ammount = 1
            },
            RecipeName = "RawAlienNobleMeatBowl_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cutting,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RecipientConstants.BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.ALIEN_NOBLE_MEAT_ID,
                    Ammount = 2
                }
            },
            ProductionTime = 2.56f,
            Name = LanguageProvider.GetEntry(LanguageEntries.RAW_ALIEN_NOBLE_MEAT_BOWL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.RAW_ALIEN_NOBLE_MEAT_BOWL_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition RAWFISHMEATBOWL_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.RAWFISHMEATBOWL_ID,
                Ammount = 1
            },
            RecipeName = "RawFishMeatBowl_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cutting,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RecipientConstants.BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.FISHMEAT_ID,
                    Ammount = 2
                }
            },
            ProductionTime = 2.56f,
            Name = LanguageProvider.GetEntry(LanguageEntries.RAWFISHMEATBOWL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.RAWFISHMEATBOWL_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition RAWNOBLEFISHMEATBOWL_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.RAWNOBLEFISHMEATBOWL_ID,
                Ammount = 1
            },
            RecipeName = "RawNobleFishMeatBowl_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cutting,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RecipientConstants.BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.NOBLEFISHMEAT_ID,
                    Ammount = 2
                }
            },
            ProductionTime = 2.56f,
            Name = LanguageProvider.GetEntry(LanguageEntries.RAWNOBLEFISHMEATBOWL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.RAWNOBLEFISHMEATBOWL_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition RAW_SAUSAGE_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.RAW_SAUSAGE_ID,
                Ammount = 1
            },
            RecipeName = "RawSausage_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Mixing,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.RAW_MEAT_BOWL_ID,
                    Ammount = 2
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.RAW_SAUSAGE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.RAW_SAUSAGE_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 175,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300)
        };

        public static readonly FoodRecipeDefinition RAW_ALIEN_SAUSAGE_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.RAW_ALIEN_SAUSAGE_ID,
                Ammount = 1
            },
            RecipeName = "RawAlienSausage_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Mixing,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.RAW_ALIEN_MEAT_BOWL_ID,
                    Ammount = 2
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.RAW_ALIEN_SAUSAGE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.RAW_ALIEN_SAUSAGE_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 175,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300)
        };

        public static readonly FoodRecipeDefinition ROAST_CHAMPIGNON_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.ROAST_CHAMPIGNON_ID,
                Ammount = 1
            },
            RecipeName = "RoastChampignonMushrooms_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Baking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.CHAMPIGNONS_ID,
                    Ammount = 10
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ROAST_CHAMPIGNON_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ROAST_CHAMPIGNON_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition ROAST_SHIITAKE_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.ROAST_SHIITAKE_ID,
                Ammount = 1
            },
            RecipeName = "RoastShiitakeMushrooms_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Baking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.SHIITAKE_ID,
                    Ammount = 10
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ROAST_SHIITAKE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ROAST_SHIITAKE_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition FRIED_EGG_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.FRIED_EGG_ID,
                Ammount = 1
            },
            RecipeName = "FriedEgg_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Frying,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.EGG_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 1.28f,
            Name = LanguageProvider.GetEntry(LanguageEntries.FRIED_EGG_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.FRIED_EGG_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition FRIED_ALIEN_EGG_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.FRIED_ALIEN_EGG_ID,
                Ammount = 1
            },
            RecipeName = "FriedAlienEgg_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Frying,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.ALIEN_EGG_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 1.28f,
            Name = LanguageProvider.GetEntry(LanguageEntries.FRIED_ALIEN_EGG_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.FRIED_ALIEN_EGG_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition ROASTEDBACON_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.ROASTEDBACON_ID,
                Ammount = 1
            },
            RecipeName = "RoastedBacon_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Baking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.BACON_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ROASTEDBACON_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ROASTEDBACON_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition ROASTEDCHICKEN_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.ROASTEDCHICKEN_ID,
                Ammount = 1
            },
            RecipeName = "RoastedChicken_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Baking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.CHICKENMEAT_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ROASTEDCHICKEN_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ROASTEDCHICKEN_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition ROASTED_SAUSAGE_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.ROASTED_SAUSAGE_ID,
                Ammount = 1
            },
            RecipeName = "RoastedSausage_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Baking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.RAW_SAUSAGE_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ROASTED_SAUSAGE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ROASTED_SAUSAGE_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition ROASTED_ALIEN_SAUSAGE_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.ROASTED_ALIEN_SAUSAGE_ID,
                Ammount = 1
            },
            RecipeName = "RoastedAlienSausage_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Baking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.RAW_ALIEN_SAUSAGE_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ROASTED_ALIEN_SAUSAGE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ROASTED_ALIEN_SAUSAGE_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition ROASTED_MEAT_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.ROASTED_MEAT_ID,
                Ammount = 1
            },
            RecipeName = "RoastedMeat_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Baking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.MEAT_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ROASTED_MEAT_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ROASTED_MEAT_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition ROASTED_ALIEN_MEAT_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.ROASTED_ALIEN_MEAT_ID,
                Ammount = 1
            },
            RecipeName = "RoastedAlienMeat_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Baking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.ALIEN_MEAT_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ROASTED_ALIEN_MEAT_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ROASTED_ALIEN_MEAT_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition CEREALBAR_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.CEREALBAR_ID,
                Ammount = 1
            },
            RecipeName = "CerealBar_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.IndustrialProcessing,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.CEREAL_ID,
                    Ammount = 0.1f
                }
            },
            ProductionTime = 2.56f,
            Name = LanguageProvider.GetEntry(LanguageEntries.CEREALBAR_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.CEREALBAR_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 8,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300)
        };

        public static readonly FoodRecipeDefinition WATERBREAD_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.WATERBREAD_ID,
                Ammount = 1
            },
            RecipeName = "WaterBread_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Baking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WATER_FLASK_SMALL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WHEATSACK_ID,
                    Ammount = 0.25f
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.WATERBREAD_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.WATERBREAD_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 10,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300)
        };

        public static readonly FoodRecipeDefinition BREAD_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.BREAD_ID,
                Ammount = 2
            },
            RecipeName = "Bread_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Baking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.DOUGH_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.BREAD_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.BREAD_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 15,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300)
        };

        public static readonly FoodRecipeDefinition ALIEN_BREAD_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.ALIEN_BREAD_ID,
                Ammount = 2
            },
            RecipeName = "AlienBread_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Baking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.ALIEN_DOUGH_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ALIEN_BREAD_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ALIEN_BREAD_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 15,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300)
        };

        public static readonly FoodRecipeDefinition PASTA_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.PASTA_ID,
                Ammount = 1
            },
            RecipeName = "Pasta_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Mixing,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.DOUGH_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WHEATSACK_ID,
                    Ammount = 0.1f
                }
            },
            ProductionTime = 2.56f,
            Name = LanguageProvider.GetEntry(LanguageEntries.PASTA_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.PASTA_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition ALIEN_PASTA_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.ALIEN_PASTA_ID,
                Ammount = 1
            },
            RecipeName = "AlienPasta_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Mixing,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.ALIEN_DOUGH_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WHEATSACK_ID,
                    Ammount = 0.1f
                }
            },
            ProductionTime = 2.56f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ALIEN_PASTA_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ALIEN_PASTA_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition VEGETABLEPASTA_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.VEGETABLEPASTA_ID,
                Ammount = 2
            },
            RecipeName = "VegetablePasta_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.PASTA_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.TOMATO_ID,
                    Ammount = 2
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.RAW_BROCCOLI_BOWL_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.VEGETABLEPASTA_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.VEGETABLEPASTA_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition VEGETABLEALIENPASTA_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.VEGETABLEALIENPASTA_ID,
                Ammount = 2
            },
            RecipeName = "VegetableAlienPasta_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.ALIEN_PASTA_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.TOMATO_ID,
                    Ammount = 2
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.RAW_BROCCOLI_BOWL_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.VEGETABLEALIENPASTA_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.VEGETABLEALIENPASTA_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition MEATPASTA_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.MEATPASTA_ID,
                Ammount = 2
            },
            RecipeName = "MeatPasta_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.PASTA_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.TOMATO_ID,
                    Ammount = 2
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.RAW_MEAT_BOWL_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.MEATPASTA_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.MEATPASTA_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition ALIENMEATPASTA_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.ALIENMEATPASTA_ID,
                Ammount = 2
            },
            RecipeName = "AlienMeatPasta_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.ALIEN_PASTA_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.TOMATO_ID,
                    Ammount = 2
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.RAW_ALIEN_MEAT_BOWL_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ALIENMEATPASTA_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ALIENMEATPASTA_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition CHEESE_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.CHEESE_ID,
                Ammount = 1
            },
            RecipeName = "Cheese_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Drying,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.MILK_ID,
                    Ammount = 2
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.CHEESE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.CHEESE_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 125,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300)
        };

        public static readonly FoodRecipeDefinition SALAD_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.SALAD_ID,
                Ammount = 3
            },
            RecipeName = "Salad_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Processing,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.TOMATO_ID,
                    Ammount = 3
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.RAW_BROCCOLI_BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.RAW_CARROT_BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.RAW_BEETROOT_BOWL_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.SALAD_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.SALAD_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition VEGETABLE_SOUP_BOWL_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.VEGETABLE_SOUP_BOWL_ID,
                Ammount = 2
            },
            RecipeName = "VegetableSoupBowl_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WATER_FLASK_MEDIUM_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.RAW_CARROT_BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.RAW_BEETROOT_BOWL_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.VEGETABLE_SOUP_BOWL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.VEGETABLE_SOUP_BOWL_DESCRIPTION),
            CureDisease = new List<StatsConstants.DiseaseEffects>()
            {
                StatsConstants.DiseaseEffects.Hypothermia
            }
        };

        public static readonly FoodRecipeDefinition STEW_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.STEW_ID,
                Ammount = 2
            },
            RecipeName = "StewBowl_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WATER_FLASK_MEDIUM_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.RAW_MEAT_BOWL_ID,
                    Ammount = 2
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.STEW_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.STEW_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition ALIEN_STEW_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.ALIEN_STEW_ID,
                Ammount = 2
            },
            RecipeName = "AlienStewBowl_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WATER_FLASK_MEDIUM_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.RAW_ALIEN_MEAT_BOWL_ID,
                    Ammount = 2
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ALIEN_STEW_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ALIEN_STEW_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition MEAT_VEGETABLES_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.MEAT_VEGETABLES_ID,
                Ammount = 2
            },
            RecipeName = "MeatVegetablesBowl_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WATER_FLASK_MEDIUM_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.NOBLE_MEAT_ID,
                    Ammount = 2
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.RAW_CARROT_BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.RAW_BEETROOT_BOWL_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.MEAT_VEGETABLES_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.MEAT_VEGETABLES_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition ALIEN_MEAT_VEGETABLES_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.ALIEN_MEAT_VEGETABLES_ID,
                Ammount = 2
            },
            RecipeName = "AlienMeatVegetablesBowl_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WATER_FLASK_MEDIUM_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.ALIEN_NOBLE_MEAT_ID,
                    Ammount = 2
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.RAW_CARROT_BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.RAW_BEETROOT_BOWL_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ALIEN_MEAT_VEGETABLES_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ALIEN_MEAT_VEGETABLES_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition MEATLOAF_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.MEATLOAF_ID,
                Ammount = 2
            },
            RecipeName = "MeatloafBowl_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WATER_FLASK_MEDIUM_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.RAW_MEAT_BOWL_ID,
                    Ammount = 2
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.RAW_NOBLE_MEAT_BOWL_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.MEATLOAF_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.MEATLOAF_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition ALIENMEATLOAF_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.ALIENMEATLOAF_ID,
                Ammount = 2
            },
            RecipeName = "AlienMeatloafBowl_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WATER_FLASK_MEDIUM_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.RAW_ALIEN_MEAT_BOWL_ID,
                    Ammount = 2
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.RAW_ALIEN_NOBLE_MEAT_BOWL_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ALIENMEATLOAF_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ALIENMEATLOAF_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition MEAT_SOUP_BOWL_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.MEAT_SOUP_BOWL_ID,
                Ammount = 2
            },
            RecipeName = "MeatSoupBowl_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WATER_FLASK_MEDIUM_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.RAW_CARROT_BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.RAW_BEETROOT_BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.RAW_NOBLE_MEAT_BOWL_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.MEAT_SOUP_BOWL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.MEAT_SOUP_BOWL_DESCRIPTION),
            CureDisease = new List<StatsConstants.DiseaseEffects>()
            {
                StatsConstants.DiseaseEffects.Hypothermia
            }
        };

        public static readonly FoodRecipeDefinition ALIEN_MEAT_SOUP_BOWL_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.ALIEN_MEAT_SOUP_BOWL_ID,
                Ammount = 2
            },
            RecipeName = "AlienMeatSoupBowl_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WATER_FLASK_MEDIUM_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.RAW_CARROT_BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.RAW_BEETROOT_BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.RAW_ALIEN_NOBLE_MEAT_BOWL_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ALIEN_MEAT_SOUP_BOWL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ALIEN_MEAT_SOUP_BOWL_DESCRIPTION),
            CureDisease = new List<StatsConstants.DiseaseEffects>()
            {
                StatsConstants.DiseaseEffects.Hypothermia
            }
        };

        public static readonly FoodRecipeDefinition MUSHROOMPATE_BOWL_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.MUSHROOMPATE_BOWL_ID,
                Ammount = 2
            },
            RecipeName = "MushroomPate_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WATER_FLASK_MEDIUM_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RecipientConstants.BOWL_ID,
                    Ammount = 2
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.CHAMPIGNONS_ID,
                    Ammount = 10
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.SHIITAKE_ID,
                    Ammount = 10
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.MUSHROOMPATE_BOWL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.MUSHROOMPATE_BOWL_DESCRIPTION),
            CureDisease = new List<StatsConstants.DiseaseEffects>()
            {
                StatsConstants.DiseaseEffects.Hypothermia
            }
        };

        public static readonly FoodRecipeDefinition MEAT_MUSHROOMS_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.MEAT_MUSHROOMS_ID,
                Ammount = 2
            },
            RecipeName = "MeatMushroom_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WATER_FLASK_MEDIUM_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.NOBLE_MEAT_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.CHAMPIGNONS_ID,
                    Ammount = 10
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.SHIITAKE_ID,
                    Ammount = 10
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RecipientConstants.BOWL_ID,
                    Ammount = 2
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.MEAT_MUSHROOMS_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.MEAT_MUSHROOMS_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition ALIEN_MEAT_MUSHROOMS_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.ALIEN_MEAT_MUSHROOMS_ID,
                Ammount = 2
            },
            RecipeName = "AlienMeatMushroom_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WATER_FLASK_MEDIUM_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.ALIEN_NOBLE_MEAT_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.CHAMPIGNONS_ID,
                    Ammount = 10
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.SHIITAKE_ID,
                    Ammount = 10
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RecipientConstants.BOWL_ID,
                    Ammount = 2
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ALIEN_MEAT_MUSHROOMS_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ALIEN_MEAT_MUSHROOMS_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition SANDWICH_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.SANDWICH_ID,
                Ammount = 3
            },
            RecipeName = "Sandwich_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Processing,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.TOMATO_ID,
                    Ammount = 3
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.BREAD_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.CHEESE_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.ROASTED_SAUSAGE_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.SANDWICH_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.SANDWICH_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition ALIEN_SANDWICH_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.ALIEN_SANDWICH_ID,
                Ammount = 3
            },
            RecipeName = "AlienSandwich_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Processing,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.TOMATO_ID,
                    Ammount = 3
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.ALIEN_BREAD_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.CHEESE_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.ROASTED_ALIEN_SAUSAGE_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ALIEN_SANDWICH_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ALIEN_SANDWICH_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition ROASTEDSHRIMP_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.ROASTEDSHRIMP_ID,
                Ammount = 1
            },
            RecipeName = "RoastedShrimp_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Frying,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.SHRIMPMEAT_ID,
                    Ammount = 10
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ROASTEDSHRIMP_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ROASTEDSHRIMP_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition ROASTEDFISH_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.ROASTEDFISH_ID,
                Ammount = 1
            },
            RecipeName = "RoastedFish_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Baking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.FISHMEAT_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ROASTEDFISH_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ROASTEDFISH_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition ROASTEDNOBLEFISH_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.ROASTEDNOBLEFISH_ID,
                Ammount = 1
            },
            RecipeName = "RoastedNobleFish_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Baking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.NOBLEFISHMEAT_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ROASTEDNOBLEFISH_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ROASTEDNOBLEFISH_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition FISHMUSHROOM_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.FISHMUSHROOM_ID,
                Ammount = 2
            },
            RecipeName = "FishMushroom_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WATER_FLASK_MEDIUM_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.NOBLEFISHMEAT_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.CHAMPIGNONS_ID,
                    Ammount = 10
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.SHIITAKE_ID,
                    Ammount = 10
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RecipientConstants.BOWL_ID,
                    Ammount = 2
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.FISHMUSHROOM_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.FISHMUSHROOM_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition FISHSOUPBOWL_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.FISHSOUPBOWL_ID,
                Ammount = 2
            },
            RecipeName = "FishSoupBowl_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WATER_FLASK_MEDIUM_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.RAW_CARROT_BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.RAW_BEETROOT_BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.RAWNOBLEFISHMEATBOWL_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.FISHSOUPBOWL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.FISHSOUPBOWL_DESCRIPTION),
            CureDisease = new List<StatsConstants.DiseaseEffects>()
            {
                StatsConstants.DiseaseEffects.Hypothermia
            }
        };

        public static readonly FoodRecipeDefinition SHRIMPSOUPBOWL_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.SHRIMPSOUPBOWL_ID,
                Ammount = 2
            },
            RecipeName = "ShrimpSoupBowl_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WATER_FLASK_MEDIUM_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.RAW_CARROT_BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.RAW_BEETROOT_BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.SHRIMPMEAT_ID,
                    Ammount = 5
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.RAWFISHMEATBOWL_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.SHRIMPSOUPBOWL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.SHRIMPSOUPBOWL_DESCRIPTION),
            CureDisease = new List<StatsConstants.DiseaseEffects>()
            {
                StatsConstants.DiseaseEffects.Hypothermia
            }
        };

        public static readonly FoodRecipeDefinition APPLEPIE_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.APPLEPIE_ID,
                Ammount = 2
            },
            RecipeName = "ApplePie_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Baking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.CAKEDOUGH_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.APPLE_ID,
                    Ammount = 12f
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.APPLEPIE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.APPLEPIE_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 275,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300)
        };

        public static readonly FoodRecipeDefinition ALIEN_APPLEPIE_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.ALIEN_APPLEPIE_ID,
                Ammount = 2
            },
            RecipeName = "AlienApplePie_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Baking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.ALIEN_CAKEDOUGH_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.APPLE_ID,
                    Ammount = 12f
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ALIEN_APPLEPIE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ALIEN_APPLEPIE_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 275,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300)
        };

        public static readonly FoodRecipeDefinition CHICKENPIE_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.CHICKENPIE_ID,
                Ammount = 2
            },
            RecipeName = "ChickenPie_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Baking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.CAKEDOUGH_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.CHICKENMEAT_ID,
                    Ammount = 2
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.BACON_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.CHICKENPIE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.CHICKENPIE_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 250,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300)
        };

        public static readonly FoodRecipeDefinition ALIEN_CHICKENPIE_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.ALIEN_CHICKENPIE_ID,
                Ammount = 2
            },
            RecipeName = "AlienChickenPie_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Baking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.ALIEN_CAKEDOUGH_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.CHICKENMEAT_ID,
                    Ammount = 2
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.BACON_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.ALIEN_CHICKENPIE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ALIEN_CHICKENPIE_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 250,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300)
        };

        public static readonly FoodRecipeDefinition FATPORRIDGE_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.FATPORRIDGE_ID,
                Ammount = 1
            },
            RecipeName = "FatPorridge_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.Cooking,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.WATER_FLASK_SMALL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = RecipientConstants.BOWL_ID,
                    Ammount = 1
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.CONCENTRATEDFAT_ID,
                    Ammount = 0.15f
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.FATPORRIDGE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.FATPORRIDGE_DESCRIPTION)
        };

        public static readonly FoodRecipeDefinition PROTEINBAR_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.PROTEINBAR_ID,
                Ammount = 1
            },
            RecipeName = "ProteinBar_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.IndustrialProcessing,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.CONCENTRATEDPROTEIN_ID,
                    Ammount = 0.075f
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.CEREAL_ID,
                    Ammount = 0.025f
                }
            },
            ProductionTime = 5.12f,
            Name = LanguageProvider.GetEntry(LanguageEntries.PROTEINBAR_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.PROTEINBAR_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 45,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300)
        };

        public static readonly FoodRecipeDefinition VITAMINPILLS_DEFINITION = new FoodRecipeDefinition()
        {
            Product = new FullRecipeDefinition.RecipeItem()
            {
                Id = ItensConstants.VITAMINPILLS_ID,
                Ammount = 1
            },
            RecipeName = "VitaminPills_Construction",
            Preparation = FoodRecipeDefinition.RecipePreparationType.IndustrialProcessing,
            Ingredients = new FullRecipeDefinition.RecipeItem[]
            {
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.CONCENTRATEDVITAMIN_ID,
                    Ammount = 0.1f
                },
                new FullRecipeDefinition.RecipeItem()
                {
                    Id = ItensConstants.POLIETILENOGLICOL_ID,
                    Ammount = 1
                }
            },
            ProductionTime = 10.24f,
            Name = LanguageProvider.GetEntry(LanguageEntries.VITAMINPILLS_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.VITAMINPILLS_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 475,
            OfferAmount = new Vector2I(150, 450),
            OrderAmount = new Vector2I(50, 150),
            AcquisitionAmount = new Vector2I(100, 300)
        };

        public static readonly Dictionary<UniqueEntityId, FoodRecipeDefinition> FOOD_RECIPES = new Dictionary<UniqueEntityId, FoodRecipeDefinition>()
        {
            { ItensConstants.WATER_FLASK_SMALL_ID, WATER_FLASK_SMALL_DEFINITION },
            { ItensConstants.WATER_FLASK_MEDIUM_ID, WATER_FLASK_MEDIUM_DEFINITION },
            { ItensConstants.WATER_FLASK_BIG_ID, WATER_FLASK_BIG_DEFINITION },
            { ItensConstants.APPLE_JUICE_ID, APPLE_JUICE_DEFINITION },
            { ItensConstants.SODA_ID, SODA_DEFINITION },
            { ItensConstants.COFFEE_CAN_ID, COFFEE_CAN_DEFINITION },
            { ItensConstants.DOUGH_ID, DOUGH_DEFINITION },
            { ItensConstants.ALIEN_DOUGH_ID, ALIEN_DOUGH_DEFINITION },
            { ItensConstants.CAKEDOUGH_ID, CAKEDOUGH_DEFINITION },
            { ItensConstants.ALIEN_CAKEDOUGH_ID, ALIEN_CAKEDOUGH_DEFINITION },
            { ItensConstants.RAW_BROCCOLI_BOWL_ID, RAW_BROCCOLI_BOWL_DEFINITION },
            { ItensConstants.RAW_CARROT_BOWL_ID, RAW_CARROT_BOWL_DEFINITION },
            { ItensConstants.RAW_BEETROOT_BOWL_ID, RAW_BEETROOT_BOWL_DEFINITION },
            { ItensConstants.RAW_MEAT_BOWL_ID, RAW_MEAT_BOWL_RECIPE_DEFINITION },
            { ItensConstants.RAW_ALIEN_MEAT_BOWL_ID, RAW_ALIEN_MEAT_BOWL_RECIPE_DEFINITION },
            { ItensConstants.RAW_NOBLE_MEAT_BOWL_ID, RAW_NOBLE_MEAT_BOWL_DEFINITION },
            { ItensConstants.RAW_ALIEN_NOBLE_MEAT_BOWL_ID, RAW_ALIEN_NOBLE_MEAT_BOWL_DEFINITION },
            { ItensConstants.RAWFISHMEATBOWL_ID, RAWFISHMEATBOWL_DEFINITION },
            { ItensConstants.RAWNOBLEFISHMEATBOWL_ID, RAWNOBLEFISHMEATBOWL_DEFINITION },
            { ItensConstants.RAW_SAUSAGE_ID, RAW_SAUSAGE_DEFINITION },
            { ItensConstants.RAW_ALIEN_SAUSAGE_ID, RAW_ALIEN_SAUSAGE_DEFINITION },
            { ItensConstants.ROAST_CHAMPIGNON_ID, ROAST_CHAMPIGNON_DEFINITION },
            { ItensConstants.ROAST_SHIITAKE_ID, ROAST_SHIITAKE_DEFINITION },
            { ItensConstants.FRIED_EGG_ID, FRIED_EGG_DEFINITION },
            { ItensConstants.FRIED_ALIEN_EGG_ID, FRIED_ALIEN_EGG_DEFINITION },
            { ItensConstants.ROASTEDBACON_ID, ROASTEDBACON_DEFINITION },
            { ItensConstants.ROASTEDCHICKEN_ID, ROASTEDCHICKEN_DEFINITION },
            { ItensConstants.ROASTED_SAUSAGE_ID, ROASTED_SAUSAGE_DEFINITION },
            { ItensConstants.ROASTED_ALIEN_SAUSAGE_ID, ROASTED_ALIEN_SAUSAGE_DEFINITION },
            { ItensConstants.ROASTED_MEAT_ID, ROASTED_MEAT_DEFINITION },
            { ItensConstants.ROASTED_ALIEN_MEAT_ID, ROASTED_ALIEN_MEAT_DEFINITION },
            { ItensConstants.CEREALBAR_ID, CEREALBAR_DEFINITION },
            { ItensConstants.WATERBREAD_ID, WATERBREAD_DEFINITION },
            { ItensConstants.BREAD_ID, BREAD_DEFINITION },
            { ItensConstants.ALIEN_BREAD_ID, ALIEN_BREAD_DEFINITION },
            { ItensConstants.PASTA_ID, PASTA_DEFINITION },
            { ItensConstants.ALIEN_PASTA_ID, ALIEN_PASTA_DEFINITION },
            { ItensConstants.VEGETABLEPASTA_ID, VEGETABLEPASTA_DEFINITION },
            { ItensConstants.VEGETABLEALIENPASTA_ID, VEGETABLEALIENPASTA_DEFINITION },
            { ItensConstants.MEATPASTA_ID, MEATPASTA_DEFINITION },
            { ItensConstants.ALIENMEATPASTA_ID, ALIENMEATPASTA_DEFINITION },
            { ItensConstants.CHEESE_ID, CHEESE_DEFINITION },
            { ItensConstants.SALAD_ID, SALAD_DEFINITION },
            { ItensConstants.VEGETABLE_SOUP_BOWL_ID, VEGETABLE_SOUP_BOWL_DEFINITION },
            { ItensConstants.STEW_ID, STEW_DEFINITION },
            { ItensConstants.ALIEN_STEW_ID, ALIEN_STEW_DEFINITION },
            { ItensConstants.MEAT_VEGETABLES_ID, MEAT_VEGETABLES_DEFINITION },
            { ItensConstants.ALIEN_MEAT_VEGETABLES_ID, ALIEN_MEAT_VEGETABLES_DEFINITION },
            { ItensConstants.MEATLOAF_ID, MEATLOAF_DEFINITION },
            { ItensConstants.ALIENMEATLOAF_ID, ALIENMEATLOAF_DEFINITION },
            { ItensConstants.MEAT_SOUP_BOWL_ID, MEAT_SOUP_BOWL_DEFINITION },
            { ItensConstants.ALIEN_MEAT_SOUP_BOWL_ID, ALIEN_MEAT_SOUP_BOWL_DEFINITION },
            { ItensConstants.MUSHROOMPATE_BOWL_ID, MUSHROOMPATE_BOWL_DEFINITION },
            { ItensConstants.MEAT_MUSHROOMS_ID, MEAT_MUSHROOMS_DEFINITION },
            { ItensConstants.ALIEN_MEAT_MUSHROOMS_ID, ALIEN_MEAT_MUSHROOMS_DEFINITION },
            { ItensConstants.SANDWICH_ID, SANDWICH_DEFINITION },
            { ItensConstants.ALIEN_SANDWICH_ID, ALIEN_SANDWICH_DEFINITION },
            { ItensConstants.ROASTEDSHRIMP_ID, ROASTEDSHRIMP_DEFINITION },
            { ItensConstants.ROASTEDFISH_ID, ROASTEDFISH_DEFINITION },
            { ItensConstants.ROASTEDNOBLEFISH_ID, ROASTEDNOBLEFISH_DEFINITION },
            { ItensConstants.FISHMUSHROOM_ID, FISHMUSHROOM_DEFINITION },
            { ItensConstants.FISHSOUPBOWL_ID, FISHSOUPBOWL_DEFINITION },
            { ItensConstants.SHRIMPSOUPBOWL_ID, SHRIMPSOUPBOWL_DEFINITION },
            { ItensConstants.APPLEPIE_ID, APPLEPIE_DEFINITION },
            { ItensConstants.ALIEN_APPLEPIE_ID, ALIEN_APPLEPIE_DEFINITION },
            { ItensConstants.CHICKENPIE_ID, CHICKENPIE_DEFINITION },
            { ItensConstants.ALIEN_CHICKENPIE_ID, ALIEN_CHICKENPIE_DEFINITION },
            { ItensConstants.FATPORRIDGE_ID, FATPORRIDGE_DEFINITION },
            { ItensConstants.PROTEINBAR_ID, PROTEINBAR_DEFINITION },
            { ItensConstants.VITAMINPILLS_ID, VITAMINPILLS_DEFINITION }
        };

        public static readonly List<UniqueEntityId> FOOD_RECIPIENTS = new List<UniqueEntityId>()
        {
            { ItensConstants.FLASK_BIG_ID },
            { ItensConstants.FLASK_SMALL_ID },
            { ItensConstants.FLASK_MEDIUM_ID },
            { RecipientConstants.ALUMINUMCAN_ID },
            { RecipientConstants.BOWL_ID }
        };

        public static readonly List<UniqueEntityId> MEDICAL_INGREDIENTS = new List<UniqueEntityId>()
        {
            { ItensConstants.POLIETILENOGLICOL_ID }
        };

        public static readonly FoodConcentratedExtractDefinition TOMATO_TO_CONCENTRATED_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = ItensConstants.TOMATO_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.TOMATOTOCONCENTRATED_CONSTRUCTION_NAME),
            Description = "",            
            RecipeName = "TomatoToConcentrated_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition APPLE_TO_CONCENTRATED_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = ItensConstants.APPLE_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.APPLETOCONCENTRATED_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "AppleToConcentrated_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition ALIENEGG_TO_CONCENTRATED_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = ItensConstants.ALIEN_EGG_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.ALIENEGGTOCONCENTRATED_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "AlienEggToConcentrated_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition EGG_TO_CONCENTRATED_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = ItensConstants.EGG_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.EGGTOCONCENTRATED_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "EggToConcentrated_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition SHRIMPMEAT_TO_CONCENTRATED_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = ItensConstants.SHRIMPMEAT_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.SHRIMPMEATTOCONCENTRATED_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "ShrimpMeatToConcentrated_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition SHRIMPMEAT_TO_CONCENTRATED_FAT_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = ItensConstants.SHRIMPMEAT_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.SHRIMPMEATTOCONCENTRATEDFAT_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "ShrimpMeatToConcentratedFat_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition FISHMEAT_TO_CONCENTRATED_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = ItensConstants.FISHMEAT_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.FISHMEATTOCONCENTRATED_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "FishMeatToConcentrated_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition FISHMEAT_TO_CONCENTRATED_FAT_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = ItensConstants.FISHMEAT_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.FISHMEATTOCONCENTRATEDFAT_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "FishMeatToConcentratedFat_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition ALIEN_MEAT_TO_CONCENTRATED_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = ItensConstants.ALIEN_MEAT_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.ALIENMEATTOCONCENTRATED_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "AlienMeatToConcentrated_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition ALIEN_MEAT_TO_CONCENTRATED_FAT_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = ItensConstants.ALIEN_MEAT_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.ALIENMEATTOCONCENTRATEDFAT_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "AlienMeatToConcentratedFat_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition MEAT_TO_CONCENTRATED_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = ItensConstants.MEAT_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.MEATTOCONCENTRATED_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "MeatToConcentrated_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition MEAT_TO_CONCENTRATED_FAT_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = ItensConstants.MEAT_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.MEATTOCONCENTRATEDFAT_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "MeatToConcentratedFat_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition CHICKENMEAT_TO_CONCENTRATED_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = ItensConstants.CHICKENMEAT_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.CHICKENMEATTOCONCENTRATED_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "ChickenMeatToConcentrated_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition CHICKENMEAT_TO_CONCENTRATED_FAT_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = ItensConstants.CHICKENMEAT_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.CHICKENMEATTOCONCENTRATEDFAT_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "ChickenMeatToConcentratedFat_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition MILK_TO_CONCENTRATED_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = ItensConstants.MILK_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.MILKTOCONCENTRATED_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "MilkToConcentrated_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition MILK_TO_CONCENTRATED_FAT_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = ItensConstants.MILK_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.MILKTOCONCENTRATEDFAT_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "MilkToConcentratedFat_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition BACON_TO_CONCENTRATED_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = ItensConstants.BACON_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.BACONTOCONCENTRATED_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "BaconToConcentrated_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition BACON_TO_CONCENTRATED_FAT_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = ItensConstants.BACON_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.BACONTOCONCENTRATEDFAT_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "BaconToConcentratedFat_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition NOBLEFISHMEAT_TO_CONCENTRATED_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = ItensConstants.NOBLEFISHMEAT_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.NOBLEFISHMEATTOCONCENTRATED_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "NobleFishMeatToConcentrated_Construction",
            ProductionTime = 2.56f 
        };

        public static readonly FoodConcentratedExtractDefinition NOBLEFISHMEAT_TO_CONCENTRATED_FAT_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = ItensConstants.NOBLEFISHMEAT_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.NOBLEFISHMEATTOCONCENTRATEDFAT_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "NobleFishMeatToConcentratedFat_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition ALIEN_NOBLE_MEAT_TO_CONCENTRATED_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = ItensConstants.ALIEN_NOBLE_MEAT_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.NOBLEALIENMEATTOCONCENTRATED_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "NobleAlienMeatToConcentrated_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition ALIEN_NOBLE_MEAT_TO_CONCENTRATED_FAT_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = ItensConstants.ALIEN_NOBLE_MEAT_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.NOBLEALIENMEATTOCONCENTRATEDFAT_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "NobleAlienMeatToConcentratedFat_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition NOBLE_MEAT_TO_CONCENTRATED_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = ItensConstants.NOBLE_MEAT_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.NOBLEMEATTOCONCENTRATED_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "NobleMeatToConcentrated_Construction",
            ProductionTime = 2.56f
        };

        public static readonly FoodConcentratedExtractDefinition NOBLE_MEAT_TO_CONCENTRATED_FAT_DEFINITION = new FoodConcentratedExtractDefinition()
        {
            Ingredient = new FoodConcentratedExtractDefinition.RecipeItem()
            {
                Id = ItensConstants.NOBLE_MEAT_ID,
                Ammount = 1
            },
            Name = LanguageProvider.GetEntry(LanguageEntries.NOBLEMEATTOCONCENTRATEDFAT_CONSTRUCTION_NAME),
            Description = "",
            RecipeName = "NobleMeatToConcentratedFat_Construction",
            ProductionTime = 2.56f
        };

        public static readonly Dictionary<UniqueEntityId, List<FoodConcentratedExtractDefinition>> FOOD_CONCENTRATED_EXTRACTORS = new Dictionary<UniqueEntityId, List<FoodConcentratedExtractDefinition>>()
        {
            { 
                ItensConstants.CONCENTRATEDVITAMIN_ID,  
                new List<FoodConcentratedExtractDefinition>()
                {
                    TOMATO_TO_CONCENTRATED_DEFINITION,
                    APPLE_TO_CONCENTRATED_DEFINITION
                }
            },
            {
                ItensConstants.CONCENTRATEDPROTEIN_ID,
                new List<FoodConcentratedExtractDefinition>()
                {
                    ALIENEGG_TO_CONCENTRATED_DEFINITION,
                    EGG_TO_CONCENTRATED_DEFINITION,
                    SHRIMPMEAT_TO_CONCENTRATED_DEFINITION,
                    FISHMEAT_TO_CONCENTRATED_DEFINITION,
                    ALIEN_MEAT_TO_CONCENTRATED_DEFINITION,
                    MEAT_TO_CONCENTRATED_DEFINITION,
                    CHICKENMEAT_TO_CONCENTRATED_DEFINITION,
                    MILK_TO_CONCENTRATED_DEFINITION,
                    BACON_TO_CONCENTRATED_DEFINITION,
                    NOBLEFISHMEAT_TO_CONCENTRATED_DEFINITION,
                    ALIEN_NOBLE_MEAT_TO_CONCENTRATED_DEFINITION,
                    NOBLE_MEAT_TO_CONCENTRATED_DEFINITION
                }
            },
            {
                ItensConstants.CONCENTRATEDFAT_ID,
                new List<FoodConcentratedExtractDefinition>()
                {
                    SHRIMPMEAT_TO_CONCENTRATED_FAT_DEFINITION,
                    FISHMEAT_TO_CONCENTRATED_FAT_DEFINITION,
                    ALIEN_MEAT_TO_CONCENTRATED_FAT_DEFINITION,
                    MEAT_TO_CONCENTRATED_FAT_DEFINITION,
                    CHICKENMEAT_TO_CONCENTRATED_FAT_DEFINITION,
                    MILK_TO_CONCENTRATED_FAT_DEFINITION,
                    BACON_TO_CONCENTRATED_FAT_DEFINITION,
                    NOBLEFISHMEAT_TO_CONCENTRATED_FAT_DEFINITION,
                    ALIEN_NOBLE_MEAT_TO_CONCENTRATED_FAT_DEFINITION,
                    NOBLE_MEAT_TO_CONCENTRATED_FAT_DEFINITION
                }
            }
        };

        public static void TryOverrideDefinitions()
        {
            try
            {
                // Override recipes and add food definition
                var recipesToPostprocess = new List<MyBlueprintDefinitionBase>();
                foreach (var food in FOOD_RECIPES.Keys)
                {
                    if (FOOD_DEFINITIONS.ContainsKey(food))
                        continue;
                    var preparationDef = FOOD_RECIPES[food];
                    var recipeDef = DefinitionUtils.TryGetBlueprintDefinition(preparationDef.RecipeName);
                    if (recipeDef != null)
                    {
                        recipesToPostprocess.Add(recipeDef);
                        recipeDef.Prerequisites = preparationDef.GetIngredients();
                        recipeDef.Results = preparationDef.GetProduct();
                        recipeDef.BaseProductionTimeInSeconds = preparationDef.ProductionTime;
                        recipeDef.DisplayNameEnum = null;
                        recipeDef.DisplayNameString = preparationDef.Name;
                        recipeDef.DescriptionEnum = null;
                        recipeDef.DescriptionString = preparationDef.GetFullDescription();
                        // Add item definition based as recipes values
                        var foodDef = new FoodDefinition()
                        {
                            Id = preparationDef.Product.Id,
                            Name = preparationDef.Name,
                            Description = preparationDef.Description,
                            DefinitionType = preparationDef.DefinitionType,
                            AcquisitionAmount = preparationDef.AcquisitionAmount,
                            OrderAmount = preparationDef.OrderAmount,
                            OfferAmount = preparationDef.OfferAmount,
                            MinimalPricePerUnit = preparationDef.MinimalPricePerUnit,
                            CanPlayerOrder = preparationDef.CanPlayerOrder,
                            CureDisease = preparationDef.CureDisease
                        };
                        bool needConservation = false;
                        long maxTime = 0;
                        foreach (var item in preparationDef.Ingredients)
                        {
                            if (FOOD_RECIPIENTS.Contains(item.Id) || MEDICAL_INGREDIENTS.Contains(item.Id) || !FOOD_DEFINITIONS.ContainsKey(item.Id))
                                continue;
                            var ingredientDef = FOOD_DEFINITIONS[item.Id];
                            needConservation = needConservation || ingredientDef.NeedConservation;
                            if (ingredientDef.StartConservationTime > 0)
                            {
                                maxTime = Math.Max(maxTime, ingredientDef.StartConservationTime);
                            }
                            foodDef.Increment(ingredientDef, item.Ammount);
                        }
                        foodDef.Divide(preparationDef.Product.Ammount);
                        foodDef.ApplyPreparation(preparationDef.Preparation, needConservation, maxTime);
                        FOOD_DEFINITIONS.Add(food, foodDef);
                    }
                    else
                        ExtendedSurvivalStatsLogging.Instance.LogInfo(typeof(FoodConstants), $"CalculateRecipesNutrition recipe not found. Recipe=[{preparationDef.RecipeName}]");
                }
                // Override food definition
                foreach (var food in FOOD_DEFINITIONS.Keys)
                {
                    var foodDef = FOOD_DEFINITIONS[food];
                    if (foodDef.IgnoreDefinition)
                        continue;
                    switch (foodDef.DefinitionType)
                    {
                        case FoodDefinition.FoodDefinitionType.Consumable:
                            var consumableDef = DefinitionUtils.TryGetDefinition<MyConsumableItemDefinition>(food.DefinitionId);
                            if (consumableDef != null)
                            {
                                if (consumableDef.Stats == null)
                                    consumableDef.Stats = new List<MyConsumableItemDefinition.StatValue>();
                                consumableDef.Stats.Clear();
                                consumableDef.Stats.Add(new MyConsumableItemDefinition.StatValue()
                                {
                                    Name = StatsConstants.ValidStats.FoodDetector.ToString(),
                                    Time = 3,
                                    Value = 0.025f
                                });
                                consumableDef.Volume = foodDef.GetVolume();
                                consumableDef.Mass = foodDef.GetMass();
                                consumableDef.DisplayNameEnum = null;
                                consumableDef.DisplayNameString = foodDef.Name;
                                consumableDef.DescriptionEnum = null;
                                consumableDef.DescriptionString = null;
                                consumableDef.MinimumAcquisitionAmount = foodDef.AcquisitionAmount.X;
                                consumableDef.MaximumAcquisitionAmount = foodDef.AcquisitionAmount.Y;
                                consumableDef.MinimumOrderAmount = foodDef.OrderAmount.X;
                                consumableDef.MaximumOrderAmount = foodDef.OrderAmount.Y;
                                consumableDef.MinimumOfferAmount = foodDef.OfferAmount.X;
                                consumableDef.MaximumOfferAmount = foodDef.OfferAmount.Y;
                                consumableDef.MinimalPricePerUnit = foodDef.MinimalPricePerUnit;
                                consumableDef.CanPlayerOrder = foodDef.CanPlayerOrder;
                                consumableDef.ExtraInventoryTooltipLine.AppendLine(Environment.NewLine + foodDef.GetFullDescription());
                                consumableDef.Postprocess();
                            }
                            else
                                ExtendedSurvivalStatsLogging.Instance.LogInfo(typeof(FoodConstants), $"TryOverrideRecipes item not found. Food=[{food}]");
                            break;
                        case FoodDefinition.FoodDefinitionType.Ore:
                        case FoodDefinition.FoodDefinitionType.Ingot:
                            var physicalItemDef = DefinitionUtils.TryGetDefinition<MyPhysicalItemDefinition>(food.DefinitionId);
                            if (physicalItemDef != null)
                            {
                                physicalItemDef.DisplayNameEnum = null;
                                physicalItemDef.DisplayNameString = foodDef.Name;
                                physicalItemDef.DescriptionEnum = null;
                                physicalItemDef.DescriptionString = null;
                                physicalItemDef.ExtraInventoryTooltipLine.AppendLine(Environment.NewLine + foodDef.GetFullDescription());
                                physicalItemDef.Postprocess();
                            }
                            else
                                ExtendedSurvivalStatsLogging.Instance.LogInfo(typeof(FoodConstants), $"TryOverrideRecipes item not found. Food=[{food}]");
                            break;
                    }
                }
                // Override Concentrated Recipes
                foreach (var targetFood in FOOD_CONCENTRATED_EXTRACTORS.Keys)
                {
                    var targetFoodDef = FOOD_DEFINITIONS[targetFood];
                    foreach (var targetIngredient in FOOD_CONCENTRATED_EXTRACTORS[targetFood])
                    {
                        var targetIngredientDef = FOOD_DEFINITIONS[targetIngredient.Ingredient.Id];
                        var recipeDef = DefinitionUtils.TryGetBlueprintDefinition(targetIngredient.RecipeName);
                        if (recipeDef != null)
                        {
                            recipesToPostprocess.Add(recipeDef);
                            recipeDef.Prerequisites = new MyBlueprintDefinitionBase.Item[] { 
                                new MyBlueprintDefinitionBase.Item()
                                {
                                    Id = targetIngredient.Ingredient.Id.DefinitionId,
                                    Amount = (MyFixedPoint)targetIngredient.Ingredient.Ammount
                                }
                            };
                            float resultAmmount = 0;
                            if (targetFood == ItensConstants.CONCENTRATEDVITAMIN_ID)
                                resultAmmount = targetIngredientDef.Vitamins;
                            if (targetFood == ItensConstants.CONCENTRATEDPROTEIN_ID)
                                resultAmmount = targetIngredientDef.Protein;
                            if (targetFood == ItensConstants.CONCENTRATEDFAT_ID)
                                resultAmmount = targetIngredientDef.Lipids;
                            recipeDef.Results = new MyBlueprintDefinitionBase.Item[] {
                                new MyBlueprintDefinitionBase.Item()
                                {
                                    Id = targetFood.DefinitionId,
                                    Amount = (MyFixedPoint)resultAmmount
                                }
                            };
                            recipeDef.BaseProductionTimeInSeconds = targetIngredient.ProductionTime;
                            recipeDef.DisplayNameEnum = null;
                            recipeDef.DisplayNameString = targetIngredient.Name;
                            recipeDef.DescriptionEnum = null;
                            recipeDef.DescriptionString = null;
                        }
                        else
                            ExtendedSurvivalStatsLogging.Instance.LogInfo(typeof(FoodConstants), $"CalculateRecipesNutrition recipe not found. Recipe=[{targetIngredient.RecipeName}]");
                    }
                }
                // Post process recipes
                foreach (var recipe in recipesToPostprocess)
                {
                    recipe.Postprocess();
                }
                // Add itens to faction types
                var targetFaction = FactionTypeConstants.FACTION_TYPES_DEFINITIONS[FactionTypeConstants.TRADER_ID];
                foreach (var food in FOOD_DEFINITIONS.Where(x => x.Value.CanPlayerOrder))
                {
                    targetFaction.OffersList.Add(food.Key);
                    targetFaction.OrdersList.Add(food.Key);
                }
            }
            catch (System.Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(typeof(FoodConstants), ex);
            }
        }

    }

}