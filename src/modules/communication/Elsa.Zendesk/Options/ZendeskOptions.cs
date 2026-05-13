namespace Elsa.Zendesk.Options;

/// <summary>
/// Configuration options for the Zendesk integration.
/// </summary>
public class ZendeskOptions
{
    /// <summary>
    /// Your Zendesk subdomain (e.g. "mycompany" for "mycompany.zendesk.com").
    /// </summary>
    public string Subdomain { get; set; } = null!;

    /// <summary>
    /// The authentication mode: API token (Basic Auth) or OAuth Bearer token.
    /// </summary>
    public ZendeskAuthMode AuthMode { get; set; } = ZendeskAuthMode.ApiToken;

    /// <summary>
    /// The agent's email address. Required when <see cref="AuthMode"/> is <see cref="ZendeskAuthMode.ApiToken"/>.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// The Zendesk API token. Required when <see cref="AuthMode"/> is <see cref="ZendeskAuthMode.ApiToken"/>.
    /// </summary>
    public string? ApiToken { get; set; }

    /// <summary>
    /// The OAuth Bearer token. Required when <see cref="AuthMode"/> is <see cref="ZendeskAuthMode.OAuthBearer"/>.
    /// </summary>
    public string? OAuthToken { get; set; }

    /// <summary>
    /// Returns the base URL for the Zendesk API, e.g. https://mycompany.zendesk.com.
    /// </summary>
    public Uri GetBaseUri() => new($"https://{Subdomain}.zendesk.com");
}

