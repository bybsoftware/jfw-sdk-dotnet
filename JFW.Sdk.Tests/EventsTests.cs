
using JFW.Sdk.Abstracts;
using JFW.Sdk.Models;

namespace JFW.Sdk.Tests.Features;

public class EventsTest
{
    private const string BrandUrl = "your.domain.com"; // Replace with your actual brand URL for testing

    private readonly IJfwApiClient _apiClients;

    public EventsTest()
    {
        var baseUrl = "https://[subdomain].jframework.io";

        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(baseUrl);

        var connection = new ManagementConnection(httpClient);

        _apiClients = new JfwApiClient(BrandUrl, connection);
    }

    [Fact]
    public async Task GetByIdAsync_Should_Result_DataCorrect()
    {

        string eventId = "EVENT_ID";

        string authKey = "YOUR_AUTH_KEY";

        _apiClients.UpdateAuthKey(authKey);

        // Act
        var result = await _apiClients.Events.GetByIdAsync(eventId);

        // Assert
        Assert.IsType<Event>(result);
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetByIdAsync_Should_Throw_NotFound()
    {

        string eventId = "EVENT_ID";

        string authKey = "YOUR_AUTH_KEY";

        _apiClients.UpdateAuthKey(authKey);

        // Act
        // throw BaseException if the id was not found
        // Act & Assert
        var exception = await Assert.ThrowsAsync<JfwException>(async () =>
        {
            await _apiClients.Events.GetByIdAsync(eventId);
        });

        // Assert
        // Verify exception details if needed
        Assert.Equal("EventNotFound", exception.Code);
    }

    [Fact]
    public async Task GetAllAsync_Should_Return_Array()
    {

        string eventCode = "Event_Code";

        string authKey = "YOUR_AUTH_KEY";

        _apiClients.UpdateAuthKey(authKey);

        // Act
        var result = await _apiClients.Events.GetAllAsync(
            new GetEventsRequest()
            {
                Code = eventCode
            }
        );

        // Assert
        Assert.IsType<PaginationList<Event>>(result);
        Assert.NotNull(result);
    }
}