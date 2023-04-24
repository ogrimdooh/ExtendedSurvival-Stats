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
            Name = LanguageProvider.GetEntry(LanguageEntries.ARNICA_SEEDS_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ARNICA_SEEDS_DESCRIPTION),
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
            Name = LanguageProvider.GetEntry(LanguageEntries.BEETROOT_SEEDS_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.BEETROOT_SEEDS_DESCRIPTION),
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
            Name = LanguageProvider.GetEntry(LanguageEntries.BROCCOLI_SEEDS_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.BROCCOLI_SEEDS_DESCRIPTION),
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
            Name = LanguageProvider.GetEntry(LanguageEntries.CARROT_SEEDS_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.CARROT_SEEDS_DESCRIPTION),
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
            Name = LanguageProvider.GetEntry(LanguageEntries.COFFEE_SEEDS_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.COFFEE_SEEDS_DESCRIPTION),
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
            Name = LanguageProvider.GetEntry(LanguageEntries.MINT_SEEDS_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.MINT_SEEDS_DESCRIPTION),
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
            Name = LanguageProvider.GetEntry(LanguageEntries.TOMATO_SEEDS_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.TOMATO_SEEDS_DESCRIPTION),
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
            Name = LanguageProvider.GetEntry(LanguageEntries.WHEAT_SEEDS_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.WHEAT_SEEDS_DESCRIPTION),
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
            Name = LanguageProvider.GetEntry(LanguageEntries.CHAMOMILE_SEEDS_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.CHAMOMILE_SEEDS_DESCRIPTION),
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
            Name = LanguageProvider.GetEntry(LanguageEntries.ALOEVERA_SEEDS_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ALOEVERA_SEEDS_DESCRIPTION),
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
            Name = LanguageProvider.GetEntry(LanguageEntries.ERYTHROXYLUM_SEEDS_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ERYTHROXYLUM_SEEDS_DESCRIPTION),
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
            Name = LanguageProvider.GetEntry(LanguageEntries.FERTILIZER_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.FERTILIZER_DESCRIPTION),
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
                    Name = LanguageProvider.GetEntry(LanguageEntries.BONEFERTILIZER_CONSTRUCTION_NAME),
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
                            Id = OreConstants.BONES_ID,
                            Ammount = 7.5f
                        }
                    }
                },
                new SimpleRecipeDefinition()
                {
                    Name = LanguageProvider.GetEntry(LanguageEntries.POOPFERTILIZER_CONSTRUCTION_NAME),
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
                            Id = OreConstants.POOP_ID,
                            Ammount = 7.5f
                        }
                    }
                },
                new SimpleRecipeDefinition()
                {
                    Name = LanguageProvider.GetEntry(LanguageEntries.SPOILEDMATERIALFERTILIZER_CONSTRUCTION_NAME),
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
            Name = LanguageProvider.GetEntry(LanguageEntries.MINERALFERTILIZER_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.MINERALFERTILIZER_DESCRIPTION),
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
                    Name = LanguageProvider.GetEntry(LanguageEntries.MAGNESIUMFERTILIZER_CONSTRUCTION_NAME),
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
                    Name = LanguageProvider.GetEntry(LanguageEntries.POTASSIUMFERTILIZER_CONSTRUCTION_NAME),
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
                    Name = LanguageProvider.GetEntry(LanguageEntries.FERTILIZER_CONSTRUCTION_NAME),
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
                            Id = ItensConstants.SULFUR_INGOT_ID,
                            Ammount = 2.5f
                        }
                    }
                }
            }
        };

        public static readonly FertilizerDefinition SUPERFERTILIZER_DEFINITION = new FertilizerDefinition()
        {
            Id = SUPERFERTILIZER_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.SUPERFERTILIZER_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.SUPERFERTILIZER_DESCRIPTION),
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
            Name = LanguageProvider.GetEntry(LanguageEntries.TREEDEAD_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.TREEDEAD_DESCRIPTION),
            Mass = 750f,
            Volume = 750f,
            RecipesDefinition = new List<SimpleIngredientRecipeDefinition>()
            {
                new SimpleIngredientRecipeDefinition()
                {
                    Name = LanguageProvider.GetEntry(LanguageEntries.TREEDEAD_DESCONSTRUCTION_NAME),
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
            Name = LanguageProvider.GetEntry(LanguageEntries.APPLETREE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.APPLETREE_DESCRIPTION),
            Mass = 1250f,
            Volume = 1250f,
            RecipesDefinition = new List<SimpleIngredientRecipeDefinition>()
            {
                new SimpleIngredientRecipeDefinition()
                {
                    Name = LanguageProvider.GetEntry(LanguageEntries.APPLETREE_DESCONSTRUCTION_NAME),
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
            Name = LanguageProvider.GetEntry(LanguageEntries.APPLETREESEEDLING_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.APPLETREESEEDLING_DESCRIPTION),
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

        public static void TryOverrideDefinitions()
        {
            PhysicalItemDefinitionOverride.TryOverrideDefinitions<TreeDefinition, MyPhysicalItemDefinition>(TREES_DEFINITIONS);
            PhysicalItemDefinitionOverride.TryOverrideDefinitions<FertilizerDefinition, MyPhysicalItemDefinition>(FERTILIZERS_DEFINITIONS);
            PhysicalItemDefinitionOverride.TryOverrideDefinitions<SeedDefinition, MyPhysicalItemDefinition>(SEEDS_DEFINITIONS);
        }

    }

}