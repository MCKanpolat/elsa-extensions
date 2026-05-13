using System.Text.Json.Serialization;

namespace Elsa.Zendesk.Models;

/// <summary>Represents a Zendesk trigger.</summary>
public class ZendeskTrigger
{
    [JsonPropertyName("id")] public long Id { get; set; }
    [JsonPropertyName("url")] public string? Url { get; set; }
    [JsonPropertyName("title")] public string? Title { get; set; }
    [JsonPropertyName("active")] public bool Active { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("position")] public int? Position { get; set; }
    [JsonPropertyName("conditions")] public ZendeskTriggerConditions? Conditions { get; set; }
    [JsonPropertyName("actions")] public IList<ZendeskTriggerAction>? Actions { get; set; }
    [JsonPropertyName("created_at")] public DateTimeOffset? CreatedAt { get; set; }
    [JsonPropertyName("updated_at")] public DateTimeOffset? UpdatedAt { get; set; }
}

/// <summary>Represents the conditions block of a Zendesk trigger.</summary>
public class ZendeskTriggerConditions
{
    [JsonPropertyName("all")] public IList<ZendeskTriggerCondition>? All { get; set; }
    [JsonPropertyName("any")] public IList<ZendeskTriggerCondition>? Any { get; set; }
}

/// <summary>Represents a single condition in a Zendesk trigger.</summary>
public class ZendeskTriggerCondition
{
    [JsonPropertyName("field")] public string? Field { get; set; }
    [JsonPropertyName("operator")] public string? Operator { get; set; }
    [JsonPropertyName("value")] public object? Value { get; set; }
}

/// <summary>Represents a single action within a Zendesk trigger.</summary>
public class ZendeskTriggerAction
{
    [JsonPropertyName("field")] public string? Field { get; set; }
    [JsonPropertyName("value")] public object? Value { get; set; }
}

/// <summary>Request body for creating a trigger.</summary>
public class CreateTriggerRequest
{
    [JsonPropertyName("trigger")] public ZendeskTriggerInput Trigger { get; set; } = new();
}

/// <summary>Request body for updating a trigger.</summary>
public class UpdateTriggerRequest
{
    [JsonPropertyName("trigger")] public ZendeskTriggerInput Trigger { get; set; } = new();
}

/// <summary>Trigger input fields.</summary>
public class ZendeskTriggerInput
{
    [JsonPropertyName("title")] public string? Title { get; set; }
    [JsonPropertyName("active")] public bool? Active { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("conditions")] public ZendeskTriggerConditions? Conditions { get; set; }
    [JsonPropertyName("actions")] public IList<ZendeskTriggerAction>? Actions { get; set; }
}

/// <summary>Represents a Zendesk trigger category.</summary>
public class TriggerCategory
{
    [JsonPropertyName("id")] public string? Id { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("position")] public int? Position { get; set; }
    [JsonPropertyName("created_at")] public DateTimeOffset? CreatedAt { get; set; }
    [JsonPropertyName("updated_at")] public DateTimeOffset? UpdatedAt { get; set; }
}

/// <summary>Request body for creating/updating a trigger category.</summary>
public class TriggerCategoryRequest
{
    [JsonPropertyName("trigger_category")] public TriggerCategoryInput TriggerCategory { get; set; } = new();
}

/// <summary>Trigger category input fields.</summary>
public class TriggerCategoryInput
{
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("position")] public int? Position { get; set; }
}

