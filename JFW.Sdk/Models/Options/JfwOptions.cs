using System;

namespace JFW.Sdk.Models.Options
{
    /// <summary>
    /// Configuration options for the JFW SDK
    /// </summary>
    public class JfwOptions
    {
        /// <summary>
        /// The base URL for the JFW API
        /// </summary>
        public string BaseUrl { get; set; } = null!;

        /// <summary>
        /// The brand URL for authentication
        /// </summary>
        public string BrandUrl { get; set; } = null!;

        /// <summary>
        /// The authentication key
        /// </summary>
        public string? AuthKey { get; set; }

        /// <summary>
        /// Timeout for HTTP requests in seconds
        /// </summary>
        public int TimeoutSeconds { get; set; } = 30;

        /// <summary>
        /// Number of retries for failed requests
        /// </summary>
        public int RetryCount { get; set; } = 3;

        /// <summary>
        /// Delay between retries in milliseconds
        /// </summary>
        public int RetryDelayMilliseconds { get; set; } = 1000;

        /// <summary>
        /// Validates the configuration
        /// </summary>
        public void Validate()
        {
            if (string.IsNullOrEmpty(BaseUrl))
                throw new ArgumentException("BaseUrl is required", nameof(BaseUrl));

            if (string.IsNullOrEmpty(BrandUrl))
                throw new ArgumentException("BrandUrl is required", nameof(BrandUrl));

            if (TimeoutSeconds <= 0)
                throw new ArgumentException("TimeoutSeconds must be greater than 0", nameof(TimeoutSeconds));

            if (RetryCount < 0)
                throw new ArgumentException("RetryCount must be greater than or equal to 0", nameof(RetryCount));

            if (RetryDelayMilliseconds < 0)
                throw new ArgumentException("RetryDelayMilliseconds must be greater than or equal to 0", nameof(RetryDelayMilliseconds));
        }
    }
} 