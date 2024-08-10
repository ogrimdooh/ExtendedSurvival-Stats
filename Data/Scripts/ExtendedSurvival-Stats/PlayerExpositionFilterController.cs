using Sandbox.Common.ObjectBuilders.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using VRage.Game.ModAPI;

namespace ExtendedSurvival.Stats
{
    public static class PlayerExpositionFilterController
    {

        public const float EXPOSITION_FILTER_CAPACITY = 500;
        public const float EXPOSITION_FILTER_CICLE_BASE = 1.25f;

        public static void UpdateFluidStats(PlayerStatsEasyAcess playerStats, PlayerArmorController.PlayerEquipInfo armor, long playerId, out bool hasToxicity, out bool hasRadioactivity, out IMyInventoryItem[] ToxicityBottles, out IMyInventoryItem[] RadioactivityBottles)
        {
            hasToxicity = false;
            hasRadioactivity = false;
            var listaToxicityBottles = new List<IMyInventoryItem>();
            var listaRadioactivityBottles = new List<IMyInventoryItem>();
            int fullToxicityBottles = 0;
            int fullRadioactivityBottles = 0;
            if (playerStats != null)
            {
                if (armor != null && armor.HasArmor)
                {
                    hasToxicity = armor.HasAnyModule(EquipmentConstants.TOXICITYFILTER_MODULES);
                    hasRadioactivity = armor.HasAnyModule(EquipmentConstants.RADIOACTIVITYFILTER_MODULES);
                    if (hasToxicity || hasRadioactivity)
                    {
                        var inventory = playerStats.StatComponent.Entity.GetInventory();
                        if (inventory != null)
                        {
                            var bottles = new List<VRage.Game.ModAPI.Ingame.MyInventoryItem>(); 
                            inventory.GetItems(bottles, x => EquipmentConstants.ALLEXPOSUREBOTTLES.Contains(new UniqueEntityId(x.Type)));
                            var queryToxicityBottle = bottles.Where(x => EquipmentConstants.TOXICITYBOTTLES.Contains(new UniqueEntityId(x.Type)));
                            var queryFullToxicityBottle = bottles.Where(x => EquipmentConstants.FULLTOXICITYBOTTLES.Contains(new UniqueEntityId(x.Type)));
                            var queryRadioactivityBottle = bottles.Where(x => EquipmentConstants.RADIOACTIVITYBOTTLES.Contains(new UniqueEntityId(x.Type)));
                            var queryFullRadioactivityBottle = bottles.Where(x => EquipmentConstants.FULLRADIOACTIVITYBOTTLES.Contains(new UniqueEntityId(x.Type)));
                            if (hasToxicity && queryToxicityBottle.Any())
                            {
                                foreach (var item in queryToxicityBottle)
                                {
                                    var itemObj = inventory.GetItemByID(item.ItemId);
                                    listaToxicityBottles.Add(itemObj);
                                }
                            }
                            fullToxicityBottles = queryFullToxicityBottle.Count();
                            if (hasRadioactivity && queryRadioactivityBottle.Any())
                            {
                                foreach (var item in queryRadioactivityBottle)
                                {
                                    var itemObj = inventory.GetItemByID(item.ItemId);
                                    listaRadioactivityBottles.Add(itemObj);
                                }
                            }
                            fullRadioactivityBottles = queryFullRadioactivityBottle.Count();
                        }
                    }
                }
                if (listaToxicityBottles.Count > 0 || fullToxicityBottles > 0)
                {
                    playerStats.IntoxicationTime.Value = (
                            listaToxicityBottles.Sum(x => (x.Content as MyObjectBuilder_GasContainerObject).GasLevel) + fullToxicityBottles
                        ) / (listaToxicityBottles.Count + fullToxicityBottles);
                }
                else
                {
                    playerStats.IntoxicationTime.Value = 0;
                }
                if (listaRadioactivityBottles.Count > 0 || fullRadioactivityBottles > 0)
                {
                    playerStats.RadiationTime.Value = (
                            listaRadioactivityBottles.Sum(x => (x.Content as MyObjectBuilder_GasContainerObject).GasLevel) + fullRadioactivityBottles
                        ) / (listaRadioactivityBottles.Count + fullRadioactivityBottles);
                }
                else
                {
                    playerStats.RadiationTime.Value = 0;
                }
            }
            ToxicityBottles = listaToxicityBottles.ToArray();
            RadioactivityBottles = listaRadioactivityBottles.ToArray();
        }

        public static bool DoFillGasToCool(float exposeValue, PlayerArmorController.PlayerEquipInfo armor, IMyInventoryItem[] bottles, params UniqueEntityId[] ids)
        {
            var needToContinue = true;
            var module = armor.GetFirstModule(ids);
            if (module != null)
            {
                if (exposeValue < 0)
                    exposeValue *= -1;
                if (exposeValue == 0)
                    exposeValue = 0.1f;
                var baseCost = Math.Min(EXPOSITION_FILTER_CICLE_BASE * exposeValue, EXPOSITION_FILTER_CICLE_BASE);
                var efficiency = module.Definition.Attributes[ArmorSystemConstants.ModuleAttribute.Efficiency];
                var gasLevelToIncrease = (baseCost - (baseCost * efficiency)) / EXPOSITION_FILTER_CAPACITY;
                var inv = armor.Inventory as IMyInventory;
                foreach (var bottle in bottles)
                {
                    var bottleContent = bottle.Content as MyObjectBuilder_GasContainerObject;
                    var freeGasLevel = 1f - bottleContent.GasLevel;
                    if (freeGasLevel >= gasLevelToIncrease)
                    {
                        bottleContent.GasLevel += gasLevelToIncrease;
                        needToContinue = false;
                        break;
                    }
                    else
                    {
                        gasLevelToIncrease -= bottleContent.GasLevel;
                        var itemId = new UniqueEntityId(bottle.Content.TypeId, bottle.Content.SubtypeId);
                        inv.RemoveItems(bottle.ItemId);
                        inv.AddMaxItems(1f, ItensConstants.GetPhysicalObjectBuilder(EquipmentConstants.EXPOSEBOTTLEEQUIVALENCE[itemId]));
                        needToContinue = false;
                    }
                }
            }
            return needToContinue;
        }

    }

}
