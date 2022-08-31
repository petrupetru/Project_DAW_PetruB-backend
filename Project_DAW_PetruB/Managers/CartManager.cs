using Project_DAW_PetruB.Entities;
using Project_DAW_PetruB.Models;
using Project_DAW_PetruB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_DAW_PetruB.Managers
{
    public class CartManager : ICartManager
    {
        private readonly ICartRepository cartRepository;

        public CartManager(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public async Task Create(Cart cart)
        {
            await cartRepository.Create(cart);
        }

        public async Task Delete(string id)
        {
            var cart = cartRepository
                .GetCarts()
                .FirstOrDefault(x => x.Id == id);
            await cartRepository.Delete(cart);
        }

        public List<Cart> GetCarts()
        {
            return cartRepository.GetCarts().ToList();
        }

        public async Task Update(CartModel cartModel)
        {
            var cart = cartRepository
                .GetCarts()
                .FirstOrDefault(x => x.Id == cartModel.Id);
            cart.UserId = cartModel.UserId;
            await cartRepository.Update(cart);
        }
    }
}
