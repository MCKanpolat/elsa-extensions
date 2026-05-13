using Elsa.Workflows.Attributes;
using Elsa.Workflows.Models;
using Elsa.Zendesk.Models;
using JetBrains.Annotations;

namespace Elsa.Zendesk.Activities.Brands;

[Activity("Elsa.Zendesk.Brands", "Zendesk Brands", "Creates a brand.", DisplayName = "Create Brand")]
[UsedImplicitly]
public class CreateBrand : ZendeskActivity
{
    [Input(Description = "The name of the brand.")] public Input<string> BrandName { get; set; } = null!;
    [Input(Description = "The subdomain for the brand.")] public Input<string?> Subdomain { get; set; } = null!;
    [Output(Description = "The created brand.")] public Output<Brand?> Brand { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var request = new CreateBrandRequest { Brand = new BrandInput { Name = context.Get(BrandName), Subdomain = context.Get(Subdomain) } };
        var response = await GetClient(context).Brands.CreateBrandAsync(request, context.CancellationToken);
        context.Set(Brand, response.Brand);
    }
}

[Activity("Elsa.Zendesk.Brands", "Zendesk Brands", "Gets a brand by ID.", DisplayName = "Get Brand")]
[UsedImplicitly]
public class GetBrand : ZendeskActivity
{
    [Input(Description = "The ID of the brand.")] public Input<long> BrandId { get; set; } = null!;
    [Output(Description = "The brand.")] public Output<Brand?> Brand { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var response = await GetClient(context).Brands.ShowBrandAsync(context.Get(BrandId), context.CancellationToken);
        context.Set(Brand, response.Brand);
    }
}

[Activity("Elsa.Zendesk.Brands", "Zendesk Brands", "Lists brands.", DisplayName = "List Brands")]
[UsedImplicitly]
public class ListBrands : ZendeskActivity
{
    [Input(Description = "Page number.")] public Input<int?> Page { get; set; } = null!;
    [Input(Description = "Results per page.")] public Input<int?> PageSize { get; set; } = null!;
    [Output(Description = "Paged list of brands.")] public Output<ZendeskListResponse<Brand>> Result { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var result = await GetClient(context).Brands.ListBrandsAsync(context.Get(Page), context.Get(PageSize), context.CancellationToken);
        context.Set(Result, result);
    }
}

[Activity("Elsa.Zendesk.Brands", "Zendesk Brands", "Updates a brand.", DisplayName = "Update Brand")]
[UsedImplicitly]
public class UpdateBrand : ZendeskActivity
{
    [Input(Description = "The ID of the brand.")] public Input<long> BrandId { get; set; } = null!;
    [Input(Description = "New name.")] public Input<string?> BrandName { get; set; } = null!;
    [Output(Description = "The updated brand.")] public Output<Brand?> Brand { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context)
    {
        var request = new UpdateBrandRequest { Brand = new BrandInput { Name = context.Get(BrandName) } };
        var response = await GetClient(context).Brands.UpdateBrandAsync(context.Get(BrandId), request, context.CancellationToken);
        context.Set(Brand, response.Brand);
    }
}

[Activity("Elsa.Zendesk.Brands", "Zendesk Brands", "Deletes a brand.", DisplayName = "Delete Brand")]
[UsedImplicitly]
public class DeleteBrand : ZendeskActivity
{
    [Input(Description = "The ID of the brand to delete.")] public Input<long> BrandId { get; set; } = null!;

    protected override async ValueTask ExecuteAsync(ActivityExecutionContext context) =>
        await GetClient(context).Brands.DeleteBrandAsync(context.Get(BrandId), context.CancellationToken);
}

