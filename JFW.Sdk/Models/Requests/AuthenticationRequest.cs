/*
* Description: This class provides the credential information for the API.
* Author: Steve Bang.
* History:
* - 2024-08-12: Created - Steve Bang.
*/

namespace JFW.Sdk.Models.Requests
{
    /// <summary>
    /// This class represents the body of the authentication request.
    /// </summary>
    public class AuthenticationRequest
    {
        /// <summary>
        /// The username of the user.
        /// </summary>
        public string Username { get; set; } = null!;

        /// <summary>
        /// The password of the user.
        /// </summary>
        public string Password { get; set; } = null!;      
    }
}
