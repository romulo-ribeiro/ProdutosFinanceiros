using ProdutosFinanceiros.Application.Interfaces;
using ProdutosFinanceiros.Domain;
using ProdutosFinanceiros.Domain.Interfaces;

namespace ProdutosFinanceiros.Web.Controllers;

public class InvestmentWalletEntityController : BaseCRUDController<InvestmentWallet, IInvestmentWalletRepository, IInvestmentWalletService>
{
    public InvestmentWalletEntityController(IInvestmentWalletService InvestmentWalletService) : base(InvestmentWalletService)
    {
    }
}