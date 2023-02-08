using System.Collections.Generic;
using VRage.Game;
using VRageMath;

namespace ExtendedSurvival.Stats
{
    public static class RecipientConstants
    {

        public const string BOWL_SUBTYPEID = "Bowl";
        public static readonly UniqueEntityId BOWL_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), BOWL_SUBTYPEID);

        public const string ALUMINUMCAN_SUBTYPEID = "AluminumCan";
        public static readonly UniqueEntityId ALUMINUMCAN_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), ALUMINUMCAN_SUBTYPEID);

        public static readonly RecipientDefinition BOWL_DEFINITION = new RecipientDefinition()
        {
            Id = BOWL_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.BOWL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.BOWL_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 5,
            OfferAmount = new Vector2I(1000, 3000),
            OrderAmount = new Vector2I(250, 750),
            AcquisitionAmount = new Vector2I(500, 1500),
            Mass = 0.25f,
            Volume = 0.25f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    Name = LanguageProvider.GetEntry(LanguageEntries.BOWLOFWOOD_CONSTRUCTION_NAME),
                    RecipeName = "BowlOfWood_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 1.28f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.WOODLOG_ID,
                            Ammount = 0.2f
                        }
                    }
                },
                new SimpleRecipeDefinition()
                {
                    Name = LanguageProvider.GetEntry(LanguageEntries.BOWLOFGLASS_CONSTRUCTION_NAME),
                    RecipeName = "BowlOfGlass_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 1.28f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SILICON_INGOT_ID,
                            Ammount = 0.05f
                        },
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.SAND_ID,
                            Ammount = 0.15f
                        }
                    }
                }
            }
        };

        public static readonly RecipientDefinition ALUMINUMCAN_DEFINITION = new RecipientDefinition()
        {
            Id = ALUMINUMCAN_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.ALUMINUMCAN_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.ALUMINUMCAN_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 5,
            OfferAmount = new Vector2I(1000, 3000),
            OrderAmount = new Vector2I(250, 750),
            AcquisitionAmount = new Vector2I(500, 1500),
            Mass = 0.25f,
            Volume = 0.25f,
            RecipesDefinition = new List<SimpleRecipeDefinition>()
            {
                new SimpleRecipeDefinition()
                {
                    RecipeName = "AluminumCan_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 1.28f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.ALUMINUM_INGOT_ID,
                            Ammount = 0.5f
                        }
                    }
                },
                new SimpleRecipeDefinition()
                {
                    RecipeName = "AluminumCan_Vanila_Construction",
                    ProductAmmount = 1,
                    ProductionTime = 2.56f,
                    Ingredients = new SimpleRecipeDefinition.RecipeItem[]
                    {
                        new SimpleRecipeDefinition.RecipeItem()
                        {
                            Id = ItensConstants.IRON_INGOT_ID,
                            Ammount = 0.5f
                        }
                    }
                }
            }
        };

        public static readonly Dictionary<UniqueEntityId, RecipientDefinition> RECIPIENTS_DEFINITIONS = new Dictionary<UniqueEntityId, RecipientDefinition>()
        {
            { BOWL_ID, BOWL_DEFINITION },
            { ALUMINUMCAN_ID, ALUMINUMCAN_DEFINITION }
        };

        public static void TryOverrideDefinitions()
        {
            PhysicalItemDefinitionOverride.TryOverrideDefinitions(RECIPIENTS_DEFINITIONS);
        }

    }

}