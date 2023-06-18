namespace ExtendedSurvival.Stats
{
    public class MyStatTargetShield : MyTargetStatSimpleProgressBase
    {

        protected override string GetStatName()
        {
            return "EnergyShield";
        }

        protected override string GetId()
        {
            return "target_shield";
        }

    }
}