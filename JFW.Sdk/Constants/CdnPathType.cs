namespace JFW.Sdk.Constants;

/// <summary>
/// This enum is used to define the CDN path type.
///  This is the root folder of the uploaded file in the CDN.
/// For further information, visit here: https://whitepaper.jframework.io/other-concepts/cdn/cdn-storage
/// </summary>
/// <remarks>
/// Application: The CDN path is based on the application.
/// User: The CDN path is based on the user.
/// </remarks>
public enum CdnPathType
{
    /// <summary>
    /// The CDN path is used for the app files.
    /// </summary>
    App = 0,

    /// <summary>
    /// The CDN path is used for the user files.
    /// </summary>
    User = 1,
}