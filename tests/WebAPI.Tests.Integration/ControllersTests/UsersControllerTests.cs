namespace WebAPI.Tests.Integration.ControllersTests;

public class UsersControllerTests : BaseControllerTest
{
    public UsersControllerTests(IntegrationTestWebApplicationFactory factory) : base(factory)
    {
    }

    [Fact]
    public async Task EarnPoints_Returns_OK_With_PointBalance()
    {
        // Arrange
        await AuthenticateAsync();
        var userId = 1;
        EarnPointsRequest request = new EarnPointsRequest(Points: 100);

        // Act
        var response = await _httpClient.PostAsJsonAsync("/api/users/" + userId + "/earn", request);

        // Assert
        response.EnsureSuccessStatusCode();
        decimal pointBalance = decimal.Parse(await response.Content.ReadAsStringAsync());
        pointBalance.Should().BeGreaterThan(0);
    }
}
