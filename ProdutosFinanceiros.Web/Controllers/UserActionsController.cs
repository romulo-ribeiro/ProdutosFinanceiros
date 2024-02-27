using ProdutosFinanceiros.Application.Interfaces;
using ProdutosFinanceiros.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ProdutosFinanceiros.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserActionsController : ControllerBase
    {
        protected readonly IUserService _userService;
        protected readonly IInvestmentWalletService _investmentWalletService;

        public UserActionsController(IUserService userService, IInvestmentWalletService investmentWalletService)
        {
            _userService = userService;
            _investmentWalletService = investmentWalletService;
        }

        [HttpGet("UserWalletExtract/{username}")]
        public async Task<IActionResult> GetUserWalletExtract(string username)
        {
            var user = (await _userService.GetByUsernameAsync(username)).Entity;
            if (user == null)
            {
                return NotFound("Usuário não encontrado");
            }
            var extract = await _investmentWalletService.GetUserWalletExtract(user.Id);
            if (extract == null)
            {
                return NotFound("Carteira de investimentos não encontrada");
            }
            return Ok(extract);
        }


        [HttpPost("Buy")]
        public async Task<IActionResult> Buy(string username,Guid finProdId, int quantity)
        {
            var user = (await _userService.GetByUsernameAsync(username)).Entity;
            if (user == null)
            {
                return NotFound("Usuário não encontrado");
            }
            var result = await _investmentWalletService.Buy(user.Id, finProdId, quantity);
            if (result == null)
            {
                return BadRequest("Erro ao comprar produto financeiro");
            }
            return Ok(result);            
        }

        [HttpPost("Sell")]
        public async Task<IActionResult> Sell(string username, Guid finProdId, int quantity)
        {
            var user = (await _userService.GetByUsernameAsync(username)).Entity;
            if (user == null)
            {
                return NotFound("Usuário não encontrado");
            }
            var result = await _investmentWalletService.Sell(user.Id, finProdId, quantity);
            if (result == null)
            {
                return BadRequest("Erro ao vender produto financeiro");
            }
            return Ok(result);
        }
    }
}
