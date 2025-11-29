using AppEcommerce.Domain.Entities;
using AppEcommerce.Domain.Interfaces;

namespace AppEcommerce.Application.Services;

public class ItemCarrinhoService
{
    private readonly IitemCarrinhoRepository _repo;

    public ItemCarrinhoService(IitemCarrinhoRepository repo)
    {
        _repo = repo;
    }

    // 🔹 Buscar todos os produtos
    public async Task<IEnumerable<ItemCarrinhoEntity>> GetAllAsync()
    {
        return await _repo.GetAllAsync();
    }

    public async Task<ItemCarrinhoEntity?> GetByIdAsync(int id)
    {
        return await _repo.GetByIdAsync(id);
    }

    public async Task AddAsync(ItemCarrinhoEntity itemcarrinho)
    {
        await _repo.AddAsync(itemcarrinho);
    }

    public async Task UpdateAsync(ItemCarrinhoEntity itemcarrinho)
    {
        await _repo.UpdateAsync(itemcarrinho);
    }

    public async Task DeleteAsync(int id)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing is not null)
        {
            await _repo.DeleteAsync(existing);
        }
    }
}