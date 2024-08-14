using System;
using System.Collections.Concurrent;
using System.Linq;
using VRage.Game.ModAPI;
using VRageMath;

namespace ExtendedSurvival.Stats
{
    public static class PlayerExpositionController
    {

        private static void CheckExpositionEffect(long playerId, PlayerStatsEasyAcess statsEasyAcess)
        {
            if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToToxicity))
            {
                var exposedToToxicity = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToToxicity.ToString());
                if (exposedToToxicity >= StatsConstants.TEMPERATURE_EFFECTS[StatsConstants.TemperatureEffects.ExposedToToxicity].MaxInverseTime)
                {
                    AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.Intoxicated.ToString(), 0, true);
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.VeryIntoxicated.ToString(), 0, true);
                }
            }
            if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToExtremeToxicity))
            {
                var exposedToExtremeToxicity = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToExtremeToxicity.ToString());
                if (exposedToExtremeToxicity >= StatsConstants.TEMPERATURE_EFFECTS[StatsConstants.TemperatureEffects.ExposedToExtremeToxicity].MaxInverseTime)
                {
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.Intoxicated.ToString(), 0, true);
                    AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.VeryIntoxicated.ToString(), 0, true);
                }
            }
            if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToRadioactivity))
            {
                var exposedToRadioactivity = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToRadioactivity.ToString());
                if (exposedToRadioactivity >= StatsConstants.TEMPERATURE_EFFECTS[StatsConstants.TemperatureEffects.ExposedToRadioactivity].MaxInverseTime)
                {
                    AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.RadiationSick.ToString(), 0, true);
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.RadiationPoisoning.ToString(), 0, true);
                }
            }
            if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToExtremeRadioactivity))
            {
                var exposedToExtremeRadioactivity = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToExtremeRadioactivity.ToString());
                if (exposedToExtremeRadioactivity >= StatsConstants.TEMPERATURE_EFFECTS[StatsConstants.TemperatureEffects.ExposedToExtremeRadioactivity].MaxInverseTime)
                {
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.RadiationSick.ToString(), 0, true);
                    AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.RadiationPoisoning.ToString(), 0, true);
                }
            }
        }

        public static bool HasResistenceToRadioactivity(long playerId, out int level)
        {
            level = 0;
            var statsEasyAcess = PlayerActionsController.GetStatsEasyAcess(playerId);
            foreach (var stat in StatsConstants.RADIOACTIVITY_RESISTENCES)
            {
                if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, stat))
                {
                    level = Array.IndexOf(StatsConstants.RADIOACTIVITY_RESISTENCES, stat);
                    return true;
                }
            }
            return false;
        }

        public static bool HasResistenceToToxicity(long playerId, out int level)
        {
            level = 0;
            var statsEasyAcess = PlayerActionsController.GetStatsEasyAcess(playerId);
            foreach (var stat in StatsConstants.TOXICITY_RESISTENCES)
            {
                if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, stat))
                {
                    level = Array.IndexOf(StatsConstants.TOXICITY_RESISTENCES, stat);
                    return true;
                }
            }
            return false;
        }

        public static Vector4 GetToxicityExpositionRange(long playerId)
        {
            var baseRange = new Vector4(EXPOSITION_RANGE.X, EXPOSITION_RANGE.Y, EXPOSITION_HARD_RANGE.X, EXPOSITION_HARD_RANGE.Y);
            var armorInfo = PlayerArmorController.GetEquipedArmor(playerId, useCache: true);
            if (armorInfo != null && armorInfo.HasArmor)
            {
                baseRange = new Vector4(
                    baseRange.X + armorInfo.GetResistence(ArmorSystemConstants.DamageType.Toxicity),
                    baseRange.Y,
                    baseRange.Z,
                    baseRange.W
                );
            }
            return baseRange;
        }

        public static Vector4 GetRadioactivityExpositionRange(long playerId)
        {
            var baseRange = new Vector4(EXPOSITION_RANGE.X, EXPOSITION_RANGE.Y, EXPOSITION_HARD_RANGE.X, EXPOSITION_HARD_RANGE.Y);
            var armorInfo = PlayerArmorController.GetEquipedArmor(playerId, useCache: true);
            if (armorInfo != null && armorInfo.HasArmor)
            {
                baseRange = new Vector4(
                    baseRange.X + armorInfo.GetResistence(ArmorSystemConstants.DamageType.Radioactivity),
                    baseRange.Y,
                    baseRange.Z,
                    baseRange.W
                );
            }
            return baseRange;
        }
        
        public static readonly Vector2 EXPOSITION_RANGE = new Vector2(0.0f, 0.25f);
        public static readonly Vector2 EXPOSITION_HARD_RANGE = new Vector2(0.5f, 1.0f);
        public static readonly ConcurrentDictionary<StatsConstants.TemperatureEffects, long> LAST_TEMP_TIME = new ConcurrentDictionary<StatsConstants.TemperatureEffects, long>();

        public static void IncDevExpositionTimer(PlayerStatsEasyAcess playerStats, long playerId, long timePassed, WeatherConstants.WeatherInfo weatherInfo, PlayerArmorController.PlayerEquipInfo armor)
        {
            var statsEasyAcess = PlayerActionsController.GetStatsEasyAcess(playerId);
            if (playerStats != null)
            {
                IMyInventoryItem[] ToxicityBottles;
                IMyInventoryItem[] RadioactivityBottles;
                bool hasToxicity;
                bool hasRadioactivity;
                PlayerExpositionFilterController.UpdateFluidStats(playerStats, armor, playerId, out hasToxicity, out hasRadioactivity, out ToxicityBottles, out RadioactivityBottles);
                var needToRemoveToxic = true;
                var needToRemoveRadiation = true;
                var ToxicExposition = weatherInfo.ToxicLevel;
                var rangeToxic = GetToxicityExpositionRange(playerId);
                var RadiationExposition = weatherInfo.RadiationLevel;
                var rangeRadiation = GetRadioactivityExpositionRange(playerId);
                if (ToxicExposition > rangeToxic.X)
                {
                    if (ToxicExposition >= rangeToxic.Z)
                    {
                        int level = 0;
                        if (!HasResistenceToToxicity(playerId, out level) || 
                            (ToxicExposition >= rangeToxic.Z && level < 2) || 
                            (ToxicExposition >= rangeToxic.Y && ToxicExposition < rangeToxic.Z && level < 1))
                        {
                            bool needToContinue = true;
                            if (hasToxicity && ToxicityBottles.Any())
                            {
                                needToContinue = PlayerExpositionFilterController.DoFillGasToCool(ToxicExposition, armor, ToxicityBottles, EquipmentConstants.TOXICITYFILTER_MODULES);
                            }
                            if (needToContinue)
                            {
                                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToExtremeToxicity.ToString(), 0, true);
                                if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToToxicity))
                                {
                                    LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToToxicity] = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToToxicity.ToString());
                                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToToxicity.ToString(), 0, true);
                                    AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToExtremeToxicity.ToString(), LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToToxicity]);
                                }
                                else if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.RecoveringFromExposure))
                                {
                                    if (LAST_TEMP_TIME.ContainsKey(StatsConstants.TemperatureEffects.ExposedToExtremeToxicity))
                                        AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToExtremeToxicity.ToString(), LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToExtremeToxicity]);
                                    else if (LAST_TEMP_TIME.ContainsKey(StatsConstants.TemperatureEffects.ExposedToToxicity))
                                        AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToExtremeToxicity.ToString(), LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToToxicity]);
                                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.RecoveringFromExposure.ToString(), 0, true);
                                }
                                needToRemoveToxic = false;
                            }
                        }
                    }
                    else
                    {
                        int level = 0;
                        if (!HasResistenceToToxicity(playerId, out level) ||
                            (ToxicExposition >= rangeToxic.Y && level < 1))
                        {
                            bool needToContinue = true;
                            if (hasToxicity && ToxicityBottles.Any())
                            {
                                needToContinue = PlayerExpositionFilterController.DoFillGasToCool(ToxicExposition, armor, ToxicityBottles, EquipmentConstants.TOXICITYFILTER_MODULES);
                            }
                            if (needToContinue)
                            {
                                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToToxicity.ToString(), 0, true);
                                if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToExtremeToxicity))
                                {
                                    LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToExtremeToxicity] = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToExtremeToxicity.ToString());
                                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToExtremeToxicity.ToString(), 0, true);
                                    AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToToxicity.ToString(), LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToExtremeToxicity]);
                                }
                                else if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.RecoveringFromExposure))
                                {
                                    if (LAST_TEMP_TIME.ContainsKey(StatsConstants.TemperatureEffects.ExposedToToxicity))
                                        AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToToxicity.ToString(), LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToToxicity]);
                                    else if (LAST_TEMP_TIME.ContainsKey(StatsConstants.TemperatureEffects.ExposedToExtremeToxicity))
                                        AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToToxicity.ToString(), LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToExtremeToxicity]);
                                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.RecoveringFromExposure.ToString(), 0, true);
                                }
                                needToRemoveToxic = false;
                            }
                        }
                    }
                }
                if (RadiationExposition > rangeRadiation.X)
                {
                    if (RadiationExposition >= rangeRadiation.Z)
                    {
                        int level = 0;
                        if (!HasResistenceToRadioactivity(playerId, out level) ||
                            (RadiationExposition >= rangeRadiation.Z && level < 2) ||
                            (RadiationExposition >= rangeRadiation.Y && RadiationExposition < rangeRadiation.Z && level < 1))
                        {
                            bool needToContinue = true;
                            if (hasRadioactivity && RadioactivityBottles.Any())
                            {
                                needToContinue = PlayerExpositionFilterController.DoFillGasToCool(RadiationExposition, armor, RadioactivityBottles, EquipmentConstants.RADIOACTIVITYFILTER_MODULES);
                            }
                            if (needToContinue)
                            {
                                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToExtremeRadioactivity.ToString(), 0, true);
                                if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToRadioactivity))
                                {
                                    LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToRadioactivity] = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToRadioactivity.ToString());
                                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToRadioactivity.ToString(), 0, true);
                                    AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToExtremeRadioactivity.ToString(), LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToRadioactivity]);
                                }
                                else if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.RecoveringFromExposure))
                                {
                                    if (LAST_TEMP_TIME.ContainsKey(StatsConstants.TemperatureEffects.ExposedToExtremeRadioactivity))
                                        AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToExtremeRadioactivity.ToString(), LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToExtremeRadioactivity]);
                                    else if (LAST_TEMP_TIME.ContainsKey(StatsConstants.TemperatureEffects.ExposedToRadioactivity))
                                        AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToExtremeRadioactivity.ToString(), LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToRadioactivity]);
                                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.RecoveringFromExposure.ToString(), 0, true);
                                }
                            }
                            needToRemoveRadiation = false;
                        }
                    }
                    else
                    {
                        int level = 0;
                        if (!HasResistenceToRadioactivity(playerId, out level) ||
                            (RadiationExposition >= rangeRadiation.Y && level < 1))
                        {
                            bool needToContinue = true;
                            if (hasRadioactivity && RadioactivityBottles.Any())
                            {
                                needToContinue = PlayerExpositionFilterController.DoFillGasToCool(RadiationExposition, armor, RadioactivityBottles, EquipmentConstants.RADIOACTIVITYFILTER_MODULES);
                            }
                            if (needToContinue)
                            {
                                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToRadioactivity.ToString(), 0, true);
                                if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToExtremeRadioactivity))
                                {
                                    LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToExtremeRadioactivity] = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToExtremeRadioactivity.ToString());
                                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToExtremeRadioactivity.ToString(), 0, true);
                                    AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToRadioactivity.ToString(), LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToExtremeRadioactivity]);
                                }
                                else if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.RecoveringFromExposure))
                                {
                                    if (LAST_TEMP_TIME.ContainsKey(StatsConstants.TemperatureEffects.ExposedToRadioactivity))
                                        AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToRadioactivity.ToString(), LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToRadioactivity]);
                                    else if (LAST_TEMP_TIME.ContainsKey(StatsConstants.TemperatureEffects.ExposedToExtremeRadioactivity))
                                        AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToRadioactivity.ToString(), LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToExtremeRadioactivity]);
                                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.RecoveringFromExposure.ToString(), 0, true);
                                }
                                needToRemoveRadiation = false;
                            }
                        }
                    }
                }
                if (needToRemoveRadiation)
                {
                    if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToExtremeRadioactivity))
                    {
                        LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToExtremeRadioactivity] = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToExtremeRadioactivity.ToString());
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToExtremeRadioactivity.ToString(), 0, true);
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.RecoveringFromExposure.ToString(), 0, true);
                    }
                    if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToRadioactivity))
                    {
                        LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToRadioactivity] = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToRadioactivity.ToString());
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToRadioactivity.ToString(), 0, true);
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.RecoveringFromExposure.ToString(), 0, true);
                    }
                }
                if (needToRemoveToxic)
                {
                    if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToExtremeToxicity))
                    {
                        LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToExtremeToxicity] = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToExtremeToxicity.ToString());
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToExtremeToxicity.ToString(), 0, true);
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.RecoveringFromExposure.ToString(), 0, true);
                    }
                    if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.ExposedToToxicity))
                    {
                        LAST_TEMP_TIME[StatsConstants.TemperatureEffects.ExposedToToxicity] = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToToxicity.ToString());
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.ExposedToToxicity.ToString(), 0, true);
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.RecoveringFromExposure.ToString(), 0, true);
                    }
                }
                if (needToRemoveRadiation || needToRemoveToxic)
                {
                    if (!StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.RecoveringFromExposure))
                    {
                        LAST_TEMP_TIME.Clear();
                    }
                }
            }
            CheckExpositionEffect(playerId, statsEasyAcess);
        }

    }

}
