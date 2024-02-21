using FluentValidation;
using ProdutosFinanceiros.Domain;

namespace ProdutosFinanceiros.Application.Validators;

public class InvestmentWalletValidator : AbstractValidator<InvestmentWallet>, IValidator<InvestmentWallet>
{
    public InvestmentWalletValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .MaximumLength(100)
            .WithMessage("Name must be less than 100 characters");

        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId is required");

        RuleFor(x => x.ManagerId)
            .NotEmpty()
            .WithMessage("ManagerId is required");
    }
}
