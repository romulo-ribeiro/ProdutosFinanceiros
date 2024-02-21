using ProdutosFinanceiros.Domain;
using ProdutosFinanceiros.Domain.Interfaces;
using ProdutosFinanceiros.Infra.Context;
using ProdutosFinanceiros.Infra.Repository.GenericRepository;

namespace ProdutosFinanceiros.Infra.Repository;

public class FinancialProductRepository : GenericRepository<FinancialProduct>, IFinancialProductRepository
{
    public FinancialProductRepository(MainContext dbContext) : base(dbContext)
    {
    }
}

