﻿using ProtoBuf;
using Sandbox.Definitions;
using System;
using VRage.Game;
using VRage.ObjectBuilders;
using VRage.Utils;

namespace ExtendedSurvival
{

    [ProtoContract]
    public class UniqueEntityId : UId<MyObjectBuilderType, MyStringHash>, IEquatable<UniqueEntityId>
    {

        public static readonly UniqueEntityId Empty = new UniqueEntityId();

        public static UniqueEntityId Parse(string id)
        {
            UniqueEntityId output;
            if (!TryParse(id, out output))
                throw new ArgumentException("The provided type does not conform to a entity ID.", "id");
            return output;
        }

        public static bool TryParse(string id, out UniqueEntityId definitionId)
        {
            if (string.IsNullOrEmpty(id))
            {
                definitionId = new UniqueEntityId();
                return false;
            }

            var slashIndex = id.IndexOf('-');
            if (slashIndex == -1)
            {
                definitionId = new UniqueEntityId();
                return false;
            }
            var typeId = id.Substring(0, slashIndex).Trim();
            var subtypeId = id.Substring(slashIndex + 1).Trim();
            if (subtypeId == "(null)")
                subtypeId = null;
            definitionId = new UniqueEntityId(MyObjectBuilderType.Parse(typeId), MyStringHash.Get(subtypeId));
            return true;
        }

        public MyDefinitionId DefinitionId
        {
            get
            {
                return GetDefinitionId();
            }
        }

        public UniqueEntityId()
            :base()
        {

        }

        public UniqueEntityId(MyObjectBuilderType typeId, MyStringHash subtypeId)
            : base(typeId, subtypeId)
        {
        }

        public UniqueEntityId(MyObjectBuilderType typeId, string subtypeId)
            : base(typeId, MyStringHash.Get(subtypeId))
        {
        }

        public UniqueEntityId(MyDefinitionId id)
            : base(id.TypeId, id.SubtypeId)
        {
        }

        public bool Equals(UniqueEntityId other)
        {
            return typeId == other.typeId && subtypeId == other.subtypeId;
        }

        public override bool Equals(object obj)
        {
            return (obj is UniqueEntityId) && Equals((UniqueEntityId)obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public MyDefinitionId GetDefinitionId()
        {
            return new MyDefinitionId(typeId, subtypeId);
        }

        public static bool operator ==(UniqueEntityId l, UniqueEntityId r)
        {
            return l.Equals(r);
        }

        public static bool operator !=(UniqueEntityId l, UniqueEntityId r)
        {
            return !l.Equals(r);
        }

    }

}
