using Sandbox.Game;
using Sandbox.Game.Entities;
using Sandbox.Game.Entities.Character.Components;
using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRage.Game;
using VRage.Game.Components;
using VRage.Game.ModAPI;
using VRage.Utils;
using VRageMath;
using static VRageRender.MyBillboard;

namespace ExtendedSurvival.Stats
{

    [MySessionComponentDescriptor(MyUpdateOrder.AfterSimulation)]
    public class ExtendedSurvivalStatsSession : BaseSessionComponent
    {

        public static ExtendedSurvivalStatsSession Static { get; private set; }

        public HudAPIv2 TextAPI;
        public ExtendedSurvivalCoreAPI ESCoreAPI;

        public const ushort NETWORK_ID_STATSSYSTEM = 40522;
        public const ushort NETWORK_ID_COMMANDS = 40523;
        public const ushort NETWORK_ID_DEFINITIONS = 40524;
        public const ushort NETWORK_ID_ENTITYCALLS = 40525;
        public const string CALL_FOR_DEFS = "NEEDDEFS";

        protected override void DoInit(MyObjectBuilder_SessionComponent sessionComponent)
        {

            Static = this;

            if (!IsDedicated)
            {
                MyAPIGateway.Utilities.MessageEntered += OnMessageEntered;
                MyAPIGateway.Multiplayer.RegisterSecureMessageHandler(NETWORK_ID_STATSSYSTEM, ClientUpdateMsgHandler);
            }

            if (IsServer)
            {

                MyAPIGateway.Multiplayer.RegisterSecureMessageHandler(NETWORK_ID_COMMANDS, CommandsMsgHandler);

                MyAPIGateway.Session.DamageSystem.RegisterAfterDamageHandler(0, (entity, damage) =>
                {
                    if (entity != null)
                    {
                        var character = entity as IMyCharacter;
                        if (character != null)
                        {
                            if (character.IsValidPlayer())
                            {
                                if (ExtendedSurvivalStatsEntityManager.Instance.PlayerCharacters.ContainsKey(character.EntityId))
                                    ExtendedSurvivalStatsEntityManager.Instance.PlayerCharacters[character.EntityId].OnReciveDamage(damage);
                            }
                            else
                            {
                                if (ExtendedSurvivalStatsEntityManager.Instance.BotCharacters.ContainsKey(character.EntityId))
                                    ExtendedSurvivalStatsEntityManager.Instance.BotCharacters[character.EntityId].OnReciveDamage(damage);
                            }
                        }
                    }
                });

                MyAPIGateway.Session.SessionSettings.AutoHealing = false; /* Remove auto healing to control at playerentity */
                MyAPIGateway.Session.SessionSettings.WeatherSystem = true; /* multiple systens use weather */

                ForceWolfAndSpiders();

                MyAPIGateway.Multiplayer.RegisterSecureMessageHandler(NETWORK_ID_DEFINITIONS, ClientDefinitionsUpdateServerMsgHandler);

            }
            else
            {

                MyAPIGateway.Multiplayer.RegisterSecureMessageHandler(NETWORK_ID_DEFINITIONS, ClientDefinitionsUpdateMsgHandler);
                Command cmd = new Command(MyAPIGateway.Multiplayer.MyId, CALL_FOR_DEFS);
                string message = MyAPIGateway.Utilities.SerializeToXML<Command>(cmd);
                MyAPIGateway.Multiplayer.SendMessageToServer(
                    NETWORK_ID_DEFINITIONS,
                    Encoding.Unicode.GetBytes(message)
                );

            }

        }

        private const string SETTINGS_COMMAND = "settings";
        private const string SETTINGS_COMMAND_PLAYER_STATUS = "player.setstatus";

        private static readonly Dictionary<string, KeyValuePair<int, bool>> VALID_COMMANDS = new Dictionary<string, KeyValuePair<int, bool>>()
        {
            { SETTINGS_COMMAND, new KeyValuePair<int, bool>(3, false) },
            { SETTINGS_COMMAND_PLAYER_STATUS, new KeyValuePair<int, bool>(3, false) }
        };

