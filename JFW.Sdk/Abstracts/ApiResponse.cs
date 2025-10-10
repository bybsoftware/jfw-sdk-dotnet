
namespace JFW.Sdk.Clients.Abstracts;

/// <summary>
/// The API response.
/// </summary>
/// <typeparam name="T"></typeparam>
public class ApiResponse<T>
{
    /// <summary>
    /// Indicates whether the API call was successful.
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// The HTTP status code returned from the API.
    /// </summary>
    public int StatusCode { get; set; }

    /// <summary>
    /// The data returned from the API, if any.
    /// </summary>
    public T? Data { get; set; }

    /// <summary>
    /// The array of error responses, if any.
    /// </summary>    
    public ApiErrorResponse[]? Errors { get; set; }
}

/// <summary>
/// The API error response.
/// </summary>
public class ApiErrorResponse
{
    /// <summary>
    /// The error message.
    /// </summary>
    public string Message { get; set; } = null!;

    /// <summary>
    /// The error code.
    /// </summary>
    public string Code { get; set; } = null!;

    /// <summary>
    /// The correlation ID for the request.
    /// </summary>
    public string CorrelationId { get; set; } = null!;
}