using BlazingPizza;
using Microsoft.EntityFrameworkCore;

public class PizzaStoreContext : DbContext
  {
        public PizzaStoreContext(
            DbContextOptions options) : base(options)
        {
        }

<<<<<<< HEAD
        public DbSet<Order> Orders { get; set; }

=======
public class PizzaStoreContext : DbContext
  {
        public PizzaStoreContext(
            DbContextOptions options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }

>>>>>>> c8ea36748f8cf79e41fa8f67dfcb4d926a962981
        public DbSet<Pizza> Pizzas { get; set; }

        public DbSet<PizzaSpecial> Specials { get; set; }

        public DbSet<Topping> Toppings { get; set; }

<<<<<<< HEAD
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
=======
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
>>>>>>> c8ea36748f8cf79e41fa8f67dfcb4d926a962981
            base.OnModelCreating(modelBuilder);

            // Configuring a many-to-many special -> topping relationship that is friendly for serialization
            modelBuilder.Entity<PizzaTopping>().HasKey(pst => new { pst.PizzaId, pst.ToppingId });
            modelBuilder.Entity<PizzaTopping>().HasOne<Pizza>().WithMany(ps => ps.Toppings);
            modelBuilder.Entity<PizzaTopping>().HasOne(pst => pst.Topping).WithMany();
        }

  }