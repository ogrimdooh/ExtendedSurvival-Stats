using System;
using System.Xml.Serialization;

namespace ExtendedSurvival.Stats
{
    public abstract class BaseTemperatureComplexDiseaseSettings : BaseTemperatureDiseaseSettings
    {

        [XmlElement]
        public float RicketsInfluence { get; set; }

        [XmlElement]
        public float SevereRicketsInfluence { get; set; }

        [XmlElement]
        public float ObesityInfluence { get; set; }

        [XmlElement]
        public float SevereObesityInfluence { get; set; }

        public float GetRicketsInfluence()
        {
            return Math.Min(Math.Max(RicketsInfluence, 1.001f), 10.0f);
        }

        public float GetSevereRicketsInfluence()
        {
            return Math.Min(Math.Max(SevereRicketsInfluence, 1.001f), 10.0f);
        }

        public float GetObesityInfluence()
        {
            return Math.Min(Math.Max(ObesityInfluence, 1.001f), 10.0f);
        }

        public float GetSevereObesityInfluence()
        {
            return Math.Min(Math.Max(SevereObesityInfluence, 1.001f), 10.0f);
        }

    }

}
