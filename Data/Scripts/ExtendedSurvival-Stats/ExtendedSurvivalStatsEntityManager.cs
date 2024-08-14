using Sandbox.Definitions;
using Sandbox.Game;
using Sandbox.Game.Components;
using Sandbox.Game.Entities;
using Sandbox.Game.Entities.Character;
using Sandbox.Game.Weapons;
using Sandbox.Game.World;
using Sandbox.ModAPI;
using Sandbox.ModAPI.Weapons;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRage.Game;
using VRage.Game.Components;
using VRage.Game.Entity;
using VRage.Game.ModAPI;
using VRage.ModAPI;
using VRageMath;
using VRageRender;

namespace ExtendedSurvival.Stats
{

    [MySessionComponentDescriptor(MyUpdateOrder.NoUpdate)]
    public class ExtendedSurvivalStatsEntityManager : BaseSessionComponent
    {

        public static ExtendedSurvivalStatsEntityManager Instance { get; private set; }

        public ConcurrentDictionary<long, IMyPlayer> Players { get; private set; } = new ConcurrentDictionary<long, IMyPlayer>();

        private bool inicialLoadComplete = false;

        public static IMyPlayer GetPlayerById(long id)
        {
            if (Instance.Players.ContainsKey(id))
                return Instance.Players[id];
            return null;
        }

        public static IMyPlayer GetPlayerBySteamId(ulong id)
        {
            if (Instance.Players.Any(x => x.Value.SteamUserId == id))
                return Instance.Players.Values.FirstOrDefault(x => x.SteamUserId == id);
            return null;
        }

        protected override void DoInit(MyObjectBuilder_SessionComponent sessionComponent)
        {
            if (MyAPIGateway.Session.IsServer)
            {
                MyVisualScriptLogicProvider.PlayerHealthRecharging += (playerId, blockType, value) => {
                    var playerList = new List<IMyPlayer>();
                    MyAPIGateway.Players.GetPlayers(playerList, (player) => { return player.IdentityId == playerId; });
                    if (playerList.Any())
                    {
                        var statComp = playerList.FirstOrDefault().Character?.Components?.Get<MyEntityStatComponent>() as MyCharacterStatComponent;
                        if (statComp != null)
                        {
                            PlayerHealthController.PlayerHealthRecharging(playerId, statComp);
                        }
                    }
                };
            }
        }

        public override void BeforeStart()
        {
            try
            {
                Instance = this;
                if (IsServer)
                {
                    RegisterWatcher();
                }
                ExtendedSurvivalStatsLogging.Instance.LogInfo(GetType(), $"RegisterSecureMessageHandler EntityCallsMsgHandler");
                MyAPIGateway.Multiplayer.RegisterSecureMessageHandler(ExtendedSurvivalStatsSession.NETWORK_ID_ENTITYCALLS, EntityCallsMsgHandler);
                MyAPIGateway.Multiplayer.RegisterSecureMessageHandler(ExtendedSurvivalStatsSession.NETWORK_ID_APICALLS, ApiCallsMsgHandler);
            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(GetType(), ex);
            }
            base.BeforeStart();
        }

        public void SendCallClient(ulong caller, string method, Dictionary<string, string> extraParams)
        {
            var cmd = new Command(caller, method);
            var extraData = new CommandExtraParams() { extraParams = extraParams.Select(x => new CommandExtraParam() { id = x.Key, data = x.Value }).ToArray() };
            string extraDataToSend = MyAPIGateway.Utilities.SerializeToXML<CommandExtraParams>(extraData);
            cmd.data = Encoding.Unicode.GetBytes(extraDataToSend);
            string messageToSend = MyAPIGateway.Utilities.SerializeToXML<Command>(cmd);
            MyAPIGateway.Multiplayer.SendMessageToServer(
                ExtendedSurvivalStatsSession.NETWORK_ID_APICALLS,
                Encoding.Unicode.GetBytes(messageToSend)
            );
        }

