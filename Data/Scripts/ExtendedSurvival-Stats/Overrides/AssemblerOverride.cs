using Sandbox.Common.ObjectBuilders;
using Sandbox.Definitions;
using System;
using System.Collections.Generic;
using VRage.Game;

namespace ExtendedSurvival.Stats
{

    public sealed class AssemblerOverride : BaseIntegrationModRecipesOverride
    {

        public static void TryOverride()
        {
            new AssemblerOverride().SetDefinitions();
        }

        public const string SurvivalKitLarge = "SurvivalKitLarge";
        public const string SurvivalKit = "SurvivalKit";

        public const string BasicAssembler = "BasicAssembler";
        public const string LargeAssembler = "LargeAssembler";
        public const string LargeAssemblerIndustrial = "LargeAssemblerIndustrial";
        public const string AdvancedAssembler = "AdvancedAssembler";
        public const string AdvancedAssemblerIndustrial = "AdvancedAssemblerIndustrial";

        public const string BasicGrinder = "BasicGrinder";
        public const string Grinder = "Grinder";
        public const string GrinderIndustrial = "GrinderIndustrial";

        public const string BasicAlchemyBench = "BasicAlchemyBench";
        public const string AlchemyBench = "AlchemyBench";
        public const string AlchemyBenchIndustrial = "AlchemyBenchIndustrial";

        public const string Fertilizer_Construction = "Fertilizer_Construction";
        public const string PotassiumFertilizer_Construction = "PotassiumFertilizer_Construction";

        public const string AluminumCan_Vanila_Construction = "AluminumCan_Vanila_Construction";
        public const string AluminumCan_Construction = "AluminumCan_Vanila_Construction";

        public const string SmallAluminumCanister_Construction = "SmallAluminumCanister_Construction";
        public const string SmallAluminumCanister_Vanila_Construction = "SmallAluminumCanister_Vanila_Construction";

        public const string ThermalFluid_Construction = "ThermalFluid_Construction";
        public const string ThermalFluid_Vanila_Construction = "ThermalFluid_Vanila_Construction";

        public const string BasicFoodProcessor = "BasicFoodProcessor";
        public const string FoodProcessor = "FoodProcessor";
        public const string FoodProcessorIndustrial = "FoodProcessorIndustrial";

        public const string BasicSlaughterhouse = "BasicSlaughterhouse";
        public const string Slaughterhouse = "Slaughterhouse";
        public const string SlaughterhouseIndustrial = "SlaughterhouseIndustrial";

        protected override ulong[] GetModId()
        {
            return new ulong[] { };
        }

        protected override List<ComponentCost> GetBlockCost(UniqueEntityId item)
        {
            return new List<ComponentCost>();
        }

        protected override bool IgnoreBlockCost(UniqueEntityId item)
        {
            return true;
        }

