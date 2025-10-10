
namespace JFW.Sdk.Models;

/// <summary>
/// The base pagination class
/// </summary>
public class BasePagination
{
    /// <summary>
    /// The default value of page number.
    /// </summary>
    public const int PageNumberDefault = 0;

    /// <summary>
    /// The default value of page size.
    /// </summary>
    public const int PageSizeDefault = 20;

    /// <summary>
    /// The page number of the request. By default, the value is 0.
    /// </summary>
    public int PageNumber { get; set; } = PageNumberDefault;

    /// <summary>
    /// The page size of the request. By default, the value is 20.
    /// </summary>
    public int PageSize { get; set; } = PageSizeDefault;
}