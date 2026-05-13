using Elsa.Workflows.Attributes;
using Elsa.Workflows.Models;
using Elsa.Zendesk.Models;
using JetBrains.Annotations;

namespace Elsa.Zendesk.Activities.SlaPolicies;

[Activity("Elsa.Zendesk.SlaPolicies", "Zendesk SLA Policies", "Lists SLA policies.", DisplayName = "List SLA Policies")]
[UsedImplicitly]
public class ListSlaPolicies : ZendeskActivity
{
    [Output(Description = "List of SLA policies.")] public Output<ZendeskListResponse<SlaPolicy>> Result { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var result = await GetClient(context).SlaPolicies.ListSlaPoliciesAsync(context.CancellationToken);
        context.Set(Result, result);
    }
}

[Activity("Elsa.Zendesk.SlaPolicies", "Zendesk SLA Policies", "Creates an SLA policy.", DisplayName = "Create SLA Policy")]
[UsedImplicitly]
public class CreateSlaPolicy : ZendeskActivity
{
    [Input(Description = "Title of the SLA policy.")] public Input<string> Title { get; set; } = null!;
    [Output(Description = "The created SLA policy.")] public Output<SlaPolicy?> SlaPolicy { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var request = new CreateSlaPolicyRequest { SlaPolicy = new SlaPolicyInput { Title = context.Get(Title) } };
        var response = await GetClient(context).SlaPolicies.CreateSlaPolicyAsync(request, context.CancellationToken);
        context.Set(SlaPolicy, response.SlaPolicy);
    }
}

[Activity("Elsa.Zendesk.SlaPolicies", "Zendesk SLA Policies", "Gets an SLA policy by ID.", DisplayName = "Get SLA Policy")]
[UsedImplicitly]
public class GetSlaPolicy : ZendeskActivity
{
    [Input(Description = "The ID of the SLA policy.")] public Input<long> SlaPolicyId { get; set; } = null!;
    [Output(Description = "The SLA policy.")] public Output<SlaPolicy?> SlaPolicy { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var response = await GetClient(context).SlaPolicies.ShowSlaPolicyAsync(context.Get(SlaPolicyId), context.CancellationToken);
        context.Set(SlaPolicy, response.SlaPolicy);
    }
}

[Activity("Elsa.Zendesk.SlaPolicies", "Zendesk SLA Policies", "Deletes an SLA policy.", DisplayName = "Delete SLA Policy")]
[UsedImplicitly]
public class DeleteSlaPolicy : ZendeskActivity
{
    [Input(Description = "The ID of the SLA policy to delete.")] public Input<long> SlaPolicyId { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context) =>
        await GetClient(context).SlaPolicies.DeleteSlaPolicyAsync(context.Get(SlaPolicyId), context.CancellationToken);
}

