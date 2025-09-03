
using JFW.Sdk.Abstracts;
using JFW.Sdk.Clients.Interfaces;
using JFW.Sdk.Helpers;
using JFW.Sdk.Models;

namespace JFW.Sdk.Clients.Implements;

/// <summary>
/// This class provides all methods to call the api/v1/users endpoints.
/// </summary>
public class UsersClient : IUsersClient
{
    private readonly IManagementConnection Connection;

    /// <summary>
    /// <see cref="Uri"/> of the endpoint to use in making API calls.
    /// </summary>
    protected Uri BaseUri { get; } = new Uri("api/v1/users", UriKind.Relative);

    /// <summary>
    /// Default headers included with every request this client makes.
    /// </summary>
    protected IDictionary<string, string> DefaultHeaders { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="UsersClient"/> class.
    /// </summary>
    public UsersClient(IManagementConnection managementConnection, IDictionary<string, string> defaultHeaders)
    {
        Connection = managementConnection ?? throw new ArgumentNullException(nameof(managementConnection));
        DefaultHeaders = defaultHeaders ?? throw new ArgumentNullException(nameof(defaultHeaders));
    }


    /// <inheritdoc/>
    public Task<User?> CreateByEmailAsync(UserCreateByEmailRequest request)
    {
        return Connection.PostAsync<User>(UrlHelper.BuildUriRelative(BaseUri, "register/email-address"), request, DefaultHeaders);
    }

    /// <inheritdoc/>
    public Task<User?> CreateByPhoneAsync(UserCreateByPhoneRequest request)
    {
        return Connection.PostAsync<User>(UrlHelper.BuildUriRelative(BaseUri, "register/phone-number"), request, DefaultHeaders);
    }

    /// <inheritdoc/>
    public Task<User?> GetByIdAsync(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentException("Id cannot be null or empty.", nameof(id));

        return Connection.GetAsync<User>(UrlHelper.BuildUriRelative(BaseUri, id), DefaultHeaders);
    }

    /// <inheritdoc/>
    public Task<User?> GetByUsernameAsync(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
            throw new ArgumentException("Username cannot be null or empty.", nameof(username));

        return Connection.GetAsync<User>(UrlHelper.BuildUriRelative(BaseUri, $"by-username/{username}"), DefaultHeaders);
    }

    /// <inheritdoc/>
    public Task<PaginationList<User>?> GetAllAsync(GetUsersRequest request)
    {
        IDictionary<string, string> queryParams = request.ToDictionary();

        string? queryString = UrlHelper.AddQueryString(queryParams);

        return Connection.GetAsync<PaginationList<User>>(UrlHelper.BuildUriQuery(BaseUri, queryString), DefaultHeaders);
    }

}