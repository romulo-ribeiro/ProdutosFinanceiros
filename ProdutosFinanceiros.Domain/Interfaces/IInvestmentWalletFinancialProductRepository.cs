namespace ProdutosFinanceiros.Domain.Interfaces;

public interface IInvestmentWalletFinancialProductRepository : IGenericRepository<InvestmentWalletFinancialProduct>
{
    public Task<List<string>> GetClosingFinancialProducts(Guid managerId);
}
