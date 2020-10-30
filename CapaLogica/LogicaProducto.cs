using Datos;
using EntidadesCompartidas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class LogicaProducto
    {
        RepositorioProducto RepositorioProducto = new RepositorioProducto();
        public List<ProductoDTO> ListaProducto()
        {
            return RepositorioProducto.ListaProducto();
        }
        public void ProductoNuevo(ProductoDTO NuevoProducto)
        {
            RepositorioProducto.ProductoNuevo(NuevoProducto);
        }
        public ProductoDTO ProductoBuscar(int BuscarProducto)
        {
            return RepositorioProducto.ProductoBuscar(BuscarProducto);
        }
        public void HabilitarProducto(int Ci)
        {
            RepositorioProducto.HabilitarProducto(Ci);
        }
        public List<ProductoDTO> ProductosDeshabilitados()
        {
            return RepositorioProducto.ProductosDeshabilitados();
        }
    }
}
