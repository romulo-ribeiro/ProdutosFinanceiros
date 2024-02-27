using FluentValidation;
using ProdutosFinanceiros.Application.Interfaces;
using ProdutosFinanceiros.Domain;
using ProdutosFinanceiros.Domain.Interfaces;
using ProdutosFinanceiros.Domain.Result;

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

    public Task<Result<InvestmentWallet>> Buy(Guid userId, Guid finProdId, int quantity)
    {
        return _repository.Buy(userId, finProdId, quantity);
    }

    public Task<Result<InvestmentWallet>> Sell(Guid userId, Guid finProdId, int quantity)
    {
        return _repository.Sell(userId, finProdId, quantity);
    }

}
