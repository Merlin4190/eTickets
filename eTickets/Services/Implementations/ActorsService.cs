
using eTickets.Data.Repository.Interfaces;
using eTickets.Models;
using eTickets.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Services.Implementations
{
    public class ActorsService : IActorsService
    {
        private readonly IActorsRepository _actorsRepository;

        public ActorsService(IActorsRepository actorsRepository)
        {
            _actorsRepository = actorsRepository;
        }
        public async Task AddAsync(Actor actor)
        {
           await _actorsRepository.AddAsync(actor);
        }

        public async Task DeleteAsync(int id)
        {
            await _actorsRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            var actors = await _actorsRepository.GetAllAsync();
            return actors;
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            var actor = await _actorsRepository.GetByIdAsync(id);
            return actor;
        }

        public async Task<Actor> UpdateAsync(int id, Actor newActor)
        {
            await _actorsRepository.UpdateAsync(id, newActor);
            return newActor;
        }
    }
}
