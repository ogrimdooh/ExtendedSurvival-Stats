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
            public float Ammount { get; set; }
            public float Chance { get; set; }
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
                "Eremus Nubis"
            };

            public MiningDropLoot(UniqueEntityId itemId, float ammount, float chance)
            {
                ItemId = itemId;
                Ammount = ammount;
                Chance = chance;
            }

        }

        private static readonly Random rnd = new Random();

        private static readonly float MAX_DISTANCE_TO_GENERATE_LOOT = 1.0f;
        private static readonly float MAX_DISTANCE_TO_GENERATE_LOOT_SHIPDRILL = 2.5f;
        private static readonly float MAX_DROP_COUNT = 1;
        private static readonly float MAX_DROP_TRY_COUNT = 3;

        public static readonly List<MiningDropLoot> MINE_DROPS = new List<MiningDropLoot>()
        {
            new MiningDropLoot(ItensConstants.CHAMPIGNONS_ID, 20, 4),
            new MiningDropLoot(ItensConstants.SHIITAKE_ID, 20, 4),
            new MiningDropLoot(ItensConstants.AMANITAMUSCARIA_ID, 2, 5) 
            { 
                ValidSubType = new string[] { "AlienSoil" },
                ValidPlanetSubType = new string[] { "Alien", "Titan" }
            },
            new MiningDropLoot(ItensConstants.CAROOT_ID, 1, 2),
            new MiningDropLoot(ItensConstants.BEETROOT_ID, 1, 2),
            new MiningDropLoot(ItensConstants.ALOEVERA_ID, 5, 5),
            new MiningDropLoot(ItensConstants.ERYTHROXYLUM_ID, 5, 5),
            new MiningDropLoot(ItensConstants.ARNICA_ID, 20, 3),
            new MiningDropLoot(ItensConstants.CHAMOMILE_ID, 10, 3),
            new MiningDropLoot(ItensConstants.MINT_ID, 10, 3)
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
                                    lootAmmount.Add(validDrops[i].ItemId, validDrops[i].Ammount);
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
            MyVisualScriptLogicProvider.ShipDrillCollected = (string entityName, long entityId, string gridName, long gridId, string typeId, string subtypeId, float amount) =>
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
                                    var target = grid.Inventories.FirstOrDefault(x => inventory.CanTransferItemTo(x.GetInventory(), i.DefinitionId));
                                    if (target != null)
                                    {
                                        target.GetInventory().AddMaxItems(amountfinal, ItensConstants.GetPhysicalObjectBuilder(i));
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

        public static bool CheckEntityIsAFloatingObject(MyEntity obj)
        {
            try
            {
                var floatingObj = obj as MyFloatingObject;
                if (floatingObj != null)
                {
                    Vector3D upp = obj.WorldMatrix.Up;
                    Vector3D fww = obj.WorldMatrix.Forward;
                    var typeId = floatingObj.Item.Content.TypeId.ToString();
                    var subtypeId = floatingObj.Item.Content.SubtypeId.ToString();
                    Vector3D pos = (obj as IMyEntity).GetPosition();
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