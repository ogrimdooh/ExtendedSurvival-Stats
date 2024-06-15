using VRage.Game.ModAPI;

namespace ExtendedSurvival.Stats
{
    public static class PlayerWeatherController
    {

        public static WeatherConstants.WeatherInfo ProcessPlayerWeather(long playerId, IMyCharacter character)
        {
            var weatherInfo = WeatherConstants.GetWeatherInfo(character);

            if (character.Parent == null && weatherInfo.CurrentEnvironmentType == WeatherConstants.EnvironmentDetector.Atmosphere)
            {
                switch (weatherInfo.WeatherEffect)
                {
                    case WeatherConstants.WeatherEffects.Rain:
                    case WeatherConstants.WeatherEffects.Thunderstorm:
                        IncriseWetTimer(playerId, weatherInfo.WeatherEffect, weatherInfo.WeatherLevel, weatherInfo.WeatherIntensity);
                        break;
                }
            }
            else if (character.Parent == null && weatherInfo.CurrentEnvironmentType == WeatherConstants.EnvironmentDetector.Underwater)
            {
                IncriseUnderwaterWetTimer(playerId);
            }

            return weatherInfo;
        }

        private static void IncriseUnderwaterWetTimer(long playerId)
        {
            AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.Wet.ToString(), 0, true);
        }

        private static void IncriseWetTimer(long playerId, WeatherConstants.WeatherEffects effect, WeatherConstants.WeatherEffectsLevel level, float intensity)
        {
            AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.Wet.ToString(), 0, true);
        }

    }

}
