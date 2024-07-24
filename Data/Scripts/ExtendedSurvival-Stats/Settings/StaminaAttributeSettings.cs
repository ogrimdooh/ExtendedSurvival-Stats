using ProtoBuf;
using System.Xml.Serialization;

namespace ExtendedSurvival.Stats
{

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class StaminaAttributeSettings
    {

        [XmlElement]
        public float DrainMultiplier { get; set; } = 1.0f;

        [XmlElement]
        public float GainMultiplier { get; set; } = 1.0f;

        [XmlElement]
        public float RuningDrainMultiplier { get; set; } = 1.0f;

        [XmlElement]
        public float TreadmillDrainMultiplier { get; set; } = 1.0f;

        [XmlElement]
        public float ToolsDrainMultiplier { get; set; } = 1.0f;

        [XmlElement]
        public float JumpDrainMultiplier { get; set; } = 1.0f;

        [XmlElement]
        public float DamageMultiplier { get; set; } = 1.0f;

        [XmlElement]
        public float MinValue { get; set; } = 15f;

    }

}
