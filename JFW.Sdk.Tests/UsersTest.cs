
using JFW.Sdk.Models;

namespace JFW.Sdk.Tests;

public class UsersTest
{
    private const string BrandUrl = "your.domain.com"; // Replace with your actual brand URL for testing

    private readonly IJfwApiClient _apiClients;

    public UsersTest()
    {
        var baseUrl = "https://subdomain.jframework.io";

        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(baseUrl);

        var connection = new ManagementConnection(httpClient);

        _apiClients = new JfwApiClient(BrandUrl, connection);
    }

    [Fact]
    public async Task CreateByEmailAsync_Should_Call_PostAsync_With_Correct_Parameters()
    {
        // Arrange
        var userAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/131.0.0.0 Safari/537.36";

        _apiClients.AddOrUpdateDefaultHeader("User-Agent", userAgent);

        var userCreateRequest = new UserCreateByEmailRequest(
            emailAddress: $"test{Guid.NewGuid():N}@gmail.com",
            firstName: "John",
            lastName: "Doe",
            password: "Password123!",
            confirmPassword: "Password123!"
        );

        // Act
        var userCreated = await _apiClients.Users.CreateByEmailAsync(userCreateRequest);

        // Assert
        Assert.NotNull(userCreated);
        Assert.IsType<User>(userCreated);
        Assert.Equal(userCreateRequest.EmailAddress, userCreated?.EmailAddress);
        Assert.Equal(userCreateRequest.FirstName, userCreated?.FirstName);
        Assert.Equal(userCreateRequest.LastName, userCreated?.LastName);
        Assert.False(string.IsNullOrWhiteSpace(userCreated?.Id));
    }

    [Fact]
    public async Task CreateByPhoneAsync_Should_Call_PostAsync_With_Correct_Parameters()
    {
        // Arrange
        var userAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/131.0.0.0 Safari/537.36";

        _apiClients.AddOrUpdateDefaultHeader("User-Agent", userAgent);

        var userCreateRequest = new UserCreateByPhoneRequest(
            phoneNumber: $"+1{new Random().Next(1000000000, 1999999999)}",
            firstName: "John",
            lastName: "Doe",
            password: "Password123!",
            confirmPassword: "Password123!"
        );

        // Act
        var userCreated = await _apiClients.Users.CreateByPhoneAsync(userCreateRequest);

        // Assert
        Assert.NotNull(userCreated);
        Assert.IsType<User>(userCreated);
        Assert.Equal(userCreateRequest.PhoneNumber, userCreated?.PhoneNumber);
        Assert.Equal(userCreateRequest.FirstName, userCreated?.FirstName);
        Assert.Equal(userCreateRequest.LastName, userCreated?.LastName);
        Assert.False(string.IsNullOrWhiteSpace(userCreated?.Id));
    }

    [Fact]
    public async Task GetByIdAsync_Should_Call_GetAsync_With_Correct_Parameters()
    {
        // Arrange
        var authKey = "AUTH_KEY_HERE"; // Replace with a valid auth key for testing

        var userId = "USER_ID_HERE"; // Replace with a valid user ID for testing

        _apiClients.UpdateAuthKey(authKey);

        // Act
        var user = await _apiClients.Users.GetByIdAsync(userId);

        // Assert
        Assert.NotNull(user);
        Assert.IsType<User>(user);
        Assert.Equal(userId, user?.Id);
    }
}