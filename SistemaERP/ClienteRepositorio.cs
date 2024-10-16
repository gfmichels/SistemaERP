using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace SistemaERP
{
    public class ClienteRepositorio
    {
        private const string arquivoClientes = "clientes.json";
        private List<Cliente> clientes = new List<Cliente>();

        public ClienteRepositorio()
        {
            CarregarClientes();
        }

        public void AdicionarCliente(Cliente cliente)
        {
            clientes.Add(cliente);
            SalvarClientes();
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
                SalvarClientes();
            }
        }

        private void SalvarClientes()
        {
            var json = JsonConvert.SerializeObject(clientes, Formatting.Indented);
            File.WriteAllText(arquivoClientes, json);
        }

        private void CarregarClientes()
        {
            if (File.Exists(arquivoClientes))
            {
                var json = File.ReadAllText(arquivoClientes);
                clientes = JsonConvert.DeserializeObject<List<Cliente>>(json) ?? new List<Cliente>();
            }
        }
    }
}