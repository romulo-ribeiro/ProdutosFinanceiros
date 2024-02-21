namespace ProdutosFinanceiros.Domain.Interfaces;

public interface IUserRepository : IGenericRepository<User>
{
    public Task<bool> CheckCredentials(string username, string password);

    public Task<User> GetByUsernameAsync(string username);
    public Task<List<User>> GetManagers();
}
