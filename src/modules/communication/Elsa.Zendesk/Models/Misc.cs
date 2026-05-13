using System.Text.Json.Serialization;

namespace Elsa.Zendesk.Models;

/// <summary>Represents a Zendesk satisfaction rating.</summary>
public class SatisfactionRating
{
    [JsonPropertyName("id")] public long Id { get; set; }
    [JsonPropertyName("url")] public string? Url { get; set; }
    [JsonPropertyName("score")] public string? Score { get; set; }
    [JsonPropertyName("comment")] public string? Comment { get; set; }
    [JsonPropertyName("ticket_id")] public long? TicketId { get; set; }
    [JsonPropertyName("requester_id")] public long? RequesterId { get; set; }
    [JsonPropertyName("assignee_id")] public long? AssigneeId { get; set; }
    [JsonPropertyName("group_id")] public long? GroupId { get; set; }
    [JsonPropertyName("created_at")] public DateTimeOffset? CreatedAt { get; set; }
    [JsonPropertyName("updated_at")] public DateTimeOffset? UpdatedAt { get; set; }
}

/// <summary>Request body for creating a satisfaction rating.</summary>
public class CreateSatisfactionRatingRequest
{
    [JsonPropertyName("satisfaction_rating")] public SatisfactionRatingInput SatisfactionRating { get; set; } = new();
}

/// <summary>Satisfaction rating input fields.</summary>
public class SatisfactionRatingInput
{
    [JsonPropertyName("score")] public string? Score { get; set; }
    [JsonPropertyName("comment")] public string? Comment { get; set; }
}

/// <summary>Represents a Zendesk audit log entry.</summary>
public class AuditLog
{
    [JsonPropertyName("id")] public long Id { get; set; }
    [JsonPropertyName("url")] public string? Url { get; set; }
    [JsonPropertyName("action")] public string? Action { get; set; }
    [JsonPropertyName("actor_id")] public long? ActorId { get; set; }
    [JsonPropertyName("actor_name")] public string? ActorName { get; set; }
    [JsonPropertyName("change_description")] public string? ChangeDescription { get; set; }
    [JsonPropertyName("created_at")] public DateTimeOffset? CreatedAt { get; set; }
    [JsonPropertyName("ip_address")] public string? IpAddress { get; set; }
    [JsonPropertyName("source_id")] public long? SourceId { get; set; }
    [JsonPropertyName("source_label")] public string? SourceLabel { get; set; }
    [JsonPropertyName("source_type")] public string? SourceType { get; set; }
}

/// <summary>Represents a Zendesk bookmark.</summary>
public class ZendeskBookmark
{
    [JsonPropertyName("id")] public long Id { get; set; }
    [JsonPropertyName("url")] public string? Url { get; set; }
    [JsonPropertyName("ticket")] public Ticket? Ticket { get; set; }
    [JsonPropertyName("created_at")] public DateTimeOffset? CreatedAt { get; set; }
}

/// <summary>Request body for creating a bookmark.</summary>
public class CreateBookmarkRequest
{
    [JsonPropertyName("bookmark")] public ZendeskBookmarkInput Bookmark { get; set; } = new();
}

/// <summary>Bookmark input fields.</summary>
public class ZendeskBookmarkInput
{
    [JsonPropertyName("ticket_id")] public long TicketId { get; set; }
}

/// <summary>Represents a Zendesk custom ticket status.</summary>
public class CustomStatus
{
    [JsonPropertyName("id")] public long Id { get; set; }
    [JsonPropertyName("agent_label")] public string? AgentLabel { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("end_user_description")] public string? EndUserDescription { get; set; }
    [JsonPropertyName("end_user_label")] public string? EndUserLabel { get; set; }
    [JsonPropertyName("active")] public bool Active { get; set; }
    [JsonPropertyName("default")] public bool Default { get; set; }
    [JsonPropertyName("status_category")] public string? StatusCategory { get; set; }
    [JsonPropertyName("created_at")] public DateTimeOffset? CreatedAt { get; set; }
    [JsonPropertyName("updated_at")] public DateTimeOffset? UpdatedAt { get; set; }
}

/// <summary>Request body for creating a custom status.</summary>
public class CreateCustomStatusRequest
{
    [JsonPropertyName("custom_status")] public CustomStatusInput CustomStatus { get; set; } = new();
}

/// <summary>Request body for updating a custom status.</summary>
public class UpdateCustomStatusRequest
{
    [JsonPropertyName("custom_status")] public CustomStatusInput CustomStatus { get; set; } = new();
}

/// <summary>Custom status input fields.</summary>
public class CustomStatusInput
{
    [JsonPropertyName("agent_label")] public string? AgentLabel { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("end_user_description")] public string? EndUserDescription { get; set; }
    [JsonPropertyName("end_user_label")] public string? EndUserLabel { get; set; }
    [JsonPropertyName("active")] public bool? Active { get; set; }
    [JsonPropertyName("status_category")] public string? StatusCategory { get; set; }
}

