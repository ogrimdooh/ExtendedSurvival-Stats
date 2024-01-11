﻿using Sandbox.Definitions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRage.Game;

namespace ExtendedSurvival.Stats
{

    public static class HelpController
    {

        public enum ConfigurationValueType
        {

            None = 0,
            String = 1,
            Bool = 2,
            Integer = 3,
            Decimal = 4,
            Vector2 = 5,
            Vector3 = 6,
            Vector4 = 7

        }

        public class ConfigurationEntryHelpInfo
        {

            public UniqueNameId EntryId { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string TextureIcon { get; set; }
            public string DefaultValue { get; set; }
            public bool CanUseSettingsCommand { get; set; }
            public bool NeedRestart { get; set; }
            public ConfigurationValueType ValueType { get; set; } = ConfigurationValueType.None;
            public string CommandSample { get; set; }
            public ConfigurationEntryHelpInfo[] Entries { get; set; } = new ConfigurationEntryHelpInfo[] { };

        }

        public class CommandExtraPage
        {

            public string Description { get; set; }
            public string TextureIcon { get; set; }

        }

        public class CommandEntryHelpInfo
        {

            public UniqueNameId EntryId { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string TextureIcon { get; set; }
            public bool IsGroup { get; set; }
            public string Syntax { get; set; }
            public string CommandSample { get; set; }
            public bool ShowApplyLevel { get; set; }
            public bool NeedRestart { get; set; }
            public CommandEntryHelpInfo[] SubCommands { get; set; } = new CommandEntryHelpInfo[] { };
            public CommandExtraPage[] ExtraPage { get; set; } = new CommandExtraPage[] { };
            public Action<StringBuilder, int> OnAfterBuildPage { get; set; }

        }

        public const string BASE_TOPIC_TYPE = "ExtendedSurvival.Stats";

        public const string HELP_SYSTEM_TOPIC_SUBTYPE = "System";
        public const string HELP_CONFIGURATION_TOPIC_SUBTYPE = "Configuration";
        public const string HELP_COMMANDS_TOPIC_SUBTYPE = "Command";

        private static UniqueNameId _HelpSystemTopicId;
        public static UniqueNameId HelpSystemTopicId
        {
            get
            {
                if (_HelpSystemTopicId == null)
                    _HelpSystemTopicId = new UniqueNameId(BASE_TOPIC_TYPE, HELP_SYSTEM_TOPIC_SUBTYPE);
                return _HelpSystemTopicId;
            }
        }

        private static UniqueNameId _HelpConfigurationTopicId;
        public static UniqueNameId HelpConfigurationTopicId
        {
            get
            {
                if (_HelpConfigurationTopicId == null)
                    _HelpConfigurationTopicId = new UniqueNameId(BASE_TOPIC_TYPE, HELP_CONFIGURATION_TOPIC_SUBTYPE);
                return _HelpConfigurationTopicId;
            }
        }

        private static UniqueNameId _HelpCommandTopicId;
        public static UniqueNameId HelpCommandTopicId
        {
            get
            {
                if (_HelpCommandTopicId == null)
                    _HelpCommandTopicId = new UniqueNameId(BASE_TOPIC_TYPE, HELP_COMMANDS_TOPIC_SUBTYPE);
                return _HelpCommandTopicId;
            }
        }

        public class HelpTopic
        {

            public UniqueNameId NameId { get; set; }
            public Guid Id
            {
                get
                {
                    return NameId.GetUniqueId().Id;
                }
            }

            public string Title { get; set; }

            public ConcurrentDictionary<Guid, HelpEntry> Entries { get; set; } = new ConcurrentDictionary<Guid, HelpEntry>();

        }

        public class HelpEntry
        {

            public UniqueNameId NameId { get; set; }
            public Guid Id
            {
                get
                {
                    return NameId.GetUniqueId().Id;
                }
            }

            public int Order { get; set; }
            public int Indentation { get; set; } 
            public string Title { get; set; }
            public ConcurrentDictionary<int, HelpPage> Pages { get; set; } = new ConcurrentDictionary<int, HelpPage>();

        }

        public class HelpPage
        {

            public int Order { get; set; }
            public string Text { get; set; }
            public string Texture { get; set; }

        }

