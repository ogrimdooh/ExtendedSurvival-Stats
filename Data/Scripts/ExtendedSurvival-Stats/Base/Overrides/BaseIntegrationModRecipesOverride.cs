﻿using Sandbox.Common.ObjectBuilders;
using Sandbox.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using VRage;
using VRage.Game;
using VRage.Game.ObjectBuilders.Definitions;
using VRage.ObjectBuilders;

namespace ExtendedSurvival.Stats
{

    public abstract class BaseIntegrationModRecipesOverride : BaseModIntegrationOverride
    {

        public enum PartLevel
        {

            Normal = 0,
            Enhanced = 1,
            Proficient = 2,
            Elite = 3

        }

        public struct ExternalModCustomIcon
        {

            public string Icon;
            public bool SamePath;
            public MyModContext CustomContext;

            public ExternalModCustomIcon(string icon, bool samePath, MyModContext context = null)
            {
                Icon = icon;
                SamePath = samePath;
                CustomContext = context;
            }

        }

        public struct ExternalModCustomModel
        {

            public string Model;
            public bool SamePath;
            public KeyValuePair<float, string>[] BuildProgressModels;

            public ExternalModCustomModel(string model, bool samePath, params KeyValuePair<float, string>[] buildProgressModels)
            {
                Model = model;
                SamePath = samePath;
                BuildProgressModels = buildProgressModels;
            }

        }

        private static readonly Dictionary<string, List<SerializableDefinitionId>> BlockVariantGroups = new Dictionary<string, List<SerializableDefinitionId>>();
        private static readonly Dictionary<string, ExternalModCustomIcon> BlockVariantGroups_CustomIcon = new Dictionary<string, ExternalModCustomIcon>();

        private static MyModContext esModTechContext = null;
        public static MyModContext GetESModTechContext()
        {
            if (esModTechContext == null)
            {
                var definition = new MyDefinitionId(typeof(MyObjectBuilder_Assembler), AssemblerOverride.AdvancedAssembler);
                var blockDefinition = DefinitionUtils.TryGetDefinition<MyCubeBlockDefinition>(definition);
                esModTechContext = blockDefinition.Context;
            }
            return esModTechContext;
        }

        protected static string GetCustomIcon(MyModContext baseContext, ExternalModCustomIcon iconInfo)
        {
            var icon = iconInfo.Icon;
            if (iconInfo.SamePath)
            {
                icon = System.IO.Path.Combine(baseContext.ModPath, icon);
            }
            else
            {
                icon = System.IO.Path.Combine(GetESModTechContext().ModPath, icon);
            }
            return icon;
        }

        public static void ApplyAllBlockVariantGroups()
        {
            foreach (var key in BlockVariantGroups.Keys)
            {
                try
                {
                    var group = DefinitionUtils.GetBlockVariantGroup(key);
                    if (group != null)
                    {
                        var builder = group.GetObjectBuilder() as MyObjectBuilder_BlockVariantGroup;
                        builder.Blocks = BlockVariantGroups[key].Distinct().ToArray();
                        if (BlockVariantGroups_CustomIcon.ContainsKey(key))
                        {
                            var icon = BlockVariantGroups_CustomIcon[key].Icon;
                            if (BlockVariantGroups_CustomIcon[key].SamePath)
                            {
                                icon = System.IO.Path.Combine(group.Context.ModPath, icon);
                            }
                            else
                            {
                                icon = System.IO.Path.Combine(BlockVariantGroups_CustomIcon[key].CustomContext != null ? BlockVariantGroups_CustomIcon[key].CustomContext.ModPath : GetESModTechContext().ModPath, icon);
                            }
                            builder.Icons = new string[] { icon };
                        }
                        group.Init(builder, group.Context);
                        group.ResolveBlocks();
                        group.Postprocess();
                    }
                    else
                    {
                        ExtendedSurvivalStatsLogging.Instance.LogInfo(typeof(BaseIntegrationModRecipesOverride), $"Override BlockVariantGroup not found. ID=[{key}]");
                    }
                }
                catch (Exception ex)
                {
                    ExtendedSurvivalStatsLogging.Instance.LogWarning(typeof(BaseIntegrationModRecipesOverride), $"Override BlockVariantGroup error. ID=[{key}]");
                    ExtendedSurvivalStatsLogging.Instance.LogError(typeof(BaseIntegrationModRecipesOverride), ex);
                }
            }
        }

