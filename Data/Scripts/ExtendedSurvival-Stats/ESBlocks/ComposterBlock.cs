﻿using Sandbox.Common.ObjectBuilders;
using Sandbox.Game;
using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRage;
using VRage.Game;
using VRage.Game.Components;
using VRage.ModAPI;
using VRage.ObjectBuilders;
using VRageMath;

namespace ExtendedSurvival.Stats
{
    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_OxygenGenerator), false, "LargeBlockComposter")]
    public class ComposterBlock : SimpleInventoryLogicComponent<IMyGasGenerator>
    {

        public static string BLOCK_NAME
        {
            get
            {
                return LanguageProvider.GetEntry(LanguageEntries.CUBEBLOCK_COMPOSTER);
            }
        }

        public static string GetFullDescription()
        {
            float basePowerUse = 0.0125f;
            return string.Format(
                LanguageProvider.GetEntry(LanguageEntries.CUBEBLOCK_COMPOSTER_DESCRIPTION),
                SPOIL_MULTIPLIER,
                (MIN_TIME_TO_GENERATE / 1000).ToString("#0.0"),
                (MAX_TIME_TO_GENERATE / 1000).ToString("#0.0"),
                (basePowerUse * 1000).ToString("#0.0"),
                (basePowerUse * 1000 * POWER_MULTIPLIER).ToString("#0.0")
            );
        }

        public class DecompositionResultDefinition
        {

            public UniqueEntityId Product { get; set; }
            public Vector2 BaseFactor { get; set; }
            public bool AllowDecimal { get; set; }
            public float ChanceToGenerate { get; set; }

        }

        private const float MAS_MASS = int.MaxValue;
        private const float MAS_VOLUME = 1.250f;

        public const float POWER_MULTIPLIER = 100f;
        public const float SPOIL_MULTIPLIER = 10f;

        public const float MAX_TIME_TO_GENERATE = 10000f;
        public const float MIN_TIME_TO_GENERATE = 2500f;
        public static readonly Vector2 CICLE_CONSUMEFACTOR = new Vector2(0.01f, 0.25f);
        public static readonly List<DecompositionResultDefinition> DECOMPOSITION_RESULT = new List<DecompositionResultDefinition>()
        {
            new DecompositionResultDefinition()
            {
                Product =FishingConstants.FISH_BAIT_SMALL_ID,
                BaseFactor = new Vector2(0.4f, 0.8f),
                AllowDecimal = true,
                ChanceToGenerate = 5f
            },
            new DecompositionResultDefinition()
            {
                Product =FishingConstants.FISH_NOBLE_BAIT_ID,
                BaseFactor = new Vector2(0.1f, 0.2f),
                AllowDecimal = true,
                ChanceToGenerate = 2.5f
            }
        };

        public bool HasSpoilMaterial
        {
            get
            {
                if (inventoryObservers.Any() && ExtendedSurvivalCoreAPI.Registered)
                    return ExtendedSurvivalCoreAPI.HasItemInObserver(GetObserver(0), ItensConstants.SPOILED_MATERIAL_ID.DefinitionId);
                return false;
            }
        }

        public float MaxMass
        {
            get
            {
                return MAS_MASS;
            }
        }

        public float MaxVolume
        {
            get
            {
                return MAS_VOLUME;
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

        private bool _inventoryDefined = false;

        protected override void OnInit(MyObjectBuilder_EntityBase objectBuilder)
        {
            base.OnInit(objectBuilder);
            NeedsUpdate = MyEntityUpdateEnum.EACH_100TH_FRAME;
        }

        private long GetGameTime()
        {
            return ExtendedSurvivalCoreAPI.Registered ? ExtendedSurvivalCoreAPI.GetGameTime() : 0;
        }

        public void DoRefreshDeltaTime()
        {
            deltaTime = GetGameTime();
        }

        private long deltaTime = 0;
        private long progress = 0;

        protected override void OnUpdateAfterSimulation100()
        {
            base.OnUpdateAfterSimulation100();
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
                        InputConstraint = new MyInventoryConstraint("ComposterInventory", null, true)
                    };
                    foreach (var item in FoodConstants.FOOD_DEFINITIONS.Keys)
                    {
                        definition.InputConstraint.Add(item.DefinitionId);
                    }
                    foreach (var item in LivestockConstants.DEAD_ANIMALS_IDS)
                    {
                        definition.InputConstraint.Add(item.DefinitionId);
                    }
                    foreach (var item in FishingConstants.FISHS_DEFINITIONS.Keys)
                    {
                        definition.InputConstraint.Add(item.DefinitionId);
                    }
                    foreach (var item in FishingConstants.FISH_BAITS_DEFINITIONS.Keys)
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

        private float GetSpoilMaterialFilledFactor(float amount)
        {
            var volume = amount * 0.4f;
            return volume * 100 / MAS_VOLUME;
        }

        private long GetTimeToGenerate()
        {
            var smAmount = (float)Inventory.GetItemAmount(ItensConstants.SPOILED_MATERIAL_ID.DefinitionId);
            if (smAmount == 0)
                return (long)MAX_TIME_TO_GENERATE;
            var timeToReduce = MAX_TIME_TO_GENERATE * GetSpoilMaterialFilledFactor(smAmount);
            return (long)Math.Max(MIN_TIME_TO_GENERATE, MAX_TIME_TO_GENERATE - timeToReduce);
        }

        private void UpdatePowerConsume()
        {
            CurrentEntity.PowerConsumptionMultiplier = EnergyMultiplier;
            if (MyAPIGateway.Session.IsServer)
            {
                if (inventoryObservers.Any() && ExtendedSurvivalCoreAPI.Registered)
                {
                    ExtendedSurvivalCoreAPI.SetInventoryObserverSpoilStatus(GetObserver(0), true, IsPowered, IsPowered ? SPOIL_MULTIPLIER : 1);
                }
                if (IsPowered && HasSpoilMaterial)
                {
                    if (deltaTime == 0)
                        DoRefreshDeltaTime();
                    progress += GetGameTime() - deltaTime;
                    DoRefreshDeltaTime();
                    var timeToUse = GetTimeToGenerate();
                    if (progress > timeToUse)
                    {
                        var consumeAmount = (MyFixedPoint)CICLE_CONSUMEFACTOR.GetRandom();
                        var inventoryAmount = Inventory.GetItemAmount(ItensConstants.SPOILED_MATERIAL_ID.DefinitionId);
                        if (consumeAmount > inventoryAmount)
                            consumeAmount = inventoryAmount;
                        Inventory.RemoveItemsOfType(consumeAmount, ItensConstants.GetPhysicalObjectBuilder(ItensConstants.SPOILED_MATERIAL_ID));
                        progress -= timeToUse;
                        foreach (var item in DECOMPOSITION_RESULT)
                        {
                            if (CheckCanGenerate(item.ChanceToGenerate))
                            {
                                var totalToGenerate = CalcResultValueToGenerate(item.BaseFactor, item.AllowDecimal);
                                Inventory.AddMaxItems(totalToGenerate, ItensConstants.GetPhysicalObjectBuilder(item.Product));
                                break;
                            }
                        }
                    }
                }
                else
                {
                    progress = 0; 
                    DoRefreshDeltaTime();
                }
            }
        }

        private static float GetRandomNumber(float minimum, float maximum, bool allowDecimal)
        {
            if (allowDecimal)
                return (float)rnd.NextDouble() * (maximum - minimum) + minimum;
            return rnd.Next((int)minimum, (int)maximum);
        }

        private float CalcResultValueToGenerate(Vector2 valueRange, bool allowDecimal)
        {
            var baseValue = GetRandomNumber(valueRange.X, valueRange.Y, allowDecimal);
            if (!allowDecimal)
                baseValue = (int)baseValue;
            return baseValue;
        }

        private static readonly Random rnd = new Random();
        private static bool CheckCanGenerate(float chance)
        {
            return rnd.Next(1, 101) <= chance;
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
