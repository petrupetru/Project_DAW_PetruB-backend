using Project_DAW_PetruB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_DAW_PetruB.Repositories
{
    public interface ILicenseRepository
    {
        IQueryable<License> GetLicenses();
        Task Create(License license);
        Task Update(License license);
        Task Delete(License license);
    }
}
