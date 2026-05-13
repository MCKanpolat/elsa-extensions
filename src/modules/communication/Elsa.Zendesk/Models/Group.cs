using System.Text.Json.Serialization;

namespace Elsa.Zendesk.Models;

/// <summary>Represents a Zendesk group.</summary>
public class Group
{
    [JsonPropertyName("id")] public long Id { get; set; }
    [JsonPropertyName("url")] public string? Url { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("default")] public bool Default { get; set; }
    [JsonPropertyName("deleted")] public bool Deleted { get; set; }
    [JsonPropertyName("created_at")] public DateTimeOffset? CreatedAt { get; set; }
    [JsonPropertyName("updated_at")] public DateTimeOffset? UpdatedAt { get; set; }
}

/// <summary>Request body for creating a group.</summary>
public class CreateGroupRequest
{
    [JsonPropertyName("group")] public GroupInput Group { get; set; } = new();
}

/// <summary>Request body for updating a group.</summary>
public class UpdateGroupRequest
{
    [JsonPropertyName("group")] public GroupInput Group { get; set; } = new();
}

/// <summary>Group input fields shared by create and update operations.</summary>
public class GroupInput
{
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
}

/// <summary>Represents a Zendesk group membership.</summary>
public class GroupMembership
{
    [JsonPropertyName("id")] public long Id { get; set; }
    [JsonPropertyName("user_id")] public long UserId { get; set; }
    [JsonPropertyName("group_id")] public long GroupId { get; set; }
    [JsonPropertyName("default")] public bool Default { get; set; }
    [JsonPropertyName("created_at")] public DateTimeOffset? CreatedAt { get; set; }
    [JsonPropertyName("updated_at")] public DateTimeOffset? UpdatedAt { get; set; }
}

/// <summary>Request body for creating a group membership.</summary>
public class CreateGroupMembershipRequest
{
    [JsonPropertyName("group_membership")] public GroupMembershipInput GroupMembership { get; set; } = new();
}

/// <summary>Group membership input fields.</summary>
public class GroupMembershipInput
{
    [JsonPropertyName("user_id")] public long UserId { get; set; }
    [JsonPropertyName("group_id")] public long GroupId { get; set; }
}

