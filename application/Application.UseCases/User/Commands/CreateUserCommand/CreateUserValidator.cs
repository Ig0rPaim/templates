using FluentValidation;

namespace Application.UseCases.User.Commands.CreateUserCommand;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Email).NotEmpty().EmailAddress();
        // RuleFor(c => c.CadastralControl).NotNull();
        // RuleFor(c => c.Roles).NotEmpty();
    }
}