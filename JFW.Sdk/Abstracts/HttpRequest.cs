

namespace JFW.Sdk.Abstracts
{
    //
    // Summary:
    //     Represents an HTTP request with a URI and optional payload and parameters.
    public class HttpRequest
    {

        /// <summary>
        /// This is the uri to send the request to.
        /// </summary>
        public string Uri { get; set; }


        /// <summary>
        /// This is the payload to send with the request.
        /// </summary>
        public object Payload { get; set; }


        /// <summary>
        /// This is the set of query parameters to send with the request.
        /// </summary>
        public IEnumerable<KeyValuePair<string, object>> QueryParameters { get; set; } = Enumerable.Empty<KeyValuePair<string, object>>();


        /// <summary>
        /// This is the set of path parameters to apply to the request URI.
        /// </summary>
        public IEnumerable<KeyValuePair<string, object>> PathParameters { get; set; } = Enumerable.Empty<KeyValuePair<string, object>>();


        /// <summary>
        /// Gets or sets the headers to send with the request.
        /// This is a dictionary of key-value pairs.
        /// </summary>
        public IDictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// Builds the URL request from the URI, query parameters, and path parameters.
        /// </summary>
        /// <returns></returns>
        public string BuildUrlRequest()
        {
            if (Uri == null)
            {
                throw new ArgumentNullException(nameof(Uri));
            }

            var uri = Uri;

            // Add path parameters to the URI
            if (PathParameters != null)
            {
                foreach (var pathParameter in PathParameters)
                {
                    uri = uri.Replace($"{{{pathParameter.Key}}}", pathParameter.Value.ToString());
                }
            }

            // Add query parameters to the URI
            if (QueryParameters != null && QueryParameters.Any())
            {
                var queryString = string.Join("&", QueryParameters.Select(x => $"{x.Key}={x.Value}"));
                uri = $"{uri}?{queryString}";
            }

            return uri;
        }

    }


}
