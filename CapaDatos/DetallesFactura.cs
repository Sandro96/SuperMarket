namespace Datos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DetallesFactura")]
    public partial class DetallesFactura
    {
        public int Id { get; set; }

        public int Cantidad { get; set; }

        public int Identificador { get; set; }

        public int Factura { get; set; }

        public virtual Factura Factura1 { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
