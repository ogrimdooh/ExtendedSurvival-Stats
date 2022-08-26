namespace ExtendedSurvival.Stats
{
    public class MyStatPlayerBodyMuscles : MyStatSimpleProgressBase
    {

        protected override string GetStatName()
        {
            return "BodyMuscles";
        }

        protected override string GetId()
        {
            return "player_bodymuscles";
        }

        protected override bool IsActive()
        {
            return ExtendedSurvivalSettings.Instance.UseNutrition && IsWithHelmet() && GetBodyTrackerLevel() >= 3;
        }

    }

}