using Elsa.Zendesk.Options;

namespace Elsa.Zendesk.Tests.Options;

public class ZendeskOptionsTests
{
    [Fact]
    public void GetBaseUri_ReturnsHttpsZendeskUrlForSubdomain()
    {
        var options = new ZendeskOptions { Subdomain = "mycompany" };

        var uri = options.GetBaseUri();

        Assert.Equal(new Uri("https://mycompany.zendesk.com"), uri);
    }

    [Fact]
    public void Defaults_AreApiTokenAuthMode()
    {
        var options = new ZendeskOptions();

        Assert.Equal(ZendeskAuthMode.ApiToken, options.AuthMode);
        Assert.Null(options.Email);
        Assert.Null(options.ApiToken);
        Assert.Null(options.OAuthToken);
    }
}
