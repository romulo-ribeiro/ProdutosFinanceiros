using ProdutosFinanceiros.Application.Interfaces;
using ProdutosFinanceiros.Domain;
using ProdutosFinanceiros.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ProdutosFinanceiros.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseCRUDController<TEntity, TRepository, TService> : ControllerBase
        where TEntity : Entity
        where TRepository : IGenericRepository<TEntity>
        where TService : IBaseService<TEntity, TRepository>
    {
        protected readonly TService _service;

        public BaseCRUDController(TService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post(TEntity entity)
        {
            var result = await _service.CreateAsync(entity);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return Ok("Registro cadastrado com sucesso!");
        }

        [HttpPut]
        public async Task<IActionResult> Put(TEntity entity)
        {
            var result = await _service.UpdateAsync(entity);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return Ok("Registro atualizado com sucesso!");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetAllAsync();
            return Ok(result.ToList());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return Ok("Registro excluído com sucesso!");
        }
    }
}
