using ProtoBuf;

namespace ExtendedSurvival.Stats
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class PneumoniaSettings : BaseTemperatureDiseaseSettings
    {

        public PneumoniaSettings()
        {
            BaseChance = 0.005f;
            ExtremeChance = 0.01f;
            WetInfluence = 2f;
        }

    }

}
