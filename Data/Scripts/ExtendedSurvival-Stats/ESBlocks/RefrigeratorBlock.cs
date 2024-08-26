using Sandbox.Common.ObjectBuilders;
using Sandbox.Game;
using Sandbox.Game.Entities.Blocks;
using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRage.Game;
using VRage.Game.Components;
using VRage.ModAPI;
using VRage.Noise.Combiners;
using VRage.ObjectBuilders;

namespace ExtendedSurvival.Stats
{

    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_OxygenGenerator), false, "SmallBlockRefrigerator", "LargeBlockRefrigerator", "LargeBlockLargeRefrigerator")]
    public class RefrigeratorBlock : SimpleInventoryLogicComponent<IMyGasGenerator>
    {

        private const string Power = "PowerEfficiency";

        public enum RefrigeratorSize
        {

            Small, 
            Large, 
            ExtraLarge

        }

        public static string EXTRALARGE_BLOCK_NAME
        {
            get
            {
                return LanguageProvider.GetEntry(LanguageEntries.CUBEBLOCK_EXTRALARGE_REFRIGERATOR);
            }
        }

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

        public static Dictionary<RefrigeratorSize, float> POWER_USE = new Dictionary<RefrigeratorSize, float>()
        {
            { RefrigeratorSize.Small, 0.005f },
            { RefrigeratorSize.Large, 0.025f },
            { RefrigeratorSize.ExtraLarge, 0.125f }
        };

        public static Dictionary<RefrigeratorSize, float> POWER_MULTIPLIER = new Dictionary<RefrigeratorSize, float>()
        {
            { RefrigeratorSize.Small, 37.5f },
            { RefrigeratorSize.Large, 75f },
            { RefrigeratorSize.ExtraLarge, 112.5f }
        };

        public static Dictionary<RefrigeratorSize, float> MAS_VOLUME = new Dictionary<RefrigeratorSize, float>()
        {
            { RefrigeratorSize.Small, 0.5f },
            { RefrigeratorSize.Large, 1.5f },
            { RefrigeratorSize.ExtraLarge, 4.5f }
        };

        private const float MAS_MASS = int.MaxValue;

        public static string GetFullDescription(RefrigeratorSize size)
        {
            float basePowerUse = POWER_USE[size];
            return string.Format(
                LanguageProvider.GetEntry(LanguageEntries.CUBEBLOCK_REFRIGERATOR_DESCRIPTION), 
                (basePowerUse * 1000).ToString("#0.0"), 
                (basePowerUse * 1000 * POWER_MULTIPLIER[size]).ToString("#0.0")
            );
        }

        public float MaxMass
        {
            get
            {
                return MAS_MASS * MyAPIGateway.Session.BlocksInventorySizeMultiplier;
            }
        }

        public float MaxVolume
        {
            get
            {
                return MAS_VOLUME[Size] * MyAPIGateway.Session.BlocksInventorySizeMultiplier;
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
                return Math.Max(POWER_MULTIPLIER[Size] * InventoryFilledFactor, 1f);
            }
        }

        public MyInventory Inventory
        {
            get
            {
                return GetMyInventory(0);
            }
        }

        public RefrigeratorSize Size { get; private set; }

        private bool _inventoryDefined = false;

        protected override void OnInit(MyObjectBuilder_EntityBase objectBuilder)
        {
            base.OnInit(objectBuilder);
            switch (CurrentEntity.BlockDefinition.SubtypeId)
            {
                case "SmallBlockRefrigerator":
                    Size = RefrigeratorSize.Small;
                    break;
                case "LargeBlockLargeRefrigerator":
                    Size = RefrigeratorSize.ExtraLarge;
                    break;
                default:
                    Size = RefrigeratorSize.Large;
                    break;
            }
            NeedsUpdate = MyEntityUpdateEnum.EACH_100TH_FRAME;
            CurrentEntity.OnUpgradeValuesChanged += OnUpgradeValuesChanged;
            ((MyResourceSinkComponent)CurrentEntity.ResourceSink).RequiredInputChanged += OnRequiredInputChanged;
            CurrentEntity.AddUpgradeValue(Power, 1f);
        }

        private float power = 1.0f;
        private void OnUpgradeValuesChanged()
        {
            if (!CurrentEntity.UpgradeValues.TryGetValue(Power, out power))
                power = 1;
        }

        private void OnRequiredInputChanged(MyDefinitionId unused1, MyResourceSinkComponent unused2, float unused3, float unused4)
        {
            CurrentEntity.RefreshCustomInfo();
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
            CurrentEntity.PowerConsumptionMultiplier = EnergyMultiplier / power;            
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
