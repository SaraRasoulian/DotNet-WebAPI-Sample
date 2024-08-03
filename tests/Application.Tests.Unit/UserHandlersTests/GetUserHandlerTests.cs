using Application.Users.Handlers.QueryHandlers;
using Application.Users.Queries;
using Domain.Entities;
using Domain.Interfaces;
using Moq;
using FluentAssertions;

namespace Application.Tests.Unit.UserHandlersTests;

public class GetUserHandlerTests
{
    private readonly Mock<IUserRepository> _userRepository;

    public GetUserHandlerTests()
    {
        _userRepository = new Mock<IUserRepository>();
    }

    [Fact]
    public async Task GetUserHandler_Returns_User()
    {
        // Arrange
        long userId = 1;
        User user = new User
        {
            Id = userId,
            FirstName = "test",
            LastName = "test"
        };
        _userRepository.Setup(r => r.GetFromCacheAsync(userId)).ReturnsAsync(user);
        GetUserQuery query = new GetUserQuery(userId);
        var handler = new GetUserHandler(_userRepository.Object);

        // Act
        var response = await handler.Handle(query, default);

        // Assert
        response.Should().NotBeNull();
        response.Id.Should().Be(userId);
    }
}