
using JFW.Sdk.Clients.Abstracts;
using JFW.Sdk.Clients.Interfaces;
using JFW.Sdk.Helpers;

namespace JFW.Sdk.Clients.Implements;

/// <summary>
/// This class provides all methods to call the api/v1/features endpoints.
/// </summary>
public class FeaturesClient : BaseClient, IFeaturesClient
{
    /// <inheritdoc/>
    protected override string BaseUriClient => "api/v1/features";


    /// <summary>
    /// Initializes a new instance of the <see cref="FeaturesClient"/> class.
    /// </summary>
    public FeaturesClient(IManagementConnection managementConnection, IDictionary<string, string> defaultHeaders)
        : base(managementConnection, defaultHeaders)
    {
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