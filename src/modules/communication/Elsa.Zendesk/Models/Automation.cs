using System.Text.Json.Serialization;

namespace Elsa.Zendesk.Models;

/// <summary>Represents a Zendesk automation.</summary>
public class Automation
{
    [JsonPropertyName("id")] public long Id { get; set; }
    [JsonPropertyName("url")] public string? Url { get; set; }
    [JsonPropertyName("title")] public string? Title { get; set; }
    [JsonPropertyName("active")] public bool Active { get; set; }
    [JsonPropertyName("position")] public int? Position { get; set; }
    [JsonPropertyName("conditions")] public AutomationConditions? Conditions { get; set; }
    [JsonPropertyName("actions")] public IList<AutomationAction>? Actions { get; set; }
    [JsonPropertyName("created_at")] public DateTimeOffset? CreatedAt { get; set; }
    [JsonPropertyName("updated_at")] public DateTimeOffset? UpdatedAt { get; set; }
}

/// <summary>Represents the conditions of an automation.</summary>
public class AutomationConditions
{
    [JsonPropertyName("all")] public IList<AutomationCondition>? All { get; set; }
    [JsonPropertyName("any")] public IList<AutomationCondition>? Any { get; set; }
}

/// <summary>Represents a single automation condition.</summary>
public class AutomationCondition
{
    [JsonPropertyName("field")] public string? Field { get; set; }
    [JsonPropertyName("operator")] public string? Operator { get; set; }
    [JsonPropertyName("value")] public object? Value { get; set; }
}

/// <summary>Represents a single automation action.</summary>
public class AutomationAction
{
    [JsonPropertyName("field")] public string? Field { get; set; }
    [JsonPropertyName("value")] public object? Value { get; set; }
}

/// <summary>Request body for creating an automation.</summary>
public class CreateAutomationRequest
{
    [JsonPropertyName("automation")] public AutomationInput Automation { get; set; } = new();
}

/// <summary>Request body for updating an automation.</summary>
public class UpdateAutomationRequest
{
    [JsonPropertyName("automation")] public AutomationInput Automation { get; set; } = new();
}

/// <summary>Automation input fields.</summary>
public class AutomationInput
{
    [JsonPropertyName("title")] public string? Title { get; set; }
    [JsonPropertyName("active")] public bool? Active { get; set; }
    [JsonPropertyName("conditions")] public AutomationConditions? Conditions { get; set; }
    [JsonPropertyName("actions")] public IList<AutomationAction>? Actions { get; set; }
}

