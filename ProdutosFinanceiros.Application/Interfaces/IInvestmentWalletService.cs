using ProdutosFinanceiros.Domain;
using ProdutosFinanceiros.Domain.Interfaces;
using ProdutosFinanceiros.Domain.Result;

namespace ProdutosFinanceiros.Application.Interfaces;

public interface IInvestmentWalletService : IBaseService<InvestmentWallet, IInvestmentWalletRepository>
{
    public Task<string> GetUserWalletExtract(Guid userId, int pageSize, int pageNumber);
    public Task<Result<InvestmentWallet>> Buy(Guid userId, Guid finProdId, int quantity);
    public Task<Result<InvestmentWallet>> Sell(Guid userId, Guid finProdId, int quantity);
}
