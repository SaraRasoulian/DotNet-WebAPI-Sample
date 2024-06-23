using Application.Users.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Users.Handlers.CommandHandlers;

public class EarnPointsHandler : IRequestHandler<EarnPointsCommand, decimal>
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<EarnPointsHandler> _logger;
    public EarnPointsHandler(IUserRepository userRepository, ILogger<EarnPointsHandler> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }

    public async Task<decimal> Handle(EarnPointsCommand request, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.Get(request.UserId);
        if (user is null) throw new Exception("User not found");
        
        user.PointBalance += request.Points;
        User updatedUser = _userRepository.Update(user);
        await _userRepository.SaveChanges();

        _logger.LogInformation("Added {points} points to user with id {userId} at {now}", request.Points, request.UserId, DateTime.Now);

        return updatedUser.PointBalance;
    }
}
