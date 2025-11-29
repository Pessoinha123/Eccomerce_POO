using AppEcommerce.Application.Services;
using AppEcommerce.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AppEcommerce.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarrinhoController : ControllerBase
{
    private readonly CarrinhoService _service;

    public CarrinhoController(CarrinhoService service)
    {
        _service = service;
    }

    // 🔹 GET: api/carrinhos
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var carrinhos = await _service.GetAllAsync();
        return Ok(carrinhos);
    }

    // 🔹 GET: api/carrinho/5
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var carrinho = await _service.GetByIdAsync(id);
        if (carrinho is null)
            return NotFound("Carrinho não encontrado.");

        return Ok(carrinho);
    }

    // 🔹 POST: api/carrinho
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CarrinhoEntity carrinho)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _service.AddAsync(carrinho);
        return CreatedAtAction(nameof(GetById), new { id = carrinho.IdCarrinho }, carrinho);
    }

    // 🔹 PUT: api/carrinho/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] CarrinhoEntity carrinho)
    {
        if (id != carrinho.IdCarrinho)
            return BadRequest("ID do carrinho inválido.");

        await _service.UpdateAsync(carrinho);
        return NoContent();
    }

    // 🔹 DELETE: api/carrinho/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
