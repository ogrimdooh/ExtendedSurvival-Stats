namespace ExtendedSurvival.Stats
{
    public static class PlayerWoundedController
    {

        public static void IncDecWoundedTimer(long playerId, long timePassed, PlayerStatsEasyAcess statsEasyAcess)
        {
            if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentDamageEffects, StatsConstants.DamageEffects.Wounded) ||
                StatsConstants.IsFlagSet(statsEasyAcess.CurrentDamageEffects, StatsConstants.DamageEffects.DeepWounded) ||
                StatsConstants.IsFlagSet(statsEasyAcess.CurrentDamageEffects, StatsConstants.DamageEffects.BrokenBones))
            {
                if (statsEasyAcess.WoundedTime.Value < statsEasyAcess.WoundedTime.MaxValue)
                {
                    var finalValue = (float)timePassed;
                    var maxDamageEffect = (StatsConstants.DamageEffects)StatsConstants.GetMaxSetFlagValue(statsEasyAcess.CurrentDamageEffects);
                    statsEasyAcess.WoundedTime.Increase(finalValue * StatsConstants.TIME_MULTIPLIER_FACTOR[maxDamageEffect], null);
                }
            }
            else
            {
                statsEasyAcess.WoundedTime.Value = 0;
            }
            CheckWoundedEffect(playerId, statsEasyAcess);
        }


        private static void CheckWoundedEffect(long playerId, PlayerStatsEasyAcess statsEasyAcess)
        {
            if (statsEasyAcess.WoundedTime.Value >= statsEasyAcess.WoundedTime.MaxValue)
            {
                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DiseaseEffects.Infected.ToString(), 1, false);
                statsEasyAcess.WoundedTime.Value = 0;
            }
        }

    }

}
