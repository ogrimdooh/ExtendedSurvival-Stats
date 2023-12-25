namespace ExtendedSurvival.Stats
{
    public class MyStatPlayerBodyImmune : MyStatSimpleProgressBase
    {

        protected override string GetStatName()
        {
            return "BodyImmune";
        }

        protected override string GetId()
        {
            return "player_bodyimmune";
        }

        protected override bool IsActive()
        {
            return false; // IsWithHelmet() && GetBodyTrackerLevel() >= 4;
        }

        public override string ToString() => string.Format("{0:0}%", (float)(CurrentValue * 100.0));

    }
}