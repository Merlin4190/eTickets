using eTickets.Data.ViewModels;
using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Repository.Interfaces
{
    public interface IMoviesRepository : IBaseEntityRepository<Movie>
    {
        Task AddNewMovieAsync(NewMovieVM data);
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownVM> GetNewMovieDropdownValues();
        Task UpdateMovieAsync(UpdateMovieVM data);
    }
}
