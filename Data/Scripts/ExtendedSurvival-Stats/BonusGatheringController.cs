﻿using System.Collections.Generic;
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
                                    float getBonus = 0;
                                    if (armorInfo != null && armorInfo.HasArmor && armorInfo.ArmorDefinition.Effects.ContainsKey(ArmorSystemConstants.ArmorEffect.Gathering))
                                    {
                                        getBonus = armorInfo.ArmorDefinition.Effects[ArmorSystemConstants.ArmorEffect.Gathering];                                        
                                    }
                                    getBonus += PlayerActionsController.StatsMultiplier(playerId, ArmorSystemConstants.ArmorEffect.Gathering);
                                    if (getBonus != 0)
                                    {
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