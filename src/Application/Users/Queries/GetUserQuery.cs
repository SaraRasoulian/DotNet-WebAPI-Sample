using Application.ResponseModels;
using MediatR;

namespace Application.Users.Queries;

public record GetUserQuery(long UserId) : IRequest<UserResponse>;