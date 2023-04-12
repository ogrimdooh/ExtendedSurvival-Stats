using Sandbox.Game.Components;
using Sandbox.Game.Entities;
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

        public static void DoReciveDamage(IMyCharacter character, MyDamageInformation damage)
        {
            var statComponent = character.Components.Get<MyEntityStatComponent>() as MyCharacterStatComponent;
            MyEntityStat Torpor;
            statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.CreatureValidStats.Torpor.ToString()), out Torpor);

            if (Torpor != null && damage.Type == MyDamageType.Bullet && damage.AttackerId != 0)
            {
                var gun = ExtendedSurvivalStatsEntityManager.Instance.GetHandheldGun(damage.AttackerId);
                if (gun != null)
                {
                    if (gun.CurrentAmmoMagazineId == WeaponsConstants.PISTOL_LIDOCAIN_MAGZINE_ID.DefinitionId)
                    {
                        Torpor.Increase(damage.Amount * TorporConstants.LIDOCAIN_MULTIPLIER, null);
                    }
                    else if (gun.CurrentAmmoMagazineId == WeaponsConstants.PISTOL_PROPOFOL_MAGZINE_ID.DefinitionId)
                    {
                        Torpor.Increase(damage.Amount * TorporConstants.PROPOFOL_MULTIPLIER, null);
                    }
                    else
                    {
                        // Animals take more damage from bulets
                        character.DoDamage(damage.Amount * 10, MyDamageType.Environment, true);
                    }
                    if (Torpor.Value >= Torpor.MaxValue)
                        PassOut(character);
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
