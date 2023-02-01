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

        public override string ToString() => string.Format("{0:0}%", (float)(CurrentValue * 100.0));

    }

}