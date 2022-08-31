using Project_DAW_PetruB.Entities;
using Project_DAW_PetruB.Models;
using Project_DAW_PetruB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_DAW_PetruB.Managers
{
    public class ProducerManager : IProducerManager
    {
        private readonly IProducerRepository producerRepository;
        public ProducerManager(IProducerRepository producerRepository)
        {
            this.producerRepository = producerRepository;
        }

        public async Task Create(Producer producer)
        {
            await producerRepository.Create(producer);
        }

        public async Task Delete(string id)
        {
            var producer = producerRepository
                .GetProducers()
                .FirstOrDefault(x => x.Id == id);
            await producerRepository.Delete(producer);
        }

        public List<Producer> GetProducers()
        {
            return producerRepository.GetProducers().ToList();
        }

        public async Task Update(ProducerModel producerModel)
        {
            var producer = producerRepository
                .GetProducers()
                .FirstOrDefault(x => x.Id == producerModel.Id);
            producer.Name = producerModel.Name;

            await producerRepository.Update(producer);
        }
    }
}
