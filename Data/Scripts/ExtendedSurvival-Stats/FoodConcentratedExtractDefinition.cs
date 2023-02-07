namespace ExtendedSurvival.Stats
{
    public class FoodConcentratedExtractDefinition : BaseRecipeDefinition
    {

        public struct RecipeItem
        {

            public UniqueEntityId Id { get; set; }
            public float Ammount { get; set; }

        }

        public string Description { get; set; }
        public RecipeItem Ingredient { get; set; }

    }

}