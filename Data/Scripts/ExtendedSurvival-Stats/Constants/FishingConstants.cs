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
            Name = LanguageProvider.GetEntry(LanguageEntries.FISH_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.FISH_DESCRIPTION),
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
                            Id = FoodConstants.FISHMEAT_ID,
                            Ammount = 3
                        },
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = OreConstants.FISH_BONES_ID,
                            Ammount = 0.3f
                        }
                    }
                }
            }
        };

        public static readonly FishDefinition ALIENFISH_DEFINITION = new FishDefinition()
        {
            Id = ALIENFISH_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.ALIENFISH_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ALIENFISH_DESCRIPTION),
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
                            Id = FoodConstants.FISHMEAT_ID,
                            Ammount = 3
                        },
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = OreConstants.FISH_BONES_ID,
                            Ammount = 0.3f
                        }
                    }
                }
            }
        };

        public static readonly FishDefinition NOBLEFISH_DEFINITION = new FishDefinition()
        {
            Id = NOBLEFISH_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.NOBLEFISH_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.NOBLEFISH_DESCRIPTION),
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
                            Id = FoodConstants.NOBLEFISHMEAT_ID,
                            Ammount = 3
                        },
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = OreConstants.FISH_BONES_ID,
                            Ammount = 0.6f
                        }
                    }
                }
            }
        };

        public static readonly FishDefinition ALIENNOBLEFISH_DEFINITION = new FishDefinition()
        {
            Id = ALIENNOBLEFISH_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.ALIENNOBLEFISH_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ALIENNOBLEFISH_DESCRIPTION),
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
                            Id = FoodConstants.NOBLEFISHMEAT_ID,
                            Ammount = 3
                        },
                        new SimpleIngredientRecipeDefinition.RecipeItem()
                        {
                            Id = OreConstants.FISH_BONES_ID,
                            Ammount = 0.6f
                        }
                    }
                }
            }
        };

        public static readonly FishDefinition SHRIMP_DEFINITION = new FishDefinition()
        {
            Id = SHRIMP_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.SHRIMP_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.SHRIMP_DESCRIPTION),
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
                            Id = FoodConstants.SHRIMPMEAT_ID,
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
            Name = LanguageProvider.GetEntry(LanguageEntries.FISH_BAIT_SMALL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.FISH_BAIT_SMALL_DESCRIPTION),
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
            Name = LanguageProvider.GetEntry(LanguageEntries.FISH_NOBLE_BAIT_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.FISH_NOBLE_BAIT_DESCRIPTION),
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

        public static void TryOverrideDefinitions()
        {
            PhysicalItemDefinitionOverride.TryOverrideDefinitions<FishDefinition, MyPhysicalItemDefinition>(FISHS_DEFINITIONS);
            PhysicalItemDefinitionOverride.TryOverrideDefinitions<FishBaitDefinition, MyPhysicalItemDefinition>(FISH_BAITS_DEFINITIONS);
        }

        public static void RegisterShopItens()
        {
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = FISH_ID.DefinitionId,
                Rarity = ItemRarity.Common,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                ForceMinimalPrice = true,
                TargetFactions = new FactionType[] { FactionType.Livestock }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = ALIENFISH_ID.DefinitionId,
                Rarity = ItemRarity.Common,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                ForceMinimalPrice = true,
                TargetFactions = new FactionType[] { FactionType.Livestock }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = NOBLEFISH_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                ForceMinimalPrice = true,
                TargetFactions = new FactionType[] { FactionType.Livestock }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = ALIENNOBLEFISH_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                ForceMinimalPrice = true,
                TargetFactions = new FactionType[] { FactionType.Livestock }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = SHRIMP_ID.DefinitionId,
                Rarity = ItemRarity.Normal,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                ForceMinimalPrice = true,
                TargetFactions = new FactionType[] { FactionType.Livestock }
            });
        }

    }

}