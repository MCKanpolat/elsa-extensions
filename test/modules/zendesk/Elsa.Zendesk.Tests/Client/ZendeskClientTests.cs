using Elsa.Zendesk.Client;
using Elsa.Zendesk.Client.Api;
using Moq;

namespace Elsa.Zendesk.Tests.Client;

public class ZendeskClientTests
{
    [Fact]
    public void Constructor_AssignsAllApiPropertiesFromInjectedInstances()
    {
        var tickets = Mock.Of<ITicketsApi>();
        var users = Mock.Of<IUsersApi>();
        var organizations = Mock.Of<IOrganizationsApi>();
        var groups = Mock.Of<IGroupsApi>();
        var macros = Mock.Of<IMacrosApi>();
        var triggers = Mock.Of<ITriggersApi>();
        var views = Mock.Of<IViewsApi>();
        var automations = Mock.Of<IAutomationsApi>();
        var brands = Mock.Of<IBrandsApi>();
        var attachments = Mock.Of<IAttachmentsApi>();
        var search = Mock.Of<ISearchApi>();
        var satisfactionRatings = Mock.Of<ISatisfactionRatingsApi>();
        var auditLogs = Mock.Of<IAuditLogsApi>();
        var account = Mock.Of<IAccountApi>();
        var tags = Mock.Of<ITagsApi>();
        var bookmarks = Mock.Of<IBookmarksApi>();
        var slaPolicies = Mock.Of<ISlaPoliciesApi>();
        var customStatuses = Mock.Of<ICustomStatusesApi>();
        var dynamicContent = Mock.Of<IDynamicContentApi>();
        var locales = Mock.Of<ILocalesApi>();
        var targets = Mock.Of<ITargetsApi>();
        var requests = Mock.Of<IRequestsApi>();

        var client = new ZendeskClient(
            tickets, users, organizations, groups, macros, triggers,
            views, automations, brands, attachments, search, satisfactionRatings,
            auditLogs, account, tags, bookmarks, slaPolicies, customStatuses,
            dynamicContent, locales, targets, requests);

        Assert.Same(tickets, client.Tickets);
        Assert.Same(users, client.Users);
        Assert.Same(organizations, client.Organizations);
        Assert.Same(groups, client.Groups);
        Assert.Same(macros, client.Macros);
        Assert.Same(triggers, client.Triggers);
        Assert.Same(views, client.Views);
        Assert.Same(automations, client.Automations);
        Assert.Same(brands, client.Brands);
        Assert.Same(attachments, client.Attachments);
        Assert.Same(search, client.Search);
        Assert.Same(satisfactionRatings, client.SatisfactionRatings);
        Assert.Same(auditLogs, client.AuditLogs);
        Assert.Same(account, client.Account);
        Assert.Same(tags, client.Tags);
        Assert.Same(bookmarks, client.Bookmarks);
        Assert.Same(slaPolicies, client.SlaPolicies);
        Assert.Same(customStatuses, client.CustomStatuses);
        Assert.Same(dynamicContent, client.DynamicContent);
        Assert.Same(locales, client.Locales);
        Assert.Same(targets, client.Targets);
        Assert.Same(requests, client.Requests);
    }
}
