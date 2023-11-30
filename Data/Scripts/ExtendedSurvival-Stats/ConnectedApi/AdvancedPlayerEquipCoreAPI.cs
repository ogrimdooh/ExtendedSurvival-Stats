using ProtoBuf;
using Sandbox.Game;
using Sandbox.Game.Entities;
using Sandbox.ModAPI;
using Sandbox.ModAPI.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using VRage;
using VRage.Game;
using VRage.Game.Components;
using VRage.Game.Entity;
using VRage.Game.ModAPI;
using VRage.ModAPI;
using VRage.ObjectBuilders;
using VRage.Utils;
using VRageMath;

namespace ExtendedSurvival.Stats
{

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class EquipableItemCategoryData
    {

        [ProtoMember(1)]
        public string Id { get; set; }

        [ProtoMember(2)]
        public string Name { get; set; }

    }

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class ValidCategoryData
    {

        [ProtoMember(1)]
        public string Id { get; set; }

    }

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class PlayerSlotData
    {

        [ProtoMember(1)]
        public string Id { get; set; }

        [ProtoMember(2)]
        public string Name { get; set; }

        [ProtoMember(3)]
        public List<ValidCategoryData> ValidCategories { get; set; } = new List<ValidCategoryData>();
        
    }

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class EquipableItemSocketData
    {

        [ProtoMember(1)]
        public int Order { get; set; }

        [ProtoMember(2)]
        public List<ValidCategoryData> ValidCategories { get; set; } = new List<ValidCategoryData>();

    }

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class EquipableItemData
    {

        [ProtoMember(1)]
        public SerializableDefinitionId Id { get; set; }

        [ProtoMember(2)]
        public string ItemCategory { get; set; }

        [ProtoMember(4)]
        public bool HasEquipConditions { get; set; } = false;

        [ProtoMember(5)]
        public List<EquipableItemSocketData> Sockets { get; set; } = new List<EquipableItemSocketData>();

    }

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class SocketItemData
    {

        [ProtoMember(1)]
        public SerializableDefinitionId Id { get; set; }

        [ProtoMember(2)]
        public string ItemCategory { get; set; }

        [ProtoMember(3)]
        public bool HasEquipConditions { get; set; } = false;

    }

    public class AdvancedPlayerEquipCoreAPI
    {

        private static AdvancedPlayerEquipCoreAPI instance;

        public static string ModName = "";
        public const ushort ModHandlerID = 35475;
        public const int ModAPIVersion = 1;

        public static bool Registered { get; private set; } = false;

        private static Dictionary<string, Delegate> ModAPIMethods;

        private static Func<int, string, bool> _VerifyVersion;
        private static Func<string, bool> _ConfigureEquipableItemCategory;
        private static Func<string, bool> _ConfigurePlayerSlot;
        private static Func<string, bool> _ConfigureEquipableItem;
        private static Func<string, bool> _ConfigureSocketItem;
        
        public static void BeforeStart()
        {
            MyAPIGateway.Utilities.SendModMessage(ModHandlerID, ModAPIMethods);
        }

        /// <summary> 
        /// Returns true if the version is compatibile with the API Backend, this is automatically called
        /// </summary>
        public static bool VerifyVersion(int Version, string ModName)
        {
            return _VerifyVersion?.Invoke(Version, ModName) ?? false;
        }

        /// <summary>
        /// Configure a item category to be used by the framework
        /// </summary>
        public static bool ConfigureEquipableItemCategory(EquipableItemCategoryData value)
        {
            string messageToSend = MyAPIGateway.Utilities.SerializeToXML<EquipableItemCategoryData>(value);
            return _ConfigureEquipableItemCategory?.Invoke(messageToSend) ?? false;
        }

        /// <summary>
        /// Configure a player slot to be used by the framework
        /// </summary>
        public static bool ConfigurePlayerSlot(PlayerSlotData value)
        {
            string messageToSend = MyAPIGateway.Utilities.SerializeToXML<PlayerSlotData>(value);
            return _ConfigurePlayerSlot?.Invoke(messageToSend) ?? false;
        }

        /// <summary>
        /// Configure a equipable item to be used by the framework
        /// </summary>
        public static bool ConfigureEquipableItem(EquipableItemData value)
        {
            string messageToSend = MyAPIGateway.Utilities.SerializeToXML<EquipableItemData>(value);
            return _ConfigureEquipableItem?.Invoke(messageToSend) ?? false;
        }

        /// <summary>
        /// Configure a socket item to be used by the framework
        /// </summary>
        public static bool ConfigureSocketItem(SocketItemData value)
        {
            string messageToSend = MyAPIGateway.Utilities.SerializeToXML<SocketItemData>(value);
            return _ConfigureSocketItem?.Invoke(messageToSend) ?? false;
        }



        /// <summary>
        /// Unregisters the mod
        /// </summary>
        public void Unregister()
        {
            if (instance != null)
            {
                instance.DoUnregister();
            }
        }

        /// <summary>
        /// Unregisters the mod
        /// </summary>
        public void DoUnregister()
        {
            MyAPIGateway.Utilities.UnregisterMessageHandler(ModHandlerID, ModHandler);
            Registered = false;
            instance = null;
            m_onRegisteredAction = null;
        }

        private Action m_onRegisteredAction;

