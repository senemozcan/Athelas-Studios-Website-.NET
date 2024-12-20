namespace Entities.Models
{
    public class CartLine
    {
        public int CartLineId { get; set; }
        public Game Game { get; set; } = new();

        public int Quantity { get; set; }
    }
}