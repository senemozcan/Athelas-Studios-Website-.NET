using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    [Route("api/games")]
    [ApiController]

    public class GamesController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public GamesController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllGames()
        {
            return Ok(_manager.GameService.GetAllGames(false));
        }
    }
}