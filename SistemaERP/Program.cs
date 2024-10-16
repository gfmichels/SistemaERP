using System;
using System.Collections.Generic;

namespace SistemaERP
{
    class Program
    {
        static ClienteRepositorio clienteRepo = new ClienteRepositorio();
        static ProdutoRepositorio produtoRepo = new ProdutoRepositorio();
        static PedidoRepositorio pedidoRepo = new PedidoRepositorio();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Sistema ERP ===");
                Console.WriteLine("1 - Gerenciar Clientes");
                Console.WriteLine("2 - Gerenciar Produtos");
                Console.WriteLine("3 - Gerenciar Pedidos");
                Console.WriteLine("4 - Sair");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        GerenciarClientes();
                        break;
                    case "2":
                        GerenciarProdutos();
                        break;
                    case "3":
                        GerenciarPedidos();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        static void GerenciarClientes()
        {
            Console.Clear();
            Console.WriteLine("=== Gerenciamento de Clientes ===");
            Console.WriteLine("1 - Criar Cliente");
            Console.WriteLine("2 - Listar Clientes");
            Console.WriteLine("3 - Excluir Cliente");
            Console.WriteLine("4 - Voltar");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    CriarCliente();
                    break;
                case "2":
                    ListarClientes();
                    break;
                case "3":
                    ExcluirCliente();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }

        static void CriarCliente()
        {
            Console.Write("Digite o nome do cliente: ");
            string nome = Console.ReadLine();
            Console.Write("Digite o CPF/CNPJ do cliente: ");
            string cpfCnpj = Console.ReadLine();

            Cliente novoCliente = new Cliente { Nome = nome, CpfCnpj = cpfCnpj };
            clienteRepo.AdicionarCliente(novoCliente);

            Console.WriteLine("Cliente criado com sucesso!");
            Console.ReadKey();
        }

        static void ListarClientes()
        {
            List<Cliente> clientes = clienteRepo.ListarClientes();
            foreach (var cliente in clientes)
            {
                Console.WriteLine($"Cliente: {cliente.Nome}, CPF/CNPJ: {cliente.CpfCnpj}");
            }
            Console.ReadKey();
        }

        static void ExcluirCliente()
        {
            Console.Write("Digite o CPF/CNPJ do cliente a ser excluído: ");
            string cpfCnpj = Console.ReadLine();

            clienteRepo.ExcluirCliente(cpfCnpj);
            Console.WriteLine("Cliente excluído com sucesso!");
            Console.ReadKey();
        }

        static void GerenciarProdutos()
        {
            Console.Clear();
            Console.WriteLine("=== Gerenciamento de Produtos ===");
            Console.WriteLine("1 - Criar Produto");
            Console.WriteLine("2 - Listar Produtos");
            Console.WriteLine("3 - Excluir Produto");
            Console.WriteLine("4 - Voltar");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    CriarProduto();
                    break;
                case "2":
                    ListarProdutos();
                    break;
                case "3":
                    ExcluirProduto();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }

        static void CriarProduto()
        {
            Console.Write("Digite o nome do produto: ");
            string nome = Console.ReadLine();
            Console.Write("Digite o código do produto: ");
            string codigo = Console.ReadLine();
            Console.Write("Digite a quantidade em estoque: ");
            int estoque = int.Parse(Console.ReadLine());

            Produto novoProduto = new Produto { Nome = nome, Codigo = codigo, Estoque = estoque };
            produtoRepo.AdicionarProduto(novoProduto);

            Console.WriteLine("Produto criado com sucesso!");
            Console.ReadKey();
        }

        static void ListarProdutos()
        {
            List<Produto> produtos = produtoRepo.ListarProdutos();
            foreach (var produto in produtos)
            {
                Console.WriteLine($"Produto: {produto.Nome}, Código: {produto.Codigo}, Estoque: {produto.Estoque}");
            }
            Console.ReadKey();
        }

        static void ExcluirProduto()
        {
            Console.Write("Digite o código do produto a ser excluído: ");
            string codigo = Console.ReadLine();

            produtoRepo.ExcluirProduto(codigo);
            Console.WriteLine("Produto excluído com sucesso!");
            Console.ReadKey();
        }

        static void GerenciarPedidos()
        {
            Console.Clear();
            Console.WriteLine("=== Gerenciamento de Pedidos ===");
            Console.WriteLine("1 - Criar Pedido");
            Console.WriteLine("2 - Listar Pedidos");
            Console.WriteLine("3 - Excluir Pedido");
            Console.WriteLine("4 - Voltar");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    CriarPedido();
                    break;
                case "2":
                    ListarPedidos();
                    break;
                case "3":
                    ExcluirPedido();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }

        static void CriarPedido()
        {
            Console.Write("Digite o código do pedido: ");
            string codigoPedido = Console.ReadLine();
            Console.Write("Digite o produto do pedido: ");
            string produto = Console.ReadLine();

            Pedido novoPedido = new Pedido { CodigoPedido = codigoPedido, Produto = produto };
            pedidoRepo.AdicionarPedido(novoPedido);

            Console.WriteLine("Pedido criado com sucesso!");
            Console.ReadKey();
        }

        static void ListarPedidos()
        {
            List<Pedido> pedidos = pedidoRepo.ListarPedidos();
            foreach (var pedido in pedidos)
            {
                Console.WriteLine($"Pedido: {pedido.CodigoPedido}, Produto: {pedido.Produto}");
            }
            Console.ReadKey();
        }

        static void ExcluirPedido()
        {
            Console.Write("Digite o código do pedido a ser excluído: ");
            string codigoPedido = Console.ReadLine();

            pedidoRepo.ExcluirPedido(codigoPedido);
            Console.WriteLine("Pedido excluído com sucesso!");
            Console.ReadKey();
        }
    }
}