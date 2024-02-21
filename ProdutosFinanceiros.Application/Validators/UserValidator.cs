using FluentValidation;
using ProdutosFinanceiros.Domain;

namespace ProdutosFinanceiros.Application.Validators;

public class UserValidator : AbstractValidator<User>, IValidator<User>
{
    public UserValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(100).WithMessage("Name must be less than 100 characters");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .MaximumLength(100).WithMessage("Email must be less than 100 characters")
            .EmailAddress().WithMessage("Invalid email format");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .MaximumLength(10).WithMessage("Password must be less than 10 characters");
    }
}
