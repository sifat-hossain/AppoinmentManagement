namespace Users.Application.Actions.Users.Commands.CreateUser;

public class CreateUserValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserValidator()
    {
        RuleFor(r => r.UserName)
            .NotEmpty()
            .MaximumLength(ValidationConstants.FieldSize.Name);

        RuleFor(c => c.Password)
            .NotEmpty()
            .MinimumLength(6)
            .MaximumLength(ValidationConstants.FieldSize.Password);
    }
}