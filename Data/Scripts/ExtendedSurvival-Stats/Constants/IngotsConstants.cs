using System.Collections.Generic;
using VRage.Game;
using VRageMath;

namespace ExtendedSurvival.Stats
{
    public static class IngotsConstants
    {

        public static readonly UniqueEntityId BONEMEAL_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), OreConstants.BONES_SUBTYPEID);

        public static readonly IngotDefinition BONEMEAL_DEFINITION = new IngotDefinition()
        {
            Id = BONEMEAL_ID,
            Name = "Bone Meal",
            Description = "Bone meal is a mixture of finely and coarsely ground animal bones and slaughter-house waste products.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 2,
            OfferAmount = new Vector2I(10000, 30000),
            OrderAmount = new Vector2I(2500, 7500),
            AcquisitionAmount = new Vector2I(5000, 15000),
            Mass = 1f,
            Volume = 0.05f
        };

        public static readonly Dictionary<UniqueEntityId, IngotDefinition> INGOTS_DEFINITIONS = new Dictionary<UniqueEntityId, IngotDefinition>()
        {
            { BONEMEAL_ID, BONEMEAL_DEFINITION }
        };

        public static void TryOverrideDefinitions()
        {
            PhysicalItemDefinitionOverride.TryOverrideDefinitions(INGOTS_DEFINITIONS);
        }

    }

}