        private static readonly ConcurrentDictionary<Guid, HelpTopic> HELP_TOPICS = new ConcurrentDictionary<Guid, HelpTopic>();
        private static readonly ConcurrentBag<Action> LOAD_ACTIONS = new ConcurrentBag<Action>();
        private static bool Loaded = false;

        public static void AddLoadAction(Action action)
        {
            LOAD_ACTIONS.Add(action);
        }

        public static void AddTopic(UniqueNameId id, string title)
        {
            if (!HELP_TOPICS.ContainsKey(id.UniqueId.Id))
                HELP_TOPICS[id.UniqueId.Id] = new HelpTopic()
                {
                    NameId = id,
                    Title = title
                };
        }

        public static void AddEntry(UniqueNameId topicId, UniqueNameId id, string title, int indentation)
        {
            if (HELP_TOPICS.ContainsKey(topicId.UniqueId.Id))
            {
                if (!HELP_TOPICS[topicId.UniqueId.Id].Entries.ContainsKey(id.UniqueId.Id))
                {
                    var order = HELP_TOPICS[topicId.UniqueId.Id].Entries.Any() ? HELP_TOPICS[topicId.UniqueId.Id].Entries.Max(x => x.Value.Order) + 1 : 0;
                    HELP_TOPICS[topicId.UniqueId.Id].Entries[id.UniqueId.Id] = new HelpEntry()
                    {
                        NameId = id,
                        Title = title,
                        Indentation = indentation,
                        Order = order
                    };
                }
            }
        }

        public static void AddPage(UniqueNameId topicId, UniqueNameId entryId, string text, string texture = null)
        {
            if (HELP_TOPICS.ContainsKey(topicId.UniqueId.Id))
            {
                if (HELP_TOPICS[topicId.UniqueId.Id].Entries.ContainsKey(entryId.UniqueId.Id))
                {
                    var order = HELP_TOPICS[topicId.UniqueId.Id].Entries[entryId.UniqueId.Id].Pages.Any() ? HELP_TOPICS[topicId.UniqueId.Id].Entries[entryId.UniqueId.Id].Pages.Keys.Max() + 1 : 0;
                    HELP_TOPICS[topicId.UniqueId.Id].Entries[entryId.UniqueId.Id].Pages[order] = new HelpPage()
                    {
                        Order = order,
                        Text = text,
                        Texture = texture
                    };
                }
            }
        }

        private static void DoLoad()
        {
            /* Systems */
            AddTopic(HelpSystemTopicId, LanguageProvider.GetEntry(LanguageEntries.HELP_TOPIC_SYSTEM_TITLE));
            AddEntry(
                HelpSystemTopicId,
                HelpSystemTopicId,
                LanguageProvider.GetEntry(LanguageEntries.HELP_TOPIC_SYSTEM_TITLE),
                0
            );
            AddPage(
                HelpSystemTopicId,
                HelpSystemTopicId,
                LanguageProvider.GetEntry(LanguageEntries.HELP_TOPIC_SYSTEM_DESCRIPTION)
            );
            /* Configurations */
            AddTopic(HelpConfigurationTopicId, LanguageProvider.GetEntry(LanguageEntries.HELP_TOPIC_CONFIGURATION_TITLE));
            AddEntry(
                HelpConfigurationTopicId,
                HelpConfigurationTopicId,
                LanguageProvider.GetEntry(LanguageEntries.HELP_TOPIC_CONFIGURATION_TITLE),
                0
            );
            AddPage(
                HelpConfigurationTopicId,
                HelpConfigurationTopicId,
                LanguageProvider.GetEntry(LanguageEntries.HELP_TOPIC_CONFIGURATION_DESCRIPTION)
            );
            LoadConfigHelpEntry(
                HelpConfigurationTopicId, 
                ExtendedSurvivalSettings.HELP_INFO, 
                1
            );
            /* Commands */
            AddTopic(HelpCommandTopicId, LanguageProvider.GetEntry(LanguageEntries.HELP_TOPIC_COMMAND_TITLE));
            AddEntry(
                HelpCommandTopicId,
                HelpCommandTopicId,
                LanguageProvider.GetEntry(LanguageEntries.HELP_TOPIC_COMMAND_TITLE),
                0
            );
            AddPage(
                HelpCommandTopicId,
                HelpCommandTopicId,
                LanguageProvider.GetEntry(LanguageEntries.HELP_TOPIC_COMMAND_DESCRIPTION)
            );
            if (ExtendedSurvivalStatsCommandController.Static != null)
            {
                LoadCommandHelpEntry(
                    HelpCommandTopicId,
                    ExtendedSurvivalStatsCommandController.Static.VALID_COMMANDS.Values.Where(x => x.HelpInfo != null).Select(x => x.HelpInfo),
                    1
                );
            }
            /* Others */
            foreach (var action in LOAD_ACTIONS)
            {
                action?.Invoke();
            }
            Loaded = true;
        }

