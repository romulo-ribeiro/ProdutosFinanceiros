using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProdutosFinanceiros.Domain;
using ProdutosFinanceiros.Domain.Interfaces;
using ProdutosFinanceiros.Infra.Context;
using ProdutosFinanceiros.Infra.Repository.GenericRepository;

namespace ProdutosFinanceiros.Infra.Repository;

public class InvestmentWalletRepository : GenericRepository<InvestmentWallet>, IInvestmentWalletRepository
{
    public InvestmentWalletRepository(
        MainContext dbContext) : base(dbContext)
    {
    }

    public async Task<string> GetUserWalletExtract(Guid userId)
    {
        var iwfpRepository = dbContext.Set<InvestmentWalletFinancialProduct>().AsNoTracking();
        var fpRepository = dbContext.Set<FinancialProduct>().AsNoTracking();
        var uRepository = dbContext.Set<User>().AsNoTracking();

        var result = from iw in DbSet
             join iwfp in iwfpRepository on iw.Id equals iwfp.InvestmentWalletId
             join fp in fpRepository on iwfp.FinancialProductId equals fp.Id
             join u in uRepository on iw.UserId equals u.Id
             where u.Id == userId
             orderby iwfp.CreatedAt descending
             select new
             {
                 u.Name,
                 iw.WalletNumber,
                 ProductName = fp.Name,
                 Amount = fp.Value * iwfp.Quantity,
                 iwfp.CreatedAt
             };
             
        return JsonConvert.SerializeObject(result.ToList());
    }
}
