using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Dealership.Models
{

    public class Vehicle
    {
        public enum VehicleCondition { Undefined, New, Used, CPO }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 ID { get; set; }
        public VehicleCondition Condition {get; set;}

        [Required(ErrorMessage = "Required")]
        public string VIN { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Make { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Model { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public string Color { get; set; }
        public string Trim{ get; set; }
        public string Image { get; set; } = "/cars/default.jpg";

        //[NotMapped]
        //public IFormFile ImgUpload { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }



        public void GetUpdates(Vehicle vehicle) 
        {
            VIN = vehicle.VIN;
            Make = vehicle.Make;
            Model = vehicle.Model;
            Year = vehicle.Year;
            Mileage = vehicle.Mileage;
            Color = vehicle.Color;
            Trim = vehicle.Trim;
            Image = vehicle.Image;
            Price = vehicle.Price;
        }
    }
}
