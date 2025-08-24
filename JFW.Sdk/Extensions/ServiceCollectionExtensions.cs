using System;
using JFW.Sdk.Abstracts;
using JFW.Sdk.Apis;
using JFW.Sdk.Apis.Implements;
using JFW.Sdk.Models.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
// using Polly;
// using Polly.Extensions.Http;

namespace JFW.Sdk.Extensions
{
    /// <summary>
    /// Extension methods for configuring JFW SDK services
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds JFW SDK services to the service collection
        /// </summary>
        public static IServiceCollection AddJfwSdk(this IServiceCollection services, Action<JfwOptions> configureOptions)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            if (configureOptions == null)
                throw new ArgumentNullException(nameof(configureOptions));

            // Configure options
            services.Configure(configureOptions);

            // Register HTTP client with retry policy
            services.AddHttpClient<BaseJFWClient>((serviceProvider, client) =>
            {
                var options = serviceProvider.GetRequiredService<IOptions<JfwOptions>>().Value;
                client.BaseAddress = new Uri(options.BaseUrl);
                client.Timeout = TimeSpan.FromSeconds(options.TimeoutSeconds);
            });
            //.AddPolicyHandler(GetRetryPolicy());

            // Register API implementations
            services.AddScoped<IAuthApi, AuthApi>();

            return services;
        }

        // private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        // {
        //     return HttpPolicyExtensions
        //         .HandleTransientHttpError()
        //         .WaitAndRetryAsync(3, retryAttempt => 
        //             TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        // }
    }
} 