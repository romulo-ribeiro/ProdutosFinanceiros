using ProdutosFinanceiros.Application.Interfaces;
using ProdutosFinanceiros.Domain;
using ProdutosFinanceiros.Domain.Interfaces;

namespace ProdutosFinanceiros.Web.Controllers;

public class UserEntityController : BaseCRUDController<User, IUserRepository, IUserService>
{
    public UserEntityController(IUserService userService) : base(userService)
    {
    }
}