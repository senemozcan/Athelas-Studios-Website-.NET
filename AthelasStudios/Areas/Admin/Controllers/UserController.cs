using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace AthelasStudios.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IServiceManager _manager;

        public UserController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var users = _manager.AuthService.GetAllUsers();
            return View(users);
        }
        public IActionResult Create()
        {

            return View(new UserDtoForCreation()
            {
                Roles = new HashSet<string>(
                    _manager
                    .AuthService
                    .Roles
                    .Select(r => r.Name)
                    .ToList()
                )
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] UserDtoForCreation userDto)
        {
            var result = await _manager.AuthService.CreateUSer(userDto);
            return result.Succeeded
                ? RedirectToAction("Index")
                : View();
        }
        public async Task<IActionResult> Update([FromRoute(Name ="id")]string id)
        {
            var user = await _manager.AuthService.GetOneUserForUpdate(id);
            return View(user);
        }
    }
}