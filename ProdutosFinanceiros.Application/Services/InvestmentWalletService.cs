using FluentValidation;
using ProdutosFinanceiros.Application.Interfaces;
using ProdutosFinanceiros.Domain;
using ProdutosFinanceiros.Domain.Interfaces;

namespace ProdutosFinanceiros.Application.Services;

public class InvestmentWalletService : BaseService<InvestmentWallet, IInvestmentWalletRepository, IValidator<InvestmentWallet>>, IInvestmentWalletService
{
    public InvestmentWalletService(
        IInvestmentWalletRepository repository,
        IValidator<InvestmentWallet> validator) : base(repository, validator)
    {
    }

    public Task<string> GetUserWalletExtract(Guid userId)
    {
        return _repository.GetUserWalletExtract(userId);
    }
}
