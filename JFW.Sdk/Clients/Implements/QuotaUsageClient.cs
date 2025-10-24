
using JFW.Sdk.Clients.Interfaces;
using JFW.Sdk.Helpers;

namespace JFW.Sdk.Clients.Implements;

/// <summary>
/// This class provides all methods to call the api/v1/quota-usages endpoints.
/// </summary>
public class QuotaUsagesClient : BaseClient, IQuotaUsagesClient
{

    /// <inheritdoc/>
    protected override string BaseUriClient => "api/v1/quota-usages";

    /// <summary>
    /// Initializes a new instance of the <see cref="QuotaUsagesClient"/> class.
    /// </summary>
    public QuotaUsagesClient(IManagementConnection managementConnection, IDictionary<string, string> defaultHeaders)
        : base(managementConnection, defaultHeaders)
    {
    }

    /// <inheritdoc/>
    public Task<QuotaUsage?> TryConsumeAsync(ConsumeQuotaRequest request)
    {
        return Connection.PostAsync<QuotaUsage>(
            UrlHelper.BuildUriRelative(BaseUri, "consume"), // api/v1/quota-usages/consume
            request,
            DefaultHeaders
        );
    }
}