﻿using Sandbox.Common.ObjectBuilders;
using Sandbox.Definitions;
using System;
using System.Collections.Generic;
using VRage.Game;

namespace ExtendedSurvival
{

    public sealed class AssemblerOverride : BaseIntegrationModRecipesOverride
    {

        public static void TryOverride()
        {
            new AssemblerOverride().SetDefinitions();
        }

        public const string SurvivalKitLarge = "SurvivalKitLarge";
        public const string SurvivalKit = "SurvivalKit";

        public const string BasicAlchemyBench = "BasicAlchemyBench";
        public const string AlchemyBench = "AlchemyBench";
        public const string AlchemyBenchIndustrial = "AlchemyBenchIndustrial";

        protected override ulong[] GetModId()
        {
            return new ulong[] { };
        }

        protected override List<ComponentCost> GetBlockCost(UniqueEntityId item)
        {
            return new List<ComponentCost>();
        }

        protected override List<UniqueEntityId> GetBlocks()
        {
            var retorno = new List<UniqueEntityId>();
            try
            {
                retorno.Add(new UniqueEntityId(typeof(MyObjectBuilder_SurvivalKit), SurvivalKit));
                retorno.Add(new UniqueEntityId(typeof(MyObjectBuilder_SurvivalKit), SurvivalKitLarge));
                retorno.Add(new UniqueEntityId(typeof(MyObjectBuilder_Assembler), BasicAlchemyBench));
                retorno.Add(new UniqueEntityId(typeof(MyObjectBuilder_Assembler), AlchemyBench));
                retorno.Add(new UniqueEntityId(typeof(MyObjectBuilder_Assembler), AlchemyBenchIndustrial));
            }
            catch (Exception ex)
            {
                ExtendedSurvivalLogging.Instance.LogWarning(GetType(), $"GetBlocks [Error]");
                ExtendedSurvivalLogging.Instance.LogError(GetType(), ex);
            }
            return retorno;
        }

        public static void SetUpBasicAlchemyBench(MyAssemblerDefinition assemblerDefinition)
        {
            if (assemblerDefinition != null)
            {
                assemblerDefinition.BlueprintClasses.Add(MyDefinitionManager.Static.GetBlueprintClass(ItensConstants.BASICALCHEMYBENCH_CONCENTRATE_BLUEPRINTS));
                assemblerDefinition.BlueprintClasses.Add(MyDefinitionManager.Static.GetBlueprintClass(ItensConstants.BASICALCHEMYBENCH_MEDICAL_BLUEPRINTS));
                assemblerDefinition.LoadPostProcess();
            }
        }

        public static void SetUpAlchemyBench(MyAssemblerDefinition assemblerDefinition)
        {
            if (assemblerDefinition != null)
            {
                assemblerDefinition.BlueprintClasses.Add(MyDefinitionManager.Static.GetBlueprintClass(ItensConstants.ALCHEMYBENCH_CONCENTRATE_BLUEPRINTS));
                assemblerDefinition.BlueprintClasses.Add(MyDefinitionManager.Static.GetBlueprintClass(ItensConstants.ALCHEMYBENCH_MEDICAL_BLUEPRINTS));
                assemblerDefinition.LoadPostProcess();
            }
        }

        public static void SetUpSurvivalKit(MySurvivalKitDefinition survivalKitDefinition)
        {
            if (survivalKitDefinition != null)
            {                
                survivalKitDefinition.BlueprintClasses.Add(MyDefinitionManager.Static.GetBlueprintClass(ItensConstants.SURVIVALKIT_SURVIVAL_BLUEPRINTS));
                survivalKitDefinition.BlueprintClasses.Add(MyDefinitionManager.Static.GetBlueprintClass(ItensConstants.SURVIVALKIT_MEDICAL_BLUEPRINTS));
                survivalKitDefinition.LoadPostProcess();
            }
        }

        protected override void OnAfterSetComponents(MyCubeBlockDefinition blockDefinition, UniqueEntityId block)
        {
            base.OnAfterSetComponents(blockDefinition, block);
            if (blockDefinition.Id.SubtypeName != SurvivalKit && blockDefinition.Id.SubtypeName != SurvivalKitLarge)
            {
                var assemblerDefinition = (blockDefinition as MyAssemblerDefinition);
                switch (assemblerDefinition.Id.SubtypeName)
                {
                    case AlchemyBench:
                    case AlchemyBenchIndustrial:
                        SetUpAlchemyBench(assemblerDefinition);
                        break;
                    case BasicAlchemyBench:
                        SetUpBasicAlchemyBench(assemblerDefinition);
                        break;
                }
            }
            else
            {
                SetUpSurvivalKit(blockDefinition as MySurvivalKitDefinition);
            }
        }

    }

}