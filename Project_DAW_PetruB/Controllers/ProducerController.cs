using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_DAW_PetruB.Entities;
using Project_DAW_PetruB.Managers;
using Project_DAW_PetruB.Models;
using Project_DAW_PetruB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_DAW_PetruB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private IProducerManager producerManager;
        public ProducerController(IProducerManager producerManager)
        {
            this.producerManager = producerManager;
        }

        [HttpGet]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> GetProducers()
        {
            var producers = producerManager.GetProducers();
            return Ok(producers);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var producer = producerManager.GetProducers().FirstOrDefault(x => x.Id == id);
            return Ok(producer);
        }


        [HttpPost("create")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Create([FromBody] ProducerModel producerModel)
        {
            var newProducer = new Producer
            {
                Id = producerModel.Id,
                Name = producerModel.Name
            };
            await producerManager.Create(newProducer);

            return Ok();
        }

        [HttpPut("update")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Update([FromBody] ProducerModel producerModel)
        {
            await producerManager.Update(producerModel);

            return Ok();
        }

        [HttpDelete("delete{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            await producerManager.Delete(id);
            return Ok();
        }

        [HttpGet("count{id}")]
        public async Task<IActionResult> CountLicenses([FromRoute] string id)
        {
            var count =  producerManager.CountLicenses(id);
            return Ok(count);
        }

    }
}
