using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dealership.Models
{
    public class BodyTypes
    {
        public static List<BodyType> All
        {
            get {
                return new List<BodyType>()
                {
                    new BodyType{ Name = "Suv", Image="/img/bodyTypes/suv.png"},
                    new BodyType{ Name = "Sedan", Image="/img/bodyTypes/sedan.png"},
                    new BodyType{ Name = "Hatchback", Image="/img/bodyTypes/hatch.png"},
                    new BodyType{ Name = "Truck", Image="/img/bodyTypes/truck.png"},
                    new BodyType{ Name = "Coupe", Image="/img/bodyTypes/coupe.png"},
                    new BodyType{ Name = "Wagon", Image="/img/bodyTypes/wagon.png"},
                    new BodyType{ Name = "Minivan", Image="/img/bodyTypes/minivan.png"},
                    new BodyType{ Name = "Convertable", Image="/img/bodyTypes/convertible.png"},
                };
            } 
        }
    }
    public class BodyType
    {
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
