using Sandbox.Common.ObjectBuilders.Definitions;
using Sandbox.Definitions;
using Sandbox.Game.Entities.Character.Components;
using Sandbox.ModAPI;
using System;
using System.Collections.Concurrent;
using VRage.Game;
using VRage.Game.ModAPI;

namespace ExtendedSurvival.Stats
{
    public static class PlayerUnderwaterController
    {

        private static ConcurrentDictionary<long, float> enterUnderWaterO2Level = new ConcurrentDictionary<long, float>();
        private static ConcurrentDictionary<long, float> enterUnderWaterO2Consumption = new ConcurrentDictionary<long, float>();
        private static ConcurrentDictionary<long, bool> enterUnderWater = new ConcurrentDictionary<long, bool>();

        private static float GasRefillRation
        {
            get
            {
                return MyCharacterOxygenComponent.GAS_REFILL_RATION * 1.25f;
            }
        }

        private static float GetNoO2DamageAmount(IMyCharacter character)
        {
            return (character.Definition as MyCharacterDefinition).DamageAmountAtZeroPressure;
        }

        public static float GetEnterUnderWaterO2Level(long playerId)
        {
            if (!enterUnderWaterO2Level.ContainsKey(playerId))
                return enterUnderWaterO2Level[playerId];
            return 0;
        }

        public static void CheckIfO2ControllerIsReady(long playerId)
        {
            if (!enterUnderWaterO2Level.ContainsKey(playerId))
                enterUnderWaterO2Level[playerId] = 0;
        }

        public static void ProcessUnderwater(long playerId, IMyCharacter character, WeatherConstants.EnvironmentDetector currentEnvironmentType)
        {
            CheckIfO2ControllerIsReady(playerId);
            if (currentEnvironmentType == WeatherConstants.EnvironmentDetector.Underwater && !character.IsDead)
            {
                var OxygenComponent = character.Components.Get<MyCharacterOxygenComponent>();
                if (!enterUnderWater.ContainsKey(playerId) || !enterUnderWater[playerId])
                {
                    enterUnderWater[playerId] = true;
                    enterUnderWaterO2Level[playerId] = OxygenComponent.GetGasFillLevel(MyCharacterOxygenComponent.OxygenId);
                    enterUnderWaterO2Consumption[playerId] = (character.Definition as MyCharacterDefinition).OxygenConsumption / OxygenComponent.OxygenCapacity;
                }
                if (MyAPIGateway.Session.SessionSettings.EnableOxygen)
                {
                    if (character.EnabledHelmet)
                    {
                        if (enterUnderWaterO2Level[playerId] > 0)
                            enterUnderWaterO2Level[playerId] -= enterUnderWaterO2Consumption[playerId];
                    }
                    else if (character.CanTakeDamage())
                    {
                        character.DoDamage(GetNoO2DamageAmount(character), MyDamageType.Asphyxia, true);
                    }
                    if (enterUnderWaterO2Level[playerId] < 0)
                        enterUnderWaterO2Level[playerId] = 0;

                    if (OxygenComponent.SuitOxygenLevel < GasRefillRation)
                    {
                        if (ExtendedSurvivalCoreAPI.Registered)
                        {
                            var InventoryObserver = ExtendedSurvivalCoreAPI.GetInventoryObserver(character, 0);
                            if (InventoryObserver != Guid.Empty)
                            {
                                var bottles = ExtendedSurvivalCoreAPI.GetItemInfoByGasId(InventoryObserver, ItensConstants.OXYGEN_ID.DefinitionId);
                                if (bottles != null && bottles.Length > 0)
                                {
                                    var Inventory = character.GetInventory();
                                    foreach (var bottle in bottles)
                                    {
                                        var item = Inventory.GetItemByID(bottle.ItemId);
                                        if (item != null)
                                        {
                                            var gasContainer = item.Content as MyObjectBuilder_GasContainerObject;
                                            if (gasContainer != null)
                                            {
                                                var physicalItem = MyDefinitionManager.Static.GetPhysicalItemDefinition(gasContainer) as MyOxygenContainerDefinition;
                                                if (physicalItem.StoredGasId != ItensConstants.OXYGEN_ID.DefinitionId)
                                                    continue;
                                                float gasAmount = gasContainer.GasLevel * physicalItem.Capacity;
                                                float transferredAmount = Math.Min(gasAmount, (1f - enterUnderWaterO2Level[playerId]) * OxygenComponent.OxygenCapacity);
                                                gasContainer.GasLevel = Math.Max((gasAmount - transferredAmount) / physicalItem.Capacity, 0f);
                                                float trasnferredFillLevel = transferredAmount / OxygenComponent.OxygenCapacity;
                                                enterUnderWaterO2Level[playerId] += trasnferredFillLevel;
                                                if (enterUnderWaterO2Level[playerId] == 1f)
                                                    break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    OxygenComponent.SuitOxygenLevel = enterUnderWaterO2Level[playerId];

                    if (enterUnderWaterO2Level[playerId] <= 0 && character.CanTakeDamage())
                    {
                        character.DoDamage(GetNoO2DamageAmount(character), MyDamageType.Asphyxia, true);
                    }
                }
            }
            else
            {
                enterUnderWater[playerId] = false;
            }
        }

    }

}
