using MediatR;

namespace Application.Users.Commands;

public record EarnPointsCommand(long UserId ,decimal Points) : IRequest<decimal>;
