using Elsa.Zendesk.Models;
using Refit;

namespace Elsa.Zendesk.Client.Api;

/// <summary>Refit interface for the Zendesk Brands API.</summary>
public interface IBrandsApi
{
    [Get("/api/v2/brands")]
    Task<ZendeskListResponse<Brand>> ListBrandsAsync([Query] int? page = null, [Query] int? per_page = null, CancellationToken cancellationToken = default);

    [Post("/api/v2/brands")]
    Task<ZendeskResponse<Brand>> CreateBrandAsync([Body] CreateBrandRequest body, CancellationToken cancellationToken = default);

    [Get("/api/v2/brands/{brandId}")]
    Task<ZendeskResponse<Brand>> ShowBrandAsync(long brandId, CancellationToken cancellationToken = default);

    [Put("/api/v2/brands/{brandId}")]
    Task<ZendeskResponse<Brand>> UpdateBrandAsync(long brandId, [Body] UpdateBrandRequest body, CancellationToken cancellationToken = default);

    [Delete("/api/v2/brands/{brandId}")]
    Task DeleteBrandAsync(long brandId, CancellationToken cancellationToken = default);
}

/// <summary>Refit interface for the Zendesk Attachments and Uploads API.</summary>
public interface IAttachmentsApi
{
    [Get("/api/v2/attachments/{attachmentId}")]
    Task<ZendeskResponse<Attachment>> ShowAttachmentAsync(long attachmentId, CancellationToken cancellationToken = default);

    [Delete("/api/v2/attachments/{attachmentId}")]
    Task DeleteAttachmentAsync(long attachmentId, CancellationToken cancellationToken = default);

    [Post("/api/v2/uploads")]
    Task<UploadResponse> UploadFileAsync([Body] StreamPart file, [Query] string filename, [Query] string? token = null, CancellationToken cancellationToken = default);

    [Delete("/api/v2/uploads/{uploadToken}")]
    Task DeleteUploadAsync(string uploadToken, CancellationToken cancellationToken = default);
}

