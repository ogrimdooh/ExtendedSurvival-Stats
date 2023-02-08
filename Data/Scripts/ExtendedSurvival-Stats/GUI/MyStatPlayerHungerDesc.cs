namespace ExtendedSurvival.Stats
{
    public class MyStatPlayerHungerDesc : MyStatSimpleProgressBase
    {

        protected override string GetStatName()
        {
            return "Hunger";
        }

        protected override string GetId()
        {
            return "player_hunger_desc";
        }

        public override string ToString() => StatsConstants.GetValidStatsDescription(StatsConstants.ValidStats.Hunger);
    }
}