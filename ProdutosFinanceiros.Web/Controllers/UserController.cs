using ProdutosFinanceiros.Application.Interfaces;
using ProdutosFinanceiros.Domain;
using ProdutosFinanceiros.Domain.Interfaces;

namespace ProdutosFinanceiros.Web.Controllers;

public class UserController : BaseCRUDController<User, IUserRepository, IUserService>
{
    public UserController(IUserService userService) : base(userService)
    {
    }
}