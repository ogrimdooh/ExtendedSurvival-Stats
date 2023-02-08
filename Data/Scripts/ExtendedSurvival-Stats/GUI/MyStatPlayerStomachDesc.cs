namespace ExtendedSurvival.Stats
{
    public class MyStatPlayerStomachDesc : MyStatSimpleProgressBase
    {

        protected override string GetStatName()
        {
            return "Stomach";
        }

        protected override string GetId()
        {
            return "player_stomach_desc";
        }

        public override string ToString() => StatsConstants.GetValidStatsDescription(StatsConstants.ValidStats.Stomach);

    }
}