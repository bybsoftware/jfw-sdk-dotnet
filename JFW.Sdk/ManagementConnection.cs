using System.Text;
using JFW.Sdk.Clients.Abstracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace JFW.Sdk;

/// <summary>
/// Implements <see cref="IManagementConnection"/> using <see cref="HttpClient"/>.
/// </summary>
public class ManagementConnection : IManagementConnection, IDisposable
{
    private static readonly JsonSerializerSettings jsonSerializerSettings = new() { NullValueHandling = NullValueHandling.Ignore, DateParseHandling = DateParseHandling.DateTime, ContractResolver = new CamelCasePropertyNamesContractResolver() };

    private readonly HttpClient _httpClient;

    /// <summary>
    /// The base URL for the API.
    /// </summary>
    public string BaseUrl { get; }

    /// <summary>
    /// The content type for JSON requests.
    /// </summary>
    public const string ApplicationJsonContentType = "application/json";

    // private readonly int MAX_REQUEST_RETRY_JITTER = 250;
    // private readonly int MAX_REQUEST_RETRY_DELAY = 1000;
    // private readonly int MIN_REQUEST_RETRY_DELAY = 250;
    // private readonly int DEFAULT_NUMBER_RETRIES = 3;
    // private readonly int MAX_NUMBER_RETRIES = 10;
    // private readonly int BASE_DELAY = 250;

    /// <summary>
    /// Initializes a new instance of the <see cref="JfwApiClient"/> class.
    /// </summary>
    /// <param name="httpClient">Optional <see cref="HttpClient"/> to use. If not specified one will be created and be used for all requests made by this instance.</param>
    /// <param name="baseUrl">Optional base URL to use for requests. If not specified the <see cref="HttpClient"/>'s <see cref="HttpClient.BaseAddress"/> will be used. If neither is specified an exception will be thrown.</param>
    public ManagementConnection(HttpClient? httpClient = null, string? baseUrl = null)
    {
        _httpClient = httpClient ?? new HttpClient();
        BaseUrl = baseUrl?.TrimEnd('/') ?? _httpClient.BaseAddress?.ToString().TrimEnd('/') ?? throw new ArgumentNullException(nameof(baseUrl), "BaseUrl cannot be null if HttpClient does not have a BaseAddress.");
    }

    private static HttpContent CreateFormUrlEncodedContent(IDictionary<string, object> parameters)
    {
        return new FormUrlEncodedContent(parameters
            .Select(p => new KeyValuePair<string, string>(p.Key, p.Value?.ToString() ?? "")));
    }


    internal T? DeserializeContent<T>(string content, JsonConverter[]? converters = null)
    {
        var apiResponse = JsonConvert.DeserializeObject<ApiResponse<T>>(content,
            converters == null ? jsonSerializerSettings : new JsonSerializerSettings() { Converters = converters });

        return apiResponse != null ? apiResponse.Data : default;
    }

    private static HttpContent? CreateContent<T>(T? body, string contentType)
    {
        if (body == null) return null;

        return contentType switch
        {
            ApplicationJsonContentType => new StringContent(JsonConvert.SerializeObject(body, jsonSerializerSettings), Encoding.UTF8, ApplicationJsonContentType),
            "application/x-www-form-urlencoded" when body is IDictionary<string, object> dict =>
                new FormUrlEncodedContent(dict.Select(p => new KeyValuePair<string, string>(p.Key, p.Value?.ToString() ?? ""))),
            _ => throw new NotSupportedException($"Content type {contentType} not supported")
        };
    }

    private string BuildUrl(string url)
    {
        if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
            return url;

        return $"{BaseUrl}/{url.TrimStart('/')}";
    }

    /// <inheritdoc/>
    public async Task<TResponse?> SendAsync<TRequest, TResponse>(
        HttpMethod method,
        string url,
        TRequest? body = default,
        string contentType = ApplicationJsonContentType,
        IDictionary<string, string>? headers = null,
        JsonConverter[]? converters = null)
    {

        var finalUrl = BuildUrl(url);

        using var request = new HttpRequestMessage(method, finalUrl);

        // Add body if needed
        if (body != null && method != HttpMethod.Get && method != HttpMethod.Head)
        {
            request.Content = CreateContent(body, contentType);
        }

        // Add headers
        if (headers != null)
        {
            foreach (var header in headers)
            {
                if (!request.Headers.TryAddWithoutValidation(header.Key, header.Value))
                {
                    request.Content?.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }
        }

        using var response = await _httpClient.SendAsync(request);

        //response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();

        if (typeof(TResponse) == typeof(string))
        {
            return (TResponse)(object)content;
        }

        return DeserializeContent<TResponse>(content, converters);
    }

    /// <inheritdoc/>
    public Task<T?> GetAsync<T>(string url, IDictionary<string, string>? headers = null, JsonConverter[]? converters = null)
        => SendAsync<object?, T>(HttpMethod.Get, url, null, ApplicationJsonContentType, headers, converters);

    /// <inheritdoc/>
    public Task<T?> PostAsync<T>(string url, object? body, IDictionary<string, string>? headers = null, string contentType = ApplicationJsonContentType, JsonConverter[]? converters = null)
        => SendAsync<object?, T>(HttpMethod.Post, url, body, contentType, headers, converters);

    /// <inheritdoc/>
    public Task<T?> PutAsync<T>(string url, object? body, IDictionary<string, string>? headers = null, string contentType = ApplicationJsonContentType, JsonConverter[]? converters = null)
        => SendAsync<object?, T>(HttpMethod.Put, url, body, contentType, headers, converters);

    /// <inheritdoc/>
    public Task<T?> PatchAsync<T>(string url, object? body, IDictionary<string, string>? headers = null, string contentType = ApplicationJsonContentType, JsonConverter[]? converters = null)
        => SendAsync<object?, T>(HttpMethod.Patch, url, body, contentType, headers, converters);

    /// <inheritdoc/>
    public Task<T?> DeleteAsync<T>(string url, IDictionary<string, string>? headers = null, JsonConverter[]? converters = null)
        => SendAsync<object?, T>(HttpMethod.Delete, url, null, ApplicationJsonContentType, headers, converters);


    /// <summary>
    /// Disposes of any owned disposable resources such as the underlying <see cref="HttpClient"/> if owned.
    /// </summary>
    /// <param name="disposing">Whether we are actually disposing (<see langword="true"/>) or not (<see langword="false"/>).</param>
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _httpClient.Dispose();
        }
    }

    /// <summary>
    /// Disposes of any owned disposable resources such as the underlying <see cref="HttpClient"/> if owned.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
    }
}