using Sandbox.Definitions;
using System.Collections.Generic;
using VRage.Game;

namespace ExtendedSurvival.Stats
{
    public static class OreConstants
    {

        // Natural

        public const string STONE_SUBTYPEID = "Stone";
        public static readonly UniqueEntityId STONE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), STONE_SUBTYPEID);

        public const string IRON_SUBTYPEID = "Iron";
        public static readonly UniqueEntityId IRON_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), IRON_SUBTYPEID);

        public const string NICKEL_SUBTYPEID = "Nickel";
        public static readonly UniqueEntityId NICKEL_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), NICKEL_SUBTYPEID);

        public const string SILICON_SUBTYPEID = "Silicon";
        public static readonly UniqueEntityId SILICON_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), SILICON_SUBTYPEID);

        public const string COBALT_SUBTYPEID = "Cobalt";
        public static readonly UniqueEntityId COBALT_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), COBALT_SUBTYPEID);

        public const string SILVER_SUBTYPEID = "Silver";
        public static readonly UniqueEntityId SILVER_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), SILVER_SUBTYPEID);

        public const string GOLD_SUBTYPEID = "Gold";
        public static readonly UniqueEntityId GOLD_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), GOLD_SUBTYPEID);

        public const string PLATINUM_SUBTYPEID = "Platinum";
        public static readonly UniqueEntityId PLATINUM_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), PLATINUM_SUBTYPEID);

        public const string MAGNESIUM_SUBTYPEID = "Magnesium";
        public static readonly UniqueEntityId MAGNESIUM_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), MAGNESIUM_SUBTYPEID);

        public const string URANIUM_SUBTYPEID = "Uranium";
        public static readonly UniqueEntityId URANIUM_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), URANIUM_SUBTYPEID);

        public const string ZINC_SUBTYPEID = "Zinc";
        public static readonly UniqueEntityId ZINC_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), ZINC_SUBTYPEID);

        public const string COPPER_SUBTYPEID = "Copper";
        public static readonly UniqueEntityId COPPER_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), COPPER_SUBTYPEID);

        public const string ALUMINUM_SUBTYPEID = "Aluminum";
        public static readonly UniqueEntityId ALUMINUM_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), ALUMINUM_SUBTYPEID);

        public const string CARBON_SUBTYPEID = "Carbon";
        public static readonly UniqueEntityId CARBON_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), CARBON_SUBTYPEID);

        public const string SULFUR_SUBTYPEID = "Sulfur";
        public static readonly UniqueEntityId SULFUR_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), SULFUR_SUBTYPEID);

        public const string POTASSIUM_SUBTYPEID = "Potassium";
        public static readonly UniqueEntityId POTASSIUM_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), POTASSIUM_SUBTYPEID);

        public const string LEAD_SUBTYPEID = "Lead";
        public static readonly UniqueEntityId LEAD_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), LEAD_SUBTYPEID);

        public const string LITHIUM_SUBTYPEID = "Lithium";
        public static readonly UniqueEntityId LITHIUM_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), LITHIUM_SUBTYPEID);

        public const string PLUTONIUM_SUBTYPEID = "Plutonium";
        public static readonly UniqueEntityId PLUTONIUM_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), PLUTONIUM_SUBTYPEID);

        public const string TUNGSTEN_SUBTYPEID = "Tungsten";
        public static readonly UniqueEntityId TUNGSTEN_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), TUNGSTEN_SUBTYPEID);

        public const string TITANIUM_SUBTYPEID = "Titanium";
        public static readonly UniqueEntityId TITANIUM_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), TITANIUM_SUBTYPEID);

        public const string IRIDIUM_SUBTYPEID = "Iridium";
        public static readonly UniqueEntityId IRIDIUM_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), IRIDIUM_SUBTYPEID);

        public const string MERCURY_SUBTYPEID = "Mercury";
        public static readonly UniqueEntityId MERCURY_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), MERCURY_SUBTYPEID);

        public const string BERYLLIUM_SUBTYPEID = "Beryllium";
        public static readonly UniqueEntityId BERYLLIUM_ORE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), BERYLLIUM_SUBTYPEID);

        public static readonly UniqueEntityId[] VANILLAORES = new UniqueEntityId[] 
        {
            IRON_ORE_ID,
            NICKEL_ORE_ID,
            SILICON_ORE_ID,
            SILVER_ORE_ID,
            GOLD_ORE_ID,
            PLATINUM_ORE_ID,
            MAGNESIUM_ORE_ID,
            COBALT_ORE_ID,
            URANIUM_ORE_ID
        };

        public static readonly UniqueEntityId[] ESORES = new UniqueEntityId[]
        {
            ZINC_ORE_ID,
            COPPER_ORE_ID,
            ALUMINUM_ORE_ID,
            CARBON_ORE_ID,
            SULFUR_ORE_ID,
            POTASSIUM_ORE_ID,
            LEAD_ORE_ID,
            LITHIUM_ORE_ID,
            PLUTONIUM_ORE_ID,
            TUNGSTEN_ORE_ID,
            TITANIUM_ORE_ID,
            IRIDIUM_ORE_ID,
            MERCURY_ORE_ID,
            BERYLLIUM_ORE_ID
        };

        public static readonly UniqueEntityId[] COMMONORES = new UniqueEntityId[]
        {
            IRON_ORE_ID,
            NICKEL_ORE_ID,
            SILICON_ORE_ID,
            ZINC_ORE_ID,
            COPPER_ORE_ID,
            ALUMINUM_ORE_ID
        };

        public static readonly UniqueEntityId[] UNCOMMONORES = new UniqueEntityId[]
        {
            CARBON_ORE_ID,
            SULFUR_ORE_ID,
            POTASSIUM_ORE_ID,
            LEAD_ORE_ID
        };

        public static readonly UniqueEntityId[] RAREORES = new UniqueEntityId[]
        {
            COBALT_ORE_ID,
            SILVER_ORE_ID,
            GOLD_ORE_ID,
            LITHIUM_ORE_ID,
            MAGNESIUM_ORE_ID
        };

        public static readonly UniqueEntityId[] EPICORES = new UniqueEntityId[]
        {
            BERYLLIUM_ORE_ID,
            IRIDIUM_ORE_ID,
            MERCURY_ORE_ID,
            PLATINUM_ORE_ID,
            URANIUM_ORE_ID
        };

        public static readonly UniqueEntityId[] LEGENDARYORES = new UniqueEntityId[]
        {
            PLUTONIUM_ORE_ID,
            TUNGSTEN_ORE_ID,
            TITANIUM_ORE_ID
        };

        // Alien Animals

        public const string CARCASS_SUBTYPEID = "Carcass";
        public static readonly UniqueEntityId CARCASS_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), CARCASS_SUBTYPEID);

        public const string CARAPACE_SUBTYPEID = "Carapace";
        public static readonly UniqueEntityId CARAPACE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), CARAPACE_SUBTYPEID);

        public const string TENTACLE1_SUBTYPEID = "Tentacle1";
        public static readonly UniqueEntityId TENTACLE1_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), TENTACLE1_SUBTYPEID);

        // Stats

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