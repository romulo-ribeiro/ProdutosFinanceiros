using FluentValidation;
using ProdutosFinanceiros.Application.Interfaces;
using ProdutosFinanceiros.Domain;
using ProdutosFinanceiros.Domain.Interfaces;

namespace ProdutosFinanceiros.Application.Services;

public class FinancialProductService : BaseService<FinancialProduct, IFinancialProductRepository, IValidator<FinancialProduct>>, IFinancialProductService
{
    public FinancialProductService(IFinancialProductRepository repository, IValidator<FinancialProduct> validator) : base(repository, validator)
    {
    }
}
