namespace ExtendedSurvival.Stats
{
    public class IngestedFoodProperty
    {

        public float Max { get; set; }
        public float Current { get; set; }
        public float ConsumeRate { get; set; }
        public bool IsPositive { get; set; }

        public IngestedFoodProperty()
        {

        }

        public IngestedFoodProperty(float max, float consumeRate)
        {
            Max = max;
            Current = max;
            ConsumeRate = consumeRate;
            IsPositive = max > 0;
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
                ConsumeRate = ConsumeRate,
                IsPositive = IsPositive
            };
        }

        public static IngestedFoodProperty FromSaveData(PlayerData.IngestedFoodPropertyData data)
        {
            return new IngestedFoodProperty()
            {
                Max = data.Max,
                Current = data.Current,
                ConsumeRate = data.ConsumeRate,
                IsPositive = data.IsPositive
            };
        }

    }

}