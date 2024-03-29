﻿using Sandbox.ModAPI;
using System;
using VRage.Utils;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;

namespace ExtendedSurvival.Stats
{

    public abstract class BaseSettings
    {

        protected delegate bool BaseSettings_Validade<T>(T settings) where T : BaseSettings;
        protected delegate T BaseSettings_Upgrade<T>(T settings) where T : BaseSettings;
        protected delegate T BaseSettings_Create<T>() where T : BaseSettings;

        [XmlElement]
        public int Version { get; set; }

        protected static T Load<T>(string fileName, int currentVersion, BaseSettings_Validade<T> validade, BaseSettings_Create<T> create, BaseSettings_Upgrade<T> upgrade, bool json = false, bool createIfNotFound = true) where T : BaseSettings
        {
            var world = true;
            T settings = null;
            try
            {
                if (MyAPIGateway.Utilities.FileExistsInWorldStorage(fileName, typeof(T)))
                {
                    var needToRecreate = true;
                    using (var reader = MyAPIGateway.Utilities.ReadFileInWorldStorage(fileName, typeof(T)))
                    {
                        var fileData = reader.ReadToEnd();
                        if (fileData.Length > 0)
                        {
                            try
                            {
                                settings = GetData<T>(fileData, json);
                                MyLog.Default.WriteLineAndConsole(fileName + ": Loaded from world file.");
                                needToRecreate = false;
                            }
                            catch (Exception)
                            {
                                MyLog.Default.WriteLineAndConsole(fileName + ": Loaded from world file error.");
                            }
                        }
                    }
                    if (needToRecreate)
                    {
                        settings = create();
                        settings.Version = currentVersion;
                        validade(settings);
                        Save<T>(settings, fileName, world, json);
                        MyLog.Default.WriteLineAndConsole(fileName + ": World file recreated.");
                    }
                }
                else if (MyAPIGateway.Utilities.FileExistsInLocalStorage(fileName, typeof(T)))
                {
                    world = false;
                    var needToRecreate = true;
                    using (var reader = MyAPIGateway.Utilities.ReadFileInLocalStorage(fileName, typeof(T)))
                    {
                        var fileData = reader.ReadToEnd();
                        if (fileData.Length > 0)
                        {
                            try
                            {
                                settings = GetData<T>(fileData, json);
                                MyLog.Default.WriteLineAndConsole(fileName + ": Loaded from local file.");
                                needToRecreate = false;
                            }
                            catch (Exception)
                            {
                                MyLog.Default.WriteLineAndConsole(fileName + ": Loaded from local file error.");
                            }
                        }
                    }
                    if (needToRecreate)
                    {
                        settings = create();
                        settings.Version = currentVersion;
                        validade(settings);
                        Save<T>(settings, fileName, world, json);
                        MyLog.Default.WriteLineAndConsole(fileName + ": Local file recreated.");
                    }
                }

                if (settings != null)
                {
                    var adjusted = false;
                    if (settings.Version < currentVersion)
                    {
                        MyLog.Default.WriteLineAndConsole(string.Format(fileName + ": Settings have old version: {0} update to {1}", settings.Version, currentVersion));
                        settings = upgrade(settings);
                        adjusted = true;
                        settings.Version = currentVersion;
                    }
                    adjusted = adjusted || !validade(settings);
                    if (adjusted) Save<T>(settings, fileName, world, json);
                }
                else if (createIfNotFound)
                {
                    settings = create();
                    settings.Version = currentVersion;
                    validade(settings);
                    Save<T>(settings, fileName, world, json);
                }
                settings?.OnAfterLoad();
            }
            catch (Exception ex)
            {
                MyLog.Default.WriteLineAndConsole(string.Format(fileName + ": Exception while loading: {0}", ex.Message));
            }

            return settings;
        }

        protected virtual void OnAfterLoad()
        {

        }

        protected static T GetData<T>(string data, bool json) where T : BaseSettings
        {
            if (json)
            {
                var lines = data.Replace(Environment.NewLine, "\n").Split('\n');
                var nDict = new List<KeyValuePair<string, object>>();
                int nEnd = 0;
                JsonUtils.JsonToDic(0, lines, nDict, out nEnd);
                StringBuilder sb = new StringBuilder();
                JsonUtils.DicToXml(sb, nDict, 0);
                data = sb.ToString();
            }
            return MyAPIGateway.Utilities.SerializeFromXML<T>(data);
        }

        protected static string GetData<T>(T settings, bool json) where T : BaseSettings
        {
            var data = MyAPIGateway.Utilities.SerializeToXML(settings);
            if (json)
            {
                var lines = data.Replace(Environment.NewLine, "\n").Split('\n');
                var nDict = new List<KeyValuePair<string, object>>();
                int nEnd = 0;
                JsonUtils.XmlToDic(0, lines, nDict, out nEnd);
                StringBuilder sb = new StringBuilder();
                JsonUtils.DicToJson(sb, nDict, 0);
                data = sb.ToString();
            }
            return data;
        }

        protected static void Save<T>(T settings, string fileName, bool world, bool json) where T : BaseSettings
        {
            var targetType = typeof(T);
            if (world)
            {
                using (var writer = MyAPIGateway.Utilities.WriteFileInWorldStorage(fileName, targetType))
                {
                    writer.Write(GetData<T>(settings, json));
                }
            }
            else
            {
                using (var writer = MyAPIGateway.Utilities.WriteFileInLocalStorage(fileName, targetType))
                {
                    writer.Write(GetData<T>(settings, json));
                }
            }
        }

    }

}
