using System.Text.Json.Serialization;

namespace Elsa.Zendesk.Models;

/// <summary>Represents a Zendesk SLA policy.</summary>
public class SlaPolicy
{
    [JsonPropertyName("id")] public long Id { get; set; }
    [JsonPropertyName("url")] public string? Url { get; set; }
    [JsonPropertyName("title")] public string? Title { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("position")] public int? Position { get; set; }
    [JsonPropertyName("filter")] public SlaPolicyFilter? Filter { get; set; }
    [JsonPropertyName("policy_metrics")] public IList<SlaPolicyMetric>? PolicyMetrics { get; set; }
    [JsonPropertyName("created_at")] public DateTimeOffset? CreatedAt { get; set; }
    [JsonPropertyName("updated_at")] public DateTimeOffset? UpdatedAt { get; set; }
}

/// <summary>Represents the filter for an SLA policy.</summary>
public class SlaPolicyFilter
{
    [JsonPropertyName("all")] public IList<SlaPolicyCondition>? All { get; set; }
    [JsonPropertyName("any")] public IList<SlaPolicyCondition>? Any { get; set; }
}

/// <summary>Represents a condition in an SLA policy filter.</summary>
public class SlaPolicyCondition
{
    [JsonPropertyName("field")] public string? Field { get; set; }
    [JsonPropertyName("operator")] public string? Operator { get; set; }
    [JsonPropertyName("value")] public object? Value { get; set; }
}

/// <summary>Represents a metric target within an SLA policy.</summary>
public class SlaPolicyMetric
{
    [JsonPropertyName("priority")] public string? Priority { get; set; }
    [JsonPropertyName("metric")] public string? Metric { get; set; }
    [JsonPropertyName("target")] public int? Target { get; set; }
    [JsonPropertyName("business_hours")] public bool BusinessHours { get; set; }
}

/// <summary>Request body for creating an SLA policy.</summary>
public class CreateSlaPolicyRequest
{
    [JsonPropertyName("sla_policy")] public SlaPolicyInput SlaPolicy { get; set; } = new();
}

/// <summary>Request body for updating an SLA policy.</summary>
public class UpdateSlaPolicyRequest
{
    [JsonPropertyName("sla_policy")] public SlaPolicyInput SlaPolicy { get; set; } = new();
}

/// <summary>SLA policy input fields.</summary>
public class SlaPolicyInput
{
    [JsonPropertyName("title")] public string? Title { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("filter")] public SlaPolicyFilter? Filter { get; set; }
    [JsonPropertyName("policy_metrics")] public IList<SlaPolicyMetric>? PolicyMetrics { get; set; }
}

