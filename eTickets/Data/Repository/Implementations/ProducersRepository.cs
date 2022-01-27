using eTickets.Data.Repository.Interfaces;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Repository.Implementations
{
    public class ProducersRepository : BaseEntityRepository<Producer>, IProducersRepository
    {
        public ProducersRepository(DataContext context) : base(context) { }

    }
}
