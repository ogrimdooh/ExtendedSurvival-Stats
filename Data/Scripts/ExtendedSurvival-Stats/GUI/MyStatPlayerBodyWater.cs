namespace ExtendedSurvival.Stats
{
    public class MyStatPlayerBodyWater : MyStatSimpleProgressBase
    {

        protected override string GetStatName()
        {
            return "BodyWater";
        }

        protected override string GetId()
        {
            return "player_bodywater";
        }

        protected override bool IsActive()
        {
            return ExtendedSurvivalSettings.Instance.UseMetabolism && IsWithHelmet();
        }

    }

}