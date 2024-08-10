using System.Collections.Generic;
using System.Linq;

namespace ExtendedSurvival.Stats
{
    public abstract class ComplexFactoringDefinition<T, K> : SimpleFactoringDefinition<T> where T : BaseRecipeDefinition where K : BaseRecipeDefinition
    {

        public List<K> OtherRecipesDefinition { get; set; } = new List<K>();

        public override IEnumerable<BaseRecipeDefinition> GetRecipesDefinition()
        {
            return base.GetRecipesDefinition().Concat(OtherRecipesDefinition);
        }

    }

}