
namespace JFW.Sdk.Constants;
/// <summary>
/// Represents the status of quota usage in the system.
/// This enum is typically used for quota monitoring, 
/// where thresholds determine how close the user or tenant 
/// is to their allocated limit.
/// <para>
/// Supported values:
/// <ul>
///   <li>
///     Normal - The quota usage is within a safe range. Typically means usage is less than 80% of the total limit.
///   </li>
///   <li>
///     Warning - The quota usage has reached a warning threshold. Clients may display this to prompt the user to take preventive action.
///   </li>
///   <li>
///     Exceeded - The quota usage has reached its maximum (100%). No further quota-consuming actions are allowed.
///   </li>
/// </ul>
/// </para>
/// </summary>
public enum QuotaStatus
{
    /// <summary>
    /// The quota usage is within a safe range.
    /// Typically means usage is less than 80% of the total limit.
    /// </summary>
    Normal,

    /// <summary>
    /// The quota usage has reached a warning threshold.
    /// Usually indicates usage between 80% and 99% of the total limit.
    /// Clients may display this to prompt the user to take preventive action.
    /// </summary>
    Warning,


    /// <summary>
    /// The quota usage has reached its maximum (100%).
    /// No further quota-consuming actions are allowed.
    /// </summary>
    Exceeded
}