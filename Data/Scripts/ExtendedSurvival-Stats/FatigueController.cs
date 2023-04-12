using Sandbox.Game.Components;
using Sandbox.Game.Entities;
using VRage.Game.ModAPI;
using VRage.Utils;

namespace ExtendedSurvival.Stats
{
    public static class FatigueController
    {

        public static void DoCycle(long playerId, IMyCharacter character, MyCharacterStatComponent statComponent)
        {

            MyEntityStat Fatigue;
            statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.ValidStats.Fatigue.ToString()), out Fatigue);

            if (character.IsOnValidRestBlock() && !character.IsOnTreadmill())
            {
                ProcessRest(playerId, Fatigue, character.IsOnGoodRestBlock());
            }
            else
            {
                ProcessFatigue(playerId, Fatigue);
            }

        }

        private static void ProcessRest(long playerId, MyEntityStat Fatigue, bool goodRest)
        {
            if (Fatigue.Value > Fatigue.MinValue)
            {
                var valueToDecrease = StatsConstants.BASE_FATIGUE_DECREASE_FACTOR;
                if (goodRest)
                    valueToDecrease *= StatsConstants.BASE_FATIGUE_DECREASE_MULTIPLIER;
                Fatigue.Decrease(valueToDecrease, playerId);
            }
        }

        private static void ProcessFatigue(long playerId, MyEntityStat Fatigue)
        {
            if (Fatigue.Value < Fatigue.MaxValue)
            {
                var value = StatsConstants.BASE_FATIGUE_INCREASE_FACTOR;
                Fatigue.Increase(value, playerId);
            }
        }

    }

}
