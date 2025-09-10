
using JFW.Sdk.Abstracts;

namespace JFW.Sdk.Clients.Interfaces;

/// <summary>
/// The events client interface.
/// </summary>
public interface IEventsClient
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Event?> GetByIdAsync(string id);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<PaginationList<Event>?> GetAllAsync(GetEventsRequest request);

}