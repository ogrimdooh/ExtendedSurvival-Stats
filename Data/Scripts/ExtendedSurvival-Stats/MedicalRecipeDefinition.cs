using Sandbox.Definitions;
using System.Collections.Generic;
using System.Linq;
using VRage;

namespace ExtendedSurvival.Stats
{
    public class MedicalRecipeDefinition
    {

        public struct RecipeItem
        {

            public UniqueEntityId Id { get; set; }
            public float Ammount { get; set; }

        }

        public string RecipeName { get; set; }
        public float ProductAmmount { get; set; }
        public RecipeItem[] Ingredients { get; set; } = new RecipeItem[] { };
        public RecipeItem[] OtherResults { get; set; } = new RecipeItem[] { };
        public float ProductionTime { get; set; }

        public MyBlueprintDefinitionBase.Item[] GetIngredients()
        {
            return Ingredients.Select(x => new MyBlueprintDefinitionBase.Item()
            {
                Id = x.Id.DefinitionId,
                Amount = (MyFixedPoint)x.Ammount
            }).ToArray();
        }

        public MyBlueprintDefinitionBase.Item[] GetProduct(UniqueEntityId ProductId)
        {
            return OtherResults.Select(x => new MyBlueprintDefinitionBase.Item()
            {
                Id = x.Id.DefinitionId,
                Amount = (MyFixedPoint)x.Ammount
            }).Append(new MyBlueprintDefinitionBase.Item()
            {
                Id = ProductId.DefinitionId,
                Amount = (MyFixedPoint)ProductAmmount
            }).ToArray();
        }

    }

}