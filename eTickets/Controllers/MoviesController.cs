using eTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        public async Task<IActionResult> Index() => View(await _moviesService.GetAllAsync(m => m.Cinema));

        public async Task<IActionResult> Details(int id)
        {
            var movie = await _moviesService.GetMovieByIdAsync(id);
            if (movie == null) return View("NotFound");

            return View(movie);
        }

        public async Task<IActionResult> Create()
        {
            var movieDropDownsData = await _moviesService.GetNewMovieDropownsValues();
            ViewBag.Cinemas = new SelectList(movieDropDownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropDownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropDownsData.Actors, "Id", "FullName");

            return View();
        }
    }
}
