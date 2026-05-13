using System.Text.Json.Serialization;

namespace Elsa.Zendesk.Models;

/// <summary>Represents a Zendesk macro.</summary>
public class Macro
{
    [JsonPropertyName("id")] public long Id { get; set; }
    [JsonPropertyName("url")] public string? Url { get; set; }
    [JsonPropertyName("title")] public string? Title { get; set; }
    [JsonPropertyName("active")] public bool Active { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("position")] public int? Position { get; set; }
    [JsonPropertyName("restriction")] public object? Restriction { get; set; }
    [JsonPropertyName("actions")] public IList<MacroAction>? Actions { get; set; }
    [JsonPropertyName("created_at")] public DateTimeOffset? CreatedAt { get; set; }
    [JsonPropertyName("updated_at")] public DateTimeOffset? UpdatedAt { get; set; }
}

/// <summary>Represents a single action within a Zendesk macro.</summary>
public class MacroAction
{
    [JsonPropertyName("field")] public string? Field { get; set; }
    [JsonPropertyName("value")] public object? Value { get; set; }
}

/// <summary>Request body for creating a macro.</summary>
public class CreateMacroRequest
{
    [JsonPropertyName("macro")] public MacroInput Macro { get; set; } = new();
}

/// <summary>Request body for updating a macro.</summary>
public class UpdateMacroRequest
{
    [JsonPropertyName("macro")] public MacroInput Macro { get; set; } = new();
}

/// <summary>Macro input fields.</summary>
public class MacroInput
{
    [JsonPropertyName("title")] public string? Title { get; set; }
    [JsonPropertyName("active")] public bool? Active { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("actions")] public IList<MacroAction>? Actions { get; set; }
}

