namespace ExtendedSurvival.Stats
{
    public class MyStatPlayerStamina : MyStatSimpleProgressBase
    {

        protected override string GetStatName()
        {
            return "Stamina";
        }

        protected override string GetId()
        {
            return "player_stamina";
        }

    }
}
