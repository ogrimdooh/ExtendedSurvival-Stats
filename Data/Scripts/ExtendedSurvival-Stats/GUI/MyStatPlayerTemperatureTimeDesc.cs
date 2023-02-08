namespace ExtendedSurvival.Stats
{
    public class MyStatPlayerTemperatureTimeDesc : MyStatSimpleProgressBase
    {

        protected override string GetStatName()
        {
            return "TemperatureTime";
        }

        protected override string GetId()
        {
            return "player_temperature_time_desc";
        }

        protected override bool IsActive()
        {
            return IsWithHelmet() && GetBodyTrackerLevel() >= 1;
        }

        public override string ToString() => StatsConstants.GetValidStatsDescription(StatsConstants.ValidStats.TemperatureTime);

    }
}