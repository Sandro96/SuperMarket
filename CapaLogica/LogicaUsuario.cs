using Datos;
using EntidadesCompartidas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class LogicaUsuario
    {
        RepositorioUsuario RepositorioUsuario = new RepositorioUsuario();
        public List<UsuarioDTO> ListaUsuario()
        {
            return RepositorioUsuario.ListaUsuario();
        }

        public void UsuarioNuevo(UsuarioDTO NuevoUsuario)
        {
            RepositorioUsuario.UsuarioNuevo(NuevoUsuario);
        }

        public UsuarioDTO BuscarUsuario(string usuario)
        {
            return RepositorioUsuario.BuscarUsuario(usuario);
        }
    }
}
