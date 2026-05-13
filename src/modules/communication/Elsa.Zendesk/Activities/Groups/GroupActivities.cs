using Elsa.Workflows.Attributes;
using Elsa.Workflows.Models;
using Elsa.Zendesk.Models;
using JetBrains.Annotations;

namespace Elsa.Zendesk.Activities.Groups;

[Activity("Elsa.Zendesk.Groups", "Zendesk Groups", "Creates a new group.", DisplayName = "Create Group")]
[UsedImplicitly]
public class CreateGroup : ZendeskActivity
{
    [Input(Description = "The name of the group.")] public Input<string> Name { get; set; } = null!;
    [Input(Description = "Description of the group.")] public Input<string?> Description { get; set; } = null!;
    [Output(Description = "The created group.")] public Output<Group?> Group { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var request = new CreateGroupRequest { Group = new GroupInput { Name = context.Get(Name), Description = context.Get(Description) } };
        var response = await GetClient(context).Groups.CreateGroupAsync(request, context.CancellationToken);
        context.Set(Group, response.Group);
    }
}

[Activity("Elsa.Zendesk.Groups", "Zendesk Groups", "Gets a group by ID.", DisplayName = "Get Group")]
[UsedImplicitly]
public class GetGroup : ZendeskActivity
{
    [Input(Description = "The ID of the group.")] public Input<long> GroupId { get; set; } = null!;
    [Output(Description = "The group.")] public Output<Group?> Group { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var response = await GetClient(context).Groups.ShowGroupAsync(context.Get(GroupId), context.CancellationToken);
        context.Set(Group, response.Group);
    }
}

[Activity("Elsa.Zendesk.Groups", "Zendesk Groups", "Lists groups.", DisplayName = "List Groups")]
[UsedImplicitly]
public class ListGroups : ZendeskActivity
{
    [Input(Description = "Page number.")] public Input<int?> Page { get; set; } = null!;
    [Input(Description = "Results per page.")] public Input<int?> PageSize { get; set; } = null!;
    [Output(Description = "Paged list of groups.")] public Output<ZendeskListResponse<Group>> Result { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var result = await GetClient(context).Groups.ListGroupsAsync(context.Get(Page), context.Get(PageSize), context.CancellationToken);
        context.Set(Result, result);
    }
}

[Activity("Elsa.Zendesk.Groups", "Zendesk Groups", "Lists users in a group.", DisplayName = "List Group Users")]
[UsedImplicitly]
public class ListGroupUsers : ZendeskActivity
{
    [Input(Description = "The ID of the group.")] public Input<long> GroupId { get; set; } = null!;
    [Input(Description = "Page number.")] public Input<int?> Page { get; set; } = null!;
    [Input(Description = "Results per page.")] public Input<int?> PageSize { get; set; } = null!;
    [Output(Description = "Paged list of users in the group.")] public Output<ZendeskListResponse<User>> Result { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var result = await GetClient(context).Groups.ListGroupUsersAsync(context.Get(GroupId), context.Get(Page), context.Get(PageSize), context.CancellationToken);
        context.Set(Result, result);
    }
}

[Activity("Elsa.Zendesk.Groups", "Zendesk Groups", "Updates a group.", DisplayName = "Update Group")]
[UsedImplicitly]
public class UpdateGroup : ZendeskActivity
{
    [Input(Description = "The ID of the group.")] public Input<long> GroupId { get; set; } = null!;
    [Input(Description = "New name.")] public Input<string?> Name { get; set; } = null!;
    [Output(Description = "The updated group.")] public Output<Group?> Group { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var request = new UpdateGroupRequest { Group = new GroupInput { Name = context.Get(Name) } };
        var response = await GetClient(context).Groups.UpdateGroupAsync(context.Get(GroupId), request, context.CancellationToken);
        context.Set(Group, response.Group);
    }
}

[Activity("Elsa.Zendesk.Groups", "Zendesk Groups", "Creates a group membership.", DisplayName = "Create Group Membership")]
[UsedImplicitly]
public class CreateGroupMembership : ZendeskActivity
{
    [Input(Description = "The user ID.")] public Input<long> UserId { get; set; } = null!;
    [Input(Description = "The group ID.")] public Input<long> GroupId { get; set; } = null!;
    [Output(Description = "The created membership.")] public Output<GroupMembership?> Membership { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var request = new CreateGroupMembershipRequest { GroupMembership = new GroupMembershipInput { UserId = context.Get(UserId), GroupId = context.Get(GroupId) } };
        var response = await GetClient(context).Groups.CreateGroupMembershipAsync(request, context.CancellationToken);
        context.Set(Membership, response.GroupMembership);
    }
}

[Activity("Elsa.Zendesk.Groups", "Zendesk Groups", "Deletes a group membership.", DisplayName = "Delete Group Membership")]
[UsedImplicitly]
public class DeleteGroupMembership : ZendeskActivity
{
    [Input(Description = "The ID of the membership to delete.")] public Input<long> MembershipId { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context) =>
        await GetClient(context).Groups.DeleteGroupMembershipAsync(context.Get(MembershipId), context.CancellationToken);
}

