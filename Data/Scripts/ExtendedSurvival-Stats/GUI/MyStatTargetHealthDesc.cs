namespace ExtendedSurvival.Stats
{
    public class MyStatTargetHealthDesc : MyTargetStatSimpleProgressBase
    {

        protected override string GetStatName()
        {
            return "Health";
        }

        protected override string GetId()
        {
            return "target_health_desc";
        }

        public override string ToString() => ExtendedSurvivalStatsSession.Static?.TargetName;

    }
}