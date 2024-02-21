using Microsoft.EntityFrameworkCore;
using ProdutosFinanceiros.Domain;
using ProdutosFinanceiros.Domain.Interfaces;
using ProdutosFinanceiros.Infra.Context;
using ProdutosFinanceiros.Infra.Repository.GenericRepository;

namespace ProdutosFinanceiros.Infra.Repository;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(MainContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> CheckCredentials(string username, string password)
    {
        return await DbSet.Where(x => x.Email == username).AnyAsync(x => x.Password == password);
    }

    public async Task<User> GetByUsernameAsync(string username)
    {
        return await DbSet.Where(x => x.Email == username).FirstOrDefaultAsync();
    }

    public async Task<List<User>> GetManagers()
    {
        return await DbSet.Where(x => x.Type == Domain.Enums.UserType.Manager).ToListAsync();
    }
}
