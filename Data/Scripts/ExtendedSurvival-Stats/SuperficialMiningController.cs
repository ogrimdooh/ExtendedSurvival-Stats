using System;
using System.Collections.Generic;
using System.Linq;
using VRage;
using VRage.ModAPI;
using VRage.Game;
using Sandbox.Game.Entities;
using VRage.Game.Entity;
using VRageMath;

namespace ExtendedSurvival
{

    public static class SuperficialMiningController
    {

        private class MiningDropLoot
        {

            public UniqueEntityId ItemId { get; set; }
            public float Ammount { get; set; }
            public float Chance { get; set; }
            public string[] ValidMaterials { get; set; } = new string[] { "Soil" };

            public MiningDropLoot(UniqueEntityId itemId, float ammount, float chance)
            {
                ItemId = itemId;
                Ammount = ammount;
                Chance = chance;
            }

        }

        private static readonly Random rnd = new Random();

        private static readonly float MAX_DISTANCE_TO_GENERATE_LOOT = 1.0f;
        private static readonly float MAX_DROP_COUNT = 1;
        private static readonly float MAX_DROP_TRY_COUNT = 3;
        private static readonly List<MiningDropLoot> MINE_DROPS = new List<MiningDropLoot>()
        {
            new MiningDropLoot(ItensConstants.CHAMPIGNONS_ID, 20, 4),
            new MiningDropLoot(ItensConstants.SHIITAKE_ID, 20, 4),
            new MiningDropLoot(ItensConstants.AMANITAMUSCARIA_ID, 2, 1) { ValidMaterials = new string[] { "AlienSoil", "AlienGreenGrass", "AlienOrangeGrass", "AlienYellowGrass" } },
            new MiningDropLoot(ItensConstants.CAROOT_ID, 1, 2),
            new MiningDropLoot(ItensConstants.BEETROOT_ID, 1, 2),
            new MiningDropLoot(ItensConstants.ALOEVERA_ID, 5, 5),
            new MiningDropLoot(ItensConstants.ERYTHROXYLUM_ID, 5, 5),
            new MiningDropLoot(ItensConstants.ARNICA_ID, 20, 3),
            new MiningDropLoot(ItensConstants.CHAMOMILE_ID, 10, 3),
            new MiningDropLoot(ItensConstants.MINT_ID, 10, 3)
        };

        public static bool CheckEntityIsAFloatingObject(MyEntity obj)
        {
            var floatingObj = obj as MyFloatingObject;
            if (floatingObj != null)
            {
                var typeId = floatingObj.Item.Content.TypeId.ToString();
                if (typeId.Contains("Ore"))
                {
                    var subTypeId = floatingObj.Item.Content.SubtypeId.ToString();
                    if (subTypeId.CompareTo("Soil") == 0 && ExtendedSurvivalCoreAPI.Registered)
                    {
                        Vector3D upp = obj.WorldMatrix.Up;
                        Vector3D fww = obj.WorldMatrix.Forward;
                        Vector3D rtt = obj.WorldMatrix.Right;
                        Vector3D pos = (obj as IMyEntity).GetPosition();
                        var platAtRange = MyGamePruningStructure.GetClosestPlanet(pos);
                        if (platAtRange != null && platAtRange.HasAtmosphere)
                        {
                            var pos2 = new Vector3((float)pos.X, (float)pos.Y, (float)pos.Z);
                            var surfaceRange = platAtRange.GetClosestSurfacePointGlobal(pos);
                            if (Vector3.Distance(pos, surfaceRange) < MAX_DISTANCE_TO_GENERATE_LOOT)
                            {
                                var lootAmmount = new Dictionary<int, double>();
                                for (int c = 0; c < MAX_DROP_TRY_COUNT; c++)
                                {
                                    var i = rnd.Next(0, MINE_DROPS.Count - 1);
                                    if (MINE_DROPS[i].ValidMaterials.Contains(floatingObj.VoxelMaterial.MaterialTypeName))
                                    {
                                        if (rnd.Next(1, 101) <= MINE_DROPS[i].Chance)
                                            lootAmmount.Add(i, MINE_DROPS[i].Ammount);
                                        if (lootAmmount.Count >= MAX_DROP_COUNT)
                                            break;
                                    }
                                }
                                foreach (var i in lootAmmount.Keys)
                                {
                                    MyFixedPoint amountfinal = (int)lootAmmount[i];
                                    MyFloatingObjects.Spawn(new MyPhysicalInventoryItem(amountfinal, ItensConstants.GetPhysicalObjectBuilder(MINE_DROPS[i].ItemId)), pos, fww, upp);
                                }
                            }
                        }
                    }
                }
                return true;
            }
            return false;
        }

    }

}