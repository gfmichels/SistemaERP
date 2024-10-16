using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace SistemaERP
{
    public class PedidoRepositorio
    {
        private const string arquivoPedidos = "pedidos.json";
        private List<Pedido> pedidos = new List<Pedido>();

        public PedidoRepositorio()
        {
            CarregarPedidos();
        }

        public void AdicionarPedido(Pedido pedido)
        {
            pedidos.Add(pedido);
            SalvarPedidos();
        }

        public List<Pedido> ListarPedidos()
        {
            return pedidos;
        }

        public void ExcluirPedido(string codigoPedido)
        {
            var pedido = pedidos.FirstOrDefault(p => p.CodigoPedido == codigoPedido);
            if (pedido != null)
            {
                pedidos.Remove(pedido);
                SalvarPedidos();
            }
        }

        private void SalvarPedidos()
        {
            var json = JsonConvert.SerializeObject(pedidos, Formatting.Indented);
            File.WriteAllText(arquivoPedidos, json);
        }

        private void CarregarPedidos()
        {
            if (File.Exists(arquivoPedidos))
            {
                var json = File.ReadAllText(arquivoPedidos);
                pedidos = JsonConvert.DeserializeObject<List<Pedido>>(json) ?? new List<Pedido>();
            }
        }
    }
}