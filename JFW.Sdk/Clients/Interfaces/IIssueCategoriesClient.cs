
using JFW.Sdk.Abstracts;
using JFW.Sdk.Models;

namespace JFW.Sdk.Clients.Interfaces;

/// <summary>
/// The issue categories client interface.
/// </summary>
public interface IIssueCategoriesClient
{
    /// <summary>
    /// Gets a issue category by the given code.
    /// </summary>
    /// <remarks>
    /// This method retrieves a issue category by given code.
    /// It requires the category Code as a string parameter.
    /// API Endpoint: GET api/v1/issue-categories/by-code/{code}
    /// </remarks>
    /// <param name="code">The code of the issue category to get.</param>
    /// <returns></returns>
    Task<IssueCategory?> GetByCodeAsync(string code);

}