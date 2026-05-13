using System.Text.Json.Serialization;

namespace Elsa.Zendesk.Models;

/// <summary>Represents a Zendesk user.</summary>
public class User
{
    [JsonPropertyName("id")] public long Id { get; set; }
    [JsonPropertyName("url")] public string? Url { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("email")] public string? Email { get; set; }
    [JsonPropertyName("alias")] public string? Alias { get; set; }
    [JsonPropertyName("created_at")] public DateTimeOffset? CreatedAt { get; set; }
    [JsonPropertyName("updated_at")] public DateTimeOffset? UpdatedAt { get; set; }
    [JsonPropertyName("active")] public bool Active { get; set; }
    [JsonPropertyName("verified")] public bool Verified { get; set; }
    [JsonPropertyName("shared")] public bool Shared { get; set; }
    [JsonPropertyName("locale_id")] public long? LocaleId { get; set; }
    [JsonPropertyName("time_zone")] public string? TimeZone { get; set; }
    [JsonPropertyName("last_login_at")] public DateTimeOffset? LastLoginAt { get; set; }
    [JsonPropertyName("phone")] public string? Phone { get; set; }
    [JsonPropertyName("signature")] public string? Signature { get; set; }
    [JsonPropertyName("details")] public string? Details { get; set; }
    [JsonPropertyName("notes")] public string? Notes { get; set; }
    [JsonPropertyName("organization_id")] public long? OrganizationId { get; set; }
    [JsonPropertyName("role")] public string? Role { get; set; }
    [JsonPropertyName("external_id")] public string? ExternalId { get; set; }
    [JsonPropertyName("tags")] public IList<string>? Tags { get; set; }
    [JsonPropertyName("suspended")] public bool Suspended { get; set; }
    [JsonPropertyName("photo")] public Attachment? Photo { get; set; }
}

/// <summary>Request body for creating a user.</summary>
public class CreateUserRequest
{
    [JsonPropertyName("user")] public UserInput User { get; set; } = new();
}

/// <summary>Request body for updating a user.</summary>
public class UpdateUserRequest
{
    [JsonPropertyName("user")] public UserInput User { get; set; } = new();
}

/// <summary>User input fields shared by create and update operations.</summary>
public class UserInput
{
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("email")] public string? Email { get; set; }
    [JsonPropertyName("alias")] public string? Alias { get; set; }
    [JsonPropertyName("phone")] public string? Phone { get; set; }
    [JsonPropertyName("role")] public string? Role { get; set; }
    [JsonPropertyName("organization_id")] public long? OrganizationId { get; set; }
    [JsonPropertyName("external_id")] public string? ExternalId { get; set; }
    [JsonPropertyName("details")] public string? Details { get; set; }
    [JsonPropertyName("notes")] public string? Notes { get; set; }
    [JsonPropertyName("time_zone")] public string? TimeZone { get; set; }
    [JsonPropertyName("locale_id")] public long? LocaleId { get; set; }
    [JsonPropertyName("tags")] public IList<string>? Tags { get; set; }
    [JsonPropertyName("verified")] public bool? Verified { get; set; }
}

