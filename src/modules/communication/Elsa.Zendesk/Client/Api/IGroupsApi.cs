using Elsa.Zendesk.Models;
using Refit;

namespace Elsa.Zendesk.Client.Api;

/// <summary>Refit interface for the Zendesk Groups API.</summary>
public interface IGroupsApi
{
    [Get("/api/v2/groups")]
    Task<ZendeskListResponse<Group>> ListGroupsAsync([Query] int? page = null, [Query] int? per_page = null, CancellationToken cancellationToken = default);

    [Post("/api/v2/groups")]
    Task<ZendeskResponse<Group>> CreateGroupAsync([Body] CreateGroupRequest body, CancellationToken cancellationToken = default);

    [Get("/api/v2/groups/{groupId}")]
    Task<ZendeskResponse<Group>> ShowGroupAsync(long groupId, CancellationToken cancellationToken = default);

    [Put("/api/v2/groups/{groupId}")]
    Task<ZendeskResponse<Group>> UpdateGroupAsync(long groupId, [Body] UpdateGroupRequest body, CancellationToken cancellationToken = default);

    [Get("/api/v2/groups/{groupId}/users")]
    Task<ZendeskListResponse<User>> ListGroupUsersAsync(long groupId, [Query] int? page = null, [Query] int? per_page = null, CancellationToken cancellationToken = default);

    [Get("/api/v2/group_memberships")]
    Task<ZendeskListResponse<GroupMembership>> ListGroupMembershipsAsync([Query] int? page = null, [Query] int? per_page = null, CancellationToken cancellationToken = default);

    [Post("/api/v2/group_memberships")]
    Task<ZendeskResponse<GroupMembership>> CreateGroupMembershipAsync([Body] CreateGroupMembershipRequest body, CancellationToken cancellationToken = default);

    [Delete("/api/v2/group_memberships/{membershipId}")]
    Task DeleteGroupMembershipAsync(long membershipId, CancellationToken cancellationToken = default);
}

