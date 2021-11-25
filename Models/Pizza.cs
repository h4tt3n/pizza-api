namespace WebApi_Net60.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsGlutenFree { get; set; }
        public List<Ingredients>? Ingredients { get; set; }
        public string? Image { get; set; }
    }
}
