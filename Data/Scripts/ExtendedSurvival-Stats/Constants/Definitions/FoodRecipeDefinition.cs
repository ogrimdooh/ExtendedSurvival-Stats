using Sandbox.Definitions;
using System.Collections.Generic;
using System.Linq;
using VRage;
using VRageMath;

namespace ExtendedSurvival.Stats
{
    public class FoodRecipeDefinition : FullRecipeDefinition
    {

        public enum RecipePreparationType
        {

            Cutting = 0,
            Cooking = 1,
            Frying = 2,
            Baking = 3,
            Mixing = 4,
            Processing = 5,
            Drying = 6,
            IndustrialProcessing = 7

        }

        public string Description { get; set; }
        public FoodDefinition.FoodDefinitionType DefinitionType { get; set; } = FoodDefinition.FoodDefinitionType.Consumable;
        public RecipePreparationType Preparation { get; set; }
        public Vector2I AcquisitionAmount { get; set; } = Vector2I.Zero;
        public Vector2I OrderAmount { get; set; } = Vector2I.Zero;
        public Vector2I OfferAmount { get; set; } = Vector2I.Zero;
        public int MinimalPricePerUnit { get; set; }
        public bool CanPlayerOrder { get; set; } = false;
        public List<StatsConstants.DiseaseEffects> CureDisease { get; set; }

        public string GetFullDescription()
        {
            return Description;
        }

    }

}