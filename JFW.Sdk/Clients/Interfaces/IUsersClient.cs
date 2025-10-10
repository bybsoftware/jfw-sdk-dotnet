
using JFW.Sdk.Abstracts;

namespace JFW.Sdk.Clients.Interfaces;

/// <summary>
/// The users client interface.
/// </summary>
public interface IUsersClient
{
    /// <summary>
    /// Creates a user by email.
    /// </summary>
    /// <remarks>
    /// This method creates a new user using their email address as the primary identifier.
    /// It requires a <see cref="UserCreateByEmailRequest"/> object containing the necessary
    /// user details.
    /// API Endpoint: POST api/v1/users/register/email-address
    /// </remarks>
    /// <param name="request">The user creation request.</param>
    /// <returns>Returns the created user or null if creation failed.</returns>
    Task<User?> CreateByEmailAsync(UserCreateByEmailRequest request);

    /// <summary>
    /// Creates a user by phone number.
    /// </summary>
    /// <remarks>
    /// This method creates a new user using their phone number as the primary identifier.
    /// It requires a <see cref="UserCreateByPhoneRequest"/> object containing the necessary
    /// user details.
    /// API Endpoint: POST api/v1/users/register/phone-number
    /// </remarks>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<User?> CreateByPhoneAsync(UserCreateByPhoneRequest request);

    /// <summary>
    /// Gets a user by their unique identifier.
    /// </summary>
    /// <remarks>
    /// This method retrieves a user by their unique identifier (ID).
    /// It requires the user ID as a string parameter.
    /// API Endpoint: GET api/v1/users/{id}
    /// </remarks>
    /// <param name="id">The unique identifier of the user.</param>
    /// <returns></returns>
    Task<User?> GetByIdAsync(string id);

    /// <summary>
    /// Gets the user information for the given username.
    /// </summary>
    /// <remarks>
    /// This method retrieves a user by the given username.
    /// API Endpoint: GET api/v1/users/by-username/{username}
    /// </remarks>
    /// <param name="username">The username of the user to get.</param>
    /// <returns></returns>
    Task<User?> GetByUsernameAsync(string username);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<PaginationList<User>?> GetAllAsync(GetUsersRequest request);
}