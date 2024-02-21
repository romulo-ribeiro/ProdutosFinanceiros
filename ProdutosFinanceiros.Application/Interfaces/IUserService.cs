using ProdutosFinanceiros.Domain;
using ProdutosFinanceiros.Domain.Interfaces;
using ProdutosFinanceiros.Domain.Result;

namespace ProdutosFinanceiros.Application.Interfaces;

public interface IUserService : IBaseService<User, IUserRepository>
{
}
