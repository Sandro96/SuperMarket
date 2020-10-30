using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class ProductoDTO
    {
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public int Identificador { get; set; }
        public decimal Precio { get; set; }
        public bool Habilitado { get; set; }
    }
}
