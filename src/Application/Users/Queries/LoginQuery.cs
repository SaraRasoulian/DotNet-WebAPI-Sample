using MediatR;

namespace Application.Users.Queries;

public record LoginQuery(string UserName, string Password) : IRequest<string>;
