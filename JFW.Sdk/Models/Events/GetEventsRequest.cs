
namespace JFW.Sdk.Models;

/// <summary>
/// Specifies criteria to use when querying all events.
/// </summary>
public class GetEventsRequest : BasePagination
{
    /// <summary>
    /// Filter by GroupCodeName.
    /// </summary>
    public string? GroupCodeName { get; set; }

    /// <summary>
    /// Filter by Code.
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    /// Filter by Name.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Filter by Description.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Filter by Tags.
    /// </summary>
    public string? Tags { get; set; }

    /// <summary>
    /// Filter by ZOrder.
    /// </summary>
    public long? ZOrder { get; set; }

    /// <summary>
    /// Filter by Status.
    /// </summary>
    public JfwStatus? Status { get; set; }

    /// <summary>
    /// Filter by IsSystem.
    /// </summary>
    public bool? IsSystem { get; set; }

    /// <summary>
    /// Filter by IncludeParentBrand.
    /// </summary>
    public bool? IncludeParentBrand { get; set; }

    /// <summary>
    /// Filter by Keywords.
    /// </summary>
    public string? Keywords { get; set; }

    /// <summary>
    /// Build to dictionary
    /// </summary>
    /// <returns></returns>
    public IDictionary<string, string> ToDictionary()
    {
        var dictionary = new Dictionary<string, string>();

        if (!string.IsNullOrEmpty(GroupCodeName))
            dictionary.Add("groupCodeName", GroupCodeName);

        if (!string.IsNullOrEmpty(Code))
            dictionary.Add("code", Code);

        if (!string.IsNullOrEmpty(Name))
            dictionary.Add("name", Name);

        if (!string.IsNullOrEmpty(Description))
            dictionary.Add("description", Description);

        if (!string.IsNullOrEmpty(Tags))
            dictionary.Add("tags", Tags);

        if (ZOrder.HasValue)
            dictionary.Add("zOrder", ZOrder.Value.ToString());

        if (Status.HasValue)
            dictionary.Add("status", Status.Value.ToString());

        if (IsSystem.HasValue)
            dictionary.Add("isSystem", IsSystem.Value.ToString());

        if (IncludeParentBrand.HasValue)
            dictionary.Add("includeParentBrand", IncludeParentBrand.Value.ToString());

        if (!string.IsNullOrEmpty(Keywords))
            dictionary.Add("keywords", Keywords);

        return dictionary;
    }
}