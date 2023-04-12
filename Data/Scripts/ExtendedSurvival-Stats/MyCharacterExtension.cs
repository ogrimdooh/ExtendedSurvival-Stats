using Sandbox.Common.ObjectBuilders;
using Sandbox.ModAPI;
using Sandbox.ModAPI.Weapons;
using System;
using System.Linq;
using VRage.Game;
using VRage.Game.ModAPI;
using VRage.ObjectBuilders;

namespace ExtendedSurvival.Stats
{
    public static class MyCharacterExtension
    {


        public static bool IsCharacterWalking(this IMyCharacter Entity)
        {
            return Entity != null &&
                (int)Entity.CurrentMovementState >= (int)MyCharacterMovementEnum.Walking &&
                (int)Entity.CurrentMovementState < (int)MyCharacterMovementEnum.Running;
        }

        public static bool IsCharacterRuning(this IMyCharacter Entity)
        {
            return Entity != null &&
                (int)Entity.CurrentMovementState >= (int)MyCharacterMovementEnum.Running &&
                (int)Entity.CurrentMovementState < (int)MyCharacterMovementEnum.Sprinting;
        }

        public static bool IsCharacterSprinting(this IMyCharacter Entity)
        {
            return Entity != null && (int)Entity.CurrentMovementState == (int)MyCharacterMovementEnum.Sprinting;
        }

        public static bool IsCharacterFlying(this IMyCharacter Entity)
        {
            return Entity != null && (int)Entity.CurrentMovementState == (int)MyCharacterMovementEnum.Flying;
        }

        public static bool IsCharacterFalling(this IMyCharacter Entity)
        {
            return Entity != null && (int)Entity.CurrentMovementState == (int)MyCharacterMovementEnum.Falling;
        }

        public static bool IsCharacterSitting(this IMyCharacter Entity)
        {
            return Entity != null && (int)Entity.CurrentMovementState == (int)MyCharacterMovementEnum.Sitting;
        }

        public static IMyCubeBlock GetControlledEntity(this IMyCharacter Entity)
        {
            return Entity.Parent as IMyCubeBlock;
        }

        public static bool HasControlledEntity(this IMyCharacter Entity)
        {
            return Entity.GetControlledEntity() != null;
        }

        public static bool IsCharacterMoving(this IMyCharacter Entity)
        {
            return Entity != null &&
                !Entity.HasControlledEntity() &&
                (Entity.IsCharacterWalking() || Entity.IsCharacterRuning() || Entity.IsCharacterSprinting());
        }

        public static bool HasEquippedTool(this IMyCharacter Entity)
        {
            return Entity.EquippedTool != null;
        }

        public static bool IsCharacterUsingTool(this IMyCharacter Entity)
        {
            if (Entity.HasEquippedTool())
            {
                var handTool = Entity.EquippedTool as IMyEngineerToolBase;
                if (handTool != null)
                    return handTool.IsShooting;
                var handDrill = Entity.EquippedTool as IMyHandDrill;
                if (handDrill != null)
                    return handDrill.IsShooting;
                var rifleGun = Entity.EquippedTool as IMyAutomaticRifleGun;
                if (rifleGun != null)
                    return rifleGun.IsShooting;
            }
            return false;
        }

        public static bool IsOnTreadmill(this IMyCharacter Entity)
        {
            var block = Entity.GetControlledEntity();
            if (block != null)
            {
                var cockpit = block as IMyCockpit;
                if (cockpit != null)
                {
                    return cockpit.BlockDefinition.SubtypeName.Contains("Treadmill");
                }
            }
            return false;
        }

        public static bool CanTakeDamage(this IMyCharacter Entity)
        {
            return !MyAPIGateway.Session.CreativeMode && 
                !MyAPIGateway.Session.IsUserInvulnerable(Entity.GetPlayer()?.SteamUserId ?? 0) && 
                !Entity.IsDead;
        }

        public static bool IsOnCryoChamber(this IMyCharacter Entity)
        {
            var block = Entity.GetControlledEntity();
            if (block != null)
            {
                var cryoBlock = block as IMyCryoChamber;
                if (cryoBlock != null)
                {
                    return cryoBlock.IsWorking;
                }
            }
            return false;
        }

        private static readonly string[] ValidBathroom = new string[] {
            "LargeBlockBathroomOpen",
            "LargeBlockBathroom",
            "LargeBlockToilet",
            "LargeBlockCryoChamber",
            "SmallBlockCryoChamber"
        };

        public static bool IsOnValidBathroom(this IMyCharacter Entity)
        {
            var block = Entity.GetControlledEntity();
            if (block != null)
            {
                return ValidBathroom.Contains(block.BlockDefinition.SubtypeId);
            }
            return false;
        }

        private static readonly MyObjectBuilderType[] ValidRestBlock = new MyObjectBuilderType[] {
            typeof(MyObjectBuilder_CryoChamber),
            typeof(MyObjectBuilder_Cockpit)
        };

        public static bool IsOnValidRestBlock(this IMyCharacter Entity)
        {
            var block = Entity.GetControlledEntity();
            if (block != null)
            {
                return ValidRestBlock.Contains(block.BlockDefinition.TypeId);
            }
            return false;
        }

        private static readonly string[] GoodRestBlock = new string[] {
            "LargeBlockCryoChamber",
            "SmallBlockCryoChamber",
            "LargeBlockBed"
        };

        public static bool IsOnGoodRestBlock(this IMyCharacter Entity)
        {
            var block = Entity.GetControlledEntity();
            if (block != null)
            {
                return GoodRestBlock.Contains(block.BlockDefinition.SubtypeId);
            }
            return false;
        }

    }

}
