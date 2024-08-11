using Domain.ValueObjects;

namespace Domain.Tests.Unit.ValueObjectsTests;

public class EmailTests
{
    [Fact]
    public void Valid_Email_Returns_Email()
    {
        // Arrange
        string validEmail = "example@gmail.com";

        // Act
        Email email = new Email(validEmail);

        // Assert
        Assert.Equal(validEmail, email.Value);
    }

    [Theory]
    [InlineData("invalidexample.com")]
    [InlineData(".invalid@example.com")]
    [InlineData("@invalid")]
    [InlineData("invalid@.com")]
    public void Invalid_Email_Throws_InvalidDataException(string invalidEmail)
    {
        // Act
        Action act = () => new Email(invalidEmail);

        // Assert
        Assert.Throws<InvalidDataException>(act);
    }
}
