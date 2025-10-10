using JFW.Sdk.Models.Requests;
using JFW.Sdk.Models.Responses;

namespace JFW.Sdk.Apis;

public interface IAuthApi
{
    /// <summary>
    /// Authenticates a user with the provided credentials
    /// </summary>
    Task<AuthenticationResponse> AuthAsync(AuthenticationRequest request);

    /// <summary>
    /// Authenticates a user using a passwordless email link
    /// </summary>
    Task<AuthenticationResponse> AuthPasswordLessWithEmailLinkAsync();

    /// <summary>
    /// Authenticates a user using a passwordless email code
    /// </summary>
    Task<AuthenticationResponse> AuthPasswordLessWithEmailCodeAsync();

    /// <summary>
    /// Authenticates a user using a passwordless SMS code
    /// </summary>
    Task<AuthenticationResponse> AuthPasswordLessWithSMSCodeAsync();

    /// <summary>
    /// Registers a new user
    /// </summary>
    Task<AuthenticationResponse> RegisterAsync();

    /// <summary>
    /// Initiates the forgot password process
    /// </summary>
    Task<BaseResponse> ForgotPasswordAsync();
}