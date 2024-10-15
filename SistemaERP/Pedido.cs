using System;
using System.Collections.Generic;

public class Pedido
{
    public Cliente Cliente { get; set; }
    public DateTime DataPedido { get; set; }
    public List<ProdutoQuantidade> Produtos { get; set; } = new List<ProdutoQuantidade>();
    public decimal ValorTotal { get; private set; }

    public void AdicionarProduto(Produto produto, int quantidade)
    {
        Produtos.Add(new ProdutoQuantidade { Produto = produto, Quantidade = quantidade });
    }

    public void CalcularTotal()
    {
        ValorTotal = 0;
        foreach (var item in Produtos)
        {
            ValorTotal += item.Produto.Preco * item.Quantidade;
        }
    }
}

public class ProdutoQuantidade
{
    public Produto Produto { get; set; }
    public int Quantidade { get; set; }
}
