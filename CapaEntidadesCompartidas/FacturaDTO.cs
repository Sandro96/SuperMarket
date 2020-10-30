using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class FacturaDTO
    {
        public int Numero { get; set; }

        public int Numero_Cliente { get; set; }

        public decimal Total { get; set; }

        public string Usuario {get;set;}

        public DateTime Fecha { get; set; }

        public List<DetalleDTO> ListaDetalle { get; set; }
    }
}
