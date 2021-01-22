using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Auer.Models;
using Newtonsoft.Json;

namespace Dealership.Models
{

    public class Vehicle
    {

        public enum VehicleCondition { Undefined, New, Used, CPO }
        public VehicleCondition Condition { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("Dealer")]
        public long DealerId { get; set; }
        public Dealer Dealer { get; set; }

        public string Vin { get; set; }


        [NotMapped]
        public string Make { get; set; }
        [NotMapped]
        public string Model { get; set; }
        [NotMapped]
        public string trim { get; set; }
        [ForeignKey("Trim")]
        public long TrimId { get; set; }
        public Trim Trim { get; set; }


        [NotMapped]
        public BodyColor _BodyColor { get; set; }
        public string Color { get; set; }
        public long ColorId { get; set; }

        public int Year { get; set; }
        public int Mileage { get; set; }
        public string Image { get; set; } = "/cars/default.jpg";
        
        [NotMapped]
        public List<string> Images { get; set; }
        public string DetailsJSON { get; set; }

        [NotMapped]
        public List<KVP> Details { 
            get{ return JsonConvert.DeserializeObject<List<KVP>>(DetailsJSON) ?? new List<KVP>(); } 
            set{ DetailsJSON = JsonConvert.SerializeObject(DetailsJSON); }
        }

        //[NotMapped]
        //public IFormFile ImgUpload { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        public void GetUpdates(Vehicle vehicle)
        {
            Vin = vehicle.Vin;
            Make = vehicle.Make;
            Model = vehicle.Model;
            Year = vehicle.Year;
            Mileage = vehicle.Mileage;
            Color = vehicle.Color;
            trim = vehicle.trim;
            Image = vehicle.Image;
            Price = vehicle.Price;
        }
    }
}
