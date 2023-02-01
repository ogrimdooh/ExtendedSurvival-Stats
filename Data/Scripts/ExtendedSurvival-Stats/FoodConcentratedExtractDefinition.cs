namespace ExtendedSurvival.Stats
{
    public class FoodConcentratedExtractDefinition
    {

        public struct RecipeItem
        {

            public UniqueEntityId Id { get; set; }
            public float Ammount { get; set; }

        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string RecipeName { get; set; }
        public float ProductionTime { get; set; }
        public RecipeItem Ingredient { get; set; }

    }

}