using Elsa.Features.Services;
using Elsa.Zendesk.Features;

// ReSharper disable once CheckNamespace
namespace Elsa.Extensions;

/// <summary>
/// Extension methods for adding the Zendesk module to an Elsa workflow application.
/// </summary>
public static class ZendeskModuleExtensions
{
    /// <summary>
    /// Registers the Zendesk Ticketing module with the Elsa workflow engine.
    /// </summary>
    public static IModule UseZendesk(this IModule module, Action<ZendeskFeature>? configure = null)
    {
        module.Configure(configure);
        return module;
    }
}

