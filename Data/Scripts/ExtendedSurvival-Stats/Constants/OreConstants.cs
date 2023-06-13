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

        public const string THERMALFLUID_SUBTYPEID = "ThermalFluid";
        public static readonly UniqueEntityId THERMALFLUID_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), THERMALFLUID_SUBTYPEID);

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
            MinimalPricePerUnit = 20,
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
            MinimalPricePerUnit = 30,
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

        public static readonly OreDefinition THERMALFLUID_DEFINITION = new OreDefinition()
        {
            Id = THERMALFLUID_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.THERMALFLUID_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.THERMALFLUID_DESCRIPTION),
            CanPlayerOrder = false,
            Mass = 1f,
            Volume = 1f,
            MinimalPricePerUnit = 375,
            RecipesDefinition = new List<SimpleIngredientRecipeDefinition>()
            {
                new SimpleIngredientRecipeDefinition()
                {
                    RecipeName = "ThermalFluid_Construction",
                    IngredientAmmount = 2.5f,
                    ProductionTime = 2.56f,
                    Results = new SimpleIngredientRecipeDefinition.RecipeItem[]
                    {
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = RecipientConstants.SMALLALUMINUMCANISTER_ID,
                            Ammount = 1f
                        },
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CARBON_INGOT_ID,
                            Ammount = 2.25f
                        },
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ICE_ID,
                            Ammount = 1.5f
                        },
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SULFUR_INGOT_ID,
                            Ammount = 1.25f
                        }
                    }
                },
                new SimpleIngredientRecipeDefinition()
                {
                    RecipeName = "ThermalFluid_Vanila_Construction",
                    IngredientAmmount = 2.5f,
                    ProductionTime = 2.56f,
                    Results = new SimpleIngredientRecipeDefinition.RecipeItem[]
                    {
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = RecipientConstants.SMALLALUMINUMCANISTER_ID,
                            Ammount = 1f
                        },
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CARBON_INGOT_ID,
                            Ammount = 0.75f
                        },
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ICE_ID,
                            Ammount = 1.5f
                        },
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILICON_INGOT_ID,
                            Ammount = 2.75f
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
                ForceMinimalPrice = true,
                TargetFactions = new FactionType[] { FactionType.Farming }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = COFFEE_ID.DefinitionId,
                Rarity = ItemRarity.Normal,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                ForceMinimalPrice = true,
                TargetFactions = new FactionType[] { FactionType.Farming }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = THERMALFLUID_ID.DefinitionId,
                Rarity = ItemRarity.Normal,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                ForceMinimalPrice = true,
                TargetFactions = new FactionType[] { FactionType.Trader }
            });
        }

    }

}