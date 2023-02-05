using Sandbox.Common.ObjectBuilders.Definitions;
using Sandbox.Definitions;
using System;
using System.Collections.Generic;
using VRage.Game;
using VRageMath;

namespace ExtendedSurvival.Stats
{
    public static class SeedsAndFertilizerConstants
    {
        
        public const string ARNICA_SEEDS_SUBTYPEID = "ArnicaSeeds";
        public static readonly UniqueEntityId ARNICA_SEEDS_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), ARNICA_SEEDS_SUBTYPEID);

        public const string BEETROOT_SEEDS_SUBTYPEID = "BeetrootSeeds";
        public static readonly UniqueEntityId BEETROOT_SEEDS_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), BEETROOT_SEEDS_SUBTYPEID);

        public const string BROCCOLI_SEEDS_SUBTYPEID = "BroccoliSeeds";
        public static readonly UniqueEntityId BROCCOLI_SEEDS_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), BROCCOLI_SEEDS_SUBTYPEID);

        public const string CARROT_SEEDS_SUBTYPEID = "CarrotSeeds";
        public static readonly UniqueEntityId CARROT_SEEDS_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), CARROT_SEEDS_SUBTYPEID);

        public const string COFFEE_SEEDS_SUBTYPEID = "CoffeeSeeds";
        public static readonly UniqueEntityId COFFEE_SEEDS_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), COFFEE_SEEDS_SUBTYPEID);

        public const string MINT_SEEDS_SUBTYPEID = "MintSeeds";
        public static readonly UniqueEntityId MINT_SEEDS_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), MINT_SEEDS_SUBTYPEID);

        public const string TOMATO_SEEDS_SUBTYPEID = "TomatoSeeds";
        public static readonly UniqueEntityId TOMATO_SEEDS_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), TOMATO_SEEDS_SUBTYPEID);

        public const string WHEAT_SEEDS_SUBTYPEID = "WheatSeeds";
        public static readonly UniqueEntityId WHEAT_SEEDS_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), WHEAT_SEEDS_SUBTYPEID);

        public const string CHAMOMILE_SEEDS_SUBTYPEID = "ChamomileSeeds";
        public static readonly UniqueEntityId CHAMOMILE_SEEDS_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), CHAMOMILE_SEEDS_SUBTYPEID);

        public const string ALOEVERA_SEEDS_SUBTYPEID = "AloeVeraSeeds";
        public static readonly UniqueEntityId ALOEVERA_SEEDS_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), ALOEVERA_SEEDS_SUBTYPEID);

        public const string ERYTHROXYLUM_SEEDS_SUBTYPEID = "ErythroxylumSeeds";
        public static readonly UniqueEntityId ERYTHROXYLUM_SEEDS_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), ERYTHROXYLUM_SEEDS_SUBTYPEID);

        public const string FERTILIZER_SUBTYPEID = "Fertilizer";
        public static readonly UniqueEntityId FERTILIZER_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), FERTILIZER_SUBTYPEID);

        public const string MINERALFERTILIZER_SUBTYPEID = "MineralFertilizer";
        public static readonly UniqueEntityId MINERALFERTILIZER_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), MINERALFERTILIZER_SUBTYPEID);

        public const string SUPERFERTILIZER_SUBTYPEID = "SuperFertilizer";
        public static readonly UniqueEntityId SUPERFERTILIZER_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), SUPERFERTILIZER_SUBTYPEID);

        public const string TREEDEAD_SUBTYPEID = "TreeDead";
        public static readonly UniqueEntityId TREEDEAD_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), TREEDEAD_SUBTYPEID);

        public const string APPLETREESEEDLING_SUBTYPEID = "AppleTreeSeedling";
        public static readonly UniqueEntityId APPLETREESEEDLING_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), APPLETREESEEDLING_SUBTYPEID);

        public const string APPLETREE_SUBTYPEID = "AppleTree";
        public static readonly UniqueEntityId APPLETREE_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), APPLETREE_SUBTYPEID);

        public static readonly SeedDefinition ARNICA_SEEDS_DEFINITION = new SeedDefinition()
        {
            Id = ARNICA_SEEDS_ID,
            Name = "Arnica Seeds",
            Description = "Arnica seeds can be grown with fertilizer and ice on farms.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 1250,
            OfferAmount = new Vector2I(1000, 3000),
            OrderAmount = new Vector2I(250, 750),
            AcquisitionAmount = new Vector2I(500, 1500),
            Mass = 1f,
            Volume = 0.25f
        };

        public static readonly SeedDefinition BEETROOT_SEEDS_DEFINITION = new SeedDefinition()
        {
            Id = BEETROOT_SEEDS_ID,
            Name = "Beetroot Seeds",
            Description = "Beetroot seeds can be grown with fertilizer and ice on farms.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 625,
            OfferAmount = new Vector2I(1000, 3000),
            OrderAmount = new Vector2I(250, 750),
            AcquisitionAmount = new Vector2I(500, 1500),
            Mass = 1f,
            Volume = 0.25f
        };

        public static readonly SeedDefinition BROCCOLI_SEEDS_DEFINITION = new SeedDefinition()
        {
            Id = BROCCOLI_SEEDS_ID,
            Name = "Broccoli Seeds",
            Description = "Broccoli seeds can be grown with fertilizer and ice on farms.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 625,
            OfferAmount = new Vector2I(1000, 3000),
            OrderAmount = new Vector2I(250, 750),
            AcquisitionAmount = new Vector2I(500, 1500),
            Mass = 1f,
            Volume = 0.25f
        };

        public static readonly SeedDefinition CARROT_SEEDS_DEFINITION = new SeedDefinition()
        {
            Id = CARROT_SEEDS_ID,
            Name = "Carrot Seeds",
            Description = "Carrot seeds can be grown with fertilizer and ice on farms.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 625,
            OfferAmount = new Vector2I(1000, 3000),
            OrderAmount = new Vector2I(250, 750),
            AcquisitionAmount = new Vector2I(500, 1500),
            Mass = 1f,
            Volume = 0.25f
        };

        public static readonly SeedDefinition COFFEE_SEEDS_DEFINITION = new SeedDefinition()
        {
            Id = COFFEE_SEEDS_ID,
            Name = "Coffee Seeds",
            Description = "Coffee seeds can be grown with fertilizer and ice on farms.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 1250,
            OfferAmount = new Vector2I(1000, 3000),
            OrderAmount = new Vector2I(250, 750),
            AcquisitionAmount = new Vector2I(500, 1500),
            Mass = 1f,
            Volume = 0.25f
        };

        public static readonly SeedDefinition MINT_SEEDS_DEFINITION = new SeedDefinition()
        {
            Id = MINT_SEEDS_ID,
            Name = "Mint Seeds",
            Description = "Mint seeds can be grown with fertilizer and ice on farms.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 625,
            OfferAmount = new Vector2I(1000, 3000),
            OrderAmount = new Vector2I(250, 750),
            AcquisitionAmount = new Vector2I(500, 1500),
            Mass = 1f,
            Volume = 0.25f
        };

        public static readonly SeedDefinition TOMATO_SEEDS_DEFINITION = new SeedDefinition()
        {
            Id = TOMATO_SEEDS_ID,
            Name = "Tomato Seeds",
            Description = "Tomato seeds can be grown with fertilizer and ice on farms.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 625,
            OfferAmount = new Vector2I(1000, 3000),
            OrderAmount = new Vector2I(250, 750),
            AcquisitionAmount = new Vector2I(500, 1500),
            Mass = 1f,
            Volume = 0.25f
        };

        public static readonly SeedDefinition WHEAT_SEEDS_DEFINITION = new SeedDefinition()
        {
            Id = WHEAT_SEEDS_ID,
            Name = "Wheat Seeds",
            Description = "Wheat seeds can be grown with fertilizer and ice on farms.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 1250,
            OfferAmount = new Vector2I(1000, 3000),
            OrderAmount = new Vector2I(250, 750),
            AcquisitionAmount = new Vector2I(500, 1500),
            Mass = 1f,
            Volume = 0.25f
        };

        public static readonly SeedDefinition CHAMOMILE_SEEDS_DEFINITION = new SeedDefinition()
        {
            Id = CHAMOMILE_SEEDS_ID,
            Name = "Chamomile Seeds",
            Description = "Chamomile seeds can be grown with fertilizer and ice on farms.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 625,
            OfferAmount = new Vector2I(1000, 3000),
            OrderAmount = new Vector2I(250, 750),
            AcquisitionAmount = new Vector2I(500, 1500),
            Mass = 1f,
            Volume = 0.25f
        };

        public static readonly SeedDefinition ALOEVERA_SEEDS_DEFINITION = new SeedDefinition()
        {
            Id = ALOEVERA_SEEDS_ID,
            Name = "Aloevera Seeds",
            Description = "Aloevera seeds can be grown with fertilizer and ice on farms.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 625,
            OfferAmount = new Vector2I(1000, 3000),
            OrderAmount = new Vector2I(250, 750),
            AcquisitionAmount = new Vector2I(500, 1500),
            Mass = 1f,
            Volume = 0.25f
        };

        public static readonly SeedDefinition ERYTHROXYLUM_SEEDS_DEFINITION = new SeedDefinition()
        {
            Id = ERYTHROXYLUM_SEEDS_ID,
            Name = "Erythroxylum Seeds",
            Description = "Erythroxylum seeds can be grown with fertilizer and ice on farms.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 625,
            OfferAmount = new Vector2I(1000, 3000),
            OrderAmount = new Vector2I(250, 750),
            AcquisitionAmount = new Vector2I(500, 1500),
            Mass = 1f,
            Volume = 0.25f
        };

        public static readonly Dictionary<UniqueEntityId, SeedDefinition> SEEDS_DEFINITIONS = new Dictionary<UniqueEntityId, SeedDefinition>()
        {
            { ARNICA_SEEDS_ID, ARNICA_SEEDS_DEFINITION },
            { BEETROOT_SEEDS_ID, BEETROOT_SEEDS_DEFINITION },
            { BROCCOLI_SEEDS_ID, BROCCOLI_SEEDS_DEFINITION },
            { CARROT_SEEDS_ID, CARROT_SEEDS_DEFINITION },
            { COFFEE_SEEDS_ID, COFFEE_SEEDS_DEFINITION },
            { MINT_SEEDS_ID, MINT_SEEDS_DEFINITION },
            { TOMATO_SEEDS_ID, TOMATO_SEEDS_DEFINITION },
            { WHEAT_SEEDS_ID, WHEAT_SEEDS_DEFINITION },
            { CHAMOMILE_SEEDS_ID, CHAMOMILE_SEEDS_DEFINITION },
            { ALOEVERA_SEEDS_ID, ALOEVERA_SEEDS_DEFINITION },
            { ERYTHROXYLUM_SEEDS_ID, ERYTHROXYLUM_SEEDS_DEFINITION }
        };

        public static readonly FertilizerDefinition FERTILIZER_DEFINITION = new FertilizerDefinition()
        {
            Id = FERTILIZER_ID,
            Name = "Organic Fertilizer",
            Description = "Fertilizer made from organic matter.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 4500,
            OfferAmount = new Vector2I(100, 300),
            OrderAmount = new Vector2I(25, 75),
            AcquisitionAmount = new Vector2I(50, 150),
            Mass = 20f,
            Volume = 12f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    Name = "Organic Fertilizer From Bone Meal",
                    RecipeName = "BoneFertilizer_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SOILPOWDER_ID,
                            Ammount = 15f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CARBON_INGOT_ID,
                            Ammount = 5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.BONES_ID,
                            Ammount = 7.5f
                        }
                    }
                },
                new SimpleRecipeDefinition()
                {
                    Name = "Organic Fertilizer From Poop",
                    RecipeName = "PoopFertilizer_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SOILPOWDER_ID,
                            Ammount = 15f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CARBON_INGOT_ID,
                            Ammount = 5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.POOP_ID,
                            Ammount = 7.5f
                        }
                    }
                },
                new SimpleRecipeDefinition()
                {
                    Name = "Organic Fertilizer From Organic Material",
                    RecipeName = "SpoiledMaterialFertilizer_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SOILPOWDER_ID,
                            Ammount = 15f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CARBON_INGOT_ID,
                            Ammount = 5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SPOILED_MATERIAL_ID,
                            Ammount = 7.5f
                        }
                    }
                }
            }
        };

        public static readonly FertilizerDefinition MINERALFERTILIZER_DEFINITION = new FertilizerDefinition()
        {
            Id = MINERALFERTILIZER_ID,
            Name = "Mineral Fertilizer",
            Description = "Fertilizer made from mineral matter.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 9000,
            OfferAmount = new Vector2I(100, 300),
            OrderAmount = new Vector2I(25, 75),
            AcquisitionAmount = new Vector2I(50, 150),
            Mass = 20f,
            Volume = 12f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    Name = "Mineral Fertilizer From Magnesium",
                    RecipeName = "MagnesiumFertilizer_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SOILPOWDER_ID,
                            Ammount = 15f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CARBON_INGOT_ID,
                            Ammount = 5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.MAGNESIUM_INGOT_ID,
                            Ammount = 2.5f
                        }
                    }
                },
                new SimpleRecipeDefinition()
                {
                    Name = "Mineral Fertilizer From Potassium",
                    RecipeName = "PotassiumFertilizer_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SOILPOWDER_ID,
                            Ammount = 15f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CARBON_INGOT_ID,
                            Ammount = 5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.POTASSIUM_INGOT_ID,
                            Ammount = 2.5f
                        }
                    }
                },
                new SimpleRecipeDefinition()
                {
                    Name = "Mineral Fertilizer From Sulfur",
                    RecipeName = "Fertilizer_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SOILPOWDER_ID,
                            Ammount = 15f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CARBON_INGOT_ID,
                            Ammount = 5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SULFOR_INGOT_ID,
                            Ammount = 2.5f
                        }
                    }
                }
            }
        };

        public static readonly FertilizerDefinition SUPERFERTILIZER_DEFINITION = new FertilizerDefinition()
        {
            Id = SUPERFERTILIZER_ID,
            Name = "Super Fertilizer",
            Description = "Mixture of mineral and organic fertilizers," + Environment.NewLine + 
                          "can be used efficiently with all seeds.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 18000,
            OfferAmount = new Vector2I(100, 300),
            OrderAmount = new Vector2I(25, 75),
            AcquisitionAmount = new Vector2I(50, 150),
            Mass = 20f,
            Volume = 12f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    Name = "Super Fertilizer",
                    RecipeName = "SuperFertilizer_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 2.56f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = FERTILIZER_ID,
                            Ammount = 0.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = MINERALFERTILIZER_ID,
                            Ammount = 0.5f
                        }
                    }
                }
            }
        };

        public static readonly Dictionary<UniqueEntityId, FertilizerDefinition> FERTILIZERS_DEFINITIONS = new Dictionary<UniqueEntityId, FertilizerDefinition>()
        {
            { FERTILIZER_ID, FERTILIZER_DEFINITION },
            { MINERALFERTILIZER_ID, MINERALFERTILIZER_DEFINITION },
            { SUPERFERTILIZER_ID, SUPERFERTILIZER_DEFINITION }
        };

        public static readonly TreeDefinition TREEDEAD_DEFINITION = new TreeDefinition()
        {
            Id = TREEDEAD_ID,
            Name = "Dead Tree",
            Description = "A dead tree can be turned into wood in a grinder.",
            Mass = 750f,
            Volume = 750f,
            RecipesDefinition = new List<SimpleIngredientRecipeDefinition>()
            {
                new SimpleIngredientRecipeDefinition()
                {
                    Name = "Wood Logs From Dead Tree",
                    RecipeName = "TreeDead_Desconstruction",
                    IngredientAmmount = 1,
                    ProductionTime = 10.24f,
                    Results = new SimpleIngredientRecipeDefinition.RecipeItem[]
                    {
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.WOODLOG_ID,
                            Ammount = 60
                        },
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.BRANCH_ID,
                            Ammount = 15
                        },
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TWIG_ID,
                            Ammount = 25
                        },
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.LEAF_ID,
                            Ammount = 10
                        }
                    }
                }
            }
        };

        public static readonly TreeDefinition APPLETREE_DEFINITION = new TreeDefinition()
        {
            Id = APPLETREE_ID,
            Name = "Apple Tree",
            Description = "Can generate apples and saplings if placed with fertilizer" + Environment.NewLine +
                          "and ice in a tree farm, also can be turned into wood in a" + Environment.NewLine + 
                          "grinder.",
            Mass = 1250f,
            Volume = 1250f,
            RecipesDefinition = new List<SimpleIngredientRecipeDefinition>()
            {
                new SimpleIngredientRecipeDefinition()
                {
                    Name = "Wood Logs From Apple Tree",
                    RecipeName = "AppleTree_Desconstruction",
                    IngredientAmmount = 1,
                    ProductionTime = 10.24f,
                    Results = new SimpleIngredientRecipeDefinition.RecipeItem[]
                    {
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.WOODLOG_ID,
                            Ammount = 80
                        },
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.BRANCH_ID,
                            Ammount = 20
                        },
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TWIG_ID,
                            Ammount = 30
                        },
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.LEAF_ID,
                            Ammount = 30
                        }
                    }
                }
            }
        };

        public static readonly TreeDefinition APPLETREESEEDLING_DEFINITION = new TreeDefinition()
        {
            Id = APPLETREESEEDLING_ID,
            Name = "Apple Tree Seedling",
            Description = "Can grow into an apple tree if placed with fertilizer" + Environment.NewLine + 
                          "and ice in a tree farm.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 12500,
            OfferAmount = new Vector2I(10, 30),
            OrderAmount = new Vector2I(5, 15),
            AcquisitionAmount = new Vector2I(20, 40),
            Mass = 2.5f,
            Volume = 2.5f
        };

        public static readonly Dictionary<UniqueEntityId, TreeDefinition> TREES_DEFINITIONS = new Dictionary<UniqueEntityId, TreeDefinition>()
        {
            { APPLETREESEEDLING_ID, APPLETREESEEDLING_DEFINITION },
            { APPLETREE_ID, APPLETREE_DEFINITION },
            { TREEDEAD_ID, TREEDEAD_DEFINITION }
        };

        private static void TryOverrideSeedsDefinitions()
        {
            try
            {
                var targetFaction = FactionTypeConstants.FACTION_TYPES_DEFINITIONS[FactionTypeConstants.TRADER_ID];
                // Override medical definition
                foreach (var seed in SEEDS_DEFINITIONS.Keys)
                {
                    var seedDef = SEEDS_DEFINITIONS[seed];
                    // Item definition
                    var itemDef = DefinitionUtils.TryGetDefinition<MyPhysicalItemDefinition>(seed.subtypeId.String);
                    if (itemDef != null)
                    {
                        itemDef.Volume = seedDef.GetVolume();
                        itemDef.Mass = seedDef.GetMass();
                        itemDef.DisplayNameEnum = null;
                        itemDef.DisplayNameString = seedDef.Name;
                        itemDef.DescriptionEnum = null;
                        itemDef.DescriptionString = null;
                        itemDef.MinimumAcquisitionAmount = seedDef.AcquisitionAmount.X;
                        itemDef.MaximumAcquisitionAmount = seedDef.AcquisitionAmount.Y;
                        itemDef.MinimumOrderAmount = seedDef.OrderAmount.X;
                        itemDef.MaximumOrderAmount = seedDef.OrderAmount.Y;
                        itemDef.MinimumOfferAmount = seedDef.OfferAmount.X;
                        itemDef.MaximumOfferAmount = seedDef.OfferAmount.Y;
                        itemDef.MinimalPricePerUnit = seedDef.MinimalPricePerUnit;
                        itemDef.CanPlayerOrder = seedDef.CanPlayerOrder;
                        itemDef.ExtraInventoryTooltipLine.AppendLine(Environment.NewLine + seedDef.GetFullDescription());
                        itemDef.Postprocess();
                    }
                    else
                        ExtendedSurvivalStatsLogging.Instance.LogInfo(typeof(SeedsAndFertilizerConstants), $"TryOverrideRecipes item not found. Food=[{seed}]");
                    // Add itens to faction types
                    if (seedDef.CanPlayerOrder)
                    {
                        targetFaction.OffersList.Add(seed);
                        targetFaction.OrdersList.Add(seed);
                    }
                }
            }
            catch (System.Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(typeof(SeedsAndFertilizerConstants), ex);
            }
        }

        private static void TryOverrideFertilizerDefinitions()
        {
            try
            {
                var targetFaction = FactionTypeConstants.FACTION_TYPES_DEFINITIONS[FactionTypeConstants.TRADER_ID];
                // Override medical definition
                foreach (var fertilizer in FERTILIZERS_DEFINITIONS.Keys)
                {
                    var fertilizerDef = FERTILIZERS_DEFINITIONS[fertilizer];
                    // Item definition
                    var itemDef = DefinitionUtils.TryGetDefinition<MyPhysicalItemDefinition>(fertilizer.subtypeId.String);
                    if (itemDef != null)
                    {
                        itemDef.Volume = fertilizerDef.GetVolume();
                        itemDef.Mass = fertilizerDef.GetMass();
                        itemDef.DisplayNameEnum = null;
                        itemDef.DisplayNameString = fertilizerDef.Name;
                        itemDef.DescriptionEnum = null;
                        itemDef.DescriptionString = null;
                        itemDef.MinimumAcquisitionAmount = fertilizerDef.AcquisitionAmount.X;
                        itemDef.MaximumAcquisitionAmount = fertilizerDef.AcquisitionAmount.Y;
                        itemDef.MinimumOrderAmount = fertilizerDef.OrderAmount.X;
                        itemDef.MaximumOrderAmount = fertilizerDef.OrderAmount.Y;
                        itemDef.MinimumOfferAmount = fertilizerDef.OfferAmount.X;
                        itemDef.MaximumOfferAmount = fertilizerDef.OfferAmount.Y;
                        itemDef.MinimalPricePerUnit = fertilizerDef.MinimalPricePerUnit;
                        itemDef.CanPlayerOrder = fertilizerDef.CanPlayerOrder;
                        itemDef.ExtraInventoryTooltipLine.AppendLine(Environment.NewLine + fertilizerDef.GetFullDescription());
                        itemDef.Postprocess();
                    }
                    else
                        ExtendedSurvivalStatsLogging.Instance.LogInfo(typeof(SeedsAndFertilizerConstants), $"TryOverrideRecipes item not found. Food=[{fertilizer}]");
                    // Recipe definition
                    foreach (var recipe in fertilizerDef.RecipesDefinition)
                    {
                        var recipeDef = DefinitionUtils.TryGetBlueprintDefinition(recipe.RecipeName);
                        if (recipeDef != null)
                        {
                            recipeDef.Prerequisites = recipe.GetIngredients();
                            recipeDef.Results = recipe.GetProduct(fertilizerDef.Id);
                            recipeDef.BaseProductionTimeInSeconds = recipe.ProductionTime;
                            recipeDef.DisplayNameEnum = null;
                            recipeDef.DisplayNameString = fertilizerDef.Name;
                            recipeDef.DescriptionEnum = null;
                            recipeDef.DescriptionString = null;
                            recipeDef.Postprocess();
                        }
                        else
                            ExtendedSurvivalStatsLogging.Instance.LogInfo(typeof(SeedsAndFertilizerConstants), $"TryOverrideDefinitions recipe not found. Recipe=[{recipe.RecipeName}]");
                    }
                    // Add itens to faction types
                    if (fertilizerDef.CanPlayerOrder)
                    {
                        targetFaction.OffersList.Add(fertilizer);
                        targetFaction.OrdersList.Add(fertilizer);
                    }
                }
            }
            catch (System.Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(typeof(SeedsAndFertilizerConstants), ex);
            }
        }

        private static void TryOverrideTreeDefinitions()
        {
            try
            {
                var targetFaction = FactionTypeConstants.FACTION_TYPES_DEFINITIONS[FactionTypeConstants.TRADER_ID];
                // Override medical definition
                foreach (var tree in TREES_DEFINITIONS.Keys)
                {
                    var treeDef = TREES_DEFINITIONS[tree];
                    // Item definition
                    var itemDef = DefinitionUtils.TryGetDefinition<MyPhysicalItemDefinition>(tree.subtypeId.String);
                    if (itemDef != null)
                    {
                        itemDef.Volume = treeDef.GetVolume();
                        itemDef.Mass = treeDef.GetMass();
                        itemDef.DisplayNameEnum = null;
                        itemDef.DisplayNameString = treeDef.Name;
                        itemDef.DescriptionEnum = null;
                        itemDef.DescriptionString = null;
                        itemDef.MinimumAcquisitionAmount = treeDef.AcquisitionAmount.X;
                        itemDef.MaximumAcquisitionAmount = treeDef.AcquisitionAmount.Y;
                        itemDef.MinimumOrderAmount = treeDef.OrderAmount.X;
                        itemDef.MaximumOrderAmount = treeDef.OrderAmount.Y;
                        itemDef.MinimumOfferAmount = treeDef.OfferAmount.X;
                        itemDef.MaximumOfferAmount = treeDef.OfferAmount.Y;
                        itemDef.MinimalPricePerUnit = treeDef.MinimalPricePerUnit;
                        itemDef.CanPlayerOrder = treeDef.CanPlayerOrder;
                        itemDef.ExtraInventoryTooltipLine.AppendLine(Environment.NewLine + treeDef.GetFullDescription());
                        itemDef.Postprocess();
                    }
                    else
                        ExtendedSurvivalStatsLogging.Instance.LogInfo(typeof(SeedsAndFertilizerConstants), $"TryOverrideRecipes item not found. Food=[{tree}]");
                    // Recipe definition
                    foreach (var recipe in treeDef.RecipesDefinition)
                    {
                        var recipeDef = DefinitionUtils.TryGetBlueprintDefinition(recipe.RecipeName);
                        if (recipeDef != null)
                        {
                            recipeDef.Prerequisites = recipe.GetIngredients(treeDef.Id);
                            recipeDef.Results = recipe.GetProduct();
                            recipeDef.BaseProductionTimeInSeconds = recipe.ProductionTime;
                            recipeDef.DisplayNameEnum = null;
                            recipeDef.DisplayNameString = treeDef.Name;
                            recipeDef.DescriptionEnum = null;
                            recipeDef.DescriptionString = null;
                            recipeDef.Postprocess();
                        }
                        else
                            ExtendedSurvivalStatsLogging.Instance.LogInfo(typeof(SeedsAndFertilizerConstants), $"TryOverrideDefinitions recipe not found. Recipe=[{recipe.RecipeName}]");
                    }
                    // Add itens to faction types
                    if (treeDef.CanPlayerOrder)
                    {
                        targetFaction.OffersList.Add(tree);
                        targetFaction.OrdersList.Add(tree);
                    }
                }
            }
            catch (System.Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(typeof(SeedsAndFertilizerConstants), ex);
            }
        }

        public static void TryOverrideDefinitions()
        {
            TryOverrideSeedsDefinitions();
            TryOverrideFertilizerDefinitions();
            TryOverrideTreeDefinitions();
        }

    }

}