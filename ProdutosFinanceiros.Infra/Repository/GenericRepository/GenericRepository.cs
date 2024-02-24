using ProdutosFinanceiros.Domain.Interfaces;
using ProdutosFinanceiros.Infra.Context;
using Microsoft.EntityFrameworkCore;
using ProdutosFinanceiros.Domain;

namespace ProdutosFinanceiros.Infra.Repository.GenericRepository
{
    public abstract class GenericRepository<TEntity>
        : IGenericRepository<TEntity> where TEntity : Entity
    {
        protected readonly MainContext dbContext;
        protected readonly DbSet<TEntity> DbSet;

        public GenericRepository(MainContext dbContext)
        {
            this.dbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            var entity = await DbSet.FindAsync(id);
            if (entity != null)
            {
                dbContext.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }

        public async Task CreateAsync(TEntity entity)
        {
            DbSet.Add(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            DbSet.Remove(await DbSet.FindAsync(id));
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        protected IQueryable Query() => DbSet.AsNoTracking();
    }
}