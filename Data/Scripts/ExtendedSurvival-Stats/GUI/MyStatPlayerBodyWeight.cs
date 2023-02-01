namespace ExtendedSurvival.Stats
{
    public class MyStatPlayerBodyWeight : MyStatSimpleProgressBase
    {

        protected override string GetStatName()
        {
            return "BodyWeight";
        }

        protected override string GetId()
        {
            return "player_bodyweight";
        }

        protected override bool IsActive()
        {
            return IsWithHelmet() && GetBodyTrackerLevel() >= 3;
        }

        public override string ToString() => string.Format("{0:0}Kg", (float)(CurrentValue * Stat?.MaxValue ?? 0));

    }

}