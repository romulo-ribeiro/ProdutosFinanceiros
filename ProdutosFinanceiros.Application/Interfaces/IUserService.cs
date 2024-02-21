using ProdutosFinanceiros.Domain;
using ProdutosFinanceiros.Domain.Interfaces;
using ProdutosFinanceiros.Domain.Result;

namespace ProdutosFinanceiros.Application.Interfaces;

public interface IUserService : IBaseService<User, IUserRepository>
{
    public Task<bool> ValidateCredentials(string username, string password);
    public Task<Result<User>> GetByUsernameAsync(string username);
}
