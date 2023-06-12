using System.Collections.Generic;
using System.Linq;
using VRage;
using VRage.Game;
using Sandbox.Game.Entities;
using VRageMath;
using Sandbox.ModAPI;
using VRage.Game.ModAPI;
using Sandbox.Game;
using System;
using VRage.ObjectBuilders;
using Sandbox.Common.ObjectBuilders;

namespace ExtendedSurvival.Stats
{
    public static class BonusGatheringController
    {

        public static void DoExecuteBonusGathering(MyFloatingObject floatingObj)
        {
            if (floatingObj != null)
            {
                var typeId = floatingObj.Item.Content.TypeId;
                if (typeId == typeof(MyObjectBuilder_Ore))
                {
                    BoundingSphereD boundingSphere = new BoundingSphereD(floatingObj.PositionComp.GetPosition(), 2);
                    var around = MyAPIGateway.Entities.GetEntitiesInSphere(ref boundingSphere);
                    var query = around.Where(x => (x as IMyCharacter) != null);
                    if (query.Any())
                    {
                        var characters = query.Select(x => x as IMyCharacter).ToArray();
                        foreach (var character in characters)
                        {
                            if (character.IsValidPlayer())
                            {
                                if (character.HasEquippedTool() && character.IsCharacterUsingTool())
                                {
                                    var playerId = character.GetPlayerId();
                                    var armorInfo = PlayerArmorController.GetEquipedArmor(playerId, useCache: true);
                                    if (armorInfo.HasValue && armorInfo.Value.Definition.Effects.ContainsKey(ArmorSystemConstants.ArmorEffect.Gathering))
                                    {
                                        var getBonus = armorInfo.Value.Definition.Effects[ArmorSystemConstants.ArmorEffect.Gathering];
                                        var baseValue = (float)floatingObj.Item.Amount;
                                        floatingObj.Item.Amount = (MyFixedPoint)(baseValue + (baseValue * getBonus));
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

    }

}