
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
    /// <param name="queryStrings"></param>
    /// <returns></returns>
    public static string BuildUriQuery(Uri baseUri, IDictionary<string, string> queryStrings)
    {
        string? queryString = AddQueryString(queryStrings);

        return BuildUriQuery(baseUri, queryString);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="baseUri"></param>
    /// <param name="relativePath"></param>
    /// <returns></returns>
    public static string BuildUriRelative(Uri baseUri, string? relativePath = null)
    {
        if (string.IsNullOrEmpty(relativePath))
            return baseUri.ToString();
        else
            return $"{baseUri}/{relativePath}";
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="baseUri"></param>
    /// <param name="relativePath"></param>
    /// <param name="queryStrings"></param>
    /// <returns></returns>
    public static string BuildUri(Uri baseUri, string relativePath, IDictionary<string, string> queryStrings)
    {
        string uri = BuildUriRelative(baseUri, relativePath);

        return BuildUriQuery(new Uri(uri, UriKind.Relative), queryStrings);
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