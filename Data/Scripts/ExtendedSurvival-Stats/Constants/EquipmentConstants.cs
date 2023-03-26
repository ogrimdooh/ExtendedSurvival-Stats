using Sandbox.Definitions;
using System;
using System.Collections.Generic;
using VRage.Game;
using VRageMath;

namespace ExtendedSurvival.Stats
{

    public static class EquipmentConstants
    {

        public const string BODYTRACKER_SUBTYPEID = "BodyTracker";
        public static readonly UniqueEntityId BODYTRACKER_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), BODYTRACKER_SUBTYPEID);

        public const string ENHANCEDBODYTRACKER_SUBTYPEID = "EnhancedBodyTracker";
        public static readonly UniqueEntityId ENHANCEDBODYTRACKER_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), ENHANCEDBODYTRACKER_SUBTYPEID);

        public const string PROFICIENTBODYTRACKER_SUBTYPEID = "ProficientBodyTracker";
        public static readonly UniqueEntityId PROFICIENTBODYTRACKER_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), PROFICIENTBODYTRACKER_SUBTYPEID);

        public const string ELITEBODYTRACKER_SUBTYPEID = "EliteBodyTracker";
        public static readonly UniqueEntityId ELITEBODYTRACKER_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), ELITEBODYTRACKER_SUBTYPEID);

        public static readonly EquipmentDefinition BODYTRACKER_DEFINITION = new EquipmentDefinition()
        {
            Id = BODYTRACKER_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.BODYTRACKER_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.BODYTRACKER_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 375,
            OfferAmount = new Vector2I(100, 300),
            OrderAmount = new Vector2I(25, 75),
            AcquisitionAmount = new Vector2I(50, 150),
            Mass = 2.25f,
            Volume = 5.0f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "BodyTracker_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 2.56f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    { 
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 2
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NICKEL_INGOT_ID,
                            Ammount = 0.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NICKELGEAR_ID,
                            Ammount = 2
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COPPERWIRE_ID,
                            Ammount = 15
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TRANSISTOR_ID,
                            Ammount = 1
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CAPACITOR_ID,
                            Ammount = 2
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CHIP_ID,
                            Ammount = 1
                        }
                    }
                },
                new SimpleRecipeDefinition()
                {
                    RecipeName = "BodyTracker_VanilaConstruction",
                    ProductAmmount = 1,
                    ProductionTime = 2.56f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 3
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NICKEL_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILICON_INGOT_ID,
                            Ammount = 2.25f
                        }
                    }
                }
            }
        };

        public static readonly EquipmentDefinition ENHANCEDBODYTRACKER_DEFINITION = new EquipmentDefinition()
        {
            Id = ENHANCEDBODYTRACKER_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.ENHANCEDBODYTRACKER_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ENHANCEDBODYTRACKER_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 3750,
            OfferAmount = new Vector2I(100, 300),
            OrderAmount = new Vector2I(25, 75),
            AcquisitionAmount = new Vector2I(50, 150),
            Mass = 3.15f,
            Volume = 6.25f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "EnhancedBodyTracker_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 2.56f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.BODYTRACKER_ID,
                            Ammount = 1
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.STEEL_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CARBONGEAR_ID,
                            Ammount = 2
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COPPERWIRE_ID,
                            Ammount = 25
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TRANSISTOR_ID,
                            Ammount = 2
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CAPACITOR_ID,
                            Ammount = 4
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CHIP_ID,
                            Ammount = 2
                        }
                    }
                },
                new SimpleRecipeDefinition()
                {
                    RecipeName = "EnhancedBodyTracker_VanilaConstruction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.BODYTRACKER_ID,
                            Ammount = 1
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 2.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NICKEL_INGOT_ID,
                            Ammount = 0.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILICON_INGOT_ID,
                            Ammount = 0.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALT_INGOT_ID,
                            Ammount = 1.25f
                        }
                    }
                }
            }
        };

        public static readonly EquipmentDefinition PROFICIENTBODYTRACKER_DEFINITION = new EquipmentDefinition()
        {
            Id = PROFICIENTBODYTRACKER_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.PROFICIENTBODYTRACKER_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.PROFICIENTBODYTRACKER_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 37500,
            OfferAmount = new Vector2I(100, 300),
            OrderAmount = new Vector2I(25, 75),
            AcquisitionAmount = new Vector2I(50, 150),
            Mass = 3.85f,
            Volume = 7.15f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "ProficientBodyTracker_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 10.24f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ENHANCEDBODYTRACKER_ID,
                            Ammount = 1
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALTSTEEL_INGOT_ID,
                            Ammount = 2.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CARBONGEAR_ID,
                            Ammount = 2
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COPPERWIRE_ID,
                            Ammount = 15
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TRANSISTOR_ID,
                            Ammount = 1
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CAPACITOR_ID,
                            Ammount = 2
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ENHANCEDCHIP_ID,
                            Ammount = 1
                        }
                    }
                },
                new SimpleRecipeDefinition()
                {
                    RecipeName = "ProficientBodyTracker_VanilaConstruction",
                    ProductAmmount = 1,
                    ProductionTime = 10.24f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ENHANCEDBODYTRACKER_ID,
                            Ammount = 1
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 3.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NICKEL_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILICON_INGOT_ID,
                            Ammount = 0.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALT_INGOT_ID,
                            Ammount = 2.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.PLATINUM_INGOT_ID,
                            Ammount = 0.5f
                        }
                    }
                }
            }
        };

        public static readonly EquipmentDefinition ELITEBODYTRACKER_DEFINITION = new EquipmentDefinition()
        {
            Id = ELITEBODYTRACKER_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.ELITEBODYTRACKER_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ELITEBODYTRACKER_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 375000,
            OfferAmount = new Vector2I(100, 300),
            OrderAmount = new Vector2I(25, 75),
            AcquisitionAmount = new Vector2I(50, 150),
            Mass = 4.25f,
            Volume = 8.75f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "EliteBodyTracker_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 20.48f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.PROFICIENTBODYTRACKER_ID,
                            Ammount = 1
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALTSTEEL_INGOT_ID,
                            Ammount = 5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.STEELGEAR_ID,
                            Ammount = 4
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILVERCONNECTOR_ID,
                            Ammount = 2
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TRANSISTOR_ID,
                            Ammount = 2
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CAPACITOR_ID,
                            Ammount = 4
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ELITECHIP_ID,
                            Ammount = 1
                        }
                    }
                },
                new SimpleRecipeDefinition()
                {
                    RecipeName = "EliteBodyTracker_VanilaConstruction",
                    ProductAmmount = 1,
                    ProductionTime = 20.48f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.PROFICIENTBODYTRACKER_ID,
                            Ammount = 1
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 4f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NICKEL_INGOT_ID,
                            Ammount = 2.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILICON_INGOT_ID,
                            Ammount = 1.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALT_INGOT_ID,
                            Ammount = 5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.PLATINUM_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.URANIUM_INGOT_ID,
                            Ammount = 0.25f
                        }
                    }
                }
            }
        };

        public static readonly Dictionary<UniqueEntityId, EquipmentDefinition> EQUIPMENTS_DEFINITIONS = new Dictionary<UniqueEntityId, EquipmentDefinition>()
        {
            { BODYTRACKER_ID, BODYTRACKER_DEFINITION },
            { ENHANCEDBODYTRACKER_ID, ENHANCEDBODYTRACKER_DEFINITION },
            { PROFICIENTBODYTRACKER_ID, PROFICIENTBODYTRACKER_DEFINITION },
            { ELITEBODYTRACKER_ID, ELITEBODYTRACKER_DEFINITION }
        };

        public static void TryOverrideDefinitions()
        {
            PhysicalItemDefinitionOverride.TryOverrideDefinitions<EquipmentDefinition, MyPhysicalItemDefinition>(EQUIPMENTS_DEFINITIONS);
        }

    }

}