using Sandbox.Definitions;
using System;
using System.Collections.Generic;
using VRage.Game;
using VRageMath;

namespace ExtendedSurvival.Stats
{

    public static class FishingConstants
    {

        public const string FISH_SUBTYPEID = "Fish";
        public static readonly UniqueEntityId FISH_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), FISH_SUBTYPEID);

        public const string ALIENFISH_SUBTYPEID = "AlienFish";
        public static readonly UniqueEntityId ALIENFISH_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), ALIENFISH_SUBTYPEID);

        public const string NOBLEFISH_SUBTYPEID = "NobleFish";
        public static readonly UniqueEntityId NOBLEFISH_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), NOBLEFISH_SUBTYPEID);

        public const string ALIENNOBLEFISH_SUBTYPEID = "AlienNobleFish";
        public static readonly UniqueEntityId ALIENNOBLEFISH_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), ALIENNOBLEFISH_SUBTYPEID);

        public const string SHRIMP_SUBTYPEID = "Shrimp";
        public static readonly UniqueEntityId SHRIMP_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), SHRIMP_SUBTYPEID);

        public static readonly long BASE_RAW_FISH_SPOIL_TIME = 5 * 60 * 1000;

        public static readonly FishDefinition FISH_DEFINITION = new FishDefinition()
        {
            Id = FISH_ID,
            Name = "Fish",
            Description = "Fish are abundant in most bodies of water. They can be found" + Environment.NewLine + "in nearly all aquatic environments.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 30,
            OfferAmount = new Vector2I(1000, 3000),
            OrderAmount = new Vector2I(250, 750),
            AcquisitionAmount = new Vector2I(500, 1500),
            Mass = 0.5f,
            Volume = 0.25f,
            StartConservationTime = BASE_RAW_FISH_SPOIL_TIME,
            RecipesDefinition = new List<SimpleIngredientRecipeDefinition>()
            {
                new SimpleIngredientRecipeDefinition()
                {
                    Name = "Extract Meat From Fish",
                    RecipeName = "FishMeat_Desconstruction",
                    IngredientAmmount = 1,
                    ProductionTime = 2.56f,
                    Results = new SimpleIngredientRecipeDefinition.RecipeItem[]
                    { 
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.FISHMEAT_ID,
                            Ammount = 3
                        },
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.FISH_BONES_ID,
                            Ammount = 0.3f
                        }
                    }
                }
            }
        };

        public static readonly FishDefinition ALIENFISH_DEFINITION = new FishDefinition()
        {
            Id = ALIENFISH_ID,
            Name = "Alien Fish",
            Description = "Fish are abundant in most bodies of water. They can be found" + Environment.NewLine + "in nearly all aquatic environments.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 30,
            OfferAmount = new Vector2I(1000, 3000),
            OrderAmount = new Vector2I(250, 750),
            AcquisitionAmount = new Vector2I(500, 1500),
            Mass = 0.5f,
            Volume = 0.25f,
            StartConservationTime = BASE_RAW_FISH_SPOIL_TIME,
            RecipesDefinition = new List<SimpleIngredientRecipeDefinition>()
            {
                new SimpleIngredientRecipeDefinition()
                {
                    Name = "Extract Meat From Alien Fish",
                    RecipeName = "AlienFishMeat_Desconstruction",
                    IngredientAmmount = 1,
                    ProductionTime = 2.56f,
                    Results = new SimpleIngredientRecipeDefinition.RecipeItem[]
                    {
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.FISHMEAT_ID,
                            Ammount = 3
                        },
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.FISH_BONES_ID,
                            Ammount = 0.3f
                        }
                    }
                }
            }
        };

        public static readonly FishDefinition NOBLEFISH_DEFINITION = new FishDefinition()
        {
            Id = NOBLEFISH_ID,
            Name = "Noble Fish",
            Description = "Noble fish are more difficult to catch. They can be found in" + Environment.NewLine + "deeper waters.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 50,
            OfferAmount = new Vector2I(1000, 3000),
            OrderAmount = new Vector2I(250, 750),
            AcquisitionAmount = new Vector2I(500, 1500),
            Mass = 1.0f,
            Volume = 0.5f,
            StartConservationTime = BASE_RAW_FISH_SPOIL_TIME,
            RecipesDefinition = new List<SimpleIngredientRecipeDefinition>()
            {
                new SimpleIngredientRecipeDefinition()
                {
                    Name = "Extract Meat From Noble Fish",
                    RecipeName = "NobleFishMeat_Desconstruction",
                    IngredientAmmount = 1,
                    ProductionTime = 5.12f,
                    Results = new SimpleIngredientRecipeDefinition.RecipeItem[]
                    {
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NOBLEFISHMEAT_ID,
                            Ammount = 3
                        },
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.FISH_BONES_ID,
                            Ammount = 0.6f
                        }
                    }
                }
            }
        };

        public static readonly FishDefinition ALIENNOBLEFISH_DEFINITION = new FishDefinition()
        {
            Id = ALIENNOBLEFISH_ID,
            Name = "Alien Noble Fish",
            Description = "Noble fish are more difficult to catch. They can be found in" + Environment.NewLine + "deeper waters.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 50,
            OfferAmount = new Vector2I(1000, 3000),
            OrderAmount = new Vector2I(250, 750),
            AcquisitionAmount = new Vector2I(500, 1500),
            Mass = 1.0f,
            Volume = 0.5f,
            StartConservationTime = BASE_RAW_FISH_SPOIL_TIME,
            RecipesDefinition = new List<SimpleIngredientRecipeDefinition>()
            {
                new SimpleIngredientRecipeDefinition()
                {
                    Name = "Extract Meat From Alien Noble Fish",
                    RecipeName = "AlienNobleFishMeat_Desconstruction",
                    IngredientAmmount = 1,
                    ProductionTime = 5.12f,
                    Results = new SimpleIngredientRecipeDefinition.RecipeItem[]
                    {
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NOBLEFISHMEAT_ID,
                            Ammount = 3
                        },
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.FISH_BONES_ID,
                            Ammount = 0.6f
                        }
                    }
                }
            }
        };

        public static readonly FishDefinition SHRIMP_DEFINITION = new FishDefinition()
        {
            Id = SHRIMP_ID,
            Name = "Shrimp",
            Description = "Shrimp are crustaceans with elongated bodies and a primarily" + Environment.NewLine + "swimming mode of locomotion.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 3,
            OfferAmount = new Vector2I(1000, 3000),
            OrderAmount = new Vector2I(250, 750),
            AcquisitionAmount = new Vector2I(500, 1500),
            Mass = 0.5f,
            Volume = 0.25f,
            StartConservationTime = BASE_RAW_FISH_SPOIL_TIME,
            RecipesDefinition = new List<SimpleIngredientRecipeDefinition>()
            {
                new SimpleIngredientRecipeDefinition()
                {
                    Name = "Extract Meat From Shrimp",
                    RecipeName = "ShrimpMeat_Desconstruction",
                    IngredientAmmount = 1,
                    ProductionTime = 0.64f,
                    Results = new SimpleIngredientRecipeDefinition.RecipeItem[]
                    {
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SHRIMPMEAT_ID,
                            Ammount = 1
                        }
                    }
                }
            }
        };

        public static readonly Dictionary<UniqueEntityId, FishDefinition> FISHS_DEFINITIONS = new Dictionary<UniqueEntityId, FishDefinition>()
        {
            { FISH_ID, FISH_DEFINITION },
            { ALIENFISH_ID, ALIENFISH_DEFINITION },
            { NOBLEFISH_ID, NOBLEFISH_DEFINITION },
            { ALIENNOBLEFISH_ID, ALIENNOBLEFISH_DEFINITION },
            { SHRIMP_ID, SHRIMP_DEFINITION }
        };

        public const string FISH_BAIT_SUBTYPEID = "FishBait";
        public static readonly UniqueEntityId FISH_BAIT_SMALL_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), FISH_BAIT_SUBTYPEID);

        public const string FISH_NOBLE_BAIT_SUBTYPEID = "FishNobleBait";
        public static readonly UniqueEntityId FISH_NOBLE_BAIT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), FISH_NOBLE_BAIT_SUBTYPEID);

        public static readonly FishBaitDefinition FISH_BAIT_SMALL_DEFINITION = new FishBaitDefinition()
        {
            Id = FISH_BAIT_SMALL_ID,
            Name = "Fish Bait",
            Description = "A kind of small worm, some fish may find it appetizing.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 2,
            OfferAmount = new Vector2I(10000, 30000),
            OrderAmount = new Vector2I(2500, 7500),
            AcquisitionAmount = new Vector2I(5000, 15000),
            Mass = 1f,
            Volume = 0.2f
        };

        public static readonly FishBaitDefinition FISH_NOBLE_BAIT_DEFINITION = new FishBaitDefinition()
        {
            Id = FISH_NOBLE_BAIT_ID,
            Name = "Noble Fish Bait",
            Description = "A kind of small worm, some fish may find it appetizing.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 4,
            OfferAmount = new Vector2I(1000, 3000),
            OrderAmount = new Vector2I(250, 750),
            AcquisitionAmount = new Vector2I(500, 1500),
            Mass = 1f,
            Volume = 0.2f
        };

        public static readonly Dictionary<UniqueEntityId, FishBaitDefinition> FISH_BAITS_DEFINITIONS = new Dictionary<UniqueEntityId, FishBaitDefinition>()
        {
            { FISH_BAIT_SMALL_ID, FISH_BAIT_SMALL_DEFINITION },
            { FISH_NOBLE_BAIT_ID, FISH_NOBLE_BAIT_DEFINITION }
        };

        private static void TryOverrideBaitsDefinitions()
        {
            try
            {
                var targetFaction = FactionTypeConstants.FACTION_TYPES_DEFINITIONS[FactionTypeConstants.TRADER_ID];
                // Override medical definition
                foreach (var bait in FISH_BAITS_DEFINITIONS.Keys)
                {
                    var seedDef = FISH_BAITS_DEFINITIONS[bait];
                    // Item definition
                    var itemDef = DefinitionUtils.TryGetDefinition<MyPhysicalItemDefinition>(bait.DefinitionId);
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
                        ExtendedSurvivalStatsLogging.Instance.LogInfo(typeof(FishingConstants), $"TryOverrideRecipes item not found. Food=[{bait}]");
                    // Add itens to faction types
                    if (seedDef.CanPlayerOrder)
                    {
                        targetFaction.OffersList.Add(bait);
                        targetFaction.OrdersList.Add(bait);
                    }
                }
            }
            catch (System.Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(typeof(FishingConstants), ex);
            }
        }

        private static void TryOverrideFishDefinitions()
        {
            try
            {
                var targetFaction = FactionTypeConstants.FACTION_TYPES_DEFINITIONS[FactionTypeConstants.TRADER_ID];
                // Override medical definition
                foreach (var fish in FISHS_DEFINITIONS.Keys)
                {
                    var fishDef = FISHS_DEFINITIONS[fish];
                    // Item definition
                    var itemDef = DefinitionUtils.TryGetDefinition<MyPhysicalItemDefinition>(fish.subtypeId.String);
                    if (itemDef != null)
                    {
                        itemDef.Volume = fishDef.GetVolume();
                        itemDef.Mass = fishDef.GetMass();
                        itemDef.DisplayNameEnum = null;
                        itemDef.DisplayNameString = fishDef.Name;
                        itemDef.DescriptionEnum = null;
                        itemDef.DescriptionString = null;
                        itemDef.MinimumAcquisitionAmount = fishDef.AcquisitionAmount.X;
                        itemDef.MaximumAcquisitionAmount = fishDef.AcquisitionAmount.Y;
                        itemDef.MinimumOrderAmount = fishDef.OrderAmount.X;
                        itemDef.MaximumOrderAmount = fishDef.OrderAmount.Y;
                        itemDef.MinimumOfferAmount = fishDef.OfferAmount.X;
                        itemDef.MaximumOfferAmount = fishDef.OfferAmount.Y;
                        itemDef.MinimalPricePerUnit = fishDef.MinimalPricePerUnit;
                        itemDef.CanPlayerOrder = fishDef.CanPlayerOrder;
                        itemDef.ExtraInventoryTooltipLine.AppendLine(Environment.NewLine + fishDef.GetFullDescription());
                        itemDef.Postprocess();
                    }
                    else
                        ExtendedSurvivalStatsLogging.Instance.LogInfo(typeof(SeedsAndFertilizerConstants), $"TryOverrideRecipes item not found. Food=[{fish}]");
                    // Recipe definition
                    foreach (var recipe in fishDef.RecipesDefinition)
                    {
                        var recipeDef = DefinitionUtils.TryGetBlueprintDefinition(recipe.RecipeName);
                        if (recipeDef != null)
                        {
                            recipeDef.Prerequisites = recipe.GetIngredients(fishDef.Id);
                            recipeDef.Results = recipe.GetProduct();
                            recipeDef.BaseProductionTimeInSeconds = recipe.ProductionTime;
                            recipeDef.DisplayNameEnum = null;
                            recipeDef.DisplayNameString = fishDef.Name;
                            recipeDef.DescriptionEnum = null;
                            recipeDef.DescriptionString = null;
                            recipeDef.Postprocess();
                        }
                        else
                            ExtendedSurvivalStatsLogging.Instance.LogInfo(typeof(FishingConstants), $"TryOverrideDefinitions recipe not found. Recipe=[{recipe.RecipeName}]");
                    }
                    // Add itens to faction types
                    if (fishDef.CanPlayerOrder)
                    {
                        targetFaction.OffersList.Add(fish);
                        targetFaction.OrdersList.Add(fish);
                    }
                }
            }
            catch (System.Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(typeof(FishingConstants), ex);
            }
        }

        public static void TryOverrideDefinitions()
        {
            TryOverrideFishDefinitions();
            TryOverrideBaitsDefinitions();
        }

    }

}