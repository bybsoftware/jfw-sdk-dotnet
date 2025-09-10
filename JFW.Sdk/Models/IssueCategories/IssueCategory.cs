
namespace JFW.Sdk.Models;

/// <summary>
/// The issue category model.
/// </summary>
public class IssueCategory : BaseModel
{
    /// <summary>
    /// The group code of the issue category.
    /// </summary>
    public string? GroupCode { get; set; }

    /// <summary>
    /// The parent id of the issue category.
    /// </summary>
    public string? ParentId { get; set; }

    /// <summary>
    /// The code of the issue category.
    /// </summary>
    public string Code { get; set; } = default!;

    /// <summary>
    /// The name of the issue category.
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// The description of the issue category.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Is system issue category.
    /// </summary>
    public bool? IsSystem { get; set; }

    /// <summary>
    /// The tags of the issue category.
    /// </summary>
    public string? Tags { get; set; }

    /// <summary>
    /// The links of the issue category.
    /// </summary>
    public string? SuggestionURL { get; set; }

    /// <summary>
    /// The status of the issue category.
    /// </summary>
    public JfwStatus? Status { get; set; }
}