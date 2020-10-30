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
    public class UsuarioController : Controller
    {

        LogicaUsuario miLogica = new LogicaUsuario();
        public ActionResult ListaUsuario()
        {
            if (Session["Usuario"] != null)
            {
                List<UsuarioDTO> ListaUsuario = miLogica.ListaUsuario();
                List<UsuarioModel> ListadoUsuario = new List<UsuarioModel>();
                foreach (UsuarioDTO UnUsuario in ListaUsuario)
                {
                    UsuarioModel otroUsuario = new UsuarioModel();
                    otroUsuario.Usuario = UnUsuario.Usuario;
                    otroUsuario.Contrasena = UnUsuario.Contrasena;
                    otroUsuario.Administrador = UnUsuario.Administrador;
                    ListadoUsuario.Add(otroUsuario);

                }
                return View(ListadoUsuario);
            }
            else
            {
                return RedirectToAction("Ingreso", "Usuario");
            }
        }

        //La vista, para que complete los datos.
        public ActionResult CrearUsuario()
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
        public ActionResult CrearUsuario(UsuarioModel NuevoUsuario)
        {
            if (ModelState.IsValid)
            {
                UsuarioDTO UsuarioNuevo = new UsuarioDTO()
                {
                    Usuario = NuevoUsuario.Usuario,
                    Contrasena = NuevoUsuario.Contrasena,
                    Administrador = NuevoUsuario.Administrador,
                };
                miLogica.UsuarioNuevo(UsuarioNuevo);
                return RedirectToAction("ListaUsuario");

            }
            else
            {
                return View(NuevoUsuario);
            }
        }

        //Este es un Get para mostrar.
        public ActionResult Ingreso()
        {
            if (Session["Usuario"] == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Inicio","Home");
            }
        }

        //Recibe el modelo que lleno el usuario.
        [HttpPost]
        public ActionResult Ingreso(UsuarioModel unUsuario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UsuarioDTO Usuario = miLogica.BuscarUsuario(unUsuario.Usuario);
                    if (Usuario == null)
                    {
                        ModelState.AddModelError("Usuario", "El nombre de usuario no es correcto.");
                        return View(unUsuario);
                    }
                    else
                    {

                        if (unUsuario.Contrasena == Usuario.Contrasena)
                        {
                            UsuarioModel usuarioModel = new UsuarioModel()
                            {
                                Usuario = Usuario.Usuario,
                                Contrasena = Usuario.Contrasena,
                                Administrador = Usuario.Administrador
                            };
                            Session.Add("Usuario", usuarioModel);
                            return RedirectToAction("Inicio", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("Contrasena", "La contraseña no es correcta.");
                            return View(unUsuario);
                        }
                    }
                }
                catch (Exception)
                {
                    return View("Error");
                }
            }
            else
            {
                return View(unUsuario);
            }
        }

        public ActionResult Logout()
        {
            Session["Usuario"] = null;
            return RedirectToAction("Ingreso");
        }

        public ActionResult TiposUsuarios()
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