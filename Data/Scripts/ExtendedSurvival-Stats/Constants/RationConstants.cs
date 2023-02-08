using Sandbox.Definitions;
using System;
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
            Name = LanguageProvider.GetEntry(LanguageEntries.MEATRATION_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.MEATRATION_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 375,
            OfferAmount = new Vector2I(100, 300),
            OrderAmount = new Vector2I(25, 75),
            AcquisitionAmount = new Vector2I(50, 150),
            Mass = 6.0f,
            Volume = 3.0f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    Name = LanguageProvider.GetEntry(LanguageEntries.MEATRATION_CONSTRUCTION_NAME),
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
                    Name = LanguageProvider.GetEntry(LanguageEntries.ALIENMEATRATION_CONSTRUCTION_NAME),
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
                    Name = LanguageProvider.GetEntry(LanguageEntries.NOBLEMEATRATION_CONSTRUCTION_NAME),
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
                    Name = LanguageProvider.GetEntry(LanguageEntries.ALIENNOBLEMEATRATION_CONSTRUCTION_NAME),
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
                    Name = LanguageProvider.GetEntry(LanguageEntries.FISHMEATRATION_CONSTRUCTION_NAME),
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
                    Name = LanguageProvider.GetEntry(LanguageEntries.NOBLEFISHMEATRATION_CONSTRUCTION_NAME),
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
            Name = LanguageProvider.GetEntry(LanguageEntries.VEGETABLERATION_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.VEGETABLERATION_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 295,
            OfferAmount = new Vector2I(100, 300),
            OrderAmount = new Vector2I(25, 75),
            AcquisitionAmount = new Vector2I(50, 150),
            Mass = 6.0f,
            Volume = 3.0f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    Name = LanguageProvider.GetEntry(LanguageEntries.BROCCOLIRATION_CONSTRUCTION_NAME),
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
                    Name = LanguageProvider.GetEntry(LanguageEntries.BEETROOTRATION_CONSTRUCTION_NAME),
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
                    Name = LanguageProvider.GetEntry(LanguageEntries.CARROTRATION_CONSTRUCTION_NAME),
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
            Name = LanguageProvider.GetEntry(LanguageEntries.GRAINSRATION_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.GRAINSRATION_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 275,
            OfferAmount = new Vector2I(100, 300),
            OrderAmount = new Vector2I(25, 75),
            AcquisitionAmount = new Vector2I(50, 150),
            Mass = 6.0f,
            Volume = 3.0f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    Name = LanguageProvider.GetEntry(LanguageEntries.WHEATRATION_CONSTRUCTION_NAME),
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
                    Name = LanguageProvider.GetEntry(LanguageEntries.CEREALRATION_CONSTRUCTION_NAME),
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
            PhysicalItemDefinitionOverride.TryOverrideDefinitions(RATIONS_DEFINITIONS);
        }

    }

}