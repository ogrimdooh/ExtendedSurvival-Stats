﻿using Sandbox.Game.AI;
using Sandbox.Game.Components;
using Sandbox.Game.Entities;
using Sandbox.Game.Entities.Character;
using Sandbox.ModAPI.Weapons;
using System;
using System.Linq;
using VRage.Game;
using VRage.Game.Entity;
using VRage.Game.ModAPI;
using VRage.Utils;
using VRageMath;

namespace ExtendedSurvival.Stats
{
    public static class CreatureActionsController
    {

        public static void DoReciveDamage(IMyCharacter character, ref MyDamageInformation damage)
        {
            var statComponent = character.Components.Get<MyEntityStatComponent>() as MyCharacterStatComponent;
            MyEntityStat Torpor;
            statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.CreatureValidStats.Torpor.ToString()), out Torpor);

            if (damage.Type == MyDamageType.Wolf || damage.Type == MyDamageType.Spider)
            {
                damage.Amount = 0; /* Disable create damagin other creature */
            }
            else
            {
                if (Torpor != null && damage.Type == MyDamageType.Bullet && damage.AttackerId != 0)
                {
                    IMyAutomaticRifleGun gunObj;
                    var gun = ExtendedSurvivalStatsEntityManager.Instance.GetHandheldGun(damage.AttackerId, out gunObj);
                    if (gun != null)
                    {

                        float torporRate = 1;
                        float damageRate = 1;
                        var armor = PlayerArmorController.GetEquipedArmor(gunObj.OwnerIdentityId, useCache: true);
                        if (armor != null && armor.HasArmor)
                        {
                            if (armor.ArmorDefinition.Effects.ContainsKey(ArmorSystemConstants.ArmorEffect.CreatureDamage))
                            {
                                damageRate += armor.ArmorDefinition.Effects[ArmorSystemConstants.ArmorEffect.CreatureDamage];
                            }
                            if (armor.ArmorDefinition.Effects.ContainsKey(ArmorSystemConstants.ArmorEffect.TorporBonus))
                            {
                                torporRate += armor.ArmorDefinition.Effects[ArmorSystemConstants.ArmorEffect.TorporBonus];
                            }
                        }
                        damageRate += PlayerActionsController.StatsMultiplier(gunObj.OwnerIdentityId, ArmorSystemConstants.ArmorEffect.CreatureDamage);
                        damageRate += PlayerActionsController.StatsMultiplier(gunObj.OwnerIdentityId, ArmorSystemConstants.ArmorEffect.HandWeaponDamage);
                        torporRate += PlayerActionsController.StatsMultiplier(gunObj.OwnerIdentityId, ArmorSystemConstants.ArmorEffect.TorporBonus);

                        if (gun.CurrentAmmoMagazineId == WeaponsConstants.PISTOL_LIDOCAIN_MAGZINE_ID.DefinitionId)
                        {
                            Torpor.Increase(damage.Amount * TorporConstants.LIDOCAIN_MULTIPLIER * torporRate, null);
                        }
                        else if (gun.CurrentAmmoMagazineId == WeaponsConstants.PISTOL_PROPOFOL_MAGZINE_ID.DefinitionId)
                        {
                            Torpor.Increase(damage.Amount * TorporConstants.PROPOFOL_MULTIPLIER * torporRate, null);
                        }
                        else
                        {
                            // Animals take more damage from bulets
                            damage.Amount *= Math.Max(ExtendedSurvivalSettings.Instance.CreatureBulletDamageReciverMultiplier, 0.1f) * damageRate;
                        }
                        if (Torpor.Value >= Torpor.MaxValue)
                            PassOut(character);

                    }
                }
            }
        }

        private static void PassOut(IMyCharacter character)
        {
            try
            {
                LivestockConstants.AnimalGender Gender = LivestockConstants.AnimalGender.Female;
                LivestockConstants.AnimalInfo? animalDefinition = null;
                if (LivestockConstants.ANIMALS.Keys.Contains(character.Definition.Id.SubtypeName))
                {
                    animalDefinition = LivestockConstants.ANIMALS[character.Definition.Id.SubtypeName];
                    var genderValue = MyUtils.GetRandomInt(0, 100);
                    if (genderValue > animalDefinition.Value.genderFormula)
                        Gender = LivestockConstants.AnimalGender.Female;
                    else
                        Gender = LivestockConstants.AnimalGender.Male;
                }
                if (animalDefinition.HasValue)
                {

                    Vector3D upp = character.WorldMatrix.Up;
                    Vector3D fww = character.WorldMatrix.Forward;
                    Vector3D rtt = character.WorldMatrix.Right;
                    Vector3D pos = character.GetPosition();

                    MyFloatingObjects.Spawn(
                        new MyPhysicalInventoryItem(1, ItensConstants.GetGasContainerBuilder(animalDefinition.Value.genderIds[Gender], animalDefinition.Value.startItemHealth)),
                        pos + (upp * 2),
                        fww,
                        upp
                    );
                    character.Close();

                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogWarning(typeof(CreatureActionsController), $"PassOut [Error]");
                ExtendedSurvivalStatsLogging.Instance.LogError(typeof(CreatureActionsController), ex);
            }
        }

    }

}
