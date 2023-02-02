using System;

namespace ExtendedSurvival.Stats
{
    public class IngestedFood
    {

        public float CurrentNotConsumed
        {
            get
            {
                return Math.Max(Solid.Current + Liquid.Current, 0);
            }
        }

        public float CurrentLiquidNotConsumed
        {
            get
            {
                return Math.Max(Liquid.Current, 0);
            }
        }

        public float CurrentSolidNotConsumed
        {
            get
            {
                return Math.Max(Solid.Current, 0);
            }
        }

        public bool FullyConsumed
        {
            get
            {
                return CurrentNotConsumed == 0;
            }
        }

        public UniqueEntityId Id { get; set; }

        /// <summary>
        /// X: Max, Y: Time, Z: NotConsumed
        /// </summary>
        public IngestedFoodProperty Solid { get; set; }
        public IngestedFoodProperty Liquid { get; set; }
        public IngestedFoodProperty Protein { get; set; }
        public IngestedFoodProperty Carbohydrate { get; set; }
        public IngestedFoodProperty Lipids { get; set; }
        public IngestedFoodProperty Vitamins { get; set; }
        public IngestedFoodProperty Minerals { get; set; }
        public IngestedFoodProperty Calories { get; set; }

        public PlayerData.IngestedFoodData GetSaveData()
        {
            return new PlayerData.IngestedFoodData()
            {
                Id = Id.DefinitionId,
                Solid = Solid.GetSaveData(),
                Liquid = Liquid.GetSaveData(),
                Protein = Protein.GetSaveData(),
                Carbohydrate = Carbohydrate.GetSaveData(),
                Lipids = Lipids.GetSaveData(),
                Vitamins = Vitamins.GetSaveData(),
                Minerals = Minerals.GetSaveData(),
                Calories = Calories.GetSaveData()
            };
        }

        public static IngestedFood FromSaveData(PlayerData.IngestedFoodData data)
        {
            return new IngestedFood()
            {
                Id = new UniqueEntityId(data.Id),
                Solid = IngestedFoodProperty.FromSaveData(data.Solid),
                Liquid = IngestedFoodProperty.FromSaveData(data.Liquid),
                Protein = IngestedFoodProperty.FromSaveData(data.Protein),
                Carbohydrate = IngestedFoodProperty.FromSaveData(data.Carbohydrate),
                Lipids = IngestedFoodProperty.FromSaveData(data.Lipids),
                Vitamins = IngestedFoodProperty.FromSaveData(data.Vitamins),
                Minerals = IngestedFoodProperty.FromSaveData(data.Minerals),
                Calories = IngestedFoodProperty.FromSaveData(data.Calories)
            };
        }

    }

}