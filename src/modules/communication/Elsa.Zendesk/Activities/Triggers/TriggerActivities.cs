using Elsa.Workflows.Attributes;
using Elsa.Workflows.Models;
using Elsa.Zendesk.Models;
using JetBrains.Annotations;

namespace Elsa.Zendesk.Activities.Triggers;

[Activity("Elsa.Zendesk.Triggers", "Zendesk Triggers", "Creates a new trigger.", DisplayName = "Create Trigger")]
[UsedImplicitly]
public class CreateTrigger : ZendeskActivity
{
    [Input(Description = "Title of the trigger.")] public Input<string> Title { get; set; } = null!;
    [Output(Description = "The created trigger.")] public Output<Trigger?> Trigger { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var request = new CreateTriggerRequest { Trigger = new ZendeskTriggerInput { Title = context.Get(Title) } };
        var response = await GetClient(context).Triggers.CreateTriggerAsync(request, context.CancellationToken);
        context.Set(Trigger, response.Trigger);
    }
}

[Activity("Elsa.Zendesk.Triggers", "Zendesk Triggers", "Lists triggers.", DisplayName = "List Triggers")]
[UsedImplicitly]
public class ListTriggers : ZendeskActivity
{
    [Input(Description = "Page number.")] public Input<int?> Page { get; set; } = null!;
    [Input(Description = "Results per page.")] public Input<int?> PageSize { get; set; } = null!;
    [Output(Description = "Paged list of triggers.")] public Output<ZendeskListResponse<Trigger>> Result { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var result = await GetClient(context).Triggers.ListTriggersAsync(context.Get(Page), context.Get(PageSize), cancellationToken: context.CancellationToken);
        context.Set(Result, result);
    }
}

[Activity("Elsa.Zendesk.Triggers", "Zendesk Triggers", "Updates a trigger.", DisplayName = "Update Trigger")]
[UsedImplicitly]
public class UpdateTrigger : ZendeskActivity
{
    [Input(Description = "The ID of the trigger.")] public Input<long> TriggerId { get; set; } = null!;
    [Input(Description = "New title.")] public Input<string?> Title { get; set; } = null!;
    [Input(Description = "Active status.")] public Input<bool?> Active { get; set; } = null!;
    [Output(Description = "The updated trigger.")] public Output<Trigger?> Trigger { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var request = new UpdateTriggerRequest { Trigger = new ZendeskTriggerInput { Title = context.Get(Title), Active = context.Get(Active) } };
        var response = await GetClient(context).Triggers.UpdateTriggerAsync(context.Get(TriggerId), request, context.CancellationToken);
        context.Set(Trigger, response.Trigger);
    }
}

[Activity("Elsa.Zendesk.Triggers", "Zendesk Triggers", "Deletes a trigger.", DisplayName = "Delete Trigger")]
[UsedImplicitly]
public class DeleteTrigger : ZendeskActivity
{
    [Input(Description = "The ID of the trigger to delete.")] public Input<long> TriggerId { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context) =>
        await GetClient(context).Triggers.DeleteTriggerAsync(context.Get(TriggerId), context.CancellationToken);
}

[Activity("Elsa.Zendesk.Triggers", "Zendesk Triggers", "Lists trigger categories.", DisplayName = "List Trigger Categories")]
[UsedImplicitly]
public class ListTriggerCategories : ZendeskActivity
{
    [Input(Description = "Page number.")] public Input<int?> Page { get; set; } = null!;
    [Input(Description = "Results per page.")] public Input<int?> PageSize { get; set; } = null!;
    [Output(Description = "Paged list of trigger categories.")] public Output<ZendeskListResponse<TriggerCategory>> Result { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var result = await GetClient(context).Triggers.ListTriggerCategoriesAsync(context.Get(Page), context.Get(PageSize), context.CancellationToken);
        context.Set(Result, result);
    }
}

[Activity("Elsa.Zendesk.Triggers", "Zendesk Triggers", "Creates a trigger category.", DisplayName = "Create Trigger Category")]
[UsedImplicitly]
public class CreateTriggerCategory : ZendeskActivity
{
    [Input(Description = "Name of the category.")] public Input<string> Name { get; set; } = null!;
    [Output(Description = "The created category.")] public Output<TriggerCategory?> Category { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var request = new TriggerCategoryRequest { TriggerCategory = new TriggerCategoryInput { Name = context.Get(Name) } };
        var response = await GetClient(context).Triggers.CreateTriggerCategoryAsync(request, context.CancellationToken);
        context.Set(Category, response.TriggerCategory);
    }
}

