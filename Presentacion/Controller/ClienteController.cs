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
    public class ClienteController : Controller
    {
        LogicaCliente LogicaCliente = new LogicaCliente();
        public ActionResult ListaCliente()
        {
            if (Session["Usuario"] != null)
            {
                List<ClienteDTO> ListaCliente = LogicaCliente.ListaCliente();
                List<ClienteModel> ListadoCliente = new List<ClienteModel>();
                foreach (ClienteDTO UnCliente in ListaCliente)
                {
                    ClienteModel OtroCliente = new ClienteModel();
                    OtroCliente.Ci = UnCliente.Ci;
                    OtroCliente.Nombre = UnCliente.Nombre;
                    OtroCliente.Domicilio = UnCliente.Domicilio;
                    OtroCliente.FechaNacimiento = UnCliente.FechaNacimiento;
                    if (UnCliente.Habilitado == true)
                    {
                        ListadoCliente.Add(OtroCliente);
                    }
                }
                return View(ListadoCliente);
            }
            else
            {
                return RedirectToAction("Ingreso", "Usuario");
            }
        }

        //La vista, para que complete los datos.
        public ActionResult CrearCliente()
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

        //Aca vienen los datos como ClienteModel.
        [HttpPost]
        public ActionResult CrearCliente(ClienteModel NuevoCliente)
        {
            if (ModelState.IsValid)
            {
                ClienteDTO ClienteNuevo = new ClienteDTO()
                {
                    Nombre = NuevoCliente.Nombre,
                    Ci = NuevoCliente.Ci,
                    Domicilio = NuevoCliente.Domicilio,
                    FechaNacimiento = NuevoCliente.FechaNacimiento,
                    Habilitado = true
                };
                LogicaCliente.ClienteNuevo(ClienteNuevo);
                return RedirectToAction("ListaCliente");

            }
            else
            {
                return View(NuevoCliente);
            }
        }

        //Habilitar y desabilitar
        public ActionResult HabilitarCliente(int Ci)
        {
            LogicaCliente.HabilitarCliente(Ci);
            ClienteDTO unCliente = LogicaCliente.ClienteBuscar(Ci);
            if (unCliente != null && unCliente.Habilitado == true)
            {
                return RedirectToAction("ClientesDeshabilitados");
            }
            else
            {
                return RedirectToAction("ListaCliente");
            }
        }

        public ActionResult ClientesDeshabilitados()
        {
            if (Session["Usuario"] != null)
            {
                List<ClienteDTO> ClientesDeshabilitados = LogicaCliente.ClientesDeshabilitados();
                List<ClienteModel> ListadoCliente = new List<ClienteModel>();
                foreach (ClienteDTO UnCliente in ClientesDeshabilitados)
                {
                    ClienteModel OtroCliente = new ClienteModel();
                    OtroCliente.Ci = UnCliente.Ci;
                    OtroCliente.Nombre = UnCliente.Nombre;
                    OtroCliente.Domicilio = UnCliente.Domicilio;
                    OtroCliente.FechaNacimiento = UnCliente.FechaNacimiento;
                    if (UnCliente.Habilitado == false)
                    {
                        ListadoCliente.Add(OtroCliente);
                    }
                }
                return View(ListadoCliente);
            }
            else
            {
                return RedirectToAction("Ingreso", "Usuario");
            }
        }

        public ActionResult TiposClientes()
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