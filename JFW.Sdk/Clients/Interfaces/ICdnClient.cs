
namespace JFW.Sdk.Clients.Interfaces;

/// <summary>
/// The cdn client interface.
/// </summary>
public interface ICdnClient
{
    /// <summary>
    /// Saves the specified file to the CDN folder with CDN file information.
    /// </summary>
    /// <param name="uploadRequest">The payload upload request.</param>
    /// <returns></returns>
    Task<Cdn?> UploadAsync(CdnUploadRequest uploadRequest);
}