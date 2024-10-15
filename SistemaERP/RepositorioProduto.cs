using System.Text.Json;
using System.IO;

public class ProdutoRepositorio : IRepositorio<Produto>
{
    private const string ArquivoProdutos = "produtos.json";
    private List<Produto> produtos;

    public ProdutoRepositorio()
    {
        if (File.Exists(ArquivoProdutos))
        {
            string json = File.ReadAllText(ArquivoProdutos);
            produtos = JsonSerializer.Deserialize<List<Produto>>(json);
        }
        else
        {
            produtos = new List<Produto>();
        }
    }

    public void Adicionar(Produto produto)
    {
        produtos.Add(produto);
        Salvar();
    }

    public void Remover(Produto produto)
    {
        produtos.Remove(produto);
        Salvar();
    }

    public void Atualizar(Produto produto)
    {
        // Simulação de atualização
        Salvar();
    }

    public List<Produto> Listar()
    {
        return produtos;
    }

    private void Salvar()
    {
        string json = JsonSerializer.Serialize(produtos, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(ArquivoProdutos, json);
    }
}