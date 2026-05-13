using Elsa.Workflows.Attributes;
using Elsa.Workflows.Models;
using Elsa.Zendesk.Models;
using JetBrains.Annotations;

namespace Elsa.Zendesk.Activities.Macros;

[Activity("Elsa.Zendesk.Macros", "Zendesk Macros", "Creates a new macro.", DisplayName = "Create Macro")]
[UsedImplicitly]
public class CreateMacro : ZendeskActivity
{
    [Input(Description = "The title of the macro.")] public Input<string> Title { get; set; } = null!;
    [Output(Description = "The created macro.")] public Output<Macro?> Macro { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var request = new CreateMacroRequest { Macro = new MacroInput { Title = context.Get(Title) } };
        var response = await GetClient(context).Macros.CreateMacroAsync(request, context.CancellationToken);
        context.Set(Macro, response.Macro);
    }
}

[Activity("Elsa.Zendesk.Macros", "Zendesk Macros", "Gets a macro by ID.", DisplayName = "Get Macro")]
[UsedImplicitly]
public class GetMacro : ZendeskActivity
{
    [Input(Description = "The ID of the macro.")] public Input<long> MacroId { get; set; } = null!;
    [Output(Description = "The macro.")] public Output<Macro?> Macro { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var response = await GetClient(context).Macros.ShowMacroAsync(context.Get(MacroId), context.CancellationToken);
        context.Set(Macro, response.Macro);
    }
}

[Activity("Elsa.Zendesk.Macros", "Zendesk Macros", "Lists macros.", DisplayName = "List Macros")]
[UsedImplicitly]
public class ListMacros : ZendeskActivity
{
    [Input(Description = "Filter by active status.")] public Input<bool?> Active { get; set; } = null!;
    [Input(Description = "Page number.")] public Input<int?> Page { get; set; } = null!;
    [Input(Description = "Results per page.")] public Input<int?> PageSize { get; set; } = null!;
    [Output(Description = "Paged list of macros.")] public Output<ZendeskListResponse<Macro>> Result { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var result = await GetClient(context).Macros.ListMacrosAsync(context.Get(Page), context.Get(PageSize), context.Get(Active), context.CancellationToken);
        context.Set(Result, result);
    }
}

[Activity("Elsa.Zendesk.Macros", "Zendesk Macros", "Searches macros.", DisplayName = "Search Macros")]
[UsedImplicitly]
public class SearchMacros : ZendeskActivity
{
    [Input(Description = "The search query.")] public Input<string> Query { get; set; } = null!;
    [Output(Description = "Matching macros.")] public Output<ZendeskListResponse<Macro>> Result { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var result = await GetClient(context).Macros.SearchMacrosAsync(context.Get(Query)!, cancellationToken: context.CancellationToken);
        context.Set(Result, result);
    }
}

[Activity("Elsa.Zendesk.Macros", "Zendesk Macros", "Updates a macro.", DisplayName = "Update Macro")]
[UsedImplicitly]
public class UpdateMacro : ZendeskActivity
{
    [Input(Description = "The ID of the macro.")] public Input<long> MacroId { get; set; } = null!;
    [Input(Description = "New title.")] public Input<string?> Title { get; set; } = null!;
    [Input(Description = "Active status.")] public Input<bool?> Active { get; set; } = null!;
    [Output(Description = "The updated macro.")] public Output<Macro?> Macro { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var request = new UpdateMacroRequest { Macro = new MacroInput { Title = context.Get(Title), Active = context.Get(Active) } };
        var response = await GetClient(context).Macros.UpdateMacroAsync(context.Get(MacroId), request, context.CancellationToken);
        context.Set(Macro, response.Macro);
    }
}

[Activity("Elsa.Zendesk.Macros", "Zendesk Macros", "Deletes a macro.", DisplayName = "Delete Macro")]
[UsedImplicitly]
public class DeleteMacro : ZendeskActivity
{
    [Input(Description = "The ID of the macro to delete.")] public Input<long> MacroId { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context) =>
        await GetClient(context).Macros.DeleteMacroAsync(context.Get(MacroId), context.CancellationToken);
}

