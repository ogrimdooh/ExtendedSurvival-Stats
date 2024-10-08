﻿using ProtoBuf;
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

        private const bool USE_JSON_TO_SAVE = true;

        public const string HELP_TOPIC_SUBTYPE = "ExtendedSurvival.Stats.Settings";
        public static readonly HelpController.ConfigurationEntryHelpInfo[] HELP_INFO = new HelpController.ConfigurationEntryHelpInfo[]
        {
            new HelpController.ConfigurationEntryHelpInfo()
            {
                EntryId = new UniqueNameId(HelpController.BASE_TOPIC_TYPE, $"{HELP_TOPIC_SUBTYPE}.Debug"),
                Title = "Debug",
                Description = LanguageProvider.GetEntry(LanguageEntries.HELP_SETTINGS_DEBUG_DESCRIPTION),
                DefaultValue = "false",
                CanUseSettingsCommand = true,
                NeedRestart = false,
                CommandSample = "/settings Debug true",
                ValueType = HelpController.ConfigurationValueType.Bool
            }
        };

        private const int CURRENT_VERSION = 4;
        private const string FILE_NAME = "ExtendedSurvival.Stats.Settings.xml";
        private const string JSON_FILE_NAME = "ExtendedSurvival.Stats.Settings.cfg";

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
        public bool Debug { get; set; } = false;

        [XmlElement]
        public bool ForceCreatureSpawn { get; set; } = true;

        [XmlElement]
        public bool HardModeEnabled { get; set; } = false;

        [XmlElement]
        public float MetabolismSpeedMultiplier { get; set; } = 4.0f;

        [XmlElement]
        public float CreatureBulletDamageReciverMultiplier { get; set; } = 5.0f;

        [XmlElement]
        public int MaxActiveFoodEffects { get; set; } = 3;

        [XmlElement]
        public MetabolismSettings MetabolismSettings { get; set; } = new MetabolismSettings();

        [XmlElement]
        public StaminaAttributeSettings StaminaSettings { get; set; } = new StaminaAttributeSettings();

        [XmlElement]
        public FoodSettings FoodSettings { get; set; } = new FoodSettings();

        [XmlElement]
        public DiseaseSettings DiseaseSettings { get; set; } = new DiseaseSettings();

        private static bool Validate(ExtendedSurvivalSettings settings)
        {
            var res = true;
            return res;
        }

        private static ExtendedSurvivalSettings Upgrade(ExtendedSurvivalSettings settings)
        {
            if (settings.Version < 3)
            {
                settings.ForceCreatureSpawn = true;
                settings.MetabolismSpeedMultiplier = 6;
                settings.MetabolismSettings = new MetabolismSettings();
                settings.StaminaSettings = new StaminaAttributeSettings();
                settings.FoodSettings = new FoodSettings();
                settings.DiseaseSettings = new DiseaseSettings();
            }
            return settings;
        }

        public static ExtendedSurvivalSettings Load()
        {
            _instance = Load(JSON_FILE_NAME, CURRENT_VERSION, Validate, () => { return new ExtendedSurvivalSettings(); }, Upgrade, true, false);
            if (_instance == null)
                _instance = Load(FILE_NAME, CURRENT_VERSION, Validate, () => { return new ExtendedSurvivalSettings(); }, Upgrade);
            return _instance;
        }

        public static void ClientLoad(string data)
        {
            _instance = GetData<ExtendedSurvivalSettings>(data, true);
        }

        public string GetDataToClient()
        {
            return GetData(this, true);
        }

        public static void Save()
        {
            try
            {
                Save<ExtendedSurvivalSettings>(Instance, USE_JSON_TO_SAVE ? JSON_FILE_NAME : FILE_NAME, true, USE_JSON_TO_SAVE);
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

        public bool ClearFoodVolume(UniqueEntityId id)
        {
            if (FoodSettings.Volumes.Any(x => x.Id == id.DefinitionId))
            {
                FoodSettings.Volumes.RemoveAll(x => x.Id == id.DefinitionId);
                return true;
            }
            return false;
        }

        public bool SetFoodVolume(UniqueEntityId id, float multiplier)
        {
            if (FoodSettings.Volumes.Any(x => x.Id == id.DefinitionId))
            {
                var settings = FoodSettings.Volumes.FirstOrDefault(x => x.Id == id.DefinitionId);
                settings.Multiplier = multiplier;
            }
            else
            {
                FoodSettings.Volumes.Add(new FoodVolumeSettings() 
                { 
                    Id = id.DefinitionId,
                    Multiplier = multiplier
                });
            }
            return true;
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
                case "metabolismspeedmultiplier":
                    float metabolismspeedmultiplier;
                    if (float.TryParse(value, out metabolismspeedmultiplier))
                    {
                        MetabolismSpeedMultiplier = Math.Max(0.01f, Math.Min(10, metabolismspeedmultiplier));
                        return true;
                    }
                    break;
                case "creaturebulletdamagerecivermultiplier":
                    float creaturebulletdamagerecivermultiplier;
                    if (float.TryParse(value, out creaturebulletdamagerecivermultiplier))
                    {
                        CreatureBulletDamageReciverMultiplier = Math.Max(0.01f, Math.Min(10, creaturebulletdamagerecivermultiplier));
                        return true;
                    }
                    break;
                case "maxactivefoodeffects":
                    int maxactivefoodeffects;
                    if (int.TryParse(value, out maxactivefoodeffects))
                    {
                        MaxActiveFoodEffects = Math.Max(1, Math.Min(10, maxactivefoodeffects));
                        return true;
                    }
                    break;
                case "metabolismsettings.caloriesconsumemultiplier":
                    float metabolismsettingscaloriesconsumemultiplier;
                    if (float.TryParse(value, out metabolismsettingscaloriesconsumemultiplier))
                    {
                        MetabolismSettings.CaloriesConsumeMultiplier = metabolismsettingscaloriesconsumemultiplier;
                        return true;
                    }
                    break;
                case "metabolismsettings.waterconsumemultiplier":
                    float metabolismsettingswaterconsumemultiplier;
                    if (float.TryParse(value, out metabolismsettingswaterconsumemultiplier))
                    {
                        MetabolismSettings.WaterConsumeMultiplier = metabolismsettingswaterconsumemultiplier;
                        return true;
                    }
                    break;
                case "metabolismsettings.proteinconsumemultiplier":
                    float metabolismsettingsproteinconsumemultiplier;
                    if (float.TryParse(value, out metabolismsettingsproteinconsumemultiplier))
                    {
                        MetabolismSettings.ProteinConsumeMultiplier = metabolismsettingsproteinconsumemultiplier;
                        return true;
                    }
                    break;
                case "metabolismsettings.carbohydrateconsumemultiplier":
                    float metabolismsettingscarbohydrateconsumemultiplier;
                    if (float.TryParse(value, out metabolismsettingscarbohydrateconsumemultiplier))
                    {
                        MetabolismSettings.CarbohydrateConsumeMultiplier = metabolismsettingscarbohydrateconsumemultiplier;
                        return true;
                    }
                    break;
                case "metabolismsettings.lipidsconsumemultiplier":
                    float metabolismsettingslipidsconsumemultiplier;
                    if (float.TryParse(value, out metabolismsettingslipidsconsumemultiplier))
                    {
                        MetabolismSettings.LipidsConsumeMultiplier = metabolismsettingslipidsconsumemultiplier;
                        return true;
                    }
                    break;
                case "metabolismsettings.mineralsconsumemultiplier":
                    float metabolismsettingsmineralsconsumemultiplier;
                    if (float.TryParse(value, out metabolismsettingsmineralsconsumemultiplier))
                    {
                        MetabolismSettings.MineralsConsumeMultiplier = metabolismsettingsmineralsconsumemultiplier;
                        return true;
                    }
                    break;
                case "metabolismsettings.vitaminsconsumemultiplier":
                    float metabolismsettingsvitaminsconsumemultiplier;
                    if (float.TryParse(value, out metabolismsettingsvitaminsconsumemultiplier))
                    {
                        MetabolismSettings.VitaminsConsumeMultiplier = metabolismsettingsvitaminsconsumemultiplier;
                        return true;
                    }
                    break;
                case "metabolismsettings.staminaspendedmultiplier":
                    float metabolismsettingsstaminaspendedmultiplier;
                    if (float.TryParse(value, out metabolismsettingsstaminaspendedmultiplier))
                    {
                        MetabolismSettings.StaminaSpendedMultiplier = metabolismsettingsstaminaspendedmultiplier;
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
                case "staminasettings.jumpdrainmultiplier":
                    float staminasettingsjumpdrainmultiplier;
                    if (float.TryParse(value, out staminasettingsjumpdrainmultiplier))
                    {
                        StaminaSettings.JumpDrainMultiplier = staminasettingsjumpdrainmultiplier;
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
                case "foodsettings.proteinsmultiplier":
                    float foodsettingsproteinsmultiplier;
                    if (float.TryParse(value, out foodsettingsproteinsmultiplier))
                    {
                        FoodSettings.ProteinsMultiplier = foodsettingsproteinsmultiplier;
                        return true;
                    }
                    break;
                case "foodsettings.carbohydratesmultiplier":
                    float foodsettingscarbohydratesmultiplier;
                    if (float.TryParse(value, out foodsettingscarbohydratesmultiplier))
                    {
                        FoodSettings.CarbohydratesMultiplier = foodsettingscarbohydratesmultiplier;
                        return true;
                    }
                    break;
                case "foodsettings.lipidsmultiplier":
                    float foodsettingslipidsmultiplier;
                    if (float.TryParse(value, out foodsettingslipidsmultiplier))
                    {
                        FoodSettings.LipidsMultiplier = foodsettingslipidsmultiplier;
                        return true;
                    }
                    break;
                case "foodsettings.vitaminsmultiplier":
                    float foodsettingsvitaminsmultiplier;
                    if (float.TryParse(value, out foodsettingsvitaminsmultiplier))
                    {
                        FoodSettings.VitaminsMultiplier = foodsettingsvitaminsmultiplier;
                        return true;
                    }
                    break;
                case "foodsettings.mineralsmultiplier":
                    float foodsettingsmineralsmultiplier;
                    if (float.TryParse(value, out foodsettingsmineralsmultiplier))
                    {
                        FoodSettings.MineralsMultiplier = foodsettingsmineralsmultiplier;
                        return true;
                    }
                    break;
                case "foodsettings.caloriesmultiplier":
                    float foodsettingscaloriesmultiplier;
                    if (float.TryParse(value, out foodsettingscaloriesmultiplier))
                    {
                        FoodSettings.CaloriesMultiplier = foodsettingscaloriesmultiplier;
                        return true;
                    }
                    break;
                case "foodsettings.digestiontimemultiplier":
                    float foodsettingsdigestiontimemultiplier;
                    if (float.TryParse(value, out foodsettingsdigestiontimemultiplier))
                    {
                        FoodSettings.DigestionTimeMultiplier = foodsettingsdigestiontimemultiplier;
                        return true;
                    }
                    break;                    
            }
            return false;
        }

    }

}
