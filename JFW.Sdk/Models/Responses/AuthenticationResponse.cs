/*
* Description: This class provides all constants for the user types.
* Author: Steve Bang.
* History:
* - 2024-08-31: Created - Steve Bang.
*/

using System;

namespace JFW.Sdk.Models.Responses
{
    /// <summary>
    /// Represents the response from an authentication request
    /// </summary>
    public class AuthenticationResponse : BaseResponse
    {
        /// <summary>
        /// The unique identifier of the authenticated user
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The username of the authenticated user
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The email address of the authenticated user
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// The authentication key for subsequent requests
        /// </summary>
        public string AuthKey { get; set; }

        /// <summary>
        /// The expiration time of the authentication token
        /// </summary>
        public DateTime ExpiresAt { get; set; }
    }
}
