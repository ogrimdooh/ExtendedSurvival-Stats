using System;
using System.Xml.Serialization;

namespace ExtendedSurvival.Stats
{
    public abstract class BaseTemperatureDiseaseSettings
    {

        [XmlElement]
        public float BaseChance { get; set; }

        [XmlElement]
        public float ExtremeChance { get; set; }

        [XmlElement]
        public float WetInfluence { get; set; }

        public float GetBaseChance()
        {
            return Math.Min(Math.Max(BaseChance, 0.001f), 0.25f);
        }

        public float GetExtremeChance()
        {
            return Math.Min(Math.Max(ExtremeChance, 0.001f), 0.25f);
        }

        public float GetWetInfluence()
        {
            return Math.Min(Math.Max(WetInfluence, 1.001f), 10.0f);
        }

    }

}
