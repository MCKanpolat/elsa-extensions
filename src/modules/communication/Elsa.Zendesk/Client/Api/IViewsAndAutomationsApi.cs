using Elsa.Zendesk.Models;
using Refit;

namespace Elsa.Zendesk.Client.Api;

/// <summary>Refit interface for the Zendesk Views API.</summary>
public interface IViewsApi
{
    [Get("/api/v2/views")]
    Task<ZendeskListResponse<View>> ListViewsAsync([Query] int? page = null, [Query] int? per_page = null, [Query] bool? active = null, CancellationToken cancellationToken = default);

    [Get("/api/v2/views/search")]
    Task<ZendeskListResponse<View>> SearchViewsAsync([Query] string query, CancellationToken cancellationToken = default);

    [Post("/api/v2/views")]
    Task<ZendeskResponse<View>> CreateViewAsync([Body] CreateViewRequest body, CancellationToken cancellationToken = default);

    [Get("/api/v2/views/{viewId}")]
    Task<ZendeskResponse<View>> ShowViewAsync(long viewId, CancellationToken cancellationToken = default);

    [Put("/api/v2/views/{viewId}")]
    Task<ZendeskResponse<View>> UpdateViewAsync(long viewId, [Body] UpdateViewRequest body, CancellationToken cancellationToken = default);

    [Delete("/api/v2/views/{viewId}")]
    Task DeleteViewAsync(long viewId, CancellationToken cancellationToken = default);

    [Get("/api/v2/views/{viewId}/tickets")]
    Task<ZendeskListResponse<Ticket>> ListViewTicketsAsync(long viewId, [Query] int? page = null, [Query] int? per_page = null, CancellationToken cancellationToken = default);
}

/// <summary>Refit interface for the Zendesk Automations API.</summary>
public interface IAutomationsApi
{
    [Get("/api/v2/automations")]
    Task<ZendeskListResponse<Automation>> ListAutomationsAsync([Query] int? page = null, [Query] int? per_page = null, [Query] bool? active = null, CancellationToken cancellationToken = default);

    [Post("/api/v2/automations")]
    Task<ZendeskResponse<Automation>> CreateAutomationAsync([Body] CreateAutomationRequest body, CancellationToken cancellationToken = default);

    [Get("/api/v2/automations/{automationId}")]
    Task<ZendeskResponse<Automation>> ShowAutomationAsync(long automationId, CancellationToken cancellationToken = default);

    [Put("/api/v2/automations/{automationId}")]
    Task<ZendeskResponse<Automation>> UpdateAutomationAsync(long automationId, [Body] UpdateAutomationRequest body, CancellationToken cancellationToken = default);

    [Delete("/api/v2/automations/{automationId}")]
    Task DeleteAutomationAsync(long automationId, CancellationToken cancellationToken = default);
}