        private void ClientUpdateMsgHandler(ushort netId, byte[] data, ulong steamId, bool fromServer)
        {
            try
            {
                if (netId != NETWORK_ID_STATSSYSTEM)
                    return;

                var message = Encoding.Unicode.GetString(data);
                var mPlayerData = MyAPIGateway.Utilities.SerializeFromXML<PlayerData>(message);

                if (TextAPI.Heartbeat == false && RunCount >= 300)
                {
                    MyAPIGateway.Utilities.ShowNotification("HUDAPI MOD MISSING", 5000, "Red");
                }

                if (mPlayerData != null && TextAPI.Heartbeat && false)
                {

                    if (!isHUDInit)
                    {
                        var xAlignValue = 0.175f;
                        var yAlignValue = 0.175f;

                        isHUDInit = true;

                        col01HUDMessage = new HudAPIv2.HUDMessage(
                            col01Builder,
                            new Vector2D(col01Position.X + xAlignValue, col01Position.Y + yAlignValue),
                            Scale: hudScale
                        );
                        col01HUDMessage.Blend = BlendTypeEnum.PostPP;

                        col02HUDMessage = new HudAPIv2.HUDMessage(
                            col02Builder,
                            new Vector2D(col02Position.X + xAlignValue, col02Position.Y + yAlignValue),
                            Scale: hudScale2,
                            Font: "monospace"
                        );
                        col02HUDMessage.Blend = BlendTypeEnum.PostPP;
                    }

                    if (isHUDInit)
                    {
                        foreach (var item in icons)
                        {
                            item.Value.Visible = false;
                        }
                        foreach (var item in statusIcons)
                        {
                            item.Value.Visible = false;
                        }
                        col01Builder.Clear();
                        col02Builder.Clear();
                        int c = 0;
                        int c2 = 0;
                        if (mPlayerData.ThirstEnabled)
                        {
                            BuildProgressDisplay(c, 1, ThirstIcon, "Thirst", mPlayerData.Thirst, col01Builder, ProgressDisplayType.Normal, false);
                            c++;
                        }
                        if (mPlayerData.HungerEnabled)
                        {
                            BuildProgressDisplay(c, 1, HungerIcon, "Hunger", mPlayerData.Hunger, col01Builder, ProgressDisplayType.Normal, false);
                            c++;
                        }
                        if (mPlayerData.StaminaEnabled)
                        {
                            BuildProgressDisplay(c, 1, StaminaIcon, "Stamina", mPlayerData.Stamina, col01Builder, ProgressDisplayType.Normal, false);
                            c++;
                        }
                        if (mPlayerData.BodyTemperatureEnabled)
                        {
                            var icon = BodyTemperature;
                            var bodyStatus = "Stable";
                            if (mPlayerData.TemperatureTime.Z > StatsConstants.MIN_TO_GET_EFFECT_OVERHITING)
                            {
                                bodyStatus = "Boiling";
                                icon = BodyTemperatureHot;
                            }
                            else if (mPlayerData.TemperatureTime.Z > StatsConstants.MIN_TO_GET_EFFECT_ONFIRE)
                            {
                                bodyStatus = "Too Hot";
                                icon = BodyTemperatureHot;
                            }
                            else if (mPlayerData.TemperatureTime.Z > 0)
                            {
                                bodyStatus = "Warming Up";
                            }
                            else if (mPlayerData.TemperatureTime.Z < StatsConstants.MIN_TO_GET_EFFECT_FROSTY)
                            {
                                bodyStatus = "Freezing";
                                icon = BodyTemperatureCold;
                            }
                            else if (mPlayerData.TemperatureTime.Z < StatsConstants.MIN_TO_GET_EFFECT_COLD)
                            {
                                bodyStatus = "Very Cold";
                                icon = BodyTemperatureCold;
                            }
                            else if (mPlayerData.TemperatureTime.Z < 0)
                            {
                                bodyStatus = "Cooling Down";
                            }
                            BuildProgressDisplay(c, 1, icon, string.Format("Body Temperature [{0}]", bodyStatus), mPlayerData.TemperatureTime, col01Builder, ProgressDisplayType.OnlyBar, false,
                                (percent) =>
                                {
                                    return percent <= 0.05f || percent >= 0.95f;
                                },
                                (percent) =>
                                {
                                    return percent <= 0.3f || percent >= 0.7f;
                                }
                            );
                            c++;
                        }
                        if (mPlayerData.UseMetabolism)
                        {
                            if (mPlayerData.IntakeBodyFood.Z > mPlayerData.IntakeBodyFood.X)
                            {
                                BuildProgressDisplay(c2, 2, null, "Intake Food         ", mPlayerData.IntakeBodyFood, col02Builder, ProgressDisplayType.OnlyPercent, false, (percent) => { return false; }, (percent) => { return false; });
                                c2++;
                            }
                            if (mPlayerData.IntakeBodyWater.Z > mPlayerData.IntakeBodyWater.X)
                            {
                                BuildProgressDisplay(c2, 2, null, "Intake Water        ", mPlayerData.IntakeBodyWater, col02Builder, ProgressDisplayType.OnlyPercent, false, (percent) => { return false; }, (percent) => { return false; });
                                c2++;
                            }
                            col01Builder.AppendLine();
                            BuildProgressDisplay(c, 1, BodyEnergy, "Body Energy", mPlayerData.BodyEnergy, col01Builder, ProgressDisplayType.Normal, false, lineBonus: 1);
                            c++;
                            BuildProgressDisplay(c, 1, BodyWater, "Body Water", mPlayerData.BodyWater, col01Builder, ProgressDisplayType.Normal, false, lineBonus: 1);
                            c++;
                            if (mPlayerData.UseNutrition)
                            {
                                BuildProgressDisplay(c2, 2, null, "Intake Carbohydrates", mPlayerData.IntakeCarbohydrates, col02Builder, ProgressDisplayType.OnlyPercent, false, (percent) => { return false; });
                                c2++;
                                BuildProgressDisplay(c2, 2, null, "Intake Protein      ", mPlayerData.IntakeProtein, col02Builder, ProgressDisplayType.OnlyPercent, false, (percent) => { return false; });
                                c2++;
                                BuildProgressDisplay(c2, 2, null, "Intake Lipids       ", mPlayerData.IntakeLipids, col02Builder, ProgressDisplayType.OnlyPercent, false, (percent) => { return false; });
                                c2++;
                                BuildProgressDisplay(c2, 2, null, "Intake Vitamins     ", mPlayerData.IntakeVitamins, col02Builder, ProgressDisplayType.OnlyPercent, false, (percent) => { return false; });
                                c2++;
                                BuildProgressDisplay(c2, 2, null, "Intake Minerals     ", mPlayerData.IntakeMinerals, col02Builder, ProgressDisplayType.OnlyPercent, false, (percent) => { return false; });
                                c2++;
                                col02Builder.AppendLine();
                                BuildProgressDisplay(c2, 2, null, "Body Muscles     ", mPlayerData.BodyMuscles, col02Builder, ProgressDisplayType.OnlyValues, false, lineBonus: 1);
                                c2++;
                                BuildProgressDisplay(c2, 2, null, "Body Fat         ", mPlayerData.BodyFat, col02Builder, ProgressDisplayType.OnlyValues, false, lineBonus: 1);
                                c2++;
                                BuildProgressDisplay(c2, 2, null, "Body Performance ", mPlayerData.BodyPerformance, col02Builder, ProgressDisplayType.OnlyValues, false, lineBonus: 1);
                                c2++;
                            }
                        }
                        bool lineBreak = false;
                        if (mPlayerData.WoundedTime.Z > mPlayerData.WoundedTime.X && mPlayerData.WoundedTime.Z < mPlayerData.WoundedTime.Y)
                        {
                            if (col02Builder.Length != 0 && !lineBreak)
                            {
                                lineBreak = true;
                                col02Builder.AppendLine();
                            }
                            BuildProgressDisplay(c2, 2, null, "Wound infection time", mPlayerData.WoundedTime, col02Builder, ProgressDisplayType.OnlyPercent, false,
                                (percent) => {
                                    return percent >= 0.95f;
                                },
                                (percent) => {
                                    return percent >= 0.7f;
                                },
                                lineBonus: 1
                            );
                            c2++;
                        }
                        if (mPlayerData.WetTime.Z > mPlayerData.WetTime.X)
                        {
                            if (col02Builder.Length != 0 && !lineBreak)
                            {
                                lineBreak = true;
                                col02Builder.AppendLine();
                            }
                            BuildProgressDisplay(c2, 2, null, "Wet body level      ", mPlayerData.WetTime, col02Builder, ProgressDisplayType.OnlyPercent, false,
                                (percent) => {
                                    return percent >= 0.95f;
                                },
                                (percent) => {
                                    return percent >= 0.7f;
                                },
                                lineBonus: 1
                            );
                            c2++;
                        }
                        if (col02Builder.Length != 0 && !lineBreak)
                        {
                            lineBreak = true;
                            col02Builder.AppendLine();
                        }
                        if (mPlayerData.CurrentEnvironmentType == WeatherConstants.EnvironmentDetector.Underwater)
                        {
                            col02Builder.AppendLine("<color=white>" + mPlayerData.CurrentEnvironmentType.ToString() + " [" + mPlayerData.Depth + "]");
                        }
                        else
                            col02Builder.AppendLine("<color=white>" + mPlayerData.CurrentEnvironmentType.ToString());
                        var temperatureLevel = WeatherConstants.TemperatureToLevel(mPlayerData.Temperature.Y);
                        string tempDesc = "";
                        string tempColor = "white";
                        switch (temperatureLevel)
                        {
                            case MyTemperatureLevel.ExtremeFreeze:
                                tempDesc = "Extreme Freeze";
                                tempColor = "red";
                                break;
                            case MyTemperatureLevel.Freeze:
                                tempDesc = "Freeze";
                                tempColor = "yellow";
                                break;
                            case MyTemperatureLevel.Cozy:
                                tempDesc = "Cozy";
                                tempColor = "white";
                                break;
                            case MyTemperatureLevel.Hot:
                                tempDesc = "Hot";
                                tempColor = "yellow";
                                break;
                            case MyTemperatureLevel.ExtremeHot:
                                tempDesc = "Extreme Hot";
                                tempColor = "red";
                                break;
                        }
                        col02Builder.AppendLine($"<color={tempColor}>Temperature: {Math.Round(mPlayerData.Temperature.Y, 2)}ºC [{tempDesc}]");
                        StringBuilder sb = new StringBuilder();
                        int ic = 0;
                        if (mPlayerData.CurrentSurvivalEffects != StatsConstants.SurvivalEffects.None)
                        {
                            foreach (var effect in StatsConstants.GetFlags(mPlayerData.CurrentSurvivalEffects))
                            {
                                IconDisplay(c, ic, StatsConstants.SurvivalEffectsIcons[effect], Color.Orange, lineBonus: 2);
                                ic++;
                                sb.Append((sb.ToString().Trim().Length > 0 ? ", " : "") + effect);
                            }
                        }
                        if (mPlayerData.CurrentDamageEffects != StatsConstants.DamageEffects.None)
                        {
                            foreach (var effect in StatsConstants.GetFlags(mPlayerData.CurrentDamageEffects))
                            {
                                IconDisplay(c, ic, StatsConstants.DamageEffectsIcons[effect], Color.Orange, lineBonus: 2);
                                ic++;
                                sb.Append((sb.ToString().Trim().Length > 0 ? ", " : "") + effect);
                            }
                        }
                        if (mPlayerData.CurrentTemperatureEffects != StatsConstants.TemperatureEffects.None)
                        {
                            foreach (var effect in StatsConstants.GetFlags(mPlayerData.CurrentTemperatureEffects))
                            {
                                IconDisplay(c, ic, StatsConstants.TemperatureEffectsIcons[effect], Color.Orange, lineBonus: 2);
                                ic++;
                                sb.Append((sb.ToString().Trim().Length > 0 ? ", " : "") + effect);
                            }
                        }
                        if (mPlayerData.CurrentDiseaseEffects != StatsConstants.DiseaseEffects.None)
                        {
                            foreach (var effect in StatsConstants.GetFlags(mPlayerData.CurrentDiseaseEffects))
                            {
                                IconDisplay(c, ic, StatsConstants.DiseaseEffectsIcons[effect], Color.Orange, lineBonus: 2);
                                ic++;
                                sb.Append((sb.ToString().Trim().Length > 0 ? ", " : "") + effect);
                            }
                        }
                        if (mPlayerData.CurrentOtherEffects != StatsConstants.OtherEffects.None)
                        {
                            foreach (var effect in StatsConstants.GetFlags(mPlayerData.CurrentOtherEffects))
                            {
                                IconDisplay(c, ic, StatsConstants.OtherEffectsIcons[effect], Color.Orange, lineBonus: 2);
                                ic++;
                                sb.Append((sb.ToString().Trim().Length > 0 ? ", " : "") + effect);
                            }
                        }
                        if (sb.Length > 0)
                        {
                            if (col01Builder.Length != 0)
                                col01Builder.AppendLine();
                            //col01Builder.AppendLine("<color=red>" + sb.ToString());
                        }
                    }

                }

                if (mPlayerData.NeedToUpdateLocal)
                {
                    if (MyAPIGateway.Session.Player != null && MyAPIGateway.Session.Player.Character != null)
                    {
                        var OxygenComponent = MyAPIGateway.Session.Player.Character.Components.Get<MyCharacterOxygenComponent>();
                        OxygenComponent.SuitOxygenLevel = mPlayerData.O2Level;
                        var Inventory = MyAPIGateway.Session.Player.Character.GetInventory() as MyInventory;
                        if (Inventory != null)
                        {
                            if ((float)Inventory.MaxVolume != mPlayerData.CurrentCargoVolume)
                            {
                                var definition = new MyInventoryComponentDefinition
                                {
                                    RemoveEntityOnEmpty = false,
                                    MultiplierEnabled = false,
                                    MaxItemCount = int.MaxValue,
                                    Mass = mPlayerData.CurrentCargoMass,
                                    Volume = mPlayerData.CurrentCargoVolume,
                                    InputConstraint = new MyInventoryConstraint("PlayerInventory", null, false)
                                };
                                Inventory.Init(definition);
                            }
                        }
                    }
                    else
                    {
                        ExtendedSurvivalStatsLogging.Instance.LogWarning(GetType(), $"ClientUpdateMsgHandler MyAPIGateway.Session.Player || Character is NULL");
                    }
                }

            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(GetType(), ex);
            }

        }

