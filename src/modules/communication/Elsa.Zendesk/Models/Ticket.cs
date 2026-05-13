using System.Text.Json.Serialization;

namespace Elsa.Zendesk.Models;

/// <summary>Represents a Zendesk ticket.</summary>
public class Ticket
{
    [JsonPropertyName("id")] public long Id { get; set; }
    [JsonPropertyName("url")] public string? Url { get; set; }
    [JsonPropertyName("external_id")] public string? ExternalId { get; set; }
    [JsonPropertyName("type")] public string? Type { get; set; }
    [JsonPropertyName("subject")] public string? Subject { get; set; }
    [JsonPropertyName("raw_subject")] public string? RawSubject { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("priority")] public string? Priority { get; set; }
    [JsonPropertyName("status")] public string? Status { get; set; }
    [JsonPropertyName("recipient")] public string? Recipient { get; set; }
    [JsonPropertyName("requester_id")] public long? RequesterId { get; set; }
    [JsonPropertyName("submitter_id")] public long? SubmitterId { get; set; }
    [JsonPropertyName("assignee_id")] public long? AssigneeId { get; set; }
    [JsonPropertyName("organization_id")] public long? OrganizationId { get; set; }
    [JsonPropertyName("group_id")] public long? GroupId { get; set; }
    [JsonPropertyName("brand_id")] public long? BrandId { get; set; }
    [JsonPropertyName("forum_topic_id")] public long? ForumTopicId { get; set; }
    [JsonPropertyName("problem_id")] public long? ProblemId { get; set; }
    [JsonPropertyName("has_incidents")] public bool HasIncidents { get; set; }
    [JsonPropertyName("is_public")] public bool IsPublic { get; set; }
    [JsonPropertyName("due_at")] public DateTimeOffset? DueAt { get; set; }
    [JsonPropertyName("tags")] public IList<string>? Tags { get; set; }
    [JsonPropertyName("created_at")] public DateTimeOffset? CreatedAt { get; set; }
    [JsonPropertyName("updated_at")] public DateTimeOffset? UpdatedAt { get; set; }
    [JsonPropertyName("custom_fields")] public IList<TicketCustomField>? CustomFields { get; set; }
}

/// <summary>Represents a custom field on a Zendesk ticket.</summary>
public class TicketCustomField
{
    [JsonPropertyName("id")] public long Id { get; set; }
    [JsonPropertyName("value")] public object? Value { get; set; }
}

/// <summary>Request body for creating a ticket.</summary>
public class CreateTicketRequest
{
    [JsonPropertyName("ticket")] public TicketInput Ticket { get; set; } = new();
}

/// <summary>Request body for updating a ticket.</summary>
public class UpdateTicketRequest
{
    [JsonPropertyName("ticket")] public TicketInput Ticket { get; set; } = new();
}

/// <summary>Ticket input fields shared by create and update operations.</summary>
public class TicketInput
{
    [JsonPropertyName("subject")] public string? Subject { get; set; }
    [JsonPropertyName("comment")] public TicketCommentInput? Comment { get; set; }
    [JsonPropertyName("type")] public string? Type { get; set; }
    [JsonPropertyName("priority")] public string? Priority { get; set; }
    [JsonPropertyName("status")] public string? Status { get; set; }
    [JsonPropertyName("requester_id")] public long? RequesterId { get; set; }
    [JsonPropertyName("assignee_id")] public long? AssigneeId { get; set; }
    [JsonPropertyName("group_id")] public long? GroupId { get; set; }
    [JsonPropertyName("organization_id")] public long? OrganizationId { get; set; }
    [JsonPropertyName("brand_id")] public long? BrandId { get; set; }
    [JsonPropertyName("external_id")] public string? ExternalId { get; set; }
    [JsonPropertyName("due_at")] public DateTimeOffset? DueAt { get; set; }
    [JsonPropertyName("tags")] public IList<string>? Tags { get; set; }
    [JsonPropertyName("custom_fields")] public IList<TicketCustomField>? CustomFields { get; set; }
}

/// <summary>Inline comment input when creating/updating a ticket.</summary>
public class TicketCommentInput
{
    [JsonPropertyName("body")] public string? Body { get; set; }
    [JsonPropertyName("html_body")] public string? HtmlBody { get; set; }
    [JsonPropertyName("public")] public bool? Public { get; set; }
    [JsonPropertyName("author_id")] public long? AuthorId { get; set; }
}

