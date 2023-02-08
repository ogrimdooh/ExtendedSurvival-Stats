namespace ExtendedSurvival.Stats
{
    public class MyStatPlayerBodyPerformanceDesc : MyStatSimpleProgressBase
    {

        protected override string GetStatName()
        {
            return "BodyPerformance";
        }

        protected override string GetId()
        {
            return "player_bodyperformance_desc";
        }

        protected override bool IsActive()
        {
            return IsWithHelmet() && GetBodyTrackerLevel() >= 3;
        }

        public override string ToString() => StatsConstants.GetValidStatsDescription(StatsConstants.ValidStats.BodyPerformance);

    }
}