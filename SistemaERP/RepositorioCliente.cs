using System.Text.Json;
using System.IO;

public class ClienteRepositorio : IRepositorio<Cliente>
{
    private const string ArquivoClientes = "clientes.json";
    private List<Cliente> clientes;

    public ClienteRepositorio()
    {
        if (File.Exists(ArquivoClientes))
        {
            string json = File.ReadAllText(ArquivoClientes);
            clientes = JsonSerializer.Deserialize<List<Cliente>>(json);
        }
        else
        {
            clientes = new List<Cliente>();
        }
    }

    public void Adicionar(Cliente cliente)
    {
        clientes.Add(cliente);
        Salvar();
    }

    public void Remover(Cliente cliente)
    {
        clientes.Remove(cliente);
        Salvar();
    }

    public void Atualizar(Cliente cliente)
    {
        // Simulação de atualização
        Salvar();
    }

    public List<Cliente> Listar()
    {
        return clientes;
    }

    private void Salvar()
    {
        string json = JsonSerializer.Serialize(clientes, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(ArquivoClientes, json);
    }
}