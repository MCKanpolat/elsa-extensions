using Elsa.Zendesk.Client.Api;

namespace Elsa.Zendesk.Client;

/// <summary>Composite Zendesk API client exposing all API groups.</summary>
public interface IZendeskClient
{
    ITicketsApi Tickets { get; }
    IUsersApi Users { get; }
    IOrganizationsApi Organizations { get; }
    IGroupsApi Groups { get; }
    IMacrosApi Macros { get; }
    ITriggersApi Triggers { get; }
    IViewsApi Views { get; }
    IAutomationsApi Automations { get; }
    IBrandsApi Brands { get; }
    IAttachmentsApi Attachments { get; }
    ISearchApi Search { get; }
    ISatisfactionRatingsApi SatisfactionRatings { get; }
    IAuditLogsApi AuditLogs { get; }
    IAccountApi Account { get; }
    ITagsApi Tags { get; }
    IBookmarksApi Bookmarks { get; }
    ISlaPoliciesApi SlaPolicies { get; }
    ICustomStatusesApi CustomStatuses { get; }
    IDynamicContentApi DynamicContent { get; }
    ILocalesApi Locales { get; }
    ITargetsApi Targets { get; }
    IRequestsApi Requests { get; }
}

