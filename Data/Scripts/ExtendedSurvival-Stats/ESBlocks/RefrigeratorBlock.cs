﻿using Sandbox.Common.ObjectBuilders;
using Sandbox.Game;
using Sandbox.Game.Entities.Blocks;
using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI;
using System;
using System.Linq;
using System.Text;
using VRage.Game;
using VRage.Game.Components;
using VRage.ModAPI;
using VRage.ObjectBuilders;

namespace ExtendedSurvival.Stats
{

    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_OxygenGenerator), false, "SmallBlockRefrigerator", "LargeBlockRefrigerator")]
    public class RefrigeratorBlock : SimpleInventoryLogicComponent<IMyGasGenerator>
    {

        public static string LARGE_BLOCK_NAME
        {
            get
            {
                return LanguageProvider.GetEntry(LanguageEntries.CUBEBLOCK_LARGE_REFRIGERATOR);
            }
        }

        public static string SMALL_BLOCK_NAME
        {
            get
            {
                return LanguageProvider.GetEntry(LanguageEntries.CUBEBLOCK_SMALL_REFRIGERATOR);
            }
        }

        public static string GetFullDescription(bool smallBlock)
        {
            float basePowerUse = smallBlock ? 0.005f : 0.025f;
            return string.Format(
                LanguageProvider.GetEntry(LanguageEntries.CUBEBLOCK_REFRIGERATOR_DESCRIPTION), 
                (basePowerUse * 1000).ToString("#0.0"), 
                (basePowerUse * 1000 * POWER_MULTIPLIER).ToString("#0.0")
            );
        }

        private const float MAS_MASS = int.MaxValue;
        private const float MAS_VOLUME = 1.250f;
        private const float SMALL_BLOCK_MULTIPLIER = 0.5f;

        private const float POWER_MULTIPLIER = 100f;

        public float MaxMass
        {
            get
            {
                return MAS_MASS * (SmallBlock ? SMALL_BLOCK_MULTIPLIER : 1f);
            }
        }

        public float MaxVolume
        {
            get
            {
                return MAS_VOLUME * (SmallBlock ? SMALL_BLOCK_MULTIPLIER : 1f);
            }
        }

        public float InventoryFilledFactor
        {
            get
            {
                return (float)Inventory.CurrentVolume / MaxVolume;
            }
        }

        public float EnergyMultiplier
        {
            get
            {
                return Math.Max(POWER_MULTIPLIER * InventoryFilledFactor, 1f);
            }
        }

        public MyInventory Inventory
        {
            get
            {
                return GetMyInventory(0);
            }
        }

        public bool SmallBlock { get; private set; }

        private bool _inventoryDefined = false;

        protected override void OnInit(MyObjectBuilder_EntityBase objectBuilder)
        {
            base.OnInit(objectBuilder);
            SmallBlock = CurrentEntity.BlockDefinition.SubtypeId == "SmallBlockRefrigerator";
            NeedsUpdate = MyEntityUpdateEnum.EACH_100TH_FRAME;
        }

        public override void UpdateAfterSimulation100()
        {
            base.UpdateAfterSimulation100();
            if (!_inventoryDefined)
            {
                if (Inventory != null)
                {
                    var definition = new MyInventoryComponentDefinition
                    {
                        RemoveEntityOnEmpty = false,
                        MultiplierEnabled = false,
                        MaxItemCount = int.MaxValue,
                        Mass = MaxMass,
                        Volume = MaxVolume,
                        InputConstraint = new MyInventoryConstraint("RefrigeratorInventory", null, true)
                    };
                    foreach (var item in FoodConstants.FOOD_DEFINITIONS.Keys)
                    {
                        if (FoodConstants.FOOD_DEFINITIONS[item].NeedConservation)
                        {
                            definition.InputConstraint.Add(item.DefinitionId);
                        }
                    }
                    foreach (var item in LivestockConstants.DEAD_ANIMALS_IDS)
                    {
                        definition.InputConstraint.Add(item.DefinitionId);
                    }
                    foreach (var item in FishingConstants.FISHS_DEFINITIONS.Keys)
                    {
                        definition.InputConstraint.Add(item.DefinitionId);
                    }
                    definition.InputConstraint.Add(OreConstants.FISH_BONES_ID.DefinitionId);
                    definition.InputConstraint.Add(OreConstants.BONES_ID.DefinitionId);
                    definition.InputConstraint.Add(ItensConstants.SPOILED_MATERIAL_ID.DefinitionId);
                    Inventory.Init(definition);
                }
                _inventoryDefined = true;
            }
            UpdatePowerConsume();
        }

        private void UpdatePowerConsume()
        {
            CurrentEntity.PowerConsumptionMultiplier = EnergyMultiplier;            
            if (MyAPIGateway.Session.IsServer && inventoryObservers.Any())
            {
                ExtendedSurvivalCoreAPI.SetInventoryObserverSpoilStatus(GetObserver(0), !IsPowered, false, 1);
            }
        }

        private MyInventory _inventory;
        protected override MyInventory GetMyInventory(int index)
        {
            if (_inventory == null)
                _inventory = CurrentEntity.GetInventory() as MyInventory;
            return _inventory;
        }

        protected override int GetInventoryCount()
        {
            return 1;
        }

    }

}
