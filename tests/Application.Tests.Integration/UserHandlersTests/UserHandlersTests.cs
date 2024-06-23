using Application.Users.Commands;
using FluentAssertions;

namespace Application.Tests.Integration.UserHandlersTests;

public class UserHandlersTests : BaseHandlerTest
{
    public UserHandlersTests(IntegrationTestWebApplicationFactory factory) : base(factory) { }

    [Fact]
    public async void EarnPointsCommand_Returns_PointsBalance()
    {
        // Arrange
        var command = new EarnPointsCommand(
            UserId: 1,
            Points: 200);

        // Act
        var result = await _sender.Send(command);

        // Assert
        result.Should().BeGreaterThan(0);        
    }
}
