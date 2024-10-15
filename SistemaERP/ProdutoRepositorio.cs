using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class ProdutoRepositorio : IRepositorio<Produto>
{
    private List<Produto> produtos = new List<Produto>();

    public void Adicionar(Produto produto)
    {
        produtos.Add(produto);
    }

    public void Remover(Produto produto)
    {
        produtos.Remove(produto);
    }

    public List<Produto> Listar()
    {
        return produtos;
    }

    public Produto BuscarPorNome(string nome)
    {
        return produtos.Find(p => p.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
    }

    public Produto BuscarPorCodigo(string codigo)
    {
        return produtos.Find(p => p.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));
    }

    public void SalvarDados()
    {
        var json = JsonSerializer.Serialize(produtos);
        File.WriteAllText("produtos.json", json);
    }

    public void CarregarDados()
    {
        if (File.Exists("produtos.json"))
        {
            var json = File.ReadAllText("produtos.json");
            produtos = JsonSerializer.Deserialize<List<Produto>>(json);
        }
    }
}