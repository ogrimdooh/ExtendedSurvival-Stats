namespace ExtendedSurvival.Stats
{
    public class MyStatPlayerStaminaDesc : MyStatSimpleProgressBase
    {

        protected override string GetStatName()
        {
            return "Stamina";
        }

        protected override string GetId()
        {
            return "player_stamina_desc";
        }

        public override string ToString() => StatsConstants.GetValidStatsDescription(StatsConstants.ValidStats.Stamina);
    }
}