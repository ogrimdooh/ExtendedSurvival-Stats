using Sandbox.Definitions;
using System.Collections.Generic;
using System.Linq;
using VRage;
using VRageMath;

namespace ExtendedSurvival.Stats
{
    public class FoodRecipeDefinition
    {

        public struct RecipeItem
        {

            public UniqueEntityId Id { get; set; }
            public float Ammount { get; set; }

        }

        public enum RecipePreparationType
        {

            Cutting = 0,
            Cooking = 1,
            Frying = 2,
            Baking = 3,
            Mixing = 4,
            Processing = 5,
            Drying = 6

        }

        public string Name { get; set; }
        public string Description { get; set; }
        public FoodDefinition.FoodDefinitionType DefinitionType { get; set; } = FoodDefinition.FoodDefinitionType.Consumable;
        public string RecipeName { get; set; }
        public RecipePreparationType Preparation { get; set; }
        public RecipeItem[] Ingredients { get; set; } = new RecipeItem[] { };
        public RecipeItem Product { get; set; }
        public RecipeItem[] OtherResults { get; set; } = new RecipeItem[] { };
        public float ProductionTime { get; set; }
        public Vector2I AcquisitionAmount { get; set; } = Vector2I.Zero;
        public Vector2I OrderAmount { get; set; } = Vector2I.Zero;
        public Vector2I OfferAmount { get; set; } = Vector2I.Zero;
        public int MinimalPricePerUnit { get; set; }
        public bool CanPlayerOrder { get; set; } = false;

        public string GetFullDescription()
        {
            return Description;
        }

        public MyBlueprintDefinitionBase.Item[] GetIngredients()
        {
            return Ingredients.Select(x => new MyBlueprintDefinitionBase.Item() 
            { 
                Id = x.Id.DefinitionId,
                Amount = (MyFixedPoint)x.Ammount
            }).ToArray();
        }

        public MyBlueprintDefinitionBase.Item[] GetProduct()
        {
            return OtherResults.Select(x => new MyBlueprintDefinitionBase.Item()
            {
                Id = x.Id.DefinitionId,
                Amount = (MyFixedPoint)x.Ammount
            }).Append(new MyBlueprintDefinitionBase.Item()
            {
                Id = Product.Id.DefinitionId,
                Amount = (MyFixedPoint)Product.Ammount
            }).ToArray();
        }

    }

}