        public struct ComponentCost
        {

            public string subtype;
            public int count;
            public bool critical;
            public string deconstructId;

            public ComponentCost(string subtype, int count, bool critical = false, string deconstructId = null)
            {
                this.subtype = subtype;
                this.count = count;
                this.critical = critical;
                this.deconstructId = deconstructId;
            }

        }

        public class ComponentInfo
        {

            public int integrity;
            public string bluePrintName;
            public Dictionary<UniqueEntityId, float> bluePrintCost = new Dictionary<UniqueEntityId, float>();
            public List<string> targetBlueprintClasses = new List<string>();

            public ComponentInfo(int integrity, string bluePrintName)
            {
                this.integrity = integrity;
                this.bluePrintName = bluePrintName;
            }

        }

        protected static int GetCostMultiplier(float value, float multiplier)
        {
            return Math.Max((int)(value * multiplier), 1);
        }

        protected virtual List<string> GetComponents() { return new List<string>(); }
        protected virtual ComponentInfo GetComponentInfo(string item) { return null; }

        protected abstract List<UniqueEntityId> GetBlocks();
        protected abstract List<ComponentCost> GetBlockCost(UniqueEntityId item);

        protected override void OnSetDefinitions()
        {
            foreach (var block in GetBlocks())
            {
                var blockDefinition = MyDefinitionManager.Static.GetCubeBlockDefinition(block.DefinitionId);
                if (blockDefinition != null)
                    SetComponents(blockDefinition, block);
                else
                    ExtendedSurvivalStatsLogging.Instance.LogWarning(GetType(), $"Override block not found. ID=[{block}]");
            }
            foreach (var component in GetComponents())
            {
                var compInfo = GetComponentInfo(component);
                if (compInfo != null)
                {
                    var compBuilder = new MyObjectBuilder_Component { SubtypeName = component };
                    var compDef = MyDefinitionManager.Static.GetComponentDefinition(compBuilder.GetObjectId());
                    if (compDef != null)
                        SetComponentInfo(compDef, compInfo, component);
                    else
                        ExtendedSurvivalStatsLogging.Instance.LogWarning(GetType(), $"Override component not found. ID=[{component}]");
                }
                else
                    ExtendedSurvivalStatsLogging.Instance.LogWarning(GetType(), $"Override component no info found. ID=[{component}]");
            }
        }

        protected void SetBlockVariantGroupIcon(string name, string icon, bool samePath = true, MyModContext customContext = null)
        {
            if (BlockVariantGroups_CustomIcon.ContainsKey(name))
                BlockVariantGroups_CustomIcon[name] = new ExternalModCustomIcon(icon, samePath, customContext);
            else
                BlockVariantGroups_CustomIcon.Add(name, new ExternalModCustomIcon(icon, samePath, customContext));
        }

        protected void RemoveBlockVariantGroup(string name, params MyDefinitionId[] ids)
        {
            var lista = ids.Select(x => new SerializableDefinitionId(x.TypeId, x.SubtypeName)).ToList();
            if (BlockVariantGroups.ContainsKey(name))
                BlockVariantGroups[name].RemoveAll(x => lista.Contains(x));
        }

        protected void AppendBlockVariantGroup(string name, params MyDefinitionId[] ids)
        {
            if (BlockVariantGroups.ContainsKey(name))
                BlockVariantGroups[name].AddRange(ids.Select(x => new SerializableDefinitionId(x.TypeId, x.SubtypeName)));
            else
                RebuildBlockVariantGroup(name, ids);
        }

        protected void RebuildBlockVariantGroup(string name, params MyDefinitionId[] ids)
        {
            if (BlockVariantGroups.ContainsKey(name))
                BlockVariantGroups.Remove(name);
            var lista = ids.Select(x => new SerializableDefinitionId(x.TypeId, x.SubtypeName)).ToList();
            BlockVariantGroups.Add(name, lista);
        }

