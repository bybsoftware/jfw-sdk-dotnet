
using JFW.Sdk.Clients.Interfaces;
using JFW.Sdk.Helpers;

namespace JFW.Sdk.Clients.Implements;

/// <summary>
/// This class provides all methods to call the api/v1/issue-categories endpoints.
/// </summary>
public class IssueCategoriesClient : BaseClient, IIssueCategoriesClient
{
    /// <inheritdoc/>
    protected override string BaseUriClient => "api/v1/issue-categories";

    /// <summary>
    /// Initializes a new instance of the <see cref="IssueCategoriesClient"/> class.
    /// </summary>
    public IssueCategoriesClient(IManagementConnection managementConnection, IDictionary<string, string> defaultHeaders)
        : base(managementConnection, defaultHeaders)
    {
    }

    /// <inheritdoc/>
    public Task<IssueCategory?> GetByCodeAsync(string code)
    {
        return Connection.GetAsync<IssueCategory?>(UrlHelper.BuildUriRelative(BaseUri, $"by-code/{code}"), DefaultHeaders);
    }
}