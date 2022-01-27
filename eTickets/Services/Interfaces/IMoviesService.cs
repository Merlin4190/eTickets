using eTickets.Data.ViewModels;
using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Services.Interfaces
{
    public interface IMoviesService
    {
        Task AddNewMovieAsync(NewMovieVM data);
        Task<IEnumerable<Movie>> GetAllAsync();
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownVM> GetNewMovieDropdownValues();
        Task UpdateMovieAsync(UpdateMovieVM data);
        Task DeleteAsync(int id);
    }
}
