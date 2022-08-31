using Project_DAW_PetruB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_DAW_PetruB.Managers
{
    public interface IAuthManager
    {
        Task Signup(RegisterModel registerModel);
        Task<TokenModel> Login(LoginModel loginModel);
    }
}
