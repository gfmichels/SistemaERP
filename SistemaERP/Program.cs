using System;

public class Program
{
    static ClienteRepositorio clienteRepositorio = new ClienteRepositorio();
    static ProdutoRepositorio produtoRepositorio = new ProdutoRepositorio();
    static PedidoRepositorio pedidoRepositorio = new PedidoRepositorio();

    public static void Main(string[] args)
    {
        CarregarDados();

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Cadastrar Cliente");
            Console.WriteLine("2. Listar Clientes");
            Console.WriteLine("3. Cadastrar Produto");
            Console.WriteLine("4. Listar Produtos");
            Console.WriteLine("5. Criar Pedido");
            Console.WriteLine("6. Sair");
            Console.Write("Escolha uma opção: ");

            var opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1":
                    CadastrarCliente(clienteRepositorio);
                    break;
                case "2":
                    ListarClientes(clienteRepositorio);
                    break;
                case "3":
                    CadastrarProduto(produtoRepositorio);
                    break;
                case "4":
                    ListarProdutos(produtoRepositorio);
                    break;
                case "5":
                    CriarPedido();
                    break;
                case "6":
                    SalvarDados();
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void CadastrarCliente(ClienteRepositorio repositorio)
    {
        var cliente = new Cliente();
        Console.Write("Nome: ");
        cliente.Nome = Console.ReadLine();
        Console.Write("CPF/CNPJ: ");
        cliente.CPF_CNPJ = Console.ReadLine();
        Console.Write("Endereço: ");
        cliente.Endereco = Console.ReadLine();
        Console.Write("Telefone: ");
        cliente.Telefone = Console.ReadLine();
        Console.Write("E-mail: ");
        cliente.Email = Console.ReadLine();
        repositorio.Adicionar(cliente);
        Console.WriteLine("Cliente cadastrado com sucesso.");
    }

    static void ListarClientes(ClienteRepositorio repositorio)
    {
        Console.WriteLine("Clientes cadastrados:");
        foreach (var cliente in repositorio.Listar())
        {
            Console.WriteLine($"Nome: {cliente.Nome}, CPF/CNPJ: {cliente.CPF_CNPJ}");
        }
    }

    static void CadastrarProduto(ProdutoRepositorio repositorio)
    {
        var produto = new Produto();
        Console.Write("Nome: ");
        produto.Nome = Console.ReadLine();
        Console.Write("Código: ");
        produto.Codigo = Console.ReadLine();
        Console.Write("Preço: ");
        produto.Preco = decimal.Parse(Console.ReadLine());
        Console.Write("Quantidade em Estoque: ");
        produto.QuantidadeEstoque = int.Parse(Console.ReadLine());
        repositorio.Adicionar(produto);
        Console.WriteLine("Produto cadastrado com sucesso.");
    }

    static void ListarProdutos(ProdutoRepositorio repositorio)
    {
        Console.WriteLine("Produtos cadastrados:");
        foreach (var produto in repositorio.Listar())
        {
            Console.WriteLine($"Nome: {produto.Nome}, Código: {produto.Codigo}, Preço: {produto.Preco}, Estoque: {produto.QuantidadeEstoque}");
        }
    }

    static void CriarPedido()
    {
        Console.WriteLine("Criando pedido...");
        ListarClientes(clienteRepositorio);
        Console.Write("Escolha o nome do cliente: ");
        var nomeCliente = Console.ReadLine();
        var cliente = clienteRepositorio.BuscarPorNome(nomeCliente);

        if (cliente == null)
        {
            Console.WriteLine("Cliente não encontrado.");
            return;
        }

        var pedido = new Pedido();
        pedido.Cliente = cliente;
        pedido.DataPedido = DateTime.Now;

        while (true)
        {
            ListarProdutos(produtoRepositorio);
            Console.Write("Escolha o código do produto (ou 'sair' para finalizar): ");
            var codigoProduto = Console.ReadLine();
            if (codigoProduto.ToLower() == "sair") break;

            var produto = produtoRepositorio.BuscarPorCodigo(codigoProduto);
            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado.");
                continue;
            }

            Console.Write("Quantidade: ");
            var quantidade = int.Parse(Console.ReadLine());
            pedido.AdicionarProduto(produto, quantidade);
        }

        pedido.CalcularTotal();
        pedidoRepositorio.Adicionar(pedido);
        Console.WriteLine($"Pedido criado para {cliente.Nome}. Valor Total: R$ {pedido.ValorTotal}");
    }

    static void CarregarDados()
    {
        clienteRepositorio.CarregarDados();
        produtoRepositorio.CarregarDados();
        pedidoRepositorio.CarregarDados();
    }

    static void SalvarDados()
    {
        clienteRepositorio.SalvarDados();
        produtoRepositorio.SalvarDados();
        pedidoRepositorio.SalvarDados();
        Console.WriteLine("Dados salvos com sucesso.");
    }
}