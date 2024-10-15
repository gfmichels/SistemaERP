using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class ClienteRepositorio : IRepositorio<Cliente>
{
    private List<Cliente> clientes = new List<Cliente>();

    public void Adicionar(Cliente cliente)
    {
        clientes.Add(cliente);
    }

    public void Remover(Cliente cliente)
    {
        clientes.Remove(cliente);
    }

    public List<Cliente> Listar()
    {
        return clientes;
    }

    public Cliente BuscarPorNome(string nome)
    {
        return clientes.Find(c => c.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
    }

    public Cliente BuscarPorCodigo(string codigo)
    {
        return null; // Cliente não possui código único
    }

    public void SalvarDados()
    {
        var json = JsonSerializer.Serialize(clientes);
        File.WriteAllText("clientes.json", json);
    }

    public void CarregarDados()
    {
        if (File.Exists("clientes.json"))
        {
            var json = File.ReadAllText("clientes.json");
            clientes = JsonSerializer.Deserialize<List<Cliente>>(json);
        }
    }
}