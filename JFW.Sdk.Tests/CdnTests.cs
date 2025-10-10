
using JFW.Sdk.Models;

namespace JFW.Sdk.Tests;

public class CdnTest
{
    private const string AuthKey = "AUTH_KEY";
    private const string BrandUrl = "BRAND_URL";

    private readonly IJfwApiClient _apiClients;

    public CdnTest()
    {
        var baseUrl = "https://[subdomain].jframework.io";

        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(baseUrl);

        var connection = new ManagementConnection(httpClient);

        _apiClients = JfwApiClient.CreateBuilder()
            .WithBrandUrl(BrandUrl)
            .WithManagementConnection(connection)
            .Build();
    }

    [Fact]
    public async Task UploadAsync_Should_Return_ValidCdnObject()
    {

        // Arrange
        var tempFile = Path.GetTempFileName();
        try
        {
            await File.WriteAllBytesAsync(tempFile, new byte[] { 0x89, 0x50, 0x4E, 0x47 }); // PNG header
            using var fileStream = File.OpenRead(tempFile);
            _apiClients.UpdateAuthKey(AuthKey);

            // Act
            var result = await _apiClients.Cdn.UploadAsync(new CdnUploadRequest()
            {
                UploadFile = fileStream,
                CdnPathType = Constants.CdnPathType.User,
                RefObject = "user",
                RefId = 1,
                Tags = "#test-mode",
                Notes = "Unit test"
            });

            // Assert
            Assert.IsType<Cdn>(result);
            Assert.NotNull(result);
        }
        finally
        {
            if (File.Exists(tempFile))
                File.Delete(tempFile);
        }
    }


}