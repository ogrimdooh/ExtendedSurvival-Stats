using ProtoBuf;
using System.Xml.Serialization;

namespace ExtendedSurvival.Stats
{

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class StaminaAttributeSettings : AttributeSettings
    {

        [XmlElement]
        public float GainMultiplier { get; set; } = 1.0f;

        [XmlElement]
        public float RuningDrainMultiplier { get; set; } = 1.0f;

        [XmlElement]
        public float TreadmillDrainMultiplier { get; set; } = 1.0f;

        [XmlElement]
        public float ToolsDrainMultiplier { get; set; } = 1.0f;

        [XmlElement]
        public float DamageMultiplier { get; set; } = 1.0f;

        [XmlElement]
        public bool LostMaxStaminaWhenGotSick { get; set; } = true;

        [XmlElement]
        public bool IncriseStaminaDrainWithTemperature { get; set; } = true;

        [XmlElement]
        public bool IncriseStaminaDrainWithBodyFat { get; set; } = true;

        [XmlElement]
        public bool DecreaseStaminaGainWithDamage { get; set; } = true;

    }

}
