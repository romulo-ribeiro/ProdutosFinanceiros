using FluentValidation;
using ProdutosFinanceiros.Domain;
using ProdutosFinanceiros.Domain.Interfaces;
using ProdutosFinanceiros.Domain.Result;

namespace ProdutosFinanceiros.Application.Services
{
    public abstract class BaseService<TEntity, TRepository, TValidator>
        where TEntity : Entity
        where TRepository : IGenericRepository<TEntity>
        where TValidator : IValidator<TEntity>
    {
        protected readonly TRepository _repository;
        protected readonly TValidator _validator;

        public BaseService(TRepository repository, TValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<Result<TEntity>> UpdateAsync(TEntity entity)
        {
            var result = new Result<TEntity>(entity, await _validator.ValidateAsync(entity));
            if (result.IsValid)
            {
                await _repository.UpdateAsync(entity);
            }
            return result;
        }

        public async Task<Result<TEntity>> CreateAsync(TEntity entity)
        {
            var result = new Result<TEntity>(entity, await _validator.ValidateAsync(entity));
            if (result.IsValid)
            {
                await _repository.CreateAsync(result.Entity);
            }
            return result;
        }

        public async Task<Result<TEntity>> DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            var result = new Result<TEntity>();
            if (entity == null)
            {
                result.Errors.Add("Data not found.");
            }
            else
            {
                result.IsValid = await _repository.DeleteAsync(id);
            }
            return result;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}
