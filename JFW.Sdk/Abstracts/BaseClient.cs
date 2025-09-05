
namespace JFW.Sdk.Clients.Abstracts;

/// <summary>
/// 
/// </summary>
public abstract class BaseClient
{
    /// <summary>
    /// 
    /// </summary>
    protected readonly IManagementConnection Connection;

    /// <summary>
    /// Default headers included with every request this client makes.
    /// </summary>
    protected IDictionary<string, string> DefaultHeaders { get; }

    /// <summary>
    /// The base URI of the request client
    /// </summary>
    protected readonly Uri BaseUri;

    /// <summary>
    /// The base URI of the request client
    /// </summary>
    protected abstract string BaseUriClient { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="managementConnection"></param>
    /// <param name="defaultHeaders"></param>
    /// <param name="baseUri"></param>
    public BaseClient(
        IManagementConnection managementConnection,
        IDictionary<string, string> defaultHeaders,
        Uri baseUri
    )
    {
        Connection = managementConnection;
        DefaultHeaders = defaultHeaders;
        BaseUri = baseUri;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="managementConnection"></param>
    /// <param name="defaultHeaders"></param>
    public BaseClient(
        IManagementConnection managementConnection,
        IDictionary<string, string> defaultHeaders
    )
    {
        Connection = managementConnection;
        DefaultHeaders = defaultHeaders;
        BaseUri = new Uri(BaseUriClient, UriKind.Relative);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="managementConnection"></param>
    /// <param name="defaultHeaders"></param>
    /// <param name="baseUri"></param>
    public BaseClient(
        IManagementConnection managementConnection,
        IDictionary<string, string> defaultHeaders,
        string baseUri
    ) : this(
        managementConnection,
        defaultHeaders,
        new Uri(baseUri, UriKind.Relative)
    )
    {
    }

}