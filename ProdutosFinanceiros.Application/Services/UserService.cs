using FluentValidation;
using ProdutosFinanceiros.Application.Interfaces;
using ProdutosFinanceiros.Domain;
using ProdutosFinanceiros.Domain.Interfaces;
using ProdutosFinanceiros.Domain.Result;

namespace ProdutosFinanceiros.Application.Services
{
    public class UserService : BaseService<User, IUserRepository, IValidator<User>>, IUserService
    {
        public UserService(
            IUserRepository repository,
            IValidator<User> validator) : base(repository, validator)
        {
        }
    }
}
