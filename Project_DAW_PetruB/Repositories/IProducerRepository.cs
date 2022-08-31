using Project_DAW_PetruB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_DAW_PetruB.Repositories
{
    public interface IProducerRepository
    {
        IQueryable<Producer> GetProducers();
        Task Create(Producer producer);
        Task Update(Producer producer);
        Task Delete(Producer producer);
    }
}
