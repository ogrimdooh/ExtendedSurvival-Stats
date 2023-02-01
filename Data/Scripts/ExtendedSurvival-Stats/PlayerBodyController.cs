using System.Linq;
using System.Collections.Generic;

namespace ExtendedSurvival.Stats
{
    public class PlayerBodyController
    {

        public float IntestineVolume { get; set; }
        public float BladderVolume { get; set; }

        public float CurrentWeight { get; set; } = PlayerBodyConstants.StartWeight;
        public float CurrentFat { get; set; } = PlayerBodyConstants.StartFat;
        public float CurrentMuscle { get; set; } = PlayerBodyConstants.StartMuscle;
        public float CurrentPerformance { get; set; } = PlayerBodyConstants.StartPerformance;
        public float CurrentImunity { get; set; } = PlayerBodyConstants.StartImunity;
        public float WaterAmmount { get; set; } = PlayerBodyConstants.StartWaterReserve;
        public float CaloriesAmmount { get; set; } = PlayerBodyConstants.StartCalories;

        public float ProteinAmmount { get; set; }
        public float CarbohydrateAmmount { get; set; }
        public float LipidsAmmount { get; set; }
        public float VitaminsAmmount { get; set; }
        public float MineralsAmmount { get; set; }

        public float CurrentBodyWater
        {
            get
            {
                return WaterAmmount / PlayerBodyConstants.WaterReserveSize.W;
            }
        }

        public float CurrentBodyEnergy
        {
            get
            {
                if (CaloriesAmmount < 0)
                    return 0;
                if (CaloriesAmmount >= PlayerBodyConstants.CaloriesReserveSize.Y)
                    return 1;
                return CaloriesAmmount / PlayerBodyConstants.CaloriesReserveSize.Y;
            }
        }

        public float CurrentStomachVolume
        {
            get
            {
                return IngestedFoods.Sum(x => x.CurrentNotConsumed);
            }
        }

        public float CurrentStomachLiquid
        {
            get
            {
                return IngestedFoods.Sum(x => x.CurrentLiquidNotConsumed);
            }
        }

        public float CurrentStomachSolid
        {
            get
            {
                return IngestedFoods.Sum(x => x.CurrentSolidNotConsumed);
            }
        }

        public float CurrentStomachAmmount
        {
            get
            {
                return CurrentStomachVolume / PlayerBodyConstants.StomachSize.W;
            }
        }

        public float CurrentIntestineAmmount
        {
            get
            {
                return IntestineVolume / PlayerBodyConstants.IntestineSize.W;
            }
        }

        public float CurrentBladderAmmount
        {
            get
            {
                return BladderVolume / PlayerBodyConstants.BladderSize.W;
            }
        }

        public float CurrentHungerAmmount
        {
            get
            {
                // Less than the minimum
                if (CaloriesAmmount < PlayerBodyConstants.CaloriesReserveSize.X)
                {
                    if (CurrentStomachVolume >= PlayerBodyConstants.StomachSize.Z)
                        return 1.0f;
                    return CurrentStomachVolume / PlayerBodyConstants.StomachSize.Z;
                }
                // Greater than the maximum
                else if (CaloriesAmmount > PlayerBodyConstants.CaloriesReserveSize.Y)
                {
                    if (CurrentStomachVolume >= PlayerBodyConstants.StomachSize.X)
                        return 1.0f;
                    return CurrentStomachVolume / PlayerBodyConstants.StomachSize.X;
                }
                // In average
                else
                {
                    if (CurrentStomachVolume >= PlayerBodyConstants.StomachSize.Y)
                        return 1.0f;
                    return CurrentStomachVolume / PlayerBodyConstants.StomachSize.Y;
                }
            }
        }

        public float CurrentThirstAmmount
        {
            get
            {
                // Is Dehydrating
                if (WaterAmmount < PlayerBodyConstants.WaterReserveSize.Y)
                {
                    if (CurrentStomachLiquid >= PlayerBodyConstants.WaterReserveSize.W)
                        return 1.0f;
                    return CurrentStomachLiquid / PlayerBodyConstants.WaterReserveSize.W;
                }
                // Is Thirsty
                else if (WaterAmmount < PlayerBodyConstants.WaterReserveSize.Z)
                {
                    if (CurrentStomachLiquid >= PlayerBodyConstants.WaterReserveSize.Z)
                        return 1.0f;
                    return CurrentStomachLiquid / PlayerBodyConstants.WaterReserveSize.Z;
                }
                // In average
                else
                {
                    if (CurrentStomachLiquid >= PlayerBodyConstants.WaterReserveSize.Y)
                        return 1.0f;
                    return CurrentStomachLiquid / PlayerBodyConstants.StomachSize.Y;
                }
            }
        }

        public List<IngestedFood> IngestedFoods { get; set; } = new List<IngestedFood>();

        private void DoConsumeCicle(float staminaSpended)
        {
            float caloriesToConsume = PlayerBodyConstants.CaloriesConsumption.X;
            float waterToConsume = PlayerBodyConstants.WaterConsumption.X;
            if (staminaSpended > 0)
            {
                caloriesToConsume += PlayerBodyConstants.CaloriesConsumption.Y * staminaSpended;
                waterToConsume += PlayerBodyConstants.WaterConsumption.Y * staminaSpended;
            }
            CaloriesAmmount -= caloriesToConsume;
            WaterAmmount -= waterToConsume;
        }

        private void DoAbsorptionCicle()
        {
            foreach (var food in IngestedFoods)
            {
                if (food.Liquid.Current > 0)
                {
                    WaterAmmount += food.Liquid.ConsumeRate;
                    food.Liquid.Current -= food.Liquid.ConsumeRate;
                }
                if (food.Solid.Current > 0)
                {
                    IntestineVolume += food.Solid.ConsumeRate;
                    food.Solid.Current -= food.Solid.ConsumeRate;
                }
                if (food.Calories.Current > 0)
                {
                    CaloriesAmmount += food.Calories.ConsumeRate;
                    food.Calories.Current -= food.Calories.ConsumeRate;
                }
            }
            IngestedFoods.RemoveAll(x => x.FullyConsumed);
        }

        private void DoBladderCicle()
        {
            var waterToBladder = PlayerBodyConstants.WaterToBladder;
            if (WaterAmmount > PlayerBodyConstants.WaterReserveSize.W)
            {
                waterToBladder += WaterAmmount - PlayerBodyConstants.WaterReserveSize.W;
                WaterAmmount = PlayerBodyConstants.WaterReserveSize.W;
            }
            BladderVolume += waterToBladder;
        }

        public void DoCicle(float staminaSpended)
        {
            DoConsumeCicle(staminaSpended);
            DoAbsorptionCicle();
            DoBladderCicle();
        }

        public void DoConsumeItem(FoodDefinition food)
        {
            if (IngestedFoods.Any(x => x.Id == food.Id))
            {
                var foodInDigestion = IngestedFoods.FirstOrDefault(x => x.Id == food.Id);
                food.AddToIngestedFood(foodInDigestion);
            }
            else
            {
                IngestedFoods.Add(food.GetAsIngestedFood());
            }
        }

    }

}