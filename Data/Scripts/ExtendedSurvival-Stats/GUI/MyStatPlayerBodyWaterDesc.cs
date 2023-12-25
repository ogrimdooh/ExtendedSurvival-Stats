namespace ExtendedSurvival.Stats
{
    public class MyStatPlayerBodyWaterDesc : MyStatSimpleProgressBase
    {

        protected override string GetStatName()
        {
            return "BodyWater";
        }

        protected override string GetId()
        {
            return "player_bodywater_desc";
        }
        /*
        protected override bool IsActive()
        {
            return IsWithHelmet() && GetBodyTrackerLevel() >= 2;
        }
        */
        public override string ToString() => StatsConstants.GetValidStatsDescription(StatsConstants.ValidStats.BodyWater);

    }
}