using Sandbox.ModAPI;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using VRage.Game.ModAPI;

namespace ExtendedSurvival.Stats
{
    public static class PlayerArmorController
    {

        public struct PlayerArmorInfo
        {

            public IMyInventory Inventory;
            public uint ItemUid;
            public ArmorDefinition Definition;

            public string GetDisplayInfo()
            {
                return string.Format(LanguageProvider.GetEntry(LanguageEntries.ARMORDESC_UI_EQUIPED), Definition.Name);
            }

        }

        private static ConcurrentDictionary<long, PlayerArmorInfo> cache = new ConcurrentDictionary<long, PlayerArmorInfo>();

        public static PlayerArmorInfo? GetEquipedArmor(long playerId = 0, bool useCache = false)
        {
            if (useCache)
            {
                if (cache.ContainsKey(playerId))
                {
                    var invItem = cache[playerId].Inventory.GetItemByID(cache[playerId].ItemUid);
                    if (invItem != null && invItem.Content.GetUniqueId() == cache[playerId].Definition.Id)
                        return cache[playerId];
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
                    playerInventory.GetItems(itens, x => EquipmentConstants.ARMORS_DEFINITIONS.ContainsKey(new UniqueEntityId(x.Type)));
                    if (itens.Any())
                    {
                        var item = itens.FirstOrDefault();
                        cache[playerId] = new PlayerArmorInfo()
                        {
                            Definition = EquipmentConstants.ARMORS_DEFINITIONS[new UniqueEntityId(item.Type)],
                            Inventory = playerInventory,
                            ItemUid = item.ItemId
                        };
                        return cache[playerId];
                    }
                }
            }
            return null;
        }

    }

}
