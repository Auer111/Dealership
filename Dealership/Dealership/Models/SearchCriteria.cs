using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dealership.Models
{
    public class SearchCriteria
    {
        //Loaded in SearchViewComponent
        public List<Make> Makes { get; set; }
        public List<BodyColor> Colors { get; set; }
        public List<BodyType> BodyTypes { get; set; }

        //Used to filter results in InventoryViewComponent
        public Vehicle.VehicleCondition Condition { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string BodyType { get; set; }
        public decimal PriceMin { get; set; } = 0;
        public decimal PriceMax { get; set; } = 80000;
        public string Color { get; set; }
        public int? Page { get; set; }
    }
}
