using Microsoft.EntityFrameworkCore;
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

        public List<LicenseModel> GetLicensesListed(string id)
        {
            var cart = cartRepository
                .GetCarts()
                .Include(x => x.LicenseCarts)
                .ThenInclude(lc => lc.License)
                .ThenInclude(l => l.Producer)
                .FirstOrDefault(x => x.Id == id);
            var licensecarts = cart.LicenseCarts;
            List<LicenseModel> llm = new List<LicenseModel>();
            foreach(var lc in licensecarts)
            {
                LicenseModel lm = new LicenseModel();
                lm.Id = lc.License.Id;
                lm.Key = lc.License.Key;
                lm.Name = lc.License.Name;
                lm.ProducerId = lc.License.ProducerId;
                lm.Producer = lc.License.Producer.Name;
                llm.Add(lm);
            }
            return llm;
        }

        public async Task Update(CartModel cartModel)
        {
            var cart = cartRepository
                .GetCarts()
                .FirstOrDefault(x => x.Id == cartModel.Id);
            cart.UserId = cartModel.UserId;
            await cartRepository.Update(cart);
        }

        public async Task CreateLicenseCart(LicenseCart licenseCart)
        {
            await cartRepository.CreateLicenseCart(licenseCart);
        }

        public async Task DeleteLicenseCart(LicenseCart licenseCart)
        {
            await cartRepository.DeleteLicenseCart(licenseCart);
        }
    }
}
