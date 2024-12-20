using Entities.Models;

namespace AthelasStudios.Models
{
    public class GameListViewModel
    {
        public IEnumerable<Game> Games { get; set; } = Enumerable.Empty<Game>();
        public Pagination Pagination { get; set; } = new();
        public int TotalCount => Games.Count();
    }
}