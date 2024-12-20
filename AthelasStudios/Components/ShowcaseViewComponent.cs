
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace AthelasStudios.Components
{
    public class ShowcaseViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public ShowcaseViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public IViewComponentResult Invoke()
        {
            var games = _manager.GameService.GetShowcaseGames(false);
            return View(games);
        }

    }
}