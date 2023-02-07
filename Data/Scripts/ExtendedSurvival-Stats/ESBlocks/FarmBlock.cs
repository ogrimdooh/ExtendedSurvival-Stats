using Sandbox.Common.ObjectBuilders;
using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI;
using System.Collections.Generic;
using VRage.Game.Components;
using VRage.ModAPI;
using VRage.Game;
using VRage.Game.ModAPI;
using VRage.ObjectBuilders;
using Sandbox.Game;
using SpaceEngineers.Game.ModAPI;
using VRage.Game.Entity;
using System;
using VRage;
using System.Linq;
using VRage.Utils;
using VRageMath;
using System.Text;

namespace ExtendedSurvival.Stats
{

    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_OxygenFarm), false, "LargeBlockFarm")]
    public class FarmBlock : BaseInventoryLogicComponent<IMyOxygenFarm>
    {

        public const string BLOCK_NAME = "Farm";

        public static string GetFullDescription()
        {
            var values = new StringBuilder();
            values.AppendLine(string.Format(
                "Farms are blocks that generate vegetables, mushrooms and herbs when seeds, ice and fertilizers are placed in the inventory. " +
                "Resource cost increases by {0}% for extra seed type and rotting time decreases by {0}% when producing.", 
                (FarmConstants.BASE_INCRESE_COST * 100).ToString("#0.0"),
                (FarmConstants.BASE_SPOILMULTIPLIER_WITH_TREE * 100).ToString("#0.0")
            ));
            return values.ToString();
        }

        private const float MAS_MASS = int.MaxValue;
        private const float MAS_VOLUME = 4;

        public static float MaxMass
        {
            get
            {
                return MAS_MASS * MyAPIGateway.Session.SessionSettings.InventorySizeMultiplier;
            }
        }

        public static float MaxVolume
        {
            get
            {
                return MAS_VOLUME * MyAPIGateway.Session.SessionSettings.InventorySizeMultiplier;
            }
        }

        public MyInventory Inventory
        {
            get
            {
                return GetMyInventory(0);
            }
        }

        private readonly Dictionary<UniqueEntityId, float> _progress = new Dictionary<UniqueEntityId, float>();

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
                    var spoilMultiplier = HasRequiredItensToProduce() ? FarmConstants.BASE_SPOILMULTIPLIER_WITH_TREE : 1;
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

        private bool HasRequiredItensToProduce()
        {
            return CurrentEntity.Enabled && CurrentEntity.IsFunctional && CurrentEntity.IsWorking && _totalFertilizer > 0 && _totalIce > 0 && _progress.Count > 0;
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
                        var needDelte = new List<UniqueEntityId>();
                        var keysToSee = _progress.Keys.ToArray();
                        for (int i = 0; i < keysToSee.Length; i++)
                        {
                            var key = keysToSee[i];
                            if (HasRequiredItens(key))
                            {
                                _progress[key] += timeDeltaMilliseconds;
                                if (_progress[key] > FarmConstants.DEFINITIONS[key].TimeToProduceInMs)
                                {
                                    _progress[key] -= FarmConstants.DEFINITIONS[key].TimeToProduceInMs;
                                    MyAPIGateway.Utilities.InvokeOnGameThread(() =>
                                    {
                                        GenerateProducts(key);
                                    });
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
                        var keys = FarmConstants.DEFINITIONS.Keys.Where(x => !_progress.ContainsKey(x)).ToList();
                        foreach (var key in keys)
                        {
                            if (HasRequiredItens(key))
                                _progress.Add(key, 0);
                        }
                    }
                    else
                        ResetProgress(); // No Ice or Fertilizer reset progress
                }
                else
                    ResetItensAmmount();
            }
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


        private bool HasRequiredItens(UniqueEntityId key)
        {
            return (!FarmConstants.DEFINITIONS[key].SunRequired || _totalSun > 0) &&
                (float)Inventory.GetItemAmount(key.DefinitionId) > FarmConstants.DEFINITIONS[key].SeedFactor;
        }

        private MyFixedPoint GetIceToRemove(UniqueEntityId key)
        {
            var baseFactor = FarmConstants.DEFINITIONS[key].IceFactor;
            return (MyFixedPoint)(baseFactor + (_totalSun * baseFactor)) * GetIncriseMultiplier();
        }

        private MyFixedPoint GetFertilizerToRemove(UniqueEntityId key)
        {
            var baseFactor = FarmConstants.DEFINITIONS[key].FertilizerFactor;
            return (MyFixedPoint)(baseFactor + (_totalSun * baseFactor)) * GetIncriseMultiplier();
        }

        private MyFixedPoint GetSeedsToRemove(UniqueEntityId key)
        {
            var baseFactor = FarmConstants.DEFINITIONS[key].SeedFactor;
            return (MyFixedPoint)baseFactor * GetIncriseMultiplier();
        }

        private float GetIncriseMultiplier()
        {
            return 1 + (_progress.Count > 1 ? FarmConstants.BASE_INCRESE_COST * (_progress.Count - 1) : 0);
        }

        private static bool CheckCanGenerate(float chance)
        {
            return MyUtils.GetRandomInt(1, 101) <= chance;
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

        private void GenerateProducts(UniqueEntityId key)
        {
            var fertilizerToRemove = GetFertilizerToRemove(key);
            UniqueEntityId fertilerToUse = null;
            if (GetFirstFertilizer(out fertilerToUse))
            {
                var iceToRemove = GetIceToRemove(key);
                var iceAmmount = Inventory.GetItemAmount(ItensConstants.ICE_ID.DefinitionId);
                if (iceToRemove > iceAmmount)
                    iceToRemove = iceAmmount;
                Inventory.RemoveItemsOfType(iceToRemove, ItensConstants.GetPhysicalObjectBuilder(ItensConstants.ICE_ID));
                if (HasSuperFertilizer())
                {
                    fertilerToUse = FarmConstants.POWER_FERTILIZER;
                }
                else if (HasItem(FarmConstants.DEFINITIONS[key].PreferredFertilizer))
                {
                    fertilerToUse = FarmConstants.DEFINITIONS[key].PreferredFertilizer;
                }
                var fertilizerAmmount = Inventory.GetItemAmount(fertilerToUse.DefinitionId);
                if (fertilizerToRemove > fertilizerAmmount)
                    fertilizerToRemove = fertilizerAmmount;
                Inventory.RemoveItemsOfType(fertilizerToRemove, ItensConstants.GetPhysicalObjectBuilder(fertilerToUse));
                var seedToRemove = GetSeedsToRemove(key);
                var seedAmmount = Inventory.GetItemAmount(key.DefinitionId);
                if (seedToRemove > seedAmmount)
                    seedToRemove = seedAmmount;
                Inventory.RemoveItemsOfType(seedToRemove, ItensConstants.GetPhysicalObjectBuilder(key));
                for (int i = 0; i < FarmConstants.DEFINITIONS[key].Results.Count; i++)
                {
                    var result = FarmConstants.DEFINITIONS[key].Results[i];
                    if (CheckCanGenerate(result.ChanceToGenerate))
                    {
                        var totalToGenerate = CalcResultValueToGenerate(result.BaseFactor, result.SunMultiplierFactor, result.AllowDecimal);
                        if (fertilerToUse == FarmConstants.POWER_FERTILIZER)
                            totalToGenerate *= FarmConstants.POWER_FERTILIZER_MULTIPLIER;
                        else if (fertilerToUse == FarmConstants.DEFINITIONS[key].PreferredFertilizer)
                            totalToGenerate *= FarmConstants.PREFER_FERTILIZER_MULTIPLIER;
                        Inventory.AddMaxItems(totalToGenerate, ItensConstants.GetPhysicalObjectBuilder(result.Product), result.AllowDecimal);
                    }
                }
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
            definition.InputConstraint.Add(RecipientConstants.BOWL_ID.DefinitionId);
            foreach (var key in FarmConstants.DEFINITIONS.Keys)
            {
                if (!definition.InputConstraint.ConstrainedIds.Contains(key.DefinitionId))
                    definition.InputConstraint.Add(key.DefinitionId);
                foreach (var result in FarmConstants.DEFINITIONS[key].Results)
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