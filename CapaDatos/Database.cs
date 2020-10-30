namespace Datos
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Database : DbContext
    {
        public Database()
            : base("name=Database")
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<DetallesFactura> DetallesFactura { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Domicilio)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Factura)
                .WithRequired(e => e.Cliente)
                .HasForeignKey(e => e.Numero_Cliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Factura>()
                .Property(e => e.Usuario)
                .IsUnicode(false);

            modelBuilder.Entity<Factura>()
                .Property(e => e.Total)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Factura>()
                .HasMany(e => e.DetallesFactura)
                .WithRequired(e => e.Factura1)
                .HasForeignKey(e => e.Factura)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Marca)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Precio)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.DetallesFactura)
                .WithRequired(e => e.Producto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Usuario1)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Contrasena)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Factura)
                .WithRequired(e => e.Usuario1)
                .HasForeignKey(e => e.Usuario)
                .WillCascadeOnDelete(false);
        }
    }
}
