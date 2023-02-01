using System;
using VRageMath;

namespace ExtendedSurvival.Stats
{
    public class PlayerSendData
    {

        public long EntityId { get; set; }
        public long PlayerId { get; set; }
        public ulong SteamPlayerId { get; set; }

        public bool HasDied { get; set; }
        public DateTime LastTimeDied { get; set; }

        public Vector2 Temperature { get; set; }

        public bool NeedToUpdateLocal { get; set; }
        public float O2Level { get; set; }
        public float CurrentCargoMass { get; set; }
        public float CurrentCargoVolume { get; set; }

    }

}