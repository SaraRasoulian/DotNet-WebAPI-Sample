using Application.Users.Commands;
using Application.Users.Handlers.CommandHandlers;
using Domain.Entities;
using Domain.Interfaces;
using Moq;

namespace Application.Tests.Unit.UserHandlersTests;

public class EarnPointsHandlerTests
{
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

        var userRepository = new Mock<IUserRepository>();

        userRepository.Setup(r => r.GetById(userId))
               .ReturnsAsync(user);

        userRepository.Setup(r => r.Update(user))
               .Returns(updatedUser);

        var handler = new EarnPointsHandler(userRepository.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        Assert.Equal(updatedUser.PointBalance, result);
        userRepository.Verify(x => x.GetById(userId), Times.Once);
        userRepository.Verify(x => x.Update(user), Times.Once);
    }
}
