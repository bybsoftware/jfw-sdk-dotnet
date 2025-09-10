
using JFW.Sdk.Abstracts;
using JFW.Sdk.Clients.Interfaces;
using JFW.Sdk.Helpers;

namespace JFW.Sdk.Clients.Implements;

/// <summary>
/// This class provides all methods to call the api/v1/events endpoints.
/// </summary>
public class EventsClient : BaseClient, IEventsClient
{
    /// <inheritdoc/>
    protected override string BaseUriClient => "api/v1/events";


    /// <summary>
    /// Initializes a new instance of the <see cref="EventsClient"/> class.
    /// </summary>
    public EventsClient(IManagementConnection managementConnection, IDictionary<string, string> defaultHeaders)
        : base(managementConnection, defaultHeaders)
    {
    }

    /// <inheritdoc/>
    public Task<PaginationList<Event>?> GetAllAsync(GetEventsRequest request)
    {
        IDictionary<string, string> queryParams = request.ToDictionary();

        string? queryString = UrlHelper.AddQueryString(queryParams);

        return Connection.GetAsync<PaginationList<Event>>(UrlHelper.BuildUriQuery(BaseUri, queryString), DefaultHeaders);
    }
    
    /// <inheritdoc/>
    public Task<Event?> GetByIdAsync(string id)
    {
        // GET api/v1/events/{id}
        return Connection.GetAsync<Event>(UrlHelper.BuildUriRelative(BaseUri, id), DefaultHeaders);
    }
}