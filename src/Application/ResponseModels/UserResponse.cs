using Domain.ValueObjects;

namespace Application.ResponseModels;

public record UserResponse(
    long Id,
    string FirstName,
    string LastName,
    string UserName,
    Email Email,
    decimal PointBalance);