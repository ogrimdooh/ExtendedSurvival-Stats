namespace ExtendedSurvival.Stats
{
    public class MyStatPlayerBodyEnergyDesc : MyStatSimpleProgressBase
    {

        protected override string GetStatName()
        {
            return "BodyEnergy";
        }

        protected override string GetId()
        {
            return "player_bodyenergy_desc";
        }
        /*
        protected override bool IsActive()
        {
            return IsWithHelmet() && GetBodyTrackerLevel() >= 1;
        }
        */
        public override string ToString() => StatsConstants.GetValidStatsDescription(StatsConstants.ValidStats.BodyEnergy);

    }
}