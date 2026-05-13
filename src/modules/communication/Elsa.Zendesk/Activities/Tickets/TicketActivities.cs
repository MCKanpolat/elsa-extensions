using Elsa.Workflows.Attributes;
using Elsa.Workflows.Models;
using Elsa.Zendesk.Models;
using JetBrains.Annotations;

namespace Elsa.Zendesk.Activities.Tickets;

/// <summary>Retrieves a single Zendesk ticket by ID.</summary>
[Activity("Elsa.Zendesk.Tickets", "Zendesk Tickets", "Gets a Zendesk ticket by ID.", DisplayName = "Get Ticket")]
[UsedImplicitly]
public class GetTicket : ZendeskActivity
{
    /// <summary>The ID of the ticket to retrieve.</summary>
    [Input(Description = "The ID of the ticket to retrieve.")]
    public Input<long> TicketId { get; set; } = null!;

    /// <summary>The retrieved ticket.</summary>
    [Output(Description = "The retrieved Zendesk ticket.")]
    public Output<Ticket?> Ticket { get; set; } = null!;

    /// <inheritdoc />
    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var ticketId = context.Get(TicketId);
        var response = await GetClient(context).Tickets.ShowTicketAsync(ticketId, context.CancellationToken);
        context.Set(Ticket, response.Ticket);
    }
}

/// <summary>Lists Zendesk tickets with optional pagination.</summary>
[Activity("Elsa.Zendesk.Tickets", "Zendesk Tickets", "Lists Zendesk tickets.", DisplayName = "List Tickets")]
[UsedImplicitly]
public class ListTickets : ZendeskActivity
{
    /// <summary>Page number (1-based).</summary>
    [Input(Description = "The page number (1-based).")]
    public Input<int?> Page { get; set; } = null!;

    /// <summary>Number of results per page (max 100).</summary>
    [Input(Description = "Number of results per page (max 100).")]
    public Input<int?> PageSize { get; set; } = null!;

    /// <summary>Paged list of tickets.</summary>
    [Output(Description = "Paged list of tickets.")]
    public Output<ZendeskListResponse<Ticket>> Result { get; set; } = null!;

    /// <inheritdoc />
    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var result = await GetClient(context).Tickets.ListTicketsAsync(context.Get(Page), context.Get(PageSize), context.CancellationToken);
        context.Set(Result, result);
    }
}

/// <summary>Updates a Zendesk ticket.</summary>
[Activity("Elsa.Zendesk.Tickets", "Zendesk Tickets", "Updates an existing Zendesk ticket.", DisplayName = "Update Ticket")]
[UsedImplicitly]
public class UpdateTicket : ZendeskActivity
{
    /// <summary>The ID of the ticket to update.</summary>
    [Input(Description = "The ID of the ticket to update.")]
    public Input<long> TicketId { get; set; } = null!;

    /// <summary>New subject for the ticket.</summary>
    [Input(Description = "New subject for the ticket.")]
    public Input<string?> Subject { get; set; } = null!;

    /// <summary>New status (open, pending, hold, solved, closed).</summary>
    [Input(Description = "New status (open, pending, hold, solved, closed).")]
    public Input<string?> Status { get; set; } = null!;

    /// <summary>New priority (urgent, high, normal, low).</summary>
    [Input(Description = "New priority (urgent, high, normal, low).")]
    public Input<string?> Priority { get; set; } = null!;

    /// <summary>New assignee user ID.</summary>
    [Input(Description = "New assignee user ID.")]
    public Input<long?> AssigneeId { get; set; } = null!;

    /// <summary>New group ID.</summary>
    [Input(Description = "New group ID.")]
    public Input<long?> GroupId { get; set; } = null!;

    /// <summary>Optional comment to add when updating the ticket.</summary>
    [Input(Description = "Optional comment to add when updating the ticket.")]
    public Input<string?> Comment { get; set; } = null!;

