using System.Collections.Generic;
using System.Linq;

namespace SistemaERP
{
    public class ProdutoRepositorio
    {
        private List<Produto> produtos = new List<Produto>();

        public void AdicionarProduto(Produto produto)
        {
            produtos.Add(produto);
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
            }
        }
    }
}