
using eTickets.Data.Repository.Interfaces;
using eTickets.Models;
using eTickets.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Services.Implementations
{
    public class CinemasService : ICinemasService
    {
        private readonly ICinemasRepository _cinemasRepository;

        public CinemasService(ICinemasRepository cinemasRepository)
        {
            _cinemasRepository = cinemasRepository;
        }
        public async Task AddAsync(Cinema cinema)
        {
           await _cinemasRepository.AddAsync(cinema);
        }

        public async Task DeleteAsync(int id)
        {
            await _cinemasRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Cinema>> GetAllAsync()
        {
            var cinemas = await _cinemasRepository.GetAllAsync();
            return cinemas;
        }

        public async Task<Cinema> GetByIdAsync(int id)
        {
            var cinema = await _cinemasRepository.GetByIdAsync(id);
            return cinema;
        }

        public async Task<Cinema> UpdateAsync(int id, Cinema newCinema)
        {
            await _cinemasRepository.UpdateAsync(id, newCinema);
            return newCinema;
        }
    }
}
