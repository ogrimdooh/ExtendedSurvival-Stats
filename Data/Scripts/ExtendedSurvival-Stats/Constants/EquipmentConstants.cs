using Sandbox.Common.ObjectBuilders.Definitions;
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

        public const string COLDTHERMALBOTTLE_SUBTYPEID = "ColdThermalBottle";
        public static readonly UniqueEntityId COLDTHERMALBOTTLE_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), COLDTHERMALBOTTLE_SUBTYPEID);

        public const string HOTTHERMALBOTTLE_SUBTYPEID = "HotThermalBottle";
        public static readonly UniqueEntityId HOTTHERMALBOTTLE_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), HOTTHERMALBOTTLE_SUBTYPEID);

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

        public static readonly EquipmentDefinition COLDTHERMALBOTTLE_DEFINITION = new EquipmentDefinition()
        {
            Id = COLDTHERMALBOTTLE_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.COLDTHERMALBOTTLE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.COLDTHERMALBOTTLE_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 1250,
            OfferAmount = new Vector2I(100, 300),
            OrderAmount = new Vector2I(25, 75),
            AcquisitionAmount = new Vector2I(50, 150),
            Mass = 5f,
            Volume = 2.5f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "ColdThermalBottle_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 2.56f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 2.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NICKEL_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ALUMINUM_INGOT_ID,
                            Ammount = 0.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COPPER_INGOT_ID,
                            Ammount = 0.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.PRESSUREREGULATOR_ID,
                            Ammount = 1
                        }
                    }
                },
                new SimpleRecipeDefinition()
                {
                    RecipeName = "ColdThermalBottle_VanilaConstruction",
                    ProductAmmount = 1,
                    ProductionTime = 2.56f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 2.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NICKEL_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILICON_INGOT_ID,
                            Ammount = 1.0f
                        }
                    }
                }
            }
        };

        public static readonly EquipmentDefinition HOTTHERMALBOTTLE_DEFINITION = new EquipmentDefinition()
        {
            Id = HOTTHERMALBOTTLE_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.HOTTHERMALBOTTLE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.HOTTHERMALBOTTLE_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 1250,
            OfferAmount = new Vector2I(100, 300),
            OrderAmount = new Vector2I(25, 75),
            AcquisitionAmount = new Vector2I(50, 150),
            Mass = 5f,
            Volume = 2.5f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "HotThermalBottle_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 2.56f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 2.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NICKEL_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ALUMINUM_INGOT_ID,
                            Ammount = 0.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COPPER_INGOT_ID,
                            Ammount = 0.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.PRESSUREREGULATOR_ID,
                            Ammount = 1
                        }
                    }
                },
                new SimpleRecipeDefinition()
                {
                    RecipeName = "HotThermalBottle_VanilaConstruction",
                    ProductAmmount = 1,
                    ProductionTime = 2.56f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 2.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NICKEL_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILICON_INGOT_ID,
                            Ammount = 1.0f
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
            { ELITEBODYTRACKER_ID, ELITEBODYTRACKER_DEFINITION },
            { COLDTHERMALBOTTLE_ID, COLDTHERMALBOTTLE_DEFINITION },
            { HOTTHERMALBOTTLE_ID, HOTTHERMALBOTTLE_DEFINITION }
        };

        public static readonly Dictionary<UniqueEntityId, int> BODYTRACKERS = new Dictionary<UniqueEntityId, int>
        {
            { BODYTRACKER_ID, 1 },
            { ENHANCEDBODYTRACKER_ID, 2 },
            { PROFICIENTBODYTRACKER_ID, 3 },
            { ELITEBODYTRACKER_ID, 4 }
        };

        public static readonly UniqueEntityId[] COLDTHERMALBOTTLES = new UniqueEntityId[]
        {
            COLDTHERMALBOTTLE_ID
        };

        public static readonly UniqueEntityId[] HOTTHERMALBOTTLES = new UniqueEntityId[]
        {
            HOTTHERMALBOTTLE_ID
        };

        public const string SCAVENGERARMOR_SUBTYPEID = "ScavengerArmor";
        public static readonly UniqueEntityId SCAVENGERARMOR_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), SCAVENGERARMOR_SUBTYPEID);

        public const string SCAVENGERARMOREXPANDED_SUBTYPEID = "ScavengerArmorExpanded";
        public static readonly UniqueEntityId SCAVENGERARMOREXPANDED_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), SCAVENGERARMOREXPANDED_SUBTYPEID);

        public const string SCAVENGERARMORHEAVY_SUBTYPEID = "ScavengerArmorHeavy";
        public static readonly UniqueEntityId SCAVENGERARMORHEAVY_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), SCAVENGERARMORHEAVY_SUBTYPEID);

        public const string SCAVENGERARMORLIGHT_SUBTYPEID = "ScavengerArmorLight";
        public static readonly UniqueEntityId SCAVENGERARMORLIGHT_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), SCAVENGERARMORLIGHT_SUBTYPEID);

        public const string HUNTERARMOR_SUBTYPEID = "HunterArmor";
        public static readonly UniqueEntityId HUNTERARMOR_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), HUNTERARMOR_SUBTYPEID);

        public const string HUNTERARMOREXPANDED_SUBTYPEID = "HunterArmorExpanded";
        public static readonly UniqueEntityId HUNTERARMOREXPANDED_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), HUNTERARMOREXPANDED_SUBTYPEID);

        public const string HUNTERARMORHEAVY_SUBTYPEID = "HunterArmorHeavy";
        public static readonly UniqueEntityId HUNTERARMORHEAVY_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), HUNTERARMORHEAVY_SUBTYPEID);

        public const string HUNTERARMORLIGHT_SUBTYPEID = "HunterArmorLight";
        public static readonly UniqueEntityId HUNTERARMORLIGHT_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), HUNTERARMORLIGHT_SUBTYPEID);

        public static readonly ArmorDefinition SCAVENGERARMOR_DEFINITION = new ArmorDefinition()
        {
            Id = SCAVENGERARMOR_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.SCAVENGERARMOR_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.SCAVENGERARMOR_DESCRIPTION),
            Type = ArmorSystemConstants.ArmorType.Normal,
            Category = ArmorSystemConstants.ArmorCategory.Work,
            ModuleSlots = 2,
            StaminaCost = 0.1f,
            HotResistence = 0.75f,
            ColdResistence = 1.25f,
            Resistences = new Dictionary<ArmorSystemConstants.DamageType, float>()
            {
                { ArmorSystemConstants.DamageType.Creature, 0.05f },
                { ArmorSystemConstants.DamageType.Bullet, 0.08f },
                { ArmorSystemConstants.DamageType.Fall, 0.07f },
                { ArmorSystemConstants.DamageType.Tool, 0.05f }
            },
            Effects = new Dictionary<ArmorSystemConstants.ArmorEffect, float>()
            {
                { ArmorSystemConstants.ArmorEffect.Gathering, 0.05f }
            },
            CanPlayerOrder = true,
            MinimalPricePerUnit = 1750,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(10, 20),
            AcquisitionAmount = new Vector2I(5, 10),
            Mass = 30f,
            Volume = 20f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "ScavengerArmor_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 12.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NICKEL_INGOT_ID,
                            Ammount = 7.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ALUMINUM_INGOT_ID,
                            Ammount = 6.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.BRASS_INGOT_ID,
                            Ammount = 3.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COPPERWIRE_ID,
                            Ammount = 125
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TRANSISTOR_ID,
                            Ammount = 50
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CAPACITOR_ID,
                            Ammount = 25
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CHIP_ID,
                            Ammount = 5
                        }
                    }
                },
                new SimpleRecipeDefinition()
                {
                    RecipeName = "ScavengerArmor_VanilaConstruction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 15f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NICKEL_INGOT_ID,
                            Ammount = 10f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILICON_INGOT_ID,
                            Ammount = 5f
                        }
                    }
                }
            }
        };

        public static readonly ArmorDefinition SCAVENGERARMORLIGHT_DEFINITION = new ArmorDefinition()
        {
            Id = SCAVENGERARMORLIGHT_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.SCAVENGERARMORLIGHT_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.SCAVENGERARMOR_DESCRIPTION),
            Type = ArmorSystemConstants.ArmorType.Light,
            Category = ArmorSystemConstants.ArmorCategory.Work,
            ModuleSlots = 2,
            StaminaCost = 0.05f,
            HotResistence = 0.75f,
            ColdResistence = 1.25f,
            Resistences = new Dictionary<ArmorSystemConstants.DamageType, float>()
            {
                { ArmorSystemConstants.DamageType.Creature, 0.025f },
                { ArmorSystemConstants.DamageType.Bullet, 0.04f },
                { ArmorSystemConstants.DamageType.Fall, 0.035f },
                { ArmorSystemConstants.DamageType.Tool, 0.025f }
            },
            Effects = new Dictionary<ArmorSystemConstants.ArmorEffect, float>()
            {
                { ArmorSystemConstants.ArmorEffect.Gathering, 0.05f }
            },
            CanPlayerOrder = true,
            MinimalPricePerUnit = 2250,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(10, 20),
            AcquisitionAmount = new Vector2I(5, 10),
            Mass = 20f,
            Volume = 15f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "ScavengerArmorLight_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 7.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ALUMINUM_INGOT_ID,
                            Ammount = 5.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NICKEL_INGOT_ID,
                            Ammount = 4.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.BRASS_INGOT_ID,
                            Ammount = 2.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COPPERWIRE_ID,
                            Ammount = 125
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TRANSISTOR_ID,
                            Ammount = 50
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CAPACITOR_ID,
                            Ammount = 25
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CHIP_ID,
                            Ammount = 5
                        }
                    }
                },
                new SimpleRecipeDefinition()
                {
                    RecipeName = "ScavengerArmorLight_VanilaConstruction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 10f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NICKEL_INGOT_ID,
                            Ammount = 5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILICON_INGOT_ID,
                            Ammount = 5f
                        }
                    }
                }
            }
        };

        public static readonly ArmorDefinition SCAVENGERARMORHEAVY_DEFINITION = new ArmorDefinition()
        {
            Id = SCAVENGERARMORHEAVY_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.SCAVENGERARMORHEAVY_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.SCAVENGERARMOR_DESCRIPTION),
            Type = ArmorSystemConstants.ArmorType.Heavy,
            Category = ArmorSystemConstants.ArmorCategory.Work,
            ModuleSlots = 2,
            StaminaCost = 0.15f,
            HotResistence = 0.75f,
            ColdResistence = 1.25f,
            Resistences = new Dictionary<ArmorSystemConstants.DamageType, float>()
            {
                { ArmorSystemConstants.DamageType.Creature, 0.075f },
                { ArmorSystemConstants.DamageType.Bullet, 0.12f },
                { ArmorSystemConstants.DamageType.Fall, 0.105f },
                { ArmorSystemConstants.DamageType.Tool, 0.075f }
            },
            Effects = new Dictionary<ArmorSystemConstants.ArmorEffect, float>()
            {
                { ArmorSystemConstants.ArmorEffect.Gathering, 0.05f }
            },
            CanPlayerOrder = true,
            MinimalPricePerUnit = 3500,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(10, 20),
            AcquisitionAmount = new Vector2I(5, 10),
            Mass = 40f,
            Volume = 25f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "ScavengerArmorHeavy_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 17.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NICKEL_INGOT_ID,
                            Ammount = 9.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ALUMINUM_INGOT_ID,
                            Ammount = 8.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.BRASS_INGOT_ID,
                            Ammount = 4.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COPPERWIRE_ID,
                            Ammount = 125
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TRANSISTOR_ID,
                            Ammount = 50
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CAPACITOR_ID,
                            Ammount = 25
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CHIP_ID,
                            Ammount = 5
                        }
                    }
                },
                new SimpleRecipeDefinition()
                {
                    RecipeName = "ScavengerArmorHeavy_VanilaConstruction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 22.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NICKEL_INGOT_ID,
                            Ammount = 12.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILICON_INGOT_ID,
                            Ammount = 5f
                        }
                    }
                }
            }
        };

        public static readonly ArmorDefinition SCAVENGERARMOREXPANDED_DEFINITION = new ArmorDefinition()
        {
            Id = SCAVENGERARMOREXPANDED_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.SCAVENGERARMOREXPANDED_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.SCAVENGERARMOR_DESCRIPTION),
            Type = ArmorSystemConstants.ArmorType.Expanded,
            Category = ArmorSystemConstants.ArmorCategory.Work,
            ModuleSlots = 3,
            StaminaCost = 0.125f,
            HotResistence = 0.75f,
            ColdResistence = 1.25f,
            Resistences = new Dictionary<ArmorSystemConstants.DamageType, float>()
            {
                { ArmorSystemConstants.DamageType.Creature, 0.025f },
                { ArmorSystemConstants.DamageType.Bullet, 0.04f },
                { ArmorSystemConstants.DamageType.Fall, 0.035f },
                { ArmorSystemConstants.DamageType.Tool, 0.025f }
            },
            Effects = new Dictionary<ArmorSystemConstants.ArmorEffect, float>()
            {
                { ArmorSystemConstants.ArmorEffect.Gathering, 0.05f }
            },
            CanPlayerOrder = true,
            MinimalPricePerUnit = 3250,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(10, 20),
            AcquisitionAmount = new Vector2I(5, 10),
            Mass = 40f,
            Volume = 25f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "ScavengerArmorExpanded_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 15.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.BRASS_INGOT_ID,
                            Ammount = 9.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NICKEL_INGOT_ID,
                            Ammount = 8.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ALUMINUM_INGOT_ID,
                            Ammount = 7.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COPPERWIRE_ID,
                            Ammount = 200
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TRANSISTOR_ID,
                            Ammount = 80
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CAPACITOR_ID,
                            Ammount = 40
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CHIP_ID,
                            Ammount = 8
                        }
                    }
                },
                new SimpleRecipeDefinition()
                {
                    RecipeName = "ScavengerArmorExpanded_VanilaConstruction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 20f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NICKEL_INGOT_ID,
                            Ammount = 15f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILICON_INGOT_ID,
                            Ammount = 5f
                        }
                    }
                }
            }
        };

        public static readonly ArmorDefinition HUNTERARMOR_DEFINITION = new ArmorDefinition()
        {
            Id = HUNTERARMOR_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.HUNTERARMOR_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.HUNTERARMOR_DESCRIPTION),
            Type = ArmorSystemConstants.ArmorType.Normal,
            Category = ArmorSystemConstants.ArmorCategory.Combat,
            ModuleSlots = 4,
            StaminaCost = 0.15f,
            HotResistence = 1.25f,
            ColdResistence = 1.75f,
            Resistences = new Dictionary<ArmorSystemConstants.DamageType, float>()
            {
                { ArmorSystemConstants.DamageType.Bullet, 0.075f },
                { ArmorSystemConstants.DamageType.Creature, 0.12f },
                { ArmorSystemConstants.DamageType.Explosion, 0.025f },
                { ArmorSystemConstants.DamageType.Fall, 0.08f },
                { ArmorSystemConstants.DamageType.Tool, 0.05f },
                { ArmorSystemConstants.DamageType.Toxicity, 0.05f }
            },
            Effects = new Dictionary<ArmorSystemConstants.ArmorEffect, float>()
            {
                { ArmorSystemConstants.ArmorEffect.CreatureDamage, 0.15f },
                { ArmorSystemConstants.ArmorEffect.TorporBonus, 0.25f }
            },
            CanPlayerOrder = true,
            MinimalPricePerUnit = 1750,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(10, 20),
            AcquisitionAmount = new Vector2I(5, 10),
            Mass = 45f,
            Volume = 30f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "HunterArmor_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.STEEL_INGOT_ID,
                            Ammount = 17.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NICKEL_INGOT_ID,
                            Ammount = 9.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ALUMINUM_INGOT_ID,
                            Ammount = 8.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.BRASS_INGOT_ID,
                            Ammount = 6.50f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALT_INGOT_ID,
                            Ammount = 3.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COPPERWIRE_ID,
                            Ammount = 200
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TRANSISTOR_ID,
                            Ammount = 80
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CAPACITOR_ID,
                            Ammount = 40
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CHIP_ID,
                            Ammount = 8
                        }
                    }
                },
                new SimpleRecipeDefinition()
                {
                    RecipeName = "HunterArmor_VanilaConstruction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 27.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NICKEL_INGOT_ID,
                            Ammount = 12.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILICON_INGOT_ID,
                            Ammount = 5f
                        }
                    }
                }
            }
        };

        public static readonly ArmorDefinition HUNTERARMORLIGHT_DEFINITION = new ArmorDefinition()
        {
            Id = HUNTERARMORLIGHT_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.HUNTERARMORLIGHT_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.HUNTERARMOR_DESCRIPTION),
            Type = ArmorSystemConstants.ArmorType.Light,
            Category = ArmorSystemConstants.ArmorCategory.Combat,
            ModuleSlots = 4,
            StaminaCost = 0.075f,
            HotResistence = 1.25f,
            ColdResistence = 1.75f,
            Resistences = new Dictionary<ArmorSystemConstants.DamageType, float>()
            {
                { ArmorSystemConstants.DamageType.Bullet, 0.0375f },
                { ArmorSystemConstants.DamageType.Creature, 0.06f },
                { ArmorSystemConstants.DamageType.Explosion, 0.0125f },
                { ArmorSystemConstants.DamageType.Fall, 0.04f },
                { ArmorSystemConstants.DamageType.Tool, 0.025f },
                { ArmorSystemConstants.DamageType.Toxicity, 0.025f }
            },
            Effects = new Dictionary<ArmorSystemConstants.ArmorEffect, float>()
            {
                { ArmorSystemConstants.ArmorEffect.CreatureDamage, 0.15f },
                { ArmorSystemConstants.ArmorEffect.TorporBonus, 0.25f }
            },
            CanPlayerOrder = true,
            MinimalPricePerUnit = 1750,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(10, 20),
            AcquisitionAmount = new Vector2I(5, 10),
            Mass = 30f,
            Volume = 20f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "HunterArmorLight_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.STEEL_INGOT_ID,
                            Ammount = 11.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NICKEL_INGOT_ID,
                            Ammount = 7.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ALUMINUM_INGOT_ID,
                            Ammount = 5.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.BRASS_INGOT_ID,
                            Ammount = 3.50f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALT_INGOT_ID,
                            Ammount = 2.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COPPERWIRE_ID,
                            Ammount = 200
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TRANSISTOR_ID,
                            Ammount = 80
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CAPACITOR_ID,
                            Ammount = 40
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CHIP_ID,
                            Ammount = 8
                        }
                    }
                },
                new SimpleRecipeDefinition()
                {
                    RecipeName = "HunterArmorLight_VanilaConstruction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 15f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NICKEL_INGOT_ID,
                            Ammount = 10f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILICON_INGOT_ID,
                            Ammount = 5f
                        }
                    }
                }
            }
        };

        public static readonly ArmorDefinition HUNTERARMORHEAVY_DEFINITION = new ArmorDefinition()
        {
            Id = HUNTERARMORHEAVY_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.HUNTERARMORHEAVY_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.HUNTERARMOR_DESCRIPTION),
            Type = ArmorSystemConstants.ArmorType.Heavy,
            Category = ArmorSystemConstants.ArmorCategory.Combat,
            ModuleSlots = 4,
            StaminaCost = 0.225f,
            HotResistence = 1.25f,
            ColdResistence = 1.75f,
            Resistences = new Dictionary<ArmorSystemConstants.DamageType, float>()
            {
                { ArmorSystemConstants.DamageType.Bullet, 0.1125f },
                { ArmorSystemConstants.DamageType.Creature, 0.18f },
                { ArmorSystemConstants.DamageType.Explosion, 0.0375f },
                { ArmorSystemConstants.DamageType.Fall, 0.12f },
                { ArmorSystemConstants.DamageType.Tool, 0.075f },
                { ArmorSystemConstants.DamageType.Toxicity, 0.075f }
            },
            Effects = new Dictionary<ArmorSystemConstants.ArmorEffect, float>()
            {
                { ArmorSystemConstants.ArmorEffect.CreatureDamage, 0.15f },
                { ArmorSystemConstants.ArmorEffect.TorporBonus, 0.25f }
            },
            CanPlayerOrder = true,
            MinimalPricePerUnit = 1750,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(10, 20),
            AcquisitionAmount = new Vector2I(5, 10),
            Mass = 60f,
            Volume = 40f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "HunterArmorHeavy_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.STEEL_INGOT_ID,
                            Ammount = 17.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NICKEL_INGOT_ID,
                            Ammount = 9.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ALUMINUM_INGOT_ID,
                            Ammount = 8.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.BRASS_INGOT_ID,
                            Ammount = 6.50f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALT_INGOT_ID,
                            Ammount = 3.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COPPERWIRE_ID,
                            Ammount = 200
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TRANSISTOR_ID,
                            Ammount = 80
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CAPACITOR_ID,
                            Ammount = 40
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CHIP_ID,
                            Ammount = 8
                        }
                    }
                },
                new SimpleRecipeDefinition()
                {
                    RecipeName = "HunterArmorHeavy_VanilaConstruction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 32.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NICKEL_INGOT_ID,
                            Ammount = 17.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILICON_INGOT_ID,
                            Ammount = 10f
                        }
                    }
                }
            }
        };

        public static readonly ArmorDefinition HUNTERARMOREXPANDED_DEFINITION = new ArmorDefinition()
        {
            Id = HUNTERARMOREXPANDED_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.HUNTERARMOREXPANDED_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.HUNTERARMOR_DESCRIPTION),
            Type = ArmorSystemConstants.ArmorType.Heavy,
            Category = ArmorSystemConstants.ArmorCategory.Combat,
            ModuleSlots = 5,
            StaminaCost = 0.1875f,
            HotResistence = 1.25f,
            ColdResistence = 1.75f,
            Resistences = new Dictionary<ArmorSystemConstants.DamageType, float>()
            {
                { ArmorSystemConstants.DamageType.Bullet, 0.0375f },
                { ArmorSystemConstants.DamageType.Creature, 0.06f },
                { ArmorSystemConstants.DamageType.Explosion, 0.0125f },
                { ArmorSystemConstants.DamageType.Fall, 0.04f },
                { ArmorSystemConstants.DamageType.Tool, 0.025f },
                { ArmorSystemConstants.DamageType.Toxicity, 0.025f }
            },
            Effects = new Dictionary<ArmorSystemConstants.ArmorEffect, float>()
            {
                { ArmorSystemConstants.ArmorEffect.CreatureDamage, 0.15f },
                { ArmorSystemConstants.ArmorEffect.TorporBonus, 0.25f }
            },
            CanPlayerOrder = true,
            MinimalPricePerUnit = 1750,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(10, 20),
            AcquisitionAmount = new Vector2I(5, 10),
            Mass = 60f,
            Volume = 40f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "HunterArmorExpanded_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.STEEL_INGOT_ID,
                            Ammount = 17.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NICKEL_INGOT_ID,
                            Ammount = 9.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ALUMINUM_INGOT_ID,
                            Ammount = 8.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.BRASS_INGOT_ID,
                            Ammount = 6.50f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALT_INGOT_ID,
                            Ammount = 3.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COPPERWIRE_ID,
                            Ammount = 300
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TRANSISTOR_ID,
                            Ammount = 120
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CAPACITOR_ID,
                            Ammount = 60
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CHIP_ID,
                            Ammount = 12
                        }
                    }
                },
                new SimpleRecipeDefinition()
                {
                    RecipeName = "HunterArmorExpanded_VanilaConstruction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 32.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NICKEL_INGOT_ID,
                            Ammount = 17.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILICON_INGOT_ID,
                            Ammount = 10f
                        }
                    }
                }
            }
        };

        public static readonly Dictionary<UniqueEntityId, ArmorDefinition> ARMORS_DEFINITIONS = new Dictionary<UniqueEntityId, ArmorDefinition>()
        {
            { SCAVENGERARMOR_ID, SCAVENGERARMOR_DEFINITION },
            { SCAVENGERARMORLIGHT_ID, SCAVENGERARMORLIGHT_DEFINITION },
            { SCAVENGERARMORHEAVY_ID, SCAVENGERARMORHEAVY_DEFINITION },
            { SCAVENGERARMOREXPANDED_ID, SCAVENGERARMOREXPANDED_DEFINITION },
            { HUNTERARMOR_ID, HUNTERARMOR_DEFINITION },
            { HUNTERARMORLIGHT_ID, HUNTERARMORLIGHT_DEFINITION },
            { HUNTERARMORHEAVY_ID, HUNTERARMORHEAVY_DEFINITION },
            { HUNTERARMOREXPANDED_ID, HUNTERARMOREXPANDED_DEFINITION }
        };

        public const string COLDTHERMALREGULATOR_SUBTYPEID = "ColdThermalRegulator";
        public static readonly UniqueEntityId COLDTHERMALREGULATOR_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), COLDTHERMALREGULATOR_SUBTYPEID);

        public const string ENHANCEDCOLDTHERMALREGULATOR_SUBTYPEID = "EnhancedColdThermalRegulator";
        public static readonly UniqueEntityId ENHANCEDCOLDTHERMALREGULATOR_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), ENHANCEDCOLDTHERMALREGULATOR_SUBTYPEID);

        public const string PROFICIENTCOLDTHERMALREGULATOR_SUBTYPEID = "ProficientColdThermalRegulator";
        public static readonly UniqueEntityId PROFICIENTCOLDTHERMALREGULATOR_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), PROFICIENTCOLDTHERMALREGULATOR_SUBTYPEID);

        public const string ELITECOLDTHERMALREGULATOR_SUBTYPEID = "EliteColdThermalRegulator";
        public static readonly UniqueEntityId ELITECOLDTHERMALREGULATOR_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), ELITECOLDTHERMALREGULATOR_SUBTYPEID);

        public const string HOTTHERMALREGULATOR_SUBTYPEID = "HotThermalRegulator";
        public static readonly UniqueEntityId HOTTHERMALREGULATOR_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), HOTTHERMALREGULATOR_SUBTYPEID);

        public const string ENHANCEDHOTTHERMALREGULATOR_SUBTYPEID = "EnhancedHotThermalRegulator";
        public static readonly UniqueEntityId ENHANCEDHOTTHERMALREGULATOR_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), ENHANCEDHOTTHERMALREGULATOR_SUBTYPEID);

        public const string PROFICIENTHOTTHERMALREGULATOR_SUBTYPEID = "ProficientHotThermalRegulator";
        public static readonly UniqueEntityId PROFICIENTHOTTHERMALREGULATOR_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), PROFICIENTHOTTHERMALREGULATOR_SUBTYPEID);

        public const string ELITEHOTTHERMALREGULATOR_SUBTYPEID = "EliteHotThermalRegulator";
        public static readonly UniqueEntityId ELITEHOTTHERMALREGULATOR_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), ELITEHOTTHERMALREGULATOR_SUBTYPEID);

        public const string SHIELDGENERATOR_SUBTYPEID = "ShieldGenerator";
        public static readonly UniqueEntityId SHIELDGENERATOR_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), SHIELDGENERATOR_SUBTYPEID);

        public const string ENHANCEDSHIELDGENERATOR_SUBTYPEID = "EnhancedShieldGenerator";
        public static readonly UniqueEntityId ENHANCEDSHIELDGENERATOR_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), ENHANCEDSHIELDGENERATOR_SUBTYPEID);

        public const string PROFICIENTSHIELDGENERATOR_SUBTYPEID = "ProficientShieldGenerator";
        public static readonly UniqueEntityId PROFICIENTSHIELDGENERATOR_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), PROFICIENTSHIELDGENERATOR_SUBTYPEID);

        public const string ELITESHIELDGENERATOR_SUBTYPEID = "EliteShieldGenerator";
        public static readonly UniqueEntityId ELITESHIELDGENERATOR_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), ELITESHIELDGENERATOR_SUBTYPEID);

        public const string SHIELDCAPACITOR_SUBTYPEID = "ShieldCapacitor";
        public static readonly UniqueEntityId SHIELDCAPACITOR_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), SHIELDCAPACITOR_SUBTYPEID);

        public const string ENHANCEDSHIELDCAPACITOR_SUBTYPEID = "EnhancedShieldCapacitor";
        public static readonly UniqueEntityId ENHANCEDSHIELDCAPACITOR_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), ENHANCEDSHIELDCAPACITOR_SUBTYPEID);

        public const string PROFICIENTSHIELDCAPACITOR_SUBTYPEID = "ProficientShieldCapacitor";
        public static readonly UniqueEntityId PROFICIENTSHIELDCAPACITOR_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), PROFICIENTSHIELDCAPACITOR_SUBTYPEID);

        public const string ELITESHIELDCAPACITOR_SUBTYPEID = "EliteShieldCapacitor";
        public static readonly UniqueEntityId ELITESHIELDCAPACITOR_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), ELITESHIELDCAPACITOR_SUBTYPEID);

        public const string SHIELDTRANSISTOR_SUBTYPEID = "ShieldTransistor";
        public static readonly UniqueEntityId SHIELDTRANSISTOR_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), SHIELDTRANSISTOR_SUBTYPEID);

        public const string ENHANCEDSHIELDTRANSISTOR_SUBTYPEID = "EnhancedShieldTransistor";
        public static readonly UniqueEntityId ENHANCEDSHIELDTRANSISTOR_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), ENHANCEDSHIELDTRANSISTOR_SUBTYPEID);

        public const string PROFICIENTSHIELDTRANSISTOR_SUBTYPEID = "ProficientShieldTransistor";
        public static readonly UniqueEntityId PROFICIENTSHIELDTRANSISTOR_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), PROFICIENTSHIELDTRANSISTOR_SUBTYPEID);

        public const string ELITESHIELDTRANSISTOR_SUBTYPEID = "EliteShieldTransistor";
        public static readonly UniqueEntityId ELITESHIELDTRANSISTOR_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), ELITESHIELDTRANSISTOR_SUBTYPEID);

        public const string SHIELDSPIKE_SUBTYPEID = "ShieldSpike";
        public static readonly UniqueEntityId SHIELDSPIKE_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), SHIELDSPIKE_SUBTYPEID);

        public const string ENHANCEDSHIELDSPIKE_SUBTYPEID = "EnhancedShieldSpike";
        public static readonly UniqueEntityId ENHANCEDSHIELDSPIKE_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), ENHANCEDSHIELDSPIKE_SUBTYPEID);

        public const string PROFICIENTSHIELDSPIKE_SUBTYPEID = "ProficientShieldSpike";
        public static readonly UniqueEntityId PROFICIENTSHIELDSPIKE_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), PROFICIENTSHIELDSPIKE_SUBTYPEID);

        public const string ELITESHIELDSPIKE_SUBTYPEID = "EliteShieldSpike";
        public static readonly UniqueEntityId ELITESHIELDSPIKE_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), ELITESHIELDSPIKE_SUBTYPEID);

        /* Thermal Regulators */

        public static readonly ArmorModuleDefinition COLDTHERMALREGULATOR_DEFINITION = new ArmorModuleDefinition()
        {
            Id = COLDTHERMALREGULATOR_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.COLDTHERMALREGULATOR_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.COLDTHERMALREGULATOR_DESCRIPTION),
            UseCategory = ArmorSystemConstants.ArmorCategory.Work | ArmorSystemConstants.ArmorCategory.Combat,
            Attributes = new Dictionary<ArmorSystemConstants.ModuleAttribute, float>()
            {
                { ArmorSystemConstants.ModuleAttribute.Efficiency, 0.15f }
            },
            CanPlayerOrder = true,
            MinimalPricePerUnit = 1750,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(10, 20),
            AcquisitionAmount = new Vector2I(5, 10),
            Mass = 5f,
            Volume = 2.5f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "ColdThermalRegulator_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 2.56f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 1.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NICKEL_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ALUMINUM_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.BRASS_INGOT_ID,
                            Ammount = 0.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COPPERWIRE_ID,
                            Ammount = 25
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TRANSISTOR_ID,
                            Ammount = 10
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CAPACITOR_ID,
                            Ammount = 5
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
                    RecipeName = "ColdThermalRegulator_VanilaConstruction",
                    ProductAmmount = 1,
                    ProductionTime = 2.56f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 2f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NICKEL_INGOT_ID,
                            Ammount = 1.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILICON_INGOT_ID,
                            Ammount = 1.5f
                        }
                    }
                }
            }
        };

        public static readonly ArmorModuleDefinition ENHANCEDCOLDTHERMALREGULATOR_DEFINITION = new ArmorModuleDefinition()
        {
            Id = ENHANCEDCOLDTHERMALREGULATOR_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.ENHANCEDCOLDTHERMALREGULATOR_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.COLDTHERMALREGULATOR_DESCRIPTION),
            UseCategory = ArmorSystemConstants.ArmorCategory.Work | ArmorSystemConstants.ArmorCategory.Combat,
            Attributes = new Dictionary<ArmorSystemConstants.ModuleAttribute, float>()
            {
                { ArmorSystemConstants.ModuleAttribute.Efficiency, 0.25f }
            },
            CanPlayerOrder = true,
            MinimalPricePerUnit = 17500,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(10, 20),
            AcquisitionAmount = new Vector2I(5, 10),
            Mass = 5f,
            Volume = 2.5f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "EnhancedColdThermalRegulator_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 2.56f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.STEEL_INGOT_ID,
                            Ammount = 1.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALT_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ALUMINUM_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.BRASS_INGOT_ID,
                            Ammount = 0.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILVERCONNECTOR_ID,
                            Ammount = 2
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COPPERWIRE_ID,
                            Ammount = 23
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TRANSISTOR_ID,
                            Ammount = 10
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CAPACITOR_ID,
                            Ammount = 5
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
                    RecipeName = "EnhancedColdThermalRegulator_VanilaConstruction",
                    ProductAmmount = 1,
                    ProductionTime = 2.56f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 2.0f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILICON_INGOT_ID,
                            Ammount = 1.0f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NICKEL_INGOT_ID,
                            Ammount = 0.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALT_INGOT_ID,
                            Ammount = 0.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILVER_INGOT_ID,
                            Ammount = 0.5f
                        }
                    }
                }
            }
        };

        public static readonly ArmorModuleDefinition PROFICIENTCOLDTHERMALREGULATOR_DEFINITION = new ArmorModuleDefinition()
        {
            Id = PROFICIENTCOLDTHERMALREGULATOR_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.PROFICIENTCOLDTHERMALREGULATOR_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.COLDTHERMALREGULATOR_DESCRIPTION),
            UseCategory = ArmorSystemConstants.ArmorCategory.Work | ArmorSystemConstants.ArmorCategory.Combat,
            Attributes = new Dictionary<ArmorSystemConstants.ModuleAttribute, float>()
            {
                { ArmorSystemConstants.ModuleAttribute.Efficiency, 0.35f }
            },
            CanPlayerOrder = true,
            MinimalPricePerUnit = 175000,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(10, 20),
            AcquisitionAmount = new Vector2I(5, 10),
            Mass = 5f,
            Volume = 2.5f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "ProficientColdThermalRegulator_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALTSTEEL_INGOT_ID,
                            Ammount = 1.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.PLATINUM_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ALUMINUMMG_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.BRASS_INGOT_ID,
                            Ammount = 0.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SUPERCONDUCTOR_ID,
                            Ammount = 2
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILVERCONNECTOR_ID,
                            Ammount = 23
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TRANSISTOR_ID,
                            Ammount = 10
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CAPACITOR_ID,
                            Ammount = 5
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.PROFICIENTCHIP_ID,
                            Ammount = 1
                        }
                    }
                },
                new SimpleRecipeDefinition()
                {
                    RecipeName = "ProficientColdThermalRegulator_VanilaConstruction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 2.0f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILICON_INGOT_ID,
                            Ammount = 1.0f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NICKEL_INGOT_ID,
                            Ammount = 0.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALT_INGOT_ID,
                            Ammount = 0.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILVER_INGOT_ID,
                            Ammount = 0.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.GOLD_INGOT_ID,
                            Ammount = 0.25f
                        }
                    }
                }
            }
        };

        public static readonly ArmorModuleDefinition ELITECOLDTHERMALREGULATOR_DEFINITION = new ArmorModuleDefinition()
        {
            Id = ELITECOLDTHERMALREGULATOR_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.ELITECOLDTHERMALREGULATOR_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.COLDTHERMALREGULATOR_DESCRIPTION),
            UseCategory = ArmorSystemConstants.ArmorCategory.Work | ArmorSystemConstants.ArmorCategory.Combat,
            Attributes = new Dictionary<ArmorSystemConstants.ModuleAttribute, float>()
            {
                { ArmorSystemConstants.ModuleAttribute.Efficiency, 0.45f }
            },
            CanPlayerOrder = true,
            MinimalPricePerUnit = 1750000,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(10, 20),
            AcquisitionAmount = new Vector2I(5, 10),
            Mass = 5f,
            Volume = 2.5f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "EliteColdThermalRegulator_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 10.24f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TUNGSTENSTEEL_INGOT_ID,
                            Ammount = 1.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.PLATINUMIR_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ALUMINUMMG_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALTSTEEL_INGOT_ID,
                            Ammount = 0.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.BERYLLIUMCOPPERWIRE_ID,
                            Ammount = 2
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SUPERCONDUCTOR_ID,
                            Ammount = 23
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TRANSISTOR_ID,
                            Ammount = 10
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CAPACITOR_ID,
                            Ammount = 5
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
                    RecipeName = "EliteColdThermalRegulator_VanilaConstruction",
                    ProductAmmount = 1,
                    ProductionTime = 10.24f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 2.0f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILICON_INGOT_ID,
                            Ammount = 1.0f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NICKEL_INGOT_ID,
                            Ammount = 0.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALT_INGOT_ID,
                            Ammount = 0.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.PLATINUM_INGOT_ID,
                            Ammount = 0.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILVER_INGOT_ID,
                            Ammount = 0.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.GOLD_INGOT_ID,
                            Ammount = 0.25f
                        }
                    }
                }
            }
        };

        public static readonly ArmorModuleDefinition HOTTHERMALREGULATOR_DEFINITION = new ArmorModuleDefinition()
        {
            Id = HOTTHERMALREGULATOR_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.HOTTHERMALREGULATOR_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.HOTTHERMALREGULATOR_DESCRIPTION),
            UseCategory = ArmorSystemConstants.ArmorCategory.Work | ArmorSystemConstants.ArmorCategory.Combat,
            Attributes = new Dictionary<ArmorSystemConstants.ModuleAttribute, float>()
            {
                { ArmorSystemConstants.ModuleAttribute.Efficiency, 0.15f }
            },
            CanPlayerOrder = true,
            MinimalPricePerUnit = 1750,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(10, 20),
            AcquisitionAmount = new Vector2I(5, 10),
            Mass = 5f,
            Volume = 2.5f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "HotThermalRegulator_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 2.56f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 1.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NICKEL_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ALUMINUM_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.BRASS_INGOT_ID,
                            Ammount = 0.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COPPERWIRE_ID,
                            Ammount = 25
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TRANSISTOR_ID,
                            Ammount = 10
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CAPACITOR_ID,
                            Ammount = 5
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
                    RecipeName = "HotThermalRegulator_VanilaConstruction",
                    ProductAmmount = 1,
                    ProductionTime = 2.56f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 2f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NICKEL_INGOT_ID,
                            Ammount = 1.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILICON_INGOT_ID,
                            Ammount = 1.5f
                        }
                    }
                }
            }
        };

        public static readonly ArmorModuleDefinition ENHANCEDHOTTHERMALREGULATOR_DEFINITION = new ArmorModuleDefinition()
        {
            Id = ENHANCEDHOTTHERMALREGULATOR_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.ENHANCEDHOTTHERMALREGULATOR_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.HOTTHERMALREGULATOR_DESCRIPTION),
            UseCategory = ArmorSystemConstants.ArmorCategory.Work | ArmorSystemConstants.ArmorCategory.Combat,
            Attributes = new Dictionary<ArmorSystemConstants.ModuleAttribute, float>()
            {
                { ArmorSystemConstants.ModuleAttribute.Efficiency, 0.25f }
            },
            CanPlayerOrder = true,
            MinimalPricePerUnit = 17500,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(10, 20),
            AcquisitionAmount = new Vector2I(5, 10),
            Mass = 5f,
            Volume = 2.5f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "EnhancedHotThermalRegulator_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 2.56f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.STEEL_INGOT_ID,
                            Ammount = 1.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALT_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ALUMINUM_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.BRASS_INGOT_ID,
                            Ammount = 0.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILVERCONNECTOR_ID,
                            Ammount = 2
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COPPERWIRE_ID,
                            Ammount = 23
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TRANSISTOR_ID,
                            Ammount = 10
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CAPACITOR_ID,
                            Ammount = 5
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
                    RecipeName = "EnhancedHotThermalRegulator_VanilaConstruction",
                    ProductAmmount = 1,
                    ProductionTime = 2.56f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 2.0f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILICON_INGOT_ID,
                            Ammount = 1.0f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NICKEL_INGOT_ID,
                            Ammount = 0.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALT_INGOT_ID,
                            Ammount = 0.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILVER_INGOT_ID,
                            Ammount = 0.5f
                        }
                    }
                }
            }
        };

        public static readonly ArmorModuleDefinition PROFICIENTHOTTHERMALREGULATOR_DEFINITION = new ArmorModuleDefinition()
        {
            Id = PROFICIENTHOTTHERMALREGULATOR_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.PROFICIENTHOTTHERMALREGULATOR_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.HOTTHERMALREGULATOR_DESCRIPTION),
            UseCategory = ArmorSystemConstants.ArmorCategory.Work | ArmorSystemConstants.ArmorCategory.Combat,
            Attributes = new Dictionary<ArmorSystemConstants.ModuleAttribute, float>()
            {
                { ArmorSystemConstants.ModuleAttribute.Efficiency, 0.35f }
            },
            CanPlayerOrder = true,
            MinimalPricePerUnit = 175000,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(10, 20),
            AcquisitionAmount = new Vector2I(5, 10),
            Mass = 5f,
            Volume = 2.5f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "ProficientHotThermalRegulator_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALTSTEEL_INGOT_ID,
                            Ammount = 1.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.PLATINUM_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ALUMINUMMG_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.BRASS_INGOT_ID,
                            Ammount = 0.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SUPERCONDUCTOR_ID,
                            Ammount = 2
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILVERCONNECTOR_ID,
                            Ammount = 23
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TRANSISTOR_ID,
                            Ammount = 10
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CAPACITOR_ID,
                            Ammount = 5
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.PROFICIENTCHIP_ID,
                            Ammount = 1
                        }
                    }
                },
                new SimpleRecipeDefinition()
                {
                    RecipeName = "ProficientHotThermalRegulator_VanilaConstruction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 2.0f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILICON_INGOT_ID,
                            Ammount = 1.0f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NICKEL_INGOT_ID,
                            Ammount = 0.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALT_INGOT_ID,
                            Ammount = 0.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILVER_INGOT_ID,
                            Ammount = 0.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.GOLD_INGOT_ID,
                            Ammount = 0.25f
                        }
                    }
                }
            }
        };

        public static readonly ArmorModuleDefinition ELITEHOTTHERMALREGULATOR_DEFINITION = new ArmorModuleDefinition()
        {
            Id = ELITEHOTTHERMALREGULATOR_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.ELITEHOTTHERMALREGULATOR_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.HOTTHERMALREGULATOR_DESCRIPTION),
            UseCategory = ArmorSystemConstants.ArmorCategory.Work | ArmorSystemConstants.ArmorCategory.Combat,
            Attributes = new Dictionary<ArmorSystemConstants.ModuleAttribute, float>()
            {
                { ArmorSystemConstants.ModuleAttribute.Efficiency, 0.45f }
            },
            CanPlayerOrder = true,
            MinimalPricePerUnit = 1750000,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(10, 20),
            AcquisitionAmount = new Vector2I(5, 10),
            Mass = 5f,
            Volume = 2.5f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "EliteHotThermalRegulator_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 10.24f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TUNGSTENSTEEL_INGOT_ID,
                            Ammount = 1.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.PLATINUMIR_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ALUMINUMMG_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALTSTEEL_INGOT_ID,
                            Ammount = 0.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.BERYLLIUMCOPPERWIRE_ID,
                            Ammount = 2
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SUPERCONDUCTOR_ID,
                            Ammount = 23
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TRANSISTOR_ID,
                            Ammount = 10
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CAPACITOR_ID,
                            Ammount = 5
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
                    RecipeName = "EliteHotThermalRegulator_VanilaConstruction",
                    ProductAmmount = 1,
                    ProductionTime = 10.24f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 2.0f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILICON_INGOT_ID,
                            Ammount = 1.0f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.NICKEL_INGOT_ID,
                            Ammount = 0.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALT_INGOT_ID,
                            Ammount = 0.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.PLATINUM_INGOT_ID,
                            Ammount = 0.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILVER_INGOT_ID,
                            Ammount = 0.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.GOLD_INGOT_ID,
                            Ammount = 0.25f
                        }
                    }
                }
            }
        };

        /* Shield Generators */

        public static readonly ArmorModuleDefinition SHIELDGENERATOR_DEFINITION = new ArmorModuleDefinition()
        {
            Id = SHIELDGENERATOR_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.SHIELDGENERATOR_NAME),
            Description = string.Format(LanguageProvider.GetEntry(LanguageEntries.SHIELDGENERATOR_DESCRIPTION), PlayerActionsController.TIME_BEFORE_CAN_REGENERATE / 1000),
            UseCategory = ArmorSystemConstants.ArmorCategory.Work | ArmorSystemConstants.ArmorCategory.Combat,
            Attributes = new Dictionary<ArmorSystemConstants.ModuleAttribute, float>()
            {
                { ArmorSystemConstants.ModuleAttribute.Capacity, 350f },
                { ArmorSystemConstants.ModuleAttribute.RechargeSpeed, 10f },
                { ArmorSystemConstants.ModuleAttribute.EnergyConsumption, 0.25f }
            },
            CanPlayerOrder = true,
            MinimalPricePerUnit = 1750,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(10, 20),
            AcquisitionAmount = new Vector2I(5, 10),
            Mass = 10f,
            Volume = 2.5f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "ShieldGenerator_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.LITHIUM_INGOT_ID,
                            Ammount = 4.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.STEEL_INGOT_ID,
                            Ammount = 3.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.GOLD_INGOT_ID,
                            Ammount = 2.0f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILVERCONNECTOR_ID,
                            Ammount = 10
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COPPERWIRE_ID,
                            Ammount = 40
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TRANSISTOR_ID,
                            Ammount = 20
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CAPACITOR_ID,
                            Ammount = 10
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
                    RecipeName = "ShieldGenerator_VanilaConstruction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 3.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALT_INGOT_ID,
                            Ammount = 2.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILVER_INGOT_ID,
                            Ammount = 3.75f
                        }
                    }
                }
            }
        };

        public static readonly ArmorModuleDefinition ENHANCEDSHIELDGENERATOR_DEFINITION = new ArmorModuleDefinition()
        {
            Id = ENHANCEDSHIELDGENERATOR_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.ENHANCEDSHIELDGENERATOR_NAME),
            Description = string.Format(LanguageProvider.GetEntry(LanguageEntries.SHIELDGENERATOR_DESCRIPTION), PlayerActionsController.TIME_BEFORE_CAN_REGENERATE / 1000),
            UseCategory = ArmorSystemConstants.ArmorCategory.Work | ArmorSystemConstants.ArmorCategory.Combat,
            Attributes = new Dictionary<ArmorSystemConstants.ModuleAttribute, float>()
            {
                { ArmorSystemConstants.ModuleAttribute.Capacity, 450f },
                { ArmorSystemConstants.ModuleAttribute.RechargeSpeed, 12.5f },
                { ArmorSystemConstants.ModuleAttribute.EnergyConsumption, 0.3f }
            },
            CanPlayerOrder = true,
            MinimalPricePerUnit = 17500,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(10, 20),
            AcquisitionAmount = new Vector2I(5, 10),
            Mass = 10f,
            Volume = 2.5f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "EnhancedShieldGenerator_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.LITHIUM_INGOT_ID,
                            Ammount = 4.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALTSTEEL_INGOT_ID,
                            Ammount = 3.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.GOLD_INGOT_ID,
                            Ammount = 1.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.PLATINUM_INGOT_ID,
                            Ammount = 0.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SUPERCONDUCTOR_ID,
                            Ammount = 10
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILVERCONNECTOR_ID,
                            Ammount = 40
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TRANSISTOR_ID,
                            Ammount = 20
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CAPACITOR_ID,
                            Ammount = 10
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ENHANCEDCHIP_ID,
                            Ammount = 2
                        }
                    }
                },
                new SimpleRecipeDefinition()
                {
                    RecipeName = "EnhancedShieldGenerator_VanilaConstruction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 3.0f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALT_INGOT_ID,
                            Ammount = 2.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILVER_INGOT_ID,
                            Ammount = 3.0f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.GOLD_INGOT_ID,
                            Ammount = 1.75f
                        }
                    }
                }
            }
        };

        public static readonly ArmorModuleDefinition PROFICIENTSHIELDGENERATOR_DEFINITION = new ArmorModuleDefinition()
        {
            Id = PROFICIENTSHIELDGENERATOR_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.PROFICIENTSHIELDGENERATOR_NAME),
            Description = string.Format(LanguageProvider.GetEntry(LanguageEntries.SHIELDGENERATOR_DESCRIPTION), PlayerActionsController.TIME_BEFORE_CAN_REGENERATE / 1000),
            UseCategory = ArmorSystemConstants.ArmorCategory.Work | ArmorSystemConstants.ArmorCategory.Combat,
            Attributes = new Dictionary<ArmorSystemConstants.ModuleAttribute, float>()
            {
                { ArmorSystemConstants.ModuleAttribute.Capacity, 550f },
                { ArmorSystemConstants.ModuleAttribute.RechargeSpeed, 15f },
                { ArmorSystemConstants.ModuleAttribute.EnergyConsumption, 0.35f }
            },
            CanPlayerOrder = true,
            MinimalPricePerUnit = 175000,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(10, 20),
            AcquisitionAmount = new Vector2I(5, 10),
            Mass = 10f,
            Volume = 2.5f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "ProficientShieldGenerator_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.LITHIUM_INGOT_ID,
                            Ammount = 4.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.BERYLLIUMSTEEL_INGOT_ID,
                            Ammount = 3.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.GOLD_INGOT_ID,
                            Ammount = 1.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ALUMINUMMG_INGOT_ID,
                            Ammount = 0.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.PLATINUM_INGOT_ID,
                            Ammount = 0.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SUPERCONDUCTOR_ID,
                            Ammount = 10
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILVERCONNECTOR_ID,
                            Ammount = 40
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TRANSISTOR_ID,
                            Ammount = 20
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CAPACITOR_ID,
                            Ammount = 10
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.PROFICIENTCHIP_ID,
                            Ammount = 2
                        }
                    }
                },
                new SimpleRecipeDefinition()
                {
                    RecipeName = "ProficientShieldGenerator_VanilaConstruction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 3.0f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALT_INGOT_ID,
                            Ammount = 2.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILVER_INGOT_ID,
                            Ammount = 3.0f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.GOLD_INGOT_ID,
                            Ammount = 1.25f
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

        public static readonly ArmorModuleDefinition ELITESHIELDGENERATOR_DEFINITION = new ArmorModuleDefinition()
        {
            Id = ELITESHIELDGENERATOR_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.ELITESHIELDGENERATOR_NAME),
            Description = string.Format(LanguageProvider.GetEntry(LanguageEntries.SHIELDGENERATOR_DESCRIPTION), PlayerActionsController.TIME_BEFORE_CAN_REGENERATE / 1000),
            UseCategory = ArmorSystemConstants.ArmorCategory.Work | ArmorSystemConstants.ArmorCategory.Combat,
            Attributes = new Dictionary<ArmorSystemConstants.ModuleAttribute, float>()
            {
                { ArmorSystemConstants.ModuleAttribute.Capacity, 650f },
                { ArmorSystemConstants.ModuleAttribute.RechargeSpeed, 20f },
                { ArmorSystemConstants.ModuleAttribute.EnergyConsumption, 0.4f }
            },
            CanPlayerOrder = true,
            MinimalPricePerUnit = 1750000,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(10, 20),
            AcquisitionAmount = new Vector2I(5, 10),
            Mass = 10f,
            Volume = 2.5f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "EliteShieldGenerator_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.LITHIUM_INGOT_ID,
                            Ammount = 4.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TUNGSTENSTEEL_INGOT_ID,
                            Ammount = 3.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.GOLD_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ALUMINUMMG_INGOT_ID,
                            Ammount = 0.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.PLATINUMIR_INGOT_ID,
                            Ammount = 0.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.BERYLLIUMCOPPERWIRE_ID,
                            Ammount = 10
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SUPERCONDUCTOR_ID,
                            Ammount = 40
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TRANSISTOR_ID,
                            Ammount = 20
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CAPACITOR_ID,
                            Ammount = 10
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ELITECHIP_ID,
                            Ammount = 2
                        }
                    }
                },
                new SimpleRecipeDefinition()
                {
                    RecipeName = "EliteShieldGenerator_VanilaConstruction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 3.0f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALT_INGOT_ID,
                            Ammount = 2.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILVER_INGOT_ID,
                            Ammount = 2.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.GOLD_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.PLATINUM_INGOT_ID,
                            Ammount = 0.5f
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

        /* Shield Transistors */

        public static readonly ArmorModuleDefinition SHIELDTRANSISTOR_DEFINITION = new ArmorModuleDefinition()
        {
            Id = SHIELDTRANSISTOR_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.SHIELDTRANSISTOR_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.SHIELDTRANSISTOR_DESCRIPTION),
            UseCategory = ArmorSystemConstants.ArmorCategory.Work | ArmorSystemConstants.ArmorCategory.Combat,
            Attributes = new Dictionary<ArmorSystemConstants.ModuleAttribute, float>()
            {
                { ArmorSystemConstants.ModuleAttribute.RechargeSpeedBonus, -0.05f },
                { ArmorSystemConstants.ModuleAttribute.EnergyConsumptionBonus, -0.1f }
            },
            CanPlayerOrder = true,
            MinimalPricePerUnit = 1750,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(10, 20),
            AcquisitionAmount = new Vector2I(5, 10),
            Mass = 5f,
            Volume = 2.5f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "ShieldTransistor_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.STEEL_INGOT_ID,
                            Ammount = 3.0f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.LITHIUM_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.GOLD_INGOT_ID,
                            Ammount = 0.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILVERCONNECTOR_ID,
                            Ammount = 5
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COPPERWIRE_ID,
                            Ammount = 20
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TRANSISTOR_ID,
                            Ammount = 10
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CAPACITOR_ID,
                            Ammount = 5
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
                    RecipeName = "ShieldTransistor_VanilaConstruction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 2f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALT_INGOT_ID,
                            Ammount = 1.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILVER_INGOT_ID,
                            Ammount = 1.25f
                        }
                    }
                }
            }
        };

        public static readonly ArmorModuleDefinition ENHANCEDSHIELDTRANSISTOR_DEFINITION = new ArmorModuleDefinition()
        {
            Id = ENHANCEDSHIELDTRANSISTOR_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.ENHANCEDSHIELDTRANSISTOR_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.SHIELDTRANSISTOR_DESCRIPTION),
            UseCategory = ArmorSystemConstants.ArmorCategory.Work | ArmorSystemConstants.ArmorCategory.Combat,
            Attributes = new Dictionary<ArmorSystemConstants.ModuleAttribute, float>()
            {
                { ArmorSystemConstants.ModuleAttribute.RechargeSpeedBonus, -0.1f },
                { ArmorSystemConstants.ModuleAttribute.EnergyConsumptionBonus, -0.2f }
            },
            CanPlayerOrder = true,
            MinimalPricePerUnit = 17500,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(10, 20),
            AcquisitionAmount = new Vector2I(5, 10),
            Mass = 5f,
            Volume = 2.5f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "EnhancedShieldTransistor_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALTSTEEL_INGOT_ID,
                            Ammount = 3.0f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.LITHIUM_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.GOLD_INGOT_ID,
                            Ammount = 0.65f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.PLATINUM_INGOT_ID,
                            Ammount = 0.1f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SUPERCONDUCTOR_ID,
                            Ammount = 5
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILVERCONNECTOR_ID,
                            Ammount = 20
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TRANSISTOR_ID,
                            Ammount = 10
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CAPACITOR_ID,
                            Ammount = 5
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
                    RecipeName = "EnhancedShieldTransistor_VanilaConstruction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 2f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALT_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILVER_INGOT_ID,
                            Ammount = 1.0f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.GOLD_INGOT_ID,
                            Ammount = 0.75f
                        }
                    }
                }
            }
        };

        public static readonly ArmorModuleDefinition PROFICIENTSHIELDTRANSISTOR_DEFINITION = new ArmorModuleDefinition()
        {
            Id = PROFICIENTSHIELDTRANSISTOR_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.PROFICIENTSHIELDTRANSISTOR_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.SHIELDTRANSISTOR_DESCRIPTION),
            UseCategory = ArmorSystemConstants.ArmorCategory.Work | ArmorSystemConstants.ArmorCategory.Combat,
            Attributes = new Dictionary<ArmorSystemConstants.ModuleAttribute, float>()
            {
                { ArmorSystemConstants.ModuleAttribute.RechargeSpeedBonus, -0.15f },
                { ArmorSystemConstants.ModuleAttribute.EnergyConsumptionBonus, -0.3f }
            },
            CanPlayerOrder = true,
            MinimalPricePerUnit = 175000,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(10, 20),
            AcquisitionAmount = new Vector2I(5, 10),
            Mass = 5f,
            Volume = 2.5f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "ProficientShieldTransistor_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.BERYLLIUMSTEEL_INGOT_ID,
                            Ammount = 3.0f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.LITHIUM_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.GOLD_INGOT_ID,
                            Ammount = 0.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ALUMINUMMG_INGOT_ID,
                            Ammount = 0.15f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.PLATINUM_INGOT_ID,
                            Ammount = 0.1f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SUPERCONDUCTOR_ID,
                            Ammount = 5
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILVERCONNECTOR_ID,
                            Ammount = 20
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TRANSISTOR_ID,
                            Ammount = 10
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CAPACITOR_ID,
                            Ammount = 5
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.PROFICIENTCHIP_ID,
                            Ammount = 1
                        }
                    }
                },
                new SimpleRecipeDefinition()
                {
                    RecipeName = "ProficientShieldTransistor_VanilaConstruction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 1.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALT_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILVER_INGOT_ID,
                            Ammount = 1.0f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.GOLD_INGOT_ID,
                            Ammount = 0.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.PLATINUM_INGOT_ID,
                            Ammount = 0.25f
                        }
                    }
                }
            }
        };

        public static readonly ArmorModuleDefinition ELITESHIELDTRANSISTOR_DEFINITION = new ArmorModuleDefinition()
        {
            Id = ELITESHIELDTRANSISTOR_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.ELITESHIELDTRANSISTOR_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.SHIELDTRANSISTOR_DESCRIPTION),
            UseCategory = ArmorSystemConstants.ArmorCategory.Work | ArmorSystemConstants.ArmorCategory.Combat,
            Attributes = new Dictionary<ArmorSystemConstants.ModuleAttribute, float>()
            {
                { ArmorSystemConstants.ModuleAttribute.RechargeSpeedBonus, -0.2f },
                { ArmorSystemConstants.ModuleAttribute.EnergyConsumptionBonus, -0.4f }
            },
            CanPlayerOrder = true,
            MinimalPricePerUnit = 1750000,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(10, 20),
            AcquisitionAmount = new Vector2I(5, 10),
            Mass = 5f,
            Volume = 2.5f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "EliteShieldTransistor_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TUNGSTENSTEEL_INGOT_ID,
                            Ammount = 3.0f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.LITHIUM_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.GOLD_INGOT_ID,
                            Ammount = 0.45f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ALUMINUMMG_INGOT_ID,
                            Ammount = 0.175f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.PLATINUMIR_INGOT_ID,
                            Ammount = 0.125f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.BERYLLIUMCOPPERWIRE_ID,
                            Ammount = 5
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SUPERCONDUCTOR_ID,
                            Ammount = 20
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TRANSISTOR_ID,
                            Ammount = 10
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CAPACITOR_ID,
                            Ammount = 5
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
                    RecipeName = "EliteShieldTransistor_VanilaConstruction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 1.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALT_INGOT_ID,
                            Ammount = 1.15f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILVER_INGOT_ID,
                            Ammount = 1.0f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.GOLD_INGOT_ID,
                            Ammount = 0.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.PLATINUM_INGOT_ID,
                            Ammount = 0.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.URANIUM_INGOT_ID,
                            Ammount = 0.1f
                        }
                    }
                }
            }
        };

        /* Shield Capacitors */

        public static readonly ArmorModuleDefinition SHIELDCAPACITOR_DEFINITION = new ArmorModuleDefinition()
        {
            Id = SHIELDCAPACITOR_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.SHIELDCAPACITOR_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.SHIELDCAPACITOR_DESCRIPTION),
            UseCategory = ArmorSystemConstants.ArmorCategory.Work | ArmorSystemConstants.ArmorCategory.Combat,
            Attributes = new Dictionary<ArmorSystemConstants.ModuleAttribute, float>()
            {
                { ArmorSystemConstants.ModuleAttribute.CapacityBonus, 0.1f },
                { ArmorSystemConstants.ModuleAttribute.RechargeSpeedBonus, 0.1f },
                { ArmorSystemConstants.ModuleAttribute.EnergyConsumptionBonus, 0.25f }
            },
            CanPlayerOrder = true,
            MinimalPricePerUnit = 1750,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(10, 20),
            AcquisitionAmount = new Vector2I(5, 10),
            Mass = 5f,
            Volume = 2.5f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "ShieldCapacitor_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.STEEL_INGOT_ID,
                            Ammount = 3.0f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.LITHIUM_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.GOLD_INGOT_ID,
                            Ammount = 0.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILVERCONNECTOR_ID,
                            Ammount = 5
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COPPERWIRE_ID,
                            Ammount = 20
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TRANSISTOR_ID,
                            Ammount = 10
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CAPACITOR_ID,
                            Ammount = 5
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
                    RecipeName = "ShieldCapacitor_VanilaConstruction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 2f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALT_INGOT_ID,
                            Ammount = 1.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILVER_INGOT_ID,
                            Ammount = 1.25f
                        }
                    }
                }
            }
        };

        public static readonly ArmorModuleDefinition ENHANCEDSHIELDCAPACITOR_DEFINITION = new ArmorModuleDefinition()
        {
            Id = ENHANCEDSHIELDCAPACITOR_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.ENHANCEDSHIELDCAPACITOR_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.SHIELDCAPACITOR_DESCRIPTION),
            UseCategory = ArmorSystemConstants.ArmorCategory.Work | ArmorSystemConstants.ArmorCategory.Combat,
            Attributes = new Dictionary<ArmorSystemConstants.ModuleAttribute, float>()
            {
                { ArmorSystemConstants.ModuleAttribute.CapacityBonus, 0.15f },
                { ArmorSystemConstants.ModuleAttribute.RechargeSpeedBonus, 0.15f },
                { ArmorSystemConstants.ModuleAttribute.EnergyConsumptionBonus, 0.35f }
            },
            CanPlayerOrder = true,
            MinimalPricePerUnit = 17500,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(10, 20),
            AcquisitionAmount = new Vector2I(5, 10),
            Mass = 5f,
            Volume = 2.5f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "EnhancedShieldCapacitor_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALTSTEEL_INGOT_ID,
                            Ammount = 3.0f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.LITHIUM_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.GOLD_INGOT_ID,
                            Ammount = 0.65f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.PLATINUM_INGOT_ID,
                            Ammount = 0.1f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SUPERCONDUCTOR_ID,
                            Ammount = 5
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILVERCONNECTOR_ID,
                            Ammount = 20
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TRANSISTOR_ID,
                            Ammount = 10
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CAPACITOR_ID,
                            Ammount = 5
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
                    RecipeName = "EnhancedShieldCapacitor_VanilaConstruction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 2f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALT_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILVER_INGOT_ID,
                            Ammount = 1.0f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.GOLD_INGOT_ID,
                            Ammount = 0.75f
                        }
                    }
                }
            }
        };

        public static readonly ArmorModuleDefinition PROFICIENTSHIELDCAPACITOR_DEFINITION = new ArmorModuleDefinition()
        {
            Id = PROFICIENTSHIELDCAPACITOR_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.PROFICIENTSHIELDCAPACITOR_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.SHIELDCAPACITOR_DESCRIPTION),
            UseCategory = ArmorSystemConstants.ArmorCategory.Work | ArmorSystemConstants.ArmorCategory.Combat,
            Attributes = new Dictionary<ArmorSystemConstants.ModuleAttribute, float>()
            {
                { ArmorSystemConstants.ModuleAttribute.CapacityBonus, 0.2f },
                { ArmorSystemConstants.ModuleAttribute.RechargeSpeedBonus, 0.2f },
                { ArmorSystemConstants.ModuleAttribute.EnergyConsumptionBonus, 0.45f }
            },
            CanPlayerOrder = true,
            MinimalPricePerUnit = 175000,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(10, 20),
            AcquisitionAmount = new Vector2I(5, 10),
            Mass = 5f,
            Volume = 2.5f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "ProficientShieldCapacitor_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.BERYLLIUMSTEEL_INGOT_ID,
                            Ammount = 3.0f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.LITHIUM_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.GOLD_INGOT_ID,
                            Ammount = 0.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ALUMINUMMG_INGOT_ID,
                            Ammount = 0.15f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.PLATINUM_INGOT_ID,
                            Ammount = 0.1f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SUPERCONDUCTOR_ID,
                            Ammount = 5
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILVERCONNECTOR_ID,
                            Ammount = 20
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TRANSISTOR_ID,
                            Ammount = 10
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CAPACITOR_ID,
                            Ammount = 5
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.PROFICIENTCHIP_ID,
                            Ammount = 1
                        }
                    }
                },
                new SimpleRecipeDefinition()
                {
                    RecipeName = "ProficientShieldCapacitor_VanilaConstruction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 1.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALT_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILVER_INGOT_ID,
                            Ammount = 1.0f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.GOLD_INGOT_ID,
                            Ammount = 0.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.PLATINUM_INGOT_ID,
                            Ammount = 0.25f
                        }
                    }
                }
            }
        };

        public static readonly ArmorModuleDefinition ELITESHIELDCAPACITOR_DEFINITION = new ArmorModuleDefinition()
        {
            Id = ELITESHIELDCAPACITOR_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.ELITESHIELDCAPACITOR_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.SHIELDCAPACITOR_DESCRIPTION),
            UseCategory = ArmorSystemConstants.ArmorCategory.Work | ArmorSystemConstants.ArmorCategory.Combat,
            Attributes = new Dictionary<ArmorSystemConstants.ModuleAttribute, float>()
            {
                { ArmorSystemConstants.ModuleAttribute.CapacityBonus, 0.25f },
                { ArmorSystemConstants.ModuleAttribute.RechargeSpeedBonus, 0.25f },
                { ArmorSystemConstants.ModuleAttribute.EnergyConsumptionBonus, 0.55f }
            },
            CanPlayerOrder = true,
            MinimalPricePerUnit = 1750000,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(10, 20),
            AcquisitionAmount = new Vector2I(5, 10),
            Mass = 5f,
            Volume = 2.5f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "EliteShieldCapacitor_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TUNGSTENSTEEL_INGOT_ID,
                            Ammount = 3.0f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.LITHIUM_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.GOLD_INGOT_ID,
                            Ammount = 0.45f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ALUMINUMMG_INGOT_ID,
                            Ammount = 0.175f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.PLATINUMIR_INGOT_ID,
                            Ammount = 0.125f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.BERYLLIUMCOPPERWIRE_ID,
                            Ammount = 5
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SUPERCONDUCTOR_ID,
                            Ammount = 20
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TRANSISTOR_ID,
                            Ammount = 10
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CAPACITOR_ID,
                            Ammount = 5
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
                    RecipeName = "EliteShieldCapacitor_VanilaConstruction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 1.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALT_INGOT_ID,
                            Ammount = 1.15f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILVER_INGOT_ID,
                            Ammount = 1.0f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.GOLD_INGOT_ID,
                            Ammount = 0.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.PLATINUM_INGOT_ID,
                            Ammount = 0.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.URANIUM_INGOT_ID,
                            Ammount = 0.1f
                        }
                    }
                }
            }
        };

        /* Shield Spike */

        public static readonly ArmorModuleDefinition SHIELDSPIKE_DEFINITION = new ArmorModuleDefinition()
        {
            Id = SHIELDSPIKE_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.SHIELDSPIKE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.SHIELDSPIKE_DESCRIPTION),
            UseCategory = ArmorSystemConstants.ArmorCategory.Combat,
            Attributes = new Dictionary<ArmorSystemConstants.ModuleAttribute, float>()
            {
                { ArmorSystemConstants.ModuleAttribute.SpikeDamage, 0.075f },
                { ArmorSystemConstants.ModuleAttribute.EnergyConsumptionBonus, 0.0375f }
            },
            CanPlayerOrder = true,
            MinimalPricePerUnit = 1750,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(10, 20),
            AcquisitionAmount = new Vector2I(5, 10),
            Mass = 5f,
            Volume = 2.5f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "ShieldSpike_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.STEEL_INGOT_ID,
                            Ammount = 3.0f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.LITHIUM_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.GOLD_INGOT_ID,
                            Ammount = 0.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILVERCONNECTOR_ID,
                            Ammount = 5
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COPPERWIRE_ID,
                            Ammount = 20
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TRANSISTOR_ID,
                            Ammount = 10
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CAPACITOR_ID,
                            Ammount = 5
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
                    RecipeName = "ShieldSpike_VanilaConstruction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 2f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALT_INGOT_ID,
                            Ammount = 1.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILVER_INGOT_ID,
                            Ammount = 1.25f
                        }
                    }
                }
            }
        };

        public static readonly ArmorModuleDefinition ENHANCEDSHIELDSPIKE_DEFINITION = new ArmorModuleDefinition()
        {
            Id = ENHANCEDSHIELDSPIKE_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.ENHANCEDSHIELDSPIKE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.SHIELDSPIKE_DESCRIPTION),
            UseCategory = ArmorSystemConstants.ArmorCategory.Combat,
            Attributes = new Dictionary<ArmorSystemConstants.ModuleAttribute, float>()
            {
                { ArmorSystemConstants.ModuleAttribute.SpikeDamage, 0.15f },
                { ArmorSystemConstants.ModuleAttribute.EnergyConsumptionBonus, 0.075f }
            },
            CanPlayerOrder = true,
            MinimalPricePerUnit = 17500,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(10, 20),
            AcquisitionAmount = new Vector2I(5, 10),
            Mass = 5f,
            Volume = 2.5f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "EnhancedShieldSpike_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALTSTEEL_INGOT_ID,
                            Ammount = 3.0f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.LITHIUM_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.GOLD_INGOT_ID,
                            Ammount = 0.65f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.PLATINUM_INGOT_ID,
                            Ammount = 0.1f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SUPERCONDUCTOR_ID,
                            Ammount = 5
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILVERCONNECTOR_ID,
                            Ammount = 20
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TRANSISTOR_ID,
                            Ammount = 10
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CAPACITOR_ID,
                            Ammount = 5
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
                    RecipeName = "EnhancedShieldSpike_VanilaConstruction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 2f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALT_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILVER_INGOT_ID,
                            Ammount = 1.0f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.GOLD_INGOT_ID,
                            Ammount = 0.75f
                        }
                    }
                }
            }
        };

        public static readonly ArmorModuleDefinition PROFICIENTSHIELDSPIKE_DEFINITION = new ArmorModuleDefinition()
        {
            Id = PROFICIENTSHIELDSPIKE_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.PROFICIENTSHIELDSPIKE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.SHIELDSPIKE_DESCRIPTION),
            UseCategory = ArmorSystemConstants.ArmorCategory.Combat,
            Attributes = new Dictionary<ArmorSystemConstants.ModuleAttribute, float>()
            {
                { ArmorSystemConstants.ModuleAttribute.SpikeDamage, 0.225f },
                { ArmorSystemConstants.ModuleAttribute.EnergyConsumptionBonus, 0.1125f }
            },
            CanPlayerOrder = true,
            MinimalPricePerUnit = 175000,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(10, 20),
            AcquisitionAmount = new Vector2I(5, 10),
            Mass = 5f,
            Volume = 2.5f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "ProficientShieldSpike_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.BERYLLIUMSTEEL_INGOT_ID,
                            Ammount = 3.0f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.LITHIUM_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.GOLD_INGOT_ID,
                            Ammount = 0.5f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ALUMINUMMG_INGOT_ID,
                            Ammount = 0.15f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.PLATINUM_INGOT_ID,
                            Ammount = 0.1f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SUPERCONDUCTOR_ID,
                            Ammount = 5
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILVERCONNECTOR_ID,
                            Ammount = 20
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TRANSISTOR_ID,
                            Ammount = 10
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CAPACITOR_ID,
                            Ammount = 5
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.PROFICIENTCHIP_ID,
                            Ammount = 1
                        }
                    }
                },
                new SimpleRecipeDefinition()
                {
                    RecipeName = "ProficientShieldSpike_VanilaConstruction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 1.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALT_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILVER_INGOT_ID,
                            Ammount = 1.0f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.GOLD_INGOT_ID,
                            Ammount = 0.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.PLATINUM_INGOT_ID,
                            Ammount = 0.25f
                        }
                    }
                }
            }
        };

        public static readonly ArmorModuleDefinition ELITESHIELDSPIKE_DEFINITION = new ArmorModuleDefinition()
        {
            Id = ELITESHIELDSPIKE_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.ELITESHIELDSPIKE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.SHIELDSPIKE_DESCRIPTION),
            UseCategory = ArmorSystemConstants.ArmorCategory.Combat,
            Attributes = new Dictionary<ArmorSystemConstants.ModuleAttribute, float>()
            {
                { ArmorSystemConstants.ModuleAttribute.SpikeDamage, 0.3f },
                { ArmorSystemConstants.ModuleAttribute.EnergyConsumptionBonus, 0.15f }
            },
            CanPlayerOrder = true,
            MinimalPricePerUnit = 1750000,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(10, 20),
            AcquisitionAmount = new Vector2I(5, 10),
            Mass = 5f,
            Volume = 2.5f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "EliteShieldSpike_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TUNGSTENSTEEL_INGOT_ID,
                            Ammount = 3.0f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.LITHIUM_INGOT_ID,
                            Ammount = 1.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.GOLD_INGOT_ID,
                            Ammount = 0.45f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ALUMINUMMG_INGOT_ID,
                            Ammount = 0.175f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.PLATINUMIR_INGOT_ID,
                            Ammount = 0.125f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.BERYLLIUMCOPPERWIRE_ID,
                            Ammount = 5
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SUPERCONDUCTOR_ID,
                            Ammount = 20
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.TRANSISTOR_ID,
                            Ammount = 10
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CAPACITOR_ID,
                            Ammount = 5
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
                    RecipeName = "EliteShieldSpike_VanilaConstruction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 1.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALT_INGOT_ID,
                            Ammount = 1.15f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILVER_INGOT_ID,
                            Ammount = 1.0f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.GOLD_INGOT_ID,
                            Ammount = 0.75f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.PLATINUM_INGOT_ID,
                            Ammount = 0.25f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.URANIUM_INGOT_ID,
                            Ammount = 0.1f
                        }
                    }
                }
            }
        };

        /* Definitions Dictionary */

        public static readonly Dictionary<UniqueEntityId, ArmorModuleDefinition> ARMOR_MODULES_DEFINITIONS = new Dictionary<UniqueEntityId, ArmorModuleDefinition>()
        {
            /* Thermal Regulator */
            { COLDTHERMALREGULATOR_ID, COLDTHERMALREGULATOR_DEFINITION },
            { ENHANCEDCOLDTHERMALREGULATOR_ID, ENHANCEDCOLDTHERMALREGULATOR_DEFINITION },
            { PROFICIENTCOLDTHERMALREGULATOR_ID, PROFICIENTCOLDTHERMALREGULATOR_DEFINITION },
            { ELITECOLDTHERMALREGULATOR_ID, ELITECOLDTHERMALREGULATOR_DEFINITION },
            { HOTTHERMALREGULATOR_ID, HOTTHERMALREGULATOR_DEFINITION },
            { ENHANCEDHOTTHERMALREGULATOR_ID, ENHANCEDHOTTHERMALREGULATOR_DEFINITION },
            { PROFICIENTHOTTHERMALREGULATOR_ID, PROFICIENTHOTTHERMALREGULATOR_DEFINITION },
            { ELITEHOTTHERMALREGULATOR_ID, ELITEHOTTHERMALREGULATOR_DEFINITION },
            /* Shield Generators */
            { SHIELDGENERATOR_ID, SHIELDGENERATOR_DEFINITION },
            { ENHANCEDSHIELDGENERATOR_ID, ENHANCEDSHIELDGENERATOR_DEFINITION },
            { PROFICIENTSHIELDGENERATOR_ID, PROFICIENTSHIELDGENERATOR_DEFINITION },
            { ELITESHIELDGENERATOR_ID, ELITESHIELDGENERATOR_DEFINITION },
            /* Shield Transistors */
            { SHIELDTRANSISTOR_ID, SHIELDTRANSISTOR_DEFINITION },
            { ENHANCEDSHIELDTRANSISTOR_ID, ENHANCEDSHIELDTRANSISTOR_DEFINITION },
            { PROFICIENTSHIELDTRANSISTOR_ID, PROFICIENTSHIELDTRANSISTOR_DEFINITION },
            { ELITESHIELDTRANSISTOR_ID, ELITESHIELDTRANSISTOR_DEFINITION },
            /* Shield Capacitors */
            { SHIELDCAPACITOR_ID, SHIELDCAPACITOR_DEFINITION },
            { ENHANCEDSHIELDCAPACITOR_ID, ENHANCEDSHIELDCAPACITOR_DEFINITION },
            { PROFICIENTSHIELDCAPACITOR_ID, PROFICIENTSHIELDCAPACITOR_DEFINITION },
            { ELITESHIELDCAPACITOR_ID, ELITESHIELDCAPACITOR_DEFINITION },
            /* Shield Spike */
            { SHIELDSPIKE_ID, SHIELDSPIKE_DEFINITION },
            { ENHANCEDSHIELDSPIKE_ID, ENHANCEDSHIELDSPIKE_DEFINITION },
            { PROFICIENTSHIELDSPIKE_ID, PROFICIENTSHIELDSPIKE_DEFINITION },
            { ELITESHIELDSPIKE_ID, ELITESHIELDSPIKE_DEFINITION }
        };

        public static readonly UniqueEntityId[] COLDTHERMALREGULATORS_MODULES = new UniqueEntityId[] 
        {
            COLDTHERMALREGULATOR_ID, ENHANCEDCOLDTHERMALREGULATOR_ID, PROFICIENTCOLDTHERMALREGULATOR_ID, ELITECOLDTHERMALREGULATOR_ID
        };

        public static readonly UniqueEntityId[] HOTTHERMALREGULATORS_MODULES = new UniqueEntityId[]
        {
            HOTTHERMALREGULATOR_ID, ENHANCEDHOTTHERMALREGULATOR_ID, PROFICIENTHOTTHERMALREGULATOR_ID, ELITEHOTTHERMALREGULATOR_ID
        };

        public static readonly UniqueEntityId[] SHIELDGENERATORS_MODULES = new UniqueEntityId[]
        {
            SHIELDGENERATOR_ID, ENHANCEDSHIELDGENERATOR_ID, PROFICIENTSHIELDGENERATOR_ID, ELITESHIELDGENERATOR_ID
        };

        public static readonly UniqueEntityId[] SHIELDCAPACITORS_MODULES = new UniqueEntityId[]
        {
            SHIELDCAPACITOR_ID, ENHANCEDSHIELDCAPACITOR_ID, PROFICIENTSHIELDCAPACITOR_ID, ELITESHIELDCAPACITOR_ID
        };

        public static readonly UniqueEntityId[] SHIELDTRANSISTORS_MODULES = new UniqueEntityId[]
        {
            SHIELDTRANSISTOR_ID, ENHANCEDSHIELDTRANSISTOR_ID, PROFICIENTSHIELDTRANSISTOR_ID, ELITESHIELDTRANSISTOR_ID
        };

        public static readonly UniqueEntityId[] SHIELDSPIKES_MODULES = new UniqueEntityId[]
        {
            SHIELDSPIKE_ID
        };

        public static readonly UniqueEntityId[] SHIELDEXPAND_MODULES = new UniqueEntityId[]
        {
            SHIELDCAPACITOR_ID, ENHANCEDSHIELDCAPACITOR_ID, PROFICIENTSHIELDCAPACITOR_ID, ELITESHIELDCAPACITOR_ID,
            SHIELDTRANSISTOR_ID, ENHANCEDSHIELDTRANSISTOR_ID, PROFICIENTSHIELDTRANSISTOR_ID, ELITESHIELDTRANSISTOR_ID,
            SHIELDSPIKE_ID
        };

        public static void TryOverrideDefinitions()
        {
            PhysicalItemDefinitionOverride.TryOverrideDefinitions<EquipmentDefinition, MyPhysicalItemDefinition>(EQUIPMENTS_DEFINITIONS);
            PhysicalItemDefinitionOverride.TryOverrideDefinitions<ArmorDefinition, MyPhysicalItemDefinition>(ARMORS_DEFINITIONS);
            PhysicalItemDefinitionOverride.TryOverrideDefinitions<ArmorModuleDefinition, MyPhysicalItemDefinition>(ARMOR_MODULES_DEFINITIONS);
        }

        public static void RegisterShopItens()
        {
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = BODYTRACKER_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = ENHANCEDBODYTRACKER_ID.DefinitionId,
                Rarity = ItemRarity.Normal,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = PROFICIENTBODYTRACKER_ID.DefinitionId,
                Rarity = ItemRarity.Rare,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = ELITEBODYTRACKER_ID.DefinitionId,
                Rarity = ItemRarity.Epic,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = HOTTHERMALBOTTLE_ID.DefinitionId,
                Rarity = ItemRarity.Normal,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Trader }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = COLDTHERMALBOTTLE_ID.DefinitionId,
                Rarity = ItemRarity.Normal,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Trader }
            });
            /* Armors */
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = SCAVENGERARMOR_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = SCAVENGERARMORLIGHT_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = SCAVENGERARMORHEAVY_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = SCAVENGERARMOREXPANDED_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            /* Armor Modules */
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = COLDTHERMALREGULATOR_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = ENHANCEDCOLDTHERMALREGULATOR_ID.DefinitionId,
                Rarity = ItemRarity.Normal,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = PROFICIENTCOLDTHERMALREGULATOR_ID.DefinitionId,
                Rarity = ItemRarity.Rare,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = ELITECOLDTHERMALREGULATOR_ID.DefinitionId,
                Rarity = ItemRarity.Epic,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = HOTTHERMALREGULATOR_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = ENHANCEDHOTTHERMALREGULATOR_ID.DefinitionId,
                Rarity = ItemRarity.Normal,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = PROFICIENTHOTTHERMALREGULATOR_ID.DefinitionId,
                Rarity = ItemRarity.Rare,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = ELITEHOTTHERMALREGULATOR_ID.DefinitionId,
                Rarity = ItemRarity.Epic,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = SHIELDGENERATOR_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = ENHANCEDSHIELDGENERATOR_ID.DefinitionId,
                Rarity = ItemRarity.Normal,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = PROFICIENTSHIELDGENERATOR_ID.DefinitionId,
                Rarity = ItemRarity.Rare,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = ELITESHIELDGENERATOR_ID.DefinitionId,
                Rarity = ItemRarity.Epic,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = SHIELDCAPACITOR_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = ENHANCEDSHIELDCAPACITOR_ID.DefinitionId,
                Rarity = ItemRarity.Normal,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = PROFICIENTSHIELDCAPACITOR_ID.DefinitionId,
                Rarity = ItemRarity.Rare,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = ELITESHIELDCAPACITOR_ID.DefinitionId,
                Rarity = ItemRarity.Epic,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = SHIELDTRANSISTOR_ID.DefinitionId,
                Rarity = ItemRarity.Uncommon,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = ENHANCEDSHIELDTRANSISTOR_ID.DefinitionId,
                Rarity = ItemRarity.Normal,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = PROFICIENTSHIELDTRANSISTOR_ID.DefinitionId,
                Rarity = ItemRarity.Rare,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = ELITESHIELDTRANSISTOR_ID.DefinitionId,
                Rarity = ItemRarity.Epic,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                TargetFactions = new FactionType[] { FactionType.Market }
            });
        }

    }

}