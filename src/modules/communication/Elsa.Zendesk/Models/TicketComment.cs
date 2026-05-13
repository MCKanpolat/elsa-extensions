using System.Text.Json.Serialization;

namespace Elsa.Zendesk.Models;

/// <summary>Represents a comment on a Zendesk ticket.</summary>
public class TicketComment
{
    [JsonPropertyName("id")] public long Id { get; set; }
    [JsonPropertyName("type")] public string? Type { get; set; }
    [JsonPropertyName("author_id")] public long? AuthorId { get; set; }
    [JsonPropertyName("body")] public string? Body { get; set; }
    [JsonPropertyName("html_body")] public string? HtmlBody { get; set; }
    [JsonPropertyName("plain_body")] public string? PlainBody { get; set; }
    [JsonPropertyName("public")] public bool? Public { get; set; }
    [JsonPropertyName("attachments")] public IList<Attachment>? Attachments { get; set; }
    [JsonPropertyName("created_at")] public DateTimeOffset? CreatedAt { get; set; }
}

/// <summary>Represents a Zendesk ticket audit.</summary>
public class TicketAudit
{
    [JsonPropertyName("id")] public long Id { get; set; }
    [JsonPropertyName("ticket_id")] public long TicketId { get; set; }
    [JsonPropertyName("created_at")] public DateTimeOffset? CreatedAt { get; set; }
    [JsonPropertyName("author_id")] public long? AuthorId { get; set; }
    [JsonPropertyName("events")] public IList<object>? Events { get; set; }
}

/// <summary>Represents Zendesk ticket metrics.</summary>
public class TicketMetrics
{
    [JsonPropertyName("id")] public long Id { get; set; }
    [JsonPropertyName("ticket_id")] public long TicketId { get; set; }
    [JsonPropertyName("created_at")] public DateTimeOffset? CreatedAt { get; set; }
    [JsonPropertyName("updated_at")] public DateTimeOffset? UpdatedAt { get; set; }
    [JsonPropertyName("reply_time_in_minutes")] public TicketMetricTime? ReplyTimeInMinutes { get; set; }
    [JsonPropertyName("first_resolution_time_in_minutes")] public TicketMetricTime? FirstResolutionTimeInMinutes { get; set; }
    [JsonPropertyName("full_resolution_time_in_minutes")] public TicketMetricTime? FullResolutionTimeInMinutes { get; set; }
    [JsonPropertyName("agent_wait_time_in_minutes")] public TicketMetricTime? AgentWaitTimeInMinutes { get; set; }
    [JsonPropertyName("requester_wait_time_in_minutes")] public TicketMetricTime? RequesterWaitTimeInMinutes { get; set; }
    [JsonPropertyName("on_hold_time_in_minutes")] public TicketMetricTime? OnHoldTimeInMinutes { get; set; }
    [JsonPropertyName("replies")] public int? Replies { get; set; }
    [JsonPropertyName("assignee_updated_at")] public DateTimeOffset? AssigneeUpdatedAt { get; set; }
    [JsonPropertyName("requester_updated_at")] public DateTimeOffset? RequesterUpdatedAt { get; set; }
    [JsonPropertyName("status_updated_at")] public DateTimeOffset? StatusUpdatedAt { get; set; }
    [JsonPropertyName("initially_assigned_at")] public DateTimeOffset? InitiallyAssignedAt { get; set; }
    [JsonPropertyName("assigned_at")] public DateTimeOffset? AssignedAt { get; set; }
    [JsonPropertyName("solved_at")] public DateTimeOffset? SolvedAt { get; set; }
    [JsonPropertyName("latest_comment_added_at")] public DateTimeOffset? LatestCommentAddedAt { get; set; }
}

/// <summary>Represents a calendar/business time measurement in ticket metrics.</summary>
public class TicketMetricTime
{
    [JsonPropertyName("calendar")] public int? Calendar { get; set; }
    [JsonPropertyName("business")] public int? Business { get; set; }
}

