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

    }

}