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
    public class FacturaController : Controller
    {
        // GET: Factura
        LogicaFactura LogicaFactura = new LogicaFactura();
        public ActionResult ListaFactura()
        {
            if (Session["Usuario"] != null)
            {
                List<FacturaDTO> ListaFactura = LogicaFactura.ListaFactura();
                List<FacturaModel> ListadoFactura = new List<FacturaModel>();
                foreach (FacturaDTO unaFactura in ListaFactura)
                {
                    FacturaModel otraFactura = new FacturaModel();
                    otraFactura.Numero = unaFactura.Numero;
                    otraFactura.Numero_Cliente = unaFactura.Numero_Cliente;
                    otraFactura.Total = unaFactura.Total;
                    otraFactura.Fecha = unaFactura.Fecha;
                    otraFactura.Usuario = unaFactura.Usuario;
                    ListadoFactura.Add(otraFactura);
                }
                return View(ListadoFactura);
            }
            else
            {
                return RedirectToAction("Ingreso", "Usuario");
            }
        }

        public ActionResult CrearFactura()
        {
            if (Session["Usuario"] != null)
            {
                FacturaModel NuevaFactura = new FacturaModel();
                NuevaFactura.ListaDetalle = new List<DetalleModel>();
                Session.Add("unaFactura", NuevaFactura);
                return View();
            }
            else
            {
                return RedirectToAction("Ingreso", "Usuario");
            }
        }
        [HttpPost]
        public ActionResult CrearFactura(FacturaModel unaFactura)
        {
            if (ModelState.IsValid)
            {
                //Traemos la factura de session.
                FacturaModel NuevaFactura = (FacturaModel)Session["unaFactura"];
                //Traemos el nombre de usuario de session.
                UsuarioModel usuariosesion = (UsuarioModel)Session["Usuario"];
                //Cargamos los datos.
                NuevaFactura.Numero_Cliente = unaFactura.Numero_Cliente;
                NuevaFactura.Numero = unaFactura.Numero;
                NuevaFactura.Usuario = usuariosesion.Usuario;
                NuevaFactura.Fecha = DateTime.Now;

                //Creamos DetalleFactura.
                DetalleModel NuevoDetalle = new DetalleModel() { Cantidad = unaFactura.Cantidad, Identificador = unaFactura.Identificador };
                NuevaFactura.ListaDetalle.Add(NuevoDetalle);

                //Instanciamos la logica producto.
                LogicaProducto LogicaProducto = new LogicaProducto();

                //Traemos el producto con su identificador.
                ProductoDTO unProducto = LogicaProducto.ProductoBuscar(unaFactura.Identificador);

                //Le asignamos el total.
                NuevaFactura.Total += unaFactura.Cantidad * unProducto.Precio;

                //Sobrescribimos la factura que esta en sesion con un nuevo detalle.
                Session.Add("unaFactura", NuevaFactura);

                return View(NuevaFactura);
            }
            return View(unaFactura);
        }

        public ActionResult GuardarFactura(FacturaModel FacturaGuardada)
        {
            FacturaDTO unaFactura = new FacturaDTO()
            {
                Numero = FacturaGuardada.Numero,
                Numero_Cliente = FacturaGuardada.Numero_Cliente,
                Usuario = FacturaGuardada.Usuario,
                Fecha = DateTime.Now,
                Total = FacturaGuardada.Total,
                ListaDetalle = new List<DetalleDTO>()
            };
            List<DetalleDTO> elDetalle = new List<DetalleDTO>();
            unaFactura.ListaDetalle = new List<DetalleDTO>();
            foreach (DetalleModel unDetalle in FacturaGuardada.ListaDetalle)
            {
                DetalleDTO otroDetalle = new DetalleDTO()
                {
                    Cantidad = unDetalle.Cantidad,
                    Identificador = unDetalle.Identificador,
                    Factura = FacturaGuardada.Numero
                };
                elDetalle.Add(otroDetalle);
            }
            unaFactura.ListaDetalle = elDetalle;
            LogicaFactura unaLogica = new LogicaFactura();
            unaLogica.FacturaNueva(unaFactura);
            return RedirectToAction("ListaFactura");
        }

        public ActionResult DetalleFactura(int NumeroFactura)
        {
            FacturaDTO unaFactura = LogicaFactura.BuscarFactura(NumeroFactura);

            //Convertimos FacturaDTO en FacturaModel
            FacturaModel factura = new FacturaModel
            {
                Fecha = unaFactura.Fecha,
                Numero_Cliente = unaFactura.Numero_Cliente,
                Numero = unaFactura.Numero,
                Usuario = unaFactura.Usuario,
                Total = unaFactura.Total,
                ListaDetalle = new List<DetalleModel>()
            };
            foreach (DetalleDTO detalle in unaFactura.ListaDetalle)
            {
                    DetalleModel otroDetalle = new DetalleModel()
                    {
                        Identificador = detalle.Identificador,
                        Cantidad = detalle.Cantidad
                    };
                    factura.ListaDetalle.Add(otroDetalle);
            }
            return View(factura);
        }
    
        public ActionResult TiposFacturas()
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