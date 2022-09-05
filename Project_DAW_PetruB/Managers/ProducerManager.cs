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
        private readonly ILicenseRepository licenseRepository;
        public ProducerManager(IProducerRepository producerRepository, ILicenseRepository licenseRepository)
        {
            this.licenseRepository = licenseRepository;
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

        public int CountLicenses(string id)
        {
            var prods = producerRepository.GetProducers();
            var licenses = licenseRepository.GetLicenses();

            var res = from producer in prods
                        join license in licenses
                        on producer.Id equals license.ProducerId
                        where producer.Id == id
                        group license by license.ProducerId into grp
                        select new { producerId = grp.Key, cnt = grp.Count() };
            if (res.Any())
            {
                return res.FirstOrDefault().cnt;
            }
            else
            {
                return 0;
            }
            
        }
    }
}
