namespace ExtendedSurvival.Stats
{
    public class MyStatPlayerStomach : MyStatSimpleProgressBase
    {

        protected override string GetStatName()
        {
            return "Stomach";
        }

        protected override string GetId()
        {
            return "player_stomach";
        }

        protected override bool IsActive()
        {
            return ExtendedSurvivalSettings.Instance.UseMetabolism;
        }

        public override string ToString() => string.Format("{0:0}%", (float)(CurrentValue * 100.0));

    }

}