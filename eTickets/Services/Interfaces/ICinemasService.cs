using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Services.Interfaces
{
    public interface ICinemasService
    {
        Task<IEnumerable<Cinema>> GetAllAsync();
        Task<Cinema> GetByIdAsync(int id);
        Task AddAsync(Cinema cinema);
        Task<Cinema> UpdateAsync(int id, Cinema newCinema);
        Task DeleteAsync(int id);
    }
}
