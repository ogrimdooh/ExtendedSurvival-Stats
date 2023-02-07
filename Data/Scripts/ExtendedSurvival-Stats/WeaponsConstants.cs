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
        public static readonly UniqueEntityId PROPOFOLDART_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), PROPOFOLDART_SUBTYPEID);

        public const string LIDOCAINDART_SUBTYPEID = "LidocainDart";
        public static readonly UniqueEntityId LIDOCAINDART_ID = new UniqueEntityId(typeof(MyObjectBuilder_Component), LIDOCAINDART_SUBTYPEID);

        public static readonly WeaponComponentDefinition PROPOFOLDART_DEFINITION = new WeaponComponentDefinition()
        {
            Id = PROPOFOLDART_ID,
            Name = "Propofol Dart",
            Description = "A Propofol-based tranquilizer dart.",
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
            Name = "Lidocain Dart",
            Description = "A Lidocain-based tranquilizer dart.",
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
            Name = "Pistol DRT-Propofol Magzine",
            Description = "A pistol clip with Propofol tranquilizer darts.",
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
            Name = "Pistol DRT-Lidocain Magzine",
            Description = "A pistol clip with Lidocain tranquilizer darts.",
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

        public static readonly WeaponDefinition LIDOCAINPISTOLITEM_DEFINITION = new WeaponDefinition()
        {
            Id = PROPOFOLPISTOLITEM_ID,
            Name = "Pistol DRT-Propofol",
            Description = "A gun for hunting animals with Propofol tranquilizer darts.",
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

        public static readonly WeaponDefinition PROPOFOLPISTOLITEM_DEFINITION = new WeaponDefinition()
        {
            Id = LIDOCAINPISTOLITEM_ID,
            Name = "Pistol DRT-Lidocain",
            Description = "A gun for hunting animals with Lidocain tranquilizer darts.",
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

        private static void TryOverrideWeaponsDefinitions()
        {
            try
            {
                var targetFaction = FactionTypeConstants.FACTION_TYPES_DEFINITIONS[FactionTypeConstants.TRADER_ID];
                // Override medical definition
                foreach (var weapon in WEAPONS_DEFINITIONS.Keys)
                {
                    var weaponDef = WEAPONS_DEFINITIONS[weapon];
                    // Item definition
                    var itemDef = DefinitionUtils.TryGetDefinition<MyPhysicalItemDefinition>(weapon.DefinitionId);
                    if (itemDef != null)
                    {
                        itemDef.Volume = weaponDef.GetVolume();
                        itemDef.Mass = weaponDef.GetMass();
                        itemDef.DisplayNameEnum = null;
                        itemDef.DisplayNameString = weaponDef.Name;
                        itemDef.DescriptionEnum = null;
                        itemDef.DescriptionString = null;
                        itemDef.MinimumAcquisitionAmount = weaponDef.AcquisitionAmount.X;
                        itemDef.MaximumAcquisitionAmount = weaponDef.AcquisitionAmount.Y;
                        itemDef.MinimumOrderAmount = weaponDef.OrderAmount.X;
                        itemDef.MaximumOrderAmount = weaponDef.OrderAmount.Y;
                        itemDef.MinimumOfferAmount = weaponDef.OfferAmount.X;
                        itemDef.MaximumOfferAmount = weaponDef.OfferAmount.Y;
                        itemDef.MinimalPricePerUnit = weaponDef.MinimalPricePerUnit;
                        itemDef.CanPlayerOrder = weaponDef.CanPlayerOrder;
                        itemDef.ExtraInventoryTooltipLine.AppendLine(Environment.NewLine + weaponDef.GetFullDescription());
                        itemDef.Postprocess();
                    }
                    else
                        ExtendedSurvivalStatsLogging.Instance.LogInfo(typeof(WeaponsConstants), $"TryOverrideRecipes item not found. Food=[{weapon}]");
                    // Recipe definition
                    foreach (var recipe in weaponDef.RecipesDefinition)
                    {
                        var recipeDef = DefinitionUtils.TryGetBlueprintDefinition(recipe.RecipeName);
                        if (recipeDef != null)
                        {
                            recipeDef.Prerequisites = recipe.GetIngredients();
                            recipeDef.Results = recipe.GetProduct(weaponDef.Id);
                            recipeDef.BaseProductionTimeInSeconds = recipe.ProductionTime;
                            recipeDef.DisplayNameEnum = null;
                            recipeDef.DisplayNameString = weaponDef.Name;
                            recipeDef.DescriptionEnum = null;
                            recipeDef.DescriptionString = null;
                            recipeDef.Postprocess();
                        }
                        else
                            ExtendedSurvivalStatsLogging.Instance.LogInfo(typeof(WeaponsConstants), $"TryOverrideDefinitions recipe not found. Recipe=[{recipe.RecipeName}]");
                    }
                    // Add itens to faction types
                    if (weaponDef.CanPlayerOrder)
                    {
                        targetFaction.OffersList.Add(weapon);
                        targetFaction.OrdersList.Add(weapon);
                    }
                }
            }
            catch (System.Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(typeof(WeaponsConstants), ex);
            }
        }

        private static void TryOverrideWeaponMagzinesDefinitions()
        {
            try
            {
                var targetFaction = FactionTypeConstants.FACTION_TYPES_DEFINITIONS[FactionTypeConstants.TRADER_ID];
                // Override medical definition
                foreach (var magzine in WEAPONMAGZINES_DEFINITIONS.Keys)
                {
                    var magzinesDef = WEAPONMAGZINES_DEFINITIONS[magzine];
                    // Item definition
                    var itemDef = DefinitionUtils.TryGetDefinition<MyPhysicalItemDefinition>(magzine.DefinitionId);
                    if (itemDef != null)
                    {
                        itemDef.Volume = magzinesDef.GetVolume();
                        itemDef.Mass = magzinesDef.GetMass();
                        itemDef.DisplayNameEnum = null;
                        itemDef.DisplayNameString = magzinesDef.Name;
                        itemDef.DescriptionEnum = null;
                        itemDef.DescriptionString = null;
                        itemDef.MinimumAcquisitionAmount = magzinesDef.AcquisitionAmount.X;
                        itemDef.MaximumAcquisitionAmount = magzinesDef.AcquisitionAmount.Y;
                        itemDef.MinimumOrderAmount = magzinesDef.OrderAmount.X;
                        itemDef.MaximumOrderAmount = magzinesDef.OrderAmount.Y;
                        itemDef.MinimumOfferAmount = magzinesDef.OfferAmount.X;
                        itemDef.MaximumOfferAmount = magzinesDef.OfferAmount.Y;
                        itemDef.MinimalPricePerUnit = magzinesDef.MinimalPricePerUnit;
                        itemDef.CanPlayerOrder = magzinesDef.CanPlayerOrder;
                        itemDef.ExtraInventoryTooltipLine.AppendLine(Environment.NewLine + magzinesDef.GetFullDescription());
                        itemDef.Postprocess();
                    }
                    else
                        ExtendedSurvivalStatsLogging.Instance.LogInfo(typeof(WeaponsConstants), $"TryOverrideRecipes item not found. Food=[{magzine}]");
                    // Recipe definition
                    foreach (var recipe in magzinesDef.RecipesDefinition)
                    {
                        var recipeDef = DefinitionUtils.TryGetBlueprintDefinition(recipe.RecipeName);
                        if (recipeDef != null)
                        {
                            recipeDef.Prerequisites = recipe.GetIngredients();
                            recipeDef.Results = recipe.GetProduct(magzinesDef.Id);
                            recipeDef.BaseProductionTimeInSeconds = recipe.ProductionTime;
                            recipeDef.DisplayNameEnum = null;
                            recipeDef.DisplayNameString = magzinesDef.Name;
                            recipeDef.DescriptionEnum = null;
                            recipeDef.DescriptionString = null;
                            recipeDef.Postprocess();
                        }
                        else
                            ExtendedSurvivalStatsLogging.Instance.LogInfo(typeof(WeaponsConstants), $"TryOverrideDefinitions recipe not found. Recipe=[{recipe.RecipeName}]");
                    }
                    // Add itens to faction types
                    if (magzinesDef.CanPlayerOrder)
                    {
                        targetFaction.OffersList.Add(magzine);
                        targetFaction.OrdersList.Add(magzine);
                    }
                }
            }
            catch (System.Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(typeof(WeaponsConstants), ex);
            }
        }

        private static void TryOverrideWeaponComponentsDefinitions()
        {
            try
            {
                var targetFaction = FactionTypeConstants.FACTION_TYPES_DEFINITIONS[FactionTypeConstants.TRADER_ID];
                // Override medical definition
                foreach (var component in WEAPONCOMPONENTS_DEFINITIONS.Keys)
                {
                    var componentsDef = WEAPONCOMPONENTS_DEFINITIONS[component];
                    // Item definition
                    var itemDef = DefinitionUtils.TryGetDefinition<MyPhysicalItemDefinition>(component.DefinitionId);
                    if (itemDef != null)
                    {
                        itemDef.Volume = componentsDef.GetVolume();
                        itemDef.Mass = componentsDef.GetMass();
                        itemDef.DisplayNameEnum = null;
                        itemDef.DisplayNameString = componentsDef.Name;
                        itemDef.DescriptionEnum = null;
                        itemDef.DescriptionString = null;
                        itemDef.MinimumAcquisitionAmount = componentsDef.AcquisitionAmount.X;
                        itemDef.MaximumAcquisitionAmount = componentsDef.AcquisitionAmount.Y;
                        itemDef.MinimumOrderAmount = componentsDef.OrderAmount.X;
                        itemDef.MaximumOrderAmount = componentsDef.OrderAmount.Y;
                        itemDef.MinimumOfferAmount = componentsDef.OfferAmount.X;
                        itemDef.MaximumOfferAmount = componentsDef.OfferAmount.Y;
                        itemDef.MinimalPricePerUnit = componentsDef.MinimalPricePerUnit;
                        itemDef.CanPlayerOrder = componentsDef.CanPlayerOrder;
                        itemDef.ExtraInventoryTooltipLine.AppendLine(Environment.NewLine + componentsDef.GetFullDescription());
                        itemDef.Postprocess();
                    }
                    else
                        ExtendedSurvivalStatsLogging.Instance.LogInfo(typeof(WeaponsConstants), $"TryOverrideRecipes item not found. Food=[{component}]");
                    // Recipe definition
                    foreach (var recipe in componentsDef.RecipesDefinition)
                    {
                        var recipeDef = DefinitionUtils.TryGetBlueprintDefinition(recipe.RecipeName);
                        if (recipeDef != null)
                        {
                            recipeDef.Prerequisites = recipe.GetIngredients();
                            recipeDef.Results = recipe.GetProduct(componentsDef.Id);
                            recipeDef.BaseProductionTimeInSeconds = recipe.ProductionTime;
                            recipeDef.DisplayNameEnum = null;
                            recipeDef.DisplayNameString = componentsDef.Name;
                            recipeDef.DescriptionEnum = null;
                            recipeDef.DescriptionString = null;
                            recipeDef.Postprocess();
                        }
                        else
                            ExtendedSurvivalStatsLogging.Instance.LogInfo(typeof(WeaponsConstants), $"TryOverrideDefinitions recipe not found. Recipe=[{recipe.RecipeName}]");
                    }
                    // Add itens to faction types
                    if (componentsDef.CanPlayerOrder)
                    {
                        targetFaction.OffersList.Add(component);
                        targetFaction.OrdersList.Add(component);
                    }
                }
            }
            catch (System.Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(typeof(WeaponsConstants), ex);
            }
        }

        public static void TryOverrideDefinitions()
        {
            TryOverrideWeaponsDefinitions();
            TryOverrideWeaponMagzinesDefinitions();
            TryOverrideWeaponComponentsDefinitions();
        }

    }

}