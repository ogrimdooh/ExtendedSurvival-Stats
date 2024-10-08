﻿using Sandbox.Definitions;
using Sandbox.Game.Entities;
using Sandbox.Game.Entities.Blocks;
using Sandbox.Game.Entities.Character;
using Sandbox.Game.Entities.Character.Components;
using Sandbox.Game.EntityComponents;
using Sandbox.Game.GameSystems;
using Sandbox.ModAPI;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRage.Game;
using VRage.Game.Entity;
using VRage.Game.ModAPI;
using VRage.ModAPI;
using VRageMath;

namespace ExtendedSurvival.Stats
{

    public static class WeatherConstants
    {

        public static WeatherInfo CurrentWeatherInfo { get; set; } = new WeatherInfo();

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
            Underwater = 4,
            NotPressurizedRoom = 5,
            NotPressurizedRoomInSpace = 6

        }

        public class WeatherInfo
        {

            public float WeatherIntensity { get; set; }
            public WeatherEffectsLevel WeatherLevel { get; set; }
            public WeatherEffects WeatherEffect { get; set; }
            public EnvironmentDetector CurrentEnvironmentType { get; set; }
            public Vector2 CurrentTemperature { get; set; } = new Vector2(0, 0);
            public Vector2 ExternalTemperature { get; set; } = new Vector2(0, 0);
            public float ToxicLevel { get; set; }
            public float RadiationLevel { get; set; }
            
            public Dictionary<string, string> GetData()
            {
                return new Dictionary<string, string>()
                {
                    { "WeatherIntensity", WeatherIntensity.ToString() },
                    { "WeatherLevel", ((int)WeatherLevel).ToString() },
                    { "WeatherEffect", ((int)WeatherEffect).ToString() },
                    { "CurrentEnvironmentType", ((int)CurrentEnvironmentType).ToString() },
                    { "CurrentTemperature", $"{CurrentTemperature.X}:{CurrentTemperature.Y}" },
                    { "ExternalTemperature", $"{ExternalTemperature.X}:{ExternalTemperature.Y}" },
                    { "ToxicLevel", ToxicLevel.ToString() },
                    { "RadiationLevel", RadiationLevel.ToString() },
                };
            }

            public void LoadData(Dictionary<string, string> data)
            {
                foreach (var key in data.Keys)
                {
                    switch (key)
                    {
                        case "WeatherIntensity":
                            float weatherIntensity;
                            if (float.TryParse(data[key], out weatherIntensity))
                                WeatherIntensity = weatherIntensity;
                            break;
                        case "WeatherLevel":
                            int weatherLevel;
                            if (int.TryParse(data[key], out weatherLevel))
                                WeatherLevel = (WeatherEffectsLevel)weatherLevel;
                            break;
                        case "WeatherEffect":
                            int weatherEffect;
                            if (int.TryParse(data[key], out weatherEffect))
                                WeatherEffect = (WeatherEffects)weatherEffect;
                            break;
                        case "CurrentEnvironmentType":
                            int currentEnvironmentType;
                            if (int.TryParse(data[key], out currentEnvironmentType))
                                CurrentEnvironmentType = (EnvironmentDetector)currentEnvironmentType;
                            break;
                        case "CurrentTemperature":
                            var parts = data[key].Split(':');
                            if (parts.Length == 2)
                            {
                                float currentTemperatureX;
                                float currentTemperatureY;
                                if (float.TryParse(parts[0], out currentTemperatureX) &&
                                    float.TryParse(parts[1], out currentTemperatureY))
                                {
                                    CurrentTemperature = new Vector2(currentTemperatureX, currentTemperatureY);
                                }
                            }
                            break;
                        case "ExternalTemperature":
                            var partsEt = data[key].Split(':');
                            if (partsEt.Length == 2)
                            {
                                float currentETemperatureX;
                                float currentETemperatureY;
                                if (float.TryParse(partsEt[0], out currentETemperatureX) &&
                                    float.TryParse(partsEt[1], out currentETemperatureY))
                                {
                                    ExternalTemperature = new Vector2(currentETemperatureX, currentETemperatureY);
                                }
                            }
                            break;
                        case "ToxicLevel":
                            float toxicLevel;
                            if (float.TryParse(data[key], out toxicLevel))
                                ToxicLevel = toxicLevel;
                            break;
                        case "RadiationLevel":
                            float radiationLevel;
                            if (float.TryParse(data[key], out radiationLevel))
                                RadiationLevel = radiationLevel;
                            break;
                    }
                }
            }

