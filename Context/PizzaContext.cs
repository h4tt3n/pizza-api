using System.Data.Entity;
using PizzaApi.Models;

namespace PizzaApi.Context;

public class PizzaContext : DbContext
{
    public DbSet<Pizza>? Pizzas { get; set; }
    public DbSet<Ingredient>? Ingredients { get; set; }
}