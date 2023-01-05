namespace PizzaApp.Model {
    public class Pizza {
        public const int DefaultSize = 12;
        public const int MinimumSize = 9;
        public const int MaximumSize = 18;
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int Size { get; set; }
        public decimal GetBasePrice() {
            return ((decimal)Size / (decimal)DefaultSize) * 1; //Special.BasePrice;
        }
        public decimal GetTotalPrice() {
            return GetBasePrice();
        }
        public string GetFormattedTotalPrice() {
            return GetTotalPrice().ToString("0.00");
        }
    }
}