
namespace JFW.Sdk.Models;

/// <summary>
/// Request model for creating a user by phone.
/// </summary>
public class UserCreateByPhoneRequest : UserBaseCreateRequest
{
    /// <summary>
    /// The email address of the user to create.
    /// </summary>
    public string PhoneNumber { get; set; }


    /// <summary>
    /// Initializes a new instance of the <see cref="UserCreateByPhoneRequest"/> class.
    /// </summary>
    public UserCreateByPhoneRequest(
        string phoneNumber,
        string password,
        string confirmPassword,
        string? firstName = null,
        string? lastName = null,
        string? referralCode = null)
    {
        PhoneNumber = phoneNumber;
        Password = password;
        ConfirmPassword = confirmPassword;
        FirstName = firstName;
        LastName = lastName;
        ReferralCode = referralCode;
    }

}