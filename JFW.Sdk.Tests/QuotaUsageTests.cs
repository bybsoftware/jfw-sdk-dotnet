
using JFW.Sdk.Abstracts;
using JFW.Sdk.Models;

namespace JFW.Sdk.Tests;

public class QuotaUsageTests
{
    private const string BrandUrl = "your.domain.com"; // Replace with your actual brand URL for testing
    private const string AuthKey = "YOUR_AUTH_KEY";

    private readonly IJfwApiClient _apiClients;

    public QuotaUsageTests()
    {
        var baseUrl = "https://[subdomain].jframework.io";

        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(baseUrl);

        var connection = new ManagementConnection(httpClient);

        _apiClients = new JfwApiClient(BrandUrl, connection);
    }


    [Fact]
    public async Task TryConsumeAsync_Should_Call_PostAsync_With_Result_Success()
    {

        // Arrange
        var request = new ConsumeQuotaRequest
        {
            UserId = "USER_ID",
            FeatureCode = "SCORING-AI-SPEAKING",
            Amount = 1,
            Resource = "RESOURCE_ID",
            Source = "TEST_SOURCE",
            Metadata = new Dictionary<string, string>
            { { "key1", "value1" } }
        };

        _apiClients.UpdateAuthKey(AuthKey);

        // Act
        var result = await _apiClients.QuotaUsages.TryConsumeAsync(request);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<QuotaUsage>(result);
    }

    [Fact]
    public async Task TryConsumeAsync_Should_Call_PostAsync_With_Result_Throw_Exception()
    {

        // Arrange
        var request = new ConsumeQuotaRequest
        {
            UserId = "2rJeEOd0OyAYowgl",
            FeatureCode = "SCORING-AI-SPEAKING",
            Amount = 1,
            Resource = "RESOURCE_ID",
            Source = "TEST_SOURCE",
            Metadata = new Dictionary<string, string>
            { { "key1", "value1" } }
        };

        _apiClients.UpdateAuthKey(AuthKey);

        // Act
        // throw BaseException if the id was not found
        // Act & Assert
        var exception = await Assert.ThrowsAsync<JfwException>(async () =>
        {
            await _apiClients.QuotaUsages.TryConsumeAsync(request);
        });

        // Assert
        Assert.NotNull(exception);
        // Verify exception details if needed
        Assert.Equal("QuotaExceeded", exception.Code);
    }
}