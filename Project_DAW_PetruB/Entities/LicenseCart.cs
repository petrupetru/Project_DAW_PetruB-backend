using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_DAW_PetruB.Entities
{
    public class LicenseCart
    {
        public string LicenseId { get; set; }
        public string CartId { get; set; }
        public License License { get; set; }
        public Cart Cart { get; set; }
    }
}
