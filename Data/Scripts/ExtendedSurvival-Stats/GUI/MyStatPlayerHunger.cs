namespace ExtendedSurvival.Stats
{

    public class MyStatPlayerHunger : MyStatSimpleProgressBase
    {

        protected override string GetStatName()
        {
            return "Hunger";
        }

        protected override string GetId()
        {
            return "player_hunger";
        }

    }
}