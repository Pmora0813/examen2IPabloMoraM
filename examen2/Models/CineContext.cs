namespace examen2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CineContext : DbContext
    {
        public CineContext()
            : base("name=CineContext")
        {
        }

        public virtual DbSet<compraCine> compraCine { get; set; }
        public virtual DbSet<ticket> ticket { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<compraCine>()
                .Property(e => e.descuento)
                .HasPrecision(18, 0);

            modelBuilder.Entity<compraCine>()
                .Property(e => e.cargoServicio)
                .HasPrecision(18, 0);

            modelBuilder.Entity<compraCine>()
                .Property(e => e.total)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ticket>()
                .Property(e => e.nombrePelicula)
                .IsUnicode(false);

            modelBuilder.Entity<ticket>()
                .Property(e => e.detalle)
                .IsUnicode(false);

            modelBuilder.Entity<ticket>()
                .Property(e => e.precioNino)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ticket>()
                .Property(e => e.precioRegular)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ticket>()
                .HasMany(e => e.compraCine)
                .WithRequired(e => e.ticket)
                .WillCascadeOnDelete(false);
        }
    }
}
