using ProdutosFinanceiros.Application.Interfaces;
using ProdutosFinanceiros.Domain;
using ProdutosFinanceiros.Domain.Interfaces;

namespace ProdutosFinanceiros.Web.Controllers;

public class FinancialProductController : BaseCRUDController<FinancialProduct, IFinancialProductRepository, IFinancialProductService>
{
    public FinancialProductController(IFinancialProductService service) : base(service)
    {
    }
}