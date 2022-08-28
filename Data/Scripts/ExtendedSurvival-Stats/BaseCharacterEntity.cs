using System;
using System.Collections.Generic;
using System.Linq;
using VRage;
using VRage.Game.ModAPI;
using VRage.Utils;
using Sandbox.Game.Entities;
using VRage.Game.Entity;
using Sandbox.Game.Components;
using VRageMath;
using VRage.Game;
using Sandbox.ModAPI;
using Sandbox.Game;
using Sandbox.ModAPI.Weapons;
using Sandbox.Game.Entities.Character.Components;

namespace ExtendedSurvival.Stats
{

    public abstract class BaseCharacterEntity : EntityBase<IMyCharacter>
    {

        protected static readonly Random rnd = new Random();

        protected static bool CheckChance(float chance)
        {
            return rnd.Next(1, 101) <= chance;
        }

        public MyCharacterStatComponent StatComponent { get; private set; }
        public MyEntityStat Health { get; private set; }

        private long _playerId = -1;
        public long PlayerId
        {
            get
            {
                if (_playerId <= 0)
                    _playerId = Entity.GetPlayerId();
                return _playerId;
            }
        }

        public IMyPlayer Player
        {
            get
            {
                return Entity.GetPlayer();
            }
        }

        public bool IsUnderwater
        {
            get
            {
                return currentEnvironmentType == WeatherConstants.EnvironmentDetector.Underwater;
            }
        }

        public float Depth
        {
            get
            {
                return IsUnderwater ? (float)Math.Round((WaterAPI.GetDepth(Entity.GetPosition()).Value * -1) - 1.5f, 2) : 0f;
            }
        }

        public MyInventory Inventory { get; private set; }
        public Guid InventoryObserver { get; private set; }

        public bool IsDead
        {
            get
            {
                return Entity == null || Entity.IsDead || Health == null || Health.Value == 0;
            }
        }

        public bool HasHealthEffects
        {
            get
            {
                return IsValid && Health.HasAnyEffect();
            }
        }

        public float HealthEffectsTimeLeft
        {
            get
            {
                return Health.HasAnyEffect() ? Health.GetEffects().Max(x => x.Value.Duration * 1000) : 0;
            }
        }

        protected virtual bool GetIsValid()
        {
            return Entity != null && Health != null;
        }

        public bool IsValid
        {
            get
            {
                return GetIsValid();
            }
        }

        public bool CanTakeDamage
        {
            get
            {
                return !MyAPIGateway.Session.CreativeMode && !MyAPIGateway.Session.IsUserInvulnerable(Player?.SteamUserId ?? 0) && IsValid && !Entity.IsDead && Health.Value > 0;
            }
        }

        public ExtendedSurvivalCoreAPI.PlanetInfo PlanetAtRange
        {
            get
            {
                if (ExtendedSurvivalCoreAPI.Registered)
                    return ExtendedSurvivalCoreAPI.GetPlanetAtRange(Entity.PositionComp.GetPosition());
                return null;
            }
        }

        protected Vector2 lastHealthChanged = Vector2.Zero;
        protected bool hasDied = false;
        protected KeyValuePair<MyPhysicalInventoryItem, MyFixedPoint>? lastRemovedIten = null;
        protected float weatherIntensity;
        protected WeatherConstants.WeatherEffectsLevel weatherLevel;
        protected WeatherConstants.WeatherEffects weatherEffect;
        protected WeatherConstants.EnvironmentDetector currentEnvironmentType;
        protected Dictionary<string, MyEntityStat> statCache = new Dictionary<string, MyEntityStat>();
        protected Vector2 currentTemperature = new Vector2(0, 0);

        public BaseCharacterEntity(IMyCharacter entity)
            : base(entity)
        {
            ConfigureCharacter(entity);
        }

        protected IMyCubeBlock GetControlledEntity()
        {
            return Entity.Parent as IMyCubeBlock;
        }

