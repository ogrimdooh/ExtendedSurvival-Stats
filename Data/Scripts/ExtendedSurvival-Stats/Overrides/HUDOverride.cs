using Sandbox.Definitions.GUI;
using System.Collections.Generic;
using System.Linq;
using VRage.Game;
using VRage.Game.Definitions;
using VRage.Game.ObjectBuilders.Definitions;
using VRage.Utils;
using VRageMath;

namespace ExtendedSurvival.Stats
{
    public sealed class HUDOverride : BaseModIntegrationOverride
    {

        private const string Default = "Default";
        private const string ExtendedSurvival = "ExtendedSurvival";

        public static void TryOverride()
        {
            new HUDOverride().SetDefinitions();
        }

        protected override ulong[] GetModId()
        {
            return new ulong[] { };
        }

        protected override void OnSetDefinitions()
        {
            var hudDef = DefinitionUtils.TryGetDefinition<MyHudDefinition>(new MyDefinitionId(typeof(MyObjectBuilder_HudDefinition), MyStringHash.GetOrCompute(Default)));
            var hudEsDef = DefinitionUtils.TryGetDefinition<MyHudDefinition>(new MyDefinitionId(typeof(MyObjectBuilder_HudDefinition), MyStringHash.GetOrCompute(ExtendedSurvival)));
            if (hudDef != null && hudEsDef != null)
            {
                MyObjectBuilder_HudDefinition builder = (MyObjectBuilder_HudDefinition)hudDef.GetObjectBuilder();
                builder.StatControls = hudDef.StatControls.Concat(hudEsDef.StatControls).ToArray();
                builder.Toolbar = hudDef.Toolbar;
                builder.GravityIndicator = hudDef.GravityIndicator;
                builder.Crosshair = hudDef.Crosshair;
                builder.TargetingMarkers = hudDef.TargetingMarkers;
                builder.OptimalScreenRatio = hudDef.OptimalScreenRatio;
                builder.CustomUIScale = hudDef.CustomUIScale;
                builder.VisorOverlayTexture = hudDef.VisorOverlayTexture;
                builder.DPad = hudDef.DPad;
                hudDef.Init(builder, hudDef.Context);
                hudDef.Postprocess();
                ExtendedSurvivalStatsLogging.Instance.LogInfo(GetType(), $"Override hud def found and replace. ID=[{Default}]");
            }
            else
                ExtendedSurvivalStatsLogging.Instance.LogInfo(GetType(), $"Override hud def not found.");
        }

    }

}