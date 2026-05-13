using System.Text.Json.Serialization;

namespace Elsa.Zendesk.Models;

/// <summary>Represents a Zendesk dynamic content item.</summary>
public class DynamicContentItem
{
    [JsonPropertyName("id")] public long Id { get; set; }
    [JsonPropertyName("url")] public string? Url { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("placeholder")] public string? Placeholder { get; set; }
    [JsonPropertyName("default_locale_id")] public long? DefaultLocaleId { get; set; }
    [JsonPropertyName("outdated")] public bool Outdated { get; set; }
    [JsonPropertyName("variants")] public IList<DynamicContentVariant>? Variants { get; set; }
    [JsonPropertyName("created_at")] public DateTimeOffset? CreatedAt { get; set; }
    [JsonPropertyName("updated_at")] public DateTimeOffset? UpdatedAt { get; set; }
}

/// <summary>Represents a locale-specific variant of a dynamic content item.</summary>
public class DynamicContentVariant
{
    [JsonPropertyName("id")] public long Id { get; set; }
    [JsonPropertyName("content")] public string? Content { get; set; }
    [JsonPropertyName("locale_id")] public long LocaleId { get; set; }
    [JsonPropertyName("active")] public bool Active { get; set; }
    [JsonPropertyName("default")] public bool Default { get; set; }
    [JsonPropertyName("outdated")] public bool Outdated { get; set; }
    [JsonPropertyName("created_at")] public DateTimeOffset? CreatedAt { get; set; }
    [JsonPropertyName("updated_at")] public DateTimeOffset? UpdatedAt { get; set; }
}

/// <summary>Request body for creating a dynamic content item.</summary>
public class CreateDynamicContentItemRequest
{
    [JsonPropertyName("item")] public DynamicContentItemInput Item { get; set; } = new();
}

/// <summary>Request body for updating a dynamic content item.</summary>
public class UpdateDynamicContentItemRequest
{
    [JsonPropertyName("item")] public DynamicContentItemInput Item { get; set; } = new();
}

/// <summary>Dynamic content item input fields.</summary>
public class DynamicContentItemInput
{
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("default_locale_id")] public long? DefaultLocaleId { get; set; }
    [JsonPropertyName("variants")] public IList<DynamicContentVariantInput>? Variants { get; set; }
}

/// <summary>Dynamic content variant input fields.</summary>
public class DynamicContentVariantInput
{
    [JsonPropertyName("content")] public string? Content { get; set; }
    [JsonPropertyName("locale_id")] public long LocaleId { get; set; }
    [JsonPropertyName("active")] public bool? Active { get; set; }
    [JsonPropertyName("default")] public bool? Default { get; set; }
}

/// <summary>Response wrapper for dynamic content item endpoints.</summary>
public class DynamicContentItemResponse
{
    [JsonPropertyName("item")] public DynamicContentItem? Item { get; set; }
}

/// <summary>Response wrapper for dynamic content list endpoints.</summary>
public class DynamicContentListResponse
{
    [JsonPropertyName("items")] public IList<DynamicContentItem>? Items { get; set; }
    [JsonPropertyName("count")] public long Count { get; set; }
    [JsonPropertyName("next_page")] public string? NextPage { get; set; }
    [JsonPropertyName("previous_page")] public string? PreviousPage { get; set; }
}

/// <summary>Represents a Zendesk locale.</summary>
public class Locale
{
    [JsonPropertyName("id")] public long Id { get; set; }
    [JsonPropertyName("url")] public string? Url { get; set; }
    [JsonPropertyName("locale")] public string? LocaleCode { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("native_name")] public string? NativeName { get; set; }
    [JsonPropertyName("presentation_name")] public string? PresentationName { get; set; }
    [JsonPropertyName("created_at")] public DateTimeOffset? CreatedAt { get; set; }
    [JsonPropertyName("updated_at")] public DateTimeOffset? UpdatedAt { get; set; }
}

/// <summary>Represents a Zendesk target (outbound integration).</summary>
public class Target
{
    [JsonPropertyName("id")] public long Id { get; set; }
    [JsonPropertyName("url")] public string? Url { get; set; }
    [JsonPropertyName("title")] public string? Title { get; set; }
    [JsonPropertyName("type")] public string? Type { get; set; }
    [JsonPropertyName("active")] public bool Active { get; set; }
    [JsonPropertyName("created_at")] public DateTimeOffset? CreatedAt { get; set; }
}

/// <summary>Represents a Zendesk search result entry.</summary>
public class SearchResult
{
    [JsonPropertyName("id")] public long Id { get; set; }
    [JsonPropertyName("url")] public string? Url { get; set; }
    [JsonPropertyName("result_type")] public string? ResultType { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("subject")] public string? Subject { get; set; }
    [JsonPropertyName("created_at")] public DateTimeOffset? CreatedAt { get; set; }
    [JsonPropertyName("updated_at")] public DateTimeOffset? UpdatedAt { get; set; }
}

/// <summary>Represents Zendesk account settings.</summary>
public class AccountSettings
{
    [JsonPropertyName("branding")] public object? Branding { get; set; }
    [JsonPropertyName("tickets")] public object? Tickets { get; set; }
    [JsonPropertyName("agents")] public object? Agents { get; set; }
    [JsonPropertyName("users")] public object? Users { get; set; }
}

/// <summary>Request body for updating account settings.</summary>
public class UpdateAccountSettingsRequest
{
    [JsonPropertyName("settings")] public AccountSettings Settings { get; set; } = new();
}

/// <summary>Response wrapper for the account settings endpoint.</summary>
public class AccountSettingsResponse
{
    [JsonPropertyName("settings")] public AccountSettings? Settings { get; set; }
}

/// <summary>Represents a Zendesk end-user request.</summary>
public class ZendeskRequest
{
    [JsonPropertyName("id")] public long Id { get; set; }
    [JsonPropertyName("url")] public string? Url { get; set; }
    [JsonPropertyName("subject")] public string? Subject { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("status")] public string? Status { get; set; }
    [JsonPropertyName("requester_id")] public long? RequesterId { get; set; }
    [JsonPropertyName("assignee_id")] public long? AssigneeId { get; set; }
    [JsonPropertyName("created_at")] public DateTimeOffset? CreatedAt { get; set; }
    [JsonPropertyName("updated_at")] public DateTimeOffset? UpdatedAt { get; set; }
}

/// <summary>Request body for creating an end-user request.</summary>
public class CreateZendeskRequestBody
{
    [JsonPropertyName("request")] public ZendeskRequestInput Request { get; set; } = new();
}

/// <summary>Request input fields.</summary>
public class ZendeskRequestInput
{
    [JsonPropertyName("subject")] public string? Subject { get; set; }
    [JsonPropertyName("comment")] public TicketCommentInput? Comment { get; set; }
    [JsonPropertyName("priority")] public string? Priority { get; set; }
    [JsonPropertyName("type")] public string? Type { get; set; }
}

