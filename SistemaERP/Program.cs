using System;

namespace SistemaERP
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instanciar repositórios
            var repositorioClientes = new ClienteRepositorio();
            var repositorioProdutos = new ProdutoRepositorio();
            var repositorioPedidos = new PedidoRepositorio();

            // ====== Testando Cadastro de Clientes ======
            Console.WriteLine("Cadastrando clientes...");

            var cliente1 = new Cliente
            {
                Nome = "Gabriel",
                CPF_CNPJ = "123.456.789-00",
                Endereco = "Rua 1, Cidade",
                Telefone = "(11) 1234-5678",
                Email = "gabriel@email.com"
            };

            var cliente2 = new Cliente
            {
                Nome = "Maria",
                CPF_CNPJ = "987.654.321-00",
                Endereco = "Avenida 2, Cidade",
                Telefone = "(11) 8765-4321",
                Email = "maria@email.com"
            };

            repositorioClientes.Adicionar(cliente1);
            repositorioClientes.Adicionar(cliente2);

            // Listar Clientes
            Console.WriteLine("Clientes cadastrados:");
            foreach (var cliente in repositorioClientes.Listar())
            {
                Console.WriteLine($"Nome: {cliente.Nome}, CPF/CNPJ: {cliente.CPF_CNPJ}");
            }

            // ====== Testando Cadastro de Produtos ======
            Console.WriteLine("\nCadastrando produtos...");

            var produto1 = new Produto
            {
                Nome = "Mouse Gamer",
                Codigo = "001",
                Preco = 150.00M,
                QuantidadeEstoque = 50
            };

            var produto2 = new Produto
            {
                Nome = "Teclado Mecânico",
                Codigo = "002",
                Preco = 300.00M,
                QuantidadeEstoque = 30
            };

            repositorioProdutos.Adicionar(produto1);
            repositorioProdutos.Adicionar(produto2);

            // Listar Produtos
            Console.WriteLine("Produtos cadastrados:");
            foreach (var produto in repositorioProdutos.Listar())
            {
                Console.WriteLine($"Nome: {produto.Nome}, Código: {produto.Codigo}, Preço: {produto.Preco}, Estoque: {produto.QuantidadeEstoque}");
            }

            // ====== Testando Criação de Pedido ======
            Console.WriteLine("\nCriando um pedido...");

            var pedido = new Pedido
            {
                Cliente = cliente1
            };

            pedido.Produtos.Add((produto1, 2)); // Comprando 2 unidades de "Mouse Gamer"
            pedido.Produtos.Add((produto2, 1)); // Comprando 1 unidade de "Teclado Mecânico"

            repositorioPedidos.Adicionar(pedido);

            // Visualizar Pedido
            Console.WriteLine($"Pedido criado para {pedido.Cliente.Nome}");
            foreach (var item in pedido.Produtos)
            {
                Console.WriteLine($"{item.Quantidade}x {item.Produto.Nome} - Total: {item.Produto.Preco * item.Quantidade:C}");
            }
            Console.WriteLine($"Valor Total do Pedido: {pedido.CalcularTotal():C}");

            // ====== Testando Remoção de Produto ======
            Console.WriteLine("\nRemovendo produto do estoque...");
            repositorioProdutos.Remover(produto1);

            // Listar Produtos Após Remoção
            Console.WriteLine("Produtos após remoção:");
            foreach (var produto in repositorioProdutos.Listar())
            {
                Console.WriteLine($"Nome: {produto.Nome}, Código: {produto.Codigo}, Preço: {produto.Preco}, Estoque: {produto.QuantidadeEstoque}");
            }
        }
    }
}