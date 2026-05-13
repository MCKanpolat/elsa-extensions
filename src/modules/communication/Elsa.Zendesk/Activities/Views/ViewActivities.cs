using Elsa.Workflows.Attributes;
using Elsa.Workflows.Models;
using Elsa.Zendesk.Models;
using JetBrains.Annotations;

namespace Elsa.Zendesk.Activities.Views;

[Activity("Elsa.Zendesk.Views", "Zendesk Views", "Creates a view.", DisplayName = "Create View")]
[UsedImplicitly]
public class CreateView : ZendeskActivity
{
    [Input(Description = "The title of the view.")] public Input<string> Title { get; set; } = null!;
    [Output(Description = "The created view.")] public Output<View?> View { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var request = new CreateViewRequest { View = new ViewInput { Title = context.Get(Title) } };
        var response = await GetClient(context).Views.CreateViewAsync(request, context.CancellationToken);
        context.Set(View, response.View);
    }
}

[Activity("Elsa.Zendesk.Views", "Zendesk Views", "Gets a view by ID.", DisplayName = "Get View")]
[UsedImplicitly]
public class GetView : ZendeskActivity
{
    [Input(Description = "The ID of the view.")] public Input<long> ViewId { get; set; } = null!;
    [Output(Description = "The view.")] public Output<View?> View { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var response = await GetClient(context).Views.ShowViewAsync(context.Get(ViewId), context.CancellationToken);
        context.Set(View, response.View);
    }
}

[Activity("Elsa.Zendesk.Views", "Zendesk Views", "Lists views.", DisplayName = "List Views")]
[UsedImplicitly]
public class ListViews : ZendeskActivity
{
    [Input(Description = "Page number.")] public Input<int?> Page { get; set; } = null!;
    [Input(Description = "Results per page.")] public Input<int?> PageSize { get; set; } = null!;
    [Output(Description = "Paged list of views.")] public Output<ZendeskListResponse<View>> Result { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var result = await GetClient(context).Views.ListViewsAsync(context.Get(Page), context.Get(PageSize), cancellationToken: context.CancellationToken);
        context.Set(Result, result);
    }
}

[Activity("Elsa.Zendesk.Views", "Zendesk Views", "Lists tickets in a view.", DisplayName = "List View Tickets")]
[UsedImplicitly]
public class ListViewTickets : ZendeskActivity
{
    [Input(Description = "The ID of the view.")] public Input<long> ViewId { get; set; } = null!;
    [Input(Description = "Page number.")] public Input<int?> Page { get; set; } = null!;
    [Input(Description = "Results per page.")] public Input<int?> PageSize { get; set; } = null!;
    [Output(Description = "Paged list of tickets in the view.")] public Output<ZendeskListResponse<Ticket>> Result { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var result = await GetClient(context).Views.ListViewTicketsAsync(context.Get(ViewId), context.Get(Page), context.Get(PageSize), context.CancellationToken);
        context.Set(Result, result);
    }
}

[Activity("Elsa.Zendesk.Views", "Zendesk Views", "Updates a view.", DisplayName = "Update View")]
[UsedImplicitly]
public class UpdateView : ZendeskActivity
{
    [Input(Description = "The ID of the view.")] public Input<long> ViewId { get; set; } = null!;
    [Input(Description = "New title.")] public Input<string?> Title { get; set; } = null!;
    [Output(Description = "The updated view.")] public Output<View?> View { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var request = new UpdateViewRequest { View = new ViewInput { Title = context.Get(Title) } };
        var response = await GetClient(context).Views.UpdateViewAsync(context.Get(ViewId), request, context.CancellationToken);
        context.Set(View, response.View);
    }
}

[Activity("Elsa.Zendesk.Views", "Zendesk Views", "Deletes a view.", DisplayName = "Delete View")]
[UsedImplicitly]
public class DeleteView : ZendeskActivity
{
    [Input(Description = "The ID of the view to delete.")] public Input<long> ViewId { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context) =>
        await GetClient(context).Views.DeleteViewAsync(context.Get(ViewId), context.CancellationToken);
}

