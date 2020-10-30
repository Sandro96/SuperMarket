using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class ClienteDTO
    {
        public int Ci { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool Habilitado { get; set; }
    }
}
