using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_DAW_PetruB.Entities;
using Project_DAW_PetruB.Managers;
using Project_DAW_PetruB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_DAW_PetruB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseController : ControllerBase
    {
        private ILicenseManager licenseManager;
        public LicenseController(ILicenseManager licenseManager)
        {
            this.licenseManager = licenseManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var license = licenseManager.GetById(id);
            return Ok(license);
        }

        [HttpGet]
        //[Authorize(Policy = "BasicUser")]
        public async Task<IActionResult> GetLicenses()
        {
            var licenses = licenseManager.GetLicenses();
            return Ok(licenses);
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] LicenseModel licenseModel)
        {
            var newLicense = new License
            {
                Id = licenseModel.Id,
                Name = licenseModel.Name,
                Key = licenseModel.Key,
                ProducerId = licenseModel.ProducerId
            };
            await licenseManager.Create(newLicense);

            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] LicenseModel licenseModel)
        {
            await licenseManager.Update(licenseModel);

            return Ok();
        }

        [HttpDelete("delete{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            await licenseManager.Delete(id);
            return Ok();
        }
    }
}
