namespace Application.Tests.Integration.UserHandlersTests;

public class GetUserHandlerTests : BaseHandlerTest
{
    public GetUserHandlerTests(IntegrationTestWebApplicationFactory factory) : base(factory) { }

    [Fact]
    public async void GetUserHandler_Returns_User()
    {
        // Arrange
        var query = new GetUserQuery(UserId: 1);

        // Act
        var result = await _sender.Send(query);

        // Assert
        result.Id.Should().Be(query.UserId);
    }
}
