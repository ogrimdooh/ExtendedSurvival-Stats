using ProtoBuf;
using System.Xml.Serialization;

namespace ExtendedSurvival.Stats
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class ThirstAttributeSettings : AttributeSettings
    {

        [XmlElement]
        public float GainMultiplier { get; set; } = 1.0f;

        [XmlElement]
        public float MovingDrainMultiplier { get; set; } = 1.0f;

        [XmlElement]
        public float TreadmillDrainMultiplier { get; set; } = 1.0f;

        [XmlElement]
        public bool IncriseThirstDrainWithTemperature { get; set; } = true;

    }

}
