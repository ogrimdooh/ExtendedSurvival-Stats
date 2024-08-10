using VRage.Game.ModAPI;

namespace ExtendedSurvival.Stats
{
    public static class PlayerWeatherController
    {

        public static WeatherConstants.WeatherInfo ProcessPlayerWeather(long playerId, IMyCharacter character)
        {
            var weatherInfo = WeatherConstants.GetWeatherInfo(character);
            var playerStats = PlayerActionsController.GetStatsEasyAcess(playerId);

            if (character.Parent == null && weatherInfo.CurrentEnvironmentType == WeatherConstants.EnvironmentDetector.Atmosphere)
            {
                switch (weatherInfo.WeatherEffect)
                {
                    case WeatherConstants.WeatherEffects.Rain:
                    case WeatherConstants.WeatherEffects.Thunderstorm:
                        IncriseWetTimer(playerId, playerStats, weatherInfo.WeatherEffect, weatherInfo.WeatherLevel, weatherInfo.WeatherIntensity);
                        break;
                }
            }
            else if (character.Parent == null && weatherInfo.CurrentEnvironmentType == WeatherConstants.EnvironmentDetector.Underwater)
            {
                IncriseUnderwaterWetTimer(playerId, playerStats);
            }

            return weatherInfo;
        }

        private static void IncriseUnderwaterWetTimer(long playerId, PlayerStatsEasyAcess playerStats)
        {
            if (!StatsConstants.IsFlagSet(playerStats.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.Wet))
                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.Wet.ToString(), 0, true);
            else
                AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.Wet.ToString(), StatsConstants.TEMPERATURE_EFFECTS[StatsConstants.TemperatureEffects.Wet].TimeToSelfRemove);
        }

        private static void IncriseWetTimer(long playerId, PlayerStatsEasyAcess playerStats, WeatherConstants.WeatherEffects effect, WeatherConstants.WeatherEffectsLevel level, float intensity)
        {
            if (!StatsConstants.IsFlagSet(playerStats.CurrentTemperatureEffects, StatsConstants.TemperatureEffects.Wet))
                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.Wet.ToString(), 0, true);
            else
                AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, StatsConstants.TemperatureEffects.Wet.ToString(), StatsConstants.TEMPERATURE_EFFECTS[StatsConstants.TemperatureEffects.Wet].TimeToSelfRemove);
        }

    }

}
