using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_DAW_PetruB.Entities
{
    public class Role : IdentityRole
    {
        public ICollection<UserRole> UserRoles;
    }
}
