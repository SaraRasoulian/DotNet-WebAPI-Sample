using FluentValidation;
using Application.Constants;

namespace Application.Users.Queries;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(v => v.UserName)
            .NotEmpty()
            .NotNull()
            .MaximumLength(UserConsts.UsernameMaxLength)
            .MinimumLength(UserConsts.UsernameMinLength);

        RuleFor(v => v.Password)
            .NotEmpty()
            .NotNull()
            .MaximumLength(UserConsts.PasswordMaxLength)
            .MinimumLength(UserConsts.PasswordMinLength);
    }
}
