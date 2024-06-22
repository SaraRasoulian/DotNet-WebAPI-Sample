using Application.Users.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Users.Handlers.CommandHandlers;

public class EarnPointsHandler : IRequestHandler<EarnPointsCommand, decimal>
{
    private readonly IUserRepository _userRepository;
    public EarnPointsHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<decimal> Handle(EarnPointsCommand request, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.Get(request.UserId);
        if (user is null) throw new Exception("User not found");
        
        user.PointBalance += request.Points;
        User updatedUser = _userRepository.Update(user);
        await _userRepository.SaveChanges(); 

        return updatedUser.PointBalance;
    }
}
