using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dealership.Models
{
    public class Inventory
    {
        public List<Vehicle> Vehicles { get; set; }

        public int? Page { get; set; }

        public int PageTotal { get; set; }

        public bool hasPrevious { get; set; }
        public bool hasNext { get; set; }
    }
}
