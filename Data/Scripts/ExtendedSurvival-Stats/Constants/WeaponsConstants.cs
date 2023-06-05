using Sandbox.Definitions;
using System;
using System.Collections.Generic;
using VRage.Game;
using VRageMath;

namespace ExtendedSurvival.Stats
{
    public static class WeaponsConstants
    {

        public const string PROPOFOLDART_SUBTYPEID = "PropofolDart";
        public static readonly UniqueEntityId PROPOFOLDART_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), PROPOFOLDART_SUBTYPEID);

        public const string LIDOCAINDART_SUBTYPEID = "LidocainDart";
        public static readonly UniqueEntityId LIDOCAINDART_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), LIDOCAINDART_SUBTYPEID);

        public static readonly WeaponComponentDefinition PROPOFOLDART_DEFINITION = new WeaponComponentDefinition()
        {
            Id = PROPOFOLDART_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.PROPOFOLDART_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.PROPOFOLDART_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 12500,
            OfferAmount = new Vector2I(100, 300),
            OrderAmount = new Vector2I(25, 75),
            AcquisitionAmount = new Vector2I(50, 150),
            Mass = 0.05f,
            Volume = 0.025f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "PropofolDart_Construction",
                    ProductAmmount = 2,
                    ProductionTime = 10.24f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 0.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALT_INGOT_ID,
                            Ammount = 0.3f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILICON_INGOT_ID,
                            Ammount = 0.2f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = QuimicalConstants.PROPOFOL_ID,
                            Ammount = 1f
                        }
                    }
                }
            }
        };

        public static readonly WeaponComponentDefinition LIDOCAINDART_DEFINITION = new WeaponComponentDefinition()
        {
            Id = LIDOCAINDART_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.LIDOCAINDART_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.LIDOCAINDART_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 2350,
            OfferAmount = new Vector2I(1000, 3000),
            OrderAmount = new Vector2I(250, 750),
            AcquisitionAmount = new Vector2I(500, 1500),
            Mass = 0.05f,
            Volume = 0.025f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "LidocainDart_Construction",
                    ProductAmmount = 2,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 0.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NICKEL_INGOT_ID,
                            Ammount = 0.3f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILICON_INGOT_ID,
                            Ammount = 0.2f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = QuimicalConstants.LIDOCAINE_ID,
                            Ammount = 1f
                        }
                    }
                }
            }
        };

        public static readonly Dictionary<UniqueEntityId, WeaponComponentDefinition> WEAPONCOMPONENTS_DEFINITIONS = new Dictionary<UniqueEntityId, WeaponComponentDefinition>()
        {
            { PROPOFOLDART_ID, PROPOFOLDART_DEFINITION },
            { LIDOCAINDART_ID, LIDOCAINDART_DEFINITION }
        };

        public const string PISTOL_PROPOFOL_MAGZINE_SUBTYPEID = "PropofolPistolMagazine";
        public static readonly UniqueEntityId PISTOL_PROPOFOL_MAGZINE_ID = new UniqueEntityId(typeof(MyObjectBuilder_AmmoMagazine), PISTOL_PROPOFOL_MAGZINE_SUBTYPEID);

        public const string PISTOL_LIDOCAIN_MAGZINE_SUBTYPEID = "LidocainPistolMagazine";
        public static readonly UniqueEntityId PISTOL_LIDOCAIN_MAGZINE_ID = new UniqueEntityId(typeof(MyObjectBuilder_AmmoMagazine), PISTOL_LIDOCAIN_MAGZINE_SUBTYPEID);

        public static readonly WeaponMagzineDefinition PISTOL_PROPOFOL_MAGZINE_DEFINITION = new WeaponMagzineDefinition()
        {
            Id = PISTOL_PROPOFOL_MAGZINE_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.PISTOL_PROPOFOL_MAGZINE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.PISTOL_PROPOFOL_MAGZINE_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 64000,
            OfferAmount = new Vector2I(100, 300),
            OrderAmount = new Vector2I(25, 75),
            AcquisitionAmount = new Vector2I(50, 150),
            Mass = 0.25f,
            Volume = 0.625f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "PropofolPistolMagazine",
                    ProductAmmount = 1,
                    ProductionTime = 2.56f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.EMPTYPISTOLMAGAZINE_ID,
                            Ammount = 1f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = PROPOFOLDART_ID,
                            Ammount = 5f
                        }
                    }
                }
            }
        };

        public static readonly WeaponMagzineDefinition PISTOL_LIDOCAIN_MAGZINE_DEFINITION = new WeaponMagzineDefinition()
        {
            Id = PISTOL_LIDOCAIN_MAGZINE_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.PISTOL_LIDOCAIN_MAGZINE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.PISTOL_LIDOCAIN_MAGZINE_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 12500,
            OfferAmount = new Vector2I(100, 300),
            OrderAmount = new Vector2I(25, 75),
            AcquisitionAmount = new Vector2I(50, 150),
            Mass = 0.25f,
            Volume = 0.625f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "LidocainPistolMagazine",
                    ProductAmmount = 1,
                    ProductionTime = 2.56f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.EMPTYPISTOLMAGAZINE_ID,
                            Ammount = 1f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = LIDOCAINDART_ID,
                            Ammount = 5f
                        }
                    }
                }
            }
        };

        public static readonly Dictionary<UniqueEntityId, WeaponMagzineDefinition> WEAPONMAGZINES_DEFINITIONS = new Dictionary<UniqueEntityId, WeaponMagzineDefinition>()
        {
            { PISTOL_PROPOFOL_MAGZINE_ID, PISTOL_PROPOFOL_MAGZINE_DEFINITION },
            { PISTOL_LIDOCAIN_MAGZINE_ID, PISTOL_LIDOCAIN_MAGZINE_DEFINITION }
        };

        public const string LIDOCAINPISTOLITEM_SUBTYPEID = "LidocainPistolItem";
        public static readonly UniqueEntityId LIDOCAINPISTOLITEM_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalGunObject), LIDOCAINPISTOLITEM_SUBTYPEID);

        public const string PROPOFOLPISTOLITEM_SUBTYPEID = "PropofolPistolItem";
        public static readonly UniqueEntityId PROPOFOLPISTOLITEM_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalGunObject), PROPOFOLPISTOLITEM_SUBTYPEID);

        public static readonly WeaponDefinition PROPOFOLPISTOLITEM_DEFINITION = new WeaponDefinition()
        {
            Id = PROPOFOLPISTOLITEM_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.PROPOFOLPISTOLITEM_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.PROPOFOLPISTOLITEM_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 75000,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(5, 10),
            AcquisitionAmount = new Vector2I(30, 60),
            Mass = 1.25f,
            Volume = 6.5f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "PropofolPistol",
                    ProductAmmount = 1,
                    ProductionTime = 20.48f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.STEEL_INGOT_ID,
                            Ammount = 5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALT_INGOT_ID,
                            Ammount = 4f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ALUMINUM_INGOT_ID,
                            Ammount = 8f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.STEELSCREW_ID,
                            Ammount = 40f
                        }
                    }
                },
                new SimpleRecipeDefinition()
                {
                    RecipeName = "PropofolPistolVanila",
                    ProductAmmount = 1,
                    ProductionTime = 20.48f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 6f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NICKEL_INGOT_ID,
                            Ammount = 4f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALT_INGOT_ID,
                            Ammount = 12f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILVER_INGOT_ID,
                            Ammount = 4f
                        }
                    }
                }
            }
        };

        public static readonly WeaponDefinition LIDOCAINPISTOLITEM_DEFINITION = new WeaponDefinition()
        {
            Id = LIDOCAINPISTOLITEM_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.LIDOCAINPISTOLITEM_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.LIDOCAINPISTOLITEM_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 25000,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(5, 10),
            AcquisitionAmount = new Vector2I(30, 60),
            Mass = 1f,
            Volume = 6f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "LidocainPistol",
                    ProductAmmount = 1,
                    ProductionTime = 20.48f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 7f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NICKEL_INGOT_ID,
                            Ammount = 3f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ALUMINUM_INGOT_ID,
                            Ammount = 8f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRONSCREW_ID,
                            Ammount = 40f
                        }
                    }
                },
                new SimpleRecipeDefinition()
                {
                    RecipeName = "LidocainPistolVanila",
                    ProductAmmount = 1,
                    ProductionTime = 20.48f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 6f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NICKEL_INGOT_ID,
                            Ammount = 4f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALT_INGOT_ID,
                            Ammount = 12f
                        }
                    }
                }
            }
        };

        public static readonly Dictionary<UniqueEntityId, WeaponDefinition> WEAPONS_DEFINITIONS = new Dictionary<UniqueEntityId, WeaponDefinition>()
        {
            { LIDOCAINPISTOLITEM_ID, LIDOCAINPISTOLITEM_DEFINITION },
            { PROPOFOLPISTOLITEM_ID, PROPOFOLPISTOLITEM_DEFINITION }
        };

        public static void TryOverrideDefinitions()
        {
            PhysicalItemDefinitionOverride.TryOverrideDefinitions<WeaponDefinition, MyPhysicalItemDefinition>(WEAPONS_DEFINITIONS);
            PhysicalItemDefinitionOverride.TryOverrideDefinitions<WeaponMagzineDefinition, MyPhysicalItemDefinition>(WEAPONMAGZINES_DEFINITIONS);
            PhysicalItemDefinitionOverride.TryOverrideDefinitions<WeaponComponentDefinition, MyPhysicalItemDefinition>(WEAPONCOMPONENTS_DEFINITIONS);
        }

        public static void RegisterShopItens()
        {
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = PROPOFOLDART_ID.DefinitionId,
                Rarity = ItemRarity.Rare,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Armory }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = LIDOCAINDART_ID.DefinitionId,
                Rarity = ItemRarity.Normal,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Armory }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = PISTOL_PROPOFOL_MAGZINE_ID.DefinitionId,
                Rarity = ItemRarity.Rare,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Armory }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = PISTOL_LIDOCAIN_MAGZINE_ID.DefinitionId,
                Rarity = ItemRarity.Normal,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Armory }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = LIDOCAINPISTOLITEM_ID.DefinitionId,
                Rarity = ItemRarity.Rare,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Armory }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = PROPOFOLPISTOLITEM_ID.DefinitionId,
                Rarity = ItemRarity.Normal,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Armory }
            });
        }

    }

}