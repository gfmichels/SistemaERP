using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class PedidoRepositorio : IRepositorio<Pedido>
{
    private List<Pedido> pedidos = new List<Pedido>();

    public void Adicionar(Pedido pedido)
    {
        pedidos.Add(pedido);
    }

    public void Remover(Pedido pedido)
    {
        pedidos.Remove(pedido);
    }

    public List<Pedido> Listar()
    {
        return pedidos;
    }

    public Pedido BuscarPorNome(string nome)
    {
        return null; // Implementar busca por nome se necessário
    }

    public Pedido BuscarPorCodigo(string codigo)
    {
        // Implementar busca por código se necessário
        return null;
    }

    public void SalvarDados()
    {
        var json = JsonSerializer.Serialize(pedidos);
        File.WriteAllText("pedidos.json", json);
    }

    public void CarregarDados()
    {
        if (File.Exists("pedidos.json"))
        {
            var json = File.ReadAllText("pedidos.json");
            pedidos = JsonSerializer.Deserialize<List<Pedido>>(json);
        }
    }
}
