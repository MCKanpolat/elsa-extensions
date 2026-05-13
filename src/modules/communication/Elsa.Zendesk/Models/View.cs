using System.Text.Json.Serialization;

namespace Elsa.Zendesk.Models;

/// <summary>Represents a Zendesk view.</summary>
public class View
{
    [JsonPropertyName("id")] public long Id { get; set; }
    [JsonPropertyName("url")] public string? Url { get; set; }
    [JsonPropertyName("title")] public string? Title { get; set; }
    [JsonPropertyName("active")] public bool Active { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("position")] public int? Position { get; set; }
    [JsonPropertyName("restriction")] public object? Restriction { get; set; }
    [JsonPropertyName("conditions")] public ViewConditions? Conditions { get; set; }
    [JsonPropertyName("execution")] public object? Execution { get; set; }
    [JsonPropertyName("created_at")] public DateTimeOffset? CreatedAt { get; set; }
    [JsonPropertyName("updated_at")] public DateTimeOffset? UpdatedAt { get; set; }
}

/// <summary>Represents the conditions of a Zendesk view.</summary>
public class ViewConditions
{
    [JsonPropertyName("all")] public IList<ViewCondition>? All { get; set; }
    [JsonPropertyName("any")] public IList<ViewCondition>? Any { get; set; }
}

/// <summary>Represents a single condition in a view.</summary>
public class ViewCondition
{
    [JsonPropertyName("field")] public string? Field { get; set; }
    [JsonPropertyName("operator")] public string? Operator { get; set; }
    [JsonPropertyName("value")] public object? Value { get; set; }
}

/// <summary>Request body for creating a view.</summary>
public class CreateViewRequest
{
    [JsonPropertyName("view")] public ViewInput View { get; set; } = new();
}

/// <summary>Request body for updating a view.</summary>
public class UpdateViewRequest
{
    [JsonPropertyName("view")] public ViewInput View { get; set; } = new();
}

/// <summary>View input fields.</summary>
public class ViewInput
{
    [JsonPropertyName("title")] public string? Title { get; set; }
    [JsonPropertyName("active")] public bool? Active { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("conditions")] public ViewConditions? Conditions { get; set; }
}

