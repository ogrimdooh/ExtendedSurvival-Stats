namespace ExtendedSurvival.Stats
{
    public class MyStatPlayerBodyWeightDesc : MyStatSimpleProgressBase
    {

        protected override string GetStatName()
        {
            return "BodyWeight";
        }

        protected override string GetId()
        {
            return "player_bodyweight_desc";
        }

        protected override bool IsActive()
        {
            return IsWithHelmet() && GetBodyTrackerLevel() >= 3;
        }

        public override string ToString() => StatsConstants.GetValidStatsDescription(StatsConstants.ValidStats.BodyWeight);

    }
}