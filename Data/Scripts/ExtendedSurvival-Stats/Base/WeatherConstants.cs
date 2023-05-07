using Sandbox.Game.Entities.Character.Components;
using Sandbox.ModAPI;
using System;
using System.Collections.Concurrent;
using VRage.Game;
using VRage.Game.ModAPI;
using VRage.ModAPI;
using VRageMath;

namespace ExtendedSurvival.Stats
{

    public static class WeatherConstants
    {

        public const float SPACE_TEMPERATURE = -270;
        public const float PRESURIZED_TEMPERATURE = 25;

        public static MyTemperatureLevel TemperatureToLevel(float temperature)
        {
            if (temperature <= 0)
                return MyTemperatureLevel.ExtremeFreeze;
            if (temperature <= 10)
                return MyTemperatureLevel.Freeze;
            if (temperature <= 35)
                return MyTemperatureLevel.Cozy;
            return temperature <= 55 ? MyTemperatureLevel.Hot : MyTemperatureLevel.ExtremeHot;
        }

        public enum WeatherEffectsLevel
        {

            Light = 0,
            Heavy = 1

        }

        public enum WeatherEffects
        {

            None = 0,
            Rain = 1,
            Thunderstorm = 2

        }

        public enum EnvironmentDetector
        {

            None = 0,
            Atmosphere = 1,
            ShipOrStation = 2,
            Space = 3,
            Underwater = 4

        }

        public class WeatherInfo
        {

            public float WeatherIntensity { get; set; }
            public WeatherEffectsLevel WeatherLevel { get; set; }
            public WeatherEffects WeatherEffect { get; set; }
            public EnvironmentDetector CurrentEnvironmentType { get; set; }
            public Vector2 CurrentTemperature { get; set; } = new Vector2(0, 0);

        }

        private static ConcurrentDictionary<long, WeatherInfo> weatherInfo = new ConcurrentDictionary<long, WeatherInfo>();

        public static WeatherInfo GetWeatherInfo(IMyCharacter entity)
        {
            if (!weatherInfo.ContainsKey(entity.EntityId))
                RefreshWeatherInfo(entity);
            return weatherInfo[entity.EntityId];
        }

        public static void RefreshWeatherInfo(IMyCharacter entity)
        {
            if (!weatherInfo.ContainsKey(entity.EntityId))
                weatherInfo[entity.EntityId] = new WeatherInfo();
            var playerPos = entity.GetPosition();
            var weather = MyAPIGateway.Session.WeatherEffects.GetWeather(playerPos);
            weatherInfo[entity.EntityId].WeatherIntensity = MyAPIGateway.Session.WeatherEffects.GetWeatherIntensity(playerPos);
            weatherInfo[entity.EntityId].WeatherLevel = weather.Contains("Heavy") ? WeatherEffectsLevel.Heavy : WeatherEffectsLevel.Light;
            if (weather.Contains("Rain"))
                weatherInfo[entity.EntityId].WeatherEffect = WeatherEffects.Rain;
            else if (weather.Contains("Thunderstorm"))
                weatherInfo[entity.EntityId].WeatherEffect = WeatherEffects.Thunderstorm;
            else
                weatherInfo[entity.EntityId].WeatherEffect = WeatherEffects.None;
            var platAtRange = GetPlanetAtRange(playerPos);
            weatherInfo[entity.EntityId].CurrentEnvironmentType = GetEnvironmentType(entity, playerPos, platAtRange);
            switch (weatherInfo[entity.EntityId].CurrentEnvironmentType)
            {
                case EnvironmentDetector.Atmosphere:
                case EnvironmentDetector.Underwater:
                    if (ExtendedSurvivalCoreAPI.Registered)
                        weatherInfo[entity.EntityId].CurrentTemperature = ExtendedSurvivalCoreAPI.GetTemperatureInPoint(platAtRange.EntityId, playerPos).Value;
                    else
                        weatherInfo[entity.EntityId].CurrentTemperature = new Vector2(0, SPACE_TEMPERATURE);
                    break;
                case EnvironmentDetector.ShipOrStation:
                    weatherInfo[entity.EntityId].CurrentTemperature = new Vector2(0.5f, PRESURIZED_TEMPERATURE);
                    break;
                case EnvironmentDetector.None:
                case EnvironmentDetector.Space:
                default:
                    weatherInfo[entity.EntityId].CurrentTemperature = new Vector2(0, SPACE_TEMPERATURE);
                    break;
            }
        }

        private static PlanetInfo GetPlanetAtRange(Vector3D pos)
        {
            if (ExtendedSurvivalCoreAPI.Registered)
                return ExtendedSurvivalCoreAPI.GetPlanetAtRange(pos);
            return null;
        }

        private static EnvironmentDetector GetEnvironmentType(IMyCharacter entity, Vector3D pos, PlanetInfo platAtRange)
        {
            WeatherConstants.EnvironmentDetector currentValue;
            entity?.Components?.Get<MyCharacterOxygenComponent>()?.UpdateBeforeSimulation100();
            var externalO2 = Math.Round(entity.EnvironmentOxygenLevel * 100, 0);
            if (entity.Physics == null || (entity.Physics != null && entity.Physics.Gravity.LengthSquared() > 0f))
            {
                if (platAtRange != null && platAtRange.Entity.HasAtmosphere && platAtRange.Entity.GetAirDensity(pos) > 0f)
                    currentValue = EnvironmentDetector.Atmosphere;
                else
                    currentValue = EnvironmentDetector.Space;
            }
            else
                currentValue = EnvironmentDetector.Space;
            double o2AtPos = 0;
            if (currentValue == EnvironmentDetector.Atmosphere)
            {
                if (WaterModAPI.Registered && platAtRange.HasWater && WaterModAPI.IsUnderwater(pos) && (WaterModAPI.GetDepth(pos).Value * -1) > 1.5f)
                    return EnvironmentDetector.Underwater;
                o2AtPos = Math.Round(platAtRange.Entity.GetOxygenForPosition(pos) * 100, 0);
            }
            if (Math.Abs(o2AtPos < externalO2 ? o2AtPos - externalO2 : externalO2 - o2AtPos) > 1f)
                return EnvironmentDetector.ShipOrStation;
            else
                return currentValue;
        }

    }

}