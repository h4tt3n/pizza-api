using System.Data.Entity;
using WebApi_Net60.Models;

namespace WebApi_Net60.Context;

public class PizzaContext : DbContext
{
    public DbSet<Pizza>? Pizzas { get; set; }
    public DbSet<Ingredient>? Ingredients { get; set; }
}