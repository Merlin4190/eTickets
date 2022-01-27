using eTickets.Data.Repository.Interfaces;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Repository.Implementations
{
    public class MoviesRepository : BaseEntityRepository<Movie>, IMoviesRepository
    {
        private readonly DataContext _context;

        public MoviesRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewMovieAsync(NewMovieVM data)
        {
            var newMovie = new Movie()
            {
                Name = data.Name,
                Description = data.Description,
                MovieCategory = data.MovieCategory,
                ImageURL = data.ImageURL,
                Price = data.Price,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                CinemaId = data.CinemaId,
                ProducerId = data.ProducerId
            };

            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            // Add Movie Actors
            foreach (var actorId in data.ActorIds)
            {
                var movieActor = new ActorMovie()
                {
                    ActorId = actorId,
                    MovieId = newMovie.Id
                };

                await _context.ActorMovies.AddAsync(movieActor);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movie = await _context.Movies
                .Include(m => m.Cinema)
                .Include(m => m.Producer)
                .Include(m => m.ActorMovies).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(m => m.Id == id);

            return movie;
        }

        public async Task<NewMovieDropdownVM> GetNewMovieDropdownValues()
        {
            var response = new NewMovieDropdownVM()
            {
                Producers = await _context.Producers.OrderBy(p => p.FullName).ToListAsync(),
                Actors = await _context.Actors.OrderBy(a => a.FullName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(c => c.Name).ToListAsync()
            };

            return response;
        }

        public async Task UpdateMovieAsync(UpdateMovieVM data)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == data.Id);

            if (movie != null)
            {
                movie.Name = data.Name;
                movie.Description = data.Description;
                movie.MovieCategory = data.MovieCategory;
                movie.ImageURL = data.ImageURL;
                movie.Price = data.Price;
                movie.StartDate = data.StartDate;
                movie.EndDate = data.EndDate;
                movie.CinemaId = data.CinemaId;
                movie.ProducerId = data.ProducerId;

                await _context.SaveChangesAsync();
            }

            // Remove Existing Actors in the database
            var actors = await _context.ActorMovies.Where(a => a.MovieId == data.Id).ToListAsync();
            _context.ActorMovies.RemoveRange(actors);
            await _context.SaveChangesAsync();

            // Add Movie Actors
            foreach (var actorId in data.ActorIds)
            {
                var movieActor = new ActorMovie()
                {
                    ActorId = actorId,
                    MovieId = data.Id
                };

                await _context.ActorMovies.AddAsync(movieActor);
            }

            await _context.SaveChangesAsync();
        }
    }
}
