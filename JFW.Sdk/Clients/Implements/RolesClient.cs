
using JFW.Sdk.Clients.Interfaces;
using JFW.Sdk.Helpers;

namespace JFW.Sdk.Clients.Implements;

/// <summary>
/// This class provides all methods to call the api/v1/roles endpoints.
/// </summary>
public class RolesClient : BaseClient, IRolesClient
{

    /// <inheritdoc/>
    protected override string BaseUriClient => "api/v1/roles";

    /// <summary>
    /// Initializes a new instance of the <see cref="UsersClient"/> class.
    /// </summary>
    public RolesClient(IManagementConnection managementConnection, IDictionary<string, string> defaultHeaders)
        : base(managementConnection, defaultHeaders)
    {
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