namespace ExtendedSurvival.Stats
{
    public class MyStatPlayerIntestine : MyStatSimpleProgressBase
    {

        protected override string GetStatName()
        {
            return "Intestine";
        }

        protected override string GetId()
        {
            return "player_intestine";
        }

        protected override bool IsActive()
        {
            return ExtendedSurvivalSettings.Instance.UseMetabolism;
        }

        public override string ToString() => string.Format("{0:0}%", (float)(CurrentValue * 100.0));

    }

    public class MyStatPlayerBladder : MyStatSimpleProgressBase
    {

        protected override string GetStatName()
        {
            return "Bladder";
        }

        protected override string GetId()
        {
            return "player_bladder";
        }

        protected override bool IsActive()
        {
            return ExtendedSurvivalSettings.Instance.UseMetabolism;
        }

        public override string ToString() => string.Format("{0:0}%", (float)(CurrentValue * 100.0));

    }

}