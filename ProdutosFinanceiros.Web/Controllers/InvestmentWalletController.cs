using ProdutosFinanceiros.Application.Interfaces;
using ProdutosFinanceiros.Domain;
using ProdutosFinanceiros.Domain.Interfaces;

namespace ProdutosFinanceiros.Web.Controllers;

public class InvestmentWalletController : BaseCRUDController<InvestmentWallet, IInvestmentWalletRepository, IInvestmentWalletService>
{
    public InvestmentWalletController(IInvestmentWalletService InvestmentWalletService) : base(InvestmentWalletService)
    {
    }
}