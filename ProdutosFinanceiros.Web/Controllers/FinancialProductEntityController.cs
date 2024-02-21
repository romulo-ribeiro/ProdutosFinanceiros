using ProdutosFinanceiros.Application.Interfaces;
using ProdutosFinanceiros.Domain;
using ProdutosFinanceiros.Domain.Interfaces;

namespace ProdutosFinanceiros.Web.Controllers;

public class FinancialProductEntityController : BaseCRUDController<FinancialProduct, IFinancialProductRepository, IFinancialProductService>
{
    public FinancialProductEntityController(IFinancialProductService service) : base(service)
    {
    }
}