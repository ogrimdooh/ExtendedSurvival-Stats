namespace ExtendedSurvival.Stats
{
    public class MyStatPlayerBodyImmuneDesc : MyStatSimpleProgressBase
    {

        protected override string GetStatName()
        {
            return "BodyImmune";
        }

        protected override string GetId()
        {
            return "player_bodyimmune_desc";
        }

        protected override bool IsActive()
        {
            return false; // IsWithHelmet() && GetBodyTrackerLevel() >= 4;
        }

        public override string ToString() => StatsConstants.GetValidStatsDescription(StatsConstants.ValidStats.BodyImmune);

    }
}