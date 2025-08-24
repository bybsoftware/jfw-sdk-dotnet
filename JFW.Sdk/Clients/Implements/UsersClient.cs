
using JFW.Sdk;
using JFW.Sdk.Clients.Interfaces;
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
        return Connection.PostAsync<User>("api/v1/users/register/email-address", request, DefaultHeaders);
    }

    /// <inheritdoc/>
    public Task<User?> CreateByPhoneAsync(UserCreateByPhoneRequest request)
    {
        return Connection.PostAsync<User>("api/v1/users/register/phone-number", request, DefaultHeaders);
    }

    /// <inheritdoc/>
    public Task<User?> GetByIdAsync(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentException("Id cannot be null or empty.", nameof(id));

        return Connection.GetAsync<User>($"api/v1/users/{id}", DefaultHeaders);
    }
}