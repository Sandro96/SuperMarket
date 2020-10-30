using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentacion.Models
{
    public class UsuarioModel
    {
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public bool Administrador { get; set; }
    }
}