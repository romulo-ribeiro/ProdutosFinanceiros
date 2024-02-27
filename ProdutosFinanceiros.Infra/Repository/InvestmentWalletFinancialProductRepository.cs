using Microsoft.EntityFrameworkCore;
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
        DateTime currentDate = DateTime.Now;
        int currentMonth = currentDate.Month;

        var query = from iwfp in dbContext.Set<InvestmentWalletFinancialProduct>()
                    where iwfp.FinancialProduct.PaymentDate.Month == currentMonth
                    where iwfp.InvestmentWallet.ManagerId == managerId
                    orderby iwfp.FinancialProduct.PaymentDate
                    select
$@"WalletNumber: {iwfp.InvestmentWallet.WalletNumber} -
ProductName: {iwfp.FinancialProduct.Name} -
PaymentDate: {iwfp.FinancialProduct.PaymentDate:dd/MM} -
Amount: {iwfp.Quantity * iwfp.FinancialProduct.Value:0.000}";

        return query.ToListAsync();
    }
}
