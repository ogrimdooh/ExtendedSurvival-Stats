namespace ExtendedSurvival.Stats
{
    public class ActiveConsumibleEffect
    {

        public UniqueEntityId Id { get; set; }

        public FoodEffectTarget EffectTarget { get; set; } = FoodEffectTarget.Health;
        public IngestedFoodProperty CurrentValue { get; set; }

        public PlayerData.ActiveConsumibleEffectData GetSaveData()
        {
            return new PlayerData.ActiveConsumibleEffectData()
            {
                Id = Id.DefinitionId,
                EffectTarget = (int)EffectTarget,
                CurrentValue = CurrentValue.GetSaveData()
            };
        }

        public static ActiveConsumibleEffect FromSaveData(PlayerData.ActiveConsumibleEffectData data)
        {
            return new ActiveConsumibleEffect()
            {
                Id = new UniqueEntityId(data.Id),
                EffectTarget = (FoodEffectTarget)data.EffectTarget,
                CurrentValue = IngestedFoodProperty.FromSaveData(data.CurrentValue)
            };
        }

    }

}