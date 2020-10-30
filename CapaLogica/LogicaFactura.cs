using Datos;
using EntidadesCompartidas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class LogicaFactura
    {
        RepositorioFactura RepositorioFactura = new RepositorioFactura();
        public List<FacturaDTO> ListaFactura()
        {
            return RepositorioFactura.ListaFactura();
        }
        public void FacturaNueva(FacturaDTO NuevaFactura)
        {
            RepositorioFactura.FacturaNueva(NuevaFactura);
        }
        public FacturaDTO BuscarFactura(int Numero)
        {
            return RepositorioFactura.BuscarFactura(Numero);
        }

    }
}
