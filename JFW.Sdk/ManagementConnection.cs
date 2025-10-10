using System.Text;
using JFW.Sdk.Abstracts;
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


    internal ApiResponse<T>? DeserializeContent<T>(string content, JsonConverter[]? converters = null)
    {
        return JsonConvert.DeserializeObject<ApiResponse<T>>(content,
            converters == null ? jsonSerializerSettings : new JsonSerializerSettings() { Converters = converters });

    }

    private static HttpContent? CreateContent<T>(T? body, string contentType)
    {
        if (body == null)
            return null;

        return contentType switch
        {
            MimeTypes.ApplicationJson => new StringContent(
                JsonConvert.SerializeObject(body, jsonSerializerSettings),
                Encoding.UTF8,
                MimeTypes.ApplicationJson
            ),

            MimeTypes.ApplicationFormUrlEncoded when body is IDictionary<string, object> dict =>
                new FormUrlEncodedContent(
                    dict.Select(p => new KeyValuePair<string, string>(
                        p.Key,
                        p.Value?.ToString() ?? string.Empty
                    ))
                ),

            MimeTypes.MultipartFormData when body is MultipartFormDataContent multipartData =>
                CreateMultipartContent(multipartData),

            MimeTypes.MultipartFormData =>
                throw new ArgumentException(
                    $"Body must be of type {nameof(MultipartFormDataContent)} when using {MimeTypes.MultipartFormData}",
                    nameof(body)
                ),

            _ => throw new NotSupportedException($"Content type '{contentType}' is not supported.")
        };
    }

    private string BuildUrl(string url)
    {
        if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
            return url;

        return $"{BaseUrl}/{url.TrimStart('/')}";
    }

    /// <summary>
    /// Creates a MultipartFormDataContent from the provided data.
    /// </summary>
    /// <param name="data">The multipart form data content.</param>
    /// <returns>An HttpContent instance containing the multipart form data.</returns>
    private static HttpContent CreateMultipartContent(MultipartFormDataContent data)
    {
        var content = new System.Net.Http.MultipartFormDataContent();

        // Add text fields
        foreach (var field in data.Fields)
        {
            content.Add(new StringContent(field.Value ?? string.Empty), field.Key);
        }

        // Add files
        foreach (var file in data.Files)
        {
            var fileContent = new ByteArrayContent(file.Value.Content);
            fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.Value.ContentType);
            content.Add(fileContent, file.Key, file.Value.FileName);
        }

        return content;
    }

    /// <inheritdoc/>
    public async Task<TResponse?> SendAsync<TRequest, TResponse>(
        HttpMethod method,
        string url,
        TRequest? body = default,
        string contentType = MimeTypes.ApplicationJson,
        IDictionary<string, string>? headers = null,
        JsonConverter[]? converters = null,
        CancellationToken cancellationToken = default
    )
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

        using var response = await _httpClient.SendAsync(request, cancellationToken);

        //response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();

        if (typeof(TResponse) == typeof(string))
        {
            return (TResponse)(object)content;
        }

        var apiResponse = DeserializeContent<TResponse>(content, converters);

        if (apiResponse == null)
            return default;

        if (apiResponse.Success)
            return apiResponse.Data;
        throw JfwException.Create(apiResponse.Errors);
    }

    /// <inheritdoc/>
    public Task<T?> GetAsync<T>(string url, IDictionary<string, string>? headers = null, JsonConverter[]? converters = null, CancellationToken cancellationToken = default)
        => SendAsync<object?, T>(HttpMethod.Get, url, null, MimeTypes.ApplicationJson, headers, converters, cancellationToken);

    /// <inheritdoc/>
    public Task<T?> PostAsync<T>(string url, object? body, IDictionary<string, string>? headers = null, string contentType = MimeTypes.ApplicationJson, JsonConverter[]? converters = null, CancellationToken cancellationToken = default)
        => SendAsync<object?, T>(HttpMethod.Post, url, body, contentType, headers, converters, cancellationToken);

    /// <inheritdoc/>
    public Task<T?> PutAsync<T>(string url, object? body, IDictionary<string, string>? headers = null, string contentType = MimeTypes.ApplicationJson, JsonConverter[]? converters = null, CancellationToken cancellationToken = default)
        => SendAsync<object?, T>(HttpMethod.Put, url, body, contentType, headers, converters, cancellationToken);

    /// <inheritdoc/>
    public Task<T?> PatchAsync<T>(string url, object? body, IDictionary<string, string>? headers = null, string contentType = MimeTypes.ApplicationJson, JsonConverter[]? converters = null, CancellationToken cancellationToken = default)
        => SendAsync<object?, T>(HttpMethod.Patch, url, body, contentType, headers, converters, cancellationToken);

    /// <inheritdoc/>
    public Task<T?> DeleteAsync<T>(string url, IDictionary<string, string>? headers = null, JsonConverter[]? converters = null, CancellationToken cancellationToken = default)
        => SendAsync<object?, T>(HttpMethod.Delete, url, null, MimeTypes.ApplicationJson, headers, converters, cancellationToken);


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