        public void SendCallServer(ulong[] target, string method, Dictionary<string, string> extraParams)
        {
            if (IsDedicated && !target.Any())
            {
                var players = new List<IMyPlayer>();
                MyAPIGateway.Players.GetPlayers(players);
                if (players.Any())
                    target = players.Select(x => x.SteamUserId).ToArray();
                else
                    return;
            }
            var cmd = new Command(0, method);
            var extraData = new CommandExtraParams() { extraParams = extraParams.Select(x => new CommandExtraParam() { id = x.Key, data = x.Value }).ToArray() };
            string extraDataToSend = MyAPIGateway.Utilities.SerializeToXML<CommandExtraParams>(extraData);
            cmd.data = Encoding.Unicode.GetBytes(extraDataToSend);
            string messageToSend = MyAPIGateway.Utilities.SerializeToXML<Command>(cmd);
            if (!target.Any())
            {
                MyAPIGateway.Multiplayer.SendMessageToOthers(
                    ExtendedSurvivalStatsSession.NETWORK_ID_APICALLS,
                    Encoding.Unicode.GetBytes(messageToSend)
                );
            }
            else
            {
                foreach (var item in target)
                {
                    MyAPIGateway.Multiplayer.SendMessageTo(
                        ExtendedSurvivalStatsSession.NETWORK_ID_APICALLS,
                        Encoding.Unicode.GetBytes(messageToSend),
                        item
                    );
                }
            }
        }

