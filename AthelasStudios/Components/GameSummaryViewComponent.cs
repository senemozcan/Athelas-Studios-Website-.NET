using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace AthelasStudios.Components
{
    public class GameSummaryViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public GameSummaryViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public string Invoke()
        {
            //service
            return _manager.GameService.GetAllGames(false).Count().ToString();
        }
    }
}