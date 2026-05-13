using Elsa.Workflows.Attributes;
using Elsa.Workflows.Models;
using Elsa.Zendesk.Models;
using JetBrains.Annotations;

namespace Elsa.Zendesk.Activities.Automations;

[Activity("Elsa.Zendesk.Automations", "Zendesk Automations", "Creates an automation.", DisplayName = "Create Automation")]
[UsedImplicitly]
public class CreateAutomation : ZendeskActivity
{
    [Input(Description = "The title of the automation.")] public Input<string> Title { get; set; } = null!;
    [Output(Description = "The created automation.")] public Output<Automation?> Automation { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var request = new CreateAutomationRequest { Automation = new AutomationInput { Title = context.Get(Title) } };
        var response = await GetClient(context).Automations.CreateAutomationAsync(request, context.CancellationToken);
        context.Set(Automation, response.Automation);
    }
}

[Activity("Elsa.Zendesk.Automations", "Zendesk Automations", "Gets an automation by ID.", DisplayName = "Get Automation")]
[UsedImplicitly]
public class GetAutomation : ZendeskActivity
{
    [Input(Description = "The ID of the automation.")] public Input<long> AutomationId { get; set; } = null!;
    [Output(Description = "The automation.")] public Output<Automation?> Automation { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var response = await GetClient(context).Automations.ShowAutomationAsync(context.Get(AutomationId), context.CancellationToken);
        context.Set(Automation, response.Automation);
    }
}

[Activity("Elsa.Zendesk.Automations", "Zendesk Automations", "Lists automations.", DisplayName = "List Automations")]
[UsedImplicitly]
public class ListAutomations : ZendeskActivity
{
    [Input(Description = "Page number.")] public Input<int?> Page { get; set; } = null!;
    [Input(Description = "Results per page.")] public Input<int?> PageSize { get; set; } = null!;
    [Output(Description = "Paged list of automations.")] public Output<ZendeskListResponse<Automation>> Result { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var result = await GetClient(context).Automations.ListAutomationsAsync(context.Get(Page), context.Get(PageSize), cancellationToken: context.CancellationToken);
        context.Set(Result, result);
    }
}

[Activity("Elsa.Zendesk.Automations", "Zendesk Automations", "Updates an automation.", DisplayName = "Update Automation")]
[UsedImplicitly]
public class UpdateAutomation : ZendeskActivity
{
    [Input(Description = "The ID of the automation.")] public Input<long> AutomationId { get; set; } = null!;
    [Input(Description = "New title.")] public Input<string?> Title { get; set; } = null!;
    [Input(Description = "Active status.")] public Input<bool?> Active { get; set; } = null!;
    [Output(Description = "The updated automation.")] public Output<Automation?> Automation { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var request = new UpdateAutomationRequest { Automation = new AutomationInput { Title = context.Get(Title), Active = context.Get(Active) } };
        var response = await GetClient(context).Automations.UpdateAutomationAsync(context.Get(AutomationId), request, context.CancellationToken);
        context.Set(Automation, response.Automation);
    }
}

[Activity("Elsa.Zendesk.Automations", "Zendesk Automations", "Deletes an automation.", DisplayName = "Delete Automation")]
[UsedImplicitly]
public class DeleteAutomation : ZendeskActivity
{
    [Input(Description = "The ID of the automation to delete.")] public Input<long> AutomationId { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context) =>
        await GetClient(context).Automations.DeleteAutomationAsync(context.Get(AutomationId), context.CancellationToken);
}

