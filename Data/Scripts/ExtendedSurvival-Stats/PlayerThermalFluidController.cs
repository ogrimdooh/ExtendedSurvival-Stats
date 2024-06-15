using Sandbox.Common.ObjectBuilders.Definitions;
using Sandbox.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using VRage.Game.ModAPI;

namespace ExtendedSurvival.Stats
{
    public static class PlayerThermalFluidController
    {

        public const float THERMAL_BOTTLE_CAPACITY = 500;
        public const float THERMAL_GAS_CICLE_BASE = 1.25f;

        public static void UpdateFluidStats(PlayerStatsEasyAcess playerStats, PlayerArmorController.PlayerEquipInfo armor, long playerId, out bool hasCold, out bool hasHot, out IMyInventoryItem[] coldBottles, out IMyInventoryItem[] hotBottles)
        {
            hasCold = false;
            hasHot = false;
            var listaColdBottles = new List<IMyInventoryItem>();
            var listaHotBottles = new List<IMyInventoryItem>();
            if (playerStats != null)
            {
                if (armor != null && armor.HasArmor)
                {
                    hasCold = armor.HasAnyModule(EquipmentConstants.COLDTHERMALREGULATORS_MODULES);
                    hasHot = armor.HasAnyModule(EquipmentConstants.HOTTHERMALREGULATORS_MODULES);
                    if (hasCold || hasHot)
                    {
                        var inventory = playerStats.StatComponent.Entity.GetInventory();
                        if (inventory != null)
                        {
                            var bottles = new List<VRage.Game.ModAPI.Ingame.MyInventoryItem>();
                            inventory.GetItems(bottles, x => new UniqueEntityId(x.Type).typeId == typeof(MyObjectBuilder_GasContainerObject));
                            var queryColdBottle = bottles.Where(x => EquipmentConstants.COLDTHERMALBOTTLES.Contains(new UniqueEntityId(x.Type)));
                            var queryHotBottle = bottles.Where(x => EquipmentConstants.HOTTHERMALBOTTLES.Contains(new UniqueEntityId(x.Type)));
                            if (hasCold && queryColdBottle.Any())
                            {
                                foreach (var item in queryColdBottle)
                                {
                                    var itemObj = inventory.GetItemByID(item.ItemId);
                                    listaColdBottles.Add(itemObj);
                                }
                            }
                            if (hasHot && queryHotBottle.Any())
                            {
                                foreach (var item in queryHotBottle)
                                {
                                    var itemObj = inventory.GetItemByID(item.ItemId);
                                    listaHotBottles.Add(itemObj);
                                }
                            }
                        }
                    }
                }
                if (listaColdBottles.Count > 0)
                {
                    playerStats.ColdThermalFluid.Value = listaColdBottles.Sum(x => (x.Content as MyObjectBuilder_GasContainerObject).GasLevel) / listaColdBottles.Count;
                }
                else
                {
                    playerStats.ColdThermalFluid.Value = 0;
                }
                if (listaHotBottles.Count > 0)
                {
                    playerStats.HotThermalFluid.Value = listaHotBottles.Sum(x => (x.Content as MyObjectBuilder_GasContainerObject).GasLevel) / listaHotBottles.Count;
                }
                else
                {
                    playerStats.HotThermalFluid.Value = 0;
                }
            }
            coldBottles = listaColdBottles.ToArray();
            hotBottles = listaHotBottles.ToArray();
        }

        public static bool DoGetGasToCool(float overTemperature, PlayerArmorController.PlayerEquipInfo armor, IMyInventoryItem[] bottles, params UniqueEntityId[] ids)
        {
            var needToContinue = true;
            var module = armor.GetFirstModule(ids);
            if (module != null)
            {
                if (overTemperature < 0)
                    overTemperature *= -1;
                if (overTemperature == 0)
                    overTemperature = 0.1f;
                overTemperature = overTemperature / 30;
                var baseCost = Math.Min(THERMAL_GAS_CICLE_BASE * overTemperature, THERMAL_GAS_CICLE_BASE);
                var efficiency = module.Definition.Attributes[ArmorSystemConstants.ModuleAttribute.Efficiency];
                var gasLevelNeeded = (baseCost - (baseCost * efficiency)) / THERMAL_BOTTLE_CAPACITY;
                var inv = armor.Inventory as MyInventory;
                foreach (var bottle in bottles)
                {
                    var bottleContent = bottle.Content as MyObjectBuilder_GasContainerObject;
                    if (bottleContent.GasLevel >= gasLevelNeeded)
                    {
                        bottleContent.GasLevel -= gasLevelNeeded;
                        needToContinue = false;
                        break;
                    }
                    else
                    {
                        gasLevelNeeded -= bottleContent.GasLevel;
                        bottleContent.GasLevel = 0;
                        needToContinue = false;
                    }
                }
            }
            return needToContinue;
        }

    }

}