        protected override List<UniqueEntityId> GetBlocks()
        {
            var retorno = new List<UniqueEntityId>();
            try
            {
                retorno.Add(new UniqueEntityId(typeof(MyObjectBuilder_Assembler), BasicGrinder));
                retorno.Add(new UniqueEntityId(typeof(MyObjectBuilder_Assembler), Grinder));
                retorno.Add(new UniqueEntityId(typeof(MyObjectBuilder_Assembler), GrinderIndustrial));
                retorno.Add(new UniqueEntityId(typeof(MyObjectBuilder_SurvivalKit), SurvivalKit));
                retorno.Add(new UniqueEntityId(typeof(MyObjectBuilder_SurvivalKit), SurvivalKitLarge));
                retorno.Add(new UniqueEntityId(typeof(MyObjectBuilder_Assembler), BasicAlchemyBench));
                retorno.Add(new UniqueEntityId(typeof(MyObjectBuilder_Assembler), AlchemyBench));
                retorno.Add(new UniqueEntityId(typeof(MyObjectBuilder_Assembler), AlchemyBenchIndustrial));
                retorno.Add(new UniqueEntityId(typeof(MyObjectBuilder_Assembler), BasicFoodProcessor));
                retorno.Add(new UniqueEntityId(typeof(MyObjectBuilder_Assembler), FoodProcessor));
                retorno.Add(new UniqueEntityId(typeof(MyObjectBuilder_Assembler), FoodProcessorIndustrial));
                retorno.Add(new UniqueEntityId(typeof(MyObjectBuilder_Assembler), BasicSlaughterhouse));
                retorno.Add(new UniqueEntityId(typeof(MyObjectBuilder_Assembler), Slaughterhouse));
                retorno.Add(new UniqueEntityId(typeof(MyObjectBuilder_Assembler), SlaughterhouseIndustrial));
                retorno.Add(new UniqueEntityId(typeof(MyObjectBuilder_Assembler), BasicAssembler));
                retorno.Add(new UniqueEntityId(typeof(MyObjectBuilder_Assembler), LargeAssembler));
                retorno.Add(new UniqueEntityId(typeof(MyObjectBuilder_Assembler), LargeAssemblerIndustrial));
                if (ExtendedSurvivalStatsSession.IsUsingTechnology())
                {
                    retorno.Add(new UniqueEntityId(typeof(MyObjectBuilder_Assembler), AdvancedAssembler));
                    retorno.Add(new UniqueEntityId(typeof(MyObjectBuilder_Assembler), AdvancedAssemblerIndustrial));
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogWarning(GetType(), $"GetBlocks [Error]");
                ExtendedSurvivalStatsLogging.Instance.LogError(GetType(), ex);
            }
            return retorno;
        }

        public static void SetUpBasicAlchemyBench(MyAssemblerDefinition assemblerDefinition)
        {
            if (assemblerDefinition != null)
            {
                assemblerDefinition.BlueprintClasses.Add(MyDefinitionManager.Static.GetBlueprintClass(ItensConstants.BASICALCHEMYBENCH_FERTILIZER_BLUEPRINTS));
                assemblerDefinition.BlueprintClasses.Add(MyDefinitionManager.Static.GetBlueprintClass(ItensConstants.BASICALCHEMYBENCH_CONCENTRATE_BLUEPRINTS));
                assemblerDefinition.BlueprintClasses.Add(MyDefinitionManager.Static.GetBlueprintClass(ItensConstants.BASICALCHEMYBENCH_MEDICAL_BLUEPRINTS));
            }
        }

        public static void SetUpAlchemyBench(MyAssemblerDefinition assemblerDefinition)
        {
            if (assemblerDefinition != null)
            {
                assemblerDefinition.BlueprintClasses.Add(MyDefinitionManager.Static.GetBlueprintClass(ItensConstants.ALCHEMYBENCH_FERTILIZER_BLUEPRINTS));
                assemblerDefinition.BlueprintClasses.Add(MyDefinitionManager.Static.GetBlueprintClass(ItensConstants.ALCHEMYBENCH_CONCENTRATE_BLUEPRINTS));
                assemblerDefinition.BlueprintClasses.Add(MyDefinitionManager.Static.GetBlueprintClass(ItensConstants.ALCHEMYBENCH_MEDICAL_BLUEPRINTS));
            }
        }

        public static void SetUpSurvivalKit(MySurvivalKitDefinition survivalKitDefinition)
        {
            if (survivalKitDefinition != null)
            {
                var refineClass = MyDefinitionManager.Static.GetBlueprintClass(ItensConstants.SURVIVALKIT_REFINE_BLUEPRINTS);
                if (!survivalKitDefinition.BlueprintClasses.Contains(refineClass))
                    survivalKitDefinition.BlueprintClasses.Add(refineClass);
                var bottlesClass = MyDefinitionManager.Static.GetBlueprintClass(ItensConstants.SURVIVALKIT_BOTTLES_BLUEPRINTS);
                if (!survivalKitDefinition.BlueprintClasses.Contains(bottlesClass))
                    survivalKitDefinition.BlueprintClasses.Add(bottlesClass);
                var alchemyClass = MyDefinitionManager.Static.GetBlueprintClass(ItensConstants.SURVIVALKIT_ALCHEMY_BLUEPRINTS);
                if (!survivalKitDefinition.BlueprintClasses.Contains(alchemyClass))
                    survivalKitDefinition.BlueprintClasses.Add(alchemyClass);
                survivalKitDefinition.BlueprintClasses.Add(MyDefinitionManager.Static.GetBlueprintClass(ItensConstants.SURVIVALKIT_SURVIVAL_BLUEPRINTS));
                survivalKitDefinition.BlueprintClasses.Add(MyDefinitionManager.Static.GetBlueprintClass(ItensConstants.SURVIVALKIT_MEDICAL_BLUEPRINTS));
                survivalKitDefinition.BlueprintClasses.Add(MyDefinitionManager.Static.GetBlueprintClass(ItensConstants.SURVIVALKIT_ARMORS_VANILLA_BLUEPRINTS));
                survivalKitDefinition.LoadPostProcess();
            }
        }

        public static void SetUpBasicAssembler(MyAssemblerDefinition assemblerDefinition)
        {
            if (assemblerDefinition != null)
            {
                var bottlesClass = MyDefinitionManager.Static.GetBlueprintClass(ItensConstants.BASICASSEMBLER_BOTTLES_BLUEPRINTS);
                if (!assemblerDefinition.BlueprintClasses.Contains(bottlesClass))
                    assemblerDefinition.BlueprintClasses.Add(bottlesClass);
                assemblerDefinition.BlueprintClasses.Add(MyDefinitionManager.Static.GetBlueprintClass(ItensConstants.BASICASSEMBLER_ARMORS_VANILLA_BLUEPRINTS));
            }
        }

        public static void SetUpAssembler(MyAssemblerDefinition assemblerDefinition)
        {
            if (assemblerDefinition != null)
            {
                var bottlesClass = MyDefinitionManager.Static.GetBlueprintClass(ItensConstants.ASSEMBLER_BOTTLES_BLUEPRINTS);
                if (!assemblerDefinition.BlueprintClasses.Contains(bottlesClass))
                    assemblerDefinition.BlueprintClasses.Add(bottlesClass);
                assemblerDefinition.BlueprintClasses.Add(MyDefinitionManager.Static.GetBlueprintClass(ItensConstants.ASSEMBLER_ARMORS_VANILLA_BLUEPRINTS));
            }
        }

        protected override void OnAfterSetDefinitions()
        {
            base.OnAfterSetDefinitions();
            if (DefinitionUtils.TryGetDefinition<MyPhysicalItemDefinition>("Sulfur") != null)
            {
                AddBluePrintToClass(ItensConstants.ALCHEMYBENCH_FERTILIZER_BLUEPRINTS, Fertilizer_Construction);
            }
            if (DefinitionUtils.TryGetDefinition<MyPhysicalItemDefinition>("Potassium") != null)
            {
                AddBluePrintToClass(ItensConstants.ALCHEMYBENCH_FERTILIZER_BLUEPRINTS, PotassiumFertilizer_Construction);
            }
            if (DefinitionUtils.TryGetDefinition<MyPhysicalItemDefinition>("Aluminum") != null)
            {
                AddBluePrintToClass(ItensConstants.SURVIVALKIT_BOTTLES_BLUEPRINTS, SmallAluminumCanister_Construction);
                AddBluePrintToClass(ItensConstants.ASSEMBLER_BOTTLES_BLUEPRINTS, AluminumCan_Construction, SmallAluminumCanister_Construction);
                AddBluePrintToClass(ItensConstants.BASICASSEMBLER_BOTTLES_BLUEPRINTS, AluminumCan_Construction, SmallAluminumCanister_Construction);
                AddBluePrintToClass(ItensConstants.ALCHEMYBENCH_LIQUIDALCHEMY_BLUEPRINTS, ThermalFluid_Construction);
                AddBluePrintToClass(ItensConstants.BASICALCHEMYBENCH_LIQUIDALCHEMY_BLUEPRINTS, ThermalFluid_Construction);
                AddBluePrintToClass(ItensConstants.SMALLBASICALCHEMYBENCH_LIQUIDALCHEMY_BLUEPRINTS, ThermalFluid_Construction);
            }
            else
            {
                AddBluePrintToClass(ItensConstants.SURVIVALKIT_BOTTLES_BLUEPRINTS, SmallAluminumCanister_Vanila_Construction);
                AddBluePrintToClass(ItensConstants.ASSEMBLER_BOTTLES_BLUEPRINTS, AluminumCan_Vanila_Construction, SmallAluminumCanister_Vanila_Construction);
                AddBluePrintToClass(ItensConstants.BASICASSEMBLER_BOTTLES_BLUEPRINTS, AluminumCan_Vanila_Construction, SmallAluminumCanister_Vanila_Construction);
                AddBluePrintToClass(ItensConstants.ALCHEMYBENCH_LIQUIDALCHEMY_BLUEPRINTS, ThermalFluid_Vanila_Construction);
                AddBluePrintToClass(ItensConstants.BASICALCHEMYBENCH_LIQUIDALCHEMY_BLUEPRINTS, ThermalFluid_Vanila_Construction);
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
                    case LargeAssembler:
                    case LargeAssemblerIndustrial:
                        if (!ExtendedSurvivalStatsSession.IsUsingTechnology())
                        {
                            SetUpAssembler(assemblerDefinition);
                        }
                        break;
                    case BasicAssembler:
                        if (!ExtendedSurvivalStatsSession.IsUsingTechnology())
                        {
                            SetUpBasicAssembler(assemblerDefinition);
                        }
                        break;
                }
                assemblerDefinition.LoadPostProcess();
            }
            else
            {
                if (!ExtendedSurvivalStatsSession.IsUsingTechnology())
                {
                    SetUpSurvivalKit(blockDefinition as MySurvivalKitDefinition);
                }
            }
        }

    }

}