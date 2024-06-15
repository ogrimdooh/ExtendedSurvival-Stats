namespace ExtendedSurvival.Stats
{
    public static class PlayerFatigueController
    {

        public static void CheckFatigue(long playerId, PlayerStatsEasyAcess statsEasyAcess)
        {
            var percent = statsEasyAcess.Fatigue.Value / statsEasyAcess.Fatigue.MaxValue;
            var needToCheckStarvation = true;
            if (!StatsConstants.IsFlagSet(statsEasyAcess.CurrentSurvivalEffects, StatsConstants.SurvivalEffects.ExtremelyTired))
            {
                if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentSurvivalEffects, StatsConstants.SurvivalEffects.Tired))
                {
                    if (percent >= 0.8f)
                    {
                        needToCheckStarvation = false;
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Tired.ToString(), 0, true);
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.ExtremelyTired.ToString(), 0, true);
                    }
                }
            }
            else
            {
                needToCheckStarvation = false;
                if (percent < 0.8f)
                {
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.ExtremelyTired.ToString(), 0, true);
                    needToCheckStarvation = true;
                }
            }
            if (needToCheckStarvation)
            {
                if (!StatsConstants.IsFlagSet(statsEasyAcess.CurrentSurvivalEffects, StatsConstants.SurvivalEffects.Tired))
                {
                    if (percent >= 0.6f)
                    {
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.Tired.ToString(), 0, true);
                    }
                }
                else
                {
                    if (percent < 0.6f)
                    {
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Tired.ToString(), 0, true);
                    }
                }
            }
        }

    }

}
