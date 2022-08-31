using Project_DAW_PetruB.Entities;
using Project_DAW_PetruB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_DAW_PetruB.Managers
{
    public interface ICartManager
    {
        List<Cart> GetCarts();
        Task Create(Cart cart);
        Task Update(CartModel cart);
        Task Delete(string id);
    }
}
