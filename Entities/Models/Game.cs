
namespace Entities.Models;

public class Game
{
    public int GameId { get; set; }
    public String? GameName { get; set; } = String.Empty;
    public decimal GamePrice { get; set; }
    public String? Summary { get; set; } = String.Empty;
    public String? ImageUrl { get; set; }
    public int? CategoryId { get; set; } //foreign key
    public Category? Category { get; set; } //navigation property

    public bool ShowCase { get; set; }

}
