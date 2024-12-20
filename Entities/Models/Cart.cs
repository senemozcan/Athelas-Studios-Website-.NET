namespace Entities.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; }
        public Cart()
        {
            Lines = new List<CartLine>();
        }

        public virtual void AddItem(Game game, int quantity)
        {
            CartLine? line = Lines.Where(l => l.Game.GameId.Equals(game.GameId))
            .FirstOrDefault();

            if (line is null)
            {
                Lines.Add(new CartLine()
                {
                    Game = game,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Game game) =>
            Lines.RemoveAll(l => l.Game.GameId.Equals(game.GameId));

        public decimal ComputeTotalValue() => 
            Lines.Sum(e => e.Game.GamePrice * e.Quantity);
        
        public virtual void Clear() => Lines.Clear();

    }
}