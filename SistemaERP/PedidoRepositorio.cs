using System.Collections.Generic;
using System.Linq;

namespace SistemaERP
{
    public class PedidoRepositorio
    {
        private List<Pedido> pedidos = new List<Pedido>();

        public void AdicionarPedido(Pedido pedido)
        {
            pedidos.Add(pedido);
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
            }
        }
    }
}