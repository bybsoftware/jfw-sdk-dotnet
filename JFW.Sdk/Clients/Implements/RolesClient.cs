
using JFW.Sdk.Clients.Interfaces;
using JFW.Sdk.Helpers;
using JFW.Sdk.Models;

namespace JFW.Sdk.Clients.Implements;

/// <summary>
/// This class provides all methods to call the api/v1/features endpoints.
/// </summary>
public class RolesClient : IRolesClient
{
    private readonly IManagementConnection Connection;

    /// <summary>
    /// <see cref="Uri"/> of the endpoint to use in making API calls.
    /// </summary>
    protected Uri BaseUri { get; } = new Uri("api/v1/roles", UriKind.Relative);

    /// <summary>
    /// Default headers included with every request this client makes.
    /// </summary>
    protected IDictionary<string, string> DefaultHeaders { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="UsersClient"/> class.
    /// </summary>
    public RolesClient(IManagementConnection managementConnection, IDictionary<string, string> defaultHeaders)
    {
        Connection = managementConnection ?? throw new ArgumentNullException(nameof(managementConnection));
        DefaultHeaders = defaultHeaders ?? throw new ArgumentNullException(nameof(defaultHeaders));
    }

    /// <inheritdoc/>
    public Task<Role?> GetByIdAsync(string id)
    {
        return Connection.GetAsync<Role>(
            UrlHelper.BuildUriRelative(BaseUri, id), // api/v1/roles/{id}
            DefaultHeaders
        );
    }
}