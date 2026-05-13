using Elsa.Zendesk.Models;
using Refit;

namespace Elsa.Zendesk.Client.Api;

/// <summary>Refit interface for the Zendesk Search API.</summary>
public interface ISearchApi
{
    [Get("/api/v2/search")]
    Task<ZendeskListResponse<SearchResult>> SearchAsync([Query] string query, [Query] string? sort_by = null, [Query] string? sort_order = null, [Query] int? page = null, [Query] int? per_page = null, CancellationToken cancellationToken = default);
}

/// <summary>Refit interface for the Zendesk Satisfaction Ratings API.</summary>
public interface ISatisfactionRatingsApi
{
    [Get("/api/v2/satisfaction_ratings")]
    Task<ZendeskListResponse<SatisfactionRating>> ListSatisfactionRatingsAsync([Query] string? score = null, [Query] int? page = null, [Query] int? per_page = null, CancellationToken cancellationToken = default);

    [Get("/api/v2/satisfaction_ratings/{satisfactionRatingId}")]
    Task<ZendeskResponse<SatisfactionRating>> ShowSatisfactionRatingAsync(long satisfactionRatingId, CancellationToken cancellationToken = default);

    [Post("/api/v2/tickets/{ticketId}/satisfaction_rating")]
    Task<ZendeskResponse<SatisfactionRating>> CreateSatisfactionRatingAsync(long ticketId, [Body] CreateSatisfactionRatingRequest body, CancellationToken cancellationToken = default);
}

/// <summary>Refit interface for the Zendesk Audit Logs API.</summary>
public interface IAuditLogsApi
{
    [Get("/api/v2/audit_logs")]
    Task<ZendeskListResponse<AuditLog>> ListAuditLogsAsync([Query] int? page = null, [Query] int? per_page = null, CancellationToken cancellationToken = default);

    [Get("/api/v2/audit_logs/{auditLogId}")]
    Task<ZendeskResponse<AuditLog>> ShowAuditLogAsync(long auditLogId, CancellationToken cancellationToken = default);
}

/// <summary>Refit interface for the Zendesk Account Settings API.</summary>
public interface IAccountApi
{
    [Get("/api/v2/account/settings")]
    Task<AccountSettingsResponse> ShowAccountSettingsAsync(CancellationToken cancellationToken = default);

    [Put("/api/v2/account/settings")]
    Task<AccountSettingsResponse> UpdateAccountSettingsAsync([Body] UpdateAccountSettingsRequest body, CancellationToken cancellationToken = default);
}

