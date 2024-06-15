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

        public class PlayerBodyTrackerInfo
        {

            public EquipmentDefinition Definition;
            public int Level;

        }

        public class ArmorModuleInfo
        {

            public ArmorModuleDefinition Definition { get; set; }

        }

        public class ShieldInfo
        {

            public bool HasShield { get; set; }
            public long MaxShield { get; set; }
            public float RechargeRate { get; set; }
            public float PowerCost { get; set; }
            public bool HasSpike { get; set; }
            public float SpikeTurn { get; set; }
            public bool HasNova { get; set; }

        }

        public class PlayerEquipInfo
        {

            public long PlayerId { get; set; }
            public IMyInventory Inventory 
            { 
                get
                {
                    if (MyAPIGateway.Session.IsServer)
                    {
                        IMyPlayer player;
                        if (ExtendedSurvivalStatsEntityManager.Instance.Players.TryGetValue(PlayerId, out player))
                        {
                            return player.Character?.GetInventory();
                        }
                        return null;
                    }
                    else
                        return MyAPIGateway.Session.Player.Character?.GetInventory();
                }
            }
            public PlayerBodyTrackerInfo BodyTracker { get; set; }
            public bool HasBodyTracker { get { return BodyTracker != null; } }            
            public bool HasArmor { get { return ArmorDefinition != null; } }
            public ArmorDefinition ArmorDefinition { get; set; }
            public List<ArmorModuleInfo> Modules { get; set; } = new List<ArmorModuleInfo>();
            public ShieldInfo Shield { get; set; } = new ShieldInfo();

            public string GetDisplayInfo()
            {

                StringBuilder sb = new StringBuilder();
                if (HasArmor)
                {
                    sb.Append(string.Format(
                        LanguageProvider.GetEntry(LanguageEntries.ARMORDESC_UI_EQUIPED),
                        ArmorDefinition.Name,
                        ArmorDefinition.ModuleSlots - Modules.Count
                    ));
                    if (Shield.HasShield)
                    {
                        sb.Append(Environment.NewLine + string.Format(
                            LanguageProvider.GetEntry(LanguageEntries.ARMORDESC_UI_SHIELD_EQUIPED),
                            Shield.MaxShield
                        ));
                    }
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

            public ArmorModuleInfo GetFirstModule(params UniqueEntityId[] ids)
            {
                foreach (var id in ids)
                {
                    if (Modules.Any(x => x.Definition.Id == id))
                        return Modules.FirstOrDefault(x => x.Definition.Id == id);
                }
                return null;
            }

            public void LoadData(StoredPlayerData dataToLoad)
            {
                BodyTracker = null;
                ArmorDefinition = null;
                Modules.Clear();
                Shield = new ShieldInfo();
                foreach (var slot in dataToLoad.Slots)
                {
                    var itemId = new UniqueEntityId(slot.ItemId);
                    switch (slot.Id)
                    {
                        case "BodyTracker":
                            BodyTracker = new PlayerBodyTrackerInfo() 
                            { 
                                Definition = EquipmentConstants.EQUIPMENTS_DEFINITIONS[itemId],
                                Level = EquipmentConstants.BODYTRACKERS[itemId]
                            };
                            break;
                        case "BodyArmor":
                            ArmorDefinition = EquipmentConstants.ARMORS_DEFINITIONS[itemId];
                            foreach (var socket in slot.Sockets)
                            {
                                Modules.Add(new ArmorModuleInfo() 
                                { 
                                    Definition = EquipmentConstants.ARMOR_MODULES_DEFINITIONS[new UniqueEntityId(socket.ItemId)]
                                });                                
                            }
                            if (Modules.Any(x => EquipmentConstants.SHIELDGENERATORS_MODULES.Contains(x.Definition.Id)))
                            {
                                var shieldModule = Modules.FirstOrDefault(x => EquipmentConstants.SHIELDGENERATORS_MODULES.Contains(x.Definition.Id));

                                float maxShieldFactor = 1;
                                float powerCostFactor = 1;
                                float rechargeRateFactor = 1;
                                float spikeTurn = 0;
                                if (Modules.Any(x => EquipmentConstants.SHIELDEXPAND_MODULES.Contains(x.Definition.Id)))
                                {
                                    foreach (var module in Modules.Where(x => EquipmentConstants.SHIELDEXPAND_MODULES.Contains(x.Definition.Id)))
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
                                        else if (EquipmentConstants.SHIELDSPIKES_MODULES.Contains(module.Definition.Id))
                                        {
                                            spikeTurn += module.Definition.Attributes[ArmorSystemConstants.ModuleAttribute.SpikeDamage];
                                            powerCostFactor += module.Definition.Attributes[ArmorSystemConstants.ModuleAttribute.EnergyConsumptionBonus];
                                        }
                                    }
                                }
                                Shield = new ShieldInfo()
                                {
                                    HasShield = true,
                                    MaxShield = (long)(shieldModule.Definition.Attributes[ArmorSystemConstants.ModuleAttribute.Capacity] * maxShieldFactor),
                                    PowerCost = shieldModule.Definition.Attributes[ArmorSystemConstants.ModuleAttribute.EnergyConsumption] * powerCostFactor,
                                    RechargeRate = shieldModule.Definition.Attributes[ArmorSystemConstants.ModuleAttribute.RechargeSpeed] * rechargeRateFactor,
                                    HasSpike = spikeTurn > 0,
                                    SpikeTurn = spikeTurn
                                };
                            }
                            break;
                    }
                }
            }

        }

        private static readonly ConcurrentDictionary<long, PlayerEquipInfo> cache = new ConcurrentDictionary<long, PlayerEquipInfo>();

        public static PlayerEquipInfo GetEquipedArmor(long playerId = 0, bool useCache = false)
        {
            try
            {
                if (playerId == 0 && !MyAPIGateway.Utilities.IsDedicated)
                    playerId = MyAPIGateway.Session?.Player?.IdentityId ?? 0;
                if (useCache && cache.ContainsKey(playerId))
                    return cache[playerId];
                StoredPlayerData storeData;
                if (MyAPIGateway.Session.IsServer)
                    storeData = AdvancedPlayerEquipCoreAPI.GetStoredData(playerId);
                else
                    storeData = AdvancedPlayerEquipCoreClientAPI.GetStoredData();
                if (storeData != null)
                {
                    if (!cache.ContainsKey(playerId))
                        cache[playerId] = new PlayerEquipInfo() { PlayerId = playerId };
                    cache[playerId].LoadData(storeData);
                    return cache[playerId];
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
