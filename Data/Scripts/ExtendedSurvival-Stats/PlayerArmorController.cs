using Sandbox.ModAPI;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using VRage.Game.ModAPI;
using static ExtendedSurvival.Stats.ArmorSystemConstants;

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

        public class HelmetModuleInfo
        {

            public HelmetModuleDefinition Definition { get; set; }

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
            public ArmorDefinition ArmorDefinition { get; set; }
            public bool HasArmor { get { return ArmorDefinition != null; } }
            public HelmetDefinition HelmetDefinition { get; set; }
            public bool HasHelmet { get { return HelmetDefinition != null; } }
            public List<ArmorModuleInfo> Modules { get; set; } = new List<ArmorModuleInfo>();
            public List<HelmetModuleInfo> HelmetModules { get; set; } = new List<HelmetModuleInfo>();
            public ShieldInfo Shield { get; set; } = new ShieldInfo();

            public float GetEffect(ArmorSystemConstants.ArmorEffect armorEffect)
            {
                ArmorSystemConstants.ModuleAttribute[] equivalences = new ModuleAttribute[] { };
                if (ArmorSystemConstants.MODULE_EQUIVALENCE.ContainsKey(armorEffect))
                    equivalences = ArmorSystemConstants.MODULE_EQUIVALENCE[armorEffect];
                var effect = 0f;
                if (HasArmor)
                {
                    effect += ArmorDefinition.GetEffect(armorEffect);
                    if (equivalences.Any())
                    {
                        foreach (var equivalence in equivalences)
                        {
                            effect += Modules.Sum(x => x.Definition.GetAttribute(equivalence));
                        }
                    }
                }
                if (HasHelmet)
                {
                    effect += HelmetDefinition.GetEffect(armorEffect);
                    if (equivalences.Any())
                    {
                        foreach (var equivalence in equivalences)
                        {
                            effect += HelmetModules.Sum(x => x.Definition.GetAttribute(equivalence));
                        }
                    }
                }
                return effect;
            }

            public float GetResistence(ArmorSystemConstants.DamageType damageType)
            {
                var resistence = 0f;
                if (HasArmor)
                    resistence += ArmorDefinition.GetResistence(damageType);
                if (HasHelmet)
                    resistence += HelmetDefinition.GetResistence(damageType);
                return resistence;
            }

            public float GetColdResistence()
            {
                var resistence = 0f;
                if (HasArmor)
                    resistence += ArmorDefinition.ColdResistence;
                if (HasHelmet)
                    resistence += HelmetDefinition.ColdResistence;
                return resistence;
            }

            public float GetHotResistence()
            {
                var resistence = 0f;
                if (HasArmor)
                    resistence += ArmorDefinition.HotResistence;
                if (HasHelmet)
                    resistence += HelmetDefinition.HotResistence;
                return resistence;
            }

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
                if (HasHelmet)
                {
                    sb.Append(Environment.NewLine + string.Format(
                        LanguageProvider.GetEntry(LanguageEntries.HELMETDESC_UI_EQUIPED),
                        HelmetDefinition.Name,
                        HelmetDefinition.ModuleSlots - HelmetModules.Count
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

            public bool HasAnyHelmetModule(params UniqueEntityId[] ids)
            {
                foreach (var id in ids)
                {
                    if (HelmetModules.Any(x => x.Definition.Id == id))
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

            public HelmetModuleInfo GetFirstHelmetModule(params UniqueEntityId[] ids)
            {
                foreach (var id in ids)
                {
                    if (HelmetModules.Any(x => x.Definition.Id == id))
                        return HelmetModules.FirstOrDefault(x => x.Definition.Id == id);
                }
                return null;
            }

            public void LoadData(StoredPlayerData dataToLoad)
            {
                BodyTracker = null;
                ArmorDefinition = null;
                HelmetDefinition = null;
                Modules.Clear();
                HelmetModules.Clear();
                Shield = new ShieldInfo();
                foreach (var slot in dataToLoad.Slots)
                {
                    var itemId = new UniqueEntityId(slot.ItemId);
                    switch (slot.Id)
                    {
                        case "BodyTracker":
                            if (EquipmentConstants.EQUIPMENTS_DEFINITIONS.ContainsKey(itemId))
                            {
                                BodyTracker = new PlayerBodyTrackerInfo()
                                {
                                    Definition = EquipmentConstants.EQUIPMENTS_DEFINITIONS[itemId],
                                    Level = EquipmentConstants.BODYTRACKERS[itemId]
                                };
                            }
                            break;
                        case "BodyArmor":
                            if (EquipmentConstants.ARMORS_DEFINITIONS.ContainsKey(itemId))
                            {
                                ArmorDefinition = EquipmentConstants.ARMORS_DEFINITIONS[itemId];
                                foreach (var socket in slot.Sockets.Where(x => EquipmentConstants.ARMOR_MODULES_DEFINITIONS.ContainsKey(new UniqueEntityId(x.ItemId))))
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
                            }
                            break;
                        case "Helmet":
                            if (EquipmentConstants.HELMETS_DEFINITIONS.ContainsKey(itemId))
                            {
                                HelmetDefinition = EquipmentConstants.HELMETS_DEFINITIONS[itemId];
                                foreach (var socket in slot.Sockets.Where(x => EquipmentConstants.HELMET_MODULES_DEFINITIONS.ContainsKey(new UniqueEntityId(x.ItemId))))
                                {
                                    HelmetModules.Add(new HelmetModuleInfo()
                                    {
                                        Definition = EquipmentConstants.HELMET_MODULES_DEFINITIONS[new UniqueEntityId(socket.ItemId)]
                                    });
                                }
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
