using Elsa.Workflows.Attributes;
using Elsa.Workflows.Models;
using Elsa.Zendesk.Models;
using JetBrains.Annotations;

namespace Elsa.Zendesk.Activities.Requests;

[Activity("Elsa.Zendesk.Requests", "Zendesk Requests", "Lists end-user requests.", DisplayName = "List Requests")]
[UsedImplicitly]
public class ListRequests : ZendeskActivity
{
    [Input(Description = "Filter by status (open, solved, etc.).")] public Input<string?> Status { get; set; } = null!;
    [Input(Description = "Page number.")] public Input<int?> Page { get; set; } = null!;
    [Input(Description = "Results per page.")] public Input<int?> PageSize { get; set; } = null!;
    [Output(Description = "Paged list of requests.")] public Output<ZendeskListResponse<ZendeskRequest>> Result { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var result = await GetClient(context).Requests.ListRequestsAsync(context.Get(Status), context.Get(Page), context.Get(PageSize), context.CancellationToken);
        context.Set(Result, result);
    }
}

[Activity("Elsa.Zendesk.Requests", "Zendesk Requests", "Creates an end-user request.", DisplayName = "Create Request")]
[UsedImplicitly]
public class CreateRequest : ZendeskActivity
{
    [Input(Description = "Subject of the request.")] public Input<string> Subject { get; set; } = null!;
    [Input(Description = "Body of the initial comment.")] public Input<string> CommentBody { get; set; } = null!;
    [Output(Description = "The created request.")] public Output<ZendeskRequest?> Request { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var body = new CreateZendeskRequestBody
        {
            Request = new ZendeskRequestInput
            {
                Subject = context.Get(Subject),
                Comment = new TicketCommentInput { Body = context.Get(CommentBody) }
            }
        };
        var response = await GetClient(context).Requests.CreateRequestAsync(body, context.CancellationToken);
        context.Set(Request, response.Request);
    }
}

[Activity("Elsa.Zendesk.Requests", "Zendesk Requests", "Gets an end-user request by ID.", DisplayName = "Get Request")]
[UsedImplicitly]
public class GetRequest : ZendeskActivity
{
    [Input(Description = "The ID of the request.")] public Input<long> RequestId { get; set; } = null!;
    [Output(Description = "The request.")] public Output<ZendeskRequest?> Request { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var response = await GetClient(context).Requests.ShowRequestAsync(context.Get(RequestId), context.CancellationToken);
        context.Set(Request, response.Request);
    }
}

[Activity("Elsa.Zendesk.Requests", "Zendesk Requests", "Searches end-user requests.", DisplayName = "Search Requests")]
[UsedImplicitly]
public class SearchRequests : ZendeskActivity
{
    [Input(Description = "The search query.")] public Input<string> Query { get; set; } = null!;
    [Output(Description = "Matching requests.")] public Output<ZendeskListResponse<ZendeskRequest>> Result { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var result = await GetClient(context).Requests.SearchRequestsAsync(context.Get(Query)!, context.CancellationToken);
        context.Set(Result, result);
    }
}

