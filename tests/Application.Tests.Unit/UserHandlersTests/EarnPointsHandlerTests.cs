using Application.Users.Commands;
using Application.Users.Handlers.CommandHandlers;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;

namespace Application.Tests.Unit.UserHandlersTests;

public class EarnPointsHandlerTests
{
    private readonly Mock<IUserRepository> _userRepository;
    
    public EarnPointsHandlerTests()
    {
        _userRepository = new Mock<IUserRepository>();
    }
    
    [Fact]
    public async Task EarnPointsHandler_Returns_PointBalance()
    {
        // Arrange
        var userId = 1;
        var command = new EarnPointsCommand(userId, Points: 100);
        User user = new User
        {
            Id = userId,
            PointBalance = 0
        };
        User updatedUser = new User
        {
            Id = userId,
            PointBalance = 100
        };
        _userRepository.Setup(r => r.GetAsync(userId)).ReturnsAsync(user);
        _userRepository.Setup(r => r.Update(user)).Returns(updatedUser);
        var logger = new Mock<ILogger<EarnPointsHandler>>();
        var handler = new EarnPointsHandler(_userRepository.Object, logger.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        Assert.Equal(updatedUser.PointBalance, result);
        _userRepository.Verify(x => x.GetAsync(userId), Times.Once);
        _userRepository.Verify(x => x.Update(user), Times.Once);
    }

    [Fact]
    public void EarnPointsHandler_With_Null_User_Throws_Exception()
    {
        // Arrange
        var userId = 1;
        var command = new EarnPointsCommand(userId, Points: 100);
        User user = null;
        _userRepository.Setup(r => r.GetAsync(userId)).ReturnsAsync(user);
        var logger = new Mock<ILogger<EarnPointsHandler>>();
        var handler = new EarnPointsHandler(_userRepository.Object, logger.Object);

        // Act & Assert
        Assert.ThrowsAsync<Exception>(async () =>
        {
            await handler.Handle(command, default);
        });
    }
}
