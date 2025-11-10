namespace AppEcommerce.Domain.Entities;

public class Cliente
{
    public int Id { get; private set; }
    public string Nome { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Senha { get; private set; } = string.Empty;
    public string Endereco { get; private set; } = string.Empty;

    public Cliente(string nome, string email, string senha, string endereco)
    {
        Nome = nome;
        Email = email;
        Senha = senha;
        Endereco = endereco;
    }

}