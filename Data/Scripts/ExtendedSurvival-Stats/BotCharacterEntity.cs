using ProtoBuf;
using Sandbox.Common.ObjectBuilders.Definitions;
using Sandbox.Game.Components;
using Sandbox.Game.Entities;
using Sandbox.ModAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRage;
using VRage.Game;
using VRage.Game.Entity;
using VRage.Game.ModAPI;
using VRage.ModAPI;
using VRage.ObjectBuilders;
using VRage.Utils;
using VRageMath;

namespace ExtendedSurvival
{

    public class BotCharacterEntity : BaseCharacterEntity
    {

        public const string STOREDPOWER_STORAGE_KEY = "63A5B803-6635-4747-B5DD-12D682519B10";
        public const string HEALTH_STORAGE_KEY = "D8F5BC79-ED1C-473A-A437-DC3C35DF9B11";
        public const int MAX_TARGET_DISTANCE = 125;

        private string botName;
        public string BotName
        {
            get
            {
                if (string.IsNullOrEmpty(botName))
                    botName = Entity.Name.Substring(Entity.Name.IndexOf('.') + 1);
                return botName;
            }
        }

        public bool IsCreature
        {
            get
            {
                return Torpor != null;
            }
        }

        private LivestockConstants.AnimalInfo? animalDefinition;

        public LivestockConstants.AnimalGender Gender { get; private set; }

        private UniqueNameId uniqueNameId = UniqueNameId.Empty;
        public UniqueNameId NameId
        {
            get
            {
                return uniqueNameId;
            }
        }

        public MyEntityStat Torpor { get; private set; }

        protected BotCharacterEntity internalTarget;
        protected bool targetJustGotNull = false;

        public BotCharacterEntity(IMyCharacter entity) 
            : base(entity)
        {
            ConfigureCharacter(entity);
        }

        protected override bool GetIsValid()
        {
            if (IsCreature)
                return base.GetIsValid() && Torpor != null && animalDefinition != null;
            return base.GetIsValid();
        }

        protected override void OnBeginConfigureCharacter()
        {
            base.OnBeginConfigureCharacter();
            if (StatComponent != null)
                Torpor = GetPlayerStat("Torpor");
            if (IsCreature)
            {
                if (LivestockConstants.ANIMALS.Keys.Contains(Entity.Definition.Id.SubtypeName))
                {
                    animalDefinition = LivestockConstants.ANIMALS[Entity.Definition.Id.SubtypeName];
                    var genderValue = MyUtils.GetRandomInt(0, 100);
                    if (genderValue > animalDefinition.Value.genderFormula)
                        Gender = LivestockConstants.AnimalGender.Female;
                    else
                        Gender = LivestockConstants.AnimalGender.Male;
                }
            }
        }

        protected override void OnEndConfigureCharacter()
        {
            if (StatComponent != null && Torpor != null)
                Torpor.OnStatChanged += Torpor_OnStatChanged;
            base.OnEndConfigureCharacter();
            if (InventoryObserver != Guid.Empty && ExtendedSurvivalCoreAPI.Registered)
                ExtendedSurvivalCoreAPI.SetInventoryObserverSpoilStatus(InventoryObserver, false);
        }

        public override void OnReciveDamage(MyDamageInformation damage)
        {
            base.OnReciveDamage(damage);
            if (IsCreature && damage.Type == MyDamageType.Bullet && damage.AttackerId != 0)
            {
                var gun = ExtendedSurvivalStatsEntityManager.Instance.GetHandheldGun(damage.AttackerId);
                if (gun != null)
                {
                    if (gun.CurrentAmmoMagazineId == ItensConstants.PISTOL_LIDOCAIN_MAGZINE_ID.DefinitionId)
                    {
                        Torpor.Increase(damage.Amount * TorporConstants.LIDOCAIN_MULTIPLIER, null);
                    }
                    else if (gun.CurrentAmmoMagazineId == ItensConstants.PISTOL_PROPOFOL_MAGZINE_ID.DefinitionId)
                    {
                        Torpor.Increase(damage.Amount * TorporConstants.PROPOFOL_MULTIPLIER, null);
                    }
                    if (Torpor.Value >= Torpor.MaxValue)
                        PassOut();
                }
            }
        }

        private void Torpor_OnStatChanged(float newValue, float oldValue, object statChangeData)
        {
        }

        public void ProcessStatsCycle()
        {
            if (!MyAPIGateway.Session.CreativeMode)
            {
                if (IsCreature)
                {
                    if (Torpor.Value >= Torpor.MaxValue)
                        PassOut();
                    else
                        ProcessTorpor();
                }
            }
        }

        private void ProcessTorpor()
        {
            if (Torpor.Value > 0)
                Torpor.Decrease(GetTorporToDecrease(), PlayerId);
        }

        private float GetTorporToDecrease()
        {
            var finalValue = TorporConstants.TORPOR_DRAIN_FACTOR;
            if (IsCharacterMoving())
                finalValue += GetSpeed() * TorporConstants.TORPOR_MOVE_DRAIN_FACTOR;
            if (IsCharacterFlying())
                finalValue *= 1 + TorporConstants.TORPOR_MOVE_DRAIN_FACTOR;
            return finalValue;
        }

        private void PassOut()
        {
            if (IsCreature && IsValid)
            {
                try
                {
                    Vector3D upp = Entity.WorldMatrix.Up;
                    Vector3D fww = Entity.WorldMatrix.Forward;
                    Vector3D rtt = Entity.WorldMatrix.Right;
                    Vector3D pos = Entity.GetPosition();
                    MyFloatingObjects.Spawn(
                        new MyPhysicalInventoryItem(1, ItensConstants.GetGasContainerBuilder(animalDefinition.Value.genderIds[Gender], animalDefinition.Value.startItemHealth)), 
                        pos + (upp * 2), 
                        fww, 
                        upp
                    );
                    Entity.Close();
                }
                catch (Exception ex)
                {
                    ExtendedSurvivalLogging.Instance.LogWarning(GetType(), $"PassOut [Error]");
                    ExtendedSurvivalLogging.Instance.LogError(GetType(), ex);
                }
            }
        }

        protected override void OnBeginResetConfiguration()
        {
            base.OnBeginResetConfiguration();

        }

        protected override void OnEndResetConfiguration()
        {

            base.OnEndResetConfiguration();
        }

        protected override void OnCharacterDied()
        {
            base.OnCharacterDied();
            if (Torpor != null)
                Torpor.OnStatChanged -= Torpor_OnStatChanged;
            if (InventoryObserver != Guid.Empty && ExtendedSurvivalCoreAPI.Registered)
                ExtendedSurvivalCoreAPI.SetInventoryObserverSpoilStatus(InventoryObserver, true);
        }

    }

}