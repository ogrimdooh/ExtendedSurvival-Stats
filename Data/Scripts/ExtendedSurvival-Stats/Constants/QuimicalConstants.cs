using Sandbox.Definitions;
using System;
using System.Collections.Generic;
using VRage.Game;
using VRageMath;

namespace ExtendedSurvival.Stats
{

    public static class QuimicalConstants
    {

        public const string PROPOFOL_SUBTYPEID = "Propofol";
        public static readonly UniqueEntityId PROPOFOL_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), PROPOFOL_SUBTYPEID);

        public const string LIDOCAINE_SUBTYPEID = "Lidocaine";
        public static readonly UniqueEntityId LIDOCAINE_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), LIDOCAINE_SUBTYPEID);

        public const string SMALLALOEVERAEXTRACT_SUBTYPEID = "SmallAloeVeraExtract";
        public static readonly UniqueEntityId SMALLALOEVERAEXTRACT_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), SMALLALOEVERAEXTRACT_SUBTYPEID);

        public const string ALOEVERAEXTRACT_SUBTYPEID = "AloeVeraExtract";
        public static readonly UniqueEntityId ALOEVERAEXTRACT_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), ALOEVERAEXTRACT_SUBTYPEID);

        public const string ARNICAEXTRACT_SUBTYPEID = "ArnicaExtract";
        public static readonly UniqueEntityId ARNICAEXTRACT_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), ARNICAEXTRACT_SUBTYPEID);

        public const string MINTEXTRACT_SUBTYPEID = "MintExtract";
        public static readonly UniqueEntityId MINTEXTRACT_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), MINTEXTRACT_SUBTYPEID);

        public const string CHAMOMILEEXTRACT_SUBTYPEID = "ChamomileExtract";
        public static readonly UniqueEntityId CHAMOMILEEXTRACT_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), CHAMOMILEEXTRACT_SUBTYPEID);

        public const string AMATOXINA_SUBTYPEID = "Amatoxina";
        public static readonly UniqueEntityId AMATOXINA_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), AMATOXINA_SUBTYPEID);

        public static readonly QuimicalDefinition PROPOFOL_DEFINITION = new QuimicalDefinition()
        {
            Id = PROPOFOL_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.PROPOFOL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.PROPOFOL_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 22500,
            OfferAmount = new Vector2I(100, 300),
            OrderAmount = new Vector2I(25, 75),
            AcquisitionAmount = new Vector2I(50, 150),
            Mass = 3f,
            Volume = 1f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "Propofol_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 20.48f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = LIDOCAINE_ID,
                            Ammount = 1f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = AMATOXINA_ID,
                            Ammount = 1f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.CARBON_INGOT_ID,
                            Ammount = 5f
                        }
                    }
                }
            }
        };

        public static readonly QuimicalDefinition LIDOCAINE_DEFINITION = new QuimicalDefinition()
        {
            Id = LIDOCAINE_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.LIDOCAINE_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.LIDOCAINE_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 4500,
            OfferAmount = new Vector2I(100, 300),
            OrderAmount = new Vector2I(25, 75),
            AcquisitionAmount = new Vector2I(50, 150),
            Mass = 3f,
            Volume = 1f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "Lidocaine_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 10.24f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.WATER_FLASK_MEDIUM_ID,
                            Ammount = 1f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = HerbsConstants.ERYTHROXYLUM_ID,
                            Ammount = 30f
                        }
                    }
                }
            }
        };

        public static readonly QuimicalDefinition SMALLALOEVERAEXTRACT_DEFINITION = new QuimicalDefinition()
        {
            Id = SMALLALOEVERAEXTRACT_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.SMALLALOEVERAEXTRACT_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.SMALLALOEVERAEXTRACT_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 1250,
            OfferAmount = new Vector2I(100, 300),
            OrderAmount = new Vector2I(25, 75),
            AcquisitionAmount = new Vector2I(50, 150),
            Mass = 1.5f,
            Volume = 0.5f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "SmallAloeVeraExtract_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 2.56f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.WATER_FLASK_SMALL_ID,
                            Ammount = 1f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = HerbsConstants.ALOEVERA_ID,
                            Ammount = 7.5f
                        }
                    }
                }
            }
        };

        public static readonly QuimicalDefinition ALOEVERAEXTRACT_DEFINITION = new QuimicalDefinition()
        {
            Id = ALOEVERAEXTRACT_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.ALOEVERAEXTRACT_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ALOEVERAEXTRACT_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 2500,
            OfferAmount = new Vector2I(100, 300),
            OrderAmount = new Vector2I(25, 75),
            AcquisitionAmount = new Vector2I(50, 150),
            Mass = 3f,
            Volume = 1f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "AloeVeraExtract_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.WATER_FLASK_MEDIUM_ID,
                            Ammount = 1f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = HerbsConstants.ALOEVERA_ID,
                            Ammount = 15f
                        }
                    }
                }
            }
        };

        public static readonly QuimicalDefinition ARNICAEXTRACT_DEFINITION = new QuimicalDefinition()
        {
            Id = ARNICAEXTRACT_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.ARNICAEXTRACT_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ARNICAEXTRACT_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 4500,
            OfferAmount = new Vector2I(100, 300),
            OrderAmount = new Vector2I(25, 75),
            AcquisitionAmount = new Vector2I(50, 150),
            Mass = 1.5f,
            Volume = 0.5f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "ArnicaExtract_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 10.24f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.WATER_FLASK_SMALL_ID,
                            Ammount = 1f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = HerbsConstants.ARNICA_ID,
                            Ammount = 15f
                        }
                    }
                }
            }
        };

        public static readonly QuimicalDefinition MINTEXTRACT_DEFINITION = new QuimicalDefinition()
        {
            Id = MINTEXTRACT_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.MINTEXTRACT_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.MINTEXTRACT_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 750,
            OfferAmount = new Vector2I(100, 300),
            OrderAmount = new Vector2I(25, 75),
            AcquisitionAmount = new Vector2I(50, 150),
            Mass = 1.5f,
            Volume = 0.5f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "MintExtract_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.WATER_FLASK_SMALL_ID,
                            Ammount = 1f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = HerbsConstants.MINT_ID,
                            Ammount = 7.5f
                        }
                    }
                }
            }
        };

        public static readonly QuimicalDefinition CHAMOMILEEXTRACT_DEFINITION = new QuimicalDefinition()
        {
            Id = CHAMOMILEEXTRACT_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.CHAMOMILEEXTRACT_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.CHAMOMILEEXTRACT_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 750,
            OfferAmount = new Vector2I(100, 300),
            OrderAmount = new Vector2I(25, 75),
            AcquisitionAmount = new Vector2I(50, 150),
            Mass = 1.5f,
            Volume = 0.5f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "Chamomile_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 5.12f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.WATER_FLASK_SMALL_ID,
                            Ammount = 1f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = HerbsConstants.CHAMOMILE_ID,
                            Ammount = 7.5f
                        }
                    }
                }
            }
        };

        public static readonly QuimicalDefinition AMATOXINA_DEFINITION = new QuimicalDefinition()
        {
            Id = AMATOXINA_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.AMATOXINA_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.AMATOXINA_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 15750,
            OfferAmount = new Vector2I(10, 20),
            OrderAmount = new Vector2I(5, 10),
            AcquisitionAmount = new Vector2I(20, 40),
            Mass = 1.5f,
            Volume = 0.5f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "Amatoxina_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 10.24f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.WATER_FLASK_SMALL_ID,
                            Ammount = 1f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.AMANITAMUSCARIA_ID,
                            Ammount = 15f
                        }
                    }
                }
            }
        };

        public static readonly Dictionary<UniqueEntityId, QuimicalDefinition> QUIMICALS_DEFINITIONS = new Dictionary<UniqueEntityId, QuimicalDefinition>()
        {
            { PROPOFOL_ID, PROPOFOL_DEFINITION },
            { LIDOCAINE_ID, LIDOCAINE_DEFINITION },
            { SMALLALOEVERAEXTRACT_ID, SMALLALOEVERAEXTRACT_DEFINITION },
            { ALOEVERAEXTRACT_ID, ALOEVERAEXTRACT_DEFINITION },
            { ARNICAEXTRACT_ID, ARNICAEXTRACT_DEFINITION },
            { MINTEXTRACT_ID, MINTEXTRACT_DEFINITION },
            { CHAMOMILEEXTRACT_ID, CHAMOMILEEXTRACT_DEFINITION },
            { AMATOXINA_ID, AMATOXINA_DEFINITION }
        };

        public static void TryOverrideDefinitions()
        {
            PhysicalItemDefinitionOverride.TryOverrideDefinitions<QuimicalDefinition, MyPhysicalItemDefinition>(QUIMICALS_DEFINITIONS);
        }

    }

}