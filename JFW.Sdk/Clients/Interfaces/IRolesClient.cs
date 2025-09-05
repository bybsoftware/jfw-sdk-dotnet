
using JFW.Sdk.Models;

namespace JFW.Sdk.Clients.Interfaces;

/// <summary>
/// The roles client interface.
/// </summary>
public interface IRolesClient
{
    /// <summary>
    /// Get a role by the given id.
    /// </summary>
    /// <remarks>
    /// API Endpoint: GET api/v1/roles/{id}
    /// </remarks>
    /// <param name="id">The id of the role to get.</param>
    /// <returns></returns>
    Task<Role?> GetByIdAsync(string id);
}