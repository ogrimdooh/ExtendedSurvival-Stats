using Sandbox.Common.ObjectBuilders.Definitions;
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
using VRage.Utils;
using VRageMath;

namespace ExtendedSurvival.Stats
{

    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_CargoContainer), false, "LargeBlockSmallCage", "SmallBlockSmallCage", "LargeBlockLargeCage")]
    public class CageBlock : SimpleInventoryLogicComponent<IMyCargoContainer> 
    {

        public const string SMALL_BLOCK_NAME = "Small Cage";
        public const string BLOCK_NAME = "Small Cage";
        public const string LARGE_BLOCK_NAME = "Large Cage";

        public static string GetFullDescription()
        {
            var values = new StringBuilder();
            values.AppendLine(string.Format(
                "Cage are blocks used to store and keep captured animals alive. " +
                "When you feed the animals they will eat to stay alive, and in some cases produce products."
            ));
            return values.ToString();
        }

        private const float INV_SMALL_MASS = int.MaxValue;
        private const float INV_SMALL_VOLUME = 0.900f;

        private const float INV_LARGE_MASS = int.MaxValue;
        private const float INV_LARGE_VOLUME = 2.700f;

        private static readonly Dictionary<string, Vector2> INVENTORY_SIZE = new Dictionary<string, Vector2>()
        {
            { "LargeBlockSmallCage", new Vector2(INV_SMALL_MASS, INV_SMALL_VOLUME) },
            { "SmallBlockSmallCage", new Vector2(INV_SMALL_MASS, INV_SMALL_VOLUME) },
            { "LargeBlockLargeCage", new Vector2(INV_LARGE_MASS, INV_LARGE_VOLUME) }
        };

        public string EntitySubType
        {
            get
            {
                return CurrentEntity?.BlockDefinition.SubtypeId;
            }
        }

        public bool HasAnimals
        {
            get
            {
                if (inventoryObservers.Any() && ExtendedSurvivalCoreAPI.Registered)
                    return ExtendedSurvivalCoreAPI.HasItemOfCategoryInObserver(GetObserver(0), LivestockConstants.ANIMAL_CATEGORY);
                return false;
            }
        }

        public bool HasMeatRation
        {
            get
            {
                if (inventoryObservers.Any() && ExtendedSurvivalCoreAPI.Registered)
                    return ExtendedSurvivalCoreAPI.HasItemInObserver(GetObserver(0), RationConstants.MEATRATION_ID.DefinitionId);
                return false;
            }
        }

        public bool HasVegetableRation
        {
            get
            {
                if (inventoryObservers.Any())
                    return ExtendedSurvivalCoreAPI.HasItemInObserver(GetObserver(0), RationConstants.VEGETABLERATION_ID.DefinitionId);
                return false;
            }
        }

        public bool HasGrainRation
        {
            get
            {
                if (inventoryObservers.Any())
                    return ExtendedSurvivalCoreAPI.HasItemInObserver(GetObserver(0), RationConstants.GRAINSRATION_ID.DefinitionId);
                return false;
            }
        }

        public bool HasRation
        {
            get
            {
                return HasMeatRation || HasVegetableRation || HasGrainRation; 
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
        private Dictionary<uint, float> reproductionProgress = new Dictionary<uint, float>();
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
                    Mass = INVENTORY_SIZE[EntitySubType].X,
                    Volume = INVENTORY_SIZE[EntitySubType].Y,
                    InputConstraint = new MyInventoryConstraint("CageInventory", null, true)
                };
                foreach (var item in LivestockConstants.ANIMALS_IDS)
                {
                    definition.InputConstraint.Add(item.DefinitionId);
                }
                foreach (var item in LivestockConstants.DEAD_ANIMALS_IDS)
                {
                    definition.InputConstraint.Add(item.DefinitionId);
                }
                foreach (var item in RationConstants.RATIONS_DEFINITIONS.Keys)
                {
                    definition.InputConstraint.Add(item.DefinitionId);
                }
                foreach (var item in LivestockConstants.GetProductionIds())
                {
                    definition.InputConstraint.Add(item.DefinitionId);
                }
                definition.InputConstraint.Add(OreConstants.BONES_ID.DefinitionId);
                definition.InputConstraint.Add(ItensConstants.SPOILED_MATERIAL_ID.DefinitionId);
                Inventory.Init(definition);
                _inventoryDefined = true;
            }
            if (MyAPIGateway.Session.IsServer && ExtendedSurvivalCoreAPI.Registered)
            {
                if (HasAnimals && HasRation)
                {
                    if (deltaTime == 0)
                        DoRefreshDeltaTime();
                    progress += GetGameTime() - deltaTime;
                    DoRefreshDeltaTime();
                    if (progress > LivestockConstants.FEED_TIME_CICLE)
                    {
                        progress -= LivestockConstants.FEED_TIME_CICLE;
                        var animals = ExtendedSurvivalCoreAPI.GetItemInfoByCategory(GetObserver(0), LivestockConstants.ANIMAL_CATEGORY);
                        foreach (var animal in animals)
                        {
                            var extraInfo = animal.ExtraInfo;
                            if (extraInfo != null)
                            {
                                var animalItem = Inventory.GetItemByID(animal.ItemId);
                                if (animalItem != null)
                                {
                                    var gasContainer = animalItem.Value.Content as MyObjectBuilder_GasContainerObject;
                                    if (gasContainer != null)
                                    {
                                        var eatFactor = float.Parse(extraInfo.GetCustomAttributes(LivestockConstants.CREATURE_EAT_FACTOR_ID));
                                        var absFactor = float.Parse(extraInfo.GetCustomAttributes(LivestockConstants.CREATURE_ABSORCION_FACTOR_ID));
                                        var popFactor = float.Parse(extraInfo.GetCustomAttributes(LivestockConstants.CREATURE_POOP_FACTOR_ID));
                                        bool gotfeed = false;
                                        var uniqueId = new UniqueEntityId(extraInfo.DefinitionId);
                                        if (LivestockConstants.ANIMALS_HERBICORES_IDS.Contains(uniqueId) && HasVegetableRation)
                                        {
                                            gotfeed = ProcessEatRoutine(eatFactor, absFactor, popFactor, RationConstants.VEGETABLERATION_ID.DefinitionId, gasContainer);
                                        }
                                        else if (LivestockConstants.ANIMALS_CARNIVORES_IDS.Contains(uniqueId) && HasMeatRation)
                                        {
                                            gotfeed = ProcessEatRoutine(eatFactor, absFactor, popFactor, RationConstants.MEATRATION_ID.DefinitionId, gasContainer);
                                        }
                                        else if (LivestockConstants.ANIMALS_BIRDS_IDS.Contains(uniqueId) && HasGrainRation)
                                        {
                                            gotfeed = ProcessEatRoutine(eatFactor, absFactor, popFactor, RationConstants.MEATRATION_ID.DefinitionId, gasContainer);
                                        }
                                        if (gotfeed)
                                        {
                                            var animalInfo = LivestockConstants.GetAnimalInfo(uniqueId);
                                            if (animalInfo.HasValue)
                                            {
                                                var gender = animalInfo.Value.genderIds.FirstOrDefault(x => x.Value == uniqueId).Key;
                                                switch (gender)
                                                {
                                                    case LivestockConstants.AnimalGender.Baby:
                                                        // Check has get adult
                                                        if (gasContainer.GasLevel >= 1f)
                                                        {
                                                            LivestockConstants.AnimalGender targetGender;
                                                            var genderValue = MyUtils.GetRandomInt(0, 100);
                                                            if (genderValue > animalInfo.Value.genderFormula)
                                                                targetGender = LivestockConstants.AnimalGender.Female;
                                                            else
                                                                targetGender = LivestockConstants.AnimalGender.Male;
                                                            var adultBuilder = ItensConstants.GetGasContainerBuilder(animalInfo.Value.genderIds[targetGender], 1);
                                                            if (adultBuilder != null)
                                                            {
                                                                Inventory.ReplaceItem(animal.ItemId, adultBuilder);
                                                            }
                                                        }
                                                        break;
                                                    case LivestockConstants.AnimalGender.Female:
                                                        // Check has male partner
                                                        var maleAnimalItem = ExtendedSurvivalCoreAPI.GetItemInfoByItemType(GetObserver(0), animalInfo.Value.genderIds[LivestockConstants.AnimalGender.Male].DefinitionId);
                                                        if (maleAnimalItem != null)
                                                        {
                                                            if (!reproductionProgress.ContainsKey(animal.ItemId))
                                                                reproductionProgress.Add(animal.ItemId, 0);
                                                            reproductionProgress[animal.ItemId] += LivestockConstants.FEED_TIME_CICLE;
                                                            if (reproductionProgress[animal.ItemId] > LivestockConstants.REPRODUCTION_TIME_CICLE)
                                                            {
                                                                reproductionProgress[animal.ItemId] -= LivestockConstants.REPRODUCTION_TIME_CICLE;
                                                                ProcessReproductionRoutine(animalInfo.Value);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (reproductionProgress.ContainsKey(animal.ItemId))
                                                                reproductionProgress.Remove(animal.ItemId);
                                                        }
                                                        break;
                                                }
                                                if (animalInfo.Value.customProductions != null)
                                                    foreach (var item in animalInfo.Value.customProductions)
                                                    {
                                                        ProcessCustomProduction(item, gender);
                                                    }
                                            }
                                        }
                                        else
                                        {
                                            if (reproductionProgress.ContainsKey(animal.ItemId))
                                                reproductionProgress.Remove(animal.ItemId);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    reproductionProgress.Clear();
                    DoRefreshDeltaTime();
                }
            }
        }

        private static float GetRandomNumber(float minimum, float maximum, bool allowDecimal)
        {
            if (allowDecimal)
                return MyUtils.GetRandomFloat(minimum, maximum);
            return MyUtils.GetRandomInt((int)minimum, (int)maximum);
        }

        private float CalcResultValueToGenerate(Vector2 valueRange, bool allowDecimal)
        {
            var baseValue = GetRandomNumber(valueRange.X, valueRange.Y, allowDecimal);
            if (!allowDecimal)
                baseValue = (int)baseValue;
            return baseValue;
        }

        private void ProcessCustomProduction(LivestockConstants.CustomProduction production, LivestockConstants.AnimalGender gender)
        {
            if (production.gender == gender)
            {
                if (production.chanceToGenerate.X >= MyUtils.GetRandomInt(0, production.chanceToGenerate.Y))
                {
                    if (production.hasRequiredProduct)
                    {
                        var requiredItemAmmount = (float)Inventory.GetItemAmount(production.requiredProduct.DefinitionId);
                        if (requiredItemAmmount < production.requiredAmmount)
                            return;
                        if (Inventory.RemoveItemsOfType((MyFixedPoint)production.requiredAmmount, production.requiredProduct.DefinitionId) <= 0)
                            return;
                    }
                    Inventory.AddMaxItems(CalcResultValueToGenerate(production.baseFactor, production.allowDecimal), ItensConstants.GetPhysicalObjectBuilder(production.product));
                }
            }
        }

        private void ProcessReproductionRoutine(LivestockConstants.AnimalInfo animalInfo)
        {
            var babyId = animalInfo.genderIds[LivestockConstants.AnimalGender.Baby];
            Inventory.AddMaxItems(1f, ItensConstants.GetGasContainerBuilder(babyId, 0.05f));
        }

        private bool ProcessEatRoutine(float eatFactor, float absFactor, float popFactor, MyDefinitionId rationId, MyObjectBuilder_GasContainerObject gasContainer)
        {
            if (gasContainer.GasLevel < 1f)
            {
                var rationAmmount = (float)Inventory.GetItemAmount(rationId);
                eatFactor = rationAmmount < eatFactor ? rationAmmount : eatFactor;
                Inventory.RemoveItemsOfType((MyFixedPoint)eatFactor, rationId);
                gasContainer.GasLevel += absFactor;
                gasContainer.GasLevel = Math.Min(gasContainer.GasLevel, 1f);
                Inventory.AddMaxItems(popFactor, ItensConstants.GetPhysicalObjectBuilder(OreConstants.POOP_ID));
            }
            return true;
        }

    }

}
