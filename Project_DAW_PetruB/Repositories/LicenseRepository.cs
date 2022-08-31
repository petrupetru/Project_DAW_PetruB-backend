using Project_DAW_PetruB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_DAW_PetruB.Repositories
{
    public class LicenseRepository : ILicenseRepository
    {
        private readonly Context db;
        public LicenseRepository(Context context)
        {
            this.db = context;
        }
        public async Task Create(License license)
        {
            await db.Licenses.AddAsync(license);
            await db.SaveChangesAsync();
        }

        public async Task Delete(License license)
        {
            db.Licenses.Remove(license);
            await db.SaveChangesAsync();
        }

        public IQueryable<License> GetLicenses()
        {
            var licenses = db.Licenses;
            return licenses;
        }

        public async Task Update(License license)
        {
            db.Licenses.Update(license);
            await db.SaveChangesAsync();
        }
    }
}