            public override int GetHashCode()
            {
                return GetDisplayInfo(4, null).GetHashCode();
            }

            public string GetDisplayInfo(int bodyTrackerLevel, PlayerArmorController.PlayerEquipInfo armorinfo)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(LanguageProvider.GetEntry(LanguageEntries.UI_ENVIROMENT_DISPLAY));
                sb.Append(GetEnvironmentDetectorDescription(CurrentEnvironmentType));
                if (bodyTrackerLevel >= 1)
                {
                    sb.Append($" [{CurrentTemperature.Y.ToString("#0.00")}ºC]");
                    if (bodyTrackerLevel >= 3 && CurrentTemperature.Y != ExternalTemperature.Y)
                    {
                        sb.Append($" {LanguageProvider.GetEntry(LanguageEntries.UI_EXTERNALTEMP_DISPLAY)} [{ExternalTemperature.Y.ToString("#0.00")}ºC]");
                    }
                    float coldReistence = 0;
                    float hotReistence = 0;
                    if (armorinfo != null && (armorinfo.HasArmor || armorinfo.HasHelmet))
                    {
                        coldReistence = armorinfo.GetColdResistence();
                        hotReistence = armorinfo.GetHotResistence();
                    }
                    if (bodyTrackerLevel >= 2 && CurrentEnvironmentType != EnvironmentDetector.ShipOrStation)
                    {
                        var minTemp = PlayerTemperatureController.TEMPERATURE_RANGE.X - coldReistence;
                        var maxTemp = PlayerTemperatureController.TEMPERATURE_RANGE.Y + hotReistence;
                        sb.Append($" {LanguageProvider.GetEntry(LanguageEntries.UI_SAFETEMPERATURE_DISPLAY)} [{minTemp.ToString("#0.00")}ºC - {maxTemp.ToString("#0.00")}ºC]");
                    }
                    if (WeatherEffect != WeatherEffects.None)
                    {
                        sb.Append(Environment.NewLine);
                        sb.Append(LanguageProvider.GetEntry(LanguageEntries.UI_WEATHER_DISPLAY));
                        sb.Append(GetWeatherEffectsLevelDescription(WeatherLevel));
                        sb.Append(" " + GetWeatherEffectsDescription(WeatherEffect));
                    }
                }
                bool addedToxicLevel = false;
                if (bodyTrackerLevel >= 2 && ToxicLevel > 0)
                {
                    sb.Append(Environment.NewLine);
                    sb.Append(LanguageProvider.GetEntry(LanguageEntries.UI_EXTERNALEXPOSE_DISPLAY));
                    sb.Append(string.Format(LanguageProvider.GetEntry(LanguageEntries.UI_TOXIC_DISPLAY), ToxicLevel.ToString("P2")));
                    addedToxicLevel = true;
                }
                if (bodyTrackerLevel >= 3 && RadiationLevel > 0)
                {
                    if (!addedToxicLevel)
                    {
                        sb.Append(Environment.NewLine);
                        sb.Append(LanguageProvider.GetEntry(LanguageEntries.UI_EXTERNALEXPOSE_DISPLAY));
                    }
                    else
                    {
                        sb.Append(" ");
                    }
                    sb.Append(string.Format(LanguageProvider.GetEntry(LanguageEntries.UI_RADIATION_DISPLAY), RadiationLevel.ToString("P2")));
                }
                return sb.ToString();
            }

        }

        private static ConcurrentDictionary<long, WeatherInfo> weatherInfo = new ConcurrentDictionary<long, WeatherInfo>();
        private static ConcurrentDictionary<long, int> weatherInfoSyncHash = new ConcurrentDictionary<long, int>();

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
            float o2Level = 0;
            bool isOnPlanetAtm = false;
            weatherInfo[entity.EntityId].CurrentEnvironmentType = GetEnvironmentType(entity, playerPos, platAtRange, out o2Level, out isOnPlanetAtm);
            if (isOnPlanetAtm && ExtendedSurvivalCoreAPI.Registered)
            {
                weatherInfo[entity.EntityId].ExternalTemperature = ExtendedSurvivalCoreAPI.GetTemperatureInPoint(platAtRange.EntityId, playerPos).Value;
                if (weatherInfo[entity.EntityId].CurrentEnvironmentType == EnvironmentDetector.Atmosphere ||
                    weatherInfo[entity.EntityId].CurrentEnvironmentType == EnvironmentDetector.Underwater)
                {
                    var density = platAtRange.Entity.GetAirDensity(playerPos);
                    weatherInfo[entity.EntityId].ToxicLevel = platAtRange.Atmosphere.ToxicLevel * density;
                    weatherInfo[entity.EntityId].RadiationLevel = platAtRange.Atmosphere.RadiationLevel * density;
                    if (platAtRange.HasWater && platAtRange.Water.Enabled && WaterModAPI.Registered && WaterModAPI.IsUnderwater(playerPos))
                    {
                        var depth = Math.Abs(WaterModAPI.GetDepth(playerPos) ?? 0) / 100;
                        if (depth > 0)
                        {
                            weatherInfo[entity.EntityId].ToxicLevel += platAtRange.Water.ToxicLevel * depth;
                            weatherInfo[entity.EntityId].RadiationLevel += platAtRange.Water.RadiationLevel * depth;
                        }
                    }
                }
                else
                {
                    weatherInfo[entity.EntityId].ToxicLevel = 0;
                    weatherInfo[entity.EntityId].RadiationLevel = 0;
                }
            }
            else
            {
                weatherInfo[entity.EntityId].ExternalTemperature = new Vector2(0, SPACE_TEMPERATURE);
                weatherInfo[entity.EntityId].ToxicLevel = 0;
                weatherInfo[entity.EntityId].RadiationLevel = 0;
            }
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
                case EnvironmentDetector.NotPressurizedRoom:
                    if (ExtendedSurvivalCoreAPI.Registered)
                    {
                        var t = ExtendedSurvivalCoreAPI.GetTemperatureInPoint(platAtRange.EntityId, playerPos).Value;
                        if (t.Y > PRESURIZED_TEMPERATURE)
                        {
                            weatherInfo[entity.EntityId].CurrentTemperature = new Vector2(
                               0.5f + t.X * (1 - o2Level),
                               PRESURIZED_TEMPERATURE + t.Y * (1 - o2Level)
                            );
                        }
                        else
                        {
                            if (t.Y < 0)
                            {
                                weatherInfo[entity.EntityId].CurrentTemperature = new Vector2(0.5f * o2Level, PRESURIZED_TEMPERATURE * o2Level);
                            }
                            else
                            {
                                weatherInfo[entity.EntityId].CurrentTemperature = new Vector2(
                                   0.5f - t.X * (1 - o2Level),
                                   PRESURIZED_TEMPERATURE - t.Y * (1 - o2Level)
                                );
                            }
                        }
                    }
                    else
                        weatherInfo[entity.EntityId].CurrentTemperature = new Vector2(0.5f * o2Level, PRESURIZED_TEMPERATURE * o2Level);
                    break;
                case EnvironmentDetector.NotPressurizedRoomInSpace:
                    weatherInfo[entity.EntityId].CurrentTemperature = new Vector2(0.5f * o2Level, PRESURIZED_TEMPERATURE * o2Level);
                    break;
                case EnvironmentDetector.None:
                case EnvironmentDetector.Space:
                default:
                    weatherInfo[entity.EntityId].CurrentTemperature = new Vector2(0, SPACE_TEMPERATURE);
                    break;
            }
            DoSyncWeatherInfo(entity);
        }

