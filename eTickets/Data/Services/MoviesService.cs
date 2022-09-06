using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly AppDbContext _context;

        public MoviesService(AppDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task AddNewMovieAsync(NewMovieVM data)
        {
            var newMovie = new Movie()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageUrl = data.ImageUrl,
                CinemaId = data.CinemaId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                MovieCategory = data.MovieCategory,
                ProducerId = data.ProducerId,
            };

            _context.Movies.Add(newMovie);
            await _context.SaveChangesAsync();

            // Add Movie Actors
            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new ActorMovie()
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId
                };

                _context.ActorMovies.Add(newActorMovie);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movie = await _context.Movies
                .Include(m => m.Cinema)
                .Include(m => m.Producer)
                .Include(m => m.ActorMovies)
                .ThenInclude(am => am.Actor)
                .FirstOrDefaultAsync(m => m.Id == id);

            return movie;
        }

        public async Task<NewMovieDropownsVM> GetNewMovieDropownsValues()
        {
            var response = new NewMovieDropownsVM()
            {
                Actors = await _context.Actors.OrderBy(a => a.FullName).ToListAsync(),
                Producers = await _context.Producers.OrderBy(p => p.FullName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(c => c.Name).ToListAsync()
            };

            return response;
        }

        public async Task UpdateMovieAsync(NewMovieVM data)
        {
            var movie = await _context.Movies.FindAsync(data.Id);
            if (movie != null)
            {
                movie.Name = data.Name;
                movie.Description = data.Description;
                movie.Price = data.Price;
                movie.ImageUrl = data.ImageUrl;
                movie.CinemaId = data.CinemaId;
                movie.StartDate = data.StartDate;
                movie.EndDate = data.EndDate;
                movie.MovieCategory = data.MovieCategory;
                movie.ProducerId = data.ProducerId;

                await _context.SaveChangesAsync();
            }

            // Remove existing actors
            var existingActorDb = _context.ActorMovies.Where(n => n.MovieId == movie.Id).ToList();
            _context.ActorMovies.RemoveRange(existingActorDb);
            await _context.SaveChangesAsync();

            // Add Movie Actors
            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new ActorMovie()
                {
                    MovieId = movie.Id,
                    ActorId = actorId
                };

                _context.ActorMovies.Add(newActorMovie);
            }

            await _context.SaveChangesAsync();
        }
    }
}
