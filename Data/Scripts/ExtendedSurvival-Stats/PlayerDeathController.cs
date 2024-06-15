using Sandbox.Game.Components;
using Sandbox.Game.Entities.Character.Components;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using VRage.Game.ModAPI;

namespace ExtendedSurvival.Stats
{
    public static class PlayerDeathController
    {

        private static readonly ConcurrentDictionary<long, bool> hasDied = new ConcurrentDictionary<long, bool>();
        private static readonly ConcurrentDictionary<long, bool> waitFullCycle = new ConcurrentDictionary<long, bool>();

        public static bool PlayerHasDied(long playerId)
        {
            return hasDied.ContainsKey(playerId) && hasDied[playerId];
        }

        public static bool PlayerNeedWaitFullCycle(long playerId)
        {
            return waitFullCycle.ContainsKey(playerId) && waitFullCycle[playerId];
        }

        public static void ClearWaitFullCycle(long playerId)
        {
            waitFullCycle[playerId] = false;
        }

        public static void DoProcessPlayerDeath(long playerId, IMyCharacter character, MyCharacterStatComponent statComponent, Dictionary<string, float> storeStats)
        {
            try
            {
                PlayerActionsController.RefreshPlayerStatComponent(playerId, statComponent);
                var playerStats = PlayerActionsController.GetStatsEasyAcess(playerId);
                if (playerStats == null)
                    return;
                playerStats.SurvivalEffects.Value = storeStats[StatsConstants.FixedStats.StatsGroup01.ToString()];
                playerStats.DamageEffects.Value = storeStats[StatsConstants.FixedStats.StatsGroup02.ToString()];
                playerStats.TemperatureEffects.Value = storeStats[StatsConstants.FixedStats.StatsGroup03.ToString()];
                playerStats.DiseaseEffects.Value = storeStats[StatsConstants.FixedStats.StatsGroup04.ToString()];
                playerStats.OtherEffects.Value = storeStats[StatsConstants.FixedStats.StatsGroup05.ToString()];
                playerStats.WoundedTime.Value = storeStats[StatsConstants.ValidStats.WoundedTime.ToString()];
                playerStats.Stamina.Value = storeStats[StatsConstants.ValidStats.Stamina.ToString()];
                playerStats.Fatigue.Value = storeStats[StatsConstants.ValidStats.Fatigue.ToString()];
                playerStats.BodyEnergy.Value = storeStats[StatsConstants.ValidStats.BodyEnergy.ToString()];
                playerStats.BodyWater.Value = storeStats[StatsConstants.ValidStats.BodyWater.ToString()];
                playerStats.BodyPerformance.Value = storeStats[StatsConstants.ValidStats.BodyPerformance.ToString()];
                playerStats.BodyImmune.Value = storeStats[StatsConstants.ValidStats.BodyImmune.ToString()];
                playerStats.BodyCalories.Value = storeStats[StatsConstants.ValidStats.BodyCalories.ToString()];
                playerStats.Intestine.Value = storeStats[StatsConstants.ValidStats.Intestine.ToString()];
                playerStats.Bladder.Value = storeStats[StatsConstants.ValidStats.Bladder.ToString()];
                playerStats.BodyWeight.Value = storeStats[StatsConstants.ValidStats.BodyWeight.ToString()];
                playerStats.BodyMuscles.Value = storeStats[StatsConstants.ValidStats.BodyMuscles.ToString()];
                playerStats.BodyFat.Value = storeStats[StatsConstants.ValidStats.BodyFat.ToString()];
                playerStats.BodyProtein.Value = storeStats[StatsConstants.ValidStats.BodyProtein.ToString()];
                playerStats.BodyCarbohydrate.Value = storeStats[StatsConstants.ValidStats.BodyCarbohydrate.ToString()];
                playerStats.BodyLipids.Value = storeStats[StatsConstants.ValidStats.BodyLipids.ToString()];
                playerStats.BodyMinerals.Value = storeStats[StatsConstants.ValidStats.BodyMinerals.ToString()];
                playerStats.BodyVitamins.Value = storeStats[StatsConstants.ValidStats.BodyVitamins.ToString()];
                playerStats.RadiationTime.Value = storeStats[StatsConstants.ValidStats.RadiationTime.ToString()];
                playerStats.IntoxicationTime.Value = storeStats[StatsConstants.ValidStats.IntoxicationTime.ToString()];
                if (playerStats.CurrentDiseaseEffects.IsFlagSet(StatsConstants.DiseaseEffects.Hyperthermia))
                {
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Hyperthermia.ToString(), 0, true);
                }
                if (playerStats.CurrentDiseaseEffects.IsFlagSet(StatsConstants.DiseaseEffects.Hypothermia))
                {
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Hypothermia.ToString(), 0, true);
                }
                if (ExtendedSurvivalSettings.Instance.HardModeEnabled)
                {
                    foreach (var item in StatsConstants.ON_DEATH_APPLY_DAMAGE)
                    {
                        if (playerStats.CurrentDamageEffects.IsFlagSet(item.Key) || playerStats.CurrentDamageEffects == item.Key)
                        {
                            foreach (var target in item.Value.Value)
                            {
                                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, target.ToString(), 0, true);
                            }
                            AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, item.Value.Key.ToString(), 0, true);
                            break;
                        }
                    }
                    if (playerStats.CurrentDamageEffects != StatsConstants.DamageEffects.None)
                    {
                        statComponent.Health.Value = statComponent.Health.MaxValue * StatsConstants.DAMAGE_HEALTH_START_VALUE[(StatsConstants.DamageEffects)StatsConstants.GetMaxSetFlagValue(playerStats.CurrentDamageEffects)];
                    }
                    var OxygenComponent = character.Components.Get<MyCharacterOxygenComponent>();
                    if (OxygenComponent != null)
                    {
                        var gasId = MyCharacterOxygenComponent.OxygenId;
                        OxygenComponent.UpdateStoredGasLevel(ref gasId, 0.25f);
                        gasId = MyCharacterOxygenComponent.HydrogenId;
                        OxygenComponent.UpdateStoredGasLevel(ref gasId, 0.1f);
                    }
                }
                else
                {
                    playerStats.DamageEffects.Value = (int)StatsConstants.DamageEffects.None;
                }
                CheckMinimalToLive(playerStats);
                hasDied[playerId] = false;
            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(typeof(PlayerActionsController), ex);
            }
        }

        public static void DoProcessPlayerDied(long playerId, IMyCharacter character, MyCharacterStatComponent statComponent)
        {
            try
            {
                hasDied[playerId] = true;
                waitFullCycle[playerId] = true;
            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(typeof(PlayerActionsController), ex);
            }
        }

        private static void CheckMinimalToLive(PlayerStatsEasyAcess playerStats)
        {
            if (playerStats.BodyWater.Value <= 0)
            {
                playerStats.BodyWater.Value = PlayerBodyConstants.ReviveWaterReserve;
            }
        }

    }

}
