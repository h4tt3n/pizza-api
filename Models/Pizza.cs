using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_Net60.Models;

public class Pizza
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsGlutenFree { get; set; }

    [NotMapped]
    public List<Ingredient>? Ingredients { get; set; }
    public string? Image { get; set; }
    public double Price { get; set; }

    public virtual List<Pizza>? Pizzas { get; set; }
}