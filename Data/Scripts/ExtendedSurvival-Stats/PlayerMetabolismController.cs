using Sandbox.Game.Components;
using System;
using System.Collections.Concurrent;
using System.Linq;

namespace ExtendedSurvival.Stats
{
    public static class PlayerMetabolismController
    {

        public enum MetabolismValueModifier
        {

            WaterConsumption = 0

        }

        public static void DoEatStartFood(long playerId)
        {
            AdvancedStatsAndEffectsAPI.DoPlayerConsume(playerId, FoodConstants.SANDWICH_ID.DefinitionId);
            AdvancedStatsAndEffectsAPI.DoPlayerConsume(playerId, ItensConstants.WATER_FLASK_SMALL_ID.DefinitionId);
        }

        public static void DoCleanYourself(long playerId)
        {
            AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.OtherEffects.PoopOnClothes.ToString(), 0, true);
            AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.OtherEffects.PeeOnClothes.ToString(), 0, true);
        }

        public static void DoBodyNeeds(long playerId, MyCharacterStatComponent statComponent)
        {
            PlayerActionsController.RefreshPlayerStatComponent(playerId, statComponent);
            var statsEasyAcess = PlayerActionsController.GetStatsEasyAcess(playerId);
            var CurrentBladderAmmount = statsEasyAcess.Bladder.MaxValue / statsEasyAcess.Bladder.Value;
            var CurrentIntestineAmmount = statsEasyAcess.Intestine.MaxValue / statsEasyAcess.Intestine.Value;
            if (CurrentBladderAmmount >= 0.075f)
                statsEasyAcess.Bladder.Value = 0;
            if (CurrentIntestineAmmount >= 0.5f)
                statsEasyAcess.Intestine.Value = 0;
        }

        public static void DoEmptyBladder(long playerId)
        {
            var statsEasyAcess = PlayerActionsController.GetStatsEasyAcess(playerId);
            statsEasyAcess.Bladder.Value = 0;
        }

        public static void DoEmptyIntestine(long playerId)
        {
            var statsEasyAcess = PlayerActionsController.GetStatsEasyAcess(playerId);
            statsEasyAcess.Intestine.Value = 0;
        }

        public static void DoEmptyStomach(long playerId)
        {
            AdvancedStatsAndEffectsAPI.ClearOverTimeConsumable(playerId);
        }

        public static void DoShitYourself(long playerId)
        {
            AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.OtherEffects.PoopOnClothes.ToString(), 0, true);
            DoEmptyIntestine(playerId);
        }

        public static void DoTakeAPiss(long playerId)
        {
            AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.OtherEffects.PeeOnClothes.ToString(), 0, true);
            DoEmptyBladder(playerId);
        }

        public static void DoVomit(long playerId)
        {
            AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DiseaseEffects.Queasy.ToString(), 1, false);
            DoEmptyStomach(playerId);
        }

        private static void CheckStomach(long playerId, PlayerStatsEasyAcess statsEasyAcess)
        {
            var percent = statsEasyAcess.Stomach.Value / statsEasyAcess.Stomach.MaxValue;
            var needToCheckStomach = true;
            if (!StatsConstants.IsFlagSet(statsEasyAcess.CurrentSurvivalEffects, StatsConstants.SurvivalEffects.StomachBursting))
            {
                if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentSurvivalEffects, StatsConstants.SurvivalEffects.FullStomach))
                {
                    if (percent >= 0.9f)
                    {
                        needToCheckStomach = false;
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.FullStomach.ToString(), 0, true);
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.StomachBursting.ToString(), 0, true);
                    }
                }
            }
            else
            {
                needToCheckStomach = false;
                if (percent < 0.9f)
                {
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.StomachBursting.ToString(), 0, true);
                    needToCheckStomach = true;
                }
            }
            if (needToCheckStomach)
            {
                if (!StatsConstants.IsFlagSet(statsEasyAcess.CurrentSurvivalEffects, StatsConstants.SurvivalEffects.FullStomach))
                {
                    if (percent >= 0.75f)
                    {
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.FullStomach.ToString(), 0, true);
                        needToCheckStomach = false;
                    }
                }
                else
                {
                    if (percent < 0.75f)
                    {
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.FullStomach.ToString(), 0, true);
                        needToCheckStomach = true;
                    }
                }
                if (needToCheckStomach)
                {
                    if (!StatsConstants.IsFlagSet(statsEasyAcess.CurrentSurvivalEffects, StatsConstants.SurvivalEffects.EmptyStomach))
                    {
                        if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentSurvivalEffects, StatsConstants.SurvivalEffects.StomachGrowling))
                        {
                            if (percent <= 0.05f)
                            {
                                needToCheckStomach = false;
                                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.StomachGrowling.ToString(), 0, true);
                                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.EmptyStomach.ToString(), 1, false);
                            }
                        }
                    }
                    else
                    {
                        needToCheckStomach = false;
                        if (percent > 0.05f)
                        {
                            AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.EmptyStomach.ToString(), 0, true);
                            needToCheckStomach = true;
                        }
                        else
                        {
                            var emptyStomach = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.SurvivalEffects.EmptyStomach.ToString());
                            if (emptyStomach >= StatsConstants.GetSurvivalEffectMaxInverseTime(StatsConstants.SurvivalEffects.EmptyStomach))
                            {
                                AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, StatsConstants.SurvivalEffects.EmptyStomach.ToString(), 0);
                                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.EmptyStomach.ToString(), 1, false);
                            }
                        }
                    }
                    if (needToCheckStomach)
                    {
                        if (!StatsConstants.IsFlagSet(statsEasyAcess.CurrentSurvivalEffects, StatsConstants.SurvivalEffects.StomachGrowling))
                        {
                            if (percent <= 0.15f)
                            {
                                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.StomachGrowling.ToString(), 0, true);
                            }
                        }
                        else
                        {
                            if (percent > 0.15f)
                            {
                                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.StomachGrowling.ToString(), 0, true);
                            }
                        }
                    }
                }
            }
        }

        private static void CheckIntestine(long playerId, PlayerStatsEasyAcess statsEasyAcess)
        {
            var percent = statsEasyAcess.Intestine.Value / statsEasyAcess.Intestine.MaxValue;
            var needToCheckStarvation = true;
            if (!StatsConstants.IsFlagSet(statsEasyAcess.CurrentSurvivalEffects, StatsConstants.SurvivalEffects.GutBurst))
            {
                if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentSurvivalEffects, StatsConstants.SurvivalEffects.FullGut))
                {
                    if (percent >= 0.9f)
                    {
                        needToCheckStarvation = false;
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.FullGut.ToString(), 0, true);
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.GutBurst.ToString(), 0, true);
                    }
                }
            }
            else
            {
                needToCheckStarvation = false;
                if (percent < 0.9f)
                {
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.GutBurst.ToString(), 0, true);
                    needToCheckStarvation = true;
                }
            }
            if (needToCheckStarvation)
            {
                if (!StatsConstants.IsFlagSet(statsEasyAcess.CurrentSurvivalEffects, StatsConstants.SurvivalEffects.FullGut))
                {
                    if (percent >= 0.75f)
                    {
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.FullGut.ToString(), 0, true);
                    }
                }
                else
                {
                    if (percent < 0.75f)
                    {
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.FullGut.ToString(), 0, true);
                    }
                }
            }
        }

        private static void CheckBladder(long playerId, PlayerStatsEasyAcess statsEasyAcess)
        {
            var percent = statsEasyAcess.Bladder.Value / statsEasyAcess.Bladder.MaxValue;
            var needToCheckStarvation = true;
            if (!StatsConstants.IsFlagSet(statsEasyAcess.CurrentSurvivalEffects, StatsConstants.SurvivalEffects.BladderBurst))
            {
                if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentSurvivalEffects, StatsConstants.SurvivalEffects.FullBladder))
                {
                    if (percent >= 0.9f)
                    {
                        needToCheckStarvation = false;
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.FullBladder.ToString(), 0, true);
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.BladderBurst.ToString(), 0, true);
                    }
                }
            }
            else
            {
                needToCheckStarvation = false;
                if (percent < 0.9f)
                {
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.BladderBurst.ToString(), 0, true);
                    needToCheckStarvation = true;
                }
            }
            if (needToCheckStarvation)
            {
                if (!StatsConstants.IsFlagSet(statsEasyAcess.CurrentSurvivalEffects, StatsConstants.SurvivalEffects.FullBladder))
                {
                    if (percent >= 0.75f)
                    {
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.FullBladder.ToString(), 0, true);
                    }
                }
                else
                {
                    if (percent < 0.75f)
                    {
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.FullBladder.ToString(), 0, true);
                    }
                }
            }
        }

        private static void CheckHungerValues(long playerId, PlayerStatsEasyAcess statsEasyAcess)
        {
            var percentValue = statsEasyAcess.Hunger.Value / statsEasyAcess.Hunger.MaxValue;
            if (percentValue <= 0.05f)
            {
                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.Famished.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Hungry.ToString(), 0, true);
            }
            else if (percentValue <= 0.2f)
            {
                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.Hungry.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Famished.ToString(), 0, true);
            }
            else
            {
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Hungry.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Famished.ToString(), 0, true);
            }
        }

        private static void CheckThirstValues(long playerId, PlayerStatsEasyAcess statsEasyAcess)
        {
            var percentValue = statsEasyAcess.Thirst.Value / statsEasyAcess.Thirst.MaxValue;
            if (percentValue <= 0.05f)
            {
                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.Dehydrating.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Thirsty.ToString(), 0, true);
            }
            else if (percentValue <= 0.2f)
            {
                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.Thirsty.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Dehydrating.ToString(), 0, true);
            }
            else
            {
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Thirsty.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Dehydrating.ToString(), 0, true);
            }
        }

        public static void CheckAllDigestionStats(long playerId)
        {
            var statsEasyAcess = PlayerActionsController.GetStatsEasyAcess(playerId);

            CheckStomach(playerId, statsEasyAcess);
            CheckIntestine(playerId, statsEasyAcess);
            CheckBladder(playerId, statsEasyAcess);
            CheckHungerValues(playerId, statsEasyAcess);
            CheckThirstValues(playerId, statsEasyAcess);
        }

        private static ConcurrentDictionary<long, float> sedentaryTime = new ConcurrentDictionary<long, float>();
        private static ConcurrentDictionary<long, float> lastCaloriesValue = new ConcurrentDictionary<long, float>();
        private static ConcurrentDictionary<long, float> lastCaloriesChange = new ConcurrentDictionary<long, float>();
        private static ConcurrentDictionary<long, float> waterToConsume = new ConcurrentDictionary<long, float>();

        public static void DoDigestion(long playerId, long spendTime, PlayerStatsEasyAcess statsEasyAcess)
        {
            var staminaSpended = StaminaController.GetSpendedStamina(playerId);

            if (!sedentaryTime.ContainsKey(playerId))
                sedentaryTime[playerId] = 0;
            if (staminaSpended == 0)
            {
                sedentaryTime[playerId] += spendTime;
            }
            else if (sedentaryTime[playerId] > 0)
            {
                sedentaryTime[playerId] -= spendTime * 10;
                if (sedentaryTime[playerId] < 0)
                    sedentaryTime[playerId] = 0;
            }

            DoConsumeCicle(playerId, staminaSpended, statsEasyAcess);

            var currentCaloriesValue = statsEasyAcess.BodyCalories.Value;
            lastCaloriesChange[playerId] = !lastCaloriesValue.ContainsKey(playerId) ? 0 : currentCaloriesValue - lastCaloriesValue[playerId];
            lastCaloriesValue[playerId] = currentCaloriesValue;

            DoBladderCicle(playerId, statsEasyAcess);
            DoCheckBodyState(playerId, statsEasyAcess);
            DoStomachCicle(playerId, statsEasyAcess);
            float weightChange = DoCheckBodyWeight(playerId, lastCaloriesChange[playerId], statsEasyAcess);
            if (weightChange < 0)
            {
                /* The body always consumes muscle first during body loss with no protein reserve and is sedentary */

            }
            if (weightChange > 0)
            {
                /* The body always gain fat with no stamina spend or no protein reserve */

            }
            else
            {
                /* No body change, but transform fat into muscle with stamina spend and protein reserve */

            }
        }

        private static void DoCheckBodyState(long playerId, PlayerStatsEasyAcess statsEasyAcess)
        {
            if (statsEasyAcess.Bladder.Value >= statsEasyAcess.Bladder.MaxValue)
            {
                DoTakeAPiss(playerId);
            }
            if (statsEasyAcess.Intestine.Value >= statsEasyAcess.Intestine.MaxValue)
            {
                DoShitYourself(playerId);
            }
            if (statsEasyAcess.Stomach.Value >= statsEasyAcess.Stomach.MaxValue)
            {
                DoVomit(playerId);
            }
        }

        private static float DoCheckBodyWeight(long playerId, float lastCaloriesChange, PlayerStatsEasyAcess statsEasyAcess)
        {
            float bodyChance = 0;
            if (statsEasyAcess.BodyCalories.Value < PlayerBodyConstants.CaloriesReserveSize.X &&
                lastCaloriesChange < 0) /* Esta com baixa energia e não consumiu calorias */
            {
                bodyChance -= PlayerBodyConstants.WeightChange.X;
            }
            else if (statsEasyAcess.BodyCalories.Value > PlayerBodyConstants.CaloriesReserveSize.Y &&
                lastCaloriesChange > 0) /* Esta com alta energia e não esta gastando ela */
            {
                bodyChance += PlayerBodyConstants.WeightChange.Y;
            }
            statsEasyAcess.BodyWeight.Value += bodyChance;
            return bodyChance;
        }

        private static void DoStomachCicle(long playerId, PlayerStatsEasyAcess statsEasyAcess)
        {
            var solid = AdvancedStatsAndEffectsAPI.GetRemainOverTimeConsumable(playerId, StatsConstants.VirtualStats.Solid.ToString());
            var liquid = AdvancedStatsAndEffectsAPI.GetRemainOverTimeConsumable(playerId, StatsConstants.VirtualStats.Liquid.ToString());
            statsEasyAcess.Stomach.Value = solid + liquid;
            statsEasyAcess.Hunger.Value = GetCurrentHungerAmmount(playerId, statsEasyAcess.BodyCalories.Value, statsEasyAcess.Stomach.Value) * statsEasyAcess.Hunger.MaxValue;
            statsEasyAcess.Thirst.Value = GetCurrentThirstAmmount(playerId, statsEasyAcess.BodyWater.Value, liquid) * statsEasyAcess.Thirst.MaxValue;
            statsEasyAcess.BodyEnergy.Value = GetCurrentBodyEnergy(statsEasyAcess.BodyCalories.Value) * statsEasyAcess.BodyEnergy.MaxValue;
        }

        private static float GetCurrentHungerAmmount(long playerId, float CaloriesAmmount, float CurrentStomachVolume)
        {
            var cal = Math.Max(Math.Min(CaloriesAmmount, PlayerBodyConstants.CAL_LIMIT_MAX), PlayerBodyConstants.CAL_LIMIT_MIN);
            var target = PlayerBodyConstants.BodyCalorieStats.FirstOrDefault(x => cal >= x.From && cal < x.To);
            var minToReturn = target.MinToReturn;
            var targetStomachSize = GetTargetStomachSize(playerId, target.TargetStomachSize, ref minToReturn);
            if (CurrentStomachVolume >= targetStomachSize)
                return 1.0f;
            var finalValue = CurrentStomachVolume / targetStomachSize;
            return minToReturn > 0 ? Math.Max(finalValue, minToReturn) : finalValue;
        }

        private static float GetCurrentThirstAmmount(long playerId, float WaterAmmount, float CurrentStomachLiquid)
        {
            var water = Math.Max(Math.Min(WaterAmmount, PlayerBodyConstants.WATER_RESERVE_DEAD), PlayerBodyConstants.WATER_RESERVE_FULL);
            var target = PlayerBodyConstants.BodyWaterStats.FirstOrDefault(x => water >= x.From && water < x.To);
            var minToReturn = target.MinToReturn;
            var targetStomachSize = GetTargetStomachSize(playerId, target.TargetStomachSize, ref minToReturn, 0.75f);
            if (CurrentStomachLiquid >= targetStomachSize)
                return 1.0f;
            var finalValue = CurrentStomachLiquid / targetStomachSize;
            return minToReturn > 0 ? Math.Max(finalValue, minToReturn) : finalValue;
        }

        private static float GetTargetStomachSize(long playerId, float baseValue, ref float baseMinToReturn, float maxValue = 1f)
        {
            var stack = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatStack(playerId, StatsConstants.SurvivalEffects.EmptyStomach.ToString());
            if (stack > 0)
            {
                var increase = (maxValue - baseValue) / StatsConstants.GetSurvivalEffectMaxStacks(StatsConstants.SurvivalEffects.EmptyStomach);
                var increaseMinToReturn = baseMinToReturn / StatsConstants.GetSurvivalEffectMaxStacks(StatsConstants.SurvivalEffects.EmptyStomach);
                baseMinToReturn -= increaseMinToReturn * stack;
                return baseValue + (increase * stack);
            }
            return baseValue;
        }

        private static float GetCurrentBodyEnergy(float CaloriesAmmount)
        {
            if (CaloriesAmmount < 0)
                return 0;
            if (CaloriesAmmount >= PlayerBodyConstants.CaloriesReserveSize.Y)
                return 1;
            return CaloriesAmmount / PlayerBodyConstants.CaloriesReserveSize.Y;
        }

        private static void DoBladderCicle(long playerId, PlayerStatsEasyAcess statsEasyAcess)
        {
            statsEasyAcess.Bladder.Value += PlayerBodyConstants.WaterToBladder / ExtendedSurvivalSettings.Instance.MetabolismSpeedMultiplier;
        }

        private static void DoWaterConsumeCicle(long playerId, float staminaSpended, PlayerStatsEasyAcess statsEasyAcess, float mSpeed)
        {
            waterToConsume[playerId] = PlayerBodyConstants.WaterConsumption.X;
            if (staminaSpended > 0)
            {
                waterToConsume[playerId] += PlayerBodyConstants.WaterConsumption.Y * staminaSpended;
            }
            waterToConsume[playerId] *= PlayerActionsController.StatsMultiplier(playerId, StatsConstants.ValidStats.BodyWater);
            var bonusFactor = PlayerActionsController.StatsMultiplier(playerId, MetabolismValueModifier.WaterConsumption);
            if (bonusFactor != 0)
            {
                waterToConsume[playerId] += waterToConsume[playerId] * bonusFactor;
            }
            statsEasyAcess.BodyWater.Value -= waterToConsume[playerId] * ExtendedSurvivalSettings.Instance.MetabolismSettings.WaterConsumeMultiplier / mSpeed;
        }

        private static void DoConsumeCicle(long playerId, float staminaSpended, PlayerStatsEasyAcess statsEasyAcess)
        {
            var _caloriesToConsume = PlayerBodyConstants.CaloriesConsumption.X;
            var _proteinToConsume = PlayerBodyConstants.ProteinConsumption.X;
            var _carbohydrateToConsume = PlayerBodyConstants.CarbohydrateConsumption.X;
            var _lipidsToConsume = PlayerBodyConstants.LipidConsumption.X;
            var _mineralsToConsume = PlayerBodyConstants.MineralsConsumption.X;
            var _vitaminsToConsume = PlayerBodyConstants.VitaminsConsumption.X;
            if (staminaSpended > 0)
            {
                staminaSpended *= ExtendedSurvivalSettings.Instance.MetabolismSettings.StaminaSpendedMultiplier;
                _caloriesToConsume += PlayerBodyConstants.CaloriesConsumption.Y * staminaSpended;
                _proteinToConsume += PlayerBodyConstants.ProteinConsumption.Y * staminaSpended;
                _carbohydrateToConsume += PlayerBodyConstants.CarbohydrateConsumption.Y * staminaSpended;
                _lipidsToConsume += PlayerBodyConstants.LipidConsumption.Y * staminaSpended;
                _mineralsToConsume += PlayerBodyConstants.MineralsConsumption.Y * staminaSpended;
                _vitaminsToConsume += PlayerBodyConstants.VitaminsConsumption.Y * staminaSpended;
            }
            _caloriesToConsume *= PlayerActionsController.StatsMultiplier(playerId, StatsConstants.ValidStats.BodyCalories);
            _proteinToConsume *= PlayerActionsController.StatsMultiplier(playerId, StatsConstants.ValidStats.BodyProtein);
            _carbohydrateToConsume *= PlayerActionsController.StatsMultiplier(playerId, StatsConstants.ValidStats.BodyCarbohydrate);
            _lipidsToConsume *= PlayerActionsController.StatsMultiplier(playerId, StatsConstants.ValidStats.BodyLipids);
            _mineralsToConsume *= PlayerActionsController.StatsMultiplier(playerId, StatsConstants.ValidStats.BodyMinerals);
            _vitaminsToConsume *= PlayerActionsController.StatsMultiplier(playerId, StatsConstants.ValidStats.BodyVitamins);
            var mSpeed = ExtendedSurvivalSettings.Instance.MetabolismSpeedMultiplier;
            statsEasyAcess.BodyCalories.Value -= _caloriesToConsume * ExtendedSurvivalSettings.Instance.MetabolismSettings.CaloriesConsumeMultiplier / mSpeed;
            statsEasyAcess.BodyProtein.Value -= _proteinToConsume * ExtendedSurvivalSettings.Instance.MetabolismSettings.ProteinConsumeMultiplier / mSpeed;
            statsEasyAcess.BodyCarbohydrate.Value -= _carbohydrateToConsume * ExtendedSurvivalSettings.Instance.MetabolismSettings.CarbohydrateConsumeMultiplier / mSpeed;
            statsEasyAcess.BodyLipids.Value -= _lipidsToConsume * ExtendedSurvivalSettings.Instance.MetabolismSettings.LipidsConsumeMultiplier / mSpeed;
            statsEasyAcess.BodyMinerals.Value -= _mineralsToConsume * ExtendedSurvivalSettings.Instance.MetabolismSettings.MineralsConsumeMultiplier / mSpeed;
            statsEasyAcess.BodyVitamins.Value -= _vitaminsToConsume * ExtendedSurvivalSettings.Instance.MetabolismSettings.VitaminsConsumeMultiplier / mSpeed;
            DoWaterConsumeCicle(playerId, staminaSpended, statsEasyAcess, mSpeed);
        }

    }

}
