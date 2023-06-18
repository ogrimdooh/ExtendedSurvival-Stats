namespace ExtendedSurvival.Stats
{
    public class MyStatTargetShieldDesc : MyTargetStatSimpleProgressBase
    {

        protected override string GetStatName()
        {
            return "EnergyShield";
        }

        protected override string GetId()
        {
            return "target_shield_desc";
        }

        public override string ToString() => StatsConstants.GetValidStatsDescription(StatsConstants.ValidStats.EnergyShield);

    }
}