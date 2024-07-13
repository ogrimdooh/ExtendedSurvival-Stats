namespace ExtendedSurvival.Stats
{
    public class MyStatPlayerStaminaAmount : MyStatSimpleProgressBase
    {

        protected override string GetStatName()
        {
            return "StaminaAmount";
        }

        protected override string GetId()
        {
            return "player_staminaamount";
        }

        public override string ToString() => Stat != null ? Stat.Value.ToString("#0") : "-";

    }
}