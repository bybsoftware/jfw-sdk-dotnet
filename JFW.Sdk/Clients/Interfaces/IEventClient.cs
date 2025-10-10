
using JFW.Sdk.Abstracts;

namespace JFW.Sdk.Clients.Interfaces;

/// <summary>
/// The events client interface.
/// </summary>
public interface IEventsClient
{
    /// <summary>
    /// Get an event
    /// </summary>
    /// <remarks>
    /// This method retrieves an event.
    /// API Endpoint: GET api/v1/events/{id}
    /// </remarks>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Event?> GetByIdAsync(string id);

    /// <summary>
    /// Get events
    /// </summary>
    /// <remarks>
    /// API Endpoint: GET api/v1/events
    /// </remarks>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<PaginationList<Event>?> GetAllAsync(GetEventsRequest request);

}