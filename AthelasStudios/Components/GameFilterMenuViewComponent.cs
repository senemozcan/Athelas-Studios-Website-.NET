using Microsoft.AspNetCore.Mvc;

namespace AthelasStudios.Components
{
    public class GameFilterMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}