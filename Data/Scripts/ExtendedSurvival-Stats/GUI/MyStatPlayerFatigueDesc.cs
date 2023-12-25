namespace ExtendedSurvival.Stats
{
    public class MyStatPlayerFatigueDesc : MyStatSimpleProgressBase
    {

        protected override string GetStatName()
        {
            return "Fatigue";
        }

        protected override string GetId()
        {
            return "player_fatigue_desc";
        }

        protected override bool IsActive()
        {
            return false; // IsWithHelmet() && GetBodyTrackerLevel() >= 3;
        }

        public override string ToString() => StatsConstants.GetValidStatsDescription(StatsConstants.ValidStats.Fatigue);

    }
}