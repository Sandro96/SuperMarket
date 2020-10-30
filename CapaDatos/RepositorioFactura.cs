using EntidadesCompartidas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RepositorioFactura
    {
        
        public List<FacturaDTO> ListaFactura()
        {
            using (Database Database = new Database())
            {
                var ListaFactura = from unaFactura in Database.Factura
                                   select new FacturaDTO
                                   {
                                       Fecha = unaFactura.Fecha,
                                       Numero_Cliente = unaFactura.Numero_Cliente,
                                       Numero = unaFactura.Numero,
                                       Usuario = unaFactura.Usuario,
                                       Total = unaFactura.Total
                                   };
                return ListaFactura.ToList();
            }
        
        }

        public void FacturaNueva(FacturaDTO miFactura)
        {
            Factura nuevaFactura = new Factura()
            {
                Numero = miFactura.Numero,
                Numero_Cliente = miFactura.Numero_Cliente,
                Total = miFactura.Total,
                Fecha = miFactura.Fecha,
                Usuario = miFactura.Usuario
            };

            using (Database Database = new Database())
            {
                Database.Factura.Add(nuevaFactura);
                Database.SaveChanges();

                foreach (var unDetalle in miFactura.ListaDetalle)
                {
                    DetallesFactura nuevoDetalle = new DetallesFactura()
                    {
                        Cantidad = unDetalle.Cantidad,
                        Identificador = unDetalle.Identificador,
                        Factura = nuevaFactura.Numero
                    };
                    Database.DetallesFactura.Add(nuevoDetalle);
                }

                /*Guardamos los cambios*/
                Database.SaveChanges();
            }
        }
        public FacturaDTO BuscarFactura(int Numero)
        {
            using (Database Database = new Database())
            {
                var factura = Database.Factura.Where(f => f.Numero == Numero).FirstOrDefault();

                //Convierto de Factura a FacturaDTO
                FacturaDTO BuscarFactura = new FacturaDTO()
                {
                    Fecha = factura.Fecha,
                    Numero_Cliente = factura.Numero_Cliente,
                    Numero = factura.Numero,
                    Usuario = factura.Usuario,
                    Total = factura.Total,
                    ListaDetalle = new List<DetalleDTO>()
                };

                foreach(DetallesFactura detalle in Database.DetallesFactura)
                {
                    if(detalle.Factura == BuscarFactura.Numero)
                    {
                        DetalleDTO otroDetalle = new DetalleDTO()
                        {
                            Identificador = detalle.Identificador,
                            Cantidad = detalle.Cantidad,
                            Factura = detalle.Factura,
                            Id = detalle.Id,
                        };
                        BuscarFactura.ListaDetalle.Add(otroDetalle);
                    }
                }
                return BuscarFactura;
            }
        }
    }
}