        protected bool HasControlledEntity()
        {
            return GetControlledEntity() != null;
        }

        protected MyEntityStat GetPlayerStat(string statName)
        {
            var statKey = statName.ToLower();
            if (statCache.ContainsKey(statKey))
                return statCache[statKey];
            MyEntityStat stat;
            StatComponent.TryGetStat(MyStringHash.GetOrCompute(statName), out stat);
            if (stat != null)
            {
                statCache.Add(statKey, stat);
            }
            return stat;
        }

        public MyEntityStat GetStatCache(string statKey)
        {
            if (statCache.ContainsKey(statKey))
                return statCache[statKey];
            return null;
        }

        protected void ClearStatsCache()
        {
            statCache.Clear();
        }

        protected bool IsCharacterWalking()
        {
            return Entity != null &&
                (int)Entity.CurrentMovementState >= (int)MyCharacterMovementEnum.Walking &&
                (int)Entity.CurrentMovementState < (int)MyCharacterMovementEnum.Running;
        }

        protected bool IsCharacterRuning()
        {
            return Entity != null &&
                (int)Entity.CurrentMovementState >= (int)MyCharacterMovementEnum.Running &&
                (int)Entity.CurrentMovementState < (int)MyCharacterMovementEnum.Sprinting;
        }

        protected bool IsCharacterSprinting()
        {
            return Entity != null && (int)Entity.CurrentMovementState == (int)MyCharacterMovementEnum.Sprinting;
        }

        protected bool IsCharacterFlying()
        {
            return Entity != null && (int)Entity.CurrentMovementState == (int)MyCharacterMovementEnum.Flying;
        }

        protected bool IsCharacterFalling()
        {
            return Entity != null && (int)Entity.CurrentMovementState == (int)MyCharacterMovementEnum.Falling;
        }

        protected bool IsCharacterSitting()
        {
            return Entity != null && (int)Entity.CurrentMovementState == (int)MyCharacterMovementEnum.Sitting;
        }
        
        protected bool IsCharacterMoving()
        {
            return Entity != null &&
                !HasControlledEntity() &&
                (IsCharacterWalking() || IsCharacterRuning() || IsCharacterSprinting());
        }

        protected bool IsCharacterUsingTool()
        {
            if (HasEquippedTool)
            {
                var handTool = Entity.EquippedTool as IMyEngineerToolBase;
                if (handTool != null)
                    return handTool.IsShooting;
                var handDrill = Entity.EquippedTool as IMyHandDrill;
                if (handDrill != null)
                    return handDrill.IsShooting;
                var rifleGun = Entity.EquippedTool as IMyAutomaticRifleGun;
                if (rifleGun != null)
                    return rifleGun.IsShooting;
            }
            return false;
        }

        public bool HasEquippedTool
        {
            get
            {
                return Entity.EquippedTool != null;
            }
        }

        protected MyDefinitionId? GetEquippedToolItemId()
        {
            if (HasEquippedTool)
            {
                var handTool = Entity.EquippedTool as IMyEngineerToolBase;
                if (handTool != null)
                    return handTool.PhysicalItemDefinition.Id;
                var handDrill = Entity.EquippedTool as IMyHandDrill;
                if (handDrill != null)
                    return handDrill.PhysicalItemDefinition.Id;
                var rifleGun = Entity.EquippedTool as IMyAutomaticRifleGun;
                if (rifleGun != null)
                    return rifleGun.PhysicalItemDefinition.Id;
            }
            return null;
        }

        protected MyDefinitionId? GetEquippedToolId()
        {
            if (HasEquippedTool)
            {
                var handTool = Entity.EquippedTool as IMyEngineerToolBase;
                if (handTool != null)
                    return handTool.DefinitionId;
                var handDrill = Entity.EquippedTool as IMyHandDrill;
                if (handDrill != null)
                    return handDrill.DefinitionId;
                var rifleGun = Entity.EquippedTool as IMyAutomaticRifleGun;
                if (rifleGun != null)
                    return rifleGun.DefinitionId;
            }
            return null;
        }

