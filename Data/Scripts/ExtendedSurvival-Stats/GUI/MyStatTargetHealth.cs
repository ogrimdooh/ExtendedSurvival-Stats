namespace ExtendedSurvival.Stats
{
    public class MyStatTargetHealth : MyTargetStatSimpleProgressBase
    {

        protected override string GetStatName()
        {
            return "Health";
        }

        protected override string GetId()
        {
            return "target_health";
        }

    }
}