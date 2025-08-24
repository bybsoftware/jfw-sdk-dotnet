/*
* Description: This class provides all the method required to interact with the JFW API.
* Author: Steve Bang.
* History:
* - 2024-08-31: Created - Steve Bang.
*/

using JFW.Sdk.Constants;
using System.Net.Http.Json;
using System.Text.Json;

namespace JFW.Sdk.Abstracts
{
    /// <summary>
    /// This is the base class for all JFW clients.
    /// </summary>
    public class BaseJFWClient
    {
        private readonly HttpClient _httpClient;

        private string BrandUrl { get; set; }

        private string AuthKey { get; set; }

        public BaseJFWClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new(HostUrl.Host);
            _httpClient = httpClient;
        }

        public BaseJFWClient(HttpClient httpClient, string brandUrl) : this(httpClient)
        {
            if (string.IsNullOrEmpty(brandUrl)) throw new NullReferenceException(nameof(brandUrl));
            BrandUrl = brandUrl;

            _httpClient.DefaultRequestHeaders.Add(HeaderKeys.BrandUrl, brandUrl);
        }

        public BaseJFWClient(HttpClient httpClient, string brandUrl, string authKey) : this(httpClient, brandUrl)
        {
            AuthKey = authKey;
            _httpClient.DefaultRequestHeaders.Add(HeaderKeys.AuthKey, authKey);
        }


        /// <summary>
        /// This method sends a POST request to the API.
        /// </summary>
        /// <typeparam name="BaseResponse"></typeparam>
        /// <param name="httpRequest"></param>
        /// <returns></returns>
        public async Task<BaseResponse> PostAsync<BaseResponse>(HttpRequest httpRequest)
        {
            // Build the URL request
            string urlRequest = httpRequest.BuildUrlRequest();

            // Send the request
            var request = _httpClient.PostAsJsonAsync(urlRequest, httpRequest.Payload);

            return await ReadResponseAsync<BaseResponse>(request);

        }

        /// <summary>
        /// This method sends a GET request to the API.
        /// </summary>
        /// <typeparam name="BaseResponse">The type of the response.</typeparam>
        /// <param name="httpRequest">The request to send.</param>
        /// <returns></returns>
        public async Task<BaseResponse> GetAsync<BaseResponse>(HttpRequest httpRequest)
        {
            // Build the URL request
            string urlRequest = httpRequest.BuildUrlRequest();

            // Send the request
            var request = _httpClient.GetAsync(urlRequest);

            return await ReadResponseAsync<BaseResponse>(request);

        }

        /// <summary>
        /// This method sends a PUT request to the API.
        /// </summary>
        /// <typeparam name="BaseResponse">The type of the response.</typeparam>
        /// <param name="httpRequest">The request to send.</param>
        /// <returns></returns>
        public async Task<BaseResponse> PutAsync<BaseResponse>(HttpRequest httpRequest)
        {
            // Build the URL request
            string urlRequest = httpRequest.BuildUrlRequest();

            // Send the request
            var request = _httpClient.PutAsJsonAsync(urlRequest, httpRequest.Payload);

            return await ReadResponseAsync<BaseResponse>(request);

        }


        /// <summary>
        /// This method used to read the response from the API.
        /// </summary>
        /// <typeparam name="BaseResponse"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        private static async Task<BaseResponse> ReadResponseAsync<BaseResponse>(Task<HttpResponseMessage> request)
        {
            // Wait for the response
            var responseAsString = await request.Result.Content.ReadAsStringAsync();

            // Deserialize the response
            var response = JsonSerializer.Deserialize<BaseResponse>(responseAsString);

            // Return the response
            return response;
        }
    }
}
