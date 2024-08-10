﻿using System.Collections.Generic;
using System.Linq;

namespace ExtendedSurvival.Stats
{

    public interface ISimpleFactoringDefinition
    {

        IEnumerable<BaseRecipeDefinition> GetRecipesDefinition();

    }

    public abstract class SimpleFactoringDefinition<T> : SimpleDefinition, ISimpleFactoringDefinition where T : BaseRecipeDefinition
    {

        public List<T> RecipesDefinition { get; set; } = new List<T>();

        public T RecipeDefinition
        {
            get
            {
                if (RecipesDefinition != null && RecipesDefinition.Any())
                    return RecipesDefinition.First();
                return null;
            }
        }

        public virtual IEnumerable<BaseRecipeDefinition> GetRecipesDefinition()
        {
            return RecipesDefinition;
        }

    }

}