        private static void DoSyncWeatherInfo(IMyCharacter entity)
        {
            if (ExtendedSurvivalSettings.Instance.Debug)
                ExtendedSurvivalStatsLogging.Instance.LogWarning(typeof(WeatherConstants), $"DoSyncWeatherInfo called for Id: {entity?.EntityId}");
            if (entity.IsValidPlayer())
            {
                var playerId = entity.GetPlayerId();
                if (ExtendedSurvivalStatsEntityManager.Instance.Players.ContainsKey(playerId))
                {
                    var player = ExtendedSurvivalStatsEntityManager.Instance.Players[playerId];
                    if (MyAPIGateway.Session.Player != player)
                    {
                        if (!weatherInfoSyncHash.ContainsKey(entity.EntityId) || weatherInfoSyncHash[entity.EntityId] != weatherInfo[entity.EntityId].GetHashCode())
                        {
                            weatherInfoSyncHash[entity.EntityId] = weatherInfo[entity.EntityId].GetHashCode();
                            ExtendedSurvivalStatsEntityManager.Instance.SendCallServer(new ulong[] { player.SteamUserId }, "WeatherConstants", weatherInfo[entity.EntityId].GetData());
                        }
                        else
                        {
                            if (ExtendedSurvivalSettings.Instance.Debug)
                                ExtendedSurvivalStatsLogging.Instance.LogWarning(typeof(WeatherConstants), $"{entity?.EntityId} for PlayerId: {playerId} Has no info to sync!");
                        }
                    }
                    else
                    {
                        CurrentWeatherInfo = weatherInfo[entity.EntityId];
                    }
                }
                else
                {
                    ExtendedSurvivalStatsEntityManager.Instance.UpdatePlayerList();
                    if (ExtendedSurvivalSettings.Instance.Debug)
                        ExtendedSurvivalStatsLogging.Instance.LogWarning(typeof(WeatherConstants), $"{entity?.EntityId} for PlayerId: {playerId} Is not found!");
                }
            }
            else
            {
                if (ExtendedSurvivalSettings.Instance.Debug)
                    ExtendedSurvivalStatsLogging.Instance.LogWarning(typeof(WeatherConstants), $"{entity?.EntityId} Is not a valid player!");
            }
        }