        public static IDictionary<Guid, string> GetHelpTopics()
        {
            if (!Loaded)
                DoLoad();
            return HELP_TOPICS.ToDictionary(x => x.Key, x => x.Value.Title);
        }

        public static IDictionary<Guid, VRage.MyTuple<string, int, int, int>> GetHelpTopicEntries(Guid idTopic)
        {
            if (HELP_TOPICS.ContainsKey(idTopic))
            {
                return HELP_TOPICS[idTopic].Entries.ToDictionary(
                    x => x.Key, 
                    x => new VRage.MyTuple<string, int, int, int>(x.Value.Title, x.Value.Order, x.Value.Indentation, x.Value.Pages.Count)
                );
            }
            return new Dictionary<Guid, VRage.MyTuple<string, int, int, int>>();
        }

        public static VRage.MyTuple<string, string>? GetHelpEntryPageData(Guid idTopic, Guid idEntry, int page)
        {
            if (HELP_TOPICS.ContainsKey(idTopic))
            {
                if (HELP_TOPICS[idTopic].Entries.ContainsKey(idEntry))
                {
                    var entry = HELP_TOPICS[idTopic].Entries[idEntry];
                    if (entry.Pages.ContainsKey(page))
                    {
                        return new VRage.MyTuple<string, string>(entry.Pages[page].Text, entry.Pages[page].Texture);
                    }
                }
            }
            return null;
        }

        public static void FormatHelpLine(StringBuilder sb, string startLine, params string[] terms)
        {
            if (terms.Any())
            {
                sb.AppendLine("");
                var line = new StringBuilder();
                line.Append(startLine);
                for (int i = 0; i < terms.Length; i++)
                {
                    var data = terms[i] + (i < terms.Length - 1 ? ", " : ".");
                    if (line.Length + data.Length < 80)
                        line.Append(data);
                    else
                    {
                        sb.AppendLine(line.ToString());
                        line.Clear();
                    }
                }
                if (line.Length > 0)
                    sb.AppendLine(line.ToString());
            }
        }

        public static void LoadCommandHelpEntry(UniqueNameId topicId, IEnumerable<CommandEntryHelpInfo> entries, int level)
        {
            foreach (var entry in entries)
            {
                AddEntry(
                    topicId,
                    entry.EntryId,
                    entry.Title,
                    level
                );
                var sb = new StringBuilder();
                sb.AppendLine(entry.Description);
                if (!entry.IsGroup)
                {
                    if (!string.IsNullOrWhiteSpace(entry.Syntax))
                    {
                        sb.AppendLine("");
                        sb.AppendLine($"{LanguageProvider.GetEntry(LanguageEntries.TERMS_SYNTAX)}:");
                        sb.AppendLine("");
                        sb.AppendLine(entry.Syntax);
                    }
                    if (!string.IsNullOrWhiteSpace(entry.CommandSample))
                    {
                        sb.AppendLine("");
                        sb.AppendLine($"{LanguageProvider.GetEntry(LanguageEntries.TERMS_COMMANDUSESAMPLE)}:");
                        sb.AppendLine("");
                        sb.AppendLine(entry.CommandSample);
                    }
                }
                entry.OnAfterBuildPage?.Invoke(sb, 0);
                if (entry.ShowApplyLevel)
                {
                    sb.AppendLine("");
                    var effect = entry.NeedRestart ?
                        LanguageProvider.GetEntry(LanguageEntries.TERMS_NEEDRESTART) :
                        LanguageProvider.GetEntry(LanguageEntries.TERMS_TAKEIMMEDIATELY);
                    sb.AppendLine($"{LanguageProvider.GetEntry(LanguageEntries.TERMS_CHANGEEFFECT)}: {effect}.");
                }
                AddPage(
                    topicId,
                    entry.EntryId,
                    sb.ToString(),
                    entry.TextureIcon
                );
                int p = 1;
                foreach (var page in entry.ExtraPage)
                {
                    sb.Clear();
                    sb.AppendLine(page.Description);
                    entry.OnAfterBuildPage?.Invoke(sb, p);
                    AddPage(
                        topicId,
                        entry.EntryId,
                        sb.ToString(),
                        page.TextureIcon
                    );
                    p++;
                }
                if (entry.SubCommands.Any())
                {
                    LoadCommandHelpEntry(topicId, entry.SubCommands, level + 1);
                }
            }
        }

