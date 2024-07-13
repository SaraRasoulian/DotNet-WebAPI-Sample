using FluentValidation;

namespace Application.Users.Queries;

public class GetUserQueryValidator : AbstractValidator<GetUserQuery>
{
    public GetUserQueryValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);
    }
}