        public enum ProgressDisplayType
        {

            Normal = 0,
            OnlyBar = 1,
            OnlyValues = 2,
            OnlyPercent = 3

        }

        private HudAPIv2.HUDMessage col01HUDMessage = null;
        private HudAPIv2.HUDMessage col02HUDMessage = null;

        private static readonly MyStringId ThirstIcon = MyStringId.GetOrCompute("ThirstIcon_White");
        private static readonly MyStringId HungerIcon = MyStringId.GetOrCompute("HungerIcon_White");
        private static readonly MyStringId StaminaIcon = MyStringId.GetOrCompute("StaminaIcon_White");

        private static readonly MyStringId BodyTemperature = MyStringId.GetOrCompute("BodyTemperature_White");
        private static readonly MyStringId BodyTemperatureCold = MyStringId.GetOrCompute("BodyTemperatureCold_White");
        private static readonly MyStringId BodyTemperatureHot = MyStringId.GetOrCompute("BodyTemperatureHot_White");

        private static readonly MyStringId BodyWater = MyStringId.GetOrCompute("BodyWater_White");
        private static readonly MyStringId BodyEnergy = MyStringId.GetOrCompute("BodyEnergy_White");

        private Dictionary<int, HudAPIv2.BillBoardHUDMessage> icons = new Dictionary<int, HudAPIv2.BillBoardHUDMessage>();
        private Dictionary<int, HudAPIv2.BillBoardHUDMessage> statusIcons = new Dictionary<int, HudAPIv2.BillBoardHUDMessage>();

