using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auer.Models;

namespace Dealership.Models
{
    /// <summary>
    /// Saves Vehicle & VehicleFull data in Session before saving to db.
    /// </summary>
    public class VehicleSession
    {
        public enum SessionType { Undefined, Create, Edit }

        public VehicleSession()
        {
            Vehicle = new Vehicle();
            VehicleFull = new VehicleFull { Details = new List<KVP>(), Images = new List<string>()};
        }

        public SessionType Session { get; set; } = SessionType.Undefined;
        public Vehicle Vehicle { get; set; }
        public VehicleFull VehicleFull { get; set; }



        
    }
}
