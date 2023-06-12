using System;
using System.Collections.Generic;
using System.Linq;
using VRage;
using VRage.ModAPI;
using VRage.Game;
using Sandbox.Game.Entities;
using VRage.Game.Entity;
using VRageMath;
using Sandbox.Game;
using Sandbox.ModAPI;

namespace ExtendedSurvival.Stats
{
    public static class SuperficialMiningController
    {

        public class MiningDropLoot
        {

            public UniqueEntityId ItemId { get; set; }
            public Vector2 Ammount { get; set; }
            public float Chance { get; set; }
            public bool AlowFrac { get; set; } = false;
            public string[] ValidSubType { get; set; } = new string[] 
            { 
                "Soil" 
            };
            public string[] ValidPlanetSubType { get; set; } = new string[] 
            { 
                "EarthLike", 
                "Pertam",
                "Dover",
                "Enitor",
                "Eremus Nubis",
                "HeliosTerraformed",
                "HeliosTerraformedWM"
            };

            public MiningDropLoot(UniqueEntityId itemId, Vector2 ammount, float chance, bool alowFrac = false)
            {
                ItemId = itemId;
                Ammount = ammount;
                Chance = chance;
                AlowFrac = alowFrac;
            }

        }

        private static readonly Random rnd = new Random();

        private static readonly float MAX_DISTANCE_TO_GENERATE_LOOT = 1.0f;
        private static readonly float MAX_DISTANCE_TO_GENERATE_LOOT_SHIPDRILL = 2.5f;
        private static readonly float MAX_DROP_COUNT = 1;
        private static readonly float MAX_DROP_TRY_COUNT = 3;

        public static readonly List<MiningDropLoot> MINE_DROPS = new List<MiningDropLoot>()
        {
            new MiningDropLoot(FoodConstants.CHAMPIGNONS_ID, new Vector2(4, 8), 4),
            new MiningDropLoot(FoodConstants.SHIITAKE_ID, new Vector2(4, 8), 4),
            new MiningDropLoot(FoodConstants.AMANITAMUSCARIA_ID, new Vector2(2, 4), 5) 
            { 
                ValidSubType = new string[] { "AlienSoil" },
                ValidPlanetSubType = new string[] { "Alien", "Titan" }
            },
            new MiningDropLoot(FoodConstants.CAROOT_ID, new Vector2(1, 4), 2),
            new MiningDropLoot(FoodConstants.BEETROOT_ID, new Vector2(1, 4), 2),
            new MiningDropLoot(HerbsConstants.ALOEVERA_ID, new Vector2(2, 6), 5),
            new MiningDropLoot(HerbsConstants.ERYTHROXYLUM_ID, new Vector2(1, 4), 5),
            new MiningDropLoot(HerbsConstants.ARNICA_ID, new Vector2(1, 4), 3),
            new MiningDropLoot(HerbsConstants.CHAMOMILE_ID, new Vector2(3, 9), 3),
            new MiningDropLoot(HerbsConstants.MINT_ID, new Vector2(3, 9), 3)
        };

        private static Dictionary<UniqueEntityId, float> DoInternalDrill(string typeId, string subtypeId, Vector3D pos, float maxDistance)
        {
            var lootAmmount = new Dictionary<UniqueEntityId, float>();
            if (typeId.Contains("Ore") && subtypeId.Contains("Soil") && ExtendedSurvivalCoreAPI.Registered)
            {
                var platAtRange = MyGamePruningStructure.GetClosestPlanet(pos);
                if (platAtRange != null && platAtRange.HasAtmosphere)
                {
                    var planetId = platAtRange.Generator.EnvironmentDefinition.Id.SubtypeName;
                    var surfaceRange = platAtRange.GetClosestSurfacePointGlobal(pos);
                    if (Vector3.Distance(pos, surfaceRange) < maxDistance)
                    {
                        var validDrops = MINE_DROPS.Where(x => x.ValidSubType.Contains(subtypeId) && x.ValidPlanetSubType.Contains(planetId)).ToArray();
                        if (validDrops.Any())
                        {
                            for (int c = 0; c < MAX_DROP_TRY_COUNT; c++)
                            {
                                var i = rnd.Next(0, validDrops.Length - 1);
                                if (rnd.Next(1, 101) <= validDrops[i].Chance)
                                {
                                    var value = validDrops[i].Ammount.GetRandom();
                                    if (!validDrops[i].AlowFrac)
                                        value = (int)value;
                                    lootAmmount.Add(validDrops[i].ItemId, value);
                                }
                                if (lootAmmount.Count >= MAX_DROP_COUNT)
                                    break;
                            }
                        }
                    }
                }
            }
            return lootAmmount;
        }

        public static void InitShipDrillCollec()
        {
            // Add event to ship drill
            MyVisualScriptLogicProvider.ShipDrillCollected += (string entityName, long entityId, string gridName, long gridId, string typeId, string subtypeId, float amount) =>
            {
                try
                {
                    var entity = MyAPIGateway.Entities.GetEntityById(entityId);
                    Vector3D pos = entity.GetPosition();
                    var lootAmmount = DoInternalDrill(typeId, subtypeId, pos, MAX_DISTANCE_TO_GENERATE_LOOT_SHIPDRILL);
                    if (lootAmmount.Any())
                    {
                        var inventory = entity.GetInventory();
                        if (inventory != null)
                        {
                            var drill = entity as IMyShipDrill;
                            var grid = drill.CubeGrid as MyCubeGrid;
                            foreach (var i in lootAmmount.Keys)
                            {
                                float amountfinal = (int)lootAmmount[i];
                                if (i.typeId == typeof(MyObjectBuilder_Ore))
                                {
                                    inventory.AddMaxItems(amountfinal, ItensConstants.GetPhysicalObjectBuilder(i));
                                }
                                else
                                {
                                    var targets = grid.Inventories.Where(x => 
                                        x.GetInventory().CanItemsBeAdded((MyFixedPoint)amountfinal, i.DefinitionId) &&
                                        inventory.CanTransferItemTo(x.GetInventory(), i.DefinitionId)
                                    ).ToArray();
                                    if (targets.Any())
                                    {
                                        foreach (var target in targets)
                                        {
                                            var addedAmount = target.GetInventory().AddMaxItems(amountfinal, ItensConstants.GetPhysicalObjectBuilder(i));
                                            amountfinal -= addedAmount;
                                            if (amountfinal <= 0)
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ExtendedSurvivalStatsLogging.Instance.LogError(typeof(SuperficialMiningController), ex);
                }
            };
        }

        public static bool CheckEntityIsAFloatingObject(MyFloatingObject floatingObj)
        {
            try
            {
                if (floatingObj != null)
                {
                    Vector3D upp = floatingObj.WorldMatrix.Up;
                    Vector3D fww = floatingObj.WorldMatrix.Forward;
                    var typeId = floatingObj.Item.Content.TypeId.ToString();
                    var subtypeId = floatingObj.Item.Content.SubtypeId.ToString();
                    Vector3D pos = (floatingObj as IMyEntity).GetPosition();
                    var lootAmmount = DoInternalDrill(typeId, subtypeId, pos, MAX_DISTANCE_TO_GENERATE_LOOT);
                    if (lootAmmount.Any())
                    {
                        foreach (var i in lootAmmount.Keys)
                        {
                            MyFixedPoint amountfinal = (int)lootAmmount[i];
                            MyFloatingObjects.Spawn(new MyPhysicalInventoryItem(amountfinal, ItensConstants.GetPhysicalObjectBuilder(i)), pos, fww, upp);
                        }
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(typeof(SuperficialMiningController), ex);
            }
            return false;
        }

    }

}