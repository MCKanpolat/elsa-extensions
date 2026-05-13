using System.Net.Http.Headers;
using System.Text;
using Elsa.Zendesk.Options;
using Microsoft.Extensions.Options;

namespace Elsa.Zendesk.Client;

/// <summary>
/// Delegating handler that injects the appropriate Zendesk Authorization header
/// based on <see cref="ZendeskOptions.AuthMode"/>.
/// </summary>
public class ZendeskAuthHandler : DelegatingHandler
{
    private readonly IOptions<ZendeskOptions> _options;

    /// <inheritdoc />
    public ZendeskAuthHandler(IOptions<ZendeskOptions> options)
    {
        _options = options;
    }

    /// <inheritdoc />
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var opts = _options.Value;

        request.Headers.Authorization = opts.AuthMode switch
        {
            ZendeskAuthMode.OAuthBearer => new AuthenticationHeaderValue("Bearer", opts.OAuthToken),
            _ => BuildBasicAuthHeader(opts)
        };

        return base.SendAsync(request, cancellationToken);
    }

    private static AuthenticationHeaderValue BuildBasicAuthHeader(ZendeskOptions opts)
    {
        var credentials = $"{opts.Email}/token:{opts.ApiToken}";
        var encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials));
        return new AuthenticationHeaderValue("Basic", encoded);
    }
}

