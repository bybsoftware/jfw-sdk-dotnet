
using JFW.Sdk.Clients.Interfaces;
using JFW.Sdk.Helpers;

namespace JFW.Sdk.Clients.Implements;

/// <summary>
/// This class provides all methods to call the api/v1/features endpoints.
/// </summary>
public class FeaturesClient : IFeaturesClient
{
    private readonly IManagementConnection Connection;

    /// <summary>
    /// <see cref="Uri"/> of the endpoint to use in making API calls.
    /// </summary>
    protected Uri BaseUri { get; } = new Uri("api/v1/features", UriKind.Relative);

    /// <summary>
    /// Default headers included with every request this client makes.
    /// </summary>
    protected IDictionary<string, string> DefaultHeaders { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="UsersClient"/> class.
    /// </summary>
    public FeaturesClient(IManagementConnection managementConnection, IDictionary<string, string> defaultHeaders)
    {
        Connection = managementConnection ?? throw new ArgumentNullException(nameof(managementConnection));
        DefaultHeaders = defaultHeaders ?? throw new ArgumentNullException(nameof(defaultHeaders));
    }

    /// <inheritdoc/>
    public Task<bool> CheckUserAccessAsync(string userId, string featureCode)
    {
        return Connection.GetAsync<bool>(
        UrlHelper.BuildUri(
            BaseUri, "check", // api/v1/features/check
            new Dictionary<string, string>()
            {
                { nameof(userId), userId },
                { nameof(featureCode), featureCode },
            }), // Build parameters
        DefaultHeaders  
        );
    }
}