using EntidadesCompartidas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RepositorioCliente
    {
        //El repositorio es para los metodos(Crear,borar,editar,listar,etc)

        public void ClienteNuevo(ClienteDTO NuevoCliente)
        {
            Cliente ClienteNuevo = new Cliente()
            {
                Ci = NuevoCliente.Ci,
                Nombre = NuevoCliente.Nombre,
                Domicilio = NuevoCliente.Domicilio,
                Fecha_Nacimiento = NuevoCliente.FechaNacimiento,
                Habilitado = NuevoCliente.Habilitado,
            };
            using (Database database = new Database())
            {
                database.Cliente.Add(ClienteNuevo);
                database.SaveChanges();
            }
        }

        public List<ClienteDTO> ListaCliente()
        {
            
            using (Database Database = new Database())
            {
                var ListaCliente = from unCliente in Database.Cliente
                                   select new ClienteDTO
                                   {
                                       Ci = unCliente.Ci,
                                       Nombre = unCliente.Nombre,
                                       Domicilio = unCliente.Domicilio,
                                       FechaNacimiento = unCliente.Fecha_Nacimiento,
                                       Habilitado = unCliente.Habilitado
                                   };
                { return ListaCliente.ToList(); }
            }
        }

        //Habilitamos y deshabilitamos.
        public void HabilitarCliente(int Ci)
        {
            //Instanciamos nuestra base de datos
            using (Database laBase = new Database())
            {
                //Primero buscamos al cliente en la base de datos
                var miCliente = (from unCliente in laBase.Cliente where unCliente.Ci == Ci select unCliente).First();

                //Fijamos el cliente
                laBase.Cliente.Attach(miCliente);
                if (miCliente.Habilitado == true)
                {
                    miCliente.Habilitado = false;
                }
                else
                {
                    miCliente.Habilitado = true;
                }
                //Guardamos los cambios que acabamos de hacer
                laBase.SaveChanges();
            }
        }

        //Muestra los clientes Deshabilitados
        public List<ClienteDTO> ClientesDeshabilitados()
        {

            using (Database Database = new Database())
            {
                var ClientesDeshabilitados = from unCliente in Database.Cliente
                                   select new ClienteDTO
                                   {
                                       Ci = unCliente.Ci,
                                       Nombre = unCliente.Nombre,
                                       Domicilio = unCliente.Domicilio,
                                       FechaNacimiento = unCliente.Fecha_Nacimiento,
                                       Habilitado = unCliente.Habilitado
                                   };
                { return ClientesDeshabilitados.ToList(); }
            }
        }

        public ClienteDTO ClienteBuscar(int BuscarCliente)
        {
            using (Database database = new Database())
            {
                var unCliente = database.Cliente.Where(x => x.Ci == BuscarCliente).FirstOrDefault();
                if (unCliente != null)
                {
                    ClienteDTO ClientePuente = new ClienteDTO()
                    {
                        Ci = unCliente.Ci,
                        Nombre = unCliente.Nombre,
                        Domicilio = unCliente.Domicilio,
                        FechaNacimiento = unCliente.Fecha_Nacimiento,
                        Habilitado = unCliente.Habilitado,
                    };
                    return ClientePuente;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
