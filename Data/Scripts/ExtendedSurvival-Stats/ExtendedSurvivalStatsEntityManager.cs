using Sandbox.Game;
using Sandbox.Game.Entities;
using Sandbox.ModAPI;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRage.Game;
using VRage.Game.Components;
using VRage.Game.Entity;
using VRage.Game.ModAPI;
using VRageMath;

namespace ExtendedSurvival.Stats
{
    [MySessionComponentDescriptor(MyUpdateOrder.NoUpdate)]
    public class ExtendedSurvivalStatsEntityManager : BaseSessionComponent
    {

        public static ExtendedSurvivalStatsEntityManager Instance { get; private set; }

        public ConcurrentDictionary<long, PlayerCharacterEntity> PlayerCharacters { get; private set; } = new ConcurrentDictionary<long, PlayerCharacterEntity>();
        public ConcurrentDictionary<long, BotCharacterEntity> BotCharacters { get; private set; } = new ConcurrentDictionary<long, BotCharacterEntity>();
        public ConcurrentDictionary<long, IMyPlayer> Players { get; private set; } = new ConcurrentDictionary<long, IMyPlayer>();

        private bool inicialLoadComplete = false;

        protected override void DoInit(MyObjectBuilder_SessionComponent sessionComponent)
        {
            if (MyAPIGateway.Session.IsServer)
            {
                MyVisualScriptLogicProvider.PlayerHealthRecharging = (playerId, blockType, value) => {
                    var playerList = new List<IMyPlayer>();
                    MyAPIGateway.Players.GetPlayers(playerList, (player) => { return player.IdentityId == playerId; });
                    if (playerList.Any())
                    {
                        if (PlayerCharacters.Any(x => x.Value.PlayerId == playerId))
                        {
                            var playerChar = PlayerCharacters.FirstOrDefault(x => x.Value.PlayerId == playerId).Value;
                            if (playerChar != null)
                                playerChar.PlayerHealthRecharging();
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
                else
                {
                    ExtendedSurvivalStatsLogging.Instance.LogInfo(GetType(), $"RegisterSecureMessageHandler EntityCallsMsgHandler");
                    MyAPIGateway.Multiplayer.RegisterSecureMessageHandler(ExtendedSurvivalStatsSession.NETWORK_ID_ENTITYCALLS, EntityCallsMsgHandler);
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(GetType(), ex);
            }
            base.BeforeStart();
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
                                syncComponent.CallFromServer(mCommandData.content[2], componentParams);
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
            if (MyAPIGateway.Session.IsServer)
            {
                Players?.Clear();
                Players = null;
                MyVisualScriptLogicProvider.PlayerConnected -= Players_PlayerConnected;
                MyVisualScriptLogicProvider.PlayerDisconnected -= Players_PlayerDisconnected;
                MyEntities.OnEntityAdd -= Entities_OnEntityAdd;
                MyEntities.OnEntityRemove -= Entities_OnEntityRemove;
            }
            base.UnloadData();
        }

        public ExtendedSurvivalCoreAPI.HandheldGunInfo GetHandheldGun(long id)
        {
            if (ExtendedSurvivalCoreAPI.Registered)
                return ExtendedSurvivalCoreAPI.GetHandheldGunInfo(id);
            return null;
        }

        public void Players_PlayerConnected(long playerId)
        {
            UpdatePlayerList();
        }

        public void Players_PlayerDisconnected(long playerId)
        {
            UpdatePlayerList();
        }

        public PlayerCharacterEntity GetPlayerCharacterBySteamId(ulong steamId)
        {
            var query = PlayerCharacters.Where(x => x.Value.Player?.SteamUserId == steamId);
            return query.Any() ? query.FirstOrDefault().Value : null;
        }

        public PlayerCharacterEntity GetPlayerCharacter(long playerId)
        {
            var query = PlayerCharacters.Where(x => x.Value.PlayerId == playerId);
            return query.Any() ? query.FirstOrDefault().Value : null;
        }

        public BaseCharacterEntity GetCharacter(long id)
        {
            if (PlayerCharacters.ContainsKey(id))
                return PlayerCharacters[id];
            if (BotCharacters.ContainsKey(id))
                return BotCharacters[id];
            return null;
        }

        public void UpdatePlayerList()
        {
            Players.Clear();
            var tempPlayers = new List<IMyPlayer>();
            MyAPIGateway.Players.GetPlayers(tempPlayers);

            foreach (var p in tempPlayers)
            {
                if (p?.Character == null || p.Character.IsDead)
                    continue;

                if (p.IsValidPlayer())
                    Players[p.IdentityId] = p;
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

        }

        private void Entities_OnEntityRemove(MyEntity entity)
        {
            var character = entity as IMyCharacter;
            if (character != null)
            {
                if (BotCharacters.ContainsKey(character.EntityId))
                    BotCharacters.Remove(character.EntityId);
            }
        }

        private void Entities_OnEntityAdd(MyEntity entity)
        {
            if (inicialLoadComplete)
            {
                string entityName = entity.ToString();
                if (SuperficialMiningController.CheckEntityIsAFloatingObject(entity))
                    return;
            }
            var character = entity as IMyCharacter;
            if (character != null)
            {
                var playerId = character.GetPlayerId();
                if (character.IsValidPlayer())
                {
                    UpdatePlayerList();
                    ExtendedSurvivalStatsLogging.Instance.LogInfo(typeof(ExtendedSurvivalStatsEntityManager), $"MyEntities_OnEntityAddWatcher IMyCharacter PlayerId:{playerId} EntityId:{character.EntityId} DisplayName:{character.DisplayName}");
                    if (PlayerCharacters.Any(x => x.Value.PlayerId == playerId))
                    {
                        var playerChar = PlayerCharacters.FirstOrDefault(x => x.Value.PlayerId == playerId).Value;
                        playerChar.ConfigureCharacter(character);
                    }
                    else
                    {
                        PlayerCharacters[character.EntityId] = new PlayerCharacterEntity(character);
                    }
                }
                else
                {
                    if (!BotCharacters.ContainsKey(character.EntityId))
                    {
                        ExtendedSurvivalStatsLogging.Instance.LogInfo(typeof(ExtendedSurvivalStatsEntityManager), $"MyEntities_OnEntityAddWatcher IMyCharacter BotId:{playerId} EntityId:{character.EntityId} DisplayName:{character.Name}");
                        BotCharacters[character.EntityId] = new BotCharacterEntity(character);
                    }
                }
            }
        }

        public BotCharacterEntity[] GetBotInRange(long caller, Vector3D position, float maxDistance, bool ignoreDead = true)
        {
            var query = BotCharacters.Where(x => x.Key != caller && (!ignoreDead || !x.Value.IsDead) && Vector3D.Distance(x.Value.Entity.GetPosition(), position) <= maxDistance);
            return query.Any() ? query.Select(x => x.Value).ToArray() : null;
        }

        public IMyPlayer GetClosestPlayer(Vector3D rPos)
        {
            double distanceSqd = double.MaxValue;
            IMyPlayer closest = null;

            foreach (var player in Players.Values)
            {
                if (player?.Character == null || player.Character.IsDead)
                    continue;

                var d = Vector3D.DistanceSquared(player.Character.PositionComp.WorldAABB.Center, rPos);
                if (d < distanceSqd)
                {
                    closest = player;
                    distanceSqd = d;
                }
            }

            return closest;
        }

    }

}
