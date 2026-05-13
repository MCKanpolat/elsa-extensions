using Elsa.Zendesk.Models;
using Refit;

namespace Elsa.Zendesk.Client.Api;

/// <summary>Refit interface for the Zendesk Organizations API.</summary>
public interface IOrganizationsApi
{
    [Get("/api/v2/organizations")]
    Task<ZendeskListResponse<Organization>> ListOrganizationsAsync([Query] int? page = null, [Query] int? per_page = null, CancellationToken cancellationToken = default);

    [Get("/api/v2/organizations/search")]
    Task<ZendeskListResponse<Organization>> SearchOrganizationsAsync([Query] string query, [Query] int? page = null, [Query] int? per_page = null, CancellationToken cancellationToken = default);

    [Post("/api/v2/organizations")]
    Task<ZendeskResponse<Organization>> CreateOrganizationAsync([Body] CreateOrganizationRequest body, CancellationToken cancellationToken = default);

    [Get("/api/v2/organizations/{organizationId}")]
    Task<ZendeskResponse<Organization>> ShowOrganizationAsync(long organizationId, CancellationToken cancellationToken = default);

    [Put("/api/v2/organizations/{organizationId}")]
    Task<ZendeskResponse<Organization>> UpdateOrganizationAsync(long organizationId, [Body] UpdateOrganizationRequest body, CancellationToken cancellationToken = default);

    [Delete("/api/v2/organizations/{organizationId}")]
    Task DeleteOrganizationAsync(long organizationId, CancellationToken cancellationToken = default);
}

