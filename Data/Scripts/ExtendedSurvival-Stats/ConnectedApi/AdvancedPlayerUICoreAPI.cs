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

    public class AdvancedPlayerUICoreAPI
    {

        private static AdvancedPlayerUICoreAPI instance;

        public static string ModName = "";
        public const ushort ModHandlerID = 34375;
        public const int ModAPIVersion = 1;

        public static bool Registered { get; private set; } = false;

        private static Dictionary<string, Delegate> ModAPIMethods;

        private static Func<int, string, bool> _VerifyVersion;
        private static Func<Guid, string, bool> _AddMainMenuItem;
        private static Func<string, Action<Guid>, int, bool> _RegisterMainMenuCallback;
        private static Action _LockMainMenu;
        private static Action _ReleaseMainMenu;

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
        /// Lock main menu
        /// </summary>
        public static void LockMainMenu()
        {
            _LockMainMenu?.Invoke();
        }

        /// <summary>
        /// Release main menu
        /// </summary>
        public static void ReleaseMainMenu()
        {
            _ReleaseMainMenu?.Invoke();
        }

        /// <summary>
        /// Add a main menu item
        /// </summary>
        public static bool AddMainMenuItem(Guid id, string name)
        {
            return _AddMainMenuItem?.Invoke(id, name) ?? false;
        }

        /// <summary>
        /// Register a callback method to main menu item click
        /// </summary>
        public static bool RegisterMainMenuCallback(string id, Action<Guid> callback, int priority)
        {
            return _RegisterMainMenuCallback?.Invoke(id, callback, priority) ?? false;
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
        public AdvancedPlayerUICoreAPI(Action onRegisteredAction = null)
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

                MyLog.Default.WriteLine("Registering Advanced Player UI Core API for Mod '" + ModName + "'");

                if (Registered)
                {
                    try
                    {
                        _AddMainMenuItem = (Func<Guid, string, bool>)ModAPIMethods["AddMainMenuItem"];
                        _RegisterMainMenuCallback = (Func<string, Action<Guid>, int, bool>)ModAPIMethods["RegisterMainMenuCallback"];
                        _LockMainMenu = (Action)ModAPIMethods["LockMainMenu"];
                        _ReleaseMainMenu = (Action)ModAPIMethods["ReleaseMainMenu"];

                        if (m_onRegisteredAction != null)
                            m_onRegisteredAction();
                    }
                    catch (Exception e)
                    {
                        MyAPIGateway.Utilities.ShowMessage("Advanced Player UI", "Mod '" + ModName + "' encountered an error when registering the Advanced Player UI Core API, see log for more info.");
                        MyLog.Default.WriteLine("Advanced Player UI Core API: " + e);
                    }
                }
            }
        }

    }

}