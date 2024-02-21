using ProdutosFinanceiros.Domain;
using ProdutosFinanceiros.Domain.Interfaces;
using ProdutosFinanceiros.Domain.Result;


namespace ProdutosFinanceiros.Application.Interfaces
{
    public interface IBaseService<TEntity, TRepository>
        where TEntity : Entity
        where TRepository : IGenericRepository<TEntity>
    {
        Task<Result<TEntity>> CreateAsync(TEntity entity);
        Task<Result<TEntity>> UpdateAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Guid id);
        Task<Result<TEntity>> DeleteAsync(Guid id);
    }
}
