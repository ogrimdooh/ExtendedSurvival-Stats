using ProtoBuf;
using System.Xml;
using System.Xml.Serialization;

namespace ExtendedSurvival.Stats
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class MetabolismSettings
    {

        [XmlElement]
        public float CaloriesConsumeMultiplier { get; set; } = 1.0f;

        [XmlElement]
        public float WaterConsumeMultiplier { get; set; } = 1.0f;

        [XmlElement]
        public float ProteinConsumeMultiplier { get; set; } = 1.0f;

        [XmlElement]
        public float CarbohydrateConsumeMultiplier { get; set; } = 1.0f;

        [XmlElement]
        public float LipidsConsumeMultiplier { get; set; } = 1.0f;

        [XmlElement]
        public float MineralsConsumeMultiplier { get; set; } = 1.0f;

        [XmlElement]
        public float VitaminsConsumeMultiplier { get; set; } = 1.0f;

        [XmlElement]
        public float StaminaSpendedMultiplier { get; set; } = 1.0f;

    }

}