/// <summary>
/// Represents a file to be uploaded in a multipart/form-data request.
/// </summary>
public class FileContent
{
    /// <summary>
    /// Gets or sets the file name.
    /// </summary>
    public string FileName { get; set; }

    /// <summary>
    /// Gets or sets the file content as a byte array.
    /// </summary>
    public byte[] Content { get; set; }

    /// <summary>
    /// Gets or sets the content type (MIME type) of the file.
    /// </summary>
    public string ContentType { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="FileContent"/> class.
    /// </summary>
    /// <param name="fileName">The name of the file.</param>
    /// <param name="content">The file content as bytes.</param>
    /// <param name="contentType">The MIME type of the file. Defaults to application/octet-stream.</param>
    public FileContent(string fileName, byte[] content, string contentType = MimeTypes.ApplicationOctetStream)
    {
        FileName = fileName;
        Content = content;
        ContentType = contentType;
    }

    /// <summary>
    /// Creates a FileContent from a file path.
    /// </summary>
    /// <param name="filePath">The path to the file.</param>
    /// <returns>A new FileContent instance.</returns>
    public static FileContent FromFile(string filePath)
    {
        var fileName = Path.GetFileName(filePath);
        var content = File.ReadAllBytes(filePath);
        var contentType = MimeTypes.GetMimeTypeByFilename(fileName);
        return new FileContent(fileName, content, contentType);
    }

    /// <summary>
    /// Creates a FileContent from a stream.
    /// </summary>
    /// <param name="fileName">The name of the file.</param>
    /// <param name="stream">The stream containing the file data.</param>
    /// <param name="contentType">The MIME type of the file.</param>
    /// <returns>A new FileContent instance.</returns>
    public static FileContent FromStream(string fileName, Stream stream, string? contentType = null)
    {
        using var memoryStream = new MemoryStream();
        stream.CopyTo(memoryStream);
        var content = memoryStream.ToArray();
        contentType ??= MimeTypes.GetMimeTypeByFilename(fileName);
        return new FileContent(fileName, content, contentType);
    }
}

/// <summary>
/// Represents the body content for a multipart/form-data request.
/// </summary>
public class MultipartFormDataContent
{
    /// <summary>
    /// Gets or sets the form fields as key-value pairs.
    /// </summary>
    public IDictionary<string, string> Fields { get; set; } = new Dictionary<string, string>();

    /// <summary>
    /// Gets or sets the files to be uploaded.
    /// </summary>
    public IDictionary<string, FileContent> Files { get; set; } = new Dictionary<string, FileContent>();

    /// <summary>
    /// Adds a text field to the form data.
    /// </summary>
    /// <param name="name">The field name.</param>
    /// <param name="value">The field value.</param>
    public void AddField(string name, string value)
    {
        Fields[name] = value;
    }

    /// <summary>
    /// Adds a file to the form data.
    /// </summary>
    /// <param name="name">The field name for the file.</param>
    /// <param name="file">The file content.</param>
    public void AddFile(string name, FileContent file)
    {
        Files[name] = file;
    }
}