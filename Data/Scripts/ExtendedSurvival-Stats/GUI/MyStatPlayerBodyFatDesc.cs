namespace ExtendedSurvival.Stats
{
    public class MyStatPlayerBodyFatDesc : MyStatSimpleProgressBase
    {

        protected override string GetStatName()
        {
            return "BodyFat";
        }

        protected override string GetId()
        {
            return "player_bodyfat_desc";
        }

        protected override bool IsActive()
        {
            return IsWithHelmet() && GetBodyTrackerLevel() >= 4;
        }

        public override string ToString() => StatsConstants.GetValidStatsDescription(StatsConstants.ValidStats.BodyFat);

    }
}