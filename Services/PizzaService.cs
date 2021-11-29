using WebApi_Net60.Models;

namespace WebApi_Net60.Services
{
    public static class PizzaService
    {
        static List<Pizza> Pizzas { get; }
        public static int nextId = 3;

        #region
        static PizzaService()
        {
            Pizzas = new List<Pizza>()
            {
                new Pizza {
                    Id = 1,
                    Name = "Classic Italian",
                    IsGlutenFree = false,
                    Ingredients = new List<Ingredient> {},
                    Image = "https://tinyurl.com/22pa66bj"
                },
                new Pizza {
                    Id = 2, 
                    Name = "Veggie", 
                    IsGlutenFree = true,
                    Ingredients = new List<Ingredient> {},
                    Image = "https://tinyurl.com/4hnxnu3r"

                },
                new Pizza {
                    Id = 3, 
                    Name = "Pepperoni special Meatlover", 
                    IsGlutenFree = true,
                    Ingredients = new List<Ingredient> {},
                    Image = "https://tinyurl.com/3kfaassu"
                },
            };
        }
        #endregion

        public static List<Pizza> GetAll() => Pizzas;

        public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

        public static void Add(Pizza pizza)
        {
            pizza.Id = ++nextId;
            Pizzas.Add(pizza);
        }

        public static void Delete(int id)
        {
            var pizza = Get(id);
            if (pizza is null)
                return;

            Pizzas.Remove(pizza);
        }

        public static void Update(Pizza pizza)
        {
            var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
            if (index == -1)
                return;

            Pizzas[index] = pizza;
        }

    }
}
