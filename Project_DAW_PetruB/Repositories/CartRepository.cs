using Project_DAW_PetruB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_DAW_PetruB.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly Context db;

        public CartRepository(Context db)
        {
            this.db = db;
        }

        public async Task Create(Cart cart)
        {
            await db.Carts.AddAsync(cart);
            await db.SaveChangesAsync();
        }

        public async Task Delete(Cart cart)
        {
            db.Carts.Remove(cart);
            await db.SaveChangesAsync();
        }

        public IQueryable<Cart> GetCarts()
        {
            var carts = db.Carts;
            return carts;
        }

        public async Task Update(Cart cart)
        {
            db.Carts.Update(cart);
            await db.SaveChangesAsync();
        }
    }
}
