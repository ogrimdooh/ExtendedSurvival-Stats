using Sandbox.Common.ObjectBuilders;
using Sandbox.Definitions;
using Sandbox.ModAPI;
using System.Linq;
using System.Text;
using VRage.Game;

namespace ExtendedSurvival.Stats
{
    public abstract class BaseModIntegrationOverride : BaseIntegrationOverride
    {

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

        private static MyModContext esModTechContext = null;
        public static MyModContext GetESModTechContext()
        {
            if (esModTechContext == null)
            {
                var definition = new MyDefinitionId(typeof(MyObjectBuilder_Assembler), AssemblerOverride.FoodProcessor);
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

        protected abstract ulong[] GetModId();
        protected abstract void OnSetDefinitions();

        protected virtual void OnNotSetDefinitions()
        {

        }

        protected virtual bool IsCustomCheckOk()
        {
            return false;
        }

        public override void SetDefinitions()
        {
            var ids = GetModId();
            if (ids.Length == 0 || MyAPIGateway.Session.Mods.Any(x => ids.Contains(x.PublishedFileId)) || IsCustomCheckOk())
            {
                OnBeforeSetDefinitions();
                OnSetDefinitions();
                OnAfterSetDefinitions();
            }
            else
            {
                ExtendedSurvivalStatsLogging.Instance.LogInfo(GetType(), $"Override mod not found. ID=[{GetIds(ids)}]");
                OnNotSetDefinitions();
            }
        }

        private string GetIds(ulong[] ids)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in ids)
            {
                if (sb.Length > 0)
                    sb.Append(", ");
                sb.Append(item.ToString());
            }
            return sb.ToString();
        }

        protected virtual void OnBeforeSetDefinitions()
        {

        }

        protected virtual void OnAfterSetDefinitions()
        {

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

        protected void SetPhysicalitemDisplayInfo(MyDefinitionId id, ExternalModCustomIcon? icon, string displayName = null, string description = null)
        {
            var fromBp = MyDefinitionManager.Static.GetPhysicalItemDefinition(id);
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
                ExtendedSurvivalStatsLogging.Instance.LogWarning(GetType(), $"Override not found {id}.");
        }

    }

}