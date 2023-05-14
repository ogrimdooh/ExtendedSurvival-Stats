namespace ExtendedSurvival.Stats
{
    public class MyStatPlayerBodyCalories : MyStatSimpleProgressBase
    {

        protected override string GetStatName()
        {
            return "BodyCalories";
        }

        protected override string GetId()
        {
            return "player_bodycalories";
        }

        protected override bool IsActive()
        {
            return IsWithHelmet() && GetBodyTrackerLevel() >= 2;
        }

        public override string ToString() => Stat != null ? Stat.Value.ToString("#0.0") : "-";

    }
}