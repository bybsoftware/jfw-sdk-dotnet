
namespace JFW.Sdk.Models;

/// <summary>
/// Request model for creating a user by email.
/// </summary>
public class UserCreateByEmailRequest : UserBaseCreateRequest
{
    /// <summary>
    /// The email address of the user to create.
    /// </summary>
    public string EmailAddress { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="UserCreateByEmailRequest"/> class.
    /// </summary>
    public UserCreateByEmailRequest(
        string emailAddress,
        string password,
        string confirmPassword,
        string? firstName = null,
        string? lastName = null,
        string? referralCode = null)
    {
        EmailAddress = emailAddress;
        Password = password;
        ConfirmPassword = confirmPassword;
        FirstName = firstName;
        LastName = lastName;
        ReferralCode = referralCode;
    }

}