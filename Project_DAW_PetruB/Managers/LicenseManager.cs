﻿using Microsoft.EntityFrameworkCore;
using Project_DAW_PetruB.Entities;
using Project_DAW_PetruB.Models;
using Project_DAW_PetruB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_DAW_PetruB.Managers
{
    public class LicenseManager : ILicenseManager
    {
        private readonly ILicenseRepository licenseRepository;

        public LicenseManager(ILicenseRepository licenseRepository)
        {
            this.licenseRepository = licenseRepository;
        }

        public async Task Create(License license)
        {
            await licenseRepository.Create(license);
        }

        public async Task Delete(string id)
        {
            var license = licenseRepository
                .GetLicenses()
                .FirstOrDefault(x => x.Id == id);
            await licenseRepository.Delete(license);
        }

        public LicenseModel GetById(string id)
        {
            var license = licenseRepository
                            .GetLicenses()
                            .Include(x => x.Producer)
                            .FirstOrDefault(x => x.Id == id);
            LicenseModel lm = new LicenseModel();
            lm.Id = license.Id;
            lm.Key = license.Key;
            lm.Name = license.Name;
            lm.ProducerId = license.ProducerId;
            lm.Producer = license.Producer.Name;
            return lm;
        }

        public List<License> GetLicenses()
        {
            return licenseRepository.GetLicenses().ToList();
        }

        public async Task Update(LicenseModel licenseModel)
        {
            var license = licenseRepository
                .GetLicenses()
                .FirstOrDefault(x => x.Id == licenseModel.Id);
            license.Name = licenseModel.Name;

            await licenseRepository.Update(license);
        }
    }
}