        private StringBuilder col01Builder = new StringBuilder();
        private StringBuilder col02Builder = new StringBuilder();

        private Vector2 col01Position = new Vector2(-1.12f, 0.8f);
        private Vector2 col02Position = new Vector2(-0.74f, 0.8f);

        private bool isHUDInit = false;

        private double hudScale = 1.0d;
        private double hudScale2 = 0.7d;

        private void IconDisplay(int row, int col, MyStringId? icon, Color color, int lineBonus = 0)
        {
            if (icon.HasValue)
            {
                var xAlignValue = 0.16f;
                var yAlignValue = 0.145f;
                var lineHeight = 0.0315f;
                var colWidth = 0.0435f;
                var rowHeight = lineHeight * 2;
                if (row > 0)
                {
                    yAlignValue -= row * rowHeight;
                }
                if (lineBonus > 0)
                {
                    yAlignValue -= lineBonus * lineHeight;
                }
                if (col > 0)
                {
                    xAlignValue += col * colWidth;
                }
                var baseVector = col01Position;
                var basePos = new Vector2D(baseVector.X + xAlignValue, baseVector.Y + yAlignValue);
                if (!statusIcons.ContainsKey(col))
                {
                    var iconObj = new HudAPIv2.BillBoardHUDMessage(icon.Value, basePos, color);
                    iconObj.Height = 1.8f;
                    iconObj.Scale = 0.04d;
                    iconObj.Rotation = 0f;
                    iconObj.Blend = BlendTypeEnum.PostPP;
                    statusIcons.Add(col, iconObj);
                }
                statusIcons[col].Origin = basePos;
                statusIcons[col].Material = icon.Value;
                statusIcons[col].BillBoardColor = color;
                statusIcons[col].Visible = true;
            }
        }

