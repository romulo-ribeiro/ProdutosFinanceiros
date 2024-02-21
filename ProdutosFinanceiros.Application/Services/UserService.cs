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

        public async Task<Result<User>> GetByUsernameAsync(string username)
        {
            var result = new Result<User>();
            var entity = await _repository.GetByUsernameAsync(username);
            if (entity is null)
            {
                result.Errors.Add("User not found");
            }
            else
            {
                result.IsValid = true;
                result.Entity = entity;
            }
            return result;
        }


        public async Task<bool> ValidateCredentials(string username, string password)
        {
            return await _repository.CheckCredentials(username, password);
        }
    }
}
