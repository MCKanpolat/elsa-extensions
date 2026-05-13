using Elsa.Workflows.Attributes;
using Elsa.Workflows.Models;
using Elsa.Zendesk.Models;
using JetBrains.Annotations;

namespace Elsa.Zendesk.Activities.Users;

/// <summary>Creates a new Zendesk user.</summary>
[Activity("Elsa.Zendesk.Users", "Zendesk Users", "Creates a new Zendesk user.", DisplayName = "Create User")]
[UsedImplicitly]
public class CreateUser : ZendeskActivity
{
    [Input(Description = "The name of the user.")] public Input<string> UserName { get; set; } = null!;
    [Input(Description = "The email address of the user.")] public Input<string?> Email { get; set; } = null!;
    [Input(Description = "The role of the user (end-user, agent, admin).")] public Input<string?> Role { get; set; } = null!;
    [Input(Description = "The organization ID to assign the user to.")] public Input<long?> OrganizationId { get; set; } = null!;
    [Output(Description = "The created user.")] public Output<User?> User { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var request = new CreateUserRequest
        {
            User = new UserInput
            {
                Name = context.Get(UserName),
                Email = context.Get(Email),
                Role = context.Get(Role),
                OrganizationId = context.Get(OrganizationId)
            }
        };
        var response = await GetClient(context).Users.CreateUserAsync(request, context.CancellationToken);
        context.Set(User, response.User);
    }
}

/// <summary>Gets a Zendesk user by ID.</summary>
[Activity("Elsa.Zendesk.Users", "Zendesk Users", "Gets a Zendesk user by ID.", DisplayName = "Get User")]
[UsedImplicitly]
public class GetUser : ZendeskActivity
{
    [Input(Description = "The ID of the user.")] public Input<long> UserId { get; set; } = null!;
    [Output(Description = "The user.")] public Output<User?> User { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var response = await GetClient(context).Users.ShowUserAsync(context.Get(UserId), context.CancellationToken);
        context.Set(User, response.User);
    }
}

/// <summary>Lists Zendesk users.</summary>
[Activity("Elsa.Zendesk.Users", "Zendesk Users", "Lists Zendesk users.", DisplayName = "List Users")]
[UsedImplicitly]
public class ListUsers : ZendeskActivity
{
    [Input(Description = "Page number.")] public Input<int?> Page { get; set; } = null!;
    [Input(Description = "Results per page.")] public Input<int?> PageSize { get; set; } = null!;
    [Output(Description = "Paged list of users.")] public Output<ZendeskListResponse<User>> Result { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var result = await GetClient(context).Users.ListUsersAsync(context.Get(Page), context.Get(PageSize), context.CancellationToken);
        context.Set(Result, result);
    }
}

/// <summary>Searches for Zendesk users.</summary>
[Activity("Elsa.Zendesk.Users", "Zendesk Users", "Searches for Zendesk users.", DisplayName = "Search Users")]
[UsedImplicitly]
public class SearchUsers : ZendeskActivity
{
    [Input(Description = "The search query.")] public Input<string> Query { get; set; } = null!;
    [Input(Description = "Page number.")] public Input<int?> Page { get; set; } = null!;
    [Input(Description = "Results per page.")] public Input<int?> PageSize { get; set; } = null!;
    [Output(Description = "Paged list of matching users.")] public Output<ZendeskListResponse<User>> Result { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var result = await GetClient(context).Users.SearchUsersAsync(context.Get(Query)!, context.Get(Page), context.Get(PageSize), context.CancellationToken);
        context.Set(Result, result);
    }
}

/// <summary>Updates a Zendesk user.</summary>
[Activity("Elsa.Zendesk.Users", "Zendesk Users", "Updates a Zendesk user.", DisplayName = "Update User")]
[UsedImplicitly]
public class UpdateUser : ZendeskActivity
{
    [Input(Description = "The ID of the user.")] public Input<long> UserId { get; set; } = null!;
    [Input(Description = "New name.")] public Input<string?> UserName { get; set; } = null!;
    [Input(Description = "New email address.")] public Input<string?> Email { get; set; } = null!;
    [Input(Description = "New role.")] public Input<string?> Role { get; set; } = null!;
    [Output(Description = "The updated user.")] public Output<User?> User { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var request = new UpdateUserRequest { User = new UserInput { Name = context.Get(UserName), Email = context.Get(Email), Role = context.Get(Role) } };
        var response = await GetClient(context).Users.UpdateUserAsync(context.Get(UserId), request, context.CancellationToken);
        context.Set(User, response.User);
    }
}

/// <summary>Deletes (suspends) a Zendesk user.</summary>
[Activity("Elsa.Zendesk.Users", "Zendesk Users", "Deletes a Zendesk user.", DisplayName = "Delete User")]
[UsedImplicitly]
public class DeleteUser : ZendeskActivity
{
    [Input(Description = "The ID of the user to delete.")] public Input<long> UserId { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context) =>
        await GetClient(context).Users.DeleteUserAsync(context.Get(UserId), context.CancellationToken);
}

