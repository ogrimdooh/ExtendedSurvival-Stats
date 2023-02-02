namespace ExtendedSurvival.Stats
{
    public class IngestedFoodProperty
    {

        public float Max { get; set; }
        public float Current { get; set; }
        public float ConsumeRate { get; set; }

        public IngestedFoodProperty()
        {

        }

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

        public PlayerData.IngestedFoodPropertyData GetSaveData()
        {
            return new PlayerData.IngestedFoodPropertyData()
            {
                Max = Max,
                Current = Current,
                ConsumeRate = ConsumeRate
            };
        }

        public static IngestedFoodProperty FromSaveData(PlayerData.IngestedFoodPropertyData data)
        {
            return new IngestedFoodProperty()
            {
                Max = data.Max,
                Current = data.Current,
                ConsumeRate = data.ConsumeRate
            };
        }

    }

}