        protected float GetSpeed()
        {
            return Entity.Physics.Speed;
        }

        protected void RestoreStatValue(MyEntityStat stat, Vector4 storeValue, float minFactor)
        {
            var storedFactor = storeValue.Z / stat.MaxValue;
            if (storedFactor > minFactor)
            {
                stat.Value = storeValue.Z;
            }
            else
            {
                stat.Value = minFactor * stat.MaxValue;
            }
        }

        protected virtual void OnBeginConfigureCharacter()
        {
            Entity.CharacterDied += Character_CharacterDied;
            StatComponent = Entity.Components.Get<MyEntityStatComponent>() as MyCharacterStatComponent;
            ClearStatsCache();
            if (StatComponent != null)
                Health = GetPlayerStat("Health");
        }

        public virtual void OnReciveDamage(MyDamageInformation damage)
        {

        }

        protected virtual void OnEndConfigureCharacter()
        {
            if (StatComponent != null)
                Health.OnStatChanged += Health_OnStatChanged;
            Inventory = Entity.GetInventory() as MyInventory;
            if (Inventory != null)
            {
                if (ExtendedSurvivalCoreAPI.Registered)
                {
                    InventoryObserver = ExtendedSurvivalCoreAPI.AddInventoryObserver(Entity, 0);
                }
                Inventory.ContentsRemoved += Inventory_ContentsRemoved;
            }
            hasDied = false;
        }

        protected virtual void OnCharacterDied()
        {
            Health.OnStatChanged -= Health_OnStatChanged;
        }

        protected DateTime lastTimeDead;
        protected void Character_CharacterDied(IMyCharacter obj)
        {
            lastTimeDead = DateTime.Now;
            hasDied = true;
            OnCharacterDied();
        }

