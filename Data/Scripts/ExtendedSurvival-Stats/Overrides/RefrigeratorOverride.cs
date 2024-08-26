using Sandbox.Common.ObjectBuilders;
using Sandbox.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using VRage.Game;

namespace ExtendedSurvival.Stats
{
    public sealed class RefrigeratorOverride : BaseIntegrationModRecipesOverride
    {

        public const string MA_O2 = "MA_O2";

        private static MyModContext upH2O2GeneratorContext = null;
        public static MyModContext GetUpH2O2GeneratorContext()
        {
            if (upH2O2GeneratorContext == null)
            {
                var definition = new MyDefinitionId(typeof(MyObjectBuilder_OxygenGenerator), MA_O2);
                var blockDefinition = DefinitionUtils.TryGetDefinition<MyCubeBlockDefinition>(definition);
                upH2O2GeneratorContext = blockDefinition.Context;
            }
            return upH2O2GeneratorContext;
        }

        public static void TryOverride()
        {
            new RefrigeratorOverride().SetDefinitions();
        }

        public const string LargeBlockLargeRefrigerator = "LargeBlockLargeRefrigerator";

        protected override ulong[] GetModId()
        {
            return new ulong[] { 2118214855 }; /* Upgradable O2/H2 Generator */
        }

        private static readonly ExternalModCustomModel ExtraLargeRefrigerator = new ExternalModCustomModel(
            "Models\\MA_O2\\MA_O2.mwm",
            false,
            new KeyValuePair<float, string>(0.33f, "Models\\MA_O2\\MA_O2_Constr1.mwm"),
            new KeyValuePair<float, string>(0.66f, "Models\\MA_O2\\MA_O2_Constr2.mwm"),
            new KeyValuePair<float, string>(1.00f, "Models\\MA_O2\\MA_O2_Constr3.mwm")
        );

        private static readonly Dictionary<string, ExternalModCustomModel> Blocks_CustomModel = new Dictionary<string, ExternalModCustomModel>()
        {
            { LargeBlockLargeRefrigerator, ExtraLargeRefrigerator }
        };

        protected override List<ComponentCost> GetBlockCost(UniqueEntityId item)
        {
            return new List<ComponentCost>();
        }

        protected override List<UniqueEntityId> GetBlocks()
        {
            var retorno = new List<UniqueEntityId>();
            try
            {
                retorno.Add(new UniqueEntityId(typeof(MyObjectBuilder_OxygenGenerator), LargeBlockLargeRefrigerator));
            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogWarning(GetType(), $"GetBlocks [Error]");
                ExtendedSurvivalStatsLogging.Instance.LogError(GetType(), ex);
            }
            return retorno;
        }

        protected override void OnAfterSetComponents(MyCubeBlockDefinition blockDefinition, UniqueEntityId block)
        {
            base.OnAfterSetComponents(blockDefinition, block);
            var key = blockDefinition.Id.SubtypeId.String;
            if (Blocks_CustomModel.ContainsKey(key))
            {
                var def = (blockDefinition as MyOxygenGeneratorDefinition);
                var rootPath = GetUpH2O2GeneratorContext().ModPath;
                def.Model = System.IO.Path.Combine(rootPath, Blocks_CustomModel[key].Model);
                if (Blocks_CustomModel[key].BuildProgressModels != null && Blocks_CustomModel[key].BuildProgressModels.Any())
                {
                    def.BuildProgressModels = Blocks_CustomModel[key].BuildProgressModels
                        .Select(x => new MyCubeBlockDefinition.BuildProgressModel()
                        {
                            BuildRatioUpperBound = x.Key,
                            File = System.IO.Path.Combine(rootPath, x.Value)
                        }).ToArray();
                }
                def.LoadPostProcess();
            }
        }

        protected override void OnNotSetDefinitions()
        {
            base.OnNotSetDefinitions();
            var blockDefinition = MyDefinitionManager.Static.GetCubeBlockDefinition(new UniqueEntityId(typeof(MyObjectBuilder_OxygenGenerator), LargeBlockLargeRefrigerator).DefinitionId);
            if (blockDefinition != null)
            {
                blockDefinition.Public = false;
                blockDefinition.Postprocess();
            }
        }

    }

}