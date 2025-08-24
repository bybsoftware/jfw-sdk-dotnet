
using JFW.Sdk.Clients.Implements;
using JFW.Sdk.Clients.Interfaces;

namespace JFW.Sdk;

/// <summary>
/// Represents the JFW API client.
/// </summary>
public class JfwApiClient : IJfwApiClient
{
    /// <summary>
    /// The authentication key header key.
    /// </summary>
    public const string AuthKeyHeaderKey = "Auth-Key";

    /// <summary>
    /// The brand URL header key.
    /// </summary>
    public const string BrandUrlHeaderKey = "Brand-Url";

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
    {
        if (string.IsNullOrWhiteSpace(brandUrl))
            throw new ArgumentException("BrandUrl cannot be null or empty.", nameof(brandUrl));

        DefaultHeaders = CreateDefaultHeaders(brandUrl, authKey);

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
            headers.Add(AuthKeyHeaderKey, authKey);

        if (!string.IsNullOrEmpty(brandUrl))
            headers.Add(BrandUrlHeaderKey, brandUrl);

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
        if (DefaultHeaders.ContainsKey(AuthKeyHeaderKey))
            DefaultHeaders[AuthKeyHeaderKey] = authKey;
        else
            DefaultHeaders.Add(AuthKeyHeaderKey, authKey);
    }
}