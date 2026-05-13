using Elsa.Zendesk.Client.Api;

namespace Elsa.Zendesk.Client;

/// <summary>Default implementation of <see cref="IZendeskClient"/>.</summary>
public class ZendeskClient : IZendeskClient
{
    /// <inheritdoc />
    public ZendeskClient(
        ITicketsApi tickets,
        IUsersApi users,
        IOrganizationsApi organizations,
        IGroupsApi groups,
        IMacrosApi macros,
        ITriggersApi triggers,
        IViewsApi views,
        IAutomationsApi automations,
        IBrandsApi brands,
        IAttachmentsApi attachments,
        ISearchApi search,
        ISatisfactionRatingsApi satisfactionRatings,
        IAuditLogsApi auditLogs,
        IAccountApi account,
        ITagsApi tags,
        IBookmarksApi bookmarks,
        ISlaPoliciesApi slaPolicies,
        ICustomStatusesApi customStatuses,
        IDynamicContentApi dynamicContent,
        ILocalesApi locales,
        ITargetsApi targets,
        IRequestsApi requests)
    {
        Tickets = tickets;
        Users = users;
        Organizations = organizations;
        Groups = groups;
        Macros = macros;
        Triggers = triggers;
        Views = views;
        Automations = automations;
        Brands = brands;
        Attachments = attachments;
        Search = search;
        SatisfactionRatings = satisfactionRatings;
        AuditLogs = auditLogs;
        Account = account;
        Tags = tags;
        Bookmarks = bookmarks;
        SlaPolicies = slaPolicies;
        CustomStatuses = customStatuses;
        DynamicContent = dynamicContent;
        Locales = locales;
        Targets = targets;
        Requests = requests;
    }

    /// <inheritdoc />
    public ITicketsApi Tickets { get; }
    /// <inheritdoc />
    public IUsersApi Users { get; }
    /// <inheritdoc />
    public IOrganizationsApi Organizations { get; }
    /// <inheritdoc />
    public IGroupsApi Groups { get; }
    /// <inheritdoc />
    public IMacrosApi Macros { get; }
    /// <inheritdoc />
    public ITriggersApi Triggers { get; }
    /// <inheritdoc />
    public IViewsApi Views { get; }
    /// <inheritdoc />
    public IAutomationsApi Automations { get; }
    /// <inheritdoc />
    public IBrandsApi Brands { get; }
    /// <inheritdoc />
    public IAttachmentsApi Attachments { get; }
    /// <inheritdoc />
    public ISearchApi Search { get; }
    /// <inheritdoc />
    public ISatisfactionRatingsApi SatisfactionRatings { get; }
    /// <inheritdoc />
    public IAuditLogsApi AuditLogs { get; }
    /// <inheritdoc />
    public IAccountApi Account { get; }
    /// <inheritdoc />
    public ITagsApi Tags { get; }
    /// <inheritdoc />
    public IBookmarksApi Bookmarks { get; }
    /// <inheritdoc />
    public ISlaPoliciesApi SlaPolicies { get; }
    /// <inheritdoc />
    public ICustomStatusesApi CustomStatuses { get; }
    /// <inheritdoc />
    public IDynamicContentApi DynamicContent { get; }
    /// <inheritdoc />
    public ILocalesApi Locales { get; }
    /// <inheritdoc />
    public ITargetsApi Targets { get; }
    /// <inheritdoc />
    public IRequestsApi Requests { get; }
}

