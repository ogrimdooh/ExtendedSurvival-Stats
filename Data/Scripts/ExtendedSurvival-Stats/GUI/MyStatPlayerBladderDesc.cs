namespace ExtendedSurvival.Stats
{
    public class MyStatPlayerBladderDesc : MyStatSimpleProgressBase
    {

        protected override string GetStatName()
        {
            return "Bladder";
        }

        protected override string GetId()
        {
            return "player_bladder_desc";
        }

        public override string ToString() => StatsConstants.GetValidStatsDescription(StatsConstants.ValidStats.Bladder);

    }

}