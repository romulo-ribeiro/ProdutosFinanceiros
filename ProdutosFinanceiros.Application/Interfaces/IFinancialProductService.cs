using ProdutosFinanceiros.Domain;
using ProdutosFinanceiros.Domain.Interfaces;

namespace ProdutosFinanceiros.Application.Interfaces;

public interface IFinancialProductService : IBaseService<FinancialProduct, IFinancialProductRepository>
{

}
