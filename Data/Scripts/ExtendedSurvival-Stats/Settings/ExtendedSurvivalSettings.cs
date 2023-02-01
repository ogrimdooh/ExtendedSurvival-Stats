using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using VRage.Utils;
using VRageMath;

namespace ExtendedSurvival.Stats
{

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class ExtendedSurvivalSettings : BaseSettings
    {

        private const int CURRENT_VERSION = 1;
        private const string FILE_NAME = "ExtendedSurvival.Stats.Settings.xml";

        private static ExtendedSurvivalSettings _instance;
        public static ExtendedSurvivalSettings Instance
        {
            get
            {
                if (_instance == null)
                    _instance = Load();
                return _instance;
            }
        }

        [XmlElement]
        public bool HardModeEnabled { get; set; } = false;

        [XmlElement]
        public HungerAttributeSettings HungerSettings { get; set; } = new HungerAttributeSettings();

        [XmlElement]
        public ThirstAttributeSettings ThirstSettings { get; set; } = new ThirstAttributeSettings();

        [XmlElement]
        public StaminaAttributeSettings StaminaSettings { get; set; } = new StaminaAttributeSettings();

        private static bool Validate(ExtendedSurvivalSettings settings)
        {
            var res = true;
            return res;
        }

        public static ExtendedSurvivalSettings Load()
        {
            _instance = Load(FILE_NAME, CURRENT_VERSION, Validate, () => { return new ExtendedSurvivalSettings(); });
            return _instance;
        }

        public static void ClientLoad(string data)
        {
            _instance = GetData<ExtendedSurvivalSettings>(data);
        }

        public string GetDataToClient()
        {
            return GetData(this);
        }

        public static void Save()
        {
            try
            {
                Save(Instance, FILE_NAME, true);
            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(typeof(ExtendedSurvivalSettings), ex);
            }
        }

        public ExtendedSurvivalSettings()
        {

        }

        protected override void OnAfterLoad()
        {
            base.OnAfterLoad();

        }

        public bool SetConfigValue(string name, string value)
        {
            switch (name)
            {
                case "hardmodeenabled":
                    bool hardmodeenabled;
                    if (bool.TryParse(value, out hardmodeenabled))
                    {
                        HardModeEnabled = hardmodeenabled;
                        return true;
                    }
                    break;
                case "staminasettings.gainmultiplier":
                    float staminasettingsgainmultiplier;
                    if (float.TryParse(value, out staminasettingsgainmultiplier))
                    {
                        StaminaSettings.GainMultiplier = staminasettingsgainmultiplier;
                        return true;
                    }
                    break;
                case "staminasettings.drainmultiplier":
                    float staminasettingsdrainmultiplier;
                    if (float.TryParse(value, out staminasettingsdrainmultiplier))
                    {
                        StaminaSettings.DrainMultiplier = staminasettingsdrainmultiplier;
                        return true;
                    }
                    break;
                case "staminasettings.runingdrainmultiplier":
                    float staminasettingsruningdrainmultiplier;
                    if (float.TryParse(value, out staminasettingsruningdrainmultiplier))
                    {
                        StaminaSettings.RuningDrainMultiplier = staminasettingsruningdrainmultiplier;
                        return true;
                    }
                    break;
                case "staminasettings.treadmilldrainmultiplier":
                    float staminasettingstreadmilldrainmultiplier;
                    if (float.TryParse(value, out staminasettingstreadmilldrainmultiplier))
                    {
                        StaminaSettings.TreadmillDrainMultiplier = staminasettingstreadmilldrainmultiplier;
                        return true;
                    }
                    break;
                case "staminasettings.toolsdrainmultiplier":
                    float staminasettingstoolsdrainmultiplier;
                    if (float.TryParse(value, out staminasettingstoolsdrainmultiplier))
                    {
                        StaminaSettings.ToolsDrainMultiplier = staminasettingstoolsdrainmultiplier;
                        return true;
                    }
                    break;
                case "staminasettings.damagemultiplier":
                    float staminasettingsdamagemultiplier;
                    if (float.TryParse(value, out staminasettingsdamagemultiplier))
                    {
                        StaminaSettings.DamageMultiplier = staminasettingsdamagemultiplier;
                        return true;
                    }
                    break;
                case "staminasettings.lostmaxstaminawhengotsick":
                    bool staminasettingslostmaxstaminawhengotsick;
                    if (bool.TryParse(value, out staminasettingslostmaxstaminawhengotsick))
                    {
                        StaminaSettings.LostMaxStaminaWhenGotSick = staminasettingslostmaxstaminawhengotsick;
                        return true;
                    }
                    break;
                case "staminasettings.incrisestaminadrainwithtemperature":
                    bool staminasettingsincrisestaminadrainwithtemperature;
                    if (bool.TryParse(value, out staminasettingsincrisestaminadrainwithtemperature))
                    {
                        StaminaSettings.IncriseStaminaDrainWithTemperature = staminasettingsincrisestaminadrainwithtemperature;
                        return true;
                    }
                    break;
                case "staminasettings.decreasestaminagainwithdamage":
                    bool staminasettingsdecreasestaminagainwithdamage;
                    if (bool.TryParse(value, out staminasettingsdecreasestaminagainwithdamage))
                    {
                        StaminaSettings.DecreaseStaminaGainWithDamage = staminasettingsdecreasestaminagainwithdamage;
                        return true;
                    }
                    break;
                case "staminasettings.incrisestaminadrainwithbodyfat":
                    bool staminasettingsincrisestaminadrainwithbodyfat;
                    if (bool.TryParse(value, out staminasettingsincrisestaminadrainwithbodyfat))
                    {
                        StaminaSettings.IncriseStaminaDrainWithBodyFat = staminasettingsincrisestaminadrainwithbodyfat;
                        return true;
                    }
                    break;
                case "hungersettings.drainmultiplier":
                    float hungersettingsdrainmultiplier;
                    if (float.TryParse(value, out hungersettingsdrainmultiplier))
                    {
                        HungerSettings.DrainMultiplier = hungersettingsdrainmultiplier;
                        return true;
                    }
                    break;
                case "hungersettings.movingdrainmultiplier":
                    float hungersettingsmovingdrainmultiplier;
                    if (float.TryParse(value, out hungersettingsmovingdrainmultiplier))
                    {
                        HungerSettings.MovingDrainMultiplier = hungersettingsmovingdrainmultiplier;
                        return true;
                    }
                    break;
                case "hungersettings.treadmilldrainmultiplier":
                    float hungersettingstreadmilldrainmultiplier;
                    if (float.TryParse(value, out hungersettingstreadmilldrainmultiplier))
                    {
                        HungerSettings.TreadmillDrainMultiplier = hungersettingstreadmilldrainmultiplier;
                        return true;
                    }
                    break;
                case "hungersettings.incrisehungerdrainwithtemperature":
                    bool hungersettingsincrisehungerdrainwithtemperature;
                    if (bool.TryParse(value, out hungersettingsincrisehungerdrainwithtemperature))
                    {
                        HungerSettings.IncriseHungerDrainWithTemperature = hungersettingsincrisehungerdrainwithtemperature;
                        return true;
                    }
                    break;
                case "thirstsettings.gainmultiplier":
                    float thirstsettingsgainmultiplier;
                    if (float.TryParse(value, out thirstsettingsgainmultiplier))
                    {
                        ThirstSettings.GainMultiplier = thirstsettingsgainmultiplier;
                        return true;
                    }
                    break;
                case "thirstsettings.drainmultiplier":
                    float thirstsettingsdrainmultiplier;
                    if (float.TryParse(value, out thirstsettingsdrainmultiplier))
                    {
                        ThirstSettings.DrainMultiplier = thirstsettingsdrainmultiplier;
                        return true;
                    }
                    break;
                case "thirstsettings.movingdrainmultiplier":
                    float thirstsettingsmovingdrainmultiplier;
                    if (float.TryParse(value, out thirstsettingsmovingdrainmultiplier))
                    {
                        ThirstSettings.MovingDrainMultiplier = thirstsettingsmovingdrainmultiplier;
                        return true;
                    }
                    break;
                case "thirstsettings.treadmilldrainmultiplier":
                    float thirstsettingstreadmilldrainmultiplier;
                    if (float.TryParse(value, out thirstsettingstreadmilldrainmultiplier))
                    {
                        ThirstSettings.TreadmillDrainMultiplier = thirstsettingstreadmilldrainmultiplier;
                        return true;
                    }
                    break;
                case "thirstsettings.incrisethirstdrainwithtemperature":
                    bool thirstsettingsincrisethirstdrainwithtemperature;
                    if (bool.TryParse(value, out thirstsettingsincrisethirstdrainwithtemperature))
                    {
                        ThirstSettings.IncriseThirstDrainWithTemperature = thirstsettingsincrisethirstdrainwithtemperature;
                        return true;
                    }
                    break;
            }
            return false;
        }

    }

}
