using Datos;
using EntidadesCompartidas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class LogicaCliente
    {
        RepositorioCliente RepositorioCliente = new RepositorioCliente();
        public List<ClienteDTO> ListaCliente()
        {
            return RepositorioCliente.ListaCliente();
        }
        public void ClienteNuevo(ClienteDTO NuevoCliente)
        {
            RepositorioCliente.ClienteNuevo(NuevoCliente); 
        }
        public ClienteDTO ClienteBuscar(int BuscarCliente)
        {
            return RepositorioCliente.ClienteBuscar(BuscarCliente);
        }
        public void HabilitarCliente(int Ci)
        {
            RepositorioCliente.HabilitarCliente(Ci);
        }
        public List<ClienteDTO> ClientesDeshabilitados()
        {
            return RepositorioCliente.ClientesDeshabilitados();
        }
    }
}
