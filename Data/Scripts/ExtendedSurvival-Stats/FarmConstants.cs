using System.Collections.Generic;
using VRage.Game;
using VRageMath;

namespace ExtendedSurvival.Stats
{

    public static class FarmConstants
    {

        public class TreeFarmDefinition : FarmDefinition
        {

            public bool RequiredFullCharge { get; set; }
            public float ChargeAmmount { get; set; }
            public bool IsGrowthRecipe { get; set; }

        }

        public class FarmDefinition
        {

            public float FertilizerFactor { get; set; }
            public float IceFactor { get; set; }
            public float SeedFactor { get; set; }
            public bool SunRequired { get; set; }
            public float TimeToProduceInMs { get; set; }
            public UniqueEntityId PreferredFertilizer { get; set; }
            public List<FarmResultDefinition> Results { get; set; }

        }

        public class FarmResultDefinition
        {

            public UniqueEntityId Product { get; set; }
            public Vector2 BaseFactor { get; set; }
            public bool AllowDecimal { get; set; }
            public float SunMultiplierFactor { get; set; }
            public float ChanceToGenerate { get; set; }
            public bool IsGas { get; set; }
            public float GasAmmount { get; set; }

            public MyObjectBuilder_PhysicalObject GetBuilder()
            {
                if (IsGas)
                    return ItensConstants.GetGasContainerBuilder(Product, GasAmmount);
                else
                    return ItensConstants.GetPhysicalObjectBuilder(Product);
            }

        }

        public const int BASE_TIME_TO_PRODUCE = 5000;
        public const float BASE_FERTILIZER_FACTOR = 0.015f;
        public const float BASE_ICE_FACTOR = 0.025f;
        public const float BASE_SEED_FACTOR = 0.1f;
        public const float BASE_SUN_MULTIPLIER_FACTOR = 0.5f;
        public const float BASE_SUN_MULTIPLIER_SEED_FACTOR = 1.5f;

        public const float BASE_SPOILMULTIPLIER_WITH_TREE = 0.25f;

        public const float BASE_INCRESE_COST = 0.25f;

        public const float BASE_TREE_ABSORCION_FACTOR = 0.01f;
        public const float BASE_DECAY_FACTOR = 0.0025f;
        public const float BASE_TREE_DECAY_FACTOR = 0.00125f;
        public const long BASE_TOLERANCE_TIME = 12;

        public const float PREFER_FERTILIZER_MULTIPLIER = 1.25f;
        public const float POWER_FERTILIZER_MULTIPLIER = 1.5f;

        public static readonly List<UniqueEntityId> TREE_IDS = new List<UniqueEntityId>()
        {
            SeedsAndFertilizerConstants.APPLETREESEEDLING_ID,
            SeedsAndFertilizerConstants.APPLETREE_ID
        };

        public static readonly List<UniqueEntityId> FERTILIZERS = new List<UniqueEntityId>()
        {
            SeedsAndFertilizerConstants.FERTILIZER_ID,
            SeedsAndFertilizerConstants.MINERALFERTILIZER_ID,
            SeedsAndFertilizerConstants.SUPERFERTILIZER_ID
        };

        public static readonly UniqueEntityId POWER_FERTILIZER = SeedsAndFertilizerConstants.SUPERFERTILIZER_ID;

