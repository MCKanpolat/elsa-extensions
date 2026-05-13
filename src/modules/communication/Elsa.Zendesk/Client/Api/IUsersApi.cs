using Elsa.Zendesk.Models;
using Refit;

namespace Elsa.Zendesk.Client.Api;

/// <summary>Refit interface for the Zendesk Users API.</summary>
public interface IUsersApi
{
    [Get("/api/v2/users")]
    Task<ZendeskListResponse<User>> ListUsersAsync([Query] int? page = null, [Query] int? per_page = null, CancellationToken cancellationToken = default);

    [Get("/api/v2/users/search")]
    Task<ZendeskListResponse<User>> SearchUsersAsync([Query] string query, [Query] int? page = null, [Query] int? per_page = null, CancellationToken cancellationToken = default);

    [Post("/api/v2/users")]
    Task<ZendeskResponse<User>> CreateUserAsync([Body] CreateUserRequest body, CancellationToken cancellationToken = default);

    [Get("/api/v2/users/{userId}")]
    Task<ZendeskResponse<User>> ShowUserAsync(long userId, CancellationToken cancellationToken = default);

    [Put("/api/v2/users/{userId}")]
    Task<ZendeskResponse<User>> UpdateUserAsync(long userId, [Body] UpdateUserRequest body, CancellationToken cancellationToken = default);

    [Delete("/api/v2/users/{userId}")]
    Task<ZendeskResponse<User>> DeleteUserAsync(long userId, CancellationToken cancellationToken = default);
}

