
namespace JFW.Sdk.Models;

/// <summary>
/// Specifies criteria to use when querying all users.
/// </summary>
public class ConsumeQuotaRequest
{
    /// <summary>
    /// The ID of the user requesting quota consumption. This identifies who is making the request.
    /// </summary>
    public string? UserId { get; set; }

    /// <summary>
    /// The code of the feature for which quota is being consumed.
    /// </summary>
    public string FeatureCode { get; set; } = null!;

    /// <summary>
    /// The amount of quota to consume. By default, this is set to 1.
    /// </summary>
    public long Amount { get; set; } = 1;

    /// <summary>
    /// The resource associated with the quota consumption. This could be a specific item or entity related to the consumption.
    /// </summary>
    public string? Resource { get; set; }

    /// <summary>
    /// The source of the quota consumption request. This could indicate where the request originated from.
    /// </summary>
    public string? Source { get; set; }

    /// <summary>
    /// Additional metadata related to the quota consumption. This can include any extra information that might be relevant.
    /// </summary>
    public IDictionary<string, string>? Metadata { get; set; }
}