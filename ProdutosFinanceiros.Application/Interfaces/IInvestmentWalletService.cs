using ProdutosFinanceiros.Domain;
using ProdutosFinanceiros.Domain.Interfaces;

namespace ProdutosFinanceiros.Application.Interfaces;

public interface IInvestmentWalletService : IBaseService<InvestmentWallet, IInvestmentWalletRepository>
{
    public Task<string> GetUserWalletExtract(Guid userId);
}
