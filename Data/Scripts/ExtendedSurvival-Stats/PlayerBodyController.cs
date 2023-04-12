using System.Linq;
using System.Collections.Generic;
using Sandbox.ModAPI;
using System;

namespace ExtendedSurvival.Stats
{
    /*
    public class PlayerBodyController
    {

        public delegate void OnBodyEvent(PlayerBodyController sender, BodyEventType eventType);
        public delegate void OnBodyDisease(PlayerBodyController sender, StatsConstants.DiseaseEffects disease);
        public delegate void OnBodyDamage(PlayerBodyController sender, StatsConstants.DamageEffects damage);
        public delegate void OnFoodEffect(PlayerBodyController sender, FoodEffectTarget target, float ammount);

        public enum BodyEventType
        {

            FullIntestine = 0,
            FullBladder = 1,
            FullStomach = 2

        }

        public float IntestineVolume { get; set; }
        public float BladderVolume { get; set; }

        public float CurrentWeight { get; set; } = PlayerBodyConstants.StartWeight;
        public float CurrentFat { get; set; } = PlayerBodyConstants.StartWeight * PlayerBodyConstants.StartFat;
        public float CurrentMuscle { get; set; } = PlayerBodyConstants.StartWeight * PlayerBodyConstants.StartMuscle;

        public float CurrentPerformance { get; set; } = PlayerBodyConstants.StartPerformance;
        public float CurrentImunity { get; set; } = PlayerBodyConstants.StartImunity;
        public float WaterAmmount { get; set; } = PlayerBodyConstants.StartWaterReserve;
        public float CaloriesAmmount { get; set; } = PlayerBodyConstants.StartCalories;

        public float ProteinAmmount { get; set; } = PlayerBodyConstants.StartProteins;
        public float CarbohydrateAmmount { get; set; } = PlayerBodyConstants.StartCarbohydrates;
        public float LipidsAmmount { get; set; } = PlayerBodyConstants.StartLipids;
        public float VitaminsAmmount { get; set; } = PlayerBodyConstants.StartVitamins;
        public float MineralsAmmount { get; set; } = PlayerBodyConstants.StartMinerals;

        public event OnBodyEvent BodyEvent;
        public event OnBodyDisease BodyGetDisease;
        public event OnBodyDisease BodyCureDisease;
        public event OnBodyDamage BodyCureDamage;
        public event OnFoodEffect InstantFoodEffect;
        public event OnFoodEffect OverTimeFoodEffect;

        private float _caloriesToConsume = 0;
        private float _waterToConsume = 0;

        private float _proteinToConsume = 0;
        private float _carbohydrateToConsume = 0;
        private float _lipidsToConsume = 0;
        private float _vitaminsToConsume = 0;
        private float _mineralsToConsume = 0;

        private long deltaTime = 0;
        private long spendTime = 0;
        private long sedentaryTime = 0;

        public float FatFactor
        {
            get
            {
                return CurrentFat / CurrentWeight;
            }
        }

        public float MuscleFactor
        {
            get
            {
                return CurrentMuscle / CurrentWeight;
            }
        }

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
        public List<ActiveConsumibleEffect> ActiveFoodEffects { get; set; } = new List<ActiveConsumibleEffect>();

        public PlayerBodyController()
        {
            ResetCharacterStats();
        }

        private void DoCheckMinAndMaxValues()
        {
            CaloriesAmmount = Math.Min(Math.Max(CaloriesAmmount, PlayerBodyConstants.CaloriesLimit.X), PlayerBodyConstants.CaloriesLimit.Y);
            WaterAmmount = Math.Min(Math.Max(WaterAmmount, 0f), PlayerBodyConstants.WaterReserveSize.W);
            IntestineVolume = Math.Min(Math.Max(IntestineVolume, 0f), PlayerBodyConstants.IntestineSize.W);
            BladderVolume = Math.Min(Math.Max(BladderVolume, 0f), PlayerBodyConstants.BladderSize.W);
            CurrentWeight = Math.Min(Math.Max(CurrentWeight, PlayerBodyConstants.WeightLimit.X), PlayerBodyConstants.WeightLimit.Y);
            CurrentFat = Math.Min(Math.Max(CurrentFat, PlayerBodyConstants.FatLimit.X), PlayerBodyConstants.FatLimit.Y);
            CurrentMuscle = Math.Min(Math.Max(CurrentMuscle, PlayerBodyConstants.MuscleLimit.X), PlayerBodyConstants.MuscleLimit.Y);
            CurrentPerformance = Math.Min(Math.Max(CurrentPerformance, 0f), 1f);
            CurrentImunity = Math.Min(Math.Max(CurrentImunity, 0f), 1f);
            ProteinAmmount = Math.Min(Math.Max(ProteinAmmount, 0f), 1000f);
            CarbohydrateAmmount = Math.Min(Math.Max(CarbohydrateAmmount, 0f), 1000f);
            LipidsAmmount = Math.Min(Math.Max(LipidsAmmount, 0f), 1000f);
            VitaminsAmmount = Math.Min(Math.Max(VitaminsAmmount, 0f), 100f);
            MineralsAmmount = Math.Min(Math.Max(MineralsAmmount, 0f), 100f);
        }

        private void DoConsumeCicle(float staminaSpended)
        {
            _caloriesToConsume = PlayerBodyConstants.CaloriesConsumption.X;
            _waterToConsume = PlayerBodyConstants.WaterConsumption.X;
            _proteinToConsume = PlayerBodyConstants.ProteinConsumption.X;
            _carbohydrateToConsume = PlayerBodyConstants.CarbohydrateConsumption.X;
            _lipidsToConsume = PlayerBodyConstants.LipidConsumption.X;
            _mineralsToConsume = PlayerBodyConstants.MineralsConsumption.X;
            _vitaminsToConsume = PlayerBodyConstants.VitaminsConsumption.X;
            if (staminaSpended > 0)
            {
                _caloriesToConsume += PlayerBodyConstants.CaloriesConsumption.Y * staminaSpended;
                _waterToConsume += PlayerBodyConstants.WaterConsumption.Y * staminaSpended;
                _proteinToConsume += PlayerBodyConstants.ProteinConsumption.Y * staminaSpended;
                _carbohydrateToConsume += PlayerBodyConstants.CarbohydrateConsumption.Y * staminaSpended;
                _lipidsToConsume += PlayerBodyConstants.LipidConsumption.Y * staminaSpended;
                _mineralsToConsume += PlayerBodyConstants.MineralsConsumption.Y * staminaSpended;
                _vitaminsToConsume += PlayerBodyConstants.VitaminsConsumption.Y * staminaSpended;
            }
            CaloriesAmmount -= _caloriesToConsume / ExtendedSurvivalSettings.Instance.MetabolismSpeedMultiplier;
            WaterAmmount -= _waterToConsume / ExtendedSurvivalSettings.Instance.MetabolismSpeedMultiplier;
            ProteinAmmount -= _proteinToConsume / ExtendedSurvivalSettings.Instance.MetabolismSpeedMultiplier;
            CarbohydrateAmmount -= _carbohydrateToConsume / ExtendedSurvivalSettings.Instance.MetabolismSpeedMultiplier;
            LipidsAmmount -= _lipidsToConsume / ExtendedSurvivalSettings.Instance.MetabolismSpeedMultiplier;
            MineralsAmmount -= _mineralsToConsume / ExtendedSurvivalSettings.Instance.MetabolismSpeedMultiplier;
            VitaminsAmmount -= _vitaminsToConsume / ExtendedSurvivalSettings.Instance.MetabolismSpeedMultiplier;
        }

        private void DoEffectCicle()
        {
            foreach (var effect in ActiveFoodEffects)
            {
                if ((effect.CurrentValue.IsPositive && effect.CurrentValue.Current > 0) ||
                    (!effect.CurrentValue.IsPositive && effect.CurrentValue.Current < 0))
                {
                    if (OverTimeFoodEffect != null)
                    {
                        OverTimeFoodEffect(this, effect.EffectTarget, effect.CurrentValue.ConsumeRate);
                    }
                    effect.CurrentValue.Current -= effect.CurrentValue.ConsumeRate;
                }
            }
            ActiveFoodEffects.RemoveAll(x => 
                (x.CurrentValue.IsPositive && x.CurrentValue.Current <= 0) ||
                (!x.CurrentValue.IsPositive && x.CurrentValue.Current >= 0)
            );
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
                if (food.Protein.Current > 0)
                {
                    ProteinAmmount += food.Protein.ConsumeRate;
                    food.Protein.Current -= food.Protein.ConsumeRate;
                }
                if (food.Carbohydrate.Current > 0)
                {
                    CarbohydrateAmmount += food.Carbohydrate.ConsumeRate;
                    food.Carbohydrate.Current -= food.Carbohydrate.ConsumeRate;
                }
                if (food.Lipids.Current > 0)
                {
                    LipidsAmmount += food.Lipids.ConsumeRate;
                    food.Lipids.Current -= food.Lipids.ConsumeRate;
                }
                if (food.Vitamins.Current > 0)
                {
                    VitaminsAmmount += food.Vitamins.ConsumeRate;
                    food.Vitamins.Current -= food.Vitamins.ConsumeRate;
                }
                if (food.Minerals.Current > 0)
                {
                    MineralsAmmount += food.Minerals.ConsumeRate;
                    food.Minerals.Current -= food.Minerals.ConsumeRate;
                }
            }
            IngestedFoods.RemoveAll(x => x.FullyConsumed);
        }

        private void DoBladderCicle()
        {
            var waterToBladder = PlayerBodyConstants.WaterToBladder;
            if (WaterAmmount > PlayerBodyConstants.WaterReserveSize.W)
            {
                // 50% of water overload go to bladder
                waterToBladder += (WaterAmmount - PlayerBodyConstants.WaterReserveSize.W) * 0.50f;
                WaterAmmount = PlayerBodyConstants.WaterReserveSize.W;
            }
            if (_waterToConsume > 0)
            {
                // 15% of consumed water go to bladder
                waterToBladder += _waterToConsume * 0.15f; 
            }
            BladderVolume += waterToBladder;
        }

        private void DoCheckBodyState()
        {
            if (BodyEvent != null)
            {
                if (CurrentBladderAmmount >= 1)
                    BodyEvent(this, BodyEventType.FullBladder);
                if (CurrentIntestineAmmount >= 1)
                    BodyEvent(this, BodyEventType.FullIntestine);
                if (CurrentStomachAmmount >= 1)
                    BodyEvent(this, BodyEventType.FullStomach);
            }  
        }

        private float DoCheckBodyWeight()
        {
            float bodyChance = 0;
            if (CaloriesAmmount < PlayerBodyConstants.CaloriesReserveSize.X)
            {
                bodyChance -= PlayerBodyConstants.WeightChange.X;
            }
            else if (CaloriesAmmount > PlayerBodyConstants.CaloriesReserveSize.Y)
            {
                bodyChance += PlayerBodyConstants.WeightChange.Y;
            }
            CurrentWeight += bodyChance;
            return bodyChance;
        }

        public void ResetCharacterStats()
        {
            IntestineVolume = 0;
            BladderVolume = 0;
            CurrentWeight = PlayerBodyConstants.StartWeight;
            CurrentFat = PlayerBodyConstants.StartWeight* PlayerBodyConstants.StartFat;
            CurrentMuscle = PlayerBodyConstants.StartWeight* PlayerBodyConstants.StartMuscle;
            CurrentPerformance = PlayerBodyConstants.StartPerformance;
            CurrentImunity = PlayerBodyConstants.StartImunity;
            WaterAmmount = PlayerBodyConstants.StartWaterReserve;
            CaloriesAmmount = PlayerBodyConstants.StartCalories;
            ProteinAmmount = PlayerBodyConstants.StartProteins;
            CarbohydrateAmmount = PlayerBodyConstants.StartCarbohydrates;
            LipidsAmmount = PlayerBodyConstants.StartLipids;
            VitaminsAmmount = PlayerBodyConstants.StartVitamins;
            MineralsAmmount = PlayerBodyConstants.StartMinerals;
            DoEmptyStomach();
            DoConsumeItem(FoodConstants.FOOD_DEFINITIONS[ItensConstants.SANDWICH_ID]);
            DoConsumeItem(FoodConstants.FOOD_DEFINITIONS[ItensConstants.WATER_FLASK_SMALL_ID]);
        }

        public void CheckMinimalToLive()
        {
            if (WaterAmmount <= 0)
            {
                WaterAmmount = PlayerBodyConstants.ReviveWaterReserve;
            }
        }

        private long GetGameTime()
        {
            return ExtendedSurvivalCoreAPI.Registered ? ExtendedSurvivalCoreAPI.GetGameTime() : 0;
        }

        public void DoRefreshDeltaTime()
        {
            deltaTime = GetGameTime();
        }

        public bool DoCicle(float staminaSpended)
        {
            if (deltaTime == 0)
                DoRefreshDeltaTime();
            spendTime += GetGameTime() - deltaTime;
            if (staminaSpended == 0)
            {
                sedentaryTime += spendTime;
            }
            else if (sedentaryTime > 0)
            {
                sedentaryTime -= spendTime * 10;
                if (sedentaryTime < 0)
                    sedentaryTime = 0;
            }
            DoRefreshDeltaTime();
            long cicleType = 1000; 
            if (spendTime >= cicleType)
            {
                spendTime -= cicleType;
                DoConsumeCicle(staminaSpended);
                DoAbsorptionCicle();
                DoEffectCicle();
                DoBladderCicle();
                DoCheckBodyState();
                DoCheckMinAndMaxValues();
                float weightChange = DoCheckBodyWeight();
                if (weightChange < 0)
                {
                    
                }
                if (weightChange > 0)
                {
                   
                }
                else
                {
                    
                }
                return true;
            }
            return false;
        }

        protected static bool CheckChance(float chance)
        {
            return new Random().Next(1, 101) <= chance;
        }

        public void DoConsumeItem(MedicalDefinition medical)
        {
            DoProcessInjectedCureDamage(medical.CureDamage);
            DoProcessInjectedCureDisease(medical.CureDisease);
            DoProcessInjectedEffects(medical.Id, medical.Effects);
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
            DoProcessInjectedDiseaseChance(food.DiseaseChance);
            DoProcessInjectedCureDisease(food.CureDisease);
            DoProcessInjectedEffects(food.Id, food.Effects);
        }

        private void DoProcessInjectedDiseaseChance(Dictionary<StatsConstants.DiseaseEffects, float> diseaseChance)
        {
            if (BodyGetDisease != null && diseaseChance != null && diseaseChance.Any())
            {
                foreach (var disease in diseaseChance.Keys)
                {
                    var chance = diseaseChance[disease] * 100;
                    if (chance >= 100 || CheckChance(chance))
                    {
                        BodyGetDisease(this, disease);
                    }
                }
            }
        }

        private void DoProcessInjectedCureDisease(List<StatsConstants.DiseaseEffects> cureDisease)
        {
            if (BodyCureDisease != null && cureDisease != null && cureDisease.Any())
            {
                foreach (var disease in cureDisease)
                {
                    BodyCureDisease(this, disease);
                }
            }
        }

        private void DoProcessInjectedCureDamage(List<StatsConstants.DamageEffects> cureDamage)
        {
            if (BodyCureDamage != null && cureDamage != null && cureDamage.Any())
            {
                foreach (var damage in cureDamage)
                {
                    BodyCureDamage(this, damage);
                }
            }
        }

        private void DoProcessInjectedEffects(UniqueEntityId id, List<ConsumibleEffect> effects)
        {
            if (effects != null && effects.Any())
            {
                foreach (var effect in effects)
                {
                    switch (effect.EffectType)
                    {
                        case FoodEffectType.Instant:
                            if (InstantFoodEffect != null)
                            {
                                InstantFoodEffect(this, effect.EffectTarget, effect.Ammount);
                            }
                            break;
                        case FoodEffectType.OverTime:

                            if (ActiveFoodEffects.Any(x => x.Id == id))
                            {
                                var effectInDigestion = ActiveFoodEffects.FirstOrDefault(x => x.Id == id);
                                effectInDigestion.CurrentValue.AddAmmount(effect.Ammount);
                            }
                            else
                            {
                                ActiveFoodEffects.Add(new ActiveConsumibleEffect()
                                {
                                    Id = id,
                                    EffectTarget = effect.EffectTarget,
                                    CurrentValue = new IngestedFoodProperty(effect.Ammount, effect.Ammount / Math.Max(1, effect.TimeToEffect))
                                });
                            }
                            break;
                    }
                }
            }
        }

        public void DoEmptyBladder()
        {
            BladderVolume = 0;
        }

        public void DoEmptyIntestine()
        {
            IntestineVolume = 0;
        }

        public void DoEmptyStomach()
        {
            IngestedFoods.Clear();
        }

        public void SavePlayerData(PlayerData saveData)
        {
            saveData.SetStatValue(nameof(IntestineVolume), IntestineVolume);
            saveData.SetStatValue(nameof(BladderVolume), BladderVolume);
            saveData.SetStatValue(nameof(CurrentWeight), CurrentWeight);
            saveData.SetStatValue(nameof(CurrentFat), CurrentFat);
            saveData.SetStatValue(nameof(CurrentMuscle), CurrentMuscle);
            saveData.SetStatValue(nameof(CurrentPerformance), CurrentPerformance);
            saveData.SetStatValue(nameof(CurrentImunity), CurrentImunity);
            saveData.SetStatValue(nameof(WaterAmmount), WaterAmmount);
            saveData.SetStatValue(nameof(CaloriesAmmount), CaloriesAmmount);
            saveData.SetStatValue(nameof(ProteinAmmount), ProteinAmmount);
            saveData.SetStatValue(nameof(CarbohydrateAmmount), CarbohydrateAmmount);
            saveData.SetStatValue(nameof(LipidsAmmount), LipidsAmmount);
            saveData.SetStatValue(nameof(VitaminsAmmount), VitaminsAmmount);
            saveData.SetStatValue(nameof(MineralsAmmount), MineralsAmmount);
            saveData.IngestedFoods.Clear();
            foreach (var food in IngestedFoods)
            {
                saveData.IngestedFoods.Add(food.GetSaveData());
            }
            saveData.ActiveFoodEffects.Clear();
            foreach (var effect in ActiveFoodEffects)
            {
                saveData.ActiveFoodEffects.Add(effect.GetSaveData());
            }
        }

        public void LoadPlayerData(PlayerData saveData)
        {
            IntestineVolume = saveData.GetStatValue(nameof(IntestineVolume));
            BladderVolume = saveData.GetStatValue(nameof(BladderVolume));
            CurrentWeight = saveData.GetStatValue(nameof(CurrentWeight));
            CurrentFat = saveData.GetStatValue(nameof(CurrentFat));
            CurrentMuscle = saveData.GetStatValue(nameof(CurrentMuscle));
            CurrentPerformance = saveData.GetStatValue(nameof(CurrentPerformance));
            CurrentImunity = saveData.GetStatValue(nameof(CurrentImunity));
            WaterAmmount = saveData.GetStatValue(nameof(WaterAmmount));
            CaloriesAmmount = saveData.GetStatValue(nameof(CaloriesAmmount));
            ProteinAmmount = saveData.GetStatValue(nameof(ProteinAmmount));
            CarbohydrateAmmount = saveData.GetStatValue(nameof(CarbohydrateAmmount));
            LipidsAmmount = saveData.GetStatValue(nameof(LipidsAmmount));
            VitaminsAmmount = saveData.GetStatValue(nameof(VitaminsAmmount));
            MineralsAmmount = saveData.GetStatValue(nameof(MineralsAmmount));
            IngestedFoods.Clear();
            foreach (var food in saveData.IngestedFoods)
            {
                IngestedFoods.Add(IngestedFood.FromSaveData(food));
            }
            ActiveFoodEffects.Clear();
            foreach (var effect in saveData.ActiveFoodEffects)
            {
                ActiveFoodEffects.Add(ActiveConsumibleEffect.FromSaveData(effect));
            }
        }

    }
    */
}