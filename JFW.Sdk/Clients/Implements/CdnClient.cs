

using JFW.Sdk.Clients.Interfaces;
using JFW.Sdk.Helpers;

namespace JFW.Sdk.Clients.Implements;

/// <summary>
/// This class provides all methods to call the api/v1/events endpoints.
/// </summary>
public class CdnClient : BaseClient, ICdnClient
{
    /// <inheritdoc/>
    protected override string BaseUriClient => "api/v1/cdn";


    /// <summary>
    /// Initializes a new instance of the <see cref="EventsClient"/> class.
    /// </summary>
    public CdnClient(IManagementConnection managementConnection, IDictionary<string, string> defaultHeaders)
        : base(managementConnection, defaultHeaders)
    {
    }

    /// <inheritdoc/>
    public Task<Cdn?> UploadAsync(CdnUploadRequest uploadRequest)
        => Connection.PostAsync<Cdn?>(
            UrlHelper.BuildUriRelative(BaseUri, "upload-file"),
            uploadRequest.ToMultipartFormData(),
            DefaultHeaders,
            MimeTypes.MultipartFormData
        );

}