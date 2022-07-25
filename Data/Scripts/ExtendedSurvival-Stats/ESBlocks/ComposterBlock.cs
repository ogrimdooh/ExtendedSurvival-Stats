using Sandbox.Common.ObjectBuilders;
using Sandbox.Game;
using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using VRage.Game;
using VRage.Game.Components;
using VRage.ModAPI;
using VRage.ObjectBuilders;
using VRageMath;

namespace ExtendedSurvival
{
    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_OxygenGenerator), false, "LargeBlockComposter")]
    public class ComposterBlock : SimpleInventoryLogicComponent<IMyGasGenerator>
    {

        private class DecompositionResultDefinition
        {

            public UniqueEntityId Product { get; set; }
            public Vector2 BaseFactor { get; set; }
            public bool AllowDecimal { get; set; }
            public float ChanceToGenerate { get; set; }

        }

        private const float MAS_MASS = int.MaxValue;
        private const float MAS_VOLUME = 1.250f;

        private const float POWER_MULTIPLIER = 100f;
        private const float SPOIL_MULTIPLIER = 10f;

        private const float TIME_TO_GENERATE = 5000f;
        private static readonly List<DecompositionResultDefinition> DECOMPOSITION_RESULT = new List<DecompositionResultDefinition>()
        {
            new DecompositionResultDefinition()
            {
                Product =ItensConstants.FISH_BAIT_SMALL_ID,
                BaseFactor = new Vector2(0.4f, 0.8f),
                AllowDecimal = true,
                ChanceToGenerate = 15
            },
            new DecompositionResultDefinition()
            {
                Product =ItensConstants.FISH_NOBLE_BAIT_ID,
                BaseFactor = new Vector2(0.1f, 0.2f),
                AllowDecimal = true,
                ChanceToGenerate = 7.5f
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

        private DateTime deltaTime = DateTime.Now;
        private float progress = 0;

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
                        InputConstraint = new MyInventoryConstraint("RefrigeratorInventory", null, true)
                    };
                    foreach (var item in ItensConstants.FOODS_IDS)
                    {
                        definition.InputConstraint.Add(item.DefinitionId);
                    }
                    definition.InputConstraint.Add(ItensConstants.FISH_BAIT_SMALL_ID.DefinitionId);
                    definition.InputConstraint.Add(ItensConstants.FISH_NOBLE_BAIT_ID.DefinitionId);
                    definition.InputConstraint.Add(ItensConstants.FISH_BONES_ID.DefinitionId);
                    definition.InputConstraint.Add(ItensConstants.BOWL_ID.DefinitionId);
                    Inventory.Init(definition);
                }
                _inventoryDefined = true;
            }
            UpdatePowerConsume();
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
                    var spendTime = DateTime.Now - deltaTime;
                    progress += (float)spendTime.TotalMilliseconds;
                    if (progress > TIME_TO_GENERATE)
                    {
                        progress -= TIME_TO_GENERATE;
                        foreach (var item in DECOMPOSITION_RESULT)
                        {
                            if (CheckCanGenerate(item.ChanceToGenerate))
                            {
                                var totalToGenerate = CalcResultValueToGenerate(item.BaseFactor, item.AllowDecimal);
                                Inventory.AddMaxItems(totalToGenerate, ItensConstants.GetPhysicalObjectBuilder(item.Product));
                            }
                        }
                    }
                }
                else
                    progress = 0;
                deltaTime = DateTime.Now;
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
