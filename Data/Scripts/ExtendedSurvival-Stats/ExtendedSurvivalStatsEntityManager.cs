using Sandbox.Game;
using Sandbox.Game.Components;
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
                        var statComp = playerList.FirstOrDefault().Character?.Components?.Get<MyEntityStatComponent>() as MyCharacterStatComponent;
                        if (statComp != null)
                        {
                            PlayerActionsController.PlayerHealthRecharging(playerId, statComp);
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
                    SuperficialMiningController.InitShipDrillCollec();
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

        public HandheldGunInfo GetHandheldGun(long id)
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

        }

        private void Entities_OnEntityAdd(MyEntity entity)
        {
            if (inicialLoadComplete)
            {
                var floatingObj = entity as MyFloatingObject;
                if (floatingObj != null)
                {
                    SuperficialMiningController.CheckEntityIsAFloatingObject(floatingObj);
                    BonusGatheringController.DoExecuteBonusGathering(floatingObj);
                }
            }
        }

    }

}
