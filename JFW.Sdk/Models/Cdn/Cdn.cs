namespace JFW.Sdk.Models;

/// <summary>
/// The event model.
/// </summary>
public class Cdn : BaseModel
{

    /// <summary>
    /// The reference of the object value.
    /// </summary>
    public string? RefObject { get; set; }

    /// <summary>
    /// The id of reference object value.
    /// </summary>
    public long? RefId { get; set; }

    /// <summary>
    /// The mime type of the file.
    /// </summary>
    public string MimeType { get; set; } = null!;

    /// <summary>
    /// The url of the file.
    /// </summary>
    public string FileURL { get; set; } = null!;

    /// <summary>
    /// The original file name.
    /// </summary>
    public string OriginalFilename { get; set; } = null!;

    /// <summary>
    /// The size of the file.
    /// </summary>
    public long? FileSize { get; set; }

    /// <summary>
    /// The notes of the file.
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// The tags of the file.
    /// </summary>
    public string? Tags { get; set; }

    /// <summary>
    /// The zOrder number of the file.
    /// </summary>
    public long? ZOrder { get; set; }

    /// <summary>
    /// The flag if the brand is below system.
    /// </summary>
    public bool IsSystem { get; set; }
}