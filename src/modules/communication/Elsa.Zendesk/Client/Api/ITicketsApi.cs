using Elsa.Zendesk.Models;
using Refit;

namespace Elsa.Zendesk.Client.Api;

/// <summary>Refit interface for the Zendesk Tickets API.</summary>
public interface ITicketsApi
{
    [Get("/api/v2/tickets")]
    Task<ZendeskListResponse<Ticket>> ListTicketsAsync([Query] int? page = null, [Query] int? per_page = null, CancellationToken cancellationToken = default);

    [Post("/api/v2/tickets")]
    Task<ZendeskResponse<Ticket>> CreateTicketAsync([Body] CreateTicketRequest body, CancellationToken cancellationToken = default);

    [Get("/api/v2/tickets/{ticketId}")]
    Task<ZendeskResponse<Ticket>> ShowTicketAsync(long ticketId, CancellationToken cancellationToken = default);

    [Put("/api/v2/tickets/{ticketId}")]
    Task<ZendeskResponse<Ticket>> UpdateTicketAsync(long ticketId, [Body] UpdateTicketRequest body, CancellationToken cancellationToken = default);

    [Delete("/api/v2/tickets/{ticketId}")]
    Task DeleteTicketAsync(long ticketId, CancellationToken cancellationToken = default);

    [Delete("/api/v2/deleted_tickets/{ticketId}")]
    Task DeleteTicketPermanentlyAsync(long ticketId, CancellationToken cancellationToken = default);

    [Get("/api/v2/tickets/{ticketId}/comments")]
    Task<ZendeskListResponse<TicketComment>> ListTicketCommentsAsync(long ticketId, [Query] int? page = null, [Query] int? per_page = null, CancellationToken cancellationToken = default);

    [Get("/api/v2/tickets/{ticketId}/audits")]
    Task<ZendeskListResponse<TicketAudit>> ListTicketAuditsAsync(long ticketId, CancellationToken cancellationToken = default);

    [Get("/api/v2/tickets/{ticketId}/audits/{auditId}")]
    Task<ZendeskResponse<TicketAudit>> ShowTicketAuditAsync(long ticketId, long auditId, CancellationToken cancellationToken = default);

    [Get("/api/v2/tickets/{ticketId}/metrics")]
    Task<ZendeskResponse<TicketMetrics>> ShowTicketMetricsAsync(long ticketId, CancellationToken cancellationToken = default);
}

