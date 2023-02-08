namespace ExtendedSurvival.Stats
{
    public class MyStatPlayerIntestineDesc : MyStatSimpleProgressBase
    {

        protected override string GetStatName()
        {
            return "Intestine";
        }

        protected override string GetId()
        {
            return "player_intestine_desc";
        }

        public override string ToString() => StatsConstants.GetValidStatsDescription(StatsConstants.ValidStats.Intestine);

    }
}