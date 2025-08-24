
using JFW.Sdk.Clients.Abstracts;

namespace JFW.Sdk.Models;

/// <summary>
/// The user model.
/// </summary>
public class User : BaseModel
{
    /// <summary>
    /// The brand id.
    /// </summary>
    public string BrandId { get; set; } = null!;


    /// <summary>
    /// The user code.
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    /// The username.
    /// </summary>
    public string? Username { get; set; }

    /// <summary>
    /// The first name.
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// The last name.
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// The nick name.
    /// </summary>
    public string? NickName { get; set; }

    /// <summary>
    /// The avatar.
    /// </summary>
    public string? Avatar { get; set; }

    /// <summary>
    /// The email address.
    /// </summary>
    public string? EmailAddress { get; set; }

    /// <summary>
    /// The phone number of the user.
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// The website.
    /// </summary>
    public string? Website { get; set; }

    /// <summary>
    /// The bio.
    /// </summary>
    public string? Bio { get; set; }

    /// <summary>
    /// The email address is verified.
    /// </summary>
    public bool IsEmailAddressVerified { get; set; }

    /// <summary>
    /// The user is verified.
    /// </summary>
    public bool IsUserVerified { get; set; }

    /// <summary>
    /// The risk mark.
    /// </summary>
    public byte? RiskMark { get; set; }


    /// <summary>
    /// The referral code.
    /// </summary>
    public string? ReferralCode { get; set; }

    /// <summary>
    /// The test mode.
    /// </summary>
    public bool TestMode { get; set; }

    /// <summary>
    /// The tags.
    /// </summary>
    public string? Tags { get; set; }

    /// <summary>
    /// The status of the user.
    /// </summary>
    public string Status { get; set; } = null!;

    /// <summary>
    /// Is system user.
    /// </summary>
    public bool IsSystem { get; set; }


    /// <summary>
    /// The language code.
    /// </summary>
    public string? LanguageCode { get; set; }

    /// <summary>
    /// The country code.
    /// </summary>
    public string? CountryCode { get; set; }

    /// <summary>
    /// The time zone id.
    /// </summary>
    public string? TimeZoneId { get; set; }

    /// <summary>
    /// The expiry date package of the user.
    /// </summary>
    public DateTime? ExpiryDate { get; set; }

    /// <summary>
    /// The theme style.
    /// </summary>
    public string? ThemeStyle { get; set; }

    /// <summary>
    /// Enable sign in detection.
    /// </summary>
    public bool? EnableSignInDetection { get; set; }

    /// <summary>
    /// Flag to check if the user is an integration from another application. E.g. Google, Apple, etc.
    /// </summary>
    public bool IsUserIntegration { get; set; }
}