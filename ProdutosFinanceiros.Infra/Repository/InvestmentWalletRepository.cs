using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProdutosFinanceiros.Domain;
using ProdutosFinanceiros.Domain.Interfaces;
using ProdutosFinanceiros.Infra.Context;
using ProdutosFinanceiros.Infra.Repository.GenericRepository;

namespace ProdutosFinanceiros.Infra.Repository;

public class InvestmentWalletRepository : GenericRepository<InvestmentWallet>, IInvestmentWalletRepository
{
    private IFinancialProductRepository _fpRepository;
    private IInvestmentWalletFinancialProductRepository _iwfpRepository;

    public InvestmentWalletRepository(
        MainContext dbContext,
        IFinancialProductRepository fpRepository,
        IInvestmentWalletFinancialProductRepository iwfpRepository) : base(dbContext)
    {
        _fpRepository = fpRepository;
        _iwfpRepository = iwfpRepository;
    }

    public async Task<string> GetUserWalletExtract(Guid userId)
    {
        var result = await DbSet
            .Where(x => x.User.Id == userId)
            .Select(x => new
            {
                x.WalletNumber,
                x.User.Name,
                x.WalletFinancialProduct.CreatedAt,
                Amount = x.WalletFinancialProduct.Quantity * x.WalletFinancialProduct.FinancialProduct.Value,
                FinancialProductName = x.WalletFinancialProduct.FinancialProduct.Name,
            })
            .OrderByDescending(x => x.CreatedAt).ToListAsync();

        return JsonConvert.SerializeObject(result);
    }
}
