using Sandbox.Game.Components;
using Sandbox.Game.Entities;
using Sandbox.Game.Entities.Character;
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

        public enum StaminaValueModifier
        {

            HigherStaminaExpenditure = 0,
            MaximumStaminaReduction = 1,
            LongerStaminaRechargeTime = 2,
            StaminaRegeneration = 3,
            MaximumStaminaBonus = 4

        }

        private static ConcurrentDictionary<long, long> staminSpendTime = new ConcurrentDictionary<long, long>();
        private static ConcurrentDictionary<long, long> staminRegenTime = new ConcurrentDictionary<long, long>();
        private static ConcurrentDictionary<long, float> spendedStamina = new ConcurrentDictionary<long, float>();
        private static ConcurrentDictionary<long, float> maxStamina = new ConcurrentDictionary<long, float>();

        public static void DoCycle(long playerId, long spendTime, long updateTime, IMyCharacter character, MyCharacterStatComponent statComponent, MyEntityStat statEntity)
        {
            if (!maxStamina.ContainsKey(playerId))
                maxStamina[playerId] = 0;

            PlayerActionsController.RefreshPlayerStatComponent(playerId, statComponent);

            if (!staminSpendTime.ContainsKey(playerId))
                staminSpendTime[playerId] = 0;
            staminSpendTime[playerId] += updateTime;
            long cicleType = 250; /* default cycle time 250ms */
            if (staminSpendTime[playerId] >= cicleType)
            {

                staminSpendTime[playerId] -= cicleType;

                PlayerUnderwaterController.ProcessUnderwater(playerId, character, WeatherConstants.GetWeatherInfo(character).CurrentEnvironmentType);

                RefreshMaxStamina(playerId);
                ProcessStamina(playerId, character);

                PlayerInventoryController.ProcessCargoMax(character);
                PlayerHealthController.CheckHealthValue(playerId, statComponent);
                PlayerHealthController.CheckValuesToDoDamage(playerId, character, statComponent);

            }

            if (!staminRegenTime.ContainsKey(playerId))
                staminRegenTime[playerId] = 0;
            staminRegenTime[playerId] += updateTime;
            long cicleRegenType = 250; /* default cycle time 250ms */
            float rechargeTime = PlayerActionsController.StatsMultiplier(playerId, StaminaValueModifier.LongerStaminaRechargeTime);
            cicleRegenType = (long)((float)cicleRegenType * rechargeTime);
            if (staminRegenTime[playerId] >= cicleRegenType)
            {

                staminRegenTime[playerId] -= cicleRegenType;

                ProcessStaminaRegen(playerId, character);

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

        private static float GetStaminaToDecrese(long playerId, IMyCharacter character)
        {
            var finalValue = GetBaseStaminaToDecrease(character);
            finalValue *= PlayerActionsController.StatsMultiplier(playerId, StaminaValueModifier.HigherStaminaExpenditure);
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

        private static float GetMaxStamina(long playerId)
        {
            var access = PlayerActionsController.GetStatsEasyAcess(playerId);
            if (access != null)
            {
                var maxValue = maxStamina[playerId];
                float reduction = PlayerActionsController.StatsMultiplier(playerId, StaminaValueModifier.MaximumStaminaReduction);
                maxValue *= reduction;
                return Math.Max(maxValue, StatsConstants.MIN_STAMINA_TO_USE);
            }
            return 0;
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

        private static float GetStaminaToIncrease(long playerId)
        {
            var finalValue = StatsConstants.BASE_STAMINA_INCREASE_FACTOR * ExtendedSurvivalSettings.Instance.StaminaSettings.GainMultiplier;
            float regeneration = PlayerActionsController.StatsMultiplier(playerId, StaminaValueModifier.StaminaRegeneration);
            finalValue *= regeneration;
            return finalValue;
        }

        private static void ProcessStaminaRegen(long playerId, IMyCharacter character)
        {
            var access = PlayerActionsController.GetStatsEasyAcess(playerId);
            if (access != null)
            {
                var maxStamina = GetMaxStamina(playerId);
                if (!character.IsCharacterMoving() && !character.IsCharacterUsingTool() && !character.IsOnTreadmill())
                {
                    if (access.StaminaAmount.Value < maxStamina)
                    {
                        access.StaminaAmount.Increase(GetStaminaToIncrease(playerId), character.GetPlayer()?.IdentityId);
                    }
                }
                if (access.StaminaAmount.Value > maxStamina)
                    access.StaminaAmount.Value = maxStamina;
                RefreshStaminaFactor(playerId, access);
            }
        }

        public static void ProcessJump(long playerId, IMyCharacter character)
        {
            var access = PlayerActionsController.GetStatsEasyAcess(playerId);
            if (access != null)
            {
                var value = GetStaminaToDecrese(playerId, character) * StatsConstants.JUMP_COST_MULTIPLIER * ExtendedSurvivalSettings.Instance.StaminaSettings.JumpDrainMultiplier;
                float expenditure = PlayerActionsController.StatsMultiplier(playerId, StaminaValueModifier.HigherStaminaExpenditure);
                value *= expenditure;
                AddSpendedStamina(playerId, value);
                if (access.StaminaAmount.Value > 0)
                {
                    access.StaminaAmount.Decrease(value, character.GetPlayer()?.IdentityId);
                }
                else
                {
                    var staminaDamage = StatsConstants.BASE_STAMINA_DAMAGE_FACTOR * ExtendedSurvivalSettings.Instance.StaminaSettings.DamageMultiplier;
                    if (staminaDamage > 0 && character.CanTakeDamage())
                        character.DoDamage(staminaDamage, MyDamageType.Environment, true);
                }
                if (access.Fatigue.Value < access.Fatigue.MaxValue)
                {
                    if (character.IsOnTreadmill())
                        value *= StatsConstants.BASE_FATIGUE_INCREASE_MULTIPLIER;
                    access.Fatigue.Increase(value, character.GetPlayer()?.IdentityId);
                }
                RefreshStaminaFactor(playerId, access);
            }
        }

        private static void RefreshMaxStamina(long playerId)
        {
            float value = 100;
            var access = PlayerActionsController.GetStatsEasyAcess(playerId);
            if (access != null)
            {
                value += PlayerActionsController.StatsMultiplier(playerId, StaminaValueModifier.MaximumStaminaBonus);
                value = Math.Max(value, StatsConstants.MIN_STAMINA_TO_USE);
            }
            maxStamina[playerId] = value;
        }

        private static void RefreshStaminaFactor(long playerId, PlayerStatsEasyAcess access)
        {
            access.Stamina.Value = (access.StaminaAmount.Value * 100) / maxStamina[playerId];            
        }

        private static void ProcessStamina(long playerId, IMyCharacter character)
        {
            var access = PlayerActionsController.GetStatsEasyAcess(playerId);
            if (access != null)
            {
                if (character.IsCharacterMoving() || character.IsCharacterUsingTool() || character.IsOnTreadmill())
                {
                    var value = GetStaminaToDecrese(playerId, character);
                    float expenditure = PlayerActionsController.StatsMultiplier(playerId, StaminaValueModifier.HigherStaminaExpenditure);
                    value *= expenditure;
                    AddSpendedStamina(playerId, value);
                    if (access.StaminaAmount.Value > 0)
                    {
                        access.StaminaAmount.Decrease(value, character.GetPlayer()?.IdentityId);
                    }
                    else
                    {
                        var staminaDamage = StatsConstants.BASE_STAMINA_DAMAGE_FACTOR * ExtendedSurvivalSettings.Instance.StaminaSettings.DamageMultiplier;
                        if (staminaDamage > 0 && character.CanTakeDamage())
                            character.DoDamage(staminaDamage, MyDamageType.Environment, true);
                    }
                    if (access.Fatigue.Value < access.Fatigue.MaxValue)
                    {
                        if (character.IsOnTreadmill())
                            value *= StatsConstants.BASE_FATIGUE_INCREASE_MULTIPLIER;
                        access.Fatigue.Increase(value, character.GetPlayer()?.IdentityId);
                    }
                    RefreshStaminaFactor(playerId, access);
                }
            }
        }

    }

}
