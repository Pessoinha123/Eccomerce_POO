using AppEcommerce.Domain.Entities;

namespace AppEcommerce.Domain.Interfaces;

public interface IClienteRepository
{
    // 🔹 Retorna todos os clientes
    Task<IEnumerable<ClienteEntity>> GetAllAsync();

    // 🔹 Retorna um cliente específico pelo Id
    Task<ClienteEntity?> GetByIdAsync(int id);

    // 🔹 Adiciona um novo cliente ao banco
    Task AddAsync(ClienteEntity cliente);

    // 🔹 Atualiza um cliente existente
    Task UpdateAsync(ClienteEntity cliente);

    // 🔹 Remove um cliente
    Task DeleteAsync(ClienteEntity cliente);


}