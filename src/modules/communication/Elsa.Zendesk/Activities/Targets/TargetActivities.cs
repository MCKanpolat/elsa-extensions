using Elsa.Workflows.Attributes;
using Elsa.Workflows.Models;
using Elsa.Zendesk.Models;
using JetBrains.Annotations;

namespace Elsa.Zendesk.Activities.Targets;

[Activity("Elsa.Zendesk.Targets", "Zendesk Targets", "Lists outbound notification targets.", DisplayName = "List Targets")]
[UsedImplicitly]
public class ListTargets : ZendeskActivity
{
    [Output(Description = "List of targets.")] public Output<ZendeskListResponse<Target>> Result { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var result = await GetClient(context).Targets.ListTargetsAsync(context.CancellationToken);
        context.Set(Result, result);
    }
}

[Activity("Elsa.Zendesk.Targets", "Zendesk Targets", "Deletes a target.", DisplayName = "Delete Target")]
[UsedImplicitly]
public class DeleteTarget : ZendeskActivity
{
    [Input(Description = "The ID of the target to delete.")] public Input<long> TargetId { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context) =>
        await GetClient(context).Targets.DeleteTargetAsync(context.Get(TargetId), context.CancellationToken);
}

