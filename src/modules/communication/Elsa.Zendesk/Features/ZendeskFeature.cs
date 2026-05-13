using Elsa.Extensions;
using Elsa.Features.Abstractions;
using Elsa.Features.Services;
using Elsa.Zendesk.Activities;
using Elsa.Zendesk.Models;
using Elsa.Zendesk.Options;
using Microsoft.Extensions.DependencyInjection;

namespace Elsa.Zendesk.Features;

/// <summary>
/// Elsa feature that registers all Zendesk Ticketing activities and services.
/// </summary>
public class ZendeskFeature : FeatureBase
{
    private const string ZendeskCategory = "Zendesk";

    /// <inheritdoc />
    public ZendeskFeature(IModule module) : base(module) { }

    /// <summary>Configures Zendesk options.</summary>
    public Action<ZendeskOptions> ConfigureZendeskOptions { get; set; } = _ => { };

    /// <summary>Provides a custom <see cref="HttpClient"/> for the Zendesk API.</summary>
    public Func<IServiceProvider, HttpClient>? HttpClientFactory { get; set; }

    /// <summary>Allows further configuration of the Refit <see cref="IHttpClientBuilder"/>.</summary>
    public Action<IHttpClientBuilder>? ConfigureHttpClientBuilder { get; set; }

    /// <inheritdoc />
    public override void Configure()
    {
        Module.UseWorkflowManagement(management =>
        {
            management.AddActivitiesFrom<ZendeskActivity>();

            // Register key Zendesk model types as workflow variable types.
            management.AddVariableType<Ticket>(ZendeskCategory);
            management.AddVariableType<TicketComment>(ZendeskCategory);
            management.AddVariableType<TicketAudit>(ZendeskCategory);
            management.AddVariableType<TicketMetrics>(ZendeskCategory);
            management.AddVariableType<User>(ZendeskCategory);
            management.AddVariableType<Organization>(ZendeskCategory);
            management.AddVariableType<Group>(ZendeskCategory);
            management.AddVariableType<GroupMembership>(ZendeskCategory);
            management.AddVariableType<Macro>(ZendeskCategory);
            management.AddVariableType<Trigger>(ZendeskCategory);
            management.AddVariableType<TriggerCategory>(ZendeskCategory);
            management.AddVariableType<View>(ZendeskCategory);
            management.AddVariableType<Automation>(ZendeskCategory);
            management.AddVariableType<Brand>(ZendeskCategory);
            management.AddVariableType<Attachment>(ZendeskCategory);
            management.AddVariableType<SlaPolicy>(ZendeskCategory);
            management.AddVariableType<SatisfactionRating>(ZendeskCategory);
            management.AddVariableType<AuditLog>(ZendeskCategory);
            management.AddVariableType<ZendeskBookmark>(ZendeskCategory);
            management.AddVariableType<CustomStatus>(ZendeskCategory);
            management.AddVariableType<DynamicContentItem>(ZendeskCategory);
            management.AddVariableType<Locale>(ZendeskCategory);
            management.AddVariableType<Target>(ZendeskCategory);
            management.AddVariableType<SearchResult>(ZendeskCategory);
            management.AddVariableType<AccountSettings>(ZendeskCategory);
            management.AddVariableType<ZendeskRequest>(ZendeskCategory);
        });
    }

    /// <inheritdoc />
    public override void Apply() =>
        Services.AddZendesk(ConfigureZendeskOptions, HttpClientFactory, ConfigureHttpClientBuilder);
}

