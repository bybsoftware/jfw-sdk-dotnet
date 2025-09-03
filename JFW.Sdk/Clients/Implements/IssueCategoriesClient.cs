
using JFW.Sdk.Abstracts;
using JFW.Sdk.Clients.Interfaces;
using JFW.Sdk.Helpers;
using JFW.Sdk.Models;

namespace JFW.Sdk.Clients.Implements;

/// <summary>
/// This class provides all methods to call the api/v1/users endpoints.
/// </summary>
public class IssueCategoriesClient : IIssueCategoriesClient
{
    private readonly IManagementConnection Connection;

    /// <summary>
    /// <see cref="Uri"/> of the endpoint to use in making API calls.
    /// </summary>
    protected Uri BaseUri { get; } = new Uri("api/v1/issue-categories", UriKind.Relative);

    /// <summary>
    /// Default headers included with every request this client makes.
    /// </summary>
    protected IDictionary<string, string> DefaultHeaders { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="UsersClient"/> class.
    /// </summary>
    public IssueCategoriesClient(IManagementConnection managementConnection, IDictionary<string, string> defaultHeaders)
    {
        Connection = managementConnection ?? throw new ArgumentNullException(nameof(managementConnection));
        DefaultHeaders = defaultHeaders ?? throw new ArgumentNullException(nameof(defaultHeaders));
    }

    /// <inheritdoc/>
    public Task<IssueCategory?> GetByCodeAsync(string code)
    {
        return Connection.GetAsync<IssueCategory?>(UrlHelper.BuildUriRelative(BaseUri, $"by-code/{code}"), DefaultHeaders);
    }
}