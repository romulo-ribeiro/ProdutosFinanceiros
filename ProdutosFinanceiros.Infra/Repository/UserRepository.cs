using Microsoft.EntityFrameworkCore;
using ProdutosFinanceiros.Domain;
using ProdutosFinanceiros.Domain.Interfaces;
using ProdutosFinanceiros.Infra.Context;
using ProdutosFinanceiros.Infra.Repository.GenericRepository;

namespace ProdutosFinanceiros.Infra.Repository;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    //new file
    public UserRepository(MainContext dbContext) : base(dbContext)
    {
    }
}
