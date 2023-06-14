using Sandbox.ModAPI;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using VRage.Game.ModAPI;

namespace ExtendedSurvival.Stats
{
    public static class PlayerArmorController
    {

        public struct ArmorModuleInfo
        {

            public uint ItemUid;
            public ArmorModuleDefinition Definition;

        }

        public struct PlayerArmorInfo
        {

            public IMyInventory Inventory;
            public uint ItemUid;
            public ArmorDefinition Definition;
            public ArmorModuleInfo[] Modules;
            public int LastModuleCount;

            public string GetDisplayInfo()
            {
                return string.Format(
                    LanguageProvider.GetEntry(LanguageEntries.ARMORDESC_UI_EQUIPED), 
                    Definition.Name,
                    Definition.ModuleSlots - Modules.Length
                );
            }

            public bool HasAnyModule(params UniqueEntityId[] ids)
            {
                foreach (var id in ids)
                {
                    if (Modules.Any(x => x.Definition.Id == id))
                        return true;
                }
                return false;
            }

            public ArmorModuleInfo? GetFirstModule(params UniqueEntityId[] ids)
            {
                foreach (var id in ids)
                {
                    if (Modules.Any(x => x.Definition.Id == id))
                        return Modules.FirstOrDefault(x => x.Definition.Id == id);
                }
                return null;
            }

        }

        private static ConcurrentDictionary<long, PlayerArmorInfo> cache = new ConcurrentDictionary<long, PlayerArmorInfo>();

        public static PlayerArmorInfo? GetEquipedArmor(long playerId = 0, bool useCache = false)
        {
            try
            {
                var modules = new List<VRage.Game.ModAPI.Ingame.MyInventoryItem>();
                var modulesLoad = false;
                if (useCache)
                {
                    if (cache.ContainsKey(playerId))
                    {
                        if (cache[playerId].Inventory != null)
                        {
                            var invItem = cache[playerId].Inventory.GetItemByID(cache[playerId].ItemUid);
                            if (invItem != null && invItem.Content.GetUniqueId() == cache[playerId].Definition.Id)
                            {
                                cache[playerId].Inventory.GetItems(modules, x => EquipmentConstants.ARMOR_MODULES_DEFINITIONS.ContainsKey(new UniqueEntityId(x.Type)));
                                modulesLoad = true;
                                if (cache[playerId].Definition.ModuleSlots == cache[playerId].Modules.Length ||
                                    cache[playerId].Modules.Length == modules.Count ||
                                    cache[playerId].LastModuleCount == modules.Count)
                                {
                                    bool canUse = true;
                                    if (cache[playerId].Modules.Any())
                                    {
                                        foreach (var module in cache[playerId].Modules)
                                        {
                                            var moduleItem = cache[playerId].Inventory.GetItemByID(module.ItemUid);
                                            if (moduleItem.Content.GetUniqueId() != module.Definition.Id)
                                            {
                                                canUse = false;
                                                break;
                                            }
                                        }
                                    }
                                    if (canUse)
                                        return cache[playerId];
                                }
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
                        playerInventory.GetItems(itens, x => EquipmentConstants.ARMORS_DEFINITIONS.ContainsKey(new UniqueEntityId(x.Type)));
                        if (itens.Any())
                        {
                            var item = itens.FirstOrDefault();
                            var idemDef = EquipmentConstants.ARMORS_DEFINITIONS[new UniqueEntityId(item.Type)];
                            if (!modulesLoad)
                            {
                                playerInventory.GetItems(modules, x => EquipmentConstants.ARMOR_MODULES_DEFINITIONS.ContainsKey(new UniqueEntityId(x.Type)));
                            }
                            var validModules = new List<ArmorModuleInfo>();
                            if (modules.Any())
                            {
                                foreach (var module in modules)
                                {
                                    var moduleDef = EquipmentConstants.ARMOR_MODULES_DEFINITIONS[new UniqueEntityId(module.Type)];
                                    if (moduleDef.UseCategory.IsFlagSet(idemDef.Category))
                                    {
                                        validModules.Add(new ArmorModuleInfo()
                                        {
                                            ItemUid = module.ItemId,
                                            Definition = moduleDef
                                        });
                                    }
                                }
                            }

                            cache[playerId] = new PlayerArmorInfo()
                            {
                                Definition = idemDef,
                                Inventory = playerInventory,
                                ItemUid = item.ItemId,
                                Modules = validModules.ToArray(),
                                LastModuleCount = modules.Count
                            };
                            return cache[playerId];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(typeof(PlayerArmorController), ex);
            }
            return null;
        }

    }

}
