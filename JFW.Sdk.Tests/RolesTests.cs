
using JFW.Sdk.Abstracts;
using JFW.Sdk.Models;

namespace JFW.Sdk.Tests.Roles;

public class RolesTests
{
    private const string BrandUrl = "your.domain.com"; // Replace with your actual brand URL for testing

    private readonly IJfwApiClient _apiClients;

    public RolesTests()
    {
        var baseUrl = "https://[subdomain].jframework.io";

        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(baseUrl);

        var connection = new ManagementConnection(httpClient);

        _apiClients = new JfwApiClient(BrandUrl, connection);
    }

    [Fact]
    public async Task GetByIdAsync_Should_Result_RoleData()
    {

        string roleId = "ROLE_ID";

        string authKey = "YOUR_AUTH_KEY";

        _apiClients.UpdateAuthKey(authKey);

        // Act
        var roleResult = await _apiClients.Roles.GetByIdAsync(roleId);

        // Assert
        Assert.IsType<Role>(roleResult);
        Assert.NotNull(roleResult);
    }


    [Fact]
    public async Task GetByIdAsync_Should_Result_NotFound()
    {

        string roleId = "ROLE_ID";

        string authKey = "YOUR_AUTH_KEY";

        _apiClients.UpdateAuthKey(authKey);

        // Act
        // throw BaseException if the id was not found
        // Act & Assert
        var exception = await Assert.ThrowsAsync<JfwException>(async () =>
        {
            await _apiClients.Roles.GetByIdAsync(roleId);
        });

        // Assert
        // Verify exception details if needed
        Assert.Equal("RoleNotFound", exception.Code);
    }
}