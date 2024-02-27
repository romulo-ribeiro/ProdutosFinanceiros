using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProdutosFinanceiros.Domain;
using ProdutosFinanceiros.Domain.Interfaces;
using ProdutosFinanceiros.Domain.Result;
using ProdutosFinanceiros.Infra.Context;
using ProdutosFinanceiros.Infra.Repository.GenericRepository;

namespace ProdutosFinanceiros.Infra.Repository;

public class InvestmentWalletRepository : GenericRepository<InvestmentWallet>, IInvestmentWalletRepository
{
    public InvestmentWalletRepository(
        MainContext dbContext) : base(dbContext)
    {
    }

    public async Task<string> GetUserWalletExtract(Guid userId, int pageSize, int pageNumber)
    {
        var iwfpRepository = dbContext.Set<InvestmentWalletFinancialProduct>().AsNoTracking();
        var fpRepository = dbContext.Set<FinancialProduct>().AsNoTracking();
        var uRepository = dbContext.Set<User>().AsNoTracking();

        var query = (from iw in DbSet
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
                      }).Skip(pageSize * (pageNumber - 1)).Take(pageSize);
                      
        var result = await query.ToListAsync();
        return JsonConvert.SerializeObject(result);
    }

    public async Task<Result<InvestmentWallet>> Buy(Guid userId, Guid finProdId, int quantity)
    {
        var result = new Result<InvestmentWallet>();

        var fpRepository = dbContext.Set<FinancialProduct>().AsNoTracking();
        var uRepository = dbContext.Set<User>().AsNoTracking();

        var wallet = DbSet.FirstOrDefaultAsync(iw => iw.UserId == userId).Result;
        var product = fpRepository.FirstOrDefaultAsync(fp => fp.Id == finProdId).Result;
        var user = uRepository.FirstOrDefaultAsync(u => u.Id == userId).Result;

        if (wallet == null || product == null || user == null)
        {
            result.Errors.Add("User, wallet or product not found.");
            return result;
        }

        decimal totalCost = product.Value * quantity;
        if (totalCost > 0 && totalCost <= wallet.Balance)
        {
            var relationshipEntry = new InvestmentWalletFinancialProduct(wallet.Id, product.Id, quantity);
            wallet.WalletFinancialProduct.Add(relationshipEntry);
            Console.WriteLine($"{user.Name} bought {quantity} units of {product.Name}.");
            await dbContext.SaveChangesAsync();
            result.Entity = wallet;
        }
        else
        {
            result.Errors.Add($"{user.Name} does not have enough funds to buy {quantity} units of {product.Name}.");
        }


        return result;
    }

    public async Task<Result<InvestmentWallet>> Sell(Guid userId, Guid finProdId, int quantity)
    {
        var result = new Result<InvestmentWallet>();

        var fpRepository = dbContext.Set<FinancialProduct>().AsNoTracking();
        var uRepository = dbContext.Set<User>().AsNoTracking();

        var wallet = DbSet.FirstOrDefaultAsync(iw => iw.UserId == userId).Result;
        var product = fpRepository.FirstOrDefaultAsync(fp => fp.Id == finProdId).Result;
        var user = uRepository.FirstOrDefaultAsync(u => u.Id == userId).Result;


        if (wallet == null || product == null || user == null)
        {
            result.Errors.Add("User, wallet or product not found.");
            return result;
        }

        int existingQuantity = wallet.WalletFinancialProduct
            .FirstOrDefault(x => x.FinancialProductId.Equals(finProdId))?.Quantity ?? 0;
        if (existingQuantity >= quantity)
        {
            foreach (var entry in wallet.WalletFinancialProduct)
            {
                if (entry.FinancialProduct.Id == product.Id)
                {
                    entry.Quantity -= quantity;
                    break;
                }
            }

            await dbContext.SaveChangesAsync();
            result.Entity = wallet;
        }

        return result;
    }
}
