using Microsoft.EntityFrameworkCore;
using TiendaRopa.Entidades;

namespace TiendaRopa.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSets (tablas)
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<ProductoRopa> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<VentaDetalle> VentaDetalles { get; set; }

        public DbSet<ProductoRopa> ProductoRopa { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relaciones
            modelBuilder.Entity<ProductoRopa>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Productos)
                .HasForeignKey(p => p.CategoriaId);

            modelBuilder.Entity<Venta>()
                .HasOne(v => v.Cliente)
                .WithMany(c => c.Ventas)
                .HasForeignKey(v => v.ClienteId);

            modelBuilder.Entity<VentaDetalle>()
                .HasOne(d => d.Venta)
                .WithMany(v => v.Detalles)
                .HasForeignKey(d => d.VentaId);

            modelBuilder.Entity<VentaDetalle>()
                .HasOne(d => d.Producto)
                .WithMany(p => p.Detalles)
                .HasForeignKey(d => d.ProductoId);

            // Configuración de decimales para evitar truncamiento
            modelBuilder.Entity<ProductoRopa>()
                .Property(p => p.Precio)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Venta>()
                .Property(v => v.Total)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<VentaDetalle>()
                .Property(d => d.PrecioUnitario)
                .HasColumnType("decimal(10,2)");
        }
    }
}