        private static PlanetInfo GetPlanetAtRange(Vector3D pos)
        {
            if (ExtendedSurvivalCoreAPI.Registered)
                return ExtendedSurvivalCoreAPI.GetPlanetAtRange(pos);
            return null;
        }

        private static EnvironmentDetector GetEnvironmentType(IMyCharacter entity, Vector3D pos, PlanetInfo platAtRange, out float o2Level, out bool isOnPlanetAtm)
        {
            o2Level = 0;
            isOnPlanetAtm = platAtRange != null && platAtRange.Entity.HasAtmosphere && platAtRange.Entity.GetAirDensity(pos) > 0f;
            WeatherConstants.EnvironmentDetector currentValue = EnvironmentDetector.None;
            entity?.Components?.Get<MyCharacterOxygenComponent>()?.UpdateBeforeSimulation100();
            var cockpit = entity.Parent as MyCockpit;
            if (cockpit != null)
            {
                var hasPower = cockpit.ResourceSink.IsPoweredByType(MyResourceDistributorComponent.ElectricityId);
                if (hasPower && cockpit.OxygenFillLevel >= 0.7f)
                {
                    return EnvironmentDetector.ShipOrStation;
                }
                else
                {
                    var o2Capacity = (cockpit as Sandbox.ModAPI.Ingame.IMyCockpit)?.OxygenCapacity ?? 0;
                    if (o2Capacity > 0)
                    {
                        o2Level = cockpit.OxygenFillLevel;
                        if (isOnPlanetAtm)
                        {
                            return EnvironmentDetector.NotPressurizedRoom;
                        }
                        else
                            return EnvironmentDetector.NotPressurizedRoomInSpace;
                    }
                    else
                    {
                        if (isOnPlanetAtm)
                        {
                            o2Level = platAtRange.Entity.GetOxygenForPosition(pos);
                            currentValue = EnvironmentDetector.Atmosphere;
                        }
                        else
                            currentValue = EnvironmentDetector.Space;
                    }
                }
            }
            else
            {
                if (entity.Physics == null || (entity.Physics != null && entity.Physics.Gravity.LengthSquared() > 0f))
                {
                    if (isOnPlanetAtm)
                    {
                        o2Level = platAtRange.Entity.GetOxygenForPosition(pos);
                        currentValue = EnvironmentDetector.Atmosphere;
                    }
                    else
                        currentValue = EnvironmentDetector.Space;
                }
                else
                    currentValue = EnvironmentDetector.Space;
            }
            if (currentValue == EnvironmentDetector.Atmosphere && (platAtRange?.HasWater ?? false) && WaterModAPI.Registered)
            {
                if (WaterModAPI.IsUnderwater(pos))
                {
                    currentValue = EnvironmentDetector.Underwater;
                }
            }
            var o2Block = GetOxygenBlockAtCharacter(entity, out o2Level);
            if (o2Block != null && o2Block.Room != null && o2Block.Room.IsAirtight)
            {
                if (o2Level >= 0.85f)
                    return EnvironmentDetector.ShipOrStation;
                else
                    return currentValue == EnvironmentDetector.Space ? EnvironmentDetector.NotPressurizedRoomInSpace : EnvironmentDetector.NotPressurizedRoom;
            }
            else
            {
                return currentValue;
            }
        }

