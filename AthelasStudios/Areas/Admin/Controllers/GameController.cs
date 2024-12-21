using AthelasStudios.Models;
using Entities.Dtos;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Services.Contracts;

namespace AthelasStudios.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class GameController : Controller
    {
        private readonly IServiceManager _manager;

        public GameController(IServiceManager manager)
        {
            _manager = manager;
        }
        public IActionResult Index([FromQuery] GameRequestParameters p)
        {
            ViewData["Title"] = "Games";

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
                Pagination = pagination
            });
        }



        public IActionResult Create()
        {
            ViewBag.Categories = GetCategoriesSelectList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] GameDtoForInsertion gameDto, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                //file operation
                string path = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot", "images", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                gameDto.ImageUrl = String.Concat("/images/", file.FileName);
                _manager.GameService.CreateGame(gameDto);
                TempData["success"] = $"{gameDto.GameName} has been created";
                return RedirectToAction("Index");
            }
            return View();
        }
        private SelectList GetCategoriesSelectList()
        {
            return new SelectList(_manager.CategoryService.GetAllCategories(false),
            "CategoryId",
            "CategoryName", "1");
        }


        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            ViewBag.Categories = GetCategoriesSelectList();
            var model = _manager.GameService.GetOneGameForUpdate(id, false);
            ViewData["Title"] = model?.GameName;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<IActionResult> Update([FromForm] GameDtoForUpdate gameDto,  IFormFile file)
        {
            if (ModelState.IsValid)
            {
                //file operation
                string path = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot", "images", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                gameDto.ImageUrl = String.Concat("/images/", file.FileName);
                _manager.GameService.UpdateOneGame(gameDto);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _manager.GameService.DeleteOneProduct(id);
            TempData["danger"] = "The game has been removed.";
            return RedirectToAction("Index");
        }
    }
}