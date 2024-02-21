using ProdutosFinanceiros.Domain;
using ProdutosFinanceiros.Domain.Interfaces;
using ProdutosFinanceiros.Infra.Context;
using ProdutosFinanceiros.Infra.Repository.GenericRepository;

namespace ProdutosFinanceiros.Infra.Repository;

public class InvestmentWalletFinancialProductRepository : GenericRepository<InvestmentWalletFinancialProduct>, IInvestmentWalletFinancialProductRepository
{
    public InvestmentWalletFinancialProductRepository(MainContext dbContext) : base(dbContext)
    {
    }

    public Task<List<string>> GetClosingFinancialProducts(Guid managerId)
    {
        throw new NotImplementedException();
    }
}
