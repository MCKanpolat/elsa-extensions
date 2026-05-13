using Elsa.Zendesk.Client;
using Elsa.Zendesk.Client.Api;
using Elsa.Zendesk.Options;
using Microsoft.Extensions.Options;
using Refit;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Provides service registration extensions for Zendesk integration.
/// </summary>
public static class ZendeskDependencyInjectionExtensions
{
    /// <summary>
    /// Registers all Zendesk services including Refit clients with the configured auth handler.
    /// </summary>
    public static IServiceCollection AddZendesk(
        this IServiceCollection services,
        Action<ZendeskOptions>? configure = null,
        Func<IServiceProvider, HttpClient>? httpClientFactory = null,
        Action<IHttpClientBuilder>? configureHttpClientBuilder = null)
    {
        if (configure != null)
            services.Configure(configure);

        services.AddTransient<ZendeskAuthHandler>();

        var refitSettings = new RefitSettings();

        services
            .AddZendeskApi<ITicketsApi>(refitSettings, httpClientFactory, configureHttpClientBuilder)
            .AddZendeskApi<IUsersApi>(refitSettings, httpClientFactory, configureHttpClientBuilder)
            .AddZendeskApi<IOrganizationsApi>(refitSettings, httpClientFactory, configureHttpClientBuilder)
            .AddZendeskApi<IGroupsApi>(refitSettings, httpClientFactory, configureHttpClientBuilder)
            .AddZendeskApi<IMacrosApi>(refitSettings, httpClientFactory, configureHttpClientBuilder)
            .AddZendeskApi<ITriggersApi>(refitSettings, httpClientFactory, configureHttpClientBuilder)
            .AddZendeskApi<IViewsApi>(refitSettings, httpClientFactory, configureHttpClientBuilder)
            .AddZendeskApi<IAutomationsApi>(refitSettings, httpClientFactory, configureHttpClientBuilder)
            .AddZendeskApi<IBrandsApi>(refitSettings, httpClientFactory, configureHttpClientBuilder)
            .AddZendeskApi<IAttachmentsApi>(refitSettings, httpClientFactory, configureHttpClientBuilder)
            .AddZendeskApi<ISearchApi>(refitSettings, httpClientFactory, configureHttpClientBuilder)
            .AddZendeskApi<ISatisfactionRatingsApi>(refitSettings, httpClientFactory, configureHttpClientBuilder)
            .AddZendeskApi<IAuditLogsApi>(refitSettings, httpClientFactory, configureHttpClientBuilder)
            .AddZendeskApi<IAccountApi>(refitSettings, httpClientFactory, configureHttpClientBuilder)
            .AddZendeskApi<ITagsApi>(refitSettings, httpClientFactory, configureHttpClientBuilder)
            .AddZendeskApi<IBookmarksApi>(refitSettings, httpClientFactory, configureHttpClientBuilder)
            .AddZendeskApi<ISlaPoliciesApi>(refitSettings, httpClientFactory, configureHttpClientBuilder)
            .AddZendeskApi<ICustomStatusesApi>(refitSettings, httpClientFactory, configureHttpClientBuilder)
            .AddZendeskApi<IDynamicContentApi>(refitSettings, httpClientFactory, configureHttpClientBuilder)
            .AddZendeskApi<ILocalesApi>(refitSettings, httpClientFactory, configureHttpClientBuilder)
            .AddZendeskApi<ITargetsApi>(refitSettings, httpClientFactory, configureHttpClientBuilder)
            .AddZendeskApi<IRequestsApi>(refitSettings, httpClientFactory, configureHttpClientBuilder)
            .AddTransient<IZendeskClient, ZendeskClient>();

        return services;
    }

    private static IServiceCollection AddZendeskApi<T>(
        this IServiceCollection services,
        RefitSettings refitSettings,
        Func<IServiceProvider, HttpClient>? httpClientFactory,
        Action<IHttpClientBuilder>? configureHttpClientBuilder) where T : class
    {
        if (httpClientFactory == null)
        {
            var builder = services.AddRefitClient<T>(refitSettings)
                .ConfigureHttpClient((sp, client) =>
                {
                    var opts = sp.GetRequiredService<IOptions<ZendeskOptions>>().Value;
                    client.BaseAddress = opts.GetBaseUri();
                })
                .AddHttpMessageHandler<ZendeskAuthHandler>();

            configureHttpClientBuilder?.Invoke(builder);
        }
        else
        {
            services.AddTransient(sp =>
            {
                var httpClient = httpClientFactory(sp);
                var opts = sp.GetRequiredService<IOptions<ZendeskOptions>>().Value;
                httpClient.BaseAddress ??= opts.GetBaseUri();
                return RestService.For<T>(httpClient, refitSettings);
            });
        }

        return services;
    }
}

