using Elsa.Workflows.Attributes;
using Elsa.Workflows.Models;
using Elsa.Zendesk.Models;
using JetBrains.Annotations;

namespace Elsa.Zendesk.Activities.DynamicContent;

[Activity("Elsa.Zendesk.DynamicContent", "Zendesk Dynamic Content", "Lists dynamic content items.", DisplayName = "List Dynamic Content Items")]
[UsedImplicitly]
public class ListDynamicContentItems : ZendeskActivity
{
    [Input(Description = "Page number.")] public Input<int?> Page { get; set; } = null!;
    [Input(Description = "Results per page.")] public Input<int?> PageSize { get; set; } = null!;
    [Output(Description = "Paged list of dynamic content items.")] public Output<ZendeskListResponse<DynamicContentItem>> Result { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var result = await GetClient(context).DynamicContent.ListDynamicContentItemsAsync(context.Get(Page), context.Get(PageSize), context.CancellationToken);
        context.Set(Result, result);
    }
}

[Activity("Elsa.Zendesk.DynamicContent", "Zendesk Dynamic Content", "Creates a dynamic content item.", DisplayName = "Create Dynamic Content Item")]
[UsedImplicitly]
public class CreateDynamicContentItem : ZendeskActivity
{
    [Input(Description = "The name of the dynamic content item.")] public Input<string> Name { get; set; } = null!;
    [Input(Description = "Default locale ID.")] public Input<long> DefaultLocaleId { get; set; } = null!;
    [Output(Description = "The created item.")] public Output<DynamicContentItem?> Item { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var request = new CreateDynamicContentItemRequest { Item = new DynamicContentItemInput { Name = context.Get(Name), DefaultLocaleId = context.Get(DefaultLocaleId) } };
        var response = await GetClient(context).DynamicContent.CreateDynamicContentItemAsync(request, context.CancellationToken);
        context.Set(Item, response.Item);
    }
}

[Activity("Elsa.Zendesk.DynamicContent", "Zendesk Dynamic Content", "Gets a dynamic content item by ID.", DisplayName = "Get Dynamic Content Item")]
[UsedImplicitly]
public class GetDynamicContentItem : ZendeskActivity
{
    [Input(Description = "The ID of the dynamic content item.")] public Input<long> ItemId { get; set; } = null!;
    [Output(Description = "The dynamic content item.")] public Output<DynamicContentItem?> Item { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var response = await GetClient(context).DynamicContent.ShowDynamicContentItemAsync(context.Get(ItemId), context.CancellationToken);
        context.Set(Item, response.Item);
    }
}

[Activity("Elsa.Zendesk.DynamicContent", "Zendesk Dynamic Content", "Deletes a dynamic content item.", DisplayName = "Delete Dynamic Content Item")]
[UsedImplicitly]
public class DeleteDynamicContentItem : ZendeskActivity
{
    [Input(Description = "The ID of the item to delete.")] public Input<long> ItemId { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context) =>
        await GetClient(context).DynamicContent.DeleteDynamicContentItemAsync(context.Get(ItemId), context.CancellationToken);
}