        protected void RemoveBlockVariantGroup(string name)
        {
            var group = DefinitionUtils.GetBlockVariantGroup(name);
            if (group != null)
                group.Enabled = false;
        }

        private void SetComponentInfo(MyComponentDefinition compDef, ComponentInfo compInfo, string component)
        {
            compDef.MaxIntegrity = compInfo.integrity;
            var definitionID = new MyDefinitionId(typeof(MyObjectBuilder_BlueprintDefinition), compInfo.bluePrintName);
            var blueprint = MyDefinitionManager.Static.GetBlueprintDefinition(definitionID);
            if (blueprint != null)
            {
                var newBlueprint = new List<MyBlueprintDefinitionBase.Item>();
                foreach (var item in compInfo.bluePrintCost)
                {
                    var newItem = new MyBlueprintDefinitionBase.Item
                    {
                        Amount = (MyFixedPoint)item.Value,
                        Id = item.Key.DefinitionId
                    };
                    newBlueprint.Add(newItem);
                }
                blueprint.Prerequisites = newBlueprint.ToArray();
                foreach (var targetBlueprintClass in compInfo.targetBlueprintClasses)
                {
                    AddBluePrintToClass(targetBlueprintClass, compInfo.bluePrintName);
                }
            }
            else
                ExtendedSurvivalStatsLogging.Instance.LogWarning(GetType(), $"Override component no blueprint found. ID=[{component}] BP=[{compInfo.bluePrintName}]");
        }

        protected virtual void OnAfterSetComponents(MyCubeBlockDefinition blockDefinition, UniqueEntityId block)
        {

        }

        protected MyComponentDefinition GetComponentDefinition(string subtype)
        {
            if (string.IsNullOrEmpty(subtype))
                return null;
            var compBuilder = new MyObjectBuilder_Component { SubtypeName = subtype };
            return MyDefinitionManager.Static.GetComponentDefinition(compBuilder.GetObjectId());
        }

        private PartLevel GetMaxPartLevel(List<ComponentCost> components)
        {
            if (components.Any(x => x.subtype.Contains("Elite")))
                return PartLevel.Elite;
            if (components.Any(x => x.subtype.Contains("Proficient")))
                return PartLevel.Proficient;
            if (components.Any(x => x.subtype.Contains("Enhanced")))
                return PartLevel.Enhanced;
            return PartLevel.Normal;
        }

        private bool HasComputer(List<ComponentCost> components)
        {
            return components.Any(x => x.subtype.Contains("Computer"));
        }

        private bool HasMotor(List<ComponentCost> components)
        {
            return components.Any(x => x.subtype.Contains("Motor"));
        }

        private bool HasPowerCell(List<ComponentCost> components)
        {
            return components.Any(x => x.subtype.Contains("PowerCell"));
        }

        private bool HasSuperCapacitor(List<ComponentCost> components)
        {
            return components.Any(x => x.subtype.Contains("SuperCapacitor"));
        }

        private bool HasReactor(List<ComponentCost> components)
        {
            return components.Any(x => x.subtype.Contains("Reactor"));
        }

        private bool HasHighPressureCompressor(List<ComponentCost> components)
        {
            return components.Any(x => x.subtype.Contains("HighPressureCompressor"));
        }

        private bool HasGravityGenerator(List<ComponentCost> components)
        {
            return components.Any(x => x.subtype.Contains("GravityGenerator"));
        }

        private bool HasPlasmaGenerator(List<ComponentCost> components)
        {
            return components.Any(x => x.subtype.Contains("PlasmaGenerator"));
        }

        private const float INTEGRITY_PERSEC_BASE = 750f;
        private const float MIN_TIME_BUILD = 7.5f;

