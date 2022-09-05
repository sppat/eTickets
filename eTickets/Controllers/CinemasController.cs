using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemasService _cinemasService;

        public CinemasController(ICinemasService cinemasService)
        {
            _cinemasService = cinemasService;
        }

        public async Task<IActionResult> Index() => View(await _cinemasService.GetAllAsync());

        public async Task<IActionResult> Details(int id)
        {
            var cinema = await _cinemasService.GetByIdAsync(id);
            if (cinema == null)
                return View("NotFound");

            return View(cinema);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Cinema cinema)
        {
            if (!ModelState.IsValid)
                return View(cinema);

            await _cinemasService.AddAsync(cinema);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var cinema = await _cinemasService.GetByIdAsync(id);
            if (cinema == null)
            {
                return View("NotFound");
            }

            return View(cinema);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Cinema newCinema)
        {
            if (!ModelState.IsValid)
                return View(newCinema);

            if (id == newCinema.Id)
            {
                await _cinemasService.UpdateAsync(id, newCinema);

                return RedirectToAction(nameof(Index));
            }

            return View(newCinema);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var cinema = await _cinemasService.GetByIdAsync(id);
            if (cinema == null)
                return View("NotFound");

            return View(cinema);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _cinemasService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
