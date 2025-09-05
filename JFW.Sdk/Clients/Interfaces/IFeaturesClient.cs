
namespace JFW.Sdk.Clients.Interfaces;

/// <summary>
/// The features client interface.
/// </summary>
public interface IFeaturesClient
{
    /// <summary>
    /// Check if the user can access the feature or not.
    /// </summary>
    /// <remarks>
    /// API Endpoint: GET api/v1/features/check
    /// </remarks>
    /// <param name="userId">The id of the user to check.</param>
    /// <param name="featureCode">The code of the feature to check.</param>
    /// <returns></returns>
    Task<bool> CheckUserAccessAsync(string userId, string featureCode);

}