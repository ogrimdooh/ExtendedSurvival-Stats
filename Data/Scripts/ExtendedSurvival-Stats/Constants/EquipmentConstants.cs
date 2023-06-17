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

        public static readonly Dictionary<UniqueEntityId, ArmorDefinition> ARMORS_DEFINITIONS = new Dictionary<UniqueEntityId, ArmorDefinition>()
        {
            { SCAVENGERARMOR_ID, SCAVENGERARMOR_DEFINITION },
            { SCAVENGERARMORLIGHT_ID, SCAVENGERARMORLIGHT_DEFINITION },
            { SCAVENGERARMORHEAVY_ID, SCAVENGERARMORHEAVY_DEFINITION },
            { SCAVENGERARMOREXPANDED_ID, SCAVENGERARMOREXPANDED_DEFINITION }
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
            Mass = 5f,
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
                            Id = ItensConstants.STEEL_INGOT_ID,
                            Ammount = 3.0f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.COBALT_INGOT_ID,
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
                    RecipeName = "ShieldGenerator_VanilaConstruction",
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
            /* Shield Generator */
            { SHIELDGENERATOR_ID, SHIELDGENERATOR_DEFINITION }
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
            SHIELDGENERATOR_ID
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
        }

    }

}