        private void ApiCallsMsgHandler(ushort netId, byte[] data, ulong steamId, bool fromServer)
        {
            try
            {
                if (netId != ExtendedSurvivalStatsSession.NETWORK_ID_APICALLS)
                    return;
                var message = Encoding.Unicode.GetString(data);
                var mCommandData = MyAPIGateway.Utilities.SerializeFromXML<Command>(message);
                var componentParamData = Encoding.Unicode.GetString(mCommandData.data);
                var componentParams = MyAPIGateway.Utilities.SerializeFromXML<CommandExtraParams>(componentParamData);
                switch (mCommandData.content[0])
                {
                    case "WeatherConstants":
                        if (fromServer)
                        {
                            WeatherConstants.CurrentWeatherInfo.LoadData(componentParams.extraParams.ToDictionary(x => x.id, x => x.data));
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(GetType(), ex);
            }
        }

        private void EntityCallsMsgHandler(ushort netId, byte[] data, ulong steamId, bool fromServer)
        {
            try
            {
                if (netId != ExtendedSurvivalStatsSession.NETWORK_ID_ENTITYCALLS)
                    return;
                var message = Encoding.Unicode.GetString(data);
                var mCommandData = MyAPIGateway.Utilities.SerializeFromXML<Command>(message);
                long entityId = long.Parse(mCommandData.content[0]);
                var entity = MyEntities.GetEntityById(entityId);
                if (entity != null)
                {
                    var blockLogic = entity.GameLogic;
                    if (blockLogic != null)
                    {
                        var compositeLogic = blockLogic as MyCompositeGameLogicComponent;
                        if (compositeLogic != null)
                        {
                            blockLogic = compositeLogic.GetComponents().FirstOrDefault(x => x.GetType().Name.Contains(mCommandData.content[1]));
                        }
                        if (blockLogic != null)
                        {
                            var syncComponent = blockLogic as IMySyncDataComponent;
                            if (syncComponent != null)
                            {
                                var componentParamData = Encoding.Unicode.GetString(mCommandData.data);
                                var componentParams = MyAPIGateway.Utilities.SerializeFromXML<CommandExtraParams>(componentParamData);
                                if (fromServer)
                                    syncComponent.CallFromServer(mCommandData.content[2], componentParams);
                                else
                                    syncComponent.CallFromClient(steamId, mCommandData.content[2], componentParams);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(GetType(), ex);
            }
        }

        protected override void UnloadData()
        {
            try
            {
                if (IsServer)
                {
                    Players?.Clear();
                    Players = null;
                    MyVisualScriptLogicProvider.PlayerConnected -= Players_PlayerConnected;
                    MyVisualScriptLogicProvider.PlayerDisconnected -= Players_PlayerDisconnected;
                    MyEntities.OnEntityAdd -= Entities_OnEntityAdd;
                    MyEntities.OnEntityRemove -= Entities_OnEntityRemove;
                    MyAPIGateway.Projectiles.OnProjectileAdded -= Projectiles_OnProjectileAdded;
                }
                MyAPIGateway.Multiplayer.UnregisterSecureMessageHandler(ExtendedSurvivalStatsSession.NETWORK_ID_ENTITYCALLS, EntityCallsMsgHandler);
                MyAPIGateway.Multiplayer.UnregisterSecureMessageHandler(ExtendedSurvivalStatsSession.NETWORK_ID_APICALLS, ApiCallsMsgHandler);
            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(GetType(), ex);
            }
            base.UnloadData();
        }

        public HandheldGunInfo GetHandheldGun(long id, out IMyAutomaticRifleGun gun)
        {
            gun = null;
            if (ExtendedSurvivalCoreAPI.Registered)
                return ExtendedSurvivalCoreAPI.GetHandheldGunInfo(id, out gun);
            return null;
        }

        public void Players_PlayerConnected(long playerId)
        {
            MyAPIGateway.Parallel.Start(() => {
                MyAPIGateway.Parallel.Sleep(1000);

                var tempPlayers = new List<IMyPlayer>();
                MyAPIGateway.Players.GetPlayers(tempPlayers, (x) => x.Identity.IdentityId == playerId);
                if (tempPlayers.Count > 0)
                {
                    DoProcessPlayerList(tempPlayers);
                }
            });
        }

        public void Players_PlayerDisconnected(long playerId)
        {
            if (Players.ContainsKey(playerId))
                Players.Remove(playerId);
        }

        public void UpdatePlayerList()
        {
            Players.Clear();
            var tempPlayers = new List<IMyPlayer>();
            MyAPIGateway.Players.GetPlayers(tempPlayers);
            DoProcessPlayerList(tempPlayers);
        }

        private void DoProcessPlayerList(List<IMyPlayer> tempPlayers)
        {
            foreach (var p in tempPlayers)
            {
                if (p.IsValidPlayer())
                {
                    Players[p.IdentityId] = p;
                }
            }
        }

        public void RegisterWatcher()
        {

            foreach (var entity in MyEntities.GetEntities())
            {
                Entities_OnEntityAdd(entity);
            }
            inicialLoadComplete = true;

            UpdatePlayerList();

            MyVisualScriptLogicProvider.PlayerConnected += Players_PlayerConnected;
            MyVisualScriptLogicProvider.PlayerDisconnected += Players_PlayerDisconnected;

            MyEntities.OnEntityAdd += Entities_OnEntityAdd;
            MyEntities.OnEntityRemove += Entities_OnEntityRemove;

            MyAPIGateway.Projectiles.OnProjectileAdded += Projectiles_OnProjectileAdded;

        }

        public static Vector3 GetDeviatedVector(float deviateAngle, Vector3 direction)
        {
            return MyUtilRandomVector3ByDeviatingVector.GetRandom(direction, deviateAngle);
        }

        public static void AddProjectile(MyDefinitionBase weaponDefinition, MyDefinitionBase ammoDefinition, bool isDeviated, bool isAiming, 
            float deviateShotAngle, float deviateShotAngleAiming, Vector3D initialPosition, Vector3 initialVelocity, Vector3 direction, 
            MyEntity ownerBlock)
        {
            Vector3 directionNormalized = direction;
            if (isDeviated)
            {
                float deviateAngle = deviateShotAngle;
                if (isAiming)
                {
                    deviateAngle = deviateShotAngleAiming;
                }

                directionNormalized = GetDeviatedVector(deviateAngle, direction);
                directionNormalized.Normalize();
            }

            if (!directionNormalized.IsValid())
            {
                return;
            }

            MyAPIGateway.Projectiles.Add(weaponDefinition, ammoDefinition, initialPosition, initialVelocity, directionNormalized, ownerBlock, null, ownerBlock, new MyEntity[] { });
        }

        private void Projectiles_OnProjectileAdded(ref MyProjectileInfo projectile, int index)
        {
            try
            {
                var playerId = MyAPIGateway.Players.TryGetIdentityId(projectile.OwningPlayer);
                if (playerId != 0)
                {
                    var player = GetPlayerById(playerId);
                    if (player != null)
                    {
                        var armorInfo = PlayerArmorController.GetEquipedArmor(playerId, useCache: true);
                        if (armorInfo != null)
                        {
                            var shootingAccuracy = Math.Min(armorInfo.GetEffect(ArmorSystemConstants.ArmorEffect.ShootingAccuracy), 0.9f);
                            if (shootingAccuracy > 0)
                            {
                                var deviateMultiplier = 1 - shootingAccuracy;
                                var weaponDefinition = projectile.WeaponDefinition as MyWeaponDefinition;
                                var ammoDefinition = projectile.ProjectileAmmoDefinition as MyAmmoDefinition;
                                var cubegrid = projectile.OwnerEntity as IMyCubeGrid;
                                if (cubegrid != null)
                                {
                                    var slimBlock = cubegrid.GetCubeBlock(cubegrid.WorldToGridInteger(projectile.Origin));
                                    var gunBlock = slimBlock?.FatBlock as IMyUserControllableGun;
                                    if (gunBlock != null)
                                    {
                                        var isTurret = (slimBlock.BlockDefinition as MyLargeTurretBaseDefinition) != null;
                                        var turretBlock = player?.Controller?.ControlledEntity?.Entity as IMyLargeTurretBase;
                                        if (turretBlock != null && isTurret && slimBlock.FatBlock?.EntityId == turretBlock.EntityId)
                                        {
                                            if (turretBlock.IsUnderControl && (weaponDefinition.DeviateShotAngle > 0 || weaponDefinition.DeviateShotAngleAiming > 0))
                                            {
                                                MyAPIGateway.Projectiles.MarkProjectileForDestroy(index);
                                                AddProjectile(
                                                    weaponDefinition,
                                                    ammoDefinition,
                                                    true,
                                                    false,
                                                    weaponDefinition.DeviateShotAngle * deviateMultiplier,
                                                    weaponDefinition.DeviateShotAngleAiming * deviateMultiplier,
                                                    projectile.Origin,
                                                    projectile.Velocity,
                                                    turretBlock.GetWorldMatrix().Forward,
                                                    turretBlock as MyEntity
                                                );
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    var character = projectile.OwnerEntity as IMyCharacter;
                                    if (character != null)
                                    {
                                        var isAiming = false;
                                        if (player != null && character != null && character.GetPlayerId() == playerId)
                                        {
                                            var handGun = character.EquippedTool as IMyGunBaseUser;
                                            if (handGun != null)
                                            {
                                                isAiming = character.CurrentMovementState.GetMode() == 2;
                                                MyAPIGateway.Projectiles.MarkProjectileForDestroy(index);
                                                AddProjectile(
                                                    weaponDefinition,
                                                    ammoDefinition,
                                                    true,
                                                    false,
                                                    weaponDefinition.DeviateShotAngle * deviateMultiplier,
                                                    weaponDefinition.DeviateShotAngleAiming * deviateMultiplier,
                                                    projectile.Origin,
                                                    projectile.Velocity,
                                                    handGun.Weapon.WorldMatrix.Forward,
                                                    handGun.Weapon
                                                );
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(GetType(), ex);
            }
        }

        private void Entities_OnEntityRemove(MyEntity entity)
        {

        }

        private void Entities_OnEntityAdd(MyEntity entity)
        {
            try
            {
                if (inicialLoadComplete)
                {
                    var floatingObj = entity as MyFloatingObject;
                    if (floatingObj != null)
                    {
                        BonusGatheringController.DoExecuteBonusGathering(floatingObj);
                        return;
                    }
                    var missile = entity as IMyMissile;
                    if (missile != null)
                    {
                        var laucherBlock = ExtendedSurvivalCoreAPI.FindGridBlockById(missile.LauncherId);
                        if (laucherBlock != null)
                        {
                            OnMissileShoot(missile, laucherBlock.FatBlock as IMyLargeTurretBase);
                        }
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(GetType(), ex);
            }
        }

        private void OnMissileShoot(IMyMissile missile, IMyLargeTurretBase currentEntity)
        {
            if (currentEntity != null)
            {
                var blockDefinition = MyDefinitionManager.Static.GetCubeBlockDefinition(currentEntity.BlockDefinition) as MyWeaponBlockDefinition;
                if (blockDefinition != null)
                {
                    var weaponDefinition = MyDefinitionManager.Static.GetWeaponDefinition(blockDefinition.WeaponDefinitionId);
                    if (weaponDefinition != null)
                    {
                        if (currentEntity.IsUnderControl && weaponDefinition.DeviateShotAngle > 0)
                        {
                            var player = ExtendedSurvivalStatsEntityManager.GetPlayerById((currentEntity as VRage.Game.ModAPI.Interfaces.IMyControllableEntity).ControllerInfo.ControllingIdentityId);
                            if (player != null && player.IsValidPlayer())
                            {
                                var playerId = player.IdentityId;
                                var armorInfo = PlayerArmorController.GetEquipedArmor(playerId, useCache: true);
                                if (armorInfo != null)
                                {
                                    var shootingAccuracy = Math.Min(armorInfo.GetEffect(ArmorSystemConstants.ArmorEffect.ShootingAccuracy), 0.9f);
                                    if (shootingAccuracy > 0)
                                    {
                                        var deviateMultiplier = 1 - shootingAccuracy;
                                        var deviateFinal = weaponDefinition.DeviateShotAngle * deviateMultiplier;
                                        var shootDir = currentEntity.GetWorldMatrix().Forward;

                                        Vector3 directionNormalized = shootDir;
                                        directionNormalized = GetDeviatedVector(deviateFinal, shootDir);
                                        directionNormalized.Normalize();

                                        var mwm = missile.WorldMatrix;
                                        var nmwm = Matrix.CreateLookAtInverse(missile.GetPosition(), directionNormalized, mwm.Up);

                                        missile.SetWorldMatrix(nmwm);
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
