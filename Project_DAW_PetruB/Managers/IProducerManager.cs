using Project_DAW_PetruB.Entities;
using Project_DAW_PetruB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_DAW_PetruB.Managers
{
    public interface IProducerManager
    {
        List<Producer> GetProducers();
        Task Create(Producer producer);
        Task Update(ProducerModel producer);
        Task Delete(string id);
        int CountLicenses(string id);
    }
}
