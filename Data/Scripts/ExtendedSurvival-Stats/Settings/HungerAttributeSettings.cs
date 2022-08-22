using ProtoBuf;
using System.Xml.Serialization;

namespace ExtendedSurvival.Stats
{

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class HungerAttributeSettings : AttributeSettings
    {

        [XmlElement]
        public float MovingDrainMultiplier { get; set; } = 1.0f;

        [XmlElement]
        public float TreadmillDrainMultiplier { get; set; } = 1.0f;

        [XmlElement]
        public bool IncriseHungerDrainWithTemperature { get; set; } = true;

    }

}
