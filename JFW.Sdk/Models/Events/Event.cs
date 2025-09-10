
namespace JFW.Sdk.Models;

/// <summary>
/// The event model.
/// </summary>
public class Event : BaseModel
{
    /// <summary>
    /// The guid of the event.
    /// </summary>
    public Guid Guid { get; set; }

    /// <summary>
    /// The group name of the event.
    /// </summary>
    public string GroupCodeName { get; set; } = null!;

    /// <summary>
    /// The code of the event.
    /// </summary>
    public string Code { get; set; } = null!;

    /// <summary>
    /// The name of the event.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// The description of the tracking event.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// The tracking level of the event.
    /// </summary>
    public short? TrackingLevel { get; set; }

    /// <summary>
    /// The tags of the event.
    /// </summary>
    public string? Tags { get; set; }

    /// <summary>
    /// The z-order of the event.
    /// </summary>
    public long? ZOrder { get; set; }

    /// <summary>
    /// The status of the event.
    /// </summary>
    public JfwStatus Status { get; set; }

    /// <summary>
    /// Flag indicating if the event is a system event.
    /// </summary>
    public bool IsSystem { get; set; }
}