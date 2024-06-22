using FluentValidation;

namespace Application.Users.Commands;

public sealed class EarnPointsCommandValidator : AbstractValidator<EarnPointsCommand>
{
    public EarnPointsCommandValidator()
    {
        RuleFor(v => v.UserId)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);

        RuleFor(v => v.Points)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);
    }
}
