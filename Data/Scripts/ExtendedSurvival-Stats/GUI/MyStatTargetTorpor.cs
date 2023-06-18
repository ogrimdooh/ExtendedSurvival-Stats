namespace ExtendedSurvival.Stats
{
    public class MyStatTargetTorpor : MyTargetStatSimpleProgressBase
    {

        protected override string GetStatName()
        {
            return "Torpor";
        }

        protected override string GetId()
        {
            return "target_torpor";
        }

    }
}