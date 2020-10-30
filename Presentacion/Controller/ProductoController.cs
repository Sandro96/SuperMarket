using EntidadesCompartidas;
using Logica;
using Presentacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentacion.Controllers
{
    public class ProductoController : Controller
    {
        LogicaProducto LogicaProducto = new LogicaProducto();
        public ActionResult ListaProducto()
        {
            if (Session["Usuario"] != null)
            {
                List<ProductoDTO> ListaProducto = LogicaProducto.ListaProducto();
                List<ProductoModel> ListadoProducto = new List<ProductoModel>();
                foreach (ProductoDTO UnProducto in ListaProducto)
                {
                    ProductoModel OtroProducto = new ProductoModel();
                    OtroProducto.Nombre = UnProducto.Nombre;
                    OtroProducto.Identificador = UnProducto.Identificador;
                    OtroProducto.Marca = UnProducto.Marca;
                    OtroProducto.Precio = UnProducto.Precio;
                    if (UnProducto.Habilitado == true)
                    {
                        ListadoProducto.Add(OtroProducto);
                    }

                }
                return View(ListadoProducto);
            }
            else
            {
                return RedirectToAction("Ingreso", "Usuario");
            }
        }

        //La vista, para que complete los datos.
        public ActionResult CrearProducto()
        {
            {
                if (Session["Usuario"] != null)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Ingreso", "Usuario");
                }
            }
        } 

        [HttpPost]
        public ActionResult CrearProducto(ProductoModel NuevoProducto)
        {
            if (ModelState.IsValid)
            {
                ProductoDTO ProductoNuevo = new ProductoDTO()
                {
                    Nombre = NuevoProducto.Nombre,
                    Identificador = NuevoProducto.Identificador,
                    Marca = NuevoProducto.Marca,
                    Precio = NuevoProducto.Precio,
                    Habilitado = NuevoProducto.Habilitado
                };
                LogicaProducto.ProductoNuevo(ProductoNuevo);
                return View();

            }
            else
            {
                return View(NuevoProducto);
            }
        }

        //Habilitar y desabilitar
        public ActionResult HabilitarProducto(int Identificador)
        {
            LogicaProducto.HabilitarProducto(Identificador);
            ProductoDTO unProducto = LogicaProducto.ProductoBuscar(Identificador);
            if (unProducto != null && unProducto.Habilitado == true)
            {
                return RedirectToAction("ProductosDeshabilitados");
            }
            else
            {
                return RedirectToAction("ListaProducto");
            }
        }

        public ActionResult ProductosDeshabilitados()
        {
            if (Session["Usuario"] != null)
            {
                List<ProductoDTO> ProductosDeshabilitados = LogicaProducto.ProductosDeshabilitados();
                List<ProductoModel> ListadoProducto = new List<ProductoModel>();
                foreach (ProductoDTO UnProducto in ProductosDeshabilitados)
                {
                    ProductoModel OtroProducto = new ProductoModel();
                    OtroProducto.Identificador = UnProducto.Identificador;
                    OtroProducto.Nombre = UnProducto.Nombre;
                    OtroProducto.Marca = UnProducto.Marca;
                    OtroProducto.Precio = UnProducto.Precio;
                    OtroProducto.Habilitado = UnProducto.Habilitado;
                    if (UnProducto.Habilitado == false)
                    {
                        ListadoProducto.Add(OtroProducto);
                    }
                }
                return View(ListadoProducto);
            }
            else
            {
                return RedirectToAction("Ingreso", "Usuario");
            }
        }

        public ActionResult TiposProductos()
        {
            if (Session["Usuario"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Ingreso", "Usuario");
            }
        }
    }
}