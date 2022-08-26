namespace ExtendedSurvival.Stats
{
    public class MyStatPlayerBodyFat : MyStatSimpleProgressBase
    {

        protected override string GetStatName()
        {
            return "BodyFat";
        }

        protected override string GetId()
        {
            return "player_bodyfat";
        }

        protected override bool IsActive()
        {
            return ExtendedSurvivalSettings.Instance.UseNutrition && IsWithHelmet();
        }

    }

}