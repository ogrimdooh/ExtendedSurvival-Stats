namespace ExtendedSurvival.Stats
{
    public class ActiveFoodEffect
    {

        public FoodEffectTarget EffectTarget { get; set; } = FoodEffectTarget.Health;
        public IngestedFoodProperty CurrentValue { get; set; }

        public PlayerData.ActiveFoodEffectData GetSaveData()
        {
            return new PlayerData.ActiveFoodEffectData()
            {
                EffectTarget = (int)EffectTarget,
                CurrentValue = CurrentValue.GetSaveData()
            };
        }

        public static ActiveFoodEffect FromSaveData(PlayerData.ActiveFoodEffectData data)
        {
            return new ActiveFoodEffect()
            {
                EffectTarget = (FoodEffectTarget)data.EffectTarget,
                CurrentValue = IngestedFoodProperty.FromSaveData(data.CurrentValue)
            };
        }

    }

}