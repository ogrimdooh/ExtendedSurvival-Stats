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
        /*
        protected override bool IsActive()
        {
            return IsWithHelmet() && GetBodyTrackerLevel() >= 1;
        }
        */
        public override string ToString() => string.Format("{0:0}%", (float)(CurrentValue * 100.0));

    }
}