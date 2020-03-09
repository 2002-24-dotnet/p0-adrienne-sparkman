using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Databases
{
  public class PizzaBoxDbContext : DbContext
  {
    public DbSet<Crust> Crust { get; set; }
    public DbSet<Pizza> Pizza { get; set; }
    public DbSet<Size> Size { get; set; }
    public DbSet<PizzaType> Type { get; set; }
    public DbSet<Topping> Topping { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<Store> Store { get; set; }
    public DbSet<User> User { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer("server=localhost;database=pizzaboxdb;user id=sa;password=Password12345;");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Crust>().HasKey(c => c.CrustId);
      //builder.Entity<Crust>().Property(c => c.CrustId).ValueGeneratedNever();
      builder.Entity<Pizza>().HasKey(p => p.PizzaId);
      builder.Entity<TypeTopping>().HasKey(pt => new { pt.PizzaTypeId, pt.ToppingId });
      builder.Entity<Size>().HasKey(s => s.SizeId);
      //builder.Entity<Size>().Property(s => s.SizeId).ValueGeneratedNever();
      builder.Entity<Topping>().HasKey(t => t.ToppingId);
      builder.Entity<PizzaType>().HasKey(y => y.PizzaTypeId);
      //builder.Entity<PizzaType>().Property(y => y.PizzaTypeId).ValueGeneratedNever();
      builder.Entity<Store>().HasKey(s => s.StoreId);
      builder.Entity<User>().HasKey(u => u.UserId);
      builder.Entity<Order>().HasKey(o => o.OrderId);


      builder.Entity<Crust>().HasMany(c => c.Pizzas).WithOne(p => p.Crust);
      builder.Entity<PizzaType>().HasMany(y => y.Pizzas).WithOne(p => p.PizzaType);
      builder.Entity<Size>().HasMany(s => s.Pizzas).WithOne(p => p.Size);
      builder.Entity<PizzaType>().HasMany(p => p.TypeToppings).WithOne(tt => tt.PizzaType).HasForeignKey(tt => tt.PizzaTypeId);
      builder.Entity<Topping>().HasMany(t => t.TypeToppings).WithOne(pt => pt.Topping).HasForeignKey(pt => pt.ToppingId);
      builder.Entity<Store>().HasMany(s => s.OrderHistory).WithOne(o => o.Store);
      builder.Entity<Order>().HasMany(o => o.Pizzas).WithOne(p => p.Order);
      builder.Entity<User>().HasMany(u => u.OrderHistory).WithOne(o => o.User);

      builder.Entity<Crust>().HasData(new Crust[]
      {
        new Crust() { Name = "Hand Tossed", Price = 2.00M, CrustId = 1 },
        new Crust() { Name = "New York Style", Price = 2.50M, CrustId = 2 },
        new Crust() { Name = "Thin Crust", Price = 2.50M, CrustId = 3 },
        new Crust() { Name = "Deep Dish", Price = 3.50M, CrustId = 4 },
        new Crust() { Name = "Gluten Free", Price = 2.50M, CrustId = 5 }
      });

      builder.Entity<Size>().HasData(new Size[]
      {
        new Size() { Name = "Small", Price = 6.00M, SizeId = 1 },
        new Size() { Name = "Medium", Price = 8.00M, SizeId = 2 },
        new Size() { Name = "Large", Price = 10.00M, SizeId = 3 },
      });

      builder.Entity<Topping>().HasData(new Topping[]
      {
        new Topping() { Name = "Tomato Sauce", ToppingId = 2},
        new Topping() { Name = "Alfredo Sauce", ToppingId = 3},
        new Topping() { Name = "Cheese", ToppingId = 14},
        new Topping() { Name = "Pepperoni", ToppingId = 1},
        new Topping() { Name = "Sausage", ToppingId = 4},
        new Topping() { Name = "Ham", ToppingId = 11},
        new Topping() { Name = "Bacon", ToppingId = 7},
        new Topping() { Name = "Pineapple", ToppingId = 12},
        new Topping() { Name = "Onion", ToppingId = 5},
        new Topping() { Name = "Mushroom", ToppingId = 6},
        new Topping() { Name = "Tomato", ToppingId = 8},
        new Topping() { Name = "Green Pepper", ToppingId = 9},
        new Topping() { Name = "Bannana Pepper", ToppingId = 13},
        new Topping() { Name = "Jalapeno", ToppingId = 10},
        new Topping() { Name = "Feta Cheese", ToppingId = 15}
      });


      //FIXME: TODO: PizzaTypes need toppings so intermediary table can populate
      //TODO: try seeding the intermediary
      builder.Entity<PizzaType>().HasData(new PizzaType[]
      {
        new PizzaType() { Name = "Cheese", Price = 3.00M},
        new PizzaType() { Name = "Pepperoni", Price = 5.00M},
        new PizzaType() { Name = "All Meat", Price = 8.00M},
        new PizzaType() { Name = "Super Supreme", Price = 10.00M },
        new PizzaType() { Name = "Hawaiian", Price = 7.00M }
      });

      builder.Entity<Store>().HasData(new Store[]
      {
        new Store() { Name = "Big Rico's Grease Extravaganza", Username = "bigrico", Password = "grease", StoreId = 1},
        new Store() { Name = "Peace of Pie", Username = "pizza", Password = "password", StoreId = 2},
        new Store() { Name = "'za by Tony", Username = "tony", Password = "12345", StoreId = 3}
      });

      builder.Entity<User>().HasData(new User[]
      {
        new User() { Name = "Ryan Smith", Username = "rsmith", Password = "12345", UserId = 1},
        new User() { Name = "Alexander Wilkins", Username = "awilkins", Password = "12345", UserId = 2},
        new User() { Name = "Jessa Jenkins", Username = "jjenkins", Password = "12345", UserId = 3},
        new User() { Name = "Wilma Stephens", Username = "wstephens", Password = "12345", UserId = 4}
      });
    }
  }
}