        private static IMyOxygenBlock GetOxygenBlockAtCharacter(IMyCharacter entity, out float o2AtBlock)
        {
            o2AtBlock = 0;
            List<MyEntity> result = new List<MyEntity>();
            BoundingBoxD worldAabb = entity.PositionComp.WorldAABB;
            Vector3D center = worldAabb.Center;
            MyGamePruningStructure.GetTopMostEntitiesInBox(ref worldAabb, result);
            foreach (MyEntity myEntity in result)
            {
                var myCubeGrid = myEntity as IMyCubeGrid;
                if (myCubeGrid != null)
                {
                    var block = myCubeGrid.GasSystem.GetOxygenBlock(center);
                    o2AtBlock = block.OxygenLevel(myCubeGrid.GridSize);
                    return block;
                }
            }
            return null;
        }

        public static string GetEnvironmentDetectorDescription(EnvironmentDetector effect)
        {
            switch (effect)
            {
                case EnvironmentDetector.Atmosphere:
                    return LanguageProvider.GetEntry(LanguageEntries.ENVIRONMENTDETECTOR_ATMOSPHERE_NAME);
                case EnvironmentDetector.ShipOrStation:
                    return LanguageProvider.GetEntry(LanguageEntries.ENVIRONMENTDETECTOR_SHIPORSTATION_NAME);
                case EnvironmentDetector.Space:
                    return LanguageProvider.GetEntry(LanguageEntries.ENVIRONMENTDETECTOR_SPACE_NAME);
                case EnvironmentDetector.Underwater:
                    return LanguageProvider.GetEntry(LanguageEntries.ENVIRONMENTDETECTOR_UNDERWATER_NAME);
                case EnvironmentDetector.NotPressurizedRoom:
                case EnvironmentDetector.NotPressurizedRoomInSpace:
                    return LanguageProvider.GetEntry(LanguageEntries.ENVIRONMENTDETECTOR_NOTPRESSURIZEDROOM_NAME);
            }
            return "";
        }

        public static string GetWeatherEffectsDescription(WeatherEffects effect)
        {
            switch (effect)
            {
                case WeatherEffects.Rain:
                    return LanguageProvider.GetEntry(LanguageEntries.WEATHEREFFECTS_RAIN_NAME);
                case WeatherEffects.Thunderstorm:
                    return LanguageProvider.GetEntry(LanguageEntries.WEATHEREFFECTS_THUNDERSTORM_NAME);
            }
            return "";
        }

        public static string GetWeatherEffectsLevelDescription(WeatherEffectsLevel effect)
        {
            switch (effect)
            {
                case WeatherEffectsLevel.Light:
                    return LanguageProvider.GetEntry(LanguageEntries.WEATHEREFFECTSLEVEL_LIGHT_NAME);
                case WeatherEffectsLevel.Heavy:
                    return LanguageProvider.GetEntry(LanguageEntries.WEATHEREFFECTSLEVEL_HEAVY_NAME);
            }
            return "";
        }

    }

}