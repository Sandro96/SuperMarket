using EntidadesCompartidas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RepositorioUsuario
    {
        public UsuarioDTO BuscarUsuario(string usuario)
        {
            using (Database Database = new Database())
            {
                var unUsuario = Database.Usuario.Where(m => m.Usuario1.Trim().ToLower() == usuario.Trim().ToLower()).FirstOrDefault();
                if (unUsuario != null)
                {
                    UsuarioDTO otroUsuario = new UsuarioDTO()
                    {
                        Usuario = unUsuario.Usuario1,
                        Contrasena = unUsuario.Contrasena,
                        Administrador = unUsuario.Administrador
                    };
                    return otroUsuario;
                }
                else
                {
                    return null;
                }
            }
        }

        public void UsuarioNuevo(UsuarioDTO NuevoUsuario)
        {
            Usuario UsuarioNuevo = new Usuario()
            {
                Usuario1 = NuevoUsuario.Usuario,
                Contrasena = NuevoUsuario.Contrasena,
                Administrador = NuevoUsuario.Administrador,
            };
            using (Database database = new Database())
            {
                database.Usuario.Add(UsuarioNuevo);
                database.SaveChanges();
            }
        }

        public List<UsuarioDTO> ListaUsuario()
        {

            using (Database Database = new Database())
            {
                var ListaUsuario = from unUsuario in Database.Usuario
                                   select new UsuarioDTO
                                   {
                                       Usuario = unUsuario.Usuario1,
                                       Contrasena = unUsuario.Contrasena,
                                       Administrador = unUsuario.Administrador,
                                   };
                { return ListaUsuario.ToList(); }
            }
        }
       
    }
}
