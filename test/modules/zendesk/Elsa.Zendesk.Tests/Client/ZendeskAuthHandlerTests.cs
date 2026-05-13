using System.Net;
using System.Text;
using Elsa.Zendesk.Client;
using Elsa.Zendesk.Options;

namespace Elsa.Zendesk.Tests.Client;

public class ZendeskAuthHandlerTests
{
    [Fact]
    public async Task ApiToken_AddsBasicAuthHeaderWithEmailTokenPattern()
    {
        var options = new ZendeskOptions
        {
            AuthMode = ZendeskAuthMode.ApiToken,
            Email = "agent@example.com",
            ApiToken = "secret-token"
        };

        var request = await SendAndCaptureAsync(options);

        Assert.NotNull(request.Headers.Authorization);
        Assert.Equal("Basic", request.Headers.Authorization!.Scheme);

        var decoded = Encoding.UTF8.GetString(Convert.FromBase64String(request.Headers.Authorization.Parameter!));
        Assert.Equal("agent@example.com/token:secret-token", decoded);
    }

    [Fact]
    public async Task OAuthBearer_AddsBearerAuthorizationHeader()
    {
        var options = new ZendeskOptions
        {
            AuthMode = ZendeskAuthMode.OAuthBearer,
            OAuthToken = "oauth-abc"
        };

        var request = await SendAndCaptureAsync(options);

        Assert.NotNull(request.Headers.Authorization);
        Assert.Equal("Bearer", request.Headers.Authorization!.Scheme);
        Assert.Equal("oauth-abc", request.Headers.Authorization.Parameter);
    }

    [Fact]
    public async Task DefaultMode_FallsBackToBasicAuth()
    {
        // AuthMode defaults to ApiToken even when not explicitly set.
        var options = new ZendeskOptions
        {
            Email = "a@b.com",
            ApiToken = "t"
        };

        var request = await SendAndCaptureAsync(options);

        Assert.Equal("Basic", request.Headers.Authorization!.Scheme);
    }

    private static async Task<HttpRequestMessage> SendAndCaptureAsync(ZendeskOptions options)
    {
        var capturingHandler = new CapturingHandler();
        var authHandler = new ZendeskAuthHandler(Microsoft.Extensions.Options.Options.Create(options))
        {
            InnerHandler = capturingHandler
        };

        using var invoker = new HttpMessageInvoker(authHandler);
        using var request = new HttpRequestMessage(HttpMethod.Get, "https://example.zendesk.com/api/v2/tickets");
        await invoker.SendAsync(request, CancellationToken.None);

        return capturingHandler.LastRequest!;
    }

    private sealed class CapturingHandler : HttpMessageHandler
    {
        public HttpRequestMessage? LastRequest { get; private set; }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            LastRequest = request;
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
        }
    }
}
