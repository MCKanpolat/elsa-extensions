using Elsa.Workflows.Attributes;
using Elsa.Workflows.Models;
using Elsa.Zendesk.Models;
using JetBrains.Annotations;

namespace Elsa.Zendesk.Activities.Account;

[Activity("Elsa.Zendesk.Account", "Zendesk Account", "Gets account settings.", DisplayName = "Get Account Settings")]
[UsedImplicitly]
public class GetAccountSettings : ZendeskActivity
{
    [Output(Description = "The account settings.")] public Output<AccountSettings?> Settings { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var response = await GetClient(context).Account.ShowAccountSettingsAsync(context.CancellationToken);
        context.Set(Settings, response.Settings);
    }
}

[Activity("Elsa.Zendesk.Account", "Zendesk Account", "Updates account settings.", DisplayName = "Update Account Settings")]
[UsedImplicitly]
public class UpdateAccountSettings : ZendeskActivity
{
    [Input(Description = "The settings object to update (serialized as JSON).")] public Input<AccountSettings> Settings { get; set; } = null!;
    [Output(Description = "The updated account settings.")] public Output<AccountSettings?> UpdatedSettings { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var request = new UpdateAccountSettingsRequest { Settings = context.Get(Settings)! };
        var response = await GetClient(context).Account.UpdateAccountSettingsAsync(request, context.CancellationToken);
        context.Set(UpdatedSettings, response.Settings);
    }
}


