using Microsoft.AspNetCore.Mvc;

namespace AthelasStudios.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Welcome";
            return View();
        }
    }
}