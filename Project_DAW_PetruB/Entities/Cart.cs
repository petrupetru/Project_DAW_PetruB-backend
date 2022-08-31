using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_DAW_PetruB.Entities
{
    public class Cart
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public ICollection<LicenseCart> LicenseCarts { get; set; }
    }
}
