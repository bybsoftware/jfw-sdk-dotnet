
namespace JFW.Sdk.Clients.Interfaces;

/// <summary>
/// The quota usage client interface.
/// </summary>
public interface IQuotaUsagesClient
{
    /// <summary>
    /// Tries to consume quota based on the provided request.
    /// </summary>
    /// <remarks>
    /// This method attempts to consume quota as specified in the <see cref="ConsumeQuotaRequest"/>.
    /// It requires the category Code as a string parameter.
    /// API Endpoint: POST api/v1/quota-usages/consume
    /// </remarks>
    /// <param name="request">The quota consumption request.</param>
    /// <returns></returns>
    Task<QuotaUsage?> TryConsumeAsync(ConsumeQuotaRequest request);

}