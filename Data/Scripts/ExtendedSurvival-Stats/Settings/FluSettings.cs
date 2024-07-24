using ProtoBuf;

namespace ExtendedSurvival.Stats
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class FluSettings : BaseTemperatureDiseaseSettings
    {

        public FluSettings()
        {
            BaseChance = 0.015f;
            ExtremeChance = 0.03f;
            WetInfluence = 2f;
        }

    }

}
