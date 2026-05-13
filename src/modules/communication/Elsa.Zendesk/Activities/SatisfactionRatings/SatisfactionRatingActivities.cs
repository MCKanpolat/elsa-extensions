using Elsa.Workflows.Attributes;
using Elsa.Workflows.Models;
using Elsa.Zendesk.Models;
using JetBrains.Annotations;

namespace Elsa.Zendesk.Activities.SatisfactionRatings;

[Activity("Elsa.Zendesk.SatisfactionRatings", "Zendesk Satisfaction", "Lists satisfaction ratings.", DisplayName = "List Satisfaction Ratings")]
[UsedImplicitly]
public class ListSatisfactionRatings : ZendeskActivity
{
    [Input(Description = "Filter by score (offered, unoffered, good, bad, good_with_comment, bad_with_comment).")] public Input<string?> Score { get; set; } = null!;
    [Input(Description = "Page number.")] public Input<int?> Page { get; set; } = null!;
    [Input(Description = "Results per page.")] public Input<int?> PageSize { get; set; } = null!;
    [Output(Description = "Paged list of satisfaction ratings.")] public Output<ZendeskListResponse<SatisfactionRating>> Result { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var result = await GetClient(context).SatisfactionRatings.ListSatisfactionRatingsAsync(context.Get(Score), context.Get(Page), context.Get(PageSize), context.CancellationToken);
        context.Set(Result, result);
    }
}

[Activity("Elsa.Zendesk.SatisfactionRatings", "Zendesk Satisfaction", "Gets a satisfaction rating by ID.", DisplayName = "Get Satisfaction Rating")]
[UsedImplicitly]
public class GetSatisfactionRating : ZendeskActivity
{
    [Input(Description = "The ID of the satisfaction rating.")] public Input<long> SatisfactionRatingId { get; set; } = null!;
    [Output(Description = "The satisfaction rating.")] public Output<SatisfactionRating?> Rating { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var response = await GetClient(context).SatisfactionRatings.ShowSatisfactionRatingAsync(context.Get(SatisfactionRatingId), context.CancellationToken);
        context.Set(Rating, response.SatisfactionRating);
    }
}

[Activity("Elsa.Zendesk.SatisfactionRatings", "Zendesk Satisfaction", "Creates a satisfaction rating for a ticket.", DisplayName = "Create Satisfaction Rating")]
[UsedImplicitly]
public class CreateSatisfactionRating : ZendeskActivity
{
    [Input(Description = "The ticket ID to rate.")] public Input<long> TicketId { get; set; } = null!;
    [Input(Description = "Score: good or bad.")] public Input<string> Score { get; set; } = null!;
    [Input(Description = "Optional comment.")] public Input<string?> Comment { get; set; } = null!;
    [Output(Description = "The created satisfaction rating.")] public Output<SatisfactionRating?> Rating { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var request = new CreateSatisfactionRatingRequest { SatisfactionRating = new SatisfactionRatingInput { Score = context.Get(Score), Comment = context.Get(Comment) } };
        var response = await GetClient(context).SatisfactionRatings.CreateSatisfactionRatingAsync(context.Get(TicketId), request, context.CancellationToken);
        context.Set(Rating, response.SatisfactionRating);
    }
}

