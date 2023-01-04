using Microsoft.EntityFrameworkCore;
using NorthWind.Entities.POCOEntities;

namespace NorthWind.Repositories.EFCore.DataContext {
    public class NorthWindContext : DbContext {
        public NorthWindContext(DbContextOptions<NorthWindContext> options):
            base(options) { }

        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderDetail> OrderDetails { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Customer>().Property(c => c.Id)
                .HasMaxLength(5).IsFixedLength();
            modelBuilder.Entity<Customer>().Property(c => c.Name)
                .IsRequired().HasMaxLength(40);

            modelBuilder.Entity<Product>().Property(c => c.Name)
                .IsRequired().HasMaxLength(40);

            modelBuilder.Entity<Order>().Property(c => c.CustomerId)
                .IsRequired().HasMaxLength(5).IsFixedLength();
            modelBuilder.Entity<Order>().Property(c => c.ShipAddress)
                .IsRequired().HasMaxLength(60);
            modelBuilder.Entity<Order>().Property(c => c.ShipCity)
                .HasMaxLength(15);
            modelBuilder.Entity<Order>().Property(c => c.ShipCountry)
                .HasMaxLength(15);
            modelBuilder.Entity<Order>().Property(c => c.ShipPostalCode)
                .HasMaxLength(10);

            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => new { od.OrderId, od.ProductId });
            modelBuilder.Entity<Order>().HasOne<Customer>()
                .WithMany().HasForeignKey(o => o.CustomerId);
            modelBuilder.Entity<OrderDetail>().HasOne<Product>()
                .WithMany().HasForeignKey(o => o.ProductId);

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Capuchino" },
                new Product { Id = 2, Name = "Expreso" },
                new Product { Id = 3, Name = "Americano" });

            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = "ALFKI", Name = "Alfred F." },
                new Customer { Id = "ANATR", Name = "Ana Trujillo" },
                new Customer { Id = "ANTON", Name = "Antonio Moreno" });
        }

    }
}
