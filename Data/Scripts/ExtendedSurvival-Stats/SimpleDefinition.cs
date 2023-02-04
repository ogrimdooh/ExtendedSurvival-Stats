using System.Collections.Generic;
using System.Linq;
using VRageMath;

namespace ExtendedSurvival.Stats
{
    public abstract class SimpleDefinition
    {

        public UniqueEntityId Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Volume { get; set; }
        public float Mass { get; set; }
        public Vector2I AcquisitionAmount { get; set; } = Vector2I.Zero;
        public Vector2I OrderAmount { get; set; } = Vector2I.Zero;
        public Vector2I OfferAmount { get; set; } = Vector2I.Zero;
        public int MinimalPricePerUnit { get; set; }
        public bool CanPlayerOrder { get; set; } = false;
        public List<SimpleRecipeDefinition> RecipesDefinition { get; set; } = new List<SimpleRecipeDefinition>();

        public SimpleRecipeDefinition RecipeDefinition
        {
            get
            {
                if (RecipesDefinition != null && RecipesDefinition.Any())
                    return RecipesDefinition.First();
                return null;
            }
        }

        public virtual float GetVolume()
        {
            return Volume / 1000;
        }

        public virtual float GetMass()
        {
            return Mass;
        }

        public virtual string GetFullDescription()
        {
            return Description;
        }

    }

}