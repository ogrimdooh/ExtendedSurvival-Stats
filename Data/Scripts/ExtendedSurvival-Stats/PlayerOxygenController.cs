using VRage.Game.ModAPI;
using VRageMath;

namespace ExtendedSurvival.Stats
{
    public static class PlayerOxygenController
    {

        public static void CheckOxygenValue(long playerId, IMyCharacter character, WeatherConstants.EnvironmentDetector currentEnvironmentType)
        {
            float percentValue;
            bool usingSuit = character.EnabledHelmet;
            if (currentEnvironmentType == WeatherConstants.EnvironmentDetector.Underwater)
            {
                PlayerUnderwaterController.CheckIfO2ControllerIsReady(playerId);
                percentValue = usingSuit ?
                    PlayerUnderwaterController.GetEnterUnderWaterO2Level(playerId) :
                    0f;
            }
            else
            {
                percentValue = usingSuit ?
                    character.GetSuitGasFillLevel(ItensConstants.OXYGEN_ID.DefinitionId) :
                    character.OxygenLevel;
            }
            var checkValue = usingSuit ?
                new Vector2(0.05f, 0.2f) :
                new Vector2(0.1f, 0.8f);
            if (percentValue <= checkValue.X)
            {
                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.Suffocation.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Disoriented.ToString(), 0, true);
            }
            else if (percentValue <= checkValue.Y)
            {
                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.Disoriented.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Suffocation.ToString(), 0, true);
            }
            else
            {
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Disoriented.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Suffocation.ToString(), 0, true);
            }
        }

    }

}
