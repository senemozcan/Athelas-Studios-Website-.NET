using Microsoft.AspNetCore.Mvc;
using Entities.Models;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;
using Entities.RequestParameters;
using AthelasStudios.Models;

namespace AthelasStudios.Controllers{
    public class GameController : Controller
    {
        private readonly IServiceManager _manager;

        public GameController(IServiceManager manager)
        {
            _manager = manager;
        }


        public IActionResult Index(GameRequestParameters p)
        {   
            var games = _manager.GameService.GetAllGamesWithDetails(p);
            var pagination = new Pagination()
            {
                CurrentPage = p.PageNumber,
                ItemsPerPage = p.PageSize,
                TotalItems = _manager.GameService.GetAllGames(false).Count()
            };
            return View(new GameListViewModel()
            {
                Games = games,
                Pagination = pagination,
            });
        }
        public IActionResult Get([FromRoute(Name = "id")]int id)
        {   
            //Game game = _context.Games.First(g => g.GameId.Equals(id));
            var model = _manager.GameService.GetOneGame(id, false);
            return View(model);
        }

    }
    
}