using Sandbox.Common.ObjectBuilders;
using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI;
using VRage.Game.Components;
using VRage.ObjectBuilders;
using Sandbox.Game;
using SpaceEngineers.Game.ModAPI;
using System;
using VRage.ModAPI;
using System.Collections.Generic;
using VRage;
using VRageMath;
using VRage.Utils;
using System.Linq;
using Sandbox.Common.ObjectBuilders.Definitions;
using System.Text;

namespace ExtendedSurvival.Stats
{
    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_OxygenFarm), false, "LargeBlockTreeFarm")]
    public class TreeFarmBlock : BaseInventoryLogicComponent<IMyOxygenFarm>
    {

        public const string BLOCK_NAME = "Tree Farm";

        public static string GetFullDescription()
        {
            var values = new StringBuilder();
            values.AppendLine(string.Format(
                "Tree farms are blocks that can grow and keep trees alive to produce fruit when you have ice and fertilizer in your inventory. " +
                "Rotting time decreases by {0}% when producing.", (FarmConstants.BASE_SPOILMULTIPLIER_WITH_TREE * 100).ToString("#0.0")
            ));
            return values.ToString();
        }

        private const float MAS_MASS = int.MaxValue;
        private const float MAS_VOLUME = 4;

        public static float MaxMass
        {
            get
            {
                return MAS_MASS * MyAPIGateway.Session.SessionSettings.BlocksInventorySizeMultiplier;
            }
        }

        public static float MaxVolume
        {
            get
            {
                return MAS_VOLUME * MyAPIGateway.Session.SessionSettings.BlocksInventorySizeMultiplier;
            }
        }

        public MyInventory Inventory
        {
            get
            {
                return GetMyInventory(0);
            }
        }

        private readonly Dictionary<uint, float> _progress = new Dictionary<uint, float>();

        private float _totalSun = 0;
        private MyFixedPoint _totalFertilizer = 0;
        private MyFixedPoint _totalIce = 0;

        private Guid DoCreateNewObserver(int index)
        {
            var id = ExtendedSurvivalCoreAPI.AddInventoryObserver(CurrentEntity, index);
            ExtendedSurvivalCoreAPI.RegisterInventoryObserverUpdateCallback(
                id,
                (Guid observerId, MyInventory inventory, IMyEntity owner, TimeSpan spendTime) =>
                {
                    var spoilMultiplier = HasTree() ? FarmConstants.BASE_SPOILMULTIPLIER_WITH_TREE : 1;
                    ExtendedSurvivalCoreAPI.SetInventoryObserverSpoilStatus(observerId, true, false, spoilMultiplier);
                    if (!MyAPIGateway.Session.CreativeMode && CurrentEntity.Enabled && CurrentEntity.IsFunctional)
                    {
                        TryGenerateFood((float)spendTime.TotalMilliseconds);
                    }
                }
            );
            return id;
        }

        protected override Guid CreateNewObserver(int index)
        {
            if (ExtendedSurvivalCoreAPI.Registered)
            {
                return DoCreateNewObserver(index);
            }
            else
            {
                ExtendedSurvivalStatsSession.AddToInvokeAfterCoreApiLoaded(() => {
                    var id = DoCreateNewObserver(index);
                    if (id != Guid.Empty)
                        inventoryObservers.Add(index, id);
                });
            }
            return Guid.Empty;
        }


        private bool HasTree()
        {
            if (CurrentEntity.Enabled && CurrentEntity.IsFunctional)
            {
                foreach (var item in FarmConstants.TREE_DEFINITIONS.Keys)
                {
                    if (!FarmConstants.TREE_DEFINITIONS[item].IsGrowthRecipe && HasItem(item))
                        return true;
                }
            }
            return false;
        }

        private void TryGenerateFood(float timeDeltaMilliseconds)
        {
            if (CurrentEntity.IsFunctional && CurrentEntity.IsWorking)
            {
                if (Inventory.ItemCount > 0)
                {
                    RefreshTotalBaseItens();
                    if (_totalFertilizer > 0 && _totalIce > 0)
                    {
                        // Generate Food and Inc Progress
                        var needDelte = new List<uint>();
                        var keysToSee = _progress.Keys.ToArray();
                        for (int i = 0; i < keysToSee.Length; i++)
                        {
                            var key = keysToSee[i];
                            if (HasRequiredItens(key))
                            {
                                _progress[key] += timeDeltaMilliseconds;
                                var extraInfo = ExtendedSurvivalCoreAPI.GetItemInfoByItemId(GetObserver(0), key);
                                if (extraInfo != null)
                                {
                                    var uniqueId = new UniqueEntityId(extraInfo.ExtraInfo.DefinitionId);
                                    if (_progress[key] > FarmConstants.TREE_DEFINITIONS[uniqueId].TimeToProduceInMs)
                                    {
                                        _progress[key] -= FarmConstants.TREE_DEFINITIONS[uniqueId].TimeToProduceInMs;
                                        MyAPIGateway.Utilities.InvokeOnGameThread(() =>
                                        {
                                            GenerateProducts(key, extraInfo.ExtraInfo);
                                        });
                                    }
                                }
                            }
                            else
                                needDelte.Add(key);
                        }
                        // Remove Progress When Needed
                        foreach (var key in needDelte)
                        {
                            _progress.Remove(key);
                        }
                        // Check to Start New Production
                        foreach (var key in FarmConstants.TREE_DEFINITIONS.Keys)
                        {
                            var entries = ExtendedSurvivalCoreAPI.GetItemInfoByItemType(GetObserver(0), key.DefinitionId);
                            if (entries != null && entries.Any(x => !_progress.ContainsKey(x.ItemId)))
                            {
                                foreach (var item in entries.Where(x => !_progress.ContainsKey(x.ItemId)))
                                {
                                    _progress.Add(item.ItemId, 0);
                                }
                            }
                        }
                    }
                    else
                        ResetProgress(); // No Ice or Fertilizer reset progress
                }
                else
                    ResetItensAmmount();
            }
        }

        private MyFixedPoint GetIceToRemove(UniqueEntityId key)
        {
            var baseFactor = FarmConstants.TREE_DEFINITIONS[key].IceFactor;
            return (MyFixedPoint)(baseFactor + (_totalSun * baseFactor)) * GetIncriseMultiplier();
        }

        private MyFixedPoint GetFertilizerToRemove(UniqueEntityId key)
        {
            var baseFactor = FarmConstants.TREE_DEFINITIONS[key].FertilizerFactor;
            return (MyFixedPoint)(baseFactor + (_totalSun * baseFactor)) * GetIncriseMultiplier();
        }

        private float GetIncriseMultiplier()
        {
            return 1 + (_progress.Count > 1 ? FarmConstants.BASE_INCRESE_COST * (_progress.Count - 1) : 0);
        }

        private bool HasSuperFertilizer()
        {
            return HasItem(FarmConstants.POWER_FERTILIZER);
        }

        private bool HasItem(UniqueEntityId id)
        {
            return Inventory.GetItemAmount(id.DefinitionId) > 0;
        }

        private bool GetFirstFertilizer(out UniqueEntityId fertilizer)
        {
            fertilizer = null;
            foreach (var item in FarmConstants.FERTILIZERS)
            {
                if (HasItem(item))
                {
                    fertilizer = item;
                    return true;
                }
            }
            return false;
        }

        private void GenerateProducts(uint itemId, ExtendedSurvivalCoreAPI.ItemExtraInfo item)
        {
            var uniqueId = new UniqueEntityId(item.DefinitionId);
            var fertilizerToRemove = GetFertilizerToRemove(uniqueId);
            UniqueEntityId fertilerToUse = null;
            if (GetFirstFertilizer(out fertilerToUse))
            {
                var iceToRemove = GetIceToRemove(uniqueId);
                var iceAmmount = Inventory.GetItemAmount(ItensConstants.ICE_ID.DefinitionId);
                if (iceToRemove > iceAmmount)
                    iceToRemove = iceAmmount;
                Inventory.RemoveItemsOfType(iceToRemove, ItensConstants.GetPhysicalObjectBuilder(ItensConstants.ICE_ID));
                if (HasSuperFertilizer())
                {
                    fertilerToUse = FarmConstants.POWER_FERTILIZER;
                }
                else if (HasItem(FarmConstants.TREE_DEFINITIONS[uniqueId].PreferredFertilizer))
                {
                    fertilerToUse = FarmConstants.TREE_DEFINITIONS[uniqueId].PreferredFertilizer;
                }
                var fertilizerAmmount = Inventory.GetItemAmount(fertilerToUse.DefinitionId);
                if (fertilizerToRemove > fertilizerAmmount)
                    fertilizerToRemove = fertilizerAmmount;
                Inventory.RemoveItemsOfType(fertilizerToRemove, ItensConstants.GetPhysicalObjectBuilder(fertilerToUse));
                var inventoryItem = Inventory.GetItemByID(itemId).Value;
                var gasContainer = inventoryItem.Content as MyObjectBuilder_GasContainerObject;
                if (gasContainer != null && gasContainer.GasLevel < 1)
                {
                    if (inventoryItem.Amount < 1)
                        inventoryItem.Amount = 1;
                    gasContainer.GasLevel += FarmConstants.TREE_DEFINITIONS[uniqueId].ChargeAmmount;
                    if (gasContainer.GasLevel > 1)
                        gasContainer.GasLevel = 1;
                }
                if (_totalSun > 0)
                {
                    if (!FarmConstants.TREE_DEFINITIONS[uniqueId].RequiredFullCharge || gasContainer.GasLevel == 1)
                    {
                        if (FarmConstants.TREE_DEFINITIONS[uniqueId].IsGrowthRecipe)
                        {
                            var result = FarmConstants.TREE_DEFINITIONS[uniqueId].Results[0];
                            if (CheckCanGenerate(result.ChanceToGenerate))
                            {
                                Inventory.ReplaceItem(itemId, result.GetBuilder());
                            }
                        }
                        else
                        {
                            for (int i = 0; i < FarmConstants.TREE_DEFINITIONS[uniqueId].Results.Count; i++)
                            {
                                var result = FarmConstants.TREE_DEFINITIONS[uniqueId].Results[i];
                                if (CheckCanGenerate(result.ChanceToGenerate))
                                {
                                    var totalToGenerate = CalcResultValueToGenerate(result.BaseFactor, result.SunMultiplierFactor, result.AllowDecimal);
                                    if (fertilerToUse == FarmConstants.POWER_FERTILIZER)
                                        totalToGenerate *= FarmConstants.POWER_FERTILIZER_MULTIPLIER;
                                    else if (fertilerToUse == FarmConstants.TREE_DEFINITIONS[uniqueId].PreferredFertilizer)
                                        totalToGenerate *= FarmConstants.PREFER_FERTILIZER_MULTIPLIER;
                                    Inventory.AddMaxItems(totalToGenerate, result.GetBuilder(), result.AllowDecimal);
                                }
                            }
                        }
                    }
                }
            }
        }

        private static bool CheckCanGenerate(float chance)
        {
            return MyUtils.GetRandomFloat(1, 101) <= chance;
        }

        private static float GetRandomNumber(float minimum, float maximum, bool allowDecimal)
        {
            if (allowDecimal)
                return MyUtils.GetRandomFloat(minimum, maximum);
            return MyUtils.GetRandomInt((int)minimum, (int)maximum);
        }

        private float CalcResultValueToGenerate(Vector2 valueRange, float sunMultiplier, bool allowDecimal)
        {
            var baseValue = GetRandomNumber(valueRange.X, valueRange.Y, allowDecimal);
            var sunBonus = baseValue * sunMultiplier * _totalSun;
            if (!allowDecimal)
            {
                baseValue = (float)Math.Round(baseValue, 0);
                sunBonus = (float)Math.Round(sunBonus, 0);
            }
            return baseValue + sunBonus;
        }

        private bool HasRequiredItens(uint key)
        {
            return ExtendedSurvivalCoreAPI.GetItemInfoByItemId(GetObserver(0), key) != null;
        }

        private void ResetProgress()
        {
            _progress.Clear();
        }

        private void ResetItensAmmount()
        {
            _totalFertilizer = 0;
            _totalIce = 0;
        }

        private void RefreshTotalBaseItens()
        {
            _totalSun = CurrentEntity.GetOutput();
            _totalFertilizer = 0;
            foreach (var item in FarmConstants.FERTILIZERS)
            {
                _totalFertilizer += Inventory.GetItemAmount(item.DefinitionId);
            }
            _totalIce = Inventory.GetItemAmount(ItensConstants.ICE_ID.DefinitionId);
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

        protected override void OnInit(MyObjectBuilder_EntityBase objectBuilder)
        {
            base.OnInit(objectBuilder);
            var definition = new MyInventoryComponentDefinition
            {
                RemoveEntityOnEmpty = false,
                MultiplierEnabled = true,
                MaxItemCount = int.MaxValue,
                Mass = MaxMass,
                Volume = MaxVolume,
                InputConstraint = new MyInventoryConstraint("FarmBlockInventory", null, true)
            };
            foreach (var item in FarmConstants.FERTILIZERS)
            {
                definition.InputConstraint.Add(item.DefinitionId);
            }
            definition.InputConstraint.Add(ItensConstants.ICE_ID.DefinitionId);
            definition.InputConstraint.Add(ItensConstants.SPOILED_MATERIAL_ID.DefinitionId);
            definition.InputConstraint.Add(SeedsAndFertilizerConstants.TREEDEAD_ID.DefinitionId);
            foreach (var key in FarmConstants.TREE_DEFINITIONS.Keys)
            {
                if (!definition.InputConstraint.ConstrainedIds.Contains(key.DefinitionId))
                    definition.InputConstraint.Add(key.DefinitionId);
                foreach (var result in FarmConstants.TREE_DEFINITIONS[key].Results)
                {
                    if (!definition.InputConstraint.ConstrainedIds.Contains(result.Product.DefinitionId))
                        definition.InputConstraint.Add(result.Product.DefinitionId);
                }
            }
            Inventory.Init(definition);
        }

        protected override void OnUpdateAfterSimulation100()
        {
            base.OnUpdateAfterSimulation100();

        }

    }

}