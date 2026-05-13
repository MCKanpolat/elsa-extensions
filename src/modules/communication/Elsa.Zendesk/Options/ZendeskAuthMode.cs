namespace Elsa.Zendesk.Options;

/// <summary>
/// Determines how requests to the Zendesk API are authenticated.
/// </summary>
public enum ZendeskAuthMode
{
    /// <summary>
    /// Use email + API token for Basic Auth: <c>email/token:api_token</c>.
    /// </summary>
    ApiToken,

    /// <summary>
    /// Use an OAuth Bearer token.
    /// </summary>
    OAuthBearer
}

