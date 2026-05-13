using Elsa.Workflows.Attributes;
using Elsa.Workflows.Models;
using Elsa.Zendesk.Models;
using JetBrains.Annotations;

namespace Elsa.Zendesk.Activities.Locales;

[Activity("Elsa.Zendesk.Locales", "Zendesk Locales", "Lists available locales.", DisplayName = "List Locales")]
[UsedImplicitly]
public class ListLocales : ZendeskActivity
{
    [Output(Description = "List of locales.")] public Output<ZendeskListResponse<Locale>> Result { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var result = await GetClient(context).Locales.ListLocalesAsync(context.CancellationToken);
        context.Set(Result, result);
    }
}

[Activity("Elsa.Zendesk.Locales", "Zendesk Locales", "Gets a locale by ID.", DisplayName = "Get Locale")]
[UsedImplicitly]
public class GetLocale : ZendeskActivity
{
    [Input(Description = "The ID of the locale.")] public Input<long> LocaleId { get; set; } = null!;
    [Output(Description = "The locale.")] public Output<Locale?> Locale { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var response = await GetClient(context).Locales.ShowLocaleAsync(context.Get(LocaleId), context.CancellationToken);
        context.Set(Locale, response.Locale);
    }
}

