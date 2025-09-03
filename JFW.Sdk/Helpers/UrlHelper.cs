
using System.Text;

namespace JFW.Sdk.Helpers;

/// <summary>
/// 
/// </summary>
public static class UrlHelper
{

    /// <summary>
    /// 
    /// </summary>
    /// <param name="baseUri"></param>
    /// <param name="queryString"></param>
    /// <returns></returns>
    public static string BuildUriQuery(Uri baseUri, string? queryString)
    {
        if (string.IsNullOrEmpty(queryString))
            return baseUri.ToString();
        else
            return $"{baseUri}?{queryString}";
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="baseUri"></param>
    /// <param name="relative"></param>
    /// <returns></returns>
    public static string BuildUriRelative(Uri baseUri, string? relative = null)
    {
        if (string.IsNullOrEmpty(relative))
            return baseUri.ToString();
        else
            return $"{baseUri}/{relative}";
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="queryStrings"></param>
    /// <returns></returns>
    public static string? AddQueryString(IDictionary<string, string> queryStrings)
    {
        // Add the query strings
        var queryString = queryStrings?.Aggregate(new StringBuilder(), (sb, kvp) =>
            {
                if (kvp.Value != null)
                {
                    if (sb.Length > 0)
                        sb = sb.Append('&');

                    sb.Append($"{Uri.EscapeDataString(kvp.Key)}={Uri.EscapeDataString(kvp.Value)}");
                }

                return sb;
            })
            .ToString();
        return queryString;
    }
}