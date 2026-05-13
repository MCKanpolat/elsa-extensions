using Elsa.Workflows.Attributes;
using Elsa.Workflows.Models;
using Elsa.Zendesk.Models;
using JetBrains.Annotations;

namespace Elsa.Zendesk.Activities.Search;

[Activity("Elsa.Zendesk.Search", "Zendesk Search", "Searches across Zendesk (tickets, users, organizations, etc.).", DisplayName = "Search")]
[UsedImplicitly]
public class Search : ZendeskActivity
{
    [Input(Description = "Zendesk search query string (e.g. 'type:ticket status:open').")] public Input<string> Query { get; set; } = null!;
    [Input(Description = "Field to sort by.")] public Input<string?> SortBy { get; set; } = null!;
    [Input(Description = "Sort order (asc or desc).")] public Input<string?> SortOrder { get; set; } = null!;
    [Input(Description = "Page number.")] public Input<int?> Page { get; set; } = null!;
    [Input(Description = "Results per page.")] public Input<int?> PageSize { get; set; } = null!;
    [Output(Description = "Paged search results.")] public Output<ZendeskListResponse<SearchResult>> Result { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var result = await GetClient(context).Search.SearchAsync(
            context.Get(Query)!,
            context.Get(SortBy),
            context.Get(SortOrder),
            context.Get(Page),
            context.Get(PageSize),
            context.CancellationToken);
        context.Set(Result, result);
    }
}

