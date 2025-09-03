


using Newtonsoft.Json;

namespace JFW.Sdk;

/// <summary>
/// Interface for connectivity between <see cref="JfwApiClient"/> and
/// the remote server.
/// </summary>
public interface IManagementConnection
{
    /// <summary>
    /// Sends a generic HTTP request with full control over method, URL, headers, and body.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request body object (use <c>object</c> or <c>null</c> if no body is required).</typeparam>
    /// <typeparam name="TResponse">The expected type of the deserialized response.</typeparam>
    /// <param name="method">The HTTP method (GET, POST, PUT, DELETE, PATCH, etc.).</param>
    /// <param name="url">The relative or absolute request URL. Relative paths are resolved against <c>BaseUrl</c>.</param>
    /// <param name="body">Optional request body. Ignored for methods like GET and HEAD.</param>
    /// <param name="contentType">The request content type. Defaults to <c>application/json</c>. Supports JSON and form-url-encoded.</param>
    /// <param name="headers">Optional per-request headers. These override or supplement default headers (e.g., Authorization).</param>
    /// <param name="converters">Optional custom JSON converters for deserialization.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>The response deserialized into <typeparamref name="TResponse"/>. Returns <c>default</c> if empty or not parsable.</returns>
    Task<TResponse?> SendAsync<TRequest, TResponse>(
        HttpMethod method,
        string url,
        TRequest? body = default,
        string contentType = "application/json",
        IDictionary<string, string>? headers = null,
        JsonConverter[]? converters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sends an HTTP GET request.
    /// </summary>
    /// <typeparam name="T">The expected response type.</typeparam>
    /// <param name="url">The relative or absolute URL of the resource.</param>
    /// <param name="headers">Optional per-request headers.</param>
    /// <param name="converters">Optional custom JSON converters for deserialization.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>The deserialized response body, or <c>default</c> if empty.</returns>
    Task<T?> GetAsync<T>(string url, IDictionary<string, string>? headers = null, JsonConverter[]? converters = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends an HTTP POST request with a request body.
    /// </summary>
    /// <typeparam name="T">The expected response type.</typeparam>
    /// <param name="url">The relative or absolute URL of the resource.</param>
    /// <param name="body">The request body. Can be JSON, form-data, etc.</param>
    /// <param name="headers">Optional per-request headers.</param>
    /// <param name="contentType">The content type for the request body. Defaults to <c>application/json</c>.</param>
    /// <param name="converters">Optional custom JSON converters for deserialization.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>The deserialized response body, or <c>default</c> if empty.</returns>
    Task<T?> PostAsync<T>(string url, object? body, IDictionary<string, string>? headers = null, string contentType = "application/json", JsonConverter[]? converters = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends an HTTP PUT request with a request body, typically used for full resource replacement.
    /// </summary>
    /// <typeparam name="T">The expected response type.</typeparam>
    /// <param name="url">The relative or absolute URL of the resource.</param>
    /// <param name="body">The request body. Can be JSON, form-data, etc.</param>
    /// <param name="headers">Optional per-request headers.</param>
    /// <param name="contentType">The content type for the request body. Defaults to <c>application/json</c>.</param>
    /// <param name="converters">Optional custom JSON converters for deserialization.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>The deserialized response body, or <c>default</c> if empty.</returns>
    Task<T?> PutAsync<T>(string url, object? body, IDictionary<string, string>? headers = null, string contentType = "application/json", JsonConverter[]? converters = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends an HTTP PATCH request with a request body, typically used for partial updates.
    /// </summary>
    /// <typeparam name="T">The expected response type.</typeparam>
    /// <param name="url">The relative or absolute URL of the resource.</param>
    /// <param name="body">The request body containing only fields to be updated.</param>
    /// <param name="headers">Optional per-request headers.</param>
    /// <param name="contentType">The content type for the request body. Defaults to <c>application/json</c>.</param>
    /// <param name="converters">Optional custom JSON converters for deserialization.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>The deserialized response body, or <c>default</c> if empty.</returns>
    Task<T?> PatchAsync<T>(string url, object? body, IDictionary<string, string>? headers = null, string contentType = "application/json", JsonConverter[]? converters = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends an HTTP DELETE request.
    /// </summary>
    /// <typeparam name="T">The expected response type.</typeparam>
    /// <param name="url">The relative or absolute URL of the resource.</param>
    /// <param name="headers">Optional per-request headers.</param>
    /// <param name="converters">Optional custom JSON converters for deserialization.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>The deserialized response body, or <c>default</c> if empty.</returns>
    Task<T?> DeleteAsync<T>(string url, IDictionary<string, string>? headers = null, JsonConverter[]? converters = null, CancellationToken cancellationToken = default);

}