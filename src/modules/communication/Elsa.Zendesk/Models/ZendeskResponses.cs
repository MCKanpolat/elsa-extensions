using System.Text.Json.Serialization;

namespace Elsa.Zendesk.Models;

/// <summary>Wraps a single Zendesk resource response.</summary>
public class ZendeskResponse<T>
{
    [JsonPropertyName("ticket")] public T? Ticket { get; set; }
    [JsonPropertyName("user")] public T? User { get; set; }
    [JsonPropertyName("organization")] public T? Organization { get; set; }
    [JsonPropertyName("group")] public T? Group { get; set; }
    [JsonPropertyName("macro")] public T? Macro { get; set; }
    [JsonPropertyName("trigger")] public T? Trigger { get; set; }
    [JsonPropertyName("view")] public T? View { get; set; }
    [JsonPropertyName("automation")] public T? Automation { get; set; }
    [JsonPropertyName("brand")] public T? Brand { get; set; }
    [JsonPropertyName("attachment")] public T? Attachment { get; set; }
    [JsonPropertyName("satisfaction_rating")] public T? SatisfactionRating { get; set; }
    [JsonPropertyName("audit_log")] public T? AuditLog { get; set; }
    [JsonPropertyName("bookmark")] public T? ZendeskBookmark { get; set; }
    [JsonPropertyName("group_membership")] public T? GroupMembership { get; set; }
    [JsonPropertyName("trigger_category")] public T? TriggerCategory { get; set; }
    [JsonPropertyName("custom_status")] public T? CustomStatus { get; set; }
    [JsonPropertyName("sla_policy")] public T? SlaPolicy { get; set; }
    [JsonPropertyName("target")] public T? Target { get; set; }
    [JsonPropertyName("request")] public T? Request { get; set; }
    [JsonPropertyName("locale")] public T? Locale { get; set; }
}

/// <summary>Wraps a paged Zendesk list response.</summary>
public class ZendeskListResponse<T>
{
    [JsonPropertyName("count")] public long Count { get; set; }
    [JsonPropertyName("next_page")] public string? NextPage { get; set; }
    [JsonPropertyName("previous_page")] public string? PreviousPage { get; set; }
    [JsonPropertyName("tickets")] public IList<T>? Tickets { get; set; }
    [JsonPropertyName("users")] public IList<T>? Users { get; set; }
    [JsonPropertyName("organizations")] public IList<T>? Organizations { get; set; }
    [JsonPropertyName("groups")] public IList<T>? Groups { get; set; }
    [JsonPropertyName("macros")] public IList<T>? Macros { get; set; }
    [JsonPropertyName("triggers")] public IList<T>? Triggers { get; set; }
    [JsonPropertyName("views")] public IList<T>? Views { get; set; }
    [JsonPropertyName("automations")] public IList<T>? Automations { get; set; }
    [JsonPropertyName("brands")] public IList<T>? Brands { get; set; }
    [JsonPropertyName("comments")] public IList<T>? Comments { get; set; }
    [JsonPropertyName("audit_logs")] public IList<T>? AuditLogs { get; set; }
    [JsonPropertyName("satisfaction_ratings")] public IList<T>? SatisfactionRatings { get; set; }
    [JsonPropertyName("bookmarks")] public IList<T>? Bookmarks { get; set; }
    [JsonPropertyName("custom_statuses")] public IList<T>? CustomStatuses { get; set; }
    [JsonPropertyName("sla_policies")] public IList<T>? SlaPolicies { get; set; }
    [JsonPropertyName("targets")] public IList<T>? Targets { get; set; }
    [JsonPropertyName("requests")] public IList<T>? Requests { get; set; }
    [JsonPropertyName("locales")] public IList<T>? Locales { get; set; }
    [JsonPropertyName("results")] public IList<T>? Results { get; set; }
    [JsonPropertyName("tags")] public IList<T>? Tags { get; set; }
}

