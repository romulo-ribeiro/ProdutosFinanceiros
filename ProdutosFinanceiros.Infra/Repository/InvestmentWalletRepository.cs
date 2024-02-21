using ProdutosFinanceiros.Domain;
using ProdutosFinanceiros.Domain.Interfaces;
using ProdutosFinanceiros.Infra.Context;
using ProdutosFinanceiros.Infra.Repository.GenericRepository;

namespace ProdutosFinanceiros.Infra.Repository;

public class InvestmentWalletRepository : GenericRepository<InvestmentWallet>, IInvestmentWalletRepository
{
    public InvestmentWalletRepository(MainContext dbContext) : base(dbContext)
    {
    }
}
