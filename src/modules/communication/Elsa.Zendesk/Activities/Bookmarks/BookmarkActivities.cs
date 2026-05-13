using Elsa.Workflows.Attributes;
using Elsa.Workflows.Models;
using Elsa.Zendesk.Models;
using JetBrains.Annotations;

namespace Elsa.Zendesk.Activities.Bookmarks;

[Activity("Elsa.Zendesk.Bookmarks", "Zendesk Bookmarks", "Lists bookmarks.", DisplayName = "List Bookmarks")]
[UsedImplicitly]
public class ListBookmarks : ZendeskActivity
{
    [Input(Description = "Page number.")] public Input<int?> Page { get; set; } = null!;
    [Input(Description = "Results per page.")] public Input<int?> PageSize { get; set; } = null!;
    [Output(Description = "Paged list of bookmarks.")] public Output<ZendeskListResponse<ZendeskBookmark>> Result { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var result = await GetClient(context).Bookmarks.ListBookmarksAsync(context.Get(Page), context.Get(PageSize), context.CancellationToken);
        context.Set(Result, result);
    }
}

[Activity("Elsa.Zendesk.Bookmarks", "Zendesk Bookmarks", "Creates a bookmark for a ticket.", DisplayName = "Create Bookmark")]
[UsedImplicitly]
public class CreateBookmark : ZendeskActivity
{
    [Input(Description = "The ticket ID to bookmark.")] public Input<long> TicketId { get; set; } = null!;
    [Output(Description = "The created bookmark.")] public Output<ZendeskBookmark?> Bookmark { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var request = new CreateBookmarkRequest { Bookmark = new ZendeskBookmarkInput { TicketId = context.Get(TicketId) } };
        var response = await GetClient(context).Bookmarks.CreateBookmarkAsync(request, context.CancellationToken);
        context.Set(Bookmark, response.ZendeskBookmark);
    }
}

[Activity("Elsa.Zendesk.Bookmarks", "Zendesk Bookmarks", "Deletes a bookmark.", DisplayName = "Delete Bookmark")]
[UsedImplicitly]
public class DeleteBookmark : ZendeskActivity
{
    [Input(Description = "The ID of the bookmark to delete.")] public Input<long> BookmarkId { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context) =>
        await GetClient(context).Bookmarks.DeleteBookmarkAsync(context.Get(BookmarkId), context.CancellationToken);
}

