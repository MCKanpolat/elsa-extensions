using Elsa.Workflows.Attributes;
using Elsa.Workflows.Models;
using Elsa.Zendesk.Models;
using JetBrains.Annotations;

namespace Elsa.Zendesk.Activities.Organizations;

[Activity("Elsa.Zendesk.Organizations", "Zendesk Organizations", "Creates a new organization.", DisplayName = "Create Organization")]
[UsedImplicitly]
public class CreateOrganization : ZendeskActivity
{
    [Input(Description = "The name of the organization.")] public Input<string> OrganizationName { get; set; } = null!;
    [Input(Description = "Notes about the organization.")] public Input<string?> Notes { get; set; } = null!;
    [Input(Description = "Details about the organization.")] public Input<string?> Details { get; set; } = null!;
    [Output(Description = "The created organization.")] public Output<Organization?> Organization { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var request = new CreateOrganizationRequest { Organization = new OrganizationInput { Name = context.Get(OrganizationName), Notes = context.Get(Notes), Details = context.Get(Details) } };
        var response = await GetClient(context).Organizations.CreateOrganizationAsync(request, context.CancellationToken);
        context.Set(Organization, response.Organization);
    }
}

[Activity("Elsa.Zendesk.Organizations", "Zendesk Organizations", "Gets an organization by ID.", DisplayName = "Get Organization")]
[UsedImplicitly]
public class GetOrganization : ZendeskActivity
{
    [Input(Description = "The ID of the organization.")] public Input<long> OrganizationId { get; set; } = null!;
    [Output(Description = "The organization.")] public Output<Organization?> Organization { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var response = await GetClient(context).Organizations.ShowOrganizationAsync(context.Get(OrganizationId), context.CancellationToken);
        context.Set(Organization, response.Organization);
    }
}

[Activity("Elsa.Zendesk.Organizations", "Zendesk Organizations", "Lists organizations.", DisplayName = "List Organizations")]
[UsedImplicitly]
public class ListOrganizations : ZendeskActivity
{
    [Input(Description = "Page number.")] public Input<int?> Page { get; set; } = null!;
    [Input(Description = "Results per page.")] public Input<int?> PageSize { get; set; } = null!;
    [Output(Description = "Paged list of organizations.")] public Output<ZendeskListResponse<Organization>> Result { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var result = await GetClient(context).Organizations.ListOrganizationsAsync(context.Get(Page), context.Get(PageSize), context.CancellationToken);
        context.Set(Result, result);
    }
}

[Activity("Elsa.Zendesk.Organizations", "Zendesk Organizations", "Searches organizations.", DisplayName = "Search Organizations")]
[UsedImplicitly]
public class SearchOrganizations : ZendeskActivity
{
    [Input(Description = "The search query.")] public Input<string> Query { get; set; } = null!;
    [Input(Description = "Page number.")] public Input<int?> Page { get; set; } = null!;
    [Input(Description = "Results per page.")] public Input<int?> PageSize { get; set; } = null!;
    [Output(Description = "Paged list of matching organizations.")] public Output<ZendeskListResponse<Organization>> Result { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var result = await GetClient(context).Organizations.SearchOrganizationsAsync(context.Get(Query)!, context.Get(Page), context.Get(PageSize), context.CancellationToken);
        context.Set(Result, result);
    }
}

[Activity("Elsa.Zendesk.Organizations", "Zendesk Organizations", "Updates an organization.", DisplayName = "Update Organization")]
[UsedImplicitly]
public class UpdateOrganization : ZendeskActivity
{
    [Input(Description = "The ID of the organization.")] public Input<long> OrganizationId { get; set; } = null!;
    [Input(Description = "New name.")] public Input<string?> OrganizationName { get; set; } = null!;
    [Input(Description = "New notes.")] public Input<string?> Notes { get; set; } = null!;
    [Output(Description = "The updated organization.")] public Output<Organization?> Organization { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var request = new UpdateOrganizationRequest { Organization = new OrganizationInput { Name = context.Get(OrganizationName), Notes = context.Get(Notes) } };
        var response = await GetClient(context).Organizations.UpdateOrganizationAsync(context.Get(OrganizationId), request, context.CancellationToken);
        context.Set(Organization, response.Organization);
    }
}

[Activity("Elsa.Zendesk.Organizations", "Zendesk Organizations", "Deletes an organization.", DisplayName = "Delete Organization")]
[UsedImplicitly]
public class DeleteOrganization : ZendeskActivity
{
    [Input(Description = "The ID of the organization to delete.")] public Input<long> OrganizationId { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context) =>
        await GetClient(context).Organizations.DeleteOrganizationAsync(context.Get(OrganizationId), context.CancellationToken);
}