    /// <summary>Whether the comment is public.</summary>
    [Input(Description = "Whether the comment is public (default: true).")]
    public Input<bool?> CommentPublic { get; set; } = null!;

    /// <summary>The updated ticket.</summary>
    [Output(Description = "The updated ticket.")]
    public Output<Ticket?> Ticket { get; set; } = null!;

    /// <inheritdoc />
    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var ticketId = context.Get(TicketId);
        var commentBody = context.Get(Comment);

        var input = new TicketInput
        {
            Subject = context.Get(Subject),
            Status = context.Get(Status),
            Priority = context.Get(Priority),
            AssigneeId = context.Get(AssigneeId),
            GroupId = context.Get(GroupId)
        };

        if (!string.IsNullOrEmpty(commentBody))
            input.Comment = new TicketCommentInput { Body = commentBody, Public = context.Get(CommentPublic) ?? true };

        var response = await GetClient(context).Tickets.UpdateTicketAsync(ticketId, new UpdateTicketRequest { Ticket = input }, context.CancellationToken);
        context.Set(Ticket, response.Ticket);
    }
}

/// <summary>Deletes a Zendesk ticket (moves to trash).</summary>
[Activity("Elsa.Zendesk.Tickets", "Zendesk Tickets", "Deletes a Zendesk ticket (moves it to the trash).", DisplayName = "Delete Ticket")]
[UsedImplicitly]
public class DeleteTicket : ZendeskActivity
{
    /// <summary>The ID of the ticket to delete.</summary>
    [Input(Description = "The ID of the ticket to delete.")]
    public Input<long> TicketId { get; set; } = null!;

    /// <inheritdoc />
    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context) =>
        await GetClient(context).Tickets.DeleteTicketAsync(context.Get(TicketId), context.CancellationToken);
}

/// <summary>Lists comments on a Zendesk ticket.</summary>
[Activity("Elsa.Zendesk.Tickets", "Zendesk Tickets", "Lists comments on a Zendesk ticket.", DisplayName = "List Ticket Comments")]
[UsedImplicitly]
public class ListTicketComments : ZendeskActivity
{
    /// <summary>The ticket ID whose comments to fetch.</summary>
    [Input(Description = "The ID of the ticket.")]
    public Input<long> TicketId { get; set; } = null!;

    /// <summary>Page number.</summary>
    [Input(Description = "The page number.")]
    public Input<int?> Page { get; set; } = null!;

    /// <summary>Results per page.</summary>
    [Input(Description = "Number of results per page.")]
    public Input<int?> PageSize { get; set; } = null!;

    /// <summary>The paged list of comments.</summary>
    [Output(Description = "Paged list of ticket comments.")]
    public Output<ZendeskListResponse<TicketComment>> Result { get; set; } = null!;

    /// <inheritdoc />
    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var result = await GetClient(context).Tickets.ListTicketCommentsAsync(context.Get(TicketId), context.Get(Page), context.Get(PageSize), context.CancellationToken);
        context.Set(Result, result);
    }
}

/// <summary>Gets metrics for a Zendesk ticket.</summary>
[Activity("Elsa.Zendesk.Tickets", "Zendesk Tickets", "Gets metrics for a Zendesk ticket.", DisplayName = "Get Ticket Metrics")]
[UsedImplicitly]
public class GetTicketMetrics : ZendeskActivity
{
    /// <summary>The ticket ID.</summary>
    [Input(Description = "The ID of the ticket.")]
    public Input<long> TicketId { get; set; } = null!;

    /// <summary>The ticket metrics.</summary>
    [Output(Description = "The ticket metrics.")]
    public Output<TicketMetrics?> Metrics { get; set; } = null!;

    /// <inheritdoc />
    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var response = await GetClient(context).Tickets.ShowTicketMetricsAsync(context.Get(TicketId), context.CancellationToken);
        context.Set(Metrics, response.Ticket);
    }
}

