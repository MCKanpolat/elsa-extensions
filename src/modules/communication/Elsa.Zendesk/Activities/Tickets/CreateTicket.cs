using Elsa.Workflows.Attributes;
using Elsa.Workflows.Models;
using Elsa.Zendesk.Models;
using JetBrains.Annotations;

namespace Elsa.Zendesk.Activities.Tickets;

/// <summary>Creates a new Zendesk ticket.</summary>
[Activity("Elsa.Zendesk.Tickets", "Zendesk Tickets", "Creates a new Zendesk ticket.", DisplayName = "Create Ticket")]
[UsedImplicitly]
public class CreateTicket : ZendeskActivity
{
    /// <summary>Subject of the ticket.</summary>
    [Input(Description = "The subject of the ticket.")]
    public Input<string> Subject { get; set; } = null!;

    /// <summary>The initial comment / description body.</summary>
    [Input(Description = "The body of the initial ticket comment.")]
    public Input<string> CommentBody { get; set; } = null!;

    /// <summary>Optional requester user ID.</summary>
    [Input(Description = "The ID of the requester.")]
    public Input<long?> RequesterId { get; set; } = null!;

    /// <summary>Optional assignee user ID.</summary>
    [Input(Description = "The ID of the assignee.")]
    public Input<long?> AssigneeId { get; set; } = null!;

    /// <summary>Optional group ID.</summary>
    [Input(Description = "The ID of the group.")]
    public Input<long?> GroupId { get; set; } = null!;

    /// <summary>Ticket priority (urgent, high, normal, low).</summary>
    [Input(Description = "The ticket priority (urgent, high, normal, low).")]
    public Input<string?> Priority { get; set; } = null!;

    /// <summary>Ticket type (problem, incident, question, task).</summary>
    [Input(Description = "The ticket type (problem, incident, question, task).")]
    public Input<string?> Type { get; set; } = null!;

    /// <summary>The created ticket.</summary>
    [Output(Description = "The created Zendesk ticket.")]
    public Output<Ticket?> Ticket { get; set; } = null!;

    /// <inheritdoc />
    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var client = GetClient(context);
        var request = new CreateTicketRequest
        {
            Ticket = new TicketInput
            {
                Subject = context.Get(Subject),
                Comment = new TicketCommentInput { Body = context.Get(CommentBody) },
                RequesterId = context.Get(RequesterId),
                AssigneeId = context.Get(AssigneeId),
                GroupId = context.Get(GroupId),
                Priority = context.Get(Priority),
                Type = context.Get(Type)
            }
        };

        var response = await client.Tickets.CreateTicketAsync(request, context.CancellationToken);
        context.Set(Ticket, response.Ticket);
    }
}

