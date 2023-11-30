using Sandbox.ModAPI;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using VRage.Game.ModAPI;

namespace ExtendedSurvival.Stats
{
    /*
    public static class PlayerBodyTrackerController
    {

        public struct PlayerBodyTrackerInfo
        {

            public IMyInventory Inventory;
            public uint ItemUid;
            public EquipmentDefinition Definition;
            public int Level;

        }


        private static ConcurrentDictionary<long, PlayerBodyTrackerInfo> cache = new ConcurrentDictionary<long, PlayerBodyTrackerInfo>();

        public static PlayerBodyTrackerInfo? GetEquipedBodyTracker(long playerId = 0, bool useCache = false)
        {
            try
            {
                if (useCache)
                {
                    if (cache.ContainsKey(playerId))
                    {
                        if (cache[playerId].Inventory != null)
                        {
                            var invItem = cache[playerId].Inventory.GetItemByID(cache[playerId].ItemUid);
                            if (invItem != null && invItem.Content.GetUniqueId() == cache[playerId].Definition.Id)
                            {
                                return cache[playerId];
                            }
                        }
                        cache.Remove(playerId);
                    }
                }
                IMyPlayer player = null;
                if (playerId == 0 && !MyAPIGateway.Utilities.IsDedicated)
                    player = MyAPIGateway.Session.Player;
                else if (playerId != 0 && MyAPIGateway.Multiplayer.IsServer)
                    ExtendedSurvivalStatsEntityManager.Instance.Players.TryGetValue(playerId, out player);
                if (player != null)
                {
                    var playerInventory = player.Character?.GetInventory();
                    if (playerInventory != null)
                    {
                        var itens = new List<VRage.Game.ModAPI.Ingame.MyInventoryItem>();
                        playerInventory.GetItems(itens, x => EquipmentConstants.BODYTRACKERS.ContainsKey(new UniqueEntityId(x.Type)));
                        if (itens.Any())
                        {
                            var bodyTracker = itens.OrderByDescending(x => EquipmentConstants.BODYTRACKERS[new UniqueEntityId(x.Type)]).FirstOrDefault();
                            var id = new UniqueEntityId(bodyTracker.Type);
                            cache[playerId] = new PlayerBodyTrackerInfo()
                            {
                                Definition = EquipmentConstants.EQUIPMENTS_DEFINITIONS[id],
                                Inventory = playerInventory,
                                ItemUid = bodyTracker.ItemId,
                                Level = EquipmentConstants.BODYTRACKERS[id]
                            };
                            return cache[playerId];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(typeof(PlayerBodyTrackerController), ex);
            }
            return null;
        }

    }
    */
}
