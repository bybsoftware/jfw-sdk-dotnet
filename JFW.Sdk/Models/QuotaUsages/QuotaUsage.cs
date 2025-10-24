
namespace JFW.Sdk.Models;

/// <summary>
/// The quota usage model.
/// </summary>
public class QuotaUsage : BaseModel
{
    /// <summary>
    /// Gets or sets the amount of quota that has been consumed.
    /// </summary>
    public long UsedAmount { get; set; }

    /// <summary>
    /// Gets or sets the total quota limit for the current period.
    /// A null value indicates that the limit has not been defined.
    /// </summary>
    public long? LimitAmount { get; set; }

    /// <summary>
    /// Gets or sets the remaining quota available for use in the current period.
    /// A null value indicates that it has not been calculated or is not applicable.
    /// </summary>
    public long? RemainingAmount { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the quota is unlimited.
    /// If true, quota usage will always be treated as <see cref="QuotaStatus.Normal"/>.
    /// </summary>
    public bool IsUnlimited { get; set; }

    /// <summary>
    /// Gets or sets the unique key that represents the quota usage period.
    /// This can be used to group or partition quota usage data (e.g., "202509").
    /// </summary>
    public string PeriodKey { get; set; } = default!;

    /// <summary>
    /// Gets or sets the start date of the quota usage period.
    /// </summary>
    public DateTime PeriodStartDate { get; set; }

    /// <summary>
    /// Gets or sets the end date of the quota usage period.
    /// A null value indicates the period is still ongoing or indefinite.
    /// </summary>
    public DateTime? PeriodEndDate { get; set; }

    /// <summary>
    /// Gets or sets the current quota usage status.
    /// This reflects whether the usage is <see cref="QuotaStatus.Normal"/>, 
    /// <see cref="QuotaStatus.Warning"/>, or <see cref="QuotaStatus.Exceeded"/>.
    /// </summary>
    public QuotaStatus Status { get; set; }

    /// <summary>
    /// Gets or sets the date when this quota usage record was last modified.
    /// A null value indicates that the record has not been updated since creation.
    /// </summary>
    public DateTime? ModifiedDate { get; set; }
}