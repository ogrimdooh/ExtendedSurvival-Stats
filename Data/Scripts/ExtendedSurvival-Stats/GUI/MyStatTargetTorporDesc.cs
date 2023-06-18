namespace ExtendedSurvival.Stats
{
    public class MyStatTargetTorporDesc : MyTargetStatSimpleProgressBase
    {

        protected override string GetStatName()
        {
            return "Torpor";
        }

        protected override string GetId()
        {
            return "target_torpor_desc";
        }

        public override string ToString() => StatsConstants.GetCreatureValidStatsDescription(StatsConstants.CreatureValidStats.Torpor);

    }
}