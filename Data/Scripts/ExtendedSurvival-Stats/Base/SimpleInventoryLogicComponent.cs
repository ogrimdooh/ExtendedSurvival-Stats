﻿using Sandbox.Game;
using System;
using VRage.Game.ModAPI;

namespace ExtendedSurvival.Stats
{
    public abstract class SimpleInventoryLogicComponent<T> : BaseInventoryLogicComponent<T> where T : IMyCubeBlock
    {

        protected event Action<int, Guid> OnAfterCreateNewObserver;

        private Guid DoCreateNewObserver(int index)
        {
            var id = ExtendedSurvivalCoreAPI.AddInventoryObserver(CurrentEntity, index);
            OnAfterCreateNewObserver?.Invoke(index, id);
            return id;
        }

        protected override Guid CreateNewObserver(int index)
        {
            if (ExtendedSurvivalCoreAPI.Registered)
                return DoCreateNewObserver(index);
            else
                ExtendedSurvivalStatsSession.AddToInvokeAfterCoreApiLoaded(() => {
                    var id = DoCreateNewObserver(index);
                    if (id != Guid.Empty)
                        inventoryObservers.Add(index, id);
                });
            return Guid.Empty;
        }

    }

}
