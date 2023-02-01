namespace ExtendedSurvival.Stats
{
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

        public override string ToString() => string.Format("{0:0}%", (float)(CurrentValue * 100.0));

    }

}