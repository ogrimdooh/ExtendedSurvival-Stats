﻿using System.Collections.Generic;
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
        public const float BASE_SUN_MULTIPLIER_FACTOR = 0.5f;
        public const float BASE_SUN_MULTIPLIER_SEED_FACTOR = 1.5f;

        public const float BASE_HERB_SEED_FACTOR = 0.01f;
        public const float BASE_GRAIN_SEED_FACTOR = 0.01f;
        public const float BASE_MUSHROOM_SEED_FACTOR = 0.01f;
        public const float BASE_VEGETABLE_SEED_FACTOR = 0.1f;

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
                            Product = FoodConstants.APPLE_ID,
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
                SeedsAndFertilizerConstants.SHIITAKE_SEEDS_ID, new FarmDefinition()
                {
                    FertilizerFactor = BASE_FERTILIZER_FACTOR,
                    IceFactor = BASE_ICE_FACTOR,
                    SeedFactor = BASE_MUSHROOM_SEED_FACTOR,
                    SunRequired = false,
                    TimeToProduceInMs = BASE_TIME_TO_PRODUCE,
                    PreferredFertilizer = SeedsAndFertilizerConstants.MINERALFERTILIZER_ID,
                    Results = new List<FarmResultDefinition>()
                    {
                        new FarmResultDefinition()
                        {
                            Product =FoodConstants.SHIITAKE_ID,
                            BaseFactor = new Vector2(3, 12),
                            AllowDecimal = false,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_FACTOR,
                            ChanceToGenerate = 50
                        }
                    }
                }
            },
            {
                SeedsAndFertilizerConstants.CHAMPIGNONS_SEEDS_ID, new FarmDefinition()
                {
                    FertilizerFactor = BASE_FERTILIZER_FACTOR,
                    IceFactor = BASE_ICE_FACTOR,
                    SeedFactor = BASE_MUSHROOM_SEED_FACTOR,
                    SunRequired = false,
                    TimeToProduceInMs = BASE_TIME_TO_PRODUCE,
                    PreferredFertilizer = SeedsAndFertilizerConstants.MINERALFERTILIZER_ID,
                    Results = new List<FarmResultDefinition>()
                    {
                        new FarmResultDefinition()
                        {
                            Product =FoodConstants.CHAMPIGNONS_ID,
                            BaseFactor = new Vector2(3, 12),
                            AllowDecimal = false,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_FACTOR,
                            ChanceToGenerate = 50
                        }
                    }
                }
            },
            {
                SeedsAndFertilizerConstants.AMANITAMUSCARIA_SEEDS_ID, new FarmDefinition()
                {
                    FertilizerFactor = BASE_FERTILIZER_FACTOR,
                    IceFactor = BASE_ICE_FACTOR,
                    SeedFactor = BASE_MUSHROOM_SEED_FACTOR,
                    SunRequired = false,
                    TimeToProduceInMs = BASE_TIME_TO_PRODUCE,
                    PreferredFertilizer = SeedsAndFertilizerConstants.MINERALFERTILIZER_ID,
                    Results = new List<FarmResultDefinition>()
                    {
                        new FarmResultDefinition()
                        {
                            Product =FoodConstants.AMANITAMUSCARIA_ID,
                            BaseFactor = new Vector2(3, 12),
                            AllowDecimal = false,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_FACTOR,
                            ChanceToGenerate = 50
                        }
                    }
                }
            },
            {
                SeedsAndFertilizerConstants.BEETROOT_SEEDS_ID, new FarmDefinition()
                {
                    FertilizerFactor = BASE_FERTILIZER_FACTOR,
                    IceFactor = BASE_ICE_FACTOR,
                    SeedFactor = BASE_VEGETABLE_SEED_FACTOR,
                    SunRequired = true,
                    TimeToProduceInMs = BASE_TIME_TO_PRODUCE,
                    PreferredFertilizer = SeedsAndFertilizerConstants.MINERALFERTILIZER_ID,
                    Results = new List<FarmResultDefinition>()
                    {
                        new FarmResultDefinition()
                        {
                            Product =FoodConstants.BEETROOT_ID,
                            BaseFactor = new Vector2(6, 18),
                            AllowDecimal = false,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_FACTOR,
                            ChanceToGenerate = 50
                        }
                    }
                }
            },
            {
                SeedsAndFertilizerConstants.ARNICA_SEEDS_ID, new FarmDefinition()
                {
                    FertilizerFactor = BASE_FERTILIZER_FACTOR,
                    IceFactor = BASE_ICE_FACTOR,
                    SeedFactor = BASE_HERB_SEED_FACTOR,
                    SunRequired = true,
                    TimeToProduceInMs = BASE_TIME_TO_PRODUCE,
                    PreferredFertilizer = SeedsAndFertilizerConstants.FERTILIZER_ID,
                    Results = new List<FarmResultDefinition>()
                    {
                        new FarmResultDefinition()
                        {
                            Product =HerbsConstants.ARNICA_ID,
                            BaseFactor = new Vector2(0.5f, 4.0f),
                            AllowDecimal = true,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_FACTOR,
                            ChanceToGenerate = 50
                        }
                    }
                }
            },
            {
                SeedsAndFertilizerConstants.BROCCOLI_SEEDS_ID, new FarmDefinition()
                {
                    FertilizerFactor = BASE_FERTILIZER_FACTOR,
                    IceFactor = BASE_ICE_FACTOR,
                    SeedFactor = BASE_VEGETABLE_SEED_FACTOR,
                    SunRequired = true,
                    TimeToProduceInMs = BASE_TIME_TO_PRODUCE,
                    PreferredFertilizer = SeedsAndFertilizerConstants.MINERALFERTILIZER_ID,
                    Results = new List<FarmResultDefinition>()
                    {
                        new FarmResultDefinition()
                        {
                            Product =FoodConstants.BROCCOLI_ID,
                            BaseFactor = new Vector2(3, 12),
                            AllowDecimal = false,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_FACTOR,
                            ChanceToGenerate = 50
                        }
                    }
                }
            },
            {
                SeedsAndFertilizerConstants.CARROT_SEEDS_ID, new FarmDefinition()
                {
                    FertilizerFactor = BASE_FERTILIZER_FACTOR,
                    IceFactor = BASE_ICE_FACTOR,
                    SeedFactor = BASE_VEGETABLE_SEED_FACTOR,
                    SunRequired = true,
                    TimeToProduceInMs = BASE_TIME_TO_PRODUCE,
                    PreferredFertilizer = SeedsAndFertilizerConstants.MINERALFERTILIZER_ID,
                    Results = new List<FarmResultDefinition>()
                    {
                        new FarmResultDefinition()
                        {
                            Product =FoodConstants.CAROOT_ID,
                            BaseFactor = new Vector2(6, 18),
                            AllowDecimal = false,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_FACTOR,
                            ChanceToGenerate = 50
                        }
                    }
                }
            },
            {
                SeedsAndFertilizerConstants.COFFEE_SEEDS_ID, new FarmDefinition()
                {
                    FertilizerFactor = BASE_FERTILIZER_FACTOR,
                    IceFactor = BASE_ICE_FACTOR,
                    SeedFactor = BASE_GRAIN_SEED_FACTOR,
                    SunRequired = true,
                    TimeToProduceInMs = BASE_TIME_TO_PRODUCE,
                    PreferredFertilizer = SeedsAndFertilizerConstants.FERTILIZER_ID,
                    Results = new List<FarmResultDefinition>()
                    {
                        new FarmResultDefinition()
                        {
                            Product = OreConstants.COFFEE_ID,
                            BaseFactor = new Vector2(0.5f, 4.0f),
                            AllowDecimal = true,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_FACTOR,
                            ChanceToGenerate = 50
                        }
                    }
                }
            },
            {
                SeedsAndFertilizerConstants.MINT_SEEDS_ID, new FarmDefinition()
                {
                    FertilizerFactor = BASE_FERTILIZER_FACTOR,
                    IceFactor = BASE_ICE_FACTOR,
                    SeedFactor = BASE_HERB_SEED_FACTOR,
                    SunRequired = true,
                    TimeToProduceInMs = BASE_TIME_TO_PRODUCE,
                    PreferredFertilizer = SeedsAndFertilizerConstants.FERTILIZER_ID,
                    Results = new List<FarmResultDefinition>()
                    {
                        new FarmResultDefinition()
                        {
                            Product =HerbsConstants.MINT_ID,
                            BaseFactor = new Vector2(0.5f, 4.0f),
                            AllowDecimal = true,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_FACTOR,
                            ChanceToGenerate = 50
                        }
                    }
                }
            },
            {
                SeedsAndFertilizerConstants.TOMATO_SEEDS_ID, new FarmDefinition()
                {
                    FertilizerFactor = BASE_FERTILIZER_FACTOR,
                    IceFactor = BASE_ICE_FACTOR,
                    SeedFactor = BASE_VEGETABLE_SEED_FACTOR,
                    SunRequired = true,
                    TimeToProduceInMs = BASE_TIME_TO_PRODUCE,
                    PreferredFertilizer = SeedsAndFertilizerConstants.FERTILIZER_ID,
                    Results = new List<FarmResultDefinition>()
                    {
                        new FarmResultDefinition()
                        {
                            Product =FoodConstants.TOMATO_ID,
                            BaseFactor = new Vector2(3, 12),
                            AllowDecimal = false,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_FACTOR,
                            ChanceToGenerate = 50
                        }
                    }
                }
            },
            {
                SeedsAndFertilizerConstants.WHEAT_SEEDS_ID, new FarmDefinition()
                {
                    FertilizerFactor = BASE_FERTILIZER_FACTOR,
                    IceFactor = BASE_ICE_FACTOR,
                    SeedFactor = BASE_GRAIN_SEED_FACTOR,
                    SunRequired = true,
                    TimeToProduceInMs = BASE_TIME_TO_PRODUCE,
                    PreferredFertilizer = SeedsAndFertilizerConstants.FERTILIZER_ID,
                    Results = new List<FarmResultDefinition>()
                    {
                        new FarmResultDefinition()
                        {
                            Product = OreConstants.WHEAT_ID,
                            BaseFactor = new Vector2(0.5f, 4.0f),
                            AllowDecimal = true,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_FACTOR,
                            ChanceToGenerate = 50
                        }
                    }
                }
            },
            {
                SeedsAndFertilizerConstants.CHAMOMILE_SEEDS_ID, new FarmDefinition()
                {
                    FertilizerFactor = BASE_FERTILIZER_FACTOR,
                    IceFactor = BASE_ICE_FACTOR,
                    SeedFactor = BASE_HERB_SEED_FACTOR,
                    SunRequired = true,
                    TimeToProduceInMs = BASE_TIME_TO_PRODUCE,
                    PreferredFertilizer = SeedsAndFertilizerConstants.FERTILIZER_ID,
                    Results = new List<FarmResultDefinition>()
                    {
                        new FarmResultDefinition()
                        {
                            Product =HerbsConstants.CHAMOMILE_ID,
                            BaseFactor = new Vector2(0.5f, 4.0f),
                            AllowDecimal = true,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_FACTOR,
                            ChanceToGenerate = 50
                        }
                    }
                }
            },
            {
                SeedsAndFertilizerConstants.ALOEVERA_SEEDS_ID, new FarmDefinition()
                {
                    FertilizerFactor = BASE_FERTILIZER_FACTOR,
                    IceFactor = BASE_ICE_FACTOR,
                    SeedFactor = BASE_HERB_SEED_FACTOR,
                    SunRequired = true,
                    TimeToProduceInMs = BASE_TIME_TO_PRODUCE,
                    PreferredFertilizer = SeedsAndFertilizerConstants.FERTILIZER_ID,
                    Results = new List<FarmResultDefinition>()
                    {
                        new FarmResultDefinition()
                        {
                            Product =HerbsConstants.ALOEVERA_ID,
                            BaseFactor = new Vector2(0.5f, 4.0f),
                            AllowDecimal = true,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_FACTOR,
                            ChanceToGenerate = 50
                        }
                    }
                }
            },
            {
                SeedsAndFertilizerConstants.ERYTHROXYLUM_SEEDS_ID, new FarmDefinition()
                {
                    FertilizerFactor = BASE_FERTILIZER_FACTOR,
                    IceFactor = BASE_ICE_FACTOR,
                    SeedFactor = BASE_HERB_SEED_FACTOR,
                    SunRequired = true,
                    TimeToProduceInMs = BASE_TIME_TO_PRODUCE,
                    PreferredFertilizer = SeedsAndFertilizerConstants.FERTILIZER_ID,
                    Results = new List<FarmResultDefinition>()
                    {
                        new FarmResultDefinition()
                        {
                            Product =HerbsConstants.ERYTHROXYLUM_ID,
                            BaseFactor = new Vector2(0.5f, 4.0f),
                            AllowDecimal = true,
                            SunMultiplierFactor = BASE_SUN_MULTIPLIER_FACTOR,
                            ChanceToGenerate = 50
                        }
                    }
                }
            }
        };

    }

}