namespace ExtendedSurvival.Stats
{
    public class MyStatTimer01 : MyStatTimersProgressBase
    {

        protected override string GetId()
        {
            return "player_timer01";
        }

        protected override int GetTargetIndex()
        {
            return 1;
        }

    }

}