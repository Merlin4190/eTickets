
using eTickets.Data.Repository.Interfaces;
using eTickets.Models;
using eTickets.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Services.Implementations
{
    public class ProducersService : IProducersService
    {
        private readonly IProducersRepository _producersRepository;

        public ProducersService(IProducersRepository producersRepository)
        {
            _producersRepository = producersRepository;
        }
        public async Task AddAsync(Producer producer)
        {
           await _producersRepository.AddAsync(producer);
        }

        public async Task DeleteAsync(int id)
        {
            await _producersRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Producer>> GetAllAsync()
        {
            var producers = await _producersRepository.GetAllAsync();
            return producers;
        }

        public async Task<Producer> GetByIdAsync(int id)
        {
            var producer = await _producersRepository.GetByIdAsync(id);
            return producer;
        }

        public async Task<Producer> UpdateAsync(int id, Producer newProducer)
        {
            await _producersRepository.UpdateAsync(id, newProducer);
            return newProducer;
        }
    }
}