        private void BuildProgressDisplay(int index, int col, MyStringId? icon, string caption, Vector4 values, StringBuilder builder, ProgressDisplayType displayType = ProgressDisplayType.Normal, bool clearBuilder = true, Func<float, bool> isRed = null, Func<float, bool> isYellow = null, int lineBonus = 0)
        {
            Color redColor = Color.Red;
            Color yellowColor = Color.Yellow;
            Color whiteColor = Color.White;
            Color greenColor = Color.Cyan;
            string redStrColor = "red";
            string yellowStrColor = "yellow";
            string whiteStrColor = "white";
            string greenStrColor = "cyan";

            if (icon.HasValue)
            {
                var xAlignValue = 0.16f;
                var yAlignValue = 0.145f;
                var lineHeight = col == 1 ? 0.0315f : 0.0145f;
                var rowHeight = lineHeight * 2;
                if (index > 0)
                {
                    yAlignValue -= index * rowHeight;
                }
                if (lineBonus > 0)
                {
                    yAlignValue -= lineBonus * lineHeight;
                }
                var baseVector = col == 1 ? col01Position : col02Position;
                var basePos = new Vector2D(baseVector.X + xAlignValue, baseVector.Y + yAlignValue);
                if (!icons.ContainsKey(index))
                {
                    var iconObj = new HudAPIv2.BillBoardHUDMessage(icon.Value, basePos, whiteColor);
                    iconObj.Height = 1.8f;
                    iconObj.Scale = col == 1 ? 0.025d : 0.0125f;
                    iconObj.Rotation = 0f;
                    iconObj.Blend = BlendTypeEnum.PostPP;
                    icons.Add(index, iconObj);
                }
                icons[index].Origin = basePos;
                icons[index].Material = icon.Value;
                icons[index].Visible = true;
            }

            var maxValue = values.Y;
            var value = values.Z;
            if (values.X != 0)
            {
                if (values.X > 0)
                {
                    maxValue -= values.X;
                    value -= values.X;
                }
                else
                {
                    maxValue += values.X * -1;
                    value += values.X * -1;
                }
            }

            var floorValue = Math.Floor(value);
            var percent = value / maxValue;

            var color = whiteColor;
            var strColor = whiteStrColor;
            if ((isRed == null && percent <= 0.05f) ||
                (isRed != null && isRed(percent)))
            {
                strColor = redStrColor;
                color = redColor;
            }
            else if ((isYellow == null && percent <= 0.3f) ||
                    (isYellow != null && isYellow(percent)))
            {
                strColor = yellowStrColor;
                color = yellowColor;
            }

            if (icon.HasValue)
            {
                icons[index].BillBoardColor = color;
            }

            var currentBars = (int)Math.Floor(percent * 100);
            var emptyBars = Math.Max(100 - currentBars, 0);

            var detail = "";
            if (values.W != 0)
            {
                detail = string.Format("<color={0}>[{1}{2}]",
                    values.W > 0 ? greenStrColor : redStrColor,
                    values.W > 0 ? "+" : "-",
                    values.W > 0 ? values.W : values.W * -1);
            }

            if (clearBuilder)
                builder.Clear();


            if (displayType == ProgressDisplayType.Normal || displayType == ProgressDisplayType.OnlyValues)
                builder.AppendLine(string.Format("<color={0}>{1}: {2} - {3} {4}", strColor, caption, floorValue.ToString().PadLeft(maxValue.ToString().Length, '0'), maxValue, detail));
            else if (displayType == ProgressDisplayType.OnlyPercent)
                builder.AppendLine(string.Format("<color={0}>{1}: {2} {3}", strColor, caption, percent.ToString("P2").PadLeft(8, '0'), detail));
            else
                builder.AppendLine(string.Format("<color={0}>{1}", strColor, caption));
            if (displayType != ProgressDisplayType.OnlyValues && displayType != ProgressDisplayType.OnlyPercent)
            {
                builder.AppendLine(string.Format("<color={0}>[{1}{2}]", strColor, "".PadLeft(currentBars, '|'), "".PadLeft(emptyBars, '\'')));
            }
        }

