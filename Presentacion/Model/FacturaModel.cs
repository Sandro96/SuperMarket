using EntidadesCompartidas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentacion.Models
{
    public class FacturaModel
    {
        public int Numero { get; set; }
        public int Numero_Cliente { get; set; }
        public decimal Total { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public List<DetalleModel> ListaDetalle { get; set; }
        public int Identificador { get; set; }
        public int Cantidad { get; set; }
    }
}