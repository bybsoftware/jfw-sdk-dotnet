
using JFW.Sdk.Abstracts;
using JFW.Sdk.Exceptions;
using JFW.Sdk.Models.Requests;
using JFW.Sdk.Models.Responses;
using Microsoft.Extensions.Logging;

namespace JFW.Sdk.Apis.Implements
{
    /// <summary>
    /// Implementation of the authentication API
    /// </summary>
    public class AuthApi : IAuthApi
    {
        private readonly BaseJFWClient _client;
        private readonly ILogger<AuthApi> _logger;

        public AuthApi(BaseJFWClient client, ILogger<AuthApi> logger)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Authenticates a user with the provided credentials
        /// </summary>
        public async Task<AuthenticationResponse> AuthAsync(AuthenticationRequest request)
        {
            try
            {
                _logger.LogInformation("Attempting to authenticate user {Username}", request.Username);

                var httpRequest = new HttpRequest
                {
                    Uri = "api/v1/users/auth",
                    Payload = request
                };

                var response = await _client.PostAsync<AuthenticationResponse>(httpRequest);

                _logger.LogInformation("Successfully authenticated user {Username}", request.Username);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to authenticate user {Username}", request.Username);
                throw new JfwAuthenticationException("Authentication failed", ex);
            }
        }

        /// <summary>
        /// Authenticates a user using a passwordless email link
        /// </summary>
        public async Task<AuthenticationResponse> AuthPasswordLessWithEmailLinkAsync()
        {
            try
            {
                _logger.LogInformation("Attempting passwordless authentication with email link");

                var httpRequest = new HttpRequest
                {
                    Uri = "api/v1/users/auth/passwordless/email/link"
                };

                var response = await _client.PostAsync<AuthenticationResponse>(httpRequest);

                _logger.LogInformation("Successfully initiated passwordless authentication with email link");
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to initiate passwordless authentication with email link");
                throw new JfwAuthenticationException("Passwordless authentication with email link failed", ex);
            }
        }

        /// <summary>
        /// Authenticates a user using a passwordless email code
        /// </summary>
        public async Task<AuthenticationResponse> AuthPasswordLessWithEmailCodeAsync()
        {
            try
            {
                _logger.LogInformation("Attempting passwordless authentication with email code");

                var httpRequest = new HttpRequest
                {
                    Uri = "api/v1/users/auth/passwordless/email/code"
                };

                var response = await _client.PostAsync<AuthenticationResponse>(httpRequest);

                _logger.LogInformation("Successfully initiated passwordless authentication with email code");
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to initiate passwordless authentication with email code");
                throw new JfwAuthenticationException("Passwordless authentication with email code failed", ex);
            }
        }

        /// <summary>
        /// Authenticates a user using a passwordless SMS code
        /// </summary>
        public async Task<AuthenticationResponse> AuthPasswordLessWithSMSCodeAsync()
        {
            try
            {
                _logger.LogInformation("Attempting passwordless authentication with SMS code");

                var httpRequest = new HttpRequest
                {
                    Uri = "api/v1/users/auth/passwordless/sms/code"
                };

                var response = await _client.PostAsync<AuthenticationResponse>(httpRequest);

                _logger.LogInformation("Successfully initiated passwordless authentication with SMS code");
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to initiate passwordless authentication with SMS code");
                throw new JfwAuthenticationException("Passwordless authentication with SMS code failed", ex);
            }
        }

        /// <summary>
        /// Registers a new user
        /// </summary>
        public async Task<AuthenticationResponse> RegisterAsync()
        {
            try
            {
                _logger.LogInformation("Attempting to register new user");

                var httpRequest = new HttpRequest
                {
                    Uri = "api/v1/users/register"
                };

                var response = await _client.PostAsync<AuthenticationResponse>(httpRequest);

                _logger.LogInformation("Successfully registered new user");
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to register new user");
                throw new JfwAuthenticationException("User registration failed", ex);
            }
        }

        /// <summary>
        /// Initiates the forgot password process
        /// </summary>
        public async Task<BaseResponse> ForgotPasswordAsync()
        {
            try
            {
                _logger.LogInformation("Attempting to initiate forgot password process");

                var httpRequest = new HttpRequest
                {
                    Uri = "api/v1/users/forgot-password"
                };

                var response = await _client.PostAsync<BaseResponse>(httpRequest);

                _logger.LogInformation("Successfully initiated forgot password process");
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to initiate forgot password process");
                throw new JfwAuthenticationException("Forgot password process failed", ex);
            }
        }
    }
}
