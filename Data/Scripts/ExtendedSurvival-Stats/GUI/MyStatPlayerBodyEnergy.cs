namespace ExtendedSurvival.Stats
{
    public class MyStatPlayerBodyEnergy : MyStatSimpleProgressBase
    {

        protected override string GetStatName()
        {
            return "BodyEnergy";
        }

        protected override string GetId()
        {
            return "player_bodyenergy";
        }

        protected override bool IsActive()
        {
            return ExtendedSurvivalSettings.Instance.UseMetabolism && IsWithHelmet() && GetBodyTrackerLevel() >= 2;
        }

    }

}