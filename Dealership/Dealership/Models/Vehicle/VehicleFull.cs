using Auer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Dealership.Models
{
    
    /// <summary>
    /// Vehicle full converts to VehicleFullDB to store data in ef CORE
    /// </summary>
    public class VehicleFullDB
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 ID { get; set; }
        public string VIN { get; set; }
        public string DetailsJSON { get; set; }


        public void GetUpdates(VehicleFullDB vehicleFull)
        {
            VIN = vehicleFull.VIN;
            DetailsJSON = vehicleFull.DetailsJSON;
        }

    }

    /// <summary>
    /// View Model for the full information of a vehicle
    /// </summary>
    public class VehicleFull
    {
        public string VIN { get; set; }
        public List<KVP> Details { get; set; }
        public List<string> Images { get; set; }


        public VehicleFullDB ToDB() 
        {
            return new VehicleFullDB
            {
                VIN = VIN,
                DetailsJSON = JsonConvert.SerializeObject(Details)
            }; 
        }

        public static VehicleFull FromDB(VehicleFullDB vehicleFullDB)
        {
            List<KVP> _Details = new List<KVP>();
            try 
            { 
                _Details = JsonConvert.DeserializeObject<List<KVP>>(vehicleFullDB.DetailsJSON); 
            }
            catch (Exception) { }
            return new VehicleFull
            {
                VIN = vehicleFullDB.VIN,
                Details = _Details
            };
        }

    }

}
