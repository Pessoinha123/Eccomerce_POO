using AppEcommerce.Domain.Entities;
using AppEcommerce.Domain.Interfaces;

namespace AppEcommerce.Application.Services;

public class CarrinhoService
{
    private readonly ICarrinhoRepository _repo;

    public CarrinhoService(ICarrinhoRepository repo)
    {
        _repo = repo;
    }

    // 🔹 Buscar todos os produtos
    public async Task<IEnumerable<CarrinhoEntity>> GetAllAsync()
    {
        return await _repo.GetAllAsync();
    }

    public async Task<CarrinhoEntity?> GetByIdAsync(int id)
    {
        return await _repo.GetByIdAsync(id);
    }

    public async Task AddAsync(CarrinhoEntity carrinho)
    {
        await _repo.AddAsync(carrinho);
    }

    public async Task UpdateAsync(CarrinhoEntity carrinho)
    {
        await _repo.UpdateAsync(carrinho);
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
