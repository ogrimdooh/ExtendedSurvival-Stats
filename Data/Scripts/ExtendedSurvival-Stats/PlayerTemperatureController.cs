using System.Collections.Concurrent;
using System.Linq;
using VRage.Game.ModAPI;
using VRageMath;

namespace ExtendedSurvival.Stats
{
    public static class PlayerTemperatureController
    {

        private static void CheckTemperatureEffect(long playerId, PlayerStatsEasyAcess statsEasyAcess)
        {
            if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToCold))
            {
                var exposedToCold = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToCold.ToString());
                if (exposedToCold >= StatsConstants.TEMPERATURE_EFFECTS[StatsConstants.TemperatureEffects.ExposedToCold].MaxInverseTime)
                {
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.OnFire.ToString(), 0, true);
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.Overheating.ToString(), 0, true);
                    AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.Cold.ToString(), 0, true);
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.Frosty.ToString(), 0, true);
                }
            }
            if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToFreeze))
            {
                var exposedToFreeze = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToFreeze.ToString());
                if (exposedToFreeze >= StatsConstants.TEMPERATURE_EFFECTS[StatsConstants.TemperatureEffects.ExposedToFreeze].MaxInverseTime)
                {
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.OnFire.ToString(), 0, true);
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.Overheating.ToString(), 0, true);
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.Cold.ToString(), 0, true);
                    AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.Frosty.ToString(), 0, true);
                }
            }
            if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToHot))
            {
                var exposedToHot = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToHot.ToString());
                if (exposedToHot >= StatsConstants.TEMPERATURE_EFFECTS[StatsConstants.TemperatureEffects.ExposedToHot].MaxInverseTime)
                {
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.OnFire.ToString(), 0, true);
                    AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.Overheating.ToString(), 0, true);
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.Cold.ToString(), 0, true);
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.Frosty.ToString(), 0, true);
                }
            }
            if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToBoiling))
            {
                var exposedToBoiling = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToBoiling.ToString());
                if (exposedToBoiling >= StatsConstants.TEMPERATURE_EFFECTS[StatsConstants.TemperatureEffects.ExposedToBoiling].MaxInverseTime)
                {
                    AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.OnFire.ToString(), 0, true);
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.Overheating.ToString(), 0, true);
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.Cold.ToString(), 0, true);
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.Frosty.ToString(), 0, true);
                }
            }
        }

        public static bool HasResistenceToHot(long playerId)
        {
            var statsEasyAcess = PlayerActionsController.GetStatsEasyAcess(playerId);
            foreach (var stat in StatsConstants.HOT_RESISTENCES)
            {
                if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, stat))
                    return true;
            }
            return false;
        }

        public static bool HasResistenceToCold(long playerId)
        {
            var statsEasyAcess = PlayerActionsController.GetStatsEasyAcess(playerId);
            foreach (var stat in StatsConstants.COLD_RESISTENCES)
            {
                if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, stat))
                    return true;
            }
            return false;
        }

        public static Vector4 GetTemperatureRange(long playerId)
        {
            var baseRange = new Vector4(TEMPERATURE_HARD_RANGE.X, TEMPERATURE_RANGE.X, TEMPERATURE_RANGE.Y, TEMPERATURE_HARD_RANGE.Y);
            var armorInfo = PlayerArmorController.GetEquipedArmor(playerId, useCache: true);
            if (armorInfo != null && armorInfo.HasArmor)
            {
                baseRange = new Vector4(
                    baseRange.X,
                    baseRange.Y - armorInfo.ArmorDefinition.ColdResistence,
                    baseRange.Z + armorInfo.ArmorDefinition.HotResistence,
                    baseRange.W
                );
            }
            return baseRange;
        }

        public static readonly Vector2 TEMPERATURE_RANGE = new Vector2(10f, 40f);
        public static readonly Vector2 TEMPERATURE_HARD_RANGE = new Vector2(0f, 50f);
        public static readonly ConcurrentDictionary<StatsConstants.TemperatureEffects, long> LAST_TEMP_TIME = new ConcurrentDictionary<StatsConstants.TemperatureEffects, long>();

        public static void IncDevTemperatureTimer(PlayerStatsEasyAcess playerStats, long playerId, long timePassed, WeatherConstants.WeatherInfo weatherInfo, PlayerArmorController.PlayerEquipInfo armor)
        {
            var statsEasyAcess = PlayerActionsController.GetStatsEasyAcess(playerId);
            if (playerStats != null)
            {
                IMyInventoryItem[] coldBottles;
                IMyInventoryItem[] hotBottles;
                bool hasCold;
                bool hasHot;
                PlayerThermalFluidController.UpdateFluidStats(playerStats, armor, playerId, out hasCold, out hasHot, out coldBottles, out hotBottles);
                var needToRemove = true;
                var temperature = weatherInfo.CurrentTemperature.Y;
                var range = GetTemperatureRange(playerId);
                if (temperature > range.Z)
                {
                    if (temperature >= range.W)
                    {
                        bool needToContinue = true;
                        if (hasHot && playerStats.HotThermalFluid.Value > 0 && hotBottles.Any())
                        {
                            needToContinue = PlayerThermalFluidController.DoGetGasToCool(temperature - range.W, armor, hotBottles, EquipmentConstants.HOTTHERMALREGULATORS_MODULES);
                        }
                        if (needToContinue)
                        {
                            AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToBoiling.ToString(), 0, true);
                            if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToHot))
                            {
                                LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToHot] = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToHot.ToString());
                                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToHot.ToString(), 0, true);
                                AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToBoiling.ToString(), LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToHot]);
                            }
                            else if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.RecoveringFromExposure))
                            {
                                if (LAST_TEMP_TIME.ContainsKey(StatsConstants.TemperatureEffects.ExposedToBoiling))
                                    AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToBoiling.ToString(), LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToBoiling]);
                                else if (LAST_TEMP_TIME.ContainsKey(StatsConstants.TemperatureEffects.ExposedToHot))
                                    AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToBoiling.ToString(), LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToHot]);
                                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.RecoveringFromExposure.ToString(), 0, true);
                            }
                            if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToFreeze))
                                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToFreeze.ToString(), 0, true);
                            if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToCold))
                                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToCold.ToString(), 0, true);
                            needToRemove = false;
                        }
                    }
                    else
                    {
                        if (!HasResistenceToHot(playerId))
                        {
                            bool needToContinue = true;
                            if (hasHot && playerStats.HotThermalFluid.Value > 0 && hotBottles.Any())
                            {
                                needToContinue = PlayerThermalFluidController.DoGetGasToCool(temperature - range.Z, armor, hotBottles, EquipmentConstants.HOTTHERMALREGULATORS_MODULES);
                            }
                            if (needToContinue)
                            {
                                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToHot.ToString(), 0, true);
                                if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToBoiling))
                                {
                                    LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToBoiling] = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToBoiling.ToString());
                                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToBoiling.ToString(), 0, true);
                                    AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToHot.ToString(), LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToBoiling]);
                                }
                                else if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.RecoveringFromExposure))
                                {
                                    if (LAST_TEMP_TIME.ContainsKey(StatsConstants.TemperatureEffects.ExposedToHot))
                                        AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToHot.ToString(), LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToHot]);
                                    else if (LAST_TEMP_TIME.ContainsKey(StatsConstants.TemperatureEffects.ExposedToBoiling))
                                        AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToHot.ToString(), LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToBoiling]);
                                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.RecoveringFromExposure.ToString(), 0, true);
                                }
                                if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToFreeze))
                                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToFreeze.ToString(), 0, true);
                                if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToCold))
                                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToCold.ToString(), 0, true);
                                needToRemove = false;
                            }
                        }
                    }
                }
                if (temperature < range.Y)
                {
                    if (temperature <= range.X)
                    {
                        bool needToContinue = true;
                        if (hasCold && playerStats.ColdThermalFluid.Value > 0 && coldBottles.Any())
                        {
                            needToContinue = PlayerThermalFluidController.DoGetGasToCool(range.X - temperature, armor, coldBottles, EquipmentConstants.COLDTHERMALREGULATORS_MODULES);
                        }
                        if (needToContinue)
                        {
                            AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToFreeze.ToString(), 0, true);
                            if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToCold))
                            {
                                LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToCold] = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToCold.ToString());
                                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToCold.ToString(), 0, true);
                                AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToFreeze.ToString(), LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToCold]);
                            }
                            else if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.RecoveringFromExposure))
                            {
                                if (LAST_TEMP_TIME.ContainsKey(StatsConstants.TemperatureEffects.ExposedToFreeze))
                                    AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToFreeze.ToString(), LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToFreeze]);
                                else if (LAST_TEMP_TIME.ContainsKey(StatsConstants.TemperatureEffects.ExposedToCold))
                                    AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToFreeze.ToString(), LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToCold]);
                                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.RecoveringFromExposure.ToString(), 0, true);
                            }
                            if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToBoiling))
                                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToBoiling.ToString(), 0, true);
                            if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToHot))
                                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToHot.ToString(), 0, true);
                            needToRemove = false;
                        }
                    }
                    else
                    {
                        if (!HasResistenceToCold(playerId))
                        {
                            bool needToContinue = true;
                            if (hasCold && playerStats.ColdThermalFluid.Value > 0 && coldBottles.Any())
                            {
                                needToContinue = PlayerThermalFluidController.DoGetGasToCool(range.Y - temperature, armor, coldBottles, EquipmentConstants.COLDTHERMALREGULATORS_MODULES);
                            }
                            if (needToContinue)
                            {
                                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToCold.ToString(), 0, true);
                                if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToFreeze))
                                {
                                    LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToFreeze] = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToFreeze.ToString());
                                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToFreeze.ToString(), 0, true);
                                    AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToCold.ToString(), LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToFreeze]);
                                }
                                else if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.RecoveringFromExposure))
                                {
                                    if (LAST_TEMP_TIME.ContainsKey(StatsConstants.TemperatureEffects.ExposedToCold))
                                        AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToCold.ToString(), LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToCold]);
                                    else if (LAST_TEMP_TIME.ContainsKey(StatsConstants.TemperatureEffects.ExposedToFreeze))
                                        AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToCold.ToString(), LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToFreeze]);
                                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.RecoveringFromExposure.ToString(), 0, true);
                                }
                                if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToBoiling))
                                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToBoiling.ToString(), 0, true);
                                if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToHot))
                                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToHot.ToString(), 0, true);
                                needToRemove = false;
                            }
                        }
                    }
                }
                if (needToRemove)
                {
                    if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToBoiling))
                    {
                        LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToBoiling] = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToBoiling.ToString());
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToBoiling.ToString(), 0, true);
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.RecoveringFromExposure.ToString(), 0, true);
                    }
                    if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToHot))
                    {
                        LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToHot] = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToHot.ToString());
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToHot.ToString(), 0, true);
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.RecoveringFromExposure.ToString(), 0, true);
                    }
                    if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToFreeze))
                    {
                        LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToFreeze] = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToFreeze.ToString());
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToFreeze.ToString(), 0, true);
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.RecoveringFromExposure.ToString(), 0, true);
                    }
                    if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToCold))
                    {
                        LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToCold] = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToCold.ToString());
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToCold.ToString(), 0, true);
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.RecoveringFromExposure.ToString(), 0, true);
                    }
                    if (!StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.RecoveringFromExposure))
                    {
                        LAST_TEMP_TIME.Clear();
                    }
                }
            }
            CheckTemperatureEffect(playerId, statsEasyAcess);
        }

    }

}
