using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Presentacion.Models
{
    public class ClienteModel
    {
        public int Ci { get; set; }

        public string Nombre { get; set; }

        public string Domicilio { get; set; }
        
        public DateTime FechaNacimiento { get; set; }

        public bool Habilitado { get; set; }
    }
}