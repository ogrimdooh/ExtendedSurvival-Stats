namespace ExtendedSurvival.Stats
{
    public class MyStatPlayerBodyPerformance : MyStatSimpleProgressBase
    {

        protected override string GetStatName()
        {
            return "BodyPerformance";
        }

        protected override string GetId()
        {
            return "player_bodyperformance";
        }

        protected override bool IsActive()
        {
            return ExtendedSurvivalSettings.Instance.UseNutrition && IsWithHelmet() && GetBodyTrackerLevel() >= 3;
        }

        public override string ToString() => string.Format("{0:0}%", (float)(CurrentValue * 100.0));

    }

}