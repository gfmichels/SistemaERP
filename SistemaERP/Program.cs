using System;

class Program
{
    private static ClienteRepositorio clienteRepositorio = new ClienteRepositorio();
    private static ProdutoRepositorio produtoRepositorio = new ProdutoRepositorio();
    private static PedidoRepositorio pedidoRepositorio = new PedidoRepositorio();

    static void Main(string[] args)
    {
        CarregarDados();

        while (true)
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1. Cadastrar Cliente");
            Console.WriteLine("2. Cadastrar Produto");
            Console.WriteLine("3. Criar Pedido");
            Console.WriteLine("4. Listar Pedidos");
            Console.WriteLine("5. Sair");

            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    CadastrarCliente();
                    break;
                case "2":
                    CadastrarProduto();
                    break;
                case "3":
                    CriarPedido();
                    break;
                case "4":
                    ListarPedidos();
                    break;
                case "5":
                    pedidoRepositorio.SalvarDados();
                    return;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }

    static void CadastrarCliente()
    {
        Console.Write("Nome do Cliente: ");
        var nome = Console.ReadLine();
        Console.Write("CPF/CNPJ: ");
        var cpfCnpj = Console.ReadLine();

        var cliente = new Cliente { Nome = nome, CpfCnpj = cpfCnpj };
        clienteRepositorio.Adicionar(cliente);
        Console.WriteLine("Cliente cadastrado.");
    }

    static void CadastrarProduto()
    {
        Console.Write("Nome do Produto: ");
        var nome = Console.ReadLine();
        Console.Write("Código do Produto: ");
        var codigo = Console.ReadLine();
        Console.Write("Preço do Produto: ");
        var preco = decimal.Parse(Console.ReadLine());
        Console.Write("Estoque do Produto: ");
        var estoque = int.Parse(Console.ReadLine());

        var produto = new Produto { Nome = nome, Codigo = codigo, Preco = preco, Estoque = estoque };
        produtoRepositorio.Adicionar(produto);
        Console.WriteLine("Produto cadastrado.");
    }

    static void CriarPedido()
    {
        Console.WriteLine("Criando pedido...");
        ListarClientes();
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
            ListarProdutos();
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

    static void ListarClientes()
    {
        Console.WriteLine("Clientes cadastrados:");
        var clientes = clienteRepositorio.Listar();
        foreach (var cliente in clientes)
        {
            Console.WriteLine($"Nome: {cliente.Nome}, CPF/CNPJ: {cliente.CpfCnpj}");
        }
    }

    static void ListarProdutos()
    {
        Console.WriteLine("Produtos cadastrados:");
        var produtos = produtoRepositorio.Listar();
        foreach (var produto in produtos)
        {
            Console.WriteLine($"Nome: {produto.Nome}, Código: {produto.Codigo}, Preço: {produto.Preco}, Estoque: {produto.Estoque}");
        }
    }

    static void ListarPedidos()
    {
        Console.WriteLine("Pedidos realizados:");
        var pedidos = pedidoRepositorio.Listar();
        foreach (var pedido in pedidos)
        {
            Console.WriteLine($"Pedido para {pedido.Cliente.Nome} em {pedido.DataPedido} - Total: R$ {pedido.ValorTotal}");
            foreach (var item in pedido.Produtos)
            {
                Console.WriteLine($"- {item.Quantidade}x {item.Produto.Nome}");
            }
        }
    }

    static void CarregarDados()
    {
        clienteRepositorio.CarregarDados();
        produtoRepositorio.CarregarDados();
        pedidoRepositorio.CarregarDados();
    }
}
