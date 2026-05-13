using Elsa.Zendesk.Models;
using Refit;

namespace Elsa.Zendesk.Client.Api;

/// <summary>Refit interface for the Zendesk Macros API.</summary>
public interface IMacrosApi
{
    [Get("/api/v2/macros")]
    Task<ZendeskListResponse<Macro>> ListMacrosAsync([Query] int? page = null, [Query] int? per_page = null, [Query] bool? active = null, CancellationToken cancellationToken = default);

    [Get("/api/v2/macros/search")]
    Task<ZendeskListResponse<Macro>> SearchMacrosAsync([Query] string query, [Query] int? page = null, [Query] int? per_page = null, CancellationToken cancellationToken = default);

    [Post("/api/v2/macros")]
    Task<ZendeskResponse<Macro>> CreateMacroAsync([Body] CreateMacroRequest body, CancellationToken cancellationToken = default);

    [Get("/api/v2/macros/{macroId}")]
    Task<ZendeskResponse<Macro>> ShowMacroAsync(long macroId, CancellationToken cancellationToken = default);

    [Put("/api/v2/macros/{macroId}")]
    Task<ZendeskResponse<Macro>> UpdateMacroAsync(long macroId, [Body] UpdateMacroRequest body, CancellationToken cancellationToken = default);

    [Delete("/api/v2/macros/{macroId}")]
    Task DeleteMacroAsync(long macroId, CancellationToken cancellationToken = default);
}

/// <summary>Refit interface for the Zendesk Triggers API.</summary>
public interface ITriggersApi
{
    [Get("/api/v2/triggers")]
    Task<ZendeskListResponse<Trigger>> ListTriggersAsync([Query] int? page = null, [Query] int? per_page = null, [Query] bool? active = null, CancellationToken cancellationToken = default);

    [Get("/api/v2/triggers/search")]
    Task<ZendeskListResponse<Trigger>> SearchTriggersAsync([Query] string query, [Query] int? page = null, [Query] int? per_page = null, CancellationToken cancellationToken = default);

    [Post("/api/v2/triggers")]
    Task<ZendeskResponse<Trigger>> CreateTriggerAsync([Body] CreateTriggerRequest body, CancellationToken cancellationToken = default);

    [Get("/api/v2/triggers/{triggerId}")]
    Task<ZendeskResponse<Trigger>> ShowTriggerAsync(long triggerId, CancellationToken cancellationToken = default);

    [Put("/api/v2/triggers/{triggerId}")]
    Task<ZendeskResponse<Trigger>> UpdateTriggerAsync(long triggerId, [Body] UpdateTriggerRequest body, CancellationToken cancellationToken = default);

    [Delete("/api/v2/triggers/{triggerId}")]
    Task DeleteTriggerAsync(long triggerId, CancellationToken cancellationToken = default);

    [Get("/api/v2/trigger_categories")]
    Task<ZendeskListResponse<TriggerCategory>> ListTriggerCategoriesAsync([Query] int? page = null, [Query] int? per_page = null, CancellationToken cancellationToken = default);

    [Post("/api/v2/trigger_categories")]
    Task<ZendeskResponse<TriggerCategory>> CreateTriggerCategoryAsync([Body] TriggerCategoryRequest body, CancellationToken cancellationToken = default);

    [Patch("/api/v2/trigger_categories/{categoryId}")]
    Task<ZendeskResponse<TriggerCategory>> UpdateTriggerCategoryAsync(string categoryId, [Body] TriggerCategoryRequest body, CancellationToken cancellationToken = default);

    [Delete("/api/v2/trigger_categories/{categoryId}")]
    Task DeleteTriggerCategoryAsync(string categoryId, CancellationToken cancellationToken = default);
}