        /// <summary>
        /// Create a Advanced Player UI Core API Instance. Please only create one per mod. 
        /// </summary>
        /// <param name="onRegisteredAction">Callback once the Advanced Player UI Core API is active. You can Instantiate Advanced Player UI Core API objects in this Action</param>
        public AdvancedPlayerEquipCoreAPI(Action onRegisteredAction = null)
        {
            if (instance != null)
            {
                return;
            }
            instance = this;
            m_onRegisteredAction = onRegisteredAction;
            MyAPIGateway.Utilities.RegisterMessageHandler(ModHandlerID, ModHandler);
            if (ModName == "")
            {
                if (MyAPIGateway.Utilities.GamePaths.ModScopeName.Contains("_"))
                    ModName = MyAPIGateway.Utilities.GamePaths.ModScopeName.Split('_')[1];
                else
                    ModName = MyAPIGateway.Utilities.GamePaths.ModScopeName;
            }
        }

        private void ModHandler(object obj)
        {
            if (obj == null)
            {
                return;
            }

            if (obj is Dictionary<string, Delegate>)
            {
                ModAPIMethods = (Dictionary<string, Delegate>)obj;
                _VerifyVersion = (Func<int, string, bool>)ModAPIMethods["VerifyVersion"];

                Registered = VerifyVersion(ModAPIVersion, ModName);

                MyLog.Default.WriteLine("Registering Advanced Player Equip Core API for Mod '" + ModName + "'");

                if (Registered)
                {
                    try
                    {

                        _ConfigureEquipableItemCategory = (Func<string, bool>)ModAPIMethods["ConfigureEquipableItemCategory"];
                        _ConfigurePlayerSlot = (Func<string, bool>)ModAPIMethods["ConfigurePlayerSlot"];
                        _ConfigureEquipableItem = (Func<string, bool>)ModAPIMethods["ConfigureEquipableItem"];
                        _ConfigureSocketItem = (Func<string, bool>)ModAPIMethods["ConfigureSocketItem"];


                        if (m_onRegisteredAction != null)
                            m_onRegisteredAction();
                    }
                    catch (Exception e)
                    {
                        MyAPIGateway.Utilities.ShowMessage("Advanced Player Equip", "Mod '" + ModName + "' encountered an error when registering the Advanced Player Equip Core API, see log for more info.");
                        MyLog.Default.WriteLine("Advanced Player Equip Core API: " + e);
                    }
                }
            }
        }

    }

    public class AdvancedPlayerEquipCoreClientAPI
    {

        private static AdvancedPlayerEquipCoreClientAPI instance;

        public static string ModName = "";
        public const ushort ModHandlerID = 35476;
        public const int ModAPIVersion = 1;

        public static bool Registered { get; private set; } = false;

        private static Dictionary<string, Delegate> ModAPIMethods;

        private static Func<int, string, bool> _VerifyVersion;

        public static void BeforeStart()
        {
            MyAPIGateway.Utilities.SendModMessage(ModHandlerID, ModAPIMethods);
        }

        /// <summary> 
        /// Returns true if the version is compatibile with the API Backend, this is automatically called
        /// </summary>
        public static bool VerifyVersion(int Version, string ModName)
        {
            return _VerifyVersion?.Invoke(Version, ModName) ?? false;
        }



        /// <summary>
        /// Unregisters the mod
        /// </summary>
        public void Unregister()
        {
            if (instance != null)
            {
                instance.DoUnregister();
            }
        }

        /// <summary>
        /// Unregisters the mod
        /// </summary>
        public void DoUnregister()
        {
            MyAPIGateway.Utilities.UnregisterMessageHandler(ModHandlerID, ModHandler);
            Registered = false;
            instance = null;
            m_onRegisteredAction = null;
        }

        private Action m_onRegisteredAction;

        /// <summary>
        /// Create a Advanced Player UI Core API Instance. Please only create one per mod. 
        /// </summary>
        /// <param name="onRegisteredAction">Callback once the Advanced Player UI Core API is active. You can Instantiate Advanced Player UI Core API objects in this Action</param>
        public AdvancedPlayerEquipCoreClientAPI(Action onRegisteredAction = null)
        {
            if (instance != null)
            {
                return;
            }
            instance = this;
            m_onRegisteredAction = onRegisteredAction;
            MyAPIGateway.Utilities.RegisterMessageHandler(ModHandlerID, ModHandler);
            if (ModName == "")
            {
                if (MyAPIGateway.Utilities.GamePaths.ModScopeName.Contains("_"))
                    ModName = MyAPIGateway.Utilities.GamePaths.ModScopeName.Split('_')[1];
                else
                    ModName = MyAPIGateway.Utilities.GamePaths.ModScopeName;
            }
        }

        private void ModHandler(object obj)
        {
            if (obj == null)
            {
                return;
            }

            if (obj is Dictionary<string, Delegate>)
            {
                ModAPIMethods = (Dictionary<string, Delegate>)obj;
                _VerifyVersion = (Func<int, string, bool>)ModAPIMethods["VerifyVersion"];

                Registered = VerifyVersion(ModAPIVersion, ModName);

                MyLog.Default.WriteLine("Registering Advanced Player Equip Core API for Mod '" + ModName + "'");

                if (Registered)
                {
                    try
                    {


                        if (m_onRegisteredAction != null)
                            m_onRegisteredAction();
                    }
                    catch (Exception e)
                    {
                        MyAPIGateway.Utilities.ShowMessage("Advanced Player Equip", "Mod '" + ModName + "' encountered an error when registering the Advanced Player Equip Core API, see log for more info.");
                        MyLog.Default.WriteLine("Advanced Player Equip Core API: " + e);
                    }
                }
            }
        }

    }

}