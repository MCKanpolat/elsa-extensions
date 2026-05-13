using Elsa.Workflows.Attributes;
using Elsa.Workflows.Models;
using Elsa.Zendesk.Models;
using JetBrains.Annotations;

namespace Elsa.Zendesk.Activities.CustomStatuses;

[Activity("Elsa.Zendesk.CustomStatuses", "Zendesk Custom Statuses", "Lists custom ticket statuses.", DisplayName = "List Custom Statuses")]
[UsedImplicitly]
public class ListCustomStatuses : ZendeskActivity
{
    [Input(Description = "Filter by active status.")] public Input<bool?> Active { get; set; } = null!;
    [Output(Description = "List of custom statuses.")] public Output<ZendeskListResponse<CustomStatus>> Result { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var result = await GetClient(context).CustomStatuses.ListCustomStatusesAsync(context.Get(Active), context.CancellationToken);
        context.Set(Result, result);
    }
}

[Activity("Elsa.Zendesk.CustomStatuses", "Zendesk Custom Statuses", "Creates a custom ticket status.", DisplayName = "Create Custom Status")]
[UsedImplicitly]
public class CreateCustomStatus : ZendeskActivity
{
    [Input(Description = "Agent-facing label.")] public Input<string> AgentLabel { get; set; } = null!;
    [Input(Description = "Status category (new, open, pending, hold, solved).")] public Input<string> StatusCategory { get; set; } = null!;
    [Input(Description = "End-user-facing label.")] public Input<string?> EndUserLabel { get; set; } = null!;
    [Output(Description = "The created custom status.")] public Output<CustomStatus?> CustomStatus { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var request = new CreateCustomStatusRequest
        {
            CustomStatus = new CustomStatusInput
            {
                AgentLabel = context.Get(AgentLabel),
                StatusCategory = context.Get(StatusCategory),
                EndUserLabel = context.Get(EndUserLabel)
            }
        };
        var response = await GetClient(context).CustomStatuses.CreateCustomStatusAsync(request, context.CancellationToken);
        context.Set(CustomStatus, response.CustomStatus);
    }
}

[Activity("Elsa.Zendesk.CustomStatuses", "Zendesk Custom Statuses", "Gets a custom status by ID.", DisplayName = "Get Custom Status")]
[UsedImplicitly]
public class GetCustomStatus : ZendeskActivity
{
    [Input(Description = "The ID of the custom status.")] public Input<long> CustomStatusId { get; set; } = null!;
    [Output(Description = "The custom status.")] public Output<CustomStatus?> CustomStatus { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var response = await GetClient(context).CustomStatuses.ShowCustomStatusAsync(context.Get(CustomStatusId), context.CancellationToken);
        context.Set(CustomStatus, response.CustomStatus);
    }
}

[Activity("Elsa.Zendesk.CustomStatuses", "Zendesk Custom Statuses", "Updates a custom status.", DisplayName = "Update Custom Status")]
[UsedImplicitly]
public class UpdateCustomStatus : ZendeskActivity
{
    [Input(Description = "The ID of the custom status.")] public Input<long> CustomStatusId { get; set; } = null!;
    [Input(Description = "New agent-facing label.")] public Input<string?> AgentLabel { get; set; } = null!;
    [Input(Description = "Active status.")] public Input<bool?> Active { get; set; } = null!;
    [Output(Description = "The updated custom status.")] public Output<CustomStatus?> CustomStatus { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var request = new UpdateCustomStatusRequest { CustomStatus = new CustomStatusInput { AgentLabel = context.Get(AgentLabel), Active = context.Get(Active) } };
        var response = await GetClient(context).CustomStatuses.UpdateCustomStatusAsync(context.Get(CustomStatusId), request, context.CancellationToken);
        context.Set(CustomStatus, response.CustomStatus);
    }
}

