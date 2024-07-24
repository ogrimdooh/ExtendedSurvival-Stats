namespace ExtendedSurvival.Stats
{
    public static class PlayerDiseaseController
    {

        private static float ChanceToGetDisease(long playerId, PlayerStatsEasyAcess statsEasyAcess, StatsConstants.DiseaseEffects disease)
        {
            float baseValue = 0;
            switch (disease)
            {
                case StatsConstants.DiseaseEffects.Flu:
                    // Temperature Effects
                    if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.Cold))
                    {
                        baseValue += ExtendedSurvivalSettings.Instance.DiseaseSettings.Flu.GetBaseChance();
                    }
                    else if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.Frosty))
                    {
                        baseValue += ExtendedSurvivalSettings.Instance.DiseaseSettings.Flu.GetExtremeChance();
                    }
                    if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.Wet))
                    {
                        baseValue *= ExtendedSurvivalSettings.Instance.DiseaseSettings.Flu.GetWetInfluence();
                    }
                    break;
                case StatsConstants.DiseaseEffects.Pneumonia:
                    // Temperature Effects
                    if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Flu))
                    {
                        if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.Cold))
                        {
                            baseValue += ExtendedSurvivalSettings.Instance.DiseaseSettings.Pneumonia.GetBaseChance();
                        }
                        else if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.Frosty))
                        {
                            baseValue += ExtendedSurvivalSettings.Instance.DiseaseSettings.Pneumonia.GetExtremeChance();
                        }
                    }
                    if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.Wet))
                    {
                        baseValue *= ExtendedSurvivalSettings.Instance.DiseaseSettings.Pneumonia.GetWetInfluence();
                    }
                    break;
                case StatsConstants.DiseaseEffects.Hypothermia:
                    if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.Frosty))
                    {
                        var exposedToCold = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToCold.ToString());
                        var exposedToFreeze = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToFreeze.ToString());
                        if (exposedToCold > 0)
                            baseValue += ExtendedSurvivalSettings.Instance.DiseaseSettings.Hypothermia.GetBaseChance();
                        if (exposedToFreeze > 0)
                            baseValue += ExtendedSurvivalSettings.Instance.DiseaseSettings.Hypothermia.GetExtremeChance();
                        if (baseValue > 0)
                        {
                            if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Rickets))
                                baseValue *= ExtendedSurvivalSettings.Instance.DiseaseSettings.Hypothermia.GetRicketsInfluence();
                            else if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentDiseaseEffects, StatsConstants.DiseaseEffects.SevereRickets))
                                baseValue *= ExtendedSurvivalSettings.Instance.DiseaseSettings.Hypothermia.GetSevereRicketsInfluence();
                            if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.Wet))
                                baseValue *= ExtendedSurvivalSettings.Instance.DiseaseSettings.Hypothermia.GetWetInfluence();
                            if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Obesity))
                                baseValue /= ExtendedSurvivalSettings.Instance.DiseaseSettings.Hypothermia.GetObesityInfluence();
                            else if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentDiseaseEffects, StatsConstants.DiseaseEffects.SevereObesity))
                                baseValue /= ExtendedSurvivalSettings.Instance.DiseaseSettings.Hypothermia.GetSevereObesityInfluence();
                            var hypothermiaStack = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatStack(playerId, StatsConstants.DiseaseEffects.Hypothermia.ToString());
                            if (hypothermiaStack > 0)
                                baseValue /= hypothermiaStack + 1;
                        }
                    }
                    break;
                case StatsConstants.DiseaseEffects.Hyperthermia:
                    if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.OnFire))
                    {
                        var exposedToHot = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToHot.ToString());
                        var exposedToBoiling = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.ExposedToBoiling.ToString());
                        if (exposedToHot > 0)
                            baseValue += ExtendedSurvivalSettings.Instance.DiseaseSettings.Hyperthermia.GetBaseChance();
                        if (exposedToBoiling > 0)
                            baseValue += ExtendedSurvivalSettings.Instance.DiseaseSettings.Hyperthermia.GetExtremeChance();
                        if (baseValue > 0)
                        {
                            if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Obesity))
                                baseValue *= ExtendedSurvivalSettings.Instance.DiseaseSettings.Hyperthermia.GetObesityInfluence();
                            else if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentDiseaseEffects, StatsConstants.DiseaseEffects.SevereObesity))
                                baseValue *= ExtendedSurvivalSettings.Instance.DiseaseSettings.Hyperthermia.GetSevereObesityInfluence();
                            if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.Wet))
                                baseValue /= ExtendedSurvivalSettings.Instance.DiseaseSettings.Hyperthermia.GetWetInfluence();
                            if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Rickets))
                                baseValue /= ExtendedSurvivalSettings.Instance.DiseaseSettings.Hyperthermia.GetRicketsInfluence();
                            else if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentDiseaseEffects, StatsConstants.DiseaseEffects.SevereRickets))
                                baseValue /= ExtendedSurvivalSettings.Instance.DiseaseSettings.Hyperthermia.GetSevereRicketsInfluence();
                            var hyperthermiaStack = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatStack(playerId, StatsConstants.DiseaseEffects.Hyperthermia.ToString());
                            if (hyperthermiaStack > 0)
                                baseValue /= hyperthermiaStack + 1;
                        }
                    }
                    break;
            }
            return baseValue;
        }

        public static void CheckIfGetDiseases(long playerId)
        {
            var statsEasyAcess = PlayerActionsController.GetStatsEasyAcess(playerId);
            float chance = ChanceToGetDisease(playerId, statsEasyAcess, StatsConstants.DiseaseEffects.Flu);
            if (chance > 0)
            {
                if (PlayerActionsController.CheckChance(chance))
                {
                    AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DiseaseEffects.Flu.ToString(), 0, true);
                }
            }
            chance = ChanceToGetDisease(playerId, statsEasyAcess, StatsConstants.DiseaseEffects.Pneumonia);
            if (chance > 0)
            {
                if (PlayerActionsController.CheckChance(chance))
                {
                    AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DiseaseEffects.Pneumonia.ToString(), 0, true);
                }
            }
            chance = ChanceToGetDisease(playerId, statsEasyAcess, StatsConstants.DiseaseEffects.Hypothermia);
            if (chance > 0)
            {
                if (PlayerActionsController.CheckChance(chance))
                {
                    AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DiseaseEffects.Hypothermia.ToString(), 1, true);
                }
            }
            chance = ChanceToGetDisease(playerId, statsEasyAcess, StatsConstants.DiseaseEffects.Hyperthermia);
            if (chance > 0)
            {
                if (PlayerActionsController.CheckChance(chance))
                {
                    AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DiseaseEffects.Hyperthermia.ToString(), 1, true);
                }
            }
            CheckStarvation(playerId, statsEasyAcess);
            CheckDehydration(playerId, statsEasyAcess);
            if (ExtendedSurvivalSettings.Instance.DiseaseSettings.WeightDiseaseEnabled)
            {
                CheckWeight(playerId, statsEasyAcess);
            }
        }

        private static void CheckStarvation(long playerId, PlayerStatsEasyAcess statsEasyAcess)
        {
            var percent = statsEasyAcess.BodyEnergy.Value / statsEasyAcess.BodyEnergy.MaxValue;
            var needToCheckStarvation = true;
            if (!StatsConstants.IsFlagSet(statsEasyAcess.CurrentDiseaseEffects, StatsConstants.DiseaseEffects.SevereStarvation))
            {
                if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Starvation))
                {
                    if (percent <= 0.05f)
                    {
                        needToCheckStarvation = false;
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Starvation.ToString(), 0, true);
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereStarvation.ToString(), 0, true);
                    }
                }
            }
            else
            {
                needToCheckStarvation = false;
                if (percent > 0.05f)
                {
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereStarvation.ToString(), 0, true);
                    needToCheckStarvation = true;
                }
            }
            if (needToCheckStarvation)
            {
                if (!StatsConstants.IsFlagSet(statsEasyAcess.CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Starvation))
                {
                    if (percent <= 0.25f)
                    {
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DiseaseEffects.Starvation.ToString(), 0, true);
                    }
                }
                else
                {
                    if (percent > 0.25f)
                    {
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Starvation.ToString(), 0, true);
                    }
                }
            }
        }

        private static void CheckWeight(long playerId, PlayerStatsEasyAcess statsEasyAcess)
        {
            var height = 1.8f;
            var bmi = statsEasyAcess.BodyWeight.Value / (height * height);
            if (bmi >= 40)
            {
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Obesity.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereObesity.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Rickets.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereRickets.ToString(), 0, true);
            }
            else if (bmi >= 30)
            {
                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DiseaseEffects.Obesity.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereObesity.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Rickets.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereRickets.ToString(), 0, true);
            }
            else if (bmi <= 17)
            {
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Obesity.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereObesity.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DiseaseEffects.Rickets.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereRickets.ToString(), 0, true);
            }
            else if (bmi <= 14)
            {
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Obesity.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereObesity.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Rickets.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereRickets.ToString(), 0, true);
            }
            else
            {
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Obesity.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereObesity.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Rickets.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereRickets.ToString(), 0, true);
            }
        }

        private static void CheckDehydration(long playerId, PlayerStatsEasyAcess statsEasyAcess)
        {
            var percent = statsEasyAcess.BodyWater.Value / statsEasyAcess.BodyWater.MaxValue;
            var needToCheckDehydration = true;
            if (!StatsConstants.IsFlagSet(statsEasyAcess.CurrentDiseaseEffects, StatsConstants.DiseaseEffects.SevereDehydration))
            {
                if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Dehydration))
                {
                    if (percent <= 0.05f)
                    {
                        needToCheckDehydration = false;
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Dehydration.ToString(), 0, true);
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereDehydration.ToString(), 0, true);
                    }
                }
            }
            else
            {
                needToCheckDehydration = false;
                if (percent > 0.05f)
                {
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereDehydration.ToString(), 0, true);
                    needToCheckDehydration = true;
                }
            }
            if (needToCheckDehydration)
            {
                if (!StatsConstants.IsFlagSet(statsEasyAcess.CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Dehydration))
                {
                    if (percent <= 0.25f)
                    {
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DiseaseEffects.Dehydration.ToString(), 0, true);
                    }
                }
                else
                {
                    if (percent > 0.25f)
                    {
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Dehydration.ToString(), 0, true);
                    }
                }
            }
        }

    }

}
