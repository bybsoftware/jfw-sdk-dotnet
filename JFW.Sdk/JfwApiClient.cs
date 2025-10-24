
using JFW.Sdk.Clients.Implements;
using JFW.Sdk.Clients.Interfaces;

namespace JFW.Sdk;

/// <summary>
/// Represents the JFW API client.
/// </summary>
public partial class JfwApiClient : IJfwApiClient
{
    /// <inheritdoc/>
    public ICdnClient Cdn { get; }

    /// <inheritdoc/>
    public IEventsClient Events { get; }

    /// <inheritdoc/>
    public IIssueCategoriesClient IssueCategories { get; }

    /// <inheritdoc/>
    public IFeaturesClient Features { get; }
    
    /// <inheritdoc/>
    public IQuotaUsagesClient QuotaUsages { get; }

    /// <inheritdoc/>
    public IRolesClient Roles { get; }

    /// <inheritdoc/>
    public IUsersClient Users { get; }


    /// <summary>
    /// The default headers included with every request this client makes.
    /// </summary>
    private Dictionary<string, string> DefaultHeaders { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="JfwApiClient"/> class.
    /// </summary>
    /// <param name="brandUrl">The brand URL.</param>
    /// <param name="authKey">The authentication key.</param>
    /// <param name="managementConnection">The management connection.</param>
    /// <exception cref="ArgumentException">brandUrl cannot be null or empty. - brandUrl</exception>
    /// <exception cref="ArgumentNullException">managementConnection</exception>
    public JfwApiClient(string brandUrl, string authKey, IManagementConnection managementConnection)
        : this(CreateDefaultHeaders(brandUrl, authKey), managementConnection)
    {
        if (string.IsNullOrWhiteSpace(brandUrl))
            throw new ArgumentException("BrandUrl cannot be null or empty.", nameof(brandUrl));
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="JfwApiClient"/> class.
    /// </summary>
    /// <param name="headerRequest">The default header request</param>
    /// <param name="managementConnection">The management connection.</param>
    public JfwApiClient(Dictionary<string, string> headerRequest, IManagementConnection managementConnection)
    {
        if (headerRequest is null)
            throw new ArgumentNullException(nameof(headerRequest));
        if (managementConnection is null)
            throw new ArgumentNullException(nameof(managementConnection));

        DefaultHeaders = headerRequest;

        Cdn = new CdnClient(managementConnection, DefaultHeaders);
        Events = new EventsClient(managementConnection, DefaultHeaders);
        IssueCategories = new IssueCategoriesClient(managementConnection, DefaultHeaders);
        Features = new FeaturesClient(managementConnection, DefaultHeaders);
        QuotaUsages = new QuotaUsagesClient(managementConnection, DefaultHeaders);
        Roles = new RolesClient(managementConnection, DefaultHeaders);
        Users = new UsersClient(managementConnection, DefaultHeaders);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="JfwApiClient"/> class.
    /// </summary>
    /// <param name="brandUrl">The brand URL.</param>
    /// <param name="managementConnection">The management connection.</param>
    /// <exception cref="ArgumentException">brandUrl cannot be null or empty. - brandUrl</exception>
    /// <exception cref="ArgumentNullException">managementConnection</exception>
    public JfwApiClient(string brandUrl, IManagementConnection managementConnection) : this(brandUrl, string.Empty, managementConnection)
    {
    }

    /// <summary>
    /// Creates the default headers.
    /// </summary>
    /// <param name="brandUrl">The brand URL.</param>
    /// <param name="authKey">The authentication key.</param>
    /// <returns>The default headers.</returns>
    private static Dictionary<string, string> CreateDefaultHeaders(string brandUrl, string authKey)
    {
        var headers = new Dictionary<string, string>();
        if (!string.IsNullOrEmpty(authKey))
            headers.Add(HeaderKeys.AuthKey, authKey);

        if (!string.IsNullOrEmpty(brandUrl))
            headers.Add(HeaderKeys.BrandUrl, brandUrl);

        return headers;
    }

    /// <summary>
    /// Creates the default headers.
    /// </summary>
    /// <param name="apikey">The api key value.</param>
    /// <returns>The default headers.</returns>
    private static Dictionary<string, string> CreateDefaultHeaders(string apikey)
    {
        var headers = new Dictionary<string, string>();
        if (!string.IsNullOrEmpty(apikey))
            headers.Add(HeaderKeys.ApiKey, apikey);

        return headers;
    }

    /// <inheritdoc />
    public void AddOrUpdateDefaultHeader(string key, string value)
    {
        if (DefaultHeaders.ContainsKey(key))
            DefaultHeaders[key] = value;
        else
            DefaultHeaders.Add(key, value);
    }

    /// <inheritdoc />
    public void UpdateAuthKey(string authKey)
    {
        if (DefaultHeaders.ContainsKey(HeaderKeys.AuthKey))
            DefaultHeaders[HeaderKeys.AuthKey] = authKey;
        else
            DefaultHeaders.Add(HeaderKeys.AuthKey, authKey);
    }
}