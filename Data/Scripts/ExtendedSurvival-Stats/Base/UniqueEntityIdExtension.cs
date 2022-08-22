using Sandbox.Definitions;
using System;
using VRage.Game;

namespace ExtendedSurvival.Stats
{
    public static class UniqueEntityIdExtension
    {

        public static T GetDefinition<T>(this UniqueEntityId id) where T : MyDefinitionBase
        {
            try
            {
                var defs = MyDefinitionManager.Static.GetAllDefinitions();
                return defs[id.DefinitionId] as T;
            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(typeof(UniqueEntityIdExtension), ex);
            }
            return null;
        }

    }

}
