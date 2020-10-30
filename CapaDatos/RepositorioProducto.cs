using EntidadesCompartidas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RepositorioProducto
    {
        public void ProductoNuevo(ProductoDTO NuevoProducto)
        {
            Producto ProductoNuevo = new Producto()
            {
                Nombre = NuevoProducto.Nombre,
                Identificador = NuevoProducto.Identificador,
                Marca = NuevoProducto.Marca,
                Precio = NuevoProducto.Precio,
                Habilitado = NuevoProducto.Habilitado
            };
            using (Database database = new Database())
            {
                database.Producto.Add(ProductoNuevo);
                database.SaveChanges();
            }
        }       

        public List<ProductoDTO> ListaProducto()
        {
            using (Database Database = new Database())
            {
                var ListaProducto = from unProducto in Database.Producto
                                    select new ProductoDTO()
                                    {
                                        Nombre = unProducto.Nombre,
                                        Identificador = unProducto.Identificador,
                                        Marca = unProducto.Marca,
                                        Precio = unProducto.Precio,
                                        Habilitado = unProducto.Habilitado
                                    };
                return ListaProducto.ToList();
            }
        }

        //Habilitamos y deshabilitamos.
        public void HabilitarProducto(int Identificador)
        {
            //Instanciamos nuestra base de datos
            using (Database laBase = new Database())
            {
                //Primero buscamos al cliente en la base de datos
                var miProducto = (from unProducto in laBase.Producto where unProducto.Identificador == Identificador select unProducto).First();

                //Fijamos el cliente
                laBase.Producto.Attach(miProducto);
                if (miProducto.Habilitado == true)
                {
                    miProducto.Habilitado = false;
                }
                else
                {
                    miProducto.Habilitado = true;
                }
                //Guardamos los cambios que acabamos de hacer
                laBase.SaveChanges();
            }
        }

        //Muestra los productos Deshabilitados
        public List<ProductoDTO> ProductosDeshabilitados()
        {

            using (Database Database = new Database())
            {
                var ProductosDeshabilitados = from unProducto in Database.Producto
                                              select new ProductoDTO
                                             {
                                                 Identificador = unProducto.Identificador,
                                                 Nombre = unProducto.Nombre,
                                                 Marca = unProducto.Marca,
                                                 Precio = unProducto.Precio,
                                                 Habilitado = unProducto.Habilitado
                                             };
                { return ProductosDeshabilitados.ToList(); }
            }
        }

        public ProductoDTO ProductoBuscar(int BuscarProducto)
        {
            using (Database database = new Database())
            {
                var unProducto = database.Producto.Where(x => x.Identificador == BuscarProducto).FirstOrDefault();

                if (unProducto != null)
                {
                    ProductoDTO ProductoPuente = new ProductoDTO()
                    {
                        Nombre = unProducto.Nombre,
                        Identificador = unProducto.Identificador,
                        Marca = unProducto.Marca,
                        Precio = Convert.ToInt32(unProducto.Precio),
                        Habilitado = unProducto.Habilitado
                    };
                    return ProductoPuente;
                }
                else
                {
                    return null;
                }
            }

        }
    }
}
