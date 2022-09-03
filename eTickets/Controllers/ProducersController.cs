using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersService _producersService;

        public ProducersController(IProducersService producersService)
        {
            _producersService = producersService;
        }

        public async Task<IActionResult> Index() => View(await _producersService.GetAllAsync());

        public async Task<IActionResult> Details(int id)
        {
            var producer = await _producersService.GetByIdAsync(id);
            if (producer == null) 
                return View("Not Found");

            return View(producer);
        }

        public IActionResult Create() => View();

        [HttpPost]
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
