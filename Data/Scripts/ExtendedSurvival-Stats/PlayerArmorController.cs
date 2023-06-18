using Sandbox.ModAPI;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public struct ShieldInfo
        {

            public bool HasShield;
            public long MaxShield;
            public float RechargeRate;
            public float PowerCost;
            public bool HasSpike;
            public bool HasNova;

        }

        public struct PlayerArmorInfo
        {

            public IMyInventory Inventory;
            public uint ItemUid;
            public ArmorDefinition Definition;
            public ArmorModuleInfo[] Modules;
            public int LastModuleCount;
            public ShieldInfo Shield;

            public string GetDisplayInfo()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(string.Format(
                    LanguageProvider.GetEntry(LanguageEntries.ARMORDESC_UI_EQUIPED),
                    Definition.Name,
                    Definition.ModuleSlots - Modules.Length
                ));
                if (Shield.HasShield)
                {
                    sb.Append(Environment.NewLine + string.Format(
                        LanguageProvider.GetEntry(LanguageEntries.ARMORDESC_UI_SHIELD_EQUIPED),
                        Shield.MaxShield
                    ));
                }
                return sb.ToString();
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
                                            if (moduleItem == null || moduleItem.Content.GetUniqueId() != module.Definition.Id)
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
                                modules.Sort((x, y) => 
                                {
                                    if (x.Type != y.Type)
                                    {
                                        var isX = EquipmentConstants.SHIELDEXPAND_MODULES.Contains(new UniqueEntityId(x.Type));
                                        var isY = EquipmentConstants.SHIELDEXPAND_MODULES.Contains(new UniqueEntityId(y.Type));
                                        if (isX != isY)
                                        {
                                            if (isX)
                                                return 1;
                                            else
                                                return -1;
                                        }
                                    }
                                    return 0;
                                });
                                foreach (var module in modules)
                                {
                                    var moduleDef = EquipmentConstants.ARMOR_MODULES_DEFINITIONS[new UniqueEntityId(module.Type)];
                                    if (moduleDef.UseCategory.IsFlagSet(idemDef.Category))
                                    {
                                        if (EquipmentConstants.SHIELDGENERATORS_MODULES.Contains(moduleDef.Id) &&
                                            validModules.Any(x => EquipmentConstants.SHIELDGENERATORS_MODULES.Contains(x.Definition.Id)))
                                            continue;
                                        if (EquipmentConstants.SHIELDEXPAND_MODULES.Contains(moduleDef.Id) &&
                                            !validModules.Any(x => EquipmentConstants.SHIELDGENERATORS_MODULES.Contains(x.Definition.Id)))
                                            continue;
                                        validModules.Add(new ArmorModuleInfo()
                                        {
                                            ItemUid = module.ItemId,
                                            Definition = moduleDef
                                        });
                                    }
                                    if (validModules.Count >= idemDef.ModuleSlots)
                                        break;
                                }
                            }
                            ShieldInfo? shield = null;
                            if (validModules.Any(x => EquipmentConstants.SHIELDGENERATORS_MODULES.Contains(x.Definition.Id)))
                            {
                                var shieldModule = validModules.FirstOrDefault(x => EquipmentConstants.SHIELDGENERATORS_MODULES.Contains(x.Definition.Id));

                                float maxShieldFactor = 1;
                                float powerCostFactor = 1;
                                float rechargeRateFactor = 1;
                                if (validModules.Any(x => EquipmentConstants.SHIELDEXPAND_MODULES.Contains(x.Definition.Id)))
                                {
                                    foreach (var module in validModules.Where(x => EquipmentConstants.SHIELDEXPAND_MODULES.Contains(x.Definition.Id)))
                                    {
                                        if (EquipmentConstants.SHIELDCAPACITORS_MODULES.Contains(module.Definition.Id))
                                        {
                                            maxShieldFactor += module.Definition.Attributes[ArmorSystemConstants.ModuleAttribute.CapacityBonus];
                                            powerCostFactor += module.Definition.Attributes[ArmorSystemConstants.ModuleAttribute.EnergyConsumptionBonus];
                                            rechargeRateFactor += module.Definition.Attributes[ArmorSystemConstants.ModuleAttribute.RechargeSpeedBonus];
                                        }
                                        else if (EquipmentConstants.SHIELDTRANSISTORS_MODULES.Contains(module.Definition.Id))
                                        {
                                            powerCostFactor += module.Definition.Attributes[ArmorSystemConstants.ModuleAttribute.EnergyConsumptionBonus];
                                            rechargeRateFactor += module.Definition.Attributes[ArmorSystemConstants.ModuleAttribute.RechargeSpeedBonus];
                                        }
                                    }
                                }
                                
                                shield = new ShieldInfo()
                                {
                                    HasShield = true,
                                    MaxShield = (long)(shieldModule.Definition.Attributes[ArmorSystemConstants.ModuleAttribute.Capacity] * maxShieldFactor),
                                    PowerCost = shieldModule.Definition.Attributes[ArmorSystemConstants.ModuleAttribute.EnergyConsumption] * powerCostFactor,
                                    RechargeRate = shieldModule.Definition.Attributes[ArmorSystemConstants.ModuleAttribute.RechargeSpeed] * rechargeRateFactor
                                };                                
                            }
                            cache[playerId] = new PlayerArmorInfo()
                            {
                                Definition = idemDef,
                                Inventory = playerInventory,
                                ItemUid = item.ItemId,
                                Modules = validModules.ToArray(),
                                LastModuleCount = modules.Count,
                                Shield = shield.HasValue ? shield.Value : new ShieldInfo() { HasShield = false }
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
