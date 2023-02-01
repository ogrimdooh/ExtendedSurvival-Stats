namespace ExtendedSurvival.Stats
{
    public class IngestedFoodProperty
    {

        public float Max { get; set; }
        public float Current { get; set; }
        public float ConsumeRate { get; set; }

        public IngestedFoodProperty(float max, float consumeRate)
        {
            Max = max;
            Current = max;
            ConsumeRate = consumeRate;
        }

        public void AddAmmount(float ammount)
        {
            Max += ammount;
            Current += ammount;
        }

    }

}