namespace ProdutosFinanceiros.Domain.Interfaces;

public interface IInvestmentWalletRepository : IGenericRepository<InvestmentWallet>
{
    public Task<string> GetUserWalletExtract(Guid userId);
}
