using Project_DAW_PetruB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_DAW_PetruB.Managers
{
    public interface ITokenManager
    {
        Task<string> GenerateToken(User user);
    }
}
