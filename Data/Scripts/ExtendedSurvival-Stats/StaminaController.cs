using Sandbox.Game.Components;
using Sandbox.Game.Entities;
using System;
using System.Collections.Concurrent;
using System.Linq;
using VRage.Game;
using VRage.Game.ModAPI;
using VRage.Utils;

namespace ExtendedSurvival.Stats
{

    public static class StaminaController
    {

        private static ConcurrentDictionary<long, long> staminSpendTime = new ConcurrentDictionary<long, long>();
        private static ConcurrentDictionary<long, float> spendedStamina = new ConcurrentDictionary<long, float>();

        public static void DoCycle(long playerId, long spendTime, long updateTime, IMyCharacter character, MyCharacterStatComponent statComponent, MyEntityStat statEntity)
        {
            if (!staminSpendTime.ContainsKey(playerId))
                staminSpendTime[playerId] = 0;
            staminSpendTime[playerId] += updateTime;
            long cicleType = 250; /* default cycle time 250ms */
            if (staminSpendTime[playerId] >= cicleType)
            {

                staminSpendTime[playerId] -= cicleType;

                PlayerActionsController.ProcessUnderwater(playerId, character, WeatherConstants.GetWeatherInfo(character).CurrentEnvironmentType);

                MyEntityStat Fatigue;
                statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.ValidStats.Fatigue.ToString()), out Fatigue);
                MyEntityStat StatsGroup04; /* Disease Effects */
                statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.FixedStats.StatsGroup04.ToString()), out StatsGroup04);
                MyEntityStat StatsGroup03; /* Temperature Effects */
                statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.FixedStats.StatsGroup03.ToString()), out StatsGroup03);
                MyEntityStat StatsGroup02; /* Damage Effects */
                statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.FixedStats.StatsGroup02.ToString()), out StatsGroup02);
                MyEntityStat StatsGroup01; /* Survival Effects */
                statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.FixedStats.StatsGroup01.ToString()), out StatsGroup01);

                ProcessStamina(
                    playerId,
                    character,
                    statEntity,
                    Fatigue,
                    (StatsConstants.DamageEffects)((int)StatsGroup02.Value),
                    (StatsConstants.DiseaseEffects)((int)StatsGroup04.Value),
                    (StatsConstants.SurvivalEffects)((int)StatsGroup01.Value),
                    (StatsConstants.TemperatureEffects)((int)StatsGroup03.Value)
                );

                PlayerActionsController.ProcessCargoMax(character);
                PlayerActionsController.CheckHealthValue(playerId, statComponent);
                PlayerActionsController.CheckValuesToDoDamage(character, statComponent);

            }
        }

        private static float GetStaminaRuningMultiplier()
        {
            return Math.Min(1, StatsConstants.BASE_RUNING_MULTIPLIER * ExtendedSurvivalSettings.Instance.StaminaSettings.RuningDrainMultiplier);
        }

        private static float GetStaminaTreadmillMultiplier()
        {
            return Math.Min(1, StatsConstants.BASE_TREADMILL_MULTIPLIER * ExtendedSurvivalSettings.Instance.StaminaSettings.TreadmillDrainMultiplier);
        }

        private static float GetBaseStaminaToDecrease(IMyCharacter character)
        {
            if (character.IsCharacterUsingTool() && !character.IsCharacterMoving())
            {
                return StatsConstants.BASE_TOOL_STAMINA_DECREASE_FACTOR * ExtendedSurvivalSettings.Instance.StaminaSettings.ToolsDrainMultiplier;
            }
            else
            {
                return StatsConstants.BASE_STAMINA_DECREASE_FACTOR * ExtendedSurvivalSettings.Instance.StaminaSettings.DrainMultiplier;
            }
        }

        private static float CurrentBodyFatMultiplier(IMyCharacter character)
        {
            return 1;
        }

        private static float GetStaminaToDecrese(IMyCharacter character, StatsConstants.TemperatureEffects CurrentTemperatureEffects)
        {
            var finalValue = GetBaseStaminaToDecrease(character);
            if (ExtendedSurvivalSettings.Instance.StaminaSettings.IncriseStaminaDrainWithTemperature)
            {
                var maxTemperatureEffect = CurrentTemperatureEffects;
                maxTemperatureEffect &= ~StatsConstants.TemperatureEffects.Wet;
                if (StatsConstants.TEMPERATURE_STAMINA_CONSUME_FACTOR.ContainsKey(maxTemperatureEffect))
                    finalValue *= StatsConstants.TEMPERATURE_STAMINA_CONSUME_FACTOR[maxTemperatureEffect];
            }
            if (ExtendedSurvivalSettings.Instance.StaminaSettings.IncriseStaminaDrainWithBodyFat && CurrentBodyFatMultiplier(character) > 0)
            {

            }
            if (character.IsCharacterSprinting())
            {
                finalValue *= GetStaminaRuningMultiplier();
            }
            if (character.IsOnTreadmill())
            {
                finalValue *= GetStaminaTreadmillMultiplier();
            }
            return finalValue;
        }

        private static int GetTotalDiseaseMultiplier(StatsConstants.DiseaseEffects CurrentDiseaseEffects, StatsConstants.SurvivalEffects CurrentSurvivalEffects)
        {
            int totalMultiplier = 0;
            if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Dysentery))
                totalMultiplier++;
            if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Hypothermia))
                totalMultiplier++;
            if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Hyperthermia))
                totalMultiplier++;
            if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Infected))
                totalMultiplier++;
            if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Pneumonia))
                totalMultiplier++;
            if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Poison))
                totalMultiplier++;
            if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Dehydration))
                totalMultiplier++;
            if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.SevereDehydration))
                totalMultiplier += 2;
            if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Starvation))
                totalMultiplier++;
            if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.SevereStarvation))
                totalMultiplier += 2;
            if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Hypolipidemia))
                totalMultiplier++;
            if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Obesity))
                totalMultiplier++;
            if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.SevereObesity))
                totalMultiplier += 2;
            if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Rickets))
                totalMultiplier++;
            if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.SevereRickets))
                totalMultiplier += 2;
            if (StatsConstants.IsFlagSet(CurrentSurvivalEffects, StatsConstants.SurvivalEffects.Disoriented))
                totalMultiplier++;
            if (StatsConstants.IsFlagSet(CurrentSurvivalEffects, StatsConstants.SurvivalEffects.Suffocation))
                totalMultiplier += 2;
            return totalMultiplier;
        }

        private static float GetMaxStamina(MyEntityStat Stamina, StatsConstants.DiseaseEffects CurrentDiseaseEffects, StatsConstants.SurvivalEffects CurrentSurvivalEffects)
        {
            var maxStamina = Stamina.MaxValue;
            float totalStaminaToRemove = StatsConstants.BASE_TOTAL_STAMINA_REMOVE_PER_STACK * GetTotalDiseaseMultiplier(CurrentDiseaseEffects, CurrentSurvivalEffects);
            if (totalStaminaToRemove > 0)
                maxStamina *= 1 - (Math.Min(totalStaminaToRemove, StatsConstants.MAX_STAMINA_REMOVE_WHEN_STACK));
            return maxStamina;
        }

        public static void AddSpendedStamina(long playerId, float value)
        {
            if (!spendedStamina.ContainsKey(playerId))
                spendedStamina[playerId] = 0;
            spendedStamina[playerId] += value;
        }

        public static float GetSpendedStamina(long playerId)
        {
            if (spendedStamina.ContainsKey(playerId))
                return spendedStamina[playerId];
            return 0;
        }

        public static void ClearSpendedStamina(long playerId)
        {
            spendedStamina[playerId] = 0;
        }

        private static float GetStaminaToIncrease(StatsConstants.DamageEffects CurrentDamageEffects, StatsConstants.SurvivalEffects CurrentSurvivalEffects)
        {
            var finalValue = StatsConstants.BASE_STAMINA_INCREASE_FACTOR * ExtendedSurvivalSettings.Instance.StaminaSettings.GainMultiplier;
            if (ExtendedSurvivalSettings.Instance.StaminaSettings.DecreaseStaminaGainWithDamage)
            {
                var maxDamageEffect = (StatsConstants.DamageEffects)StatsConstants.GetMaxSetFlagValue(CurrentDamageEffects);
                if (StatsConstants.DAMAGE_STAMINA_REGEN_FACTOR.ContainsKey(maxDamageEffect))
                    finalValue *= StatsConstants.DAMAGE_STAMINA_REGEN_FACTOR[maxDamageEffect];
            }
            var activeSurvivalEffects = CurrentSurvivalEffects.GetFlags();
            if (activeSurvivalEffects.Any())
            {
                var effectWeight = activeSurvivalEffects.Sum(x => StatsConstants.GetSurvivalEffectFeelingLevel(x));
                finalValue *= Math.Max(1 - (0.1f * effectWeight), 0.3f);
            }
            return finalValue;
        }

        private static void ProcessStamina(long playerId, IMyCharacter character, MyEntityStat Stamina, MyEntityStat Fatigue, StatsConstants.DamageEffects CurrentDamageEffects, StatsConstants.DiseaseEffects CurrentDiseaseEffects, StatsConstants.SurvivalEffects CurrentSurvivalEffects, StatsConstants.TemperatureEffects CurrentTemperatureEffects)
        {
            var value = GetStaminaToDecrese(character, CurrentTemperatureEffects);
            var maxStamina = GetMaxStamina(Stamina, CurrentDiseaseEffects, CurrentSurvivalEffects);
            if (character.IsCharacterMoving() || character.IsCharacterUsingTool() || character.IsOnTreadmill())
            {
                AddSpendedStamina(playerId, value);
                if (Stamina.Value > 0)
                {
                    Stamina.Decrease(value, character.GetPlayer()?.IdentityId);
                }
                else
                {
                    var staminaDamage = StatsConstants.BASE_STAMINA_DAMAGE_FACTOR * ExtendedSurvivalSettings.Instance.StaminaSettings.DamageMultiplier;
                    if (staminaDamage > 0 && character.CanTakeDamage())
                        character.DoDamage(staminaDamage, MyDamageType.Environment, true);
                }
                if (Fatigue.Value < Fatigue.MaxValue)
                {
                    if (character.IsOnTreadmill())
                        value *= StatsConstants.BASE_FATIGUE_INCREASE_MULTIPLIER;
                    Fatigue.Increase(value, character.GetPlayer()?.IdentityId);
                }
            }
            else
            {
                if (Stamina.Value < maxStamina)
                {
                    Stamina.Increase(GetStaminaToIncrease(CurrentDamageEffects, CurrentSurvivalEffects), character.GetPlayer()?.IdentityId);
                }
            }
            if (Stamina.Value > maxStamina)
                Stamina.Value = maxStamina;
        }

    }

}
