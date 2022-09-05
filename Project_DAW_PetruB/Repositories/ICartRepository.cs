using Project_DAW_PetruB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_DAW_PetruB.Repositories
{
    public interface ICartRepository
    {
        IQueryable<Cart> GetCarts();
        Task Create(Cart cart);
        Task Update(Cart cart);
        Task Delete(Cart cart);
        Task CreateLicenseCart(LicenseCart licenseCart);
        Task DeleteLicenseCart(LicenseCart licenseCart);
    }
}
