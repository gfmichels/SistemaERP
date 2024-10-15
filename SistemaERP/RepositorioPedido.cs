using System.Text.Json;
using System.IO;

public class PedidoRepositorio : IRepositorio<Pedido>
{
    private const string ArquivoPedidos = "pedidos.json";
    private List<Pedido> pedidos;

    public PedidoRepositorio()
    {
        if (File.Exists(ArquivoPedidos))
        {
            string json = File.ReadAllText(ArquivoPedidos);
            pedidos = JsonSerializer.Deserialize<List<Pedido>>(json);
        }
        else
        {
            pedidos = new List<Pedido>();
        }
    }

    public void Adicionar(Pedido pedido)
    {
        pedidos.Add(pedido);
        Salvar();
    }

    public void Remover(Pedido pedido)
    {
        pedidos.Remove(pedido);
        Salvar();
    }

    public void Atualizar(Pedido pedido)
    {
        // Simulação de atualização
        Salvar();
    }

    public List<Pedido> Listar()
    {
        return pedidos;
    }

    private void Salvar()
    {
        string json = JsonSerializer.Serialize(pedidos, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(ArquivoPedidos, json);
    }
}