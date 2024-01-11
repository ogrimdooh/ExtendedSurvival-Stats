using Sandbox.ModAPI;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using VRage.Game;
using VRage.Game.Components;
using VRage.Game.ModAPI;

namespace ExtendedSurvival.Stats
{
    [MySessionComponentDescriptor(MyUpdateOrder.NoUpdate)]
    public class ExtendedSurvivalStatsCommandController : BaseSessionComponent
    {

        public class ValidCommand
        {

            public string Command { get; set; }
            public int MinOptions { get; set; }
            public bool NotFixedOptions { get; set; }
            public HelpController.CommandEntryHelpInfo HelpInfo { get; set; }

            public ValidCommand(string command, int minOptions, bool notFixedOptions)
            {
                Command = command;
                MinOptions = minOptions;
                NotFixedOptions = notFixedOptions;
            }

        }

        public static ExtendedSurvivalStatsCommandController Static { get; private set; }

        protected override void DoInit(MyObjectBuilder_SessionComponent sessionComponent)
        {

            Static = this;

            if (!IsDedicated)
            {
                MyAPIGateway.Utilities.MessageEntered += OnMessageEntered;
            }

            if (IsServer)
            {

                MyAPIGateway.Multiplayer.RegisterSecureMessageHandler(ExtendedSurvivalStatsSession.NETWORK_ID_COMMANDS, ServerCommandsMsgHandler);

            }
            else
            {

                MyAPIGateway.Multiplayer.RegisterSecureMessageHandler(ExtendedSurvivalStatsSession.NETWORK_ID_COMMANDS, ClientCommandsMsgHandler);

            }

        }

        public override void LoadData()
        {
            base.LoadData();
            VALID_COMMANDS[SETTINGS_COMMAND] = new ValidCommand(SETTINGS_COMMAND, 3, false)
            {
                HelpInfo = new HelpController.CommandEntryHelpInfo()
                {
                    EntryId = new UniqueNameId(BASE_TOPIC_TYPE, SETTINGS_COMMAND),
                    Title = "Settings",
                    Description = LanguageProvider.GetEntry(LanguageEntries.HELP_COMMAND_SETTINGS_DESCRIPTION),
                    Syntax = "/settings <CONFIG> <VALUE>",
                    CommandSample = "/settings Debug true"
                }
            };
            VALID_COMMANDS[SETTINGS_COMMAND_FOOD_CLEAR_VOLUME] = new ValidCommand(SETTINGS_COMMAND_FOOD_CLEAR_VOLUME, 2, false);
            VALID_COMMANDS[SETTINGS_COMMAND_FOOD_SET_VOLUME] = new ValidCommand(SETTINGS_COMMAND_FOOD_SET_VOLUME, 3, false);
        }

