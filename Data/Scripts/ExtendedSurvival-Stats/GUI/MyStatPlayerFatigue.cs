namespace ExtendedSurvival.Stats
{
    public class MyStatPlayerFatigue : MyStatSimpleProgressBase
    {

        protected override string GetStatName()
        {
            return "Fatigue";
        }

        protected override string GetId()
        {
            return "player_fatigue";
        }

        protected override bool IsActive()
        {
            return false; // IsWithHelmet() && GetBodyTrackerLevel() >= 3;
        }

        public override string ToString() => string.Format("{0:0}%", (float)(CurrentValue * 100.0));

    }
}