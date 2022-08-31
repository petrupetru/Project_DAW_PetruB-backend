using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_DAW_PetruB.Entities
{
    public class Producer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<License> Licenses { get; set; }

    }
}
