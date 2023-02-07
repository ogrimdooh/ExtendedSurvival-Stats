using Sandbox.Common.ObjectBuilders;
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
using VRage.Game.ModAPI;
using VRage.ModAPI;
using VRage.ObjectBuilders;
using VRageMath;

namespace ExtendedSurvival.Stats
{

    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_OxygenGenerator), false, "FishTrap")]
    public class FishTrapBlock : SimpleInventoryLogicComponent<IMyGasGenerator>
    {

        public static string BLOCK_NAME
        {
            get
            {
                return LanguageProvider.GetEntry(LanguageEntries.CUBEBLOCK_FISHTRAP);
            }
        }

        public static string GetFullDescription()
        {
            float basePowerUse = 0.005f;
            return string.Format(
                LanguageProvider.GetEntry(LanguageEntries.CUBEBLOCK_FISHTRAP_DESCRIPTION), 
                (TIME_TO_GENERATE / 1000).ToString("#0.0"), 
                (basePowerUse * 1000).ToString("#0.0"), 
                (basePowerUse * 1000 * POWER_MULTIPLIER).ToString("#0.0")
            );
        }

        public static readonly string[] COMPOSTERS_IDS = new string[] { "LargeBlockComposter" };

        public class CollectorsToConnect
        {

            public List<float> depths = new List<float>();

            public int Total
            {
                get
                {
                    return depths.Count;
                }
            }

        }

        public class FishingBaitDefinition
        {

            public Vector2 ConsumeFactor { get; set; }
            public bool AllowDecimal { get; set; }
            public int MaxGenerates { get; set; }
            public List<FishingResultDefinition> Results { get; set; }

        }

        public class FishingResultDefinition
        {

            public UniqueEntityId Product { get; set; }
            public Vector2 BaseFactor { get; set; }
            public bool AllowDecimal { get; set; }
            public float ChanceToGenerate { get; set; }
            public float MinDepth { get; set; }
            public string[] RequiredPlanets { get; set; } = new string[] { };
            public string[] BlockedPlanets { get; set; } = new string[] { };

        }

        private const float SPOIL_MULTIPLIER = 0.5f;
        private const float MAS_MASS = int.MaxValue;
        private const float MAS_VOLUME = 2.587f;

        private const float POWER_MULTIPLIER = 100f;
        private const long TIME_TO_GENERATE = 5000;
        public static readonly Dictionary<UniqueEntityId, FishingBaitDefinition> BAIT_RESULT = new Dictionary<UniqueEntityId, FishingBaitDefinition>()
        {
            {
                FishingConstants.FISH_BAIT_SMALL_ID,
                new FishingBaitDefinition()
                {
                    ConsumeFactor = new Vector2(0.1f, 0.5f),
                    AllowDecimal = true,
                    MaxGenerates = 1,
                    Results = new List<FishingResultDefinition>()
                    {
                        new FishingResultDefinition()
                        {
                            Product = FishingConstants.FISH_ID,
                            BaseFactor = new Vector2(1,2),
                            AllowDecimal = false,
                            ChanceToGenerate = 30,
                            MinDepth = 2f,
                            RequiredPlanets = new string[]{ "EarthLike" }
                        },
                        new FishingResultDefinition()
                        {
                            Product = FishingConstants.SHRIMP_ID,
                            BaseFactor = new Vector2(1,2),
                            AllowDecimal = false,
                            ChanceToGenerate = 15,
                            MinDepth = 12f,
                            RequiredPlanets = new string[]{ "EarthLike" }
                        },
                        new FishingResultDefinition()
                        {
                            Product = FishingConstants.NOBLEFISH_ID,
                            BaseFactor = new Vector2(1,1),
                            AllowDecimal = false,
                            ChanceToGenerate = 5,
                            MinDepth = 24f,
                            RequiredPlanets = new string[]{ "EarthLike" }
                        },
                        new FishingResultDefinition()
                        {
                            Product = FishingConstants.ALIENFISH_ID,
                            BaseFactor = new Vector2(1,2),
                            AllowDecimal = false,
                            ChanceToGenerate = 30,
                            MinDepth = 2f,
                            BlockedPlanets = new string[]{ "EarthLike" }
                        },
                        new FishingResultDefinition()
                        {
                            Product = FishingConstants.ALIENNOBLEFISH_ID,
                            BaseFactor = new Vector2(1,1),
                            AllowDecimal = false,
                            ChanceToGenerate = 5,
                            MinDepth = 24f,
                            BlockedPlanets = new string[]{ "EarthLike" }
                        }
                    }
                }
            },
            {
                FishingConstants.FISH_NOBLE_BAIT_ID,
                new FishingBaitDefinition()
                {
                    ConsumeFactor = new Vector2(0.1f, 0.5f),
                    AllowDecimal = true,
                    MaxGenerates = 2,
                    Results = new List<FishingResultDefinition>()
                    {
                        new FishingResultDefinition()
                        {
                            Product = FishingConstants.FISH_ID,
                            BaseFactor = new Vector2(1,2),
                            AllowDecimal = false,
                            ChanceToGenerate = 60,
                            MinDepth = 2f,
                            RequiredPlanets = new string[]{ "EarthLike" }
                        },
                        new FishingResultDefinition()
                        {
                            Product = FishingConstants.SHRIMP_ID,
                            BaseFactor = new Vector2(1,2),
                            AllowDecimal = false,
                            ChanceToGenerate = 30,
                            MinDepth = 12f,
                            RequiredPlanets = new string[]{ "EarthLike" }
                        },
                        new FishingResultDefinition()
                        {
                            Product = FishingConstants.NOBLEFISH_ID,
                            BaseFactor = new Vector2(1,1),
                            AllowDecimal = false,
                            ChanceToGenerate = 10,
                            MinDepth = 24f,
                            RequiredPlanets = new string[]{ "EarthLike" }
                        },
                        new FishingResultDefinition()
                        {
                            Product = FishingConstants.ALIENFISH_ID,
                            BaseFactor = new Vector2(1,2),
                            AllowDecimal = false,
                            ChanceToGenerate = 60,
                            MinDepth = 2f,
                            BlockedPlanets = new string[]{ "EarthLike" }
                        },
                        new FishingResultDefinition()
                        {
                            Product = FishingConstants.ALIENNOBLEFISH_ID,
                            BaseFactor = new Vector2(1,1),
                            AllowDecimal = false,
                            ChanceToGenerate = 10,
                            MinDepth = 24f,
                            BlockedPlanets = new string[]{ "EarthLike" }
                        }
                    }
                }
            }
        };

        public MyInventory Inventory
        {
            get
            {
                return GetMyInventory(0);
            }
        }

        public bool IsUnderwater
        {
            get
            {
                return WaterModAPI.Registered && WaterModAPI.IsUnderwater(CurrentEntity.GetPosition());
            }
        }

        private bool _inventoryDefined = false;
        private long deltaTime = 0;
        private long progress = 0;
        private CollectorsToConnect totalConector = new CollectorsToConnect();
        private bool isWorking = false;

        private long GetGameTime()
        {
            return ExtendedSurvivalCoreAPI.Registered ? ExtendedSurvivalCoreAPI.GetGameTime() : 0;
        }

        public void DoRefreshDeltaTime()
        {
            deltaTime = GetGameTime();
        }

        public void DoRefreshLastCompostersUpdate()
        {
            lastUpdate = GetGameTime();
        }

        protected const long MIN_TO_UPDATE = 10000;
        protected long lastUpdate = 0;
        protected List<IMySlimBlock> composters = new List<IMySlimBlock>();
        protected virtual void RefreshComposters()
        { 
            try
            {
                if (ExtendedSurvivalCoreAPI.Registered)
                {
                    var spendFromLastUpdate = GetGameTime() - lastUpdate;
                    if (spendFromLastUpdate > MIN_TO_UPDATE)
                    {
                        DoRefreshLastCompostersUpdate();
                        composters.Clear();
                        Grid.GetBlocks(composters, x => COMPOSTERS_IDS.Contains(x.BlockDefinition.Id.SubtypeName));
                    }
                }
            }
            catch (System.Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(GetType(), ex);
            }
        }

        protected override void OnInit(MyObjectBuilder_EntityBase objectBuilder)
        {
            base.OnInit(objectBuilder);
            NeedsUpdate = MyEntityUpdateEnum.EACH_100TH_FRAME;
        }

        private void GetAmmountOfConnector()
        {
            totalConector.depths.Clear();
            var underwaterCollectors = ExtendedSurvivalCoreAPI.GetUnderwaterCollectors(Grid.EntityId);
            if (underwaterCollectors.Length > 0)
            {
                foreach (var item in underwaterCollectors)
                {
                    var collector = item.FatBlock as IMyCollector;
                    if (collector != null)
                    {
                        var airtight = collector.CubeGrid.IsRoomAtPositionAirtight(collector.Position) ? true : collector.CubeGrid.IsRoomAtPositionAirtight(collector.Position + (Vector3I)Base6Directions.Directions[(int)collector.Orientation.Forward]);
                        if (!airtight)
                        {
                            var upBlock = collector.CubeGrid.GetCubeBlock(collector.Position + (Vector3I)Base6Directions.Directions[(int)collector.Orientation.Forward]);
                            if (upBlock == null)
                            {
                                var collectorInventory = collector.GetInventory();
                                if (collectorInventory.CanTransferItemTo(_inventory, ItensConstants.ICE_ID.DefinitionId))
                                {
                                    totalConector.depths.Add((float)Math.Round(WaterModAPI.GetDepth(collector.GetPosition()).Value * -1, 2));
                                }
                            }
                        }
                    }
                }
            }
        }

        protected override void OnUpdateAfterSimulation100()
        {
            base.OnUpdateAfterSimulation100();
            if (!_inventoryDefined)
            {
                var definition = new MyInventoryComponentDefinition
                {
                    RemoveEntityOnEmpty = false,
                    MultiplierEnabled = false,
                    MaxItemCount = int.MaxValue,
                    Mass = MAS_MASS,
                    Volume = MAS_VOLUME,
                    InputConstraint = new MyInventoryConstraint("FishTrap", null, true)
                };
                foreach (var item in FishingConstants.FISHS_DEFINITIONS.Keys)
                {
                    definition.InputConstraint.Add(item.DefinitionId);
                }
                foreach (var item in FishingConstants.FISH_BAITS_DEFINITIONS.Keys)
                {
                    definition.InputConstraint.Add(item.DefinitionId);
                }
                definition.InputConstraint.Add(OreConstants.FISH_BONES_ID.DefinitionId);
                definition.InputConstraint.Add(ItensConstants.SPOILED_MATERIAL_ID.DefinitionId);
                Inventory.Init(definition);
                _inventoryDefined = true;
            }
            if (MyAPIGateway.Session.IsServer)
            {
                if (CurrentEntity.IsWorking && IsUnderwater && ExtendedSurvivalCoreAPI.Registered)
                {
                    isWorking = true;
                    GetAmmountOfConnector();
                    var planetAtRange = ExtendedSurvivalCoreAPI.GetPlanetAtRange(Grid.GetPosition());
                    if (IsPowered && Grid != null && planetAtRange != null && totalConector.Total > 0)
                    {
                        var planetType = planetAtRange.Entity.Name;
                        if (deltaTime == 0)
                            DoRefreshDeltaTime();
                        progress += GetGameTime() - deltaTime;
                        DoRefreshDeltaTime();
                        if (progress > TIME_TO_GENERATE)
                        {
                            progress -= TIME_TO_GENERATE;
                            if (inventoryObservers.Any())
                            {
                                int countGenerated = 0;
                                bool needBaits = false;
                                foreach (var key in BAIT_RESULT.Keys)
                                {
                                    var baitItens = ExtendedSurvivalCoreAPI.GetItemInfoByItemType(GetObserver(0), key.DefinitionId);
                                    if (baitItens != null && baitItens.Any())
                                    {
                                        var baitItem = baitItens.FirstOrDefault();
                                        var baitPhysicalItem = Inventory.GetItemByID(baitItem.ItemId);
                                        if (baitPhysicalItem != null)
                                        {
                                            var totalToConsume = CalcResultValueToGenerate(BAIT_RESULT[key].ConsumeFactor, BAIT_RESULT[key].AllowDecimal);
                                            if ((float)baitPhysicalItem.Value.Amount > totalToConsume)
                                            {
                                                var validResults = BAIT_RESULT[key].Results.Where(x =>
                                                    totalConector.depths.Any(y => y >= x.MinDepth) &&
                                                    (x.BlockedPlanets.Length == 0 || !x.BlockedPlanets.Any(y => planetType.Contains(y))) &&
                                                    (x.RequiredPlanets.Length == 0 || x.RequiredPlanets.Any(y => planetType.Contains(y)))
                                                ).OrderBy(x => x.ChanceToGenerate).ToArray();
                                                if (validResults.Length > 0)
                                                {
                                                    Inventory.RemoveItems(baitItem.ItemId, (MyFixedPoint)totalToConsume);
                                                    foreach (var item in validResults)
                                                    {
                                                        if (CheckCanGenerate(item.ChanceToGenerate))
                                                        {
                                                            var totalToGenerate = CalcResultValueToGenerate(item.BaseFactor, item.AllowDecimal);
                                                            Inventory.AddMaxItems(totalToGenerate, ItensConstants.GetPhysicalObjectBuilder(item.Product));
                                                            countGenerated++;
                                                        }
                                                        if (countGenerated >= BAIT_RESULT[key].MaxGenerates)
                                                            break;
                                                    }
                                                }
                                                break;
                                            }
                                            else
                                            {
                                                needBaits = true;
                                            }
                                        }
                                        else
                                        {
                                            needBaits = true;
                                        }
                                    }
                                    else
                                    {
                                        needBaits = true;
                                    }
                                }
                                if (countGenerated == 0 && needBaits)
                                {
                                    RefreshComposters();
                                    foreach (var block in composters.Where(x => x.FatBlock != null && x.FatBlock.GetInventory().CanTransferItemTo(Inventory, BAIT_RESULT.Keys.First().DefinitionId)))
                                    {
                                        var targetInv = block.FatBlock.GetInventory();
                                        bool baitAdded = false;
                                        foreach (var key in BAIT_RESULT.Keys)
                                        {
                                            var amount = targetInv.GetItemAmount(key.DefinitionId);
                                            if (amount > 0)
                                            {
                                                var amountAdded = (Inventory as IMyInventory).AddMaxItems(amount, ItensConstants.GetPhysicalObjectBuilder(key));
                                                targetInv.RemoveItemsOfType(amountAdded, key.DefinitionId);
                                                baitAdded = true;
                                            }
                                        }
                                        if (baitAdded)
                                            break;
                                    }
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
                else
                {
                    progress = 0;
                    isWorking = false;
                    DoRefreshDeltaTime();
                }
            }
            UpdatePowerConsume();
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

        private void UpdatePowerConsume()
        {
            if (MyAPIGateway.Session.IsServer)
            {
                if (inventoryObservers.Any() && ExtendedSurvivalCoreAPI.Registered)
                {
                    ExtendedSurvivalCoreAPI.SetInventoryObserverSpoilStatus(GetObserver(0), true, false, isWorking ? SPOIL_MULTIPLIER : 1.0f);
                }
            }
            CurrentEntity.PowerConsumptionMultiplier = isWorking ? POWER_MULTIPLIER : 1.0f;
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
