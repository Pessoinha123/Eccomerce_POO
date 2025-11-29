using AppEcommerce.Application.Services;
using AppEcommerce.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AppEcommerce.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemCarrinhoController : ControllerBase
{
    private readonly ItemCarrinhoService _service;

    public ItemCarrinhoController(ItemCarrinhoService service)
    {
        _service = service;
    }

    // 🔹 GET: api/itemcarrinhos
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var itemcarrinhos = await _service.GetAllAsync();
        return Ok(itemcarrinhos);
    }

    // 🔹 GET: api/itemcarrinho/5
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var itemcarrinho = await _service.GetByIdAsync(id);
        if (itemcarrinho is null)
            return NotFound("Item do carrinho não encontrado.");

        return Ok(itemcarrinho);
    }

    // 🔹 POST: api/itemcarrinho
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ItemCarrinhoEntity itemcarrinho)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _service.AddAsync(itemcarrinho);
        return CreatedAtAction(nameof(GetById), new { id = itemcarrinho.ID }, itemcarrinho);
    }

    // 🔹 PUT: api/itemcarrinho/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] ItemCarrinhoEntity itemcarrinho)
    {
        if (id != itemcarrinho.ID)
            return BadRequest("ID do item do carrinho inválido.");

        await _service.UpdateAsync(itemcarrinho);
        return NoContent();
    }

    // 🔹 DELETE: api/itemcarrinho/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}