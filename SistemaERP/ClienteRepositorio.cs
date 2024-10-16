using System.Collections.Generic;
using System.Linq;

namespace SistemaERP
{
    public class ClienteRepositorio
    {
        private List<Cliente> clientes = new List<Cliente>();

        public void AdicionarCliente(Cliente cliente)
        {
            clientes.Add(cliente);
        }

        public List<Cliente> ListarClientes()
        {
            return clientes;
        }

        public void ExcluirCliente(string cpfCnpj)
        {
            var cliente = clientes.FirstOrDefault(c => c.CpfCnpj == cpfCnpj);
            if (cliente != null)
            {
                clientes.Remove(cliente);
            }
        }
    }
}