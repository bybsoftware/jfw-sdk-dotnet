
namespace JFW.Sdk.Models;

/// <summary>
/// Specifies criteria to use when querying all users.
/// </summary>
public class GetUsersRequest : BasePagination
{
    /// <summary>
    /// The list id of the user to filter.
    /// </summary>
    public List<string>? Ids { get; set; }

    /// <summary>
    /// The role id of the user.
    /// </summary>
    public string? RoleId { get; set; }
    
    /// <summary>
    /// The code of the user.
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    /// The first name of the user.
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// The last name of the user.
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// The nickname of the user.
    /// </summary>
    public string? NickName { get; set; }

    /// <summary>
    /// Build to dictionary
    /// </summary>
    /// <returns></returns>
    public IDictionary<string, string> ToDictionary()
    {
        var dictionary = new Dictionary<string, string>();

        if (Ids != null && Ids.Any())
            dictionary.Add("ids", string.Join(",", Ids));

        if (!string.IsNullOrEmpty(RoleId))
            dictionary.Add("roleId", RoleId);

        if (!string.IsNullOrEmpty(Code))
            dictionary.Add("code", Code);

        if (!string.IsNullOrEmpty(FirstName))
            dictionary.Add("firstName", FirstName);

        if (!string.IsNullOrEmpty(LastName))
            dictionary.Add("lastName", LastName);

        if (!string.IsNullOrEmpty(NickName))
            dictionary.Add("nickName", NickName);

        return dictionary;
    }
}