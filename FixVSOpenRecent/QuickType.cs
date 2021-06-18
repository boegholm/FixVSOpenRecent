﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var welcome = Welcome.FromJson(jsonString);

namespace QuickType
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using J = Newtonsoft.Json.JsonPropertyAttribute;
    using R = Newtonsoft.Json.Required;
    using N = Newtonsoft.Json.NullValueHandling;

    public partial class FileEntry
    {
        [J("Key", NullValueHandling = N.Ignore)] public string Key { get; set; }
        [J("Value", NullValueHandling = N.Ignore)] public Value Value { get; set; }
    }

    public partial class Value
    {
        [J("LocalProperties", NullValueHandling = N.Ignore)] public LocalProperties LocalProperties { get; set; }
        [J("CodespaceProperties")] public object CodespaceProperties { get; set; }
        [J("Remote")] public Remote Remote { get; set; }
        [J("IsFavorite", NullValueHandling = N.Ignore)] public bool? IsFavorite { get; set; }
        [J("LastAccessed", NullValueHandling = N.Ignore)] public DateTime? LastAccessed { get; set; }
        [J("IsLocal", NullValueHandling = N.Ignore)] public bool? IsLocal { get; set; }
        [J("IsCodespace", NullValueHandling = N.Ignore)] public bool? IsCodespace { get; set; }
        [J("HasRemote", NullValueHandling = N.Ignore)] public bool? HasRemote { get; set; }
        [J("IsSourceControlled", NullValueHandling = N.Ignore)] public bool? IsSourceControlled { get; set; }
    }

    public partial class LocalProperties
    {
        [J("FullPath", NullValueHandling = N.Ignore)] public string FullPath { get; set; }
        [J("Type", NullValueHandling = N.Ignore)] public long? Type { get; set; }
        [J("SourceControl")] public object SourceControl { get; set; }
    }

    public partial class Remote
    {
        [J("Name", NullValueHandling = N.Ignore)] public string Name { get; set; }
        [J("CodeContainerProvider", NullValueHandling = N.Ignore)] public Guid? CodeContainerProvider { get; set; }
        [J("DisplayUrl", NullValueHandling = N.Ignore)] public Uri DisplayUrl { get; set; }
        [J("BrowseOnlineUrl", NullValueHandling = N.Ignore)] public Uri BrowseOnlineUrl { get; set; }
        [J("LastAccessed", NullValueHandling = N.Ignore)] public string LastAccessed { get; set; }
        [J("ExtraProperties", NullValueHandling = N.Ignore)] public List<object> ExtraProperties { get; set; }
    }

    public partial class FileEntry
    {
        public static List<FileEntry> FromJson(string json) => JsonConvert.DeserializeObject<List<FileEntry>>(json, QuickType.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this List<FileEntry> self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}