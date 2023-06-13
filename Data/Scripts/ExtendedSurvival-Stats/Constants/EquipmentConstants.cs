﻿using Sandbox.Common.ObjectBuilders.Definitions;
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

        public static void TryOverrideDefinitions()
        {
            PhysicalItemDefinitionOverride.TryOverrideDefinitions<EquipmentDefinition, MyPhysicalItemDefinition>(EQUIPMENTS_DEFINITIONS);
            PhysicalItemDefinitionOverride.TryOverrideDefinitions<ArmorDefinition, MyPhysicalItemDefinition>(ARMORS_DEFINITIONS);
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
        }

    }

}