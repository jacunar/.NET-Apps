namespace PizzaApp.Model {
    public class Order {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public Address DeliveryAddress { get; set; } = new Address();
        public List<Pizza> Pizzas { get; set; } = new List<Pizza>();
        public decimal GetTotalPrice() => Pizzas.Sum(p => p.GetTotalPrice());
        public string GetFormattedTotalPrice() => GetTotalPrice().ToString("0.00");
    }
}