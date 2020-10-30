using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentacion.Models
{
    public class ProductoModel
    {
        public string Nombre { get; set; }
        public int Identificador { get; set; }
        public string Marca { get; set; }
        public decimal Precio { get; set; }
        public bool Habilitado { get; set; }
    }
}