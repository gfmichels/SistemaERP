using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace SistemaERP
{
    public class ProdutoRepositorio
    {
        private const string arquivoProdutos = "produtos.json";
        private List<Produto> produtos = new List<Produto>();

        public ProdutoRepositorio()
        {
            CarregarProdutos();
        }

        public void AdicionarProduto(Produto produto)
        {
            produtos.Add(produto);
            SalvarProdutos();
        }

        public List<Produto> ListarProdutos()
        {
            return produtos;
        }

        public void ExcluirProduto(string codigo)
        {
            var produto = produtos.FirstOrDefault(p => p.Codigo == codigo);
            if (produto != null)
            {
                produtos.Remove(produto);
                SalvarProdutos();
            }
        }

        private void SalvarProdutos()
        {
            var json = JsonConvert.SerializeObject(produtos, Formatting.Indented);
            File.WriteAllText(arquivoProdutos, json);
        }

        private void CarregarProdutos()
        {
            if (File.Exists(arquivoProdutos))
            {
                var json = File.ReadAllText(arquivoProdutos);
                produtos = JsonConvert.DeserializeObject<List<Produto>>(json) ?? new List<Produto>();
            }
        }
    }
}