        public static void LoadConfigHelpEntry(UniqueNameId topicId, IEnumerable<ConfigurationEntryHelpInfo> entries, int level)
        {
            foreach (var entry in entries)
            {
                AddEntry(
                    topicId,
                    entry.EntryId,
                    entry.Title,
                    level
                );
                var sb = new StringBuilder();
                sb.AppendLine(entry.Description);
                if (!string.IsNullOrWhiteSpace(entry.DefaultValue))
                {
                    sb.AppendLine("");
                    sb.AppendLine($"{LanguageProvider.GetEntry(LanguageEntries.TERMS_DEFAULTVALUE)}: {entry.DefaultValue}");
                }
                if (entry.CanUseSettingsCommand)
                {
                    sb.AppendLine("");
                    var effect = entry.NeedRestart ? 
                        LanguageProvider.GetEntry(LanguageEntries.TERMS_NEEDRESTART) : 
                        LanguageProvider.GetEntry(LanguageEntries.TERMS_TAKEIMMEDIATELY);
                    sb.AppendLine($"{LanguageProvider.GetEntry(LanguageEntries.TERMS_CANUSEADMINCOMMAND)}. ({effect})");
                    if (!string.IsNullOrWhiteSpace(entry.CommandSample))
                    {
                        sb.AppendLine("");
                        sb.AppendLine($"{LanguageProvider.GetEntry(LanguageEntries.TERMS_COMMANDUSESAMPLE)}:");
                        sb.AppendLine("");
                        sb.AppendLine(entry.CommandSample);
                    }
                }
                sb.AppendLine("");
                switch (entry.ValueType)
                {
                    case ConfigurationValueType.String:
                        sb.AppendLine($"{LanguageProvider.GetEntry(LanguageEntries.CONFIGURATIONVALUETYPE_STRING)}");
                        break;
                    case ConfigurationValueType.Bool:
                        sb.AppendLine($"{LanguageProvider.GetEntry(LanguageEntries.CONFIGURATIONVALUETYPE_BOOL)}");
                        break;
                    case ConfigurationValueType.Integer:
                        sb.AppendLine($"{LanguageProvider.GetEntry(LanguageEntries.CONFIGURATIONVALUETYPE_INTEGER)}");
                        break;
                    case ConfigurationValueType.Decimal:
                        sb.AppendLine($"{LanguageProvider.GetEntry(LanguageEntries.CONFIGURATIONVALUETYPE_DECIMAL)}");
                        break;
                    case ConfigurationValueType.Vector2:
                        sb.AppendLine($"{LanguageProvider.GetEntry(LanguageEntries.CONFIGURATIONVALUETYPE_VECTOR2)}");
                        break;
                    case ConfigurationValueType.Vector3:
                        sb.AppendLine($"{LanguageProvider.GetEntry(LanguageEntries.CONFIGURATIONVALUETYPE_VECTOR3)}");
                        break;
                    case ConfigurationValueType.Vector4:
                        sb.AppendLine($"{LanguageProvider.GetEntry(LanguageEntries.CONFIGURATIONVALUETYPE_VECTOR4)}");
                        break;
                }
                AddPage(
                    topicId,
                    entry.EntryId,
                    sb.ToString(),
                    entry.TextureIcon
                );
                if (entry.Entries.Any())
                {
                    LoadConfigHelpEntry(topicId, entry.Entries, level + 1);
                }
            }
        }

        private static string BuildTextureName(MyDefinitionId id)
        {
            return $"{id.TypeId.ToString().Replace("MyObjectBuilder_", "")}{id.SubtypeId.String}";
        }

