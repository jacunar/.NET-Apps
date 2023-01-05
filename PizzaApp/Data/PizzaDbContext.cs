using PizzaApp.Model;
using Microsoft.EntityFrameworkCore;

public class PizzaDbContext : DbContext {
    public PizzaDbContext(DbContextOptions options) : base(options)
    { }
    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Customer> Customers { get; set; }
}