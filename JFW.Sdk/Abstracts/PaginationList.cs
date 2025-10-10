
namespace JFW.Sdk.Abstracts;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public class PaginationList<T>
{
    /// <summary>
    /// The list items of the list after get response pagination.
    /// </summary>
    public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();

    /// <summary>
    /// The total items of the list after get response pagination.
    /// </summary>
    public int TotalItems { get; set; }
}