        private void CommandsMsgHandler(ushort netId, byte[] data, ulong steamId, bool fromServer)
        {
            try
            {
                var message = Encoding.Unicode.GetString(data);
                var mCommandData = MyAPIGateway.Utilities.SerializeFromXML<Command>(message);
                if (MyAPIGateway.Session.IsUserAdmin(steamId))
                {
                    if (VALID_COMMANDS.ContainsKey(mCommandData.content[0]))
                    {
                        if ((!VALID_COMMANDS[mCommandData.content[0]].Value && mCommandData.content.Length == VALID_COMMANDS[mCommandData.content[0]].Key) ||
                            (VALID_COMMANDS[mCommandData.content[0]].Value && mCommandData.content.Length >= VALID_COMMANDS[mCommandData.content[0]].Key))
                        {
                            switch (mCommandData.content[0])
                            {
                                case SETTINGS_COMMAND:
                                    ExtendedSurvivalSettings.Instance.SetConfigValue(mCommandData.content[1], mCommandData.content[2]);
                                    break;
                                case SETTINGS_COMMAND_PLAYER_STATUS:
                                    var playerChar = ExtendedSurvivalStatsEntityManager.Instance.GetPlayerCharacterBySteamId(mCommandData.sender);
                                    if (playerChar != null)
                                    {
                                        if (!mCommandData.content[1].Contains("Effect"))
                                        {
                                            MyEntityStat targetStat = playerChar.GetStatCache(mCommandData.content[1]);
                                            if (targetStat != null)
                                            {
                                                float targetValue;
                                                if (float.TryParse(mCommandData.content[2], out targetValue))
                                                {
                                                    targetStat.Value = targetValue;
                                                }
                                            }
                                        }
                                    }
                                    break;
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

        private void OnMessageEntered(string messageText, ref bool sendToOthers)
        {
            sendToOthers = true;
            if (!messageText.StartsWith("/")) return;
            var words = messageText.Trim().ToLower().Replace("/", "").Split(' ');
            if (words.Length > 0)
            {
                if (VALID_COMMANDS.ContainsKey(words[0]))
                {
                    if ((!VALID_COMMANDS[words[0]].Value && words.Length == VALID_COMMANDS[words[0]].Key) ||
                        (VALID_COMMANDS[words[0]].Value && words.Length >= VALID_COMMANDS[words[0]].Key))
                    {
                        sendToOthers = false;
                        Command cmd = new Command(MyAPIGateway.Multiplayer.MyId, words);
                        string message = MyAPIGateway.Utilities.SerializeToXML<Command>(cmd);
                        MyAPIGateway.Multiplayer.SendMessageToServer(
                            NETWORK_ID_COMMANDS,
                            Encoding.Unicode.GetBytes(message)
                        );
                    }
                }
            }
        }

        private void ClientDefinitionsUpdateServerMsgHandler(ushort netId, byte[] data, ulong steamId, bool fromServer)
        {
            try
            {
                if (netId != NETWORK_ID_DEFINITIONS)
                    return;

                var message = Encoding.Unicode.GetString(data);
                var mCommandData = MyAPIGateway.Utilities.SerializeFromXML<Command>(message);
                if (IsServer)
                {

                    switch (mCommandData.content[0])
                    {
                        default:
                            Command cmd = new Command(0, CALL_FOR_DEFS);
                            cmd.data = Encoding.Unicode.GetBytes(ExtendedSurvivalSettings.Instance.GetDataToClient());
                            string messageToSend = MyAPIGateway.Utilities.SerializeToXML<Command>(cmd);
                            MyAPIGateway.Multiplayer.SendMessageTo(
                                NETWORK_ID_DEFINITIONS,
                                Encoding.Unicode.GetBytes(messageToSend),
                                mCommandData.sender
                            );
                            break;
                    }

                }

            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(GetType(), ex);
            }
        }

        private void ClientDefinitionsUpdateMsgHandler(ushort netId, byte[] data, ulong steamId, bool fromServer)
        {
            try
            {
                if (netId != NETWORK_ID_DEFINITIONS)
                    return;

                var message = Encoding.Unicode.GetString(data);
                var mCommandData = MyAPIGateway.Utilities.SerializeFromXML<Command>(message);
                if (IsClient)
                {
                    var settingsData = Encoding.Unicode.GetString(mCommandData.data);
                    ExtendedSurvivalSettings.ClientLoad(settingsData);
                    CheckDefinitions();
                }

            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(GetType(), ex);
            }
        }

        private bool HasIce(Guid observerId)
        {
            return HasItem(observerId, ItensConstants.ICE_ID);
        }

        private bool HasItem(Guid observerId, UniqueEntityId id)
        {
            if (ExtendedSurvivalCoreAPI.Registered)
                return ExtendedSurvivalCoreAPI.HasItemInObserver(observerId, id.DefinitionId);
            return false;
        }

        private bool HasAnyFertilizer(Guid observerId)
        {
            foreach (var item in FarmConstants.FERTILIZERS)
            {
                if (HasItem(observerId, item))
                    return true;
            }
            return false;
        }

        public override void SaveData()
        {
            base.SaveData();

            if (IsServer)
            {
                ExtendedSurvivalSettings.Save();
                ExtendedSurvivalStorage.Save();
            }
        }

        public override void LoadData()
        {
            TextAPI = new HudAPIv2();
            ESCoreAPI = new ExtendedSurvivalCoreAPI(()=> {
                if (IsServer)
                {
                    if (ExtendedSurvivalCoreAPI.Registered)
                    {
                        ExtendedSurvivalCoreAPI.AddGasSpoilInfo(
                            LivestockConstants.CREATURE_HEALTH,
                            LivestockConstants.FEED_TIME_CICLE,
                            LivestockConstants.BASE_HUNGRY_FACTOR,
                            (Guid observerId) =>
                            {
                                return true;
                            }
                        );
                        ExtendedSurvivalCoreAPI.AddGasSpoilInfo(
                            LivestockConstants.TREE_HEALTH,
                            FarmConstants.BASE_TIME_TO_PRODUCE,
                            FarmConstants.BASE_TREE_DECAY_FACTOR,
                            (Guid observerId) =>
                            {
                                return !HasIce(observerId) || !HasAnyFertilizer(observerId);
                            }
                        );
                        foreach (var itemKey in ItensConstants.ITEM_EXTRA_INFO_DEF.Keys)
                        {
                            ExtendedSurvivalCoreAPI.AddItemExtraInfo(ItensConstants.ITEM_EXTRA_INFO_DEF[itemKey]);
                        }
                        ExtendedSurvivalCoreAPI.AddItemCategory(LivestockConstants.ANIMAL_CATEGORY);
                        foreach (var animalId in ItensConstants.ANIMALS_IDS)
                        {
                            ExtendedSurvivalCoreAPI.AddDefinitionToCategory(animalId.DefinitionId, LivestockConstants.ANIMAL_CATEGORY);
                        }
                        ExtendedSurvivalCoreAPI.AddTreeDropLoot(new ExtendedSurvivalCoreAPI.TreeDropLoot(ItensConstants.CEREAL_ID.DefinitionId, 30, 50));
                        ExtendedSurvivalCoreAPI.AddTreeDropLoot(new ExtendedSurvivalCoreAPI.TreeDropLoot(ItensConstants.APPLE_ID.DefinitionId, 5, 25) { AlowDesert = false });
                        ExtendedSurvivalCoreAPI.AddTreeDropLoot(new ExtendedSurvivalCoreAPI.TreeDropLoot(ItensConstants.APPLETREESEEDLING_ID.DefinitionId, 1, 50) { AlowDesert = false, IsGas = true });
                    }
                }
            });

            if (IsServer)
            {
                ExtendedSurvivalSettings.Load();
                ExtendedSurvivalStorage.Load();
                CheckDefinitions();
            }

            base.LoadData();
        }

        private bool definitionsChecked = false;
        private void CheckDefinitions()
        {
            ExtendedSurvivalStatsLogging.Instance.LogInfo(GetType(), $"CheckDefinitions Called");
            if (!definitionsChecked)
            {
                definitionsChecked = true;

                DefinitionUtils.ChangeInventoryContainerType("deer_bot", "DeerLoot");
                DefinitionUtils.ChangeInventoryContainerType("deerbuck_bot", "DeerLoot");
                DefinitionUtils.ChangeInventoryContainerType("Cow_Bot", "CowLoot");
                DefinitionUtils.ChangeInventoryContainerType("Sheep_Bot", "SheepLoot");
                DefinitionUtils.ChangeInventoryContainerType("Horse_Bot", "HorseLoot");

                DefinitionUtils.ReplaceContainerTypeDefinition("WolfLoot", new Vector2I(2, 3), true, GetAnimalLoot());
                DefinitionUtils.ReplaceContainerTypeDefinition("DeerLoot", new Vector2I(2, 3), true, GetAnimalLoot(2));
                DefinitionUtils.ReplaceContainerTypeDefinition("CowLoot", new Vector2I(2, 3), true, GetAnimalLoot(3));
                DefinitionUtils.ReplaceContainerTypeDefinition("SheepLoot", new Vector2I(2, 3), true, GetAnimalLoot());
                DefinitionUtils.ReplaceContainerTypeDefinition("HorseLoot", new Vector2I(2, 3), true, GetAnimalLoot(2));
                DefinitionUtils.ReplaceContainerTypeDefinition("SpiderLoot", new Vector2I(2, 4), true, GetSpiderLoot());

                DefinitionUtils.ReplaceContainerTypeDefinition("PersonalContainerSmall", new Vector2I(2, 5), false, GetUnknownSignalLoot());

                DefinitionUtils.ChangeStatValue("AnimalHealth", new Vector3(0, 150, 150));
                DefinitionUtils.ChangeStatValue("Health", new Vector3(0, 250, 250));
                DefinitionUtils.ChangeStatValue("SpaceCharacterHealth", new Vector3(0, 250, 250));
                DefinitionUtils.ChangeStatValue("WolfHealth", new Vector3(0, 250, 250));
                DefinitionUtils.ChangeStatValue("SpiderHealth", new Vector3(0, 500, 500));

                var creatureCharacters = new string[] { "Space_Wolf", "Space_spider", "deer_bot", "deerbuck_bot", "Cow_Bot", "Sheep_Bot", "Horse_Bot" };
                foreach (var character in creatureCharacters)
                {
                    DefinitionUtils.AddStatToCharacter("Creature_Torpor", character);
                }

                var playerCharacters = new string[] { "Default_Astronaut", "Default_Astronaut_Female" };
                foreach (var character in playerCharacters)
                {
                    DefinitionUtils.AddStatToCharacter("IntakeCarbohydrates", character);
                    DefinitionUtils.AddStatToCharacter("IntakeProtein", character);
                    DefinitionUtils.AddStatToCharacter("IntakeLipids", character);
                    DefinitionUtils.AddStatToCharacter("IntakeVitamins", character);
                    DefinitionUtils.AddStatToCharacter("IntakeMinerals", character);
                    DefinitionUtils.AddStatToCharacter("BodyMuscles", character);
                    DefinitionUtils.AddStatToCharacter("BodyFat", character);
                    DefinitionUtils.AddStatToCharacter("BodyPerformance", character);
                    DefinitionUtils.AddStatToCharacter("IntakeBodyFood", character);
                    DefinitionUtils.AddStatToCharacter("IntakeBodyWater", character);
                    DefinitionUtils.AddStatToCharacter("BodyEnergy", character);
                    DefinitionUtils.AddStatToCharacter("BodyWater", character);
                    DefinitionUtils.AddStatToCharacter("WoundedTime", character);
                    DefinitionUtils.AddStatToCharacter("TemperatureTime", character);
                    DefinitionUtils.AddStatToCharacter("WetTime", character);
                    DefinitionUtils.AddStatToCharacter("SurvivalEffects", character);
                    DefinitionUtils.AddStatToCharacter("DamageEffects", character);
                    DefinitionUtils.AddStatToCharacter("TemperatureEffects", character);
                    DefinitionUtils.AddStatToCharacter("DiseaseEffects", character);
                    DefinitionUtils.AddStatToCharacter("OtherEffects", character);
                    DefinitionUtils.AddStatToCharacter("Stamina", character);
                    DefinitionUtils.AddStatToCharacter("Thirst", character);
                    DefinitionUtils.AddStatToCharacter("Hunger", character);
                }

                // NUTRITION
                NutritionConstants.CalculateRecipesNutrition();
                NutritionConstants.TryOverrideRecipes();

                // SPAWNS
                SpawnGroupOverride.SetDefinitions();

                // BLOCKS
                AssemblerOverride.TryOverride();

                //HUD
                HUDOverride.TryOverride();

            }
        }

        private MyObjectBuilder_ContainerTypeDefinition.ContainerTypeItem[] GetUnknownSignalLoot(float multiplier = 1f)
        {
            return new MyObjectBuilder_ContainerTypeDefinition.ContainerTypeItem[]
            {
                DefinitionUtils.GetLootItem(new Vector2(1, 5).GetMultiplier(multiplier), ItensConstants.BANDAGES_ID, 0.1f),
                DefinitionUtils.GetLootItem(new Vector2(1, 5).GetMultiplier(multiplier), ItensConstants.CARROT_SEEDS_ID, 0.1f),
                DefinitionUtils.GetLootItem(new Vector2(1, 5).GetMultiplier(multiplier), ItensConstants.MINT_SEEDS_ID, 0.1f),
                DefinitionUtils.GetLootItem(new Vector2(1, 5).GetMultiplier(multiplier), ItensConstants.ARNICA_SEEDS_ID, 0.1f),
                DefinitionUtils.GetLootItem(new Vector2(1, 5).GetMultiplier(multiplier), ItensConstants.BROCCOLI_SEEDS_ID, 0.1f),
                DefinitionUtils.GetLootItem(new Vector2(1, 5).GetMultiplier(multiplier), ItensConstants.COFFEE_SEEDS_ID, 0.1f),
                DefinitionUtils.GetLootItem(new Vector2(1, 5).GetMultiplier(multiplier), ItensConstants.TOMATO_SEEDS_ID, 0.1f),
                DefinitionUtils.GetLootItem(new Vector2(1, 5).GetMultiplier(multiplier), ItensConstants.WHEAT_SEEDS_ID, 0.1f),
                DefinitionUtils.GetLootItem(new Vector2(1, 5).GetMultiplier(multiplier), ItensConstants.CHAMOMILE_SEEDS_ID, 0.1f),
                DefinitionUtils.GetLootItem(new Vector2(1, 5).GetMultiplier(multiplier), ItensConstants.ALOEVERA_SEEDS_ID, 0.1f),
                DefinitionUtils.GetLootItem(new Vector2(1, 5).GetMultiplier(multiplier), ItensConstants.ERYTHROXYLUM_SEEDS_ID, 0.1f)
            };
        }

        private MyObjectBuilder_ContainerTypeDefinition.ContainerTypeItem[] GetAnimalLoot(float multiplier = 1f)
        {
            return new MyObjectBuilder_ContainerTypeDefinition.ContainerTypeItem[]
            {
                DefinitionUtils.GetLootItem(new Vector2(6, 12).GetMultiplier(multiplier), ItensConstants.MEAT_ID, 6),
                DefinitionUtils.GetLootItem(new Vector2(3, 6).GetMultiplier(multiplier), ItensConstants.NOBLE_MEAT_ID, 1),
                DefinitionUtils.GetLootItem(new Vector2(10, 20).GetMultiplier(multiplier), ItensConstants.BONES_ID, 3)
            };
        }

        private MyObjectBuilder_ContainerTypeDefinition.ContainerTypeItem[] GetSpiderLoot(float multiplier = 1f)
        {
            return new MyObjectBuilder_ContainerTypeDefinition.ContainerTypeItem[]
            {
                DefinitionUtils.GetLootItem(new Vector2(12, 24).GetMultiplier(multiplier), ItensConstants.ALIEN_MEAT_ID, 6),
                DefinitionUtils.GetLootItem(new Vector2(6, 12).GetMultiplier(multiplier), ItensConstants.ALIEN_NOBLE_MEAT_ID, 1),
                DefinitionUtils.GetLootItem(new Vector2(20, 40).GetMultiplier(multiplier), ItensConstants.BONES_ID, 3),
                DefinitionUtils.GetLootItem(new Vector2(4, 8).GetMultiplier(multiplier), ItensConstants.ALIEN_EGG_ID, 2)
            };
        }

        protected override void UnloadData()
        {
            TextAPI.Close();
            ESCoreAPI.Unregister();

            if (!IsDedicated)
                MyAPIGateway.Multiplayer.UnregisterSecureMessageHandler(NETWORK_ID_STATSSYSTEM, ClientUpdateMsgHandler);

            if (IsServer)
                MyAPIGateway.Multiplayer.UnregisterSecureMessageHandler(NETWORK_ID_COMMANDS, CommandsMsgHandler);

            base.UnloadData();
        }

        private static void ForceWolfAndSpiders()
        {
            try
            {
                MyAPIGateway.Session.SessionSettings.EnableSpiders = true;
                MyAPIGateway.Session.SessionSettings.EnableWolfs = true;
            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(typeof(ExtendedSurvivalStatsSession), ex);
            }
        }

        protected override void DoUpdate()
        {
            base.DoUpdate();

            try
            {

                if (IsServer)
                {

                    ForceWolfAndSpiders();

                    foreach (var item in ExtendedSurvivalStatsEntityManager.Instance.PlayerCharacters.Where(x => x.Value.PlayerId > 0 && x.Value.Entity != null && !x.Value.Entity.IsDead))
                    {
                        var player = item.Value;
                        player.ProcessUnderwater(RunCount);
                        if (ExtendedSurvivalStatsEntityManager.Instance.Players.ContainsKey(player.PlayerId))
                        {
                            try
                            {
                                var data = player.GetData();
                                if (data != null)
                                {
                                    string message = MyAPIGateway.Utilities.SerializeToXML<PlayerData>(data);
                                    MyAPIGateway.Multiplayer.SendMessageTo(
                                        NETWORK_ID_STATSSYSTEM,
                                        Encoding.Unicode.GetBytes(message),
                                        ExtendedSurvivalStatsEntityManager.Instance.Players[player.PlayerId].SteamUserId
                                    );
                                }
                            }
                            catch (Exception ex)
                            {
                                ExtendedSurvivalStatsLogging.Instance.LogError(GetType(), ex);
                                if (ex.Message.Contains("There was an error generating the XML document"))
                                {
                                    // To prevent server crash is better to kill this player
                                    if (player != null && player.Entity != null)
                                    {
                                        player.Entity.Kill();
                                        player.RemoveDiedRoutine();
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

        protected override void DoUpdate60()
        {
            base.DoUpdate60();

            if (MyAPIGateway.Session.IsServer)
            {

                PlayersUpdate();

            }
        }

        private void PlayersUpdate()
        {
            try
            {
                foreach (var key in ExtendedSurvivalStatsEntityManager.Instance.PlayerCharacters.Keys)
                {
                    var player = ExtendedSurvivalStatsEntityManager.Instance.PlayerCharacters[key];
                    if (!player.IsValid || player.IsDead)
                        continue;

                    player.ProcessActivityCycle();
                    player.CheckStatusValues();
                    player.CheckValuesToDoDamage();

                    if (RunCount < 300)
                        continue;

                    player.ProcessStatsCycle();
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(GetType(), ex);
            }
        }

    }

}
