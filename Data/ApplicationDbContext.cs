using System.Data.Entity;
using IndumentariaIntimaWPF.Models;

namespace IndumentariaIntimaWPF.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=DefaultConnection")
        {
            // Desactivar la verificación de compatibilidad del modelo
            Database.SetInitializer<ApplicationDbContext>(null);
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<VentasItem> VentasItems { get; set; } // Asegúrate de que esta línea esté presente

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Venta>()
                .HasKey(v => v.ID_VENTA); // Asegúrate de que solo una clave primaria está definida

            modelBuilder.Entity<Venta>()
                .HasRequired(v => v.ClienteEntidad)
                .WithMany()
                .HasForeignKey(v => v.CLIENTE);

            modelBuilder.Entity<VentasItem>()
                .HasRequired(vi => vi.Venta)
                .WithMany(v => v.VentasItems)
                .HasForeignKey(vi => vi.IDVenta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VentasItem>()
                .HasRequired(vi => vi.Producto)
                .WithMany()
                .HasForeignKey(vi => vi.IDProducto)
                .WillCascadeOnDelete(false);
        }
    }
}








