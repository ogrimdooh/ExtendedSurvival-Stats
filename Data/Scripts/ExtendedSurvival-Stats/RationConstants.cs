using Sandbox.Definitions;
using System.Collections.Generic;
using VRage.Game;
using VRageMath;

namespace ExtendedSurvival.Stats
{
    public static class RationConstants
    {

        public const string MEATRATION_SUBTYPEID = "MeatRation";
        public static readonly UniqueEntityId MEATRATION_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), MEATRATION_SUBTYPEID);

        public const string VEGETABLERATION_SUBTYPEID = "VegetablesRation";
        public static readonly UniqueEntityId VEGETABLERATION_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), VEGETABLERATION_SUBTYPEID);

        public const string GRAINSRATION_SUBTYPEID = "GrainsRation";
        public static readonly UniqueEntityId GRAINSRATION_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), GRAINSRATION_SUBTYPEID);

        public static readonly RationDefinition MEATRATION_DEFINITION = new RationDefinition()
        {
            Id = MEATRATION_ID,
            Name = "Meat Ration",
            Description = "A meat-based feed, perfect for carnivorous animals.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 15000,
            OfferAmount = new Vector2I(100, 300),
            OrderAmount = new Vector2I(25, 75),
            AcquisitionAmount = new Vector2I(50, 150),
            Mass = 6.0f,
            Volume = 3.0f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    Name = "Meat Ration",
                    RecipeName = "MeatRation_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.MEAT_ID,
                            Ammount = 12
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ICE_ID,
                            Ammount = 4
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CARBON_INGOT_ID,
                            Ammount = 1.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILICON_INGOT_ID,
                            Ammount = 0.25f
                        }
                    }
                },
                new SimpleRecipeDefinition()
                {
                    Name = "Alien Meat Ration",
                    RecipeName = "AlienMeatRation_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ALIEN_MEAT_ID,
                            Ammount = 12
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ICE_ID,
                            Ammount = 4
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CARBON_INGOT_ID,
                            Ammount = 1.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILICON_INGOT_ID,
                            Ammount = 0.25f
                        }
                    }
                },
                new SimpleRecipeDefinition()
                {
                    Name = "Noble Meat Ration",
                    RecipeName = "NobleMeatRation_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NOBLE_MEAT_ID,
                            Ammount = 6
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ICE_ID,
                            Ammount = 4.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CARBON_INGOT_ID,
                            Ammount = 1.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILICON_INGOT_ID,
                            Ammount = 0.25f
                        }
                    }
                },
                new SimpleRecipeDefinition()
                {
                    Name = "Alien Noble Meat Ration",
                    RecipeName = "AlienNobleMeatRation_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ALIEN_NOBLE_MEAT_ID,
                            Ammount = 6
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ICE_ID,
                            Ammount = 4.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CARBON_INGOT_ID,
                            Ammount = 1.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILICON_INGOT_ID,
                            Ammount = 0.25f
                        }
                    }
                },
                new SimpleRecipeDefinition()
                {
                    Name = "Fish Meat Ration",
                    RecipeName = "FishMeatRation_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.FISHMEAT_ID,
                            Ammount = 16
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ICE_ID,
                            Ammount = 4f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CARBON_INGOT_ID,
                            Ammount = 1.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILICON_INGOT_ID,
                            Ammount = 0.25f
                        }
                    }
                },
                new SimpleRecipeDefinition()
                {
                    Name = "Noble Fish Meat Ration",
                    RecipeName = "NobleFishMeatRation_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NOBLEFISHMEAT_ID,
                            Ammount = 8
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ICE_ID,
                            Ammount = 4.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CARBON_INGOT_ID,
                            Ammount = 1.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILICON_INGOT_ID,
                            Ammount = 0.25f
                        }
                    }
                }
            }
        };

        public static readonly RationDefinition VEGETABLERATION_DEFINITION = new RationDefinition()
        {
            Id = VEGETABLERATION_ID,
            Name = "Vegetables Ration",
            Description = "A vegetable-based feed, perfect for herbivorous animals.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 15000,
            OfferAmount = new Vector2I(100, 300),
            OrderAmount = new Vector2I(25, 75),
            AcquisitionAmount = new Vector2I(50, 150),
            Mass = 6.0f,
            Volume = 3.0f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    Name = "Broccoli Ration",
                    RecipeName = "BroccoliRation_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.BROCCOLI_ID,
                            Ammount = 12
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ICE_ID,
                            Ammount = 4
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CARBON_INGOT_ID,
                            Ammount = 1.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILICON_INGOT_ID,
                            Ammount = 0.25f
                        }
                    }
                },
                new SimpleRecipeDefinition()
                {
                    Name = "Beetroot Ration",
                    RecipeName = "BeetrootRation_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.BEETROOT_ID,
                            Ammount = 12
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ICE_ID,
                            Ammount = 4
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CARBON_INGOT_ID,
                            Ammount = 1.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILICON_INGOT_ID,
                            Ammount = 0.25f
                        }
                    }
                },
                new SimpleRecipeDefinition()
                {
                    Name = "Carrot Ration",
                    RecipeName = "CarrotRation_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CAROOT_ID,
                            Ammount = 12
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ICE_ID,
                            Ammount = 4
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CARBON_INGOT_ID,
                            Ammount = 1.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILICON_INGOT_ID,
                            Ammount = 0.25f
                        }
                    }
                }
            }
        };

        public static readonly RationDefinition GRAINSRATION_DEFINITION = new RationDefinition()
        {
            Id = GRAINSRATION_ID,
            Name = "Grains Ration",
            Description = "A grain-based feed, perfect for birds.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 15000,
            OfferAmount = new Vector2I(100, 300),
            OrderAmount = new Vector2I(25, 75),
            AcquisitionAmount = new Vector2I(50, 150),
            Mass = 6.0f,
            Volume = 3.0f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    Name = "Wheat Ration",
                    RecipeName = "WheatRation_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.WHEATSACK_ID,
                            Ammount = 1.35f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ICE_ID,
                            Ammount = 3.3f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CARBON_INGOT_ID,
                            Ammount = 1.35f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILICON_INGOT_ID,
                            Ammount = 0.25f
                        }
                    }
                },
                new SimpleRecipeDefinition()
                {
                    Name = "Cereal Ration",
                    RecipeName = "CerealRation_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CEREAL_ID,
                            Ammount = 1.35f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ICE_ID,
                            Ammount = 3.3f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CARBON_INGOT_ID,
                            Ammount = 1.35f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILICON_INGOT_ID,
                            Ammount = 0.25f
                        }
                    }
                }
            }
        };

        public static readonly Dictionary<UniqueEntityId, RationDefinition> RATIONS_DEFINITIONS = new Dictionary<UniqueEntityId, RationDefinition>()
        {
            { MEATRATION_ID, MEATRATION_DEFINITION },
            { VEGETABLERATION_ID, VEGETABLERATION_DEFINITION },
            { GRAINSRATION_ID, GRAINSRATION_DEFINITION }
        };

        public static void TryOverrideDefinitions()
        {
            try
            {
                var targetFaction = FactionTypeConstants.FACTION_TYPES_DEFINITIONS[FactionTypeConstants.TRADER_ID];
                // Override medical definition
                foreach (var ration in RATIONS_DEFINITIONS.Keys)
                {
                    var rationDef = RATIONS_DEFINITIONS[ration];
                    // Item definition
                    var consumableDef = DefinitionUtils.TryGetDefinition<MyPhysicalItemDefinition>(ration.subtypeId.String);
                    if (consumableDef != null)
                    {                        
                        consumableDef.Volume = rationDef.Volume;
                        consumableDef.Mass = rationDef.Mass;
                        consumableDef.DisplayNameEnum = null;
                        consumableDef.DisplayNameString = rationDef.Name;
                        consumableDef.DescriptionEnum = null;
                        consumableDef.DescriptionString = rationDef.GetFullDescription();
                        consumableDef.MinimumAcquisitionAmount = rationDef.AcquisitionAmount.X;
                        consumableDef.MaximumAcquisitionAmount = rationDef.AcquisitionAmount.Y;
                        consumableDef.MinimumOrderAmount = rationDef.OrderAmount.X;
                        consumableDef.MaximumOrderAmount = rationDef.OrderAmount.Y;
                        consumableDef.MinimumOfferAmount = rationDef.OfferAmount.X;
                        consumableDef.MaximumOfferAmount = rationDef.OfferAmount.Y;
                        consumableDef.MinimalPricePerUnit = rationDef.MinimalPricePerUnit;
                        consumableDef.CanPlayerOrder = rationDef.CanPlayerOrder;
                        consumableDef.Postprocess();
                    }
                    else
                        ExtendedSurvivalStatsLogging.Instance.LogInfo(typeof(FoodConstants), $"TryOverrideRecipes item not found. Food=[{ration}]");
                    // Recipe definition
                    foreach (var recipe in rationDef.RecipesDefinition)
                    {
                        var recipeDef = DefinitionUtils.TryGetBlueprintDefinition(recipe.RecipeName);
                        if (recipeDef != null)
                        {
                            recipeDef.Prerequisites = recipe.GetIngredients();
                            recipeDef.Results = recipe.GetProduct(rationDef.Id);
                            recipeDef.BaseProductionTimeInSeconds = recipe.ProductionTime;
                            recipeDef.DisplayNameEnum = null;
                            recipeDef.DisplayNameString = recipe.Name;
                            recipeDef.DescriptionEnum = null;
                            recipeDef.DescriptionString = rationDef.GetFullDescription();
                            recipeDef.Postprocess();
                        }
                        else
                            ExtendedSurvivalStatsLogging.Instance.LogInfo(typeof(RationConstants), $"TryOverrideDefinitions recipe not found. Recipe=[{recipe.RecipeName}]");
                    }                    
                    // Add itens to faction types
                    if (rationDef.CanPlayerOrder)
                    {
                        targetFaction.OffersList.Add(ration);
                        targetFaction.OrdersList.Add(ration);
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