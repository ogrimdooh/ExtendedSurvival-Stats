namespace ExtendedSurvival.Stats
{
    public class MyStatPlayerThirstDesc : MyStatSimpleProgressBase
    {

        protected override string GetStatName()
        {
            return "Thirst";
        }

        protected override string GetId()
        {
            return "player_thirst_desc";
        }

        public override string ToString() => StatsConstants.GetValidStatsDescription(StatsConstants.ValidStats.Thirst);
    }
}