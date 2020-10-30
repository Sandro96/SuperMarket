using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentacion.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Inicio()
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
    }
}