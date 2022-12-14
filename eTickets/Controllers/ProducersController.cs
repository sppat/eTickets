using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ProducersController : Controller
    {
        private readonly IProducersService _producersService;

        public ProducersController(IProducersService producersService)
        {
            _producersService = producersService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index() => View(await _producersService.GetAllAsync());

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var producer = await _producersService.GetByIdAsync(id);
            if (producer == null)
                return View("NotFound");

            return View(producer);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }

            await _producersService.AddAsync(producer);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var producer = await _producersService.GetByIdAsync(id);
            if (producer == null)
                return View("NotFound");

            return View(producer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Producer newProducer)
        {
            if (!ModelState.IsValid)
                return View(newProducer);

            if (id == newProducer.Id)
            {
                await _producersService.UpdateAsync(id, newProducer);

                return RedirectToAction(nameof(Index));
            }

            return View(newProducer);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var producer = await _producersService.GetByIdAsync(id);
            if (producer == null)
                return View("NotFound");

            return View(producer);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _producersService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
