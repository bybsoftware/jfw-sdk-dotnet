
namespace JFW.Sdk.Models;

/// <summary>
/// Request model for creating a user with base properties.
/// </summary>
public class UserBaseCreateRequest
{
    /// <summary>
    /// The password for the user to create.
    /// </summary>
    public string Password { get; set; } = null!;

    /// <summary>
    /// Confirmation of the password for the user to create.
    /// </summary>
    public string ConfirmPassword { get; set; } = null!;

    /// <summary>
    /// The first name of the user to create.
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// The last name of the user to create.
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// The referral code, if any, used during the user creation.
    /// </summary>
    public string? ReferralCode { get; set; }

}