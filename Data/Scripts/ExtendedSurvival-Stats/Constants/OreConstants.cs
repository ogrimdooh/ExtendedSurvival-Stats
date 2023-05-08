using Sandbox.Definitions;
using System.Collections.Generic;
using VRage.Game;

namespace ExtendedSurvival.Stats
{
    public static class OreConstants
    {

        public const string BONES_SUBTYPEID = "Bones";
        public static readonly UniqueEntityId BONES_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), BONES_SUBTYPEID);

        public const string FISH_BONES_SUBTYPEID = "FishBones";
        public static readonly UniqueEntityId FISH_BONES_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), FISH_BONES_SUBTYPEID);

        public const string POOP_SUBTYPEID = "Poop";
        public static readonly UniqueEntityId POOP_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), POOP_SUBTYPEID);

        public const string WHEAT_SUBTYPEID = "Wheat";
        public static readonly UniqueEntityId WHEAT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), WHEAT_SUBTYPEID);

        public const string COFFEE_SUBTYPEID = "Coffee";
        public static readonly UniqueEntityId COFFEE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), COFFEE_SUBTYPEID);

        public static readonly OreDefinition POOP_DEFINITION = new OreDefinition()
        {
            Id = POOP_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.POOP_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.POOP_DESCRIPTION),
            CanPlayerOrder = false,
            Mass = 1f,
            Volume = 0.4f,
            RecipesDefinition = new List<SimpleIngredientRecipeDefinition>() { }
        };

        public static readonly OreDefinition BONES_DEFINITION = new OreDefinition()
        {
            Id = BONES_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.BONES_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.BONES_DESCRIPTION),
            CanPlayerOrder = false,
            Mass = 1f,
            Volume = 0.4f,
            RecipesDefinition = new List<SimpleIngredientRecipeDefinition>() 
            {
                new SimpleIngredientRecipeDefinition()
                {
                    RecipeName = "BoneToMeal_Deconstruction",
                    IngredientAmmount = 1,
                    ProductionTime = 1.28f,
                    Results = new SimpleIngredientRecipeDefinition.RecipeItem[]
                    {
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = IngotsConstants.BONEMEAL_ID,
                            Ammount = 0.65f
                        }
                    }
                }
            }
        };

        public static readonly OreDefinition FISH_BONES_DEFINITION = new OreDefinition()
        {
            Id = FISH_BONES_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.FISH_BONES_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.FISH_BONES_DESCRIPTION),
            CanPlayerOrder = false,
            Mass = 1f,
            Volume = 0.4f,
            RecipesDefinition = new List<SimpleIngredientRecipeDefinition>()
            {
                new SimpleIngredientRecipeDefinition()
                {
                    RecipeName = "FishBonesToMeal_Deconstruction",
                    IngredientAmmount = 1,
                    ProductionTime = 1.28f,
                    Results = new SimpleIngredientRecipeDefinition.RecipeItem[]
                    {
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = IngotsConstants.BONEMEAL_ID,
                            Ammount = 0.65f
                        }
                    }
                }
            }
        };

        public static readonly OreDefinition WHEAT_DEFINITION = new OreDefinition()
        {
            Id = WHEAT_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.WHEAT_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.WHEAT_DESCRIPTION),
            CanPlayerOrder = false,
            Mass = 1f,
            Volume = 0.05f,
            RecipesDefinition = new List<SimpleIngredientRecipeDefinition>()
            {
                new SimpleIngredientRecipeDefinition()
                {
                    RecipeName = "WheatToSack_Deconstruction",
                    IngredientAmmount = 1,
                    ProductionTime = 1.28f,
                    Results = new SimpleIngredientRecipeDefinition.RecipeItem[]
                    {
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = FoodConstants.WHEATSACK_ID,
                            Ammount = 0.15f
                        }
                    }
                }
            }
        };

        public static readonly OreDefinition COFFEE_DEFINITION = new OreDefinition()
        {
            Id = COFFEE_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.COFFEE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.COFFEE_DESCRIPTION),
            CanPlayerOrder = false,
            Mass = 1f,
            Volume = 0.05f,
            RecipesDefinition = new List<SimpleIngredientRecipeDefinition>()
            {
                new SimpleIngredientRecipeDefinition()
                {
                    RecipeName = "CoffeeToSack_Deconstruction",
                    IngredientAmmount = 1,
                    ProductionTime = 1.28f,
                    Results = new SimpleIngredientRecipeDefinition.RecipeItem[]
                    {
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = FoodConstants.COFFEESACK_ID,
                            Ammount = 0.05f
                        }
                    }
                }
            }
        };

        public static readonly Dictionary<UniqueEntityId, OreDefinition> ORES_DEFINITIONS = new Dictionary<UniqueEntityId, OreDefinition>()
        {
            { BONES_ID, BONES_DEFINITION },
            { FISH_BONES_ID, FISH_BONES_DEFINITION },
            { POOP_ID, POOP_DEFINITION },
            { WHEAT_ID, WHEAT_DEFINITION },
            { COFFEE_ID, COFFEE_DEFINITION }
        };

        public static void TryOverrideDefinitions()
        {
            PhysicalItemDefinitionOverride.TryOverrideDefinitions<OreDefinition, MyPhysicalItemDefinition>(ORES_DEFINITIONS);
        }

        public static void RegisterShopItens()
        {
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = WHEAT_ID.DefinitionId,
                Rarity = ItemRarity.Normal,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Farming }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = COFFEE_ID.DefinitionId,
                Rarity = ItemRarity.Normal,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Farming }
            });
        }

    }

}