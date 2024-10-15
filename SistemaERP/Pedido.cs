public class Pedido
{
    public Cliente Cliente { get; set; }
    public DateTime DataPedido { get; set; } = DateTime.Now;
    public List<(Produto Produto, int Quantidade)> Produtos { get; set; } = new List<(Produto, int)>();

    public decimal CalcularTotal()
    {
        decimal total = 0;
        foreach (var item in Produtos)
        {
            total += item.Produto.Preco * item.Quantidade;
        }
        return total;
    }
}