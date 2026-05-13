using System.Text.Json.Serialization;

namespace Elsa.Zendesk.Models;

/// <summary>Represents a Zendesk organization.</summary>
public class Organization
{
    [JsonPropertyName("id")] public long Id { get; set; }
    [JsonPropertyName("url")] public string? Url { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("details")] public string? Details { get; set; }
    [JsonPropertyName("notes")] public string? Notes { get; set; }
    [JsonPropertyName("external_id")] public string? ExternalId { get; set; }
    [JsonPropertyName("domain_names")] public IList<string>? DomainNames { get; set; }
    [JsonPropertyName("tags")] public IList<string>? Tags { get; set; }
    [JsonPropertyName("created_at")] public DateTimeOffset? CreatedAt { get; set; }
    [JsonPropertyName("updated_at")] public DateTimeOffset? UpdatedAt { get; set; }
    [JsonPropertyName("group_id")] public long? GroupId { get; set; }
    [JsonPropertyName("shared_tickets")] public bool SharedTickets { get; set; }
    [JsonPropertyName("shared_comments")] public bool SharedComments { get; set; }
}

/// <summary>Request body for creating an organization.</summary>
public class CreateOrganizationRequest
{
    [JsonPropertyName("organization")] public OrganizationInput Organization { get; set; } = new();
}

/// <summary>Request body for updating an organization.</summary>
public class UpdateOrganizationRequest
{
    [JsonPropertyName("organization")] public OrganizationInput Organization { get; set; } = new();
}

/// <summary>Organization input fields shared by create and update operations.</summary>
public class OrganizationInput
{
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("details")] public string? Details { get; set; }
    [JsonPropertyName("notes")] public string? Notes { get; set; }
    [JsonPropertyName("external_id")] public string? ExternalId { get; set; }
    [JsonPropertyName("domain_names")] public IList<string>? DomainNames { get; set; }
    [JsonPropertyName("tags")] public IList<string>? Tags { get; set; }
    [JsonPropertyName("group_id")] public long? GroupId { get; set; }
    [JsonPropertyName("shared_tickets")] public bool? SharedTickets { get; set; }
    [JsonPropertyName("shared_comments")] public bool? SharedComments { get; set; }
}

