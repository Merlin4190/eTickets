
using eTickets.Data.Repository.Interfaces;
using eTickets.Data.ViewModels;
using eTickets.Models;
using eTickets.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Services.Implementations
{
    public class MoviesService : IMoviesService
    {
        private readonly IMoviesRepository _moviesRepository;

        public MoviesService(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }
        public async Task AddNewMovieAsync(NewMovieVM data)
        {
           await _moviesRepository.AddNewMovieAsync(data);
        }

        public async Task DeleteAsync(int id)
        {
            await _moviesRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            var movies = await _moviesRepository.GetAllAsync(m => m.Cinema);
            return movies;
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movie = await _moviesRepository.GetMovieByIdAsync(id);
            return movie;
        }

        public async Task<NewMovieDropdownVM> GetNewMovieDropdownValues()
        {
            return await _moviesRepository.GetNewMovieDropdownValues();
        }

        public async Task UpdateMovieAsync(UpdateMovieVM data)
        {
            await _moviesRepository.UpdateMovieAsync(data);
        }
    }
}
