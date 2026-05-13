using Elsa.Zendesk.Models;
using Refit;

namespace Elsa.Zendesk.Client.Api;

/// <summary>Refit interface for the Zendesk Tags API.</summary>
public interface ITagsApi
{
    [Get("/api/v2/tags")]
    Task<ZendeskListResponse<string>> ListTagsAsync([Query] int? page = null, [Query] int? per_page = null, CancellationToken cancellationToken = default);
}

/// <summary>Refit interface for the Zendesk Bookmarks API.</summary>
public interface IBookmarksApi
{
    [Get("/api/v2/bookmarks")]
    Task<ZendeskListResponse<ZendeskBookmark>> ListBookmarksAsync([Query] int? page = null, [Query] int? per_page = null, CancellationToken cancellationToken = default);

    [Post("/api/v2/bookmarks")]
    Task<ZendeskResponse<ZendeskBookmark>> CreateBookmarkAsync([Body] CreateBookmarkRequest body, CancellationToken cancellationToken = default);

    [Delete("/api/v2/bookmarks/{bookmarkId}")]
    Task DeleteBookmarkAsync(long bookmarkId, CancellationToken cancellationToken = default);
}

/// <summary>Refit interface for the Zendesk SLA Policies API.</summary>
public interface ISlaPoliciesApi
{
    [Get("/api/v2/slas/policies")]
    Task<ZendeskListResponse<SlaPolicy>> ListSlaPoliciesAsync(CancellationToken cancellationToken = default);

    [Post("/api/v2/slas/policies")]
    Task<ZendeskResponse<SlaPolicy>> CreateSlaPolicyAsync([Body] CreateSlaPolicyRequest body, CancellationToken cancellationToken = default);

    [Get("/api/v2/slas/policies/{slaPolicyId}")]
    Task<ZendeskResponse<SlaPolicy>> ShowSlaPolicyAsync(long slaPolicyId, CancellationToken cancellationToken = default);

    [Put("/api/v2/slas/policies/{slaPolicyId}")]
    Task<ZendeskResponse<SlaPolicy>> UpdateSlaPolicyAsync(long slaPolicyId, [Body] UpdateSlaPolicyRequest body, CancellationToken cancellationToken = default);

    [Delete("/api/v2/slas/policies/{slaPolicyId}")]
    Task DeleteSlaPolicyAsync(long slaPolicyId, CancellationToken cancellationToken = default);
}

/// <summary>Refit interface for the Zendesk Custom Ticket Statuses API.</summary>
public interface ICustomStatusesApi
{
    [Get("/api/v2/custom_statuses")]
    Task<ZendeskListResponse<CustomStatus>> ListCustomStatusesAsync([Query] bool? active = null, CancellationToken cancellationToken = default);

    [Post("/api/v2/custom_statuses")]
    Task<ZendeskResponse<CustomStatus>> CreateCustomStatusAsync([Body] CreateCustomStatusRequest body, CancellationToken cancellationToken = default);

    [Get("/api/v2/custom_statuses/{customStatusId}")]
    Task<ZendeskResponse<CustomStatus>> ShowCustomStatusAsync(long customStatusId, CancellationToken cancellationToken = default);

    [Patch("/api/v2/custom_statuses/{customStatusId}")]
    Task<ZendeskResponse<CustomStatus>> UpdateCustomStatusAsync(long customStatusId, [Body] UpdateCustomStatusRequest body, CancellationToken cancellationToken = default);
}

/// <summary>Refit interface for the Zendesk Dynamic Content API.</summary>
public interface IDynamicContentApi
{
    [Get("/api/v2/dynamic_content/items")]
    Task<ZendeskListResponse<DynamicContentItem>> ListDynamicContentItemsAsync([Query] int? page = null, [Query] int? per_page = null, CancellationToken cancellationToken = default);

    [Post("/api/v2/dynamic_content/items")]
    Task<DynamicContentItemResponse> CreateDynamicContentItemAsync([Body] CreateDynamicContentItemRequest body, CancellationToken cancellationToken = default);

    [Get("/api/v2/dynamic_content/items/{itemId}")]
    Task<DynamicContentItemResponse> ShowDynamicContentItemAsync(long itemId, CancellationToken cancellationToken = default);

    [Put("/api/v2/dynamic_content/items/{itemId}")]
    Task<DynamicContentItemResponse> UpdateDynamicContentItemAsync(long itemId, [Body] UpdateDynamicContentItemRequest body, CancellationToken cancellationToken = default);

    [Delete("/api/v2/dynamic_content/items/{itemId}")]
    Task DeleteDynamicContentItemAsync(long itemId, CancellationToken cancellationToken = default);
}

/// <summary>Refit interface for the Zendesk Locales API.</summary>
public interface ILocalesApi
{
    [Get("/api/v2/locales")]
    Task<ZendeskListResponse<Locale>> ListLocalesAsync(CancellationToken cancellationToken = default);

    [Get("/api/v2/locales/{localeId}")]
    Task<ZendeskResponse<Locale>> ShowLocaleAsync(long localeId, CancellationToken cancellationToken = default);
}

/// <summary>Refit interface for the Zendesk Targets API.</summary>
public interface ITargetsApi
{
    [Get("/api/v2/targets")]
    Task<ZendeskListResponse<Target>> ListTargetsAsync(CancellationToken cancellationToken = default);

    [Delete("/api/v2/targets/{targetId}")]
    Task DeleteTargetAsync(long targetId, CancellationToken cancellationToken = default);
}

/// <summary>Refit interface for the Zendesk Requests (End-User) API.</summary>
public interface IRequestsApi
{
    [Get("/api/v2/requests")]
    Task<ZendeskListResponse<ZendeskRequest>> ListRequestsAsync([Query] string? status = null, [Query] int? page = null, [Query] int? per_page = null, CancellationToken cancellationToken = default);

    [Get("/api/v2/requests/search")]
    Task<ZendeskListResponse<ZendeskRequest>> SearchRequestsAsync([Query] string query, CancellationToken cancellationToken = default);

    [Post("/api/v2/requests")]
    Task<ZendeskResponse<ZendeskRequest>> CreateRequestAsync([Body] CreateZendeskRequestBody body, CancellationToken cancellationToken = default);

    [Get("/api/v2/requests/{requestId}")]
    Task<ZendeskResponse<ZendeskRequest>> ShowRequestAsync(long requestId, CancellationToken cancellationToken = default);

    [Put("/api/v2/requests/{requestId}")]
    Task<ZendeskResponse<ZendeskRequest>> UpdateRequestAsync(long requestId, [Body] CreateZendeskRequestBody body, CancellationToken cancellationToken = default);
}

