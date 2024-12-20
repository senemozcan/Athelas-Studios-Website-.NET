using System.Text.Json.Serialization;
using AthelasStudios.Infrastructure.Extensions;
using Entities.Models;

namespace AthelasStudios.Models
{
    public class SessionCart : Cart
    {
        [JsonIgnore]
        public ISession? Session { get; set; }
        public static Cart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()
                .HttpContext?.Session;
            SessionCart cart = session?.GetJson<SessionCart>("cart")
                ?? new SessionCart();

            cart.Session = session;
            return cart;
        }
        public override void AddItem(Game game, int quantity)
        {
            base.AddItem(game, quantity);
            Session?.SetJson<SessionCart>("cart", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session?.Remove("cart");
        }
        public override void RemoveLine(Game game)
        {
            base.RemoveLine(game);
            Session?.SetJson<SessionCart>("cart", this);
        }
    }
}