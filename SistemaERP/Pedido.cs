using System;
using System.Collections.Generic;

public class Pedido
{
    public Cliente Cliente { get; set; }
    public DateTime DataPedido { get; set; }
    public Dictionary<Produto, int> Produtos { get; set; } = new Dictionary<Produto, int>();
    public decimal ValorTotal { get; private set; }

    public void AdicionarProduto(Produto produto, int quantidade)
    {
        if (Produtos.ContainsKey(produto))
            Produtos[produto] += quantidade;
        else
            Produtos[produto] = quantidade;
    }

    public void CalcularTotal()
    {
        ValorTotal = 0;
        foreach (var item in Produtos)
        {
            ValorTotal += item.Key.Preco * item.Value;
        }
    }
}