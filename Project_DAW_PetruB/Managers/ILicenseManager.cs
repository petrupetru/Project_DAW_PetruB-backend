using Project_DAW_PetruB.Entities;
using Project_DAW_PetruB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_DAW_PetruB.Managers
{
    public interface ILicenseManager
    {
        List<License> GetLicenses();
        LicenseModel GetById(string id);
        Task Create(License license);
        Task Update(LicenseModel license);
        Task Delete(string id);
    }
}
