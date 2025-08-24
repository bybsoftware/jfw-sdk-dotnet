using System;

namespace JFW.Sdk.Exceptions
{
    /// <summary>
    /// Base exception class for JFW SDK
    /// </summary>
    public class JfwException : Exception
    {
        /// <summary>
        /// The error code associated with the exception
        /// </summary>
        public string ErrorCode { get; }

        /// <summary>
        /// Creates a new instance of JfwException
        /// </summary>
        public JfwException(string message) : base(message)
        {
        }

        /// <summary>
        /// Creates a new instance of JfwException with an error code
        /// </summary>
        public JfwException(string message, string errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }

        /// <summary>
        /// Creates a new instance of JfwException with an inner exception
        /// </summary>
        public JfwException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Creates a new instance of JfwException with an error code and inner exception
        /// </summary>
        public JfwException(string message, string errorCode, Exception innerException) : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
    }

    /// <summary>
    /// Exception thrown when authentication fails
    /// </summary>
    public class JfwAuthenticationException : JfwException
    {
        public JfwAuthenticationException(string message) : base(message, "AUTH_ERROR")
        {
        }

        public JfwAuthenticationException(string message, Exception innerException) 
            : base(message, "AUTH_ERROR", innerException)
        {
        }
    }

    /// <summary>
    /// Exception thrown when an API request fails
    /// </summary>
    public class JfwApiException : JfwException
    {
        /// <summary>
        /// The HTTP status code of the failed request
        /// </summary>
        public int StatusCode { get; }

        public JfwApiException(string message, int statusCode) 
            : base(message, $"API_ERROR_{statusCode}")
        {
            StatusCode = statusCode;
        }

        public JfwApiException(string message, int statusCode, Exception innerException) 
            : base(message, $"API_ERROR_{statusCode}", innerException)
        {
            StatusCode = statusCode;
        }
    }

    /// <summary>
    /// Exception thrown when the configuration is invalid
    /// </summary>
    public class JfwConfigurationException : JfwException
    {
        public JfwConfigurationException(string message) : base(message, "CONFIG_ERROR")
        {
        }

        public JfwConfigurationException(string message, Exception innerException) 
            : base(message, "CONFIG_ERROR", innerException)
        {
        }
    }
} 