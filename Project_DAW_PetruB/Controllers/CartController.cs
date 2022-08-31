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
    public class CartController : ControllerBase
    {
        private ICartManager cartManager;

        public CartController(ICartManager cartManager)
        {
            this.cartManager = cartManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var cart = cartManager.GetCarts().FirstOrDefault(x => x.Id == id);
            return Ok(cart);
        }

        [HttpGet]
        [Authorize(Policy = "BasicUser")]
        public async Task<IActionResult> GetCarts()
        {
            var carts = cartManager.GetCarts();
            return Ok(carts);
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CartModel cartModel)
        {
            var newCart = new Cart
            {
                Id = cartModel.Id,
                UserId = cartModel.UserId
            };
            await cartManager.Create(newCart);

            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] CartModel cartModel)
        {
            await cartManager.Update(cartModel);

            return Ok();
        }

        [HttpDelete("delete-{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            await cartManager.Delete(id);
            return Ok();
        }

    }
}