        private void SetComponents(MyCubeBlockDefinition blockDefinition, UniqueEntityId block)
        {
            var newCompsList = GetBlockCost(block);
            if (newCompsList.Count > 0)
            {
                var integrityPerSec = INTEGRITY_PERSEC_BASE;
                var mass = 0f;
                var maxIntegrity = 0;
                var criticalRatio = 0f;
                var ownershipRatio = 0f;
                var newComps = new List<MyCubeBlockDefinition.Component>();
                foreach (var item in newCompsList)
                {
                    var compDef = GetComponentDefinition(item.subtype);
                    if (compDef != null)
                    {
                        var deconstructDef = GetComponentDefinition(item.deconstructId);
                        var newComp = new MyCubeBlockDefinition.Component
                        {
                            Definition = compDef,
                            Count = item.count,
                            DeconstructItem = deconstructDef != null ? deconstructDef : compDef
                        };
                        newComps.Add(newComp);
                        mass += newComp.Definition.Mass * newComp.Count;
                        maxIntegrity += newComp.Definition.MaxIntegrity * newComp.Count;
                        ownershipRatio = item.subtype.Equals("Computer") ? maxIntegrity : ownershipRatio;
                        criticalRatio = item.critical ? maxIntegrity : criticalRatio;
                    }
                }
                blockDefinition.Mass = mass;
                blockDefinition.MaxIntegrity = maxIntegrity;
                blockDefinition.Components = newComps.ToArray();
                blockDefinition.CriticalIntegrityRatio = criticalRatio / maxIntegrity;
                blockDefinition.OwnershipIntegrityRatio = ownershipRatio / maxIntegrity;
                if (blockDefinition.BuildProgressModels != null)
                {
                    var basePercent = 1f / blockDefinition.BuildProgressModels.Length;
                    var i = 1;
                    foreach (var progressModel in blockDefinition.BuildProgressModels)
                    {
                        progressModel.BuildRatioUpperBound = blockDefinition.CriticalIntegrityRatio > 0 ? (basePercent * i) * blockDefinition.CriticalIntegrityRatio : basePercent * i;
                        i++;
                    }
                }
                if (HasComputer(newCompsList))
                    integrityPerSec *= 0.95f;
                if (HasMotor(newCompsList))
                    integrityPerSec *= 0.95f;
                if (HasPowerCell(newCompsList))
                    integrityPerSec *= 0.95f;
                if (HasSuperCapacitor(newCompsList))
                    integrityPerSec *= 0.95f;
                if (HasReactor(newCompsList))
                    integrityPerSec *= 0.95f;
                if (HasHighPressureCompressor(newCompsList))
                    integrityPerSec *= 0.95f;
                if (HasGravityGenerator(newCompsList))
                    integrityPerSec *= 0.95f;
                if (HasPlasmaGenerator(newCompsList))
                    integrityPerSec *= 0.95f;
                switch (GetMaxPartLevel(newCompsList))
                {
                    case PartLevel.Enhanced:
                        integrityPerSec *= 0.8f;
                        break;
                    case PartLevel.Proficient:
                        integrityPerSec *= 0.6f;
                        break;
                    case PartLevel.Elite:
                        integrityPerSec *= 0.4f;
                        break;
                }
                if (integrityPerSec > (maxIntegrity / MIN_TIME_BUILD))
                {
                    integrityPerSec = maxIntegrity / MIN_TIME_BUILD;
                }
                blockDefinition.IntegrityPointsPerSec = integrityPerSec;
                blockDefinition.Postprocess();
            }
            else
                ExtendedSurvivalStatsLogging.Instance.LogWarning(GetType(), $"Override block no components to set. ID=[{block}]");
            OnAfterSetComponents(blockDefinition, block);
        }

        protected void SetBlueprintDisplayInfo(string name, ExternalModCustomIcon? icon, string displayName = null, string description = null)
        {
            var fromId = new MyDefinitionId(typeof(MyObjectBuilder_BlueprintDefinition), name);
            var fromBp = MyDefinitionManager.Static.GetBlueprintDefinition(fromId);
            if (fromBp != null)
            {
                if (!string.IsNullOrWhiteSpace(displayName))
                {
                    fromBp.DisplayNameEnum = null;
                    fromBp.DisplayNameString = displayName;
                }
                if (!string.IsNullOrWhiteSpace(description))
                {
                    fromBp.DescriptionEnum = null;
                    fromBp.DescriptionString = description;
                }
                if (icon.HasValue)
                {
                    fromBp.Icons = new string[] { GetCustomIcon(fromBp.Context, icon.Value) };
                }
                fromBp.Postprocess();
            }
            else
                ExtendedSurvivalStatsLogging.Instance.LogWarning(GetType(), $"Override not found {name} blue print.");
        }

    }

}