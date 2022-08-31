using Project_DAW_PetruB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_DAW_PetruB.Repositories
{
    public class ProducerRepository : IProducerRepository
    {
        private readonly Context db;
        public ProducerRepository(Context context)
        {
            this.db = context;
        }
        public IQueryable<Producer> GetProducers()
        {
            var producers = db.Producers;
            return producers;
        }
        public async Task Create(Producer producer)
        {
            await db.Producers.AddAsync(producer);
            await db.SaveChangesAsync();
        }
        public async Task Update(Producer producer)
        {
            db.Producers.Update(producer);
            await db.SaveChangesAsync();
        }
        public async Task Delete(Producer producer)
        {
            db.Producers.Remove(producer);
            await db.SaveChangesAsync();
        }
    }
}