        public void ConfigureCharacter(IMyCharacter entity)
        {
            try
            {
                if (Entity != null && (Entity != entity || !IsValid))
                    ResetConfiguration();
                if (Entity == null || !IsValid)
                {
                    Entity = entity;
                    OnBeginConfigureCharacter();
                    OnEndConfigureCharacter();
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogWarning(GetType(), $"ConfigureCharacter [Error]");
                ExtendedSurvivalStatsLogging.Instance.LogError(GetType(), ex);
            }
        }

        protected virtual void OnBeginResetConfiguration()
        {
            if (Health != null)
                Health.OnStatChanged -= Health_OnStatChanged;
            if (Inventory != null)
                Inventory.ContentsRemoved -= Inventory_ContentsRemoved;
            if (InventoryObserver != Guid.Empty)
            {
                if (ExtendedSurvivalCoreAPI.Registered)
                    ExtendedSurvivalCoreAPI.DisposeInventoryObserver(InventoryObserver);
            }
        }

        protected virtual void OnEndResetConfiguration()
        {
            Entity = null;
            StatComponent = null;
            Health = null;
            Inventory = null;
            Inventory = null;
            InventoryObserver = Guid.Empty;
        }

        protected void ResetConfiguration()
        {
            OnBeginResetConfiguration();
            OnEndResetConfiguration();
        }

        protected virtual void OnHealthChanged(float newValue, float oldValue, object statChangeData)
        {

        }

        protected void Health_OnStatChanged(float newValue, float oldValue, object statChangeData)
        {
            lastHealthChanged = new Vector2(newValue, oldValue);
            OnHealthChanged(newValue, oldValue, statChangeData);
        }

        protected virtual void OnInventoryContentsRemoved(MyPhysicalInventoryItem item, MyFixedPoint ammount)
        {

        }

        protected void Inventory_ContentsRemoved(MyPhysicalInventoryItem item, MyFixedPoint ammount)
        {
            lastRemovedIten = new KeyValuePair<MyPhysicalInventoryItem, MyFixedPoint>(item, ammount);
            OnInventoryContentsRemoved(item, ammount);
        }

        protected void RefreshWeatherInfo()
        {
            var playerPos = Entity.GetPosition();
            var weather = MyAPIGateway.Session.WeatherEffects.GetWeather(playerPos);
            weatherIntensity = MyAPIGateway.Session.WeatherEffects.GetWeatherIntensity(playerPos);
            weatherLevel = weather.Contains("Heavy") ? WeatherConstants.WeatherEffectsLevel.Heavy : WeatherConstants.WeatherEffectsLevel.Light;
            if (weather.Contains("Rain"))
                weatherEffect = WeatherConstants.WeatherEffects.Rain;
            else if (weather.Contains("Thunderstorm"))
                weatherEffect = WeatherConstants.WeatherEffects.Thunderstorm;
            else
                weatherEffect = WeatherConstants.WeatherEffects.None;
            currentEnvironmentType = GetEnvironmentType();
            switch (currentEnvironmentType)
            {
                case WeatherConstants.EnvironmentDetector.Atmosphere:
                case WeatherConstants.EnvironmentDetector.Underwater:
                    Vector3D pos = Entity.GetPosition();
                    if (ExtendedSurvivalCoreAPI.Registered)
                        currentTemperature = ExtendedSurvivalCoreAPI.GetTemperatureInPoint(PlanetAtRange.EntityId, pos).Value;
                    else
                        currentTemperature = new Vector2(0, WeatherConstants.SPACE_TEMPERATURE);
                    break;
                case WeatherConstants.EnvironmentDetector.ShipOrStation:
                    currentTemperature = new Vector2(0.5f, WeatherConstants.PRESURIZED_TEMPERATURE);
                    break;
                case WeatherConstants.EnvironmentDetector.None:
                case WeatherConstants.EnvironmentDetector.Space:
                default:
                    currentTemperature = new Vector2(0, WeatherConstants.SPACE_TEMPERATURE);
                    break;
            }
        }

        protected WeatherConstants.EnvironmentDetector GetEnvironmentType()
        {
            WeatherConstants.EnvironmentDetector currentValue;
            Entity?.Components?.Get<MyCharacterOxygenComponent>()?.UpdateBeforeSimulation100();
            Vector3D pos = Entity.GetPosition();
            var externalO2 = Math.Round(Entity.EnvironmentOxygenLevel * 100, 0);
            var platAtRange = PlanetAtRange;
            if (Entity.Physics == null || (Entity.Physics != null && Entity.Physics.Gravity.LengthSquared() > 0f))
            {
                if (platAtRange != null && platAtRange.Entity.HasAtmosphere && platAtRange.Entity.GetAirDensity(pos) > 0f)
                    currentValue = WeatherConstants.EnvironmentDetector.Atmosphere;
                else
                    currentValue = WeatherConstants.EnvironmentDetector.Space;
            }
            else
                currentValue = WeatherConstants.EnvironmentDetector.Space;
            double o2AtPos = 0;
            if (currentValue == WeatherConstants.EnvironmentDetector.Atmosphere)
            {
                if (WaterAPI.Registered && platAtRange.HasWater && WaterAPI.IsUnderwater(pos) && (WaterAPI.GetDepth(Entity.GetPosition()).Value * -1) > 1.5f)
                    return WeatherConstants.EnvironmentDetector.Underwater;
                o2AtPos = Math.Round(platAtRange.Entity.GetOxygenForPosition(pos) * 100, 0);
            }
            if (Math.Abs(o2AtPos < externalO2 ? o2AtPos - externalO2 : externalO2 - o2AtPos) > 1f)
                return WeatherConstants.EnvironmentDetector.ShipOrStation;
            else
                return currentValue;
        }

    }

}