        protected override void UnloadData()
        {
            try
            {
                if (!IsDedicated)
                {
                    MyAPIGateway.Utilities.MessageEntered -= OnMessageEntered;
                }
                if (IsServer)
                {
                    MyAPIGateway.Multiplayer.UnregisterSecureMessageHandler(ExtendedSurvivalStatsSession.NETWORK_ID_COMMANDS, ServerCommandsMsgHandler);
                }
                else
                {
                    MyAPIGateway.Multiplayer.UnregisterSecureMessageHandler(ExtendedSurvivalStatsSession.NETWORK_ID_COMMANDS, ClientCommandsMsgHandler);
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(GetType(), ex);
            }
            base.UnloadData();
        }

        private const string SETTINGS_COMMAND = "settings";
        private const string SETTINGS_COMMAND_FOOD_CLEAR_VOLUME = "food.clearvolume";
        private const string SETTINGS_COMMAND_FOOD_SET_VOLUME = "food.setvolume";

        private IMyHudNotification hudMsg;

        public const string BASE_TOPIC_TYPE = "ExtendedSurvival.Stats.Command";
        public ConcurrentDictionary<string, ValidCommand> VALID_COMMANDS = new ConcurrentDictionary<string, ValidCommand>();

        private void OnMessageEntered(string messageText, ref bool sendToOthers)
        {
            sendToOthers = true;
            if (!messageText.StartsWith("/")) return;
            var words = messageText.Trim().ToLower().Replace("/", "").Split(' ');
            if (words.Length > 0)
            {
                if (VALID_COMMANDS.ContainsKey(words[0]))
                {
                    if ((!VALID_COMMANDS[words[0]].NotFixedOptions && words.Length == VALID_COMMANDS[words[0]].MinOptions) ||
                        (VALID_COMMANDS[words[0]].NotFixedOptions && words.Length >= VALID_COMMANDS[words[0]].MinOptions))
                    {
                        sendToOthers = false;
                        Command cmd = new Command(MyAPIGateway.Multiplayer.MyId, words);
                        if (IsServer)
                        {
                            if (MyAPIGateway.Session.IsUserAdmin(MyAPIGateway.Multiplayer.MyId))
                            {
                                HandlerMsgCommand(MyAPIGateway.Multiplayer.MyId, cmd);
                            }
                        }
                        else
                        {
                            string message = MyAPIGateway.Utilities.SerializeToXML<Command>(cmd);
                            MyAPIGateway.Multiplayer.SendMessageToServer(
                                ExtendedSurvivalStatsSession.NETWORK_ID_COMMANDS,
                                Encoding.Unicode.GetBytes(message)
                            );
                        }
                    }
                }
            }
        }

        private void HandlerMsgCommand(ulong steamId, Command mCommandData)
        {
            if (MyAPIGateway.Session.IsUserAdmin(steamId))
            {
                if (VALID_COMMANDS.ContainsKey(mCommandData.content[0]))
                {
                    if ((!VALID_COMMANDS[mCommandData.content[0]].NotFixedOptions && mCommandData.content.Length == VALID_COMMANDS[mCommandData.content[0]].MinOptions) ||
                        (VALID_COMMANDS[mCommandData.content[0]].NotFixedOptions && mCommandData.content.Length >= VALID_COMMANDS[mCommandData.content[0]].MinOptions))
                    {
                        switch (mCommandData.content[0])
                        {
                            case SETTINGS_COMMAND:
                                if (DoCommand_Settings(mCommandData.content[1], mCommandData.content[2]))
                                {
                                    SendMessage(steamId, $"[ExtendedSurvivalCore] Config {mCommandData.content[1]} set to {mCommandData.content[2]}.", MyFontEnum.White);
                                }
                                break;
                            case SETTINGS_COMMAND_FOOD_CLEAR_VOLUME:
                                if (DoCommand_ClearFoodVolume(mCommandData.content[1]))
                                {
                                    SendMessage(steamId, $"[ExtendedSurvivalCore] Command {SETTINGS_COMMAND_FOOD_CLEAR_VOLUME} executed.", MyFontEnum.White);
                                }
                                break;
                            case SETTINGS_COMMAND_FOOD_SET_VOLUME:
                                if (DoCommand_SetFoodVolume(mCommandData.content[1], mCommandData.content[2]))
                                {
                                    SendMessage(steamId, $"[ExtendedSurvivalCore] Food {mCommandData.content[1]} set volume to {mCommandData.content[2]}.", MyFontEnum.White);
                                }
                                break;
                        }
                    }
                }
            }
        }

        private bool DoCommand_Settings(string name, string value)
        {
            return ExtendedSurvivalSettings.Instance.SetConfigValue(name, value);
        }

        private bool DoCommand_ClearFoodVolume(string name)
        {
            var key = FoodConstants.FOOD_DEFINITIONS.Keys.FirstOrDefault(x => x.subtypeId.String.ToLower() == name.ToLower());
            if (key != null)
            {
                return ExtendedSurvivalSettings.Instance.ClearFoodVolume(key);
            }
            return false;
        }

        private bool DoCommand_SetFoodVolume(string name, string value)
        {
            var key = FoodConstants.FOOD_DEFINITIONS.Keys.FirstOrDefault(x => x.subtypeId.String.ToLower() == name.ToLower());
            if (key != null)
            {
                float multiplier;
                if (float.TryParse(value, out multiplier))
                {
                    return ExtendedSurvivalSettings.Instance.SetFoodVolume(key, multiplier);
                }
            }
            return false;
        }

        private void ClientCommandsMsgHandler(ushort netId, byte[] data, ulong steamId, bool fromServer)
        {
            try
            {
                if (netId != ExtendedSurvivalStatsSession.NETWORK_ID_COMMANDS)
                    return;

                if (IsClient)
                {
                    var message = Encoding.Unicode.GetString(data);
                    var mCommandData = MyAPIGateway.Utilities.SerializeFromXML<Command>(message);

                    int timeToLive = 0;
                    if (mCommandData.content.Length == 3 &&
                        int.TryParse(mCommandData.content[2], out timeToLive))
                    {
                        ShowMessage(mCommandData.content[0], mCommandData.content[1], timeToLive);
                    }
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(GetType(), ex);
            }
        }

        private void ServerCommandsMsgHandler(ushort netId, byte[] data, ulong steamId, bool fromServer)
        {
            try
            {
                if (netId != ExtendedSurvivalStatsSession.NETWORK_ID_COMMANDS)
                    return;

                if (IsServer)
                {
                    var message = Encoding.Unicode.GetString(data);
                    var mCommandData = MyAPIGateway.Utilities.SerializeFromXML<Command>(message);

                    HandlerMsgCommand(steamId, mCommandData);
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(GetType(), ex);
            }
        }

        public void SendMessage(ulong target, string text, string font = MyFontEnum.Red, int timeToLive = 5000)
        {
            if (IsDedicated || (IsServer && MyAPIGateway.Multiplayer.MyId != target))
            {
                string[] values = new string[]
                {
                    text,
                    font,
                    timeToLive.ToString()
                };
                Command cmd = new Command(IsDedicated ? 0 : MyAPIGateway.Multiplayer.MyId, values);
                string message = MyAPIGateway.Utilities.SerializeToXML<Command>(cmd);
                MyAPIGateway.Multiplayer.SendMessageTo(
                    ExtendedSurvivalStatsSession.NETWORK_ID_COMMANDS,
                    Encoding.Unicode.GetBytes(message),
                    target
                );
            }
            else
            {
                ShowMessage(text, font, timeToLive);
            }
        }

        public void ShowMessage(string text, string font = MyFontEnum.Red, int timeToLive = 5000)
        {
            if (hudMsg == null)
                hudMsg = MyAPIGateway.Utilities.CreateNotification(string.Empty);

            hudMsg.Hide();
            hudMsg.Font = font;
            hudMsg.AliveTime = timeToLive;
            hudMsg.Text = text;
            hudMsg.Show();
        }

    }

}
