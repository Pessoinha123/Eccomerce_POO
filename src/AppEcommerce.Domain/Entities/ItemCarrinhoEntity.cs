namespace AppEcommerce.Domain.Entities;

public class ItemCarrinhoEntity
{
    public int ID { get; set; }
    public int Quantidade { get; set; }
    public decimal Subtotal { get; set; }

    protected ItemCarrinhoEntity () { }

     public ItemCarrinhoEntity (int idProduto, int quantidade, decimal precoUnitario) 
    { 
        Update(idProduto, quantidade, precoUnitario); 
    }
    public void Update(int idProduto, int quantidade, decimal precoUnitario)
    {
        if (idProduto <= 0)
                throw new ArgumentException("Id do produto inválido.");

        ID = idProduto;
        Quantidade = quantidade;
        Subtotal = quantidade * precoUnitario;
    }

}