        public static void LoadDefinitionHelpEntryPages<T, K>(T definition, UniqueNameId topicId, UniqueNameId entryId) 
            where T : SimpleDefinition
            where K : MyPhysicalItemDefinition
        {
            var itemDef = DefinitionUtils.TryGetDefinition<K>(definition.Id.DefinitionId);
            if (itemDef != null)
            {
                AddPage(
                    topicId,
                    entryId,
                    definition.GetHelpDescription(),
                    BuildTextureName(definition.Id.DefinitionId)
                );
                var factoring = definition as ISimpleFactoringDefinition;
                if (factoring != null)
                {
                    var sb = new StringBuilder();
                    int i = 1;
                    foreach (var recipe in factoring.GetRecipesDefinition())
                    {
                        var recipeDef = DefinitionUtils.TryGetBlueprintDefinition(recipe.RecipeName);
                        if (recipeDef != null)
                        {
                            sb.AppendLine(LanguageProvider.GetEntry(LanguageEntries.TERMS_RECIPE) + " " + i.ToString("00"));
                            sb.AppendLine(string.Format("{0}: {1}s", LanguageProvider.GetEntry(LanguageEntries.TERMS_PRODUCTIONTIME), recipe.ProductionTime.ToString("#0.00")));
                            sb.AppendLine("");
                            sb.AppendLine($"{LanguageProvider.GetEntry(LanguageEntries.TERMS_INGREDIENTS)}:");
                            foreach (var ingredient in recipeDef.Prerequisites)
                            {
                                var ingredientDef = DefinitionUtils.TryGetDefinition<MyPhysicalItemDefinition>(ingredient.Id);
                                if (ingredientDef != null)
                                {
                                    sb.AppendLine(string.Format("- {0} {1}", ingredient.Amount, ingredientDef.DisplayNameText));
                                }
                            }
                            sb.AppendLine("");
                            sb.AppendLine($"{LanguageProvider.GetEntry(LanguageEntries.TERMS_RESULTS)}:");
                            foreach (var result in recipeDef.Results)
                            {
                                var resultDef = DefinitionUtils.TryGetDefinition<MyPhysicalItemDefinition>(result.Id);
                                if (resultDef != null)
                                {
                                    sb.AppendLine(string.Format("- {0} {1}", result.Amount, resultDef.DisplayNameText));
                                }
                            }
                            var assemblers = new List<MyAssemblerDefinition>();
                            var refineries = new List<MyRefineryDefinition>();
                            var gasGenerators = new List<MyOxygenGeneratorDefinition>();
                            PhysicalItemDefinitionOverride.RecoverBlueprintUse(recipeDef, ref assemblers, ref refineries, ref gasGenerators);
                            if (assemblers.Any())
                            {
                                sb.AppendLine("");
                                sb.AppendLine($"{LanguageProvider.GetEntry(LanguageEntries.TERMS_CRAFTAT)}:");
                                foreach (var item in assemblers)
                                {
                                    var size = item.CubeSize == MyCubeSize.Large ?
                                        LanguageProvider.GetEntry(LanguageEntries.TERMS_LARGE) :
                                        LanguageProvider.GetEntry(LanguageEntries.TERMS_SMALL);
                                    sb.AppendLine($"- {item.DisplayNameText} ({size})");
                                }
                            }
                            else if (refineries.Any())
                            {
                                sb.AppendLine("");
                                sb.AppendLine($"{LanguageProvider.GetEntry(LanguageEntries.TERMS_REFINEAT)}:");
                                foreach (var item in refineries)
                                {
                                    var size = item.CubeSize == MyCubeSize.Large ?
                                        LanguageProvider.GetEntry(LanguageEntries.TERMS_LARGE) :
                                        LanguageProvider.GetEntry(LanguageEntries.TERMS_SMALL);
                                    sb.AppendLine($"- {item.DisplayNameText} ({size})");
                                }
                            }
                            else if (gasGenerators.Any())
                            {
                                sb.AppendLine("");
                                sb.AppendLine($"{LanguageProvider.GetEntry(LanguageEntries.TERMS_CONSUMEAT)}:");
                                foreach (var item in gasGenerators)
                                {
                                    var size = item.CubeSize == MyCubeSize.Large ?
                                        LanguageProvider.GetEntry(LanguageEntries.TERMS_LARGE) :
                                        LanguageProvider.GetEntry(LanguageEntries.TERMS_SMALL);
                                    sb.AppendLine($"- {item.DisplayNameText} ({size})");
                                }
                            }
                            AddPage(
                                topicId,
                                entryId,
                                sb.ToString(),
                                BuildTextureName(definition.Id.DefinitionId)
                            );
                            i++;
                        }
                    }
                }
            }
        }

    }

}
