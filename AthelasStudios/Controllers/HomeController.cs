using Microsoft.AspNetCore.Mvc;

namespace AthelasStudios.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}