        public static readonly Dictionary<UniqueEntityId, TreeFarmDefinition> TREE_DEFINITIONS = new Dictionary<UniqueEntityId, TreeFarmDefinition>()
        {
            {
                SeedsAndFertilizerConstants.APPLETREESEEDLING_ID,
                new TreeFarmDefinition()
                {
                    ChargeAmmount = BASE_TREE_ABSORCION_FACTOR,
                    RequiredFullCharge = true,
                    IsGrowthRecipe = true,
                    FertilizerFactor = BASE_FERTILIZER_FACTOR,
                    IceFactor = BASE_ICE_FACTOR,
                    SeedFactor = 0,
                    SunRequired = true,
                    TimeToProduceInMs = BASE_TIME_TO_PRODUCE,
                    PreferredFertilizer = SeedsAndFertilizerConstants.FERTILIZER_ID,
                    Results = new List<FarmResultDefinition>()
                    {
                        new FarmResultDefinition()
                        {
                            Product = SeedsAndFertilizerConstants.APPLETREE_ID,
                            BaseFactor = new Vector2(1, 1),
                            AllowDecimal = false,
                            SunMultiplierFactor = 0,
                            ChanceToGenerate = 100,
                            IsGas = true,
                            GasAmmount = 0.5f
                        }
                    }
                }
            },
            {
                SeedsAndFertilizerConstants.APPLETREE_ID,
                new TreeFarmDefinition()
                {
                    ChargeAmmount = BASE_TREE_ABSORCION_FACTOR,
                    FertilizerFactor = BASE_FERTILIZER_FACTOR,
                    IceFactor = BASE_ICE_FACTOR,
                    SeedFactor = 0,
                    SunRequired = true,
                    TimeToProduceInMs = BASE_TIME_TO_PRODUCE,
                    PreferredFertilizer = SeedsAndFertilizerConstants.FERTILIZER_ID,
                    Results = new List<FarmResultDefinition>()
                    {
                        new FarmResultDefinition()
                        {
                            Product = ItensConstants.LEAF_ID,
                            BaseFactor = new Vector2(4, 8),
                            AllowDecimal = true,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_FACTOR,
                            ChanceToGenerate = 37.5f
                        },
                        new FarmResultDefinition()
                        {
                            Product = ItensConstants.TWIG_ID,
                            BaseFactor = new Vector2(3, 6),
                            AllowDecimal = true,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_FACTOR,
                            ChanceToGenerate = 25.0f
                        },
                        new FarmResultDefinition()
                        {
                            Product = ItensConstants.BRANCH_ID,
                            BaseFactor = new Vector2(2, 4),
                            AllowDecimal = true,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_FACTOR,
                            ChanceToGenerate = 12.5f
                        },
                        new FarmResultDefinition()
                        {
                            Product =ItensConstants.APPLE_ID,
                            BaseFactor = new Vector2(1, 2),
                            AllowDecimal = false,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_FACTOR,
                            ChanceToGenerate = 6.25f
                        },
                        new FarmResultDefinition()
                        {
                            Product =SeedsAndFertilizerConstants.APPLETREESEEDLING_ID,
                            BaseFactor = new Vector2(1, 1),
                            AllowDecimal = false,
                            SunMultiplierFactor = 0,
                            ChanceToGenerate = 1.25f,
                            IsGas = true,
                            GasAmmount = 0.3f
                        }
                    }
                }
            }
        };

        public static readonly Dictionary<UniqueEntityId, FarmDefinition> DEFINITIONS = new Dictionary<UniqueEntityId, FarmDefinition>()
        {
            {
                ItensConstants.SHIITAKE_ID, new FarmDefinition()
                {
                    FertilizerFactor = BASE_FERTILIZER_FACTOR,
                    IceFactor = BASE_ICE_FACTOR,
                    SeedFactor = 0,
                    SunRequired = false,
                    TimeToProduceInMs = BASE_TIME_TO_PRODUCE,
                    PreferredFertilizer = SeedsAndFertilizerConstants.MINERALFERTILIZER_ID,
                    Results = new List<FarmResultDefinition>()
                    {
                        new FarmResultDefinition()
                        {
                            Product =ItensConstants.SHIITAKE_ID,
                            BaseFactor = new Vector2(1, 2),
                            AllowDecimal = false,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_FACTOR,
                            ChanceToGenerate = 35
                        }
                    }
                }
            },
            {
                ItensConstants.CHAMPIGNONS_ID, new FarmDefinition()
                {
                    FertilizerFactor = BASE_FERTILIZER_FACTOR,
                    IceFactor = BASE_ICE_FACTOR,
                    SeedFactor = 0,
                    SunRequired = false,
                    TimeToProduceInMs = BASE_TIME_TO_PRODUCE,
                    PreferredFertilizer = SeedsAndFertilizerConstants.MINERALFERTILIZER_ID,
                    Results = new List<FarmResultDefinition>()
                    {
                        new FarmResultDefinition()
                        {
                            Product =ItensConstants.CHAMPIGNONS_ID,
                            BaseFactor = new Vector2(1, 2),
                            AllowDecimal = false,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_FACTOR,
                            ChanceToGenerate = 45
                        }
                    }
                }
            },
            {
                ItensConstants.AMANITAMUSCARIA_ID, new FarmDefinition()
                {
                    FertilizerFactor = BASE_FERTILIZER_FACTOR,
                    IceFactor = BASE_ICE_FACTOR,
                    SeedFactor = 0,
                    SunRequired = false,
                    TimeToProduceInMs = BASE_TIME_TO_PRODUCE,
                    PreferredFertilizer = SeedsAndFertilizerConstants.MINERALFERTILIZER_ID,
                    Results = new List<FarmResultDefinition>()
                    {
                        new FarmResultDefinition()
                        {
                            Product =ItensConstants.AMANITAMUSCARIA_ID,
                            BaseFactor = new Vector2(1, 2),
                            AllowDecimal = false,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_FACTOR,
                            ChanceToGenerate = 25
                        }
                    }
                }
            },
            {
                SeedsAndFertilizerConstants.BEETROOT_SEEDS_ID, new FarmDefinition()
                {
                    FertilizerFactor = BASE_FERTILIZER_FACTOR,
                    IceFactor = BASE_ICE_FACTOR,
                    SeedFactor = BASE_SEED_FACTOR,
                    SunRequired = true,
                    TimeToProduceInMs = BASE_TIME_TO_PRODUCE,
                    PreferredFertilizer = SeedsAndFertilizerConstants.MINERALFERTILIZER_ID,
                    Results = new List<FarmResultDefinition>()
                    {
                        new FarmResultDefinition()
                        {
                            Product =ItensConstants.BEETROOT_ID,
                            BaseFactor = new Vector2(2, 3),
                            AllowDecimal = false,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_FACTOR,
                            ChanceToGenerate = 50
                        },
                        new FarmResultDefinition()
                        {
                            Product =SeedsAndFertilizerConstants.BEETROOT_SEEDS_ID,
                            BaseFactor = new Vector2(0.25f, 0.5f),
                            AllowDecimal = true,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_SEED_FACTOR,
                            ChanceToGenerate = 25
                        }
                    }
                }
            },
            {
                SeedsAndFertilizerConstants.ARNICA_SEEDS_ID, new FarmDefinition()
                {
                    FertilizerFactor = BASE_FERTILIZER_FACTOR,
                    IceFactor = BASE_ICE_FACTOR,
                    SeedFactor = BASE_SEED_FACTOR,
                    SunRequired = true,
                    TimeToProduceInMs = BASE_TIME_TO_PRODUCE,
                    PreferredFertilizer = SeedsAndFertilizerConstants.FERTILIZER_ID,
                    Results = new List<FarmResultDefinition>()
                    {
                        new FarmResultDefinition()
                        {
                            Product =ItensConstants.ARNICA_ID,
                            BaseFactor = new Vector2(2.5f, 7.5f),
                            AllowDecimal = true,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_FACTOR,
                            ChanceToGenerate = 50
                        },
                        new FarmResultDefinition()
                        {
                            Product = SeedsAndFertilizerConstants.ARNICA_SEEDS_ID,
                            BaseFactor = new Vector2(0.05f, 0.25f),
                            AllowDecimal = true,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_SEED_FACTOR,
                            ChanceToGenerate = 25
                        }
                    }
                }
            },
            {
                SeedsAndFertilizerConstants.BROCCOLI_SEEDS_ID, new FarmDefinition()
                {
                    FertilizerFactor = BASE_FERTILIZER_FACTOR,
                    IceFactor = BASE_ICE_FACTOR,
                    SeedFactor = BASE_SEED_FACTOR,
                    SunRequired = true,
                    TimeToProduceInMs = BASE_TIME_TO_PRODUCE,
                    PreferredFertilizer = SeedsAndFertilizerConstants.MINERALFERTILIZER_ID,
                    Results = new List<FarmResultDefinition>()
                    {
                        new FarmResultDefinition()
                        {
                            Product =ItensConstants.BROCCOLI_ID,
                            BaseFactor = new Vector2(1, 2),
                            AllowDecimal = false,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_FACTOR,
                            ChanceToGenerate = 50
                        },
                        new FarmResultDefinition()
                        {
                            Product =SeedsAndFertilizerConstants.BROCCOLI_SEEDS_ID,
                            BaseFactor = new Vector2(0.15f, 0.35f),
                            AllowDecimal = true,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_SEED_FACTOR,
                            ChanceToGenerate = 25
                        }
                    }
                }
            },
            {
                SeedsAndFertilizerConstants.CARROT_SEEDS_ID, new FarmDefinition()
                {
                    FertilizerFactor = BASE_FERTILIZER_FACTOR,
                    IceFactor = BASE_ICE_FACTOR,
                    SeedFactor = BASE_SEED_FACTOR,
                    SunRequired = true,
                    TimeToProduceInMs = BASE_TIME_TO_PRODUCE,
                    PreferredFertilizer = SeedsAndFertilizerConstants.MINERALFERTILIZER_ID,
                    Results = new List<FarmResultDefinition>()
                    {
                        new FarmResultDefinition()
                        {
                            Product =ItensConstants.CAROOT_ID,
                            BaseFactor = new Vector2(2, 3),
                            AllowDecimal = false,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_FACTOR,
                            ChanceToGenerate = 50
                        },
                        new FarmResultDefinition()
                        {
                            Product =SeedsAndFertilizerConstants.CARROT_SEEDS_ID,
                            BaseFactor = new Vector2(0.25f, 0.5f),
                            AllowDecimal = true,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_SEED_FACTOR,
                            ChanceToGenerate = 25
                        }
                    }
                }
            },
            {
                SeedsAndFertilizerConstants.COFFEE_SEEDS_ID, new FarmDefinition()
                {
                    FertilizerFactor = BASE_FERTILIZER_FACTOR,
                    IceFactor = BASE_ICE_FACTOR,
                    SeedFactor = BASE_SEED_FACTOR,
                    SunRequired = true,
                    TimeToProduceInMs = BASE_TIME_TO_PRODUCE,
                    PreferredFertilizer = SeedsAndFertilizerConstants.FERTILIZER_ID,
                    Results = new List<FarmResultDefinition>()
                    {
                        new FarmResultDefinition()
                        {
                            Product =ItensConstants.COFFEE_ID,
                            BaseFactor = new Vector2(0.5f, 4.5f),
                            AllowDecimal = true,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_FACTOR,
                            ChanceToGenerate = 50
                        },
                        new FarmResultDefinition()
                        {
                            Product =SeedsAndFertilizerConstants.COFFEE_SEEDS_ID,
                            BaseFactor = new Vector2(0.15f, 0.55f),
                            AllowDecimal = true,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_SEED_FACTOR,
                            ChanceToGenerate = 25
                        }
                    }
                }
            },
            {
                SeedsAndFertilizerConstants.MINT_SEEDS_ID, new FarmDefinition()
                {
                    FertilizerFactor = BASE_FERTILIZER_FACTOR,
                    IceFactor = BASE_ICE_FACTOR,
                    SeedFactor = BASE_SEED_FACTOR,
                    SunRequired = true,
                    TimeToProduceInMs = BASE_TIME_TO_PRODUCE,
                    PreferredFertilizer = SeedsAndFertilizerConstants.FERTILIZER_ID,
                    Results = new List<FarmResultDefinition>()
                    {
                        new FarmResultDefinition()
                        {
                            Product =ItensConstants.MINT_ID,
                            BaseFactor = new Vector2(3.75f, 6.50f),
                            AllowDecimal = true,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_FACTOR,
                            ChanceToGenerate = 50
                        },
                        new FarmResultDefinition()
                        {
                            Product =SeedsAndFertilizerConstants.MINT_SEEDS_ID,
                            BaseFactor = new Vector2(0.1f, 0.5f),
                            AllowDecimal = true,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_SEED_FACTOR,
                            ChanceToGenerate = 25
                        }
                    }
                }
            },
            {
                SeedsAndFertilizerConstants.TOMATO_SEEDS_ID, new FarmDefinition()
                {
                    FertilizerFactor = BASE_FERTILIZER_FACTOR,
                    IceFactor = BASE_ICE_FACTOR,
                    SeedFactor = BASE_SEED_FACTOR,
                    SunRequired = true,
                    TimeToProduceInMs = BASE_TIME_TO_PRODUCE,
                    PreferredFertilizer = SeedsAndFertilizerConstants.FERTILIZER_ID,
                    Results = new List<FarmResultDefinition>()
                    {
                        new FarmResultDefinition()
                        {
                            Product =ItensConstants.TOMATO_ID,
                            BaseFactor = new Vector2(1, 2),
                            AllowDecimal = false,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_FACTOR,
                            ChanceToGenerate = 50
                        },
                        new FarmResultDefinition()
                        {
                            Product =SeedsAndFertilizerConstants.TOMATO_SEEDS_ID,
                            BaseFactor = new Vector2(0.15f, 0.35f),
                            AllowDecimal = true,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_SEED_FACTOR,
                            ChanceToGenerate = 25
                        }
                    }
                }
            },
            {
                SeedsAndFertilizerConstants.WHEAT_SEEDS_ID, new FarmDefinition()
                {
                    FertilizerFactor = BASE_FERTILIZER_FACTOR,
                    IceFactor = BASE_ICE_FACTOR,
                    SeedFactor = BASE_SEED_FACTOR,
                    SunRequired = true,
                    TimeToProduceInMs = BASE_TIME_TO_PRODUCE,
                    PreferredFertilizer = SeedsAndFertilizerConstants.FERTILIZER_ID,
                    Results = new List<FarmResultDefinition>()
                    {
                        new FarmResultDefinition()
                        {
                            Product =ItensConstants.WHEAT_ID,
                            BaseFactor = new Vector2(1.25f, 7.75f),
                            AllowDecimal = true,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_FACTOR,
                            ChanceToGenerate = 50
                        },
                        new FarmResultDefinition()
                        {
                            Product =SeedsAndFertilizerConstants.WHEAT_SEEDS_ID,
                            BaseFactor = new Vector2(0.2f, 0.8f),
                            AllowDecimal = true,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_SEED_FACTOR,
                            ChanceToGenerate = 25
                        }
                    }
                }
            },
            {
                SeedsAndFertilizerConstants.CHAMOMILE_SEEDS_ID, new FarmDefinition()
                {
                    FertilizerFactor = BASE_FERTILIZER_FACTOR,
                    IceFactor = BASE_ICE_FACTOR,
                    SeedFactor = BASE_SEED_FACTOR,
                    SunRequired = true,
                    TimeToProduceInMs = BASE_TIME_TO_PRODUCE,
                    PreferredFertilizer = SeedsAndFertilizerConstants.FERTILIZER_ID,
                    Results = new List<FarmResultDefinition>()
                    {
                        new FarmResultDefinition()
                        {
                            Product =ItensConstants.CHAMOMILE_ID,
                            BaseFactor = new Vector2(3.75f, 6.50f),
                            AllowDecimal = true,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_FACTOR,
                            ChanceToGenerate = 50
                        },
                        new FarmResultDefinition()
                        {
                            Product =SeedsAndFertilizerConstants.CHAMOMILE_SEEDS_ID,
                            BaseFactor = new Vector2(0.1f, 0.5f),
                            AllowDecimal = true,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_SEED_FACTOR,
                            ChanceToGenerate = 25
                        }
                    }
                }
            },
            {
                SeedsAndFertilizerConstants.ALOEVERA_SEEDS_ID, new FarmDefinition()
                {
                    FertilizerFactor = BASE_FERTILIZER_FACTOR,
                    IceFactor = BASE_ICE_FACTOR,
                    SeedFactor = BASE_SEED_FACTOR,
                    SunRequired = true,
                    TimeToProduceInMs = BASE_TIME_TO_PRODUCE,
                    PreferredFertilizer = SeedsAndFertilizerConstants.FERTILIZER_ID,
                    Results = new List<FarmResultDefinition>()
                    {
                        new FarmResultDefinition()
                        {
                            Product =ItensConstants.ALOEVERA_ID,
                            BaseFactor = new Vector2(5.75f, 12.5f),
                            AllowDecimal = true,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_FACTOR,
                            ChanceToGenerate = 50
                        },
                        new FarmResultDefinition()
                        {
                            Product =SeedsAndFertilizerConstants.ALOEVERA_SEEDS_ID,
                            BaseFactor = new Vector2(0.15f, 0.45f),
                            AllowDecimal = true,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_SEED_FACTOR,
                            ChanceToGenerate = 25
                        }
                    }
                }
            },
            {
                SeedsAndFertilizerConstants.ERYTHROXYLUM_SEEDS_ID, new FarmDefinition()
                {
                    FertilizerFactor = BASE_FERTILIZER_FACTOR,
                    IceFactor = BASE_ICE_FACTOR,
                    SeedFactor = BASE_SEED_FACTOR,
                    SunRequired = true,
                    TimeToProduceInMs = BASE_TIME_TO_PRODUCE,
                    PreferredFertilizer = SeedsAndFertilizerConstants.FERTILIZER_ID,
                    Results = new List<FarmResultDefinition>()
                    {
                        new FarmResultDefinition()
                        {
                            Product =ItensConstants.ERYTHROXYLUM_ID,
                            BaseFactor = new Vector2(5.75f, 12.5f),
                            AllowDecimal = true,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_FACTOR,
                            ChanceToGenerate = 50
                        },
                        new FarmResultDefinition()
                        {
                            Product =SeedsAndFertilizerConstants.ERYTHROXYLUM_SEEDS_ID,
                            BaseFactor = new Vector2(0.15f, 0.45f),
                            AllowDecimal = true,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_SEED_FACTOR,
                            ChanceToGenerate = 25
                        }
                    }
                }
            }
        };

    }

}