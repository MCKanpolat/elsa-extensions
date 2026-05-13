using System.Text.Json.Serialization;

namespace Elsa.Zendesk.Models;

/// <summary>Represents a Zendesk brand.</summary>
public class Brand
{
    [JsonPropertyName("id")] public long Id { get; set; }
    [JsonPropertyName("url")] public string? Url { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("subdomain")] public string? Subdomain { get; set; }
    [JsonPropertyName("host_mapping")] public string? HostMapping { get; set; }
    [JsonPropertyName("active")] public bool Active { get; set; }
    [JsonPropertyName("default")] public bool Default { get; set; }
    [JsonPropertyName("is_deleted")] public bool IsDeleted { get; set; }
    [JsonPropertyName("brand_url")] public string? BrandUrl { get; set; }
    [JsonPropertyName("help_center_state")] public string? HelpCenterState { get; set; }
    [JsonPropertyName("created_at")] public DateTimeOffset? CreatedAt { get; set; }
    [JsonPropertyName("updated_at")] public DateTimeOffset? UpdatedAt { get; set; }
}

/// <summary>Request body for creating a brand.</summary>
public class CreateBrandRequest
{
    [JsonPropertyName("brand")] public BrandInput Brand { get; set; } = new();
}

/// <summary>Request body for updating a brand.</summary>
public class UpdateBrandRequest
{
    [JsonPropertyName("brand")] public BrandInput Brand { get; set; } = new();
}

/// <summary>Brand input fields.</summary>
public class BrandInput
{
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("subdomain")] public string? Subdomain { get; set; }
    [JsonPropertyName("active")] public bool? Active { get; set; }
    [JsonPropertyName("brand_url")] public string? BrandUrl { get; set; }
}

