namespace ExtendedSurvival.Stats
{
    public class MyStatPlayerBodyMusclesDesc : MyStatSimpleProgressBase
    {

        protected override string GetStatName()
        {
            return "BodyMuscles";
        }

        protected override string GetId()
        {
            return "player_bodymuscles_desc";
        }

        protected override bool IsActive()
        {
            return false; // IsWithHelmet() && GetBodyTrackerLevel() >= 4;
        }

        public override string ToString() => StatsConstants.GetValidStatsDescription(StatsConstants.ValidStats.BodyMuscles);

    }
}