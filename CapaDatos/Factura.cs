namespace Datos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Factura")]
    public partial class Factura
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Factura()
        {
            DetallesFactura = new HashSet<DetallesFactura>();
        }

        public DateTime Fecha { get; set; }

        [Key]
        public int Numero { get; set; }

        [Column("Numero Cliente")]
        public int Numero_Cliente { get; set; }

        [Required]
        [StringLength(50)]
        public string Usuario { get; set; }

        public decimal Total { get; set; }

        public virtual Cliente Cliente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetallesFactura> DetallesFactura { get; set; }

        public virtual Usuario Usuario1 { get; set; }
    }
}
