﻿using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;

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
            var data = await _actorsService.GetAllAsync();

            return View(data);
        }

        // GET /actors/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName, Bio, ProfilePictureUrl")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await _actorsService.AddAsync(actor);

            return RedirectToAction(nameof(Index));
        }

        // GET /actors/details/1
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _actorsService.GetByIdAsync(id);
            if (actorDetails == null)
            {
                return View("NotFound");
            }

            return View(actorDetails);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var actor = await _actorsService.GetByIdAsync(id);
            if (actor == null)
            {
                return View("NotFound");
            }

            return View(actor);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _actorsService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _actorsService.GetByIdAsync(id);
            if (actorDetails == null)
            {
                return View("NotFound");
            }

            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            if (id == actor.Id)
            {
                await _actorsService.UpdateAsync(id, actor);

                return RedirectToAction(nameof(Index));
            }

            return View(actor);
        }
    }
}
