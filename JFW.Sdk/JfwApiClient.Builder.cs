
namespace JFW.Sdk;

/// <summary>
/// Represents the JFW API client.
/// </summary>
public partial class JfwApiClient : IJfwApiClient
{
    /// <summary>
    /// Creates a new builder for constructing a JfwApiClient.
    /// </summary>
    public static Builder CreateBuilder()
    {
        return new Builder();
    }


    /// <summary>
    /// Builder class for constructing JfwApiClient instances.
    /// </summary>
    public class Builder
    {
        private string? _brandUrl;
        private string? _authKey;
        private string? _apiKey;
        private IManagementConnection _managementConnection = default!;
        private Dictionary<string, string> _customHeaders = default!;

        /// <summary>
        /// Initializes a new instance of the <see cref="Builder"/> class.
        /// </summary>
        internal Builder()
        {
            _customHeaders = new Dictionary<string, string>();
        }

        /// <summary>
        /// Sets the brand URL.
        /// </summary>
        public Builder WithBrandUrl(string brandUrl)
        {
            _brandUrl = brandUrl;
            return this;
        }

        /// <summary>
        /// Sets the authentication key.
        /// </summary>
        public Builder WithAuthKey(string authKey)
        {
            _authKey = authKey;
            return this;
        }

        /// <summary>
        /// Sets the API key.
        /// </summary>
        public Builder WithApiKey(string apiKey)
        {
            _apiKey = apiKey;
            return this;
        }

        /// <summary>
        /// Sets the management connection.
        /// </summary>
        public Builder WithManagementConnection(IManagementConnection managementConnection)
        {
            _managementConnection = managementConnection;
            return this;
        }

        /// <summary>
        /// Sets the management connection by the given custom domain.
        /// </summary>
        public Builder WithCustomDomain(string customDomain)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(customDomain);

            var connection = new ManagementConnection(httpClient);
            _managementConnection = connection;
            return this;
        }

        /// <summary>
        /// Adds a custom header to the client.
        /// </summary>
        public Builder WithHeader(string key, string value)
        {
            _customHeaders[key] = value;
            return this;
        }

        /// <summary>
        /// Adds multiple custom headers to the client.
        /// </summary>
        public Builder WithHeaders(Dictionary<string, string> headers)
        {
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    _customHeaders[header.Key] = header.Value;
                }
            }
            return this;
        }

        /// <summary>
        /// Builds the JfwApiClient instance.
        /// </summary>
        /// <returns>A configured JfwApiClient instance.</returns>
        /// <exception cref="InvalidOperationException">Thrown when required parameters are missing.</exception>
        public JfwApiClient Build()
        {
            if (_managementConnection == null)
            {
                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(HostUrl.DefaultHost);

                var connection = new ManagementConnection(httpClient);
                _managementConnection = connection;
            }

            var headers = new Dictionary<string, string>();

            // Add brand URL if provided
            if (!string.IsNullOrWhiteSpace(_brandUrl))
                headers.Add(HeaderKeys.BrandUrl, _brandUrl);

            // Add auth key if provided
            if (!string.IsNullOrWhiteSpace(_authKey))
                headers.Add(HeaderKeys.AuthKey, _authKey);

            // Add API key if provided
            if (!string.IsNullOrWhiteSpace(_apiKey))
                headers.Add(HeaderKeys.ApiKey, _apiKey);

            // Add custom headers (they can override default headers if needed)
            foreach (var header in _customHeaders)
            {
                headers[header.Key] = header.Value;
            }

            return new JfwApiClient(headers, _managementConnection);
        }
    }
}