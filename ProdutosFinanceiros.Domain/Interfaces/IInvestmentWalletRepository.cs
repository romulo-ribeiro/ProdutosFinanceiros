using ProdutosFinanceiros.Domain.Result;

namespace ProdutosFinanceiros.Domain.Interfaces;

public interface IInvestmentWalletRepository : IGenericRepository<InvestmentWallet>
{
    public Task<string> GetUserWalletExtract(Guid userId, int pageSize, int pageNumber);
    public Task<Result<InvestmentWallet>> Buy(Guid userId, Guid finProdId, int quantity);
    public Task<Result<InvestmentWallet>> Sell(Guid userId, Guid finProdId, int quantity);
}
