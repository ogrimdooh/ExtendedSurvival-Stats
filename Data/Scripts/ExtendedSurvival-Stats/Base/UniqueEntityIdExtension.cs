﻿using Sandbox.Definitions;
using System;
using VRage.Game;

namespace ExtendedSurvival.Stats
{
    public static class UniqueEntityIdExtension
    {

        public static bool IsNull(this UniqueEntityId id)
        {
            try
            {
                id.GetHashCode();
                return false;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public static bool IsNotNull(this UniqueEntityId id)
        {
            try
            {
                id.GetHashCode();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

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
