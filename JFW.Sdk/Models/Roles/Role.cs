
using JFW.Sdk.Clients.Abstracts;

namespace JFW.Sdk.Models;

/// <summary>
/// The role model.
/// </summary>
public class Role : BaseModel
{
    /// <summary>
    /// The parent brand id of the Role.
    /// </summary>
    public string? ParentBrandId { get; set; }

    /// <summary>
    /// The guid of the Role.
    /// </summary>
    public Guid Guid { get; set; }

    /// <summary>
    /// The code of the Role.
    /// </summary>
    public string Code { get; set; } = null!;

    /// <summary>
    /// The name of the Role.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// The description of the Role.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// The tags of the Role.
    /// </summary>
    public string? Tags { get; set; }

    /// <summary>
    /// The codes of the permissions for the Role.
    /// </summary>
    public List<string> Permissions { get; set; } = new List<string>();
}
