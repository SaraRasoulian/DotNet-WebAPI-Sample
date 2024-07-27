using Application.ResponseModels;
using Application.Users.Queries;
using Domain.Interfaces;
using MediatR;
using Mapster;

namespace Application.Users.Handlers.QueryHandlers;

public class GetUserHandler : IRequestHandler<GetUserQuery, UserResponse>
{
    private readonly IUserRepository _userRepository;

    public GetUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetFromCacheAsync(request.UserId);
        return user.Adapt<UserResponse>();
    }
}