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
        public bool StaminaEnabled { get; set; } = true;

        [XmlElement]
        public bool BodyTemperatureEnabled { get; set; } = true;

        [XmlElement]
        public bool DamageEffectsEnabled { get; set; } = true;

        [XmlElement]
        public bool WetEnabled { get; set; } = true;

        [XmlElement]
        public bool PneumoniaEnabled { get; set; } = true;

        [XmlElement]
        public bool DysenteryEnabled { get; set; } = true;

        [XmlElement]
        public bool PoisonEnabled { get; set; } = true;

        [XmlElement]
        public bool InfectedEnabled { get; set; } = true;

        [XmlElement]
        public bool HypothermiaEnabled { get; set; } = true;

        [XmlElement]
        public bool HardModeEnabled { get; set; } = false;

        [XmlElement]
        public bool MetabolismEnabled { get; set; } = true;

        [XmlElement]
        public bool NutritionEnabled { get; set; } = true;

        [XmlElement]
        public bool HyperthermiaEnabled { get; set; } = true;

        [XmlElement]
        public bool StarvationEnabled { get; set; } = true;

        [XmlElement]
        public bool SevereStarvationEnabled { get; set; } = true;

        [XmlElement]
        public bool DehydrationEnabled { get; set; } = true;

        [XmlElement]
        public bool SevereDehydrationEnabled { get; set; } = true;

        [XmlElement]
        public bool ObesityEnabled { get; set; } = true;

        [XmlElement]
        public bool SevereObesityEnabled { get; set; } = true;

        [XmlElement]
        public bool RicketsEnabled { get; set; } = true;

        [XmlElement]
        public bool SevereRicketsEnabled { get; set; } = true;

        [XmlElement]
        public bool HypolipidemiaEnabled { get; set; } = true;

        [XmlElement]
        public HungerAttributeSettings HungerSettings { get; set; } = new HungerAttributeSettings();

        [XmlElement]
        public ThirstAttributeSettings ThirstSettings { get; set; } = new ThirstAttributeSettings();

        [XmlElement]
        public StaminaAttributeSettings StaminaSettings { get; set; } = new StaminaAttributeSettings();

        [XmlIgnore]
        public bool UseMetabolism
        {
            get
            {
                return MetabolismEnabled;
            }
        }

        [XmlIgnore]
        public bool UseNutrition
        {
            get
            {
                return UseMetabolism && NutritionEnabled;
            }
        }

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
                case "staminaenabled":
                    bool staminaenabled;
                    if (bool.TryParse(value, out staminaenabled))
                    {
                        StaminaEnabled = staminaenabled;
                        return true;
                    }
                    break;
                case "bodytemperatureenabled":
                    bool bodytemperatureenabled;
                    if (bool.TryParse(value, out bodytemperatureenabled))
                    {
                        BodyTemperatureEnabled = bodytemperatureenabled;
                        return true;
                    }
                    break;
                case "damageeffectsenabled":
                    bool damageeffectsenabled;
                    if (bool.TryParse(value, out damageeffectsenabled))
                    {
                        DamageEffectsEnabled = damageeffectsenabled;
                        return true;
                    }
                    break;
                case "wetenabled":
                    bool wetenabled;
                    if (bool.TryParse(value, out wetenabled))
                    {
                        WetEnabled = wetenabled;
                        return true;
                    }
                    break;
                case "pneumoniaenabled":
                    bool pneumoniaenabled;
                    if (bool.TryParse(value, out pneumoniaenabled))
                    {
                        PneumoniaEnabled = pneumoniaenabled;
                        return true;
                    }
                    break;
                case "dysenteryenabled":
                    bool dysenteryenabled;
                    if (bool.TryParse(value, out dysenteryenabled))
                    {
                        DysenteryEnabled = dysenteryenabled;
                        return true;
                    }
                    break;
                case "poisonenabled":
                    bool poisonenabled;
                    if (bool.TryParse(value, out poisonenabled))
                    {
                        DysenteryEnabled = poisonenabled;
                        return true;
                    }
                    break;
                case "infectedenabled":
                    bool infectedenabled;
                    if (bool.TryParse(value, out infectedenabled))
                    {
                        InfectedEnabled = infectedenabled;
                        return true;
                    }
                    break;
                case "hypothermiaenabled":
                    bool hypothermiaenabled;
                    if (bool.TryParse(value, out hypothermiaenabled))
                    {
                        HypothermiaEnabled = hypothermiaenabled;
                        return true;
                    }
                    break;
                case "hardmodeenabled":
                    bool hardmodeenabled;
                    if (bool.TryParse(value, out hardmodeenabled))
                    {
                        HardModeEnabled = hardmodeenabled;
                        return true;
                    }
                    break;
                case "metabolismenabled":
                    bool metabolismenabled;
                    if (bool.TryParse(value, out metabolismenabled))
                    {
                        MetabolismEnabled = metabolismenabled;
                        return true;
                    }
                    break;
                case "nutritionenabled":
                    bool nutritionenabled;
                    if (bool.TryParse(value, out nutritionenabled))
                    {
                        NutritionEnabled = nutritionenabled;
                        return true;
                    }
                    break;
                case "hyperthermiaenabled":
                    bool hyperthermiaenabled;
                    if (bool.TryParse(value, out hyperthermiaenabled))
                    {
                        HyperthermiaEnabled = hyperthermiaenabled;
                        return true;
                    }
                    break;
                case "starvationenabled":
                    bool starvationenabled;
                    if (bool.TryParse(value, out starvationenabled))
                    {
                        StarvationEnabled = starvationenabled;
                        return true;
                    }
                    break;
                case "severestarvationenabled":
                    bool severestarvationenabled;
                    if (bool.TryParse(value, out severestarvationenabled))
                    {
                        SevereStarvationEnabled = severestarvationenabled;
                        return true;
                    }
                    break;
                case "dehydrationenabled":
                    bool dehydrationenabled;
                    if (bool.TryParse(value, out dehydrationenabled))
                    {
                        DehydrationEnabled = dehydrationenabled;
                        return true;
                    }
                    break;
                case "severedehydrationenabled":
                    bool severedehydrationenabled;
                    if (bool.TryParse(value, out severedehydrationenabled))
                    {
                        SevereDehydrationEnabled = severedehydrationenabled;
                        return true;
                    }
                    break;
                case "obesityenabled":
                    bool obesityenabled;
                    if (bool.TryParse(value, out obesityenabled))
                    {
                        ObesityEnabled = obesityenabled;
                        return true;
                    }
                    break;
                case "severeobesityenabled":
                    bool severeobesityenabled;
                    if (bool.TryParse(value, out severeobesityenabled))
                    {
                        SevereObesityEnabled = severeobesityenabled;
                        return true;
                    }
                    break;
                case "ricketsenabled":
                    bool ricketsenabled;
                    if (bool.TryParse(value, out ricketsenabled))
                    {
                        RicketsEnabled = ricketsenabled;
                        return true;
                    }
                    break;
                case "severericketsenabled":
                    bool severericketsenabled;
                    if (bool.TryParse(value, out severericketsenabled))
                    {
                        SevereRicketsEnabled = severericketsenabled;
                        return true;
                    }
                    break;
                case "hypolipidemiaenabled":
                    bool hypolipidemiaenabled;
                    if (bool.TryParse(value, out hypolipidemiaenabled))
                    {
                        HypolipidemiaEnabled = hypolipidemiaenabled;
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
