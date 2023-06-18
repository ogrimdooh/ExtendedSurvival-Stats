using Sandbox.Game.Components;

namespace ExtendedSurvival.Stats
{
    public abstract class MyTargetStatSimpleProgressBase : MyBaseStatSimpleProgressBase
    {

        protected override MyEntityStatComponent GetStatComp()
        {
            return ExtendedSurvivalStatsSession.Static?.TargetStatsComp;
        }

    }

}