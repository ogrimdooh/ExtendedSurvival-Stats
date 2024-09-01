using static ExtendedSurvival.Stats.BaseIntegrationModRecipesOverride;
using System.Collections.Generic;
using Sandbox.Definitions;

namespace ExtendedSurvival.Stats
{

    public sealed class AlienAnimalsOverride : BaseModIntegrationOverride
    {

        public const string CarcassOreToIngot = "CarcassOreToIngot";
        public const string CarapaceOreToIngot = "CarapaceOreToIngot";
        public const string TentacleOreToIngot = "TentacleOreToIngot";

        public static readonly Dictionary<UniqueEntityId, ExternalModCustomIcon> ICONS = new Dictionary<UniqueEntityId, ExternalModCustomIcon>()
        {
            /* Single Shells */
            { OreConstants.CARAPACE_ID, new ExternalModCustomIcon("Textures\\GUI\\Icons\\carapace.dds", false) },
            { OreConstants.CARCASS_ID, new ExternalModCustomIcon("Textures\\GUI\\Icons\\carcass.dds", false) },
            { OreConstants.TENTACLE1_ID, new ExternalModCustomIcon("Textures\\GUI\\Icons\\tentacle.dds", false) }
        };

        public static void TryOverride()
        {
            new AlienAnimalsOverride().SetDefinitions();
        }

        protected override ulong[] GetModId()
        {
            return new ulong[] { ExtendedSurvivalStatsSession.MES_ALIENANIMALS_MODID, ExtendedSurvivalStatsSession.ALIENANIMALS_MODID };
        }

        protected override void OnSetDefinitions()
        {
            SetBlueprintResult(
                CarcassOreToIngot, true,
                new FormulaItem(ItensConstants.SPOILED_MATERIAL_ID, 0.3f),
                new FormulaItem(IngotsConstants.BONEMEAL_ID, 0.1f),
                new FormulaItem(IngotsConstants.CARBON_POWDER_ID, 0.1f)
            );
            SetBlueprintResult(
                CarapaceOreToIngot, true,
                new FormulaItem(ItensConstants.SPOILED_MATERIAL_ID, 0.2f),
                new FormulaItem(IngotsConstants.BONEMEAL_ID, 0.2f),
                new FormulaItem(IngotsConstants.CARBON_POWDER_ID, 0.1f)
            );
            SetBlueprintResult(
                TentacleOreToIngot, true,
                new FormulaItem(ItensConstants.SPOILED_MATERIAL_ID, 0.4f),
                new FormulaItem(IngotsConstants.BONEMEAL_ID, 0.1f)
            );
            foreach (var id in ICONS.Keys)
            {
                SetPhysicalitemDisplayInfo(id.DefinitionId, ICONS[id]);
            }
        }

    }

}