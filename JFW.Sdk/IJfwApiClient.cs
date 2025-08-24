
using JFW.Sdk.Clients.Interfaces;

namespace JFW.Sdk;

/// <summary>
/// The main interface for interacting with the JFW API.
/// </summary>
public interface IJfwApiClient
{
    /// <summary>
    /// Contains all the methods to call the api/v1/users endpoints.
    /// </summary>
    IUsersClient Users { get; }



    /// <summary>
    /// Add or update a default header to be included with every request this client makes.
    /// </summary>
    void AddOrUpdateDefaultHeader(string key, string value);

    /// <summary>
    /// Update the auth key used in the Authorization header for all requests.
    /// </summary>
    /// <param name="authKey"></param>
    void UpdateAuthKey(string authKey);
}