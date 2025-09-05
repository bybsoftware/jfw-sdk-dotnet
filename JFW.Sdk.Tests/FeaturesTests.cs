
namespace JFW.Sdk.Tests.Features;

public class FeaturesTest
{
    private const string BrandUrl = "your.domain.com"; // Replace with your actual brand URL for testing

    private readonly IJfwApiClient _apiClients;

    public FeaturesTest()
    {
        var baseUrl = "https://[subdomain].jframework.io";

        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(baseUrl);

        var connection = new ManagementConnection(httpClient);

        _apiClients = new JfwApiClient(BrandUrl, connection);
    }

    [Fact]
    public async Task CheckUserAccessAsync_Should_Call_GetAsync_With_Result_False()
    {

        string userId = "USER_ID";

        string featureCode = "USERS";

        string authKey = "YOUR_AUTH_KEY";

        _apiClients.UpdateAuthKey(authKey);

        // Act
        var result = await _apiClients.Features.CheckUserAccessAsync(userId, featureCode);

        // Assert
        Assert.IsType<bool>(result);
        Assert.False(result);
    }
}