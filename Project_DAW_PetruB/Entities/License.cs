using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_DAW_PetruB.Entities
{
    public class License
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public string ProducerId { get; set; }
        public Producer Producer { get; set; }
        public ICollection<LicenseCart> LicenseCarts { get; set; }
    }
}
