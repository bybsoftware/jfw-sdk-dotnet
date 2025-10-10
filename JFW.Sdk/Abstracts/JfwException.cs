using JFW.Sdk.Clients.Abstracts;

namespace JFW.Sdk.Abstracts;

/// <summary>
/// The JFW exception
/// </summary>
public class JfwException : Exception
{
    /// <summary>
    /// The error code
    /// </summary>
    public string Code { get; set; } = default!;

    /// <summary>
    /// 
    /// </summary>
    public JfwException() { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="code"></param>
    /// <param name="message"></param>
    public JfwException(string code, string message) : base(message)
    {
        Code = code;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="apiErrorResponse"></param>
    public JfwException(ApiErrorResponse apiErrorResponse) : this(apiErrorResponse.Code, apiErrorResponse.Message)
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="apiErrorsResponse"></param>
    public static JfwException Create(ApiErrorResponse[]? apiErrorsResponse)
    {
        if (apiErrorsResponse != null && apiErrorsResponse.Any())
        {
            return new JfwException(apiErrorsResponse.First());
        }

        return new JfwException("UnknownError", "Unknown error message");
    }
}