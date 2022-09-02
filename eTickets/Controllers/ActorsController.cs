using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _actorsService;

        public ActorsController(IActorsService actorsService)
        {
            _actorsService = actorsService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _actorsService.GetAll();

            return View(data);
        }

        // GET /actors/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName, Bio, ProfilePictureUrl")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await _actorsService.Add(actor);

            return RedirectToAction(nameof(Index));
        }

        // GET /actors/details/1
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _actorsService.GetById(id);
            if (actorDetails == null)
            {
                return View("Empty");
            }

            return View(actorDetails);
        }
    }
}
