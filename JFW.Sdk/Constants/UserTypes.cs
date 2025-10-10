/*
* Description: This class provides all constants for the user types.
* Author: Steve Bang.
* History:
* - 2024-08-12: Created - Steve Bang.
*/

namespace JFW.Sdk.Constants
{
    /// <summary>
    /// Provides all the user types.
    /// </summary>
    public class UserTypes
    {
        /// <summary>
        /// The super admin user type. This user type is used for the super administrators.
        /// </summary>
        public const string SuperAdmin = nameof(SuperAdmin);

        /// <summary>
        /// The admin user type. This user type is used for the administrators.
        /// </summary>
        public const string Admin = nameof(Admin);

        /// <summary>
        /// The partner user type. That user type is used for the partners.
        /// </summary>
        public const string Partner = nameof(Partner);

        /// <summary>
        /// The user user type. This user type is used for the users.
        /// </summary>
        public const string User = nameof(User);

    }
}
