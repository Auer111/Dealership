using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dealership.Models
{
    public class Trim
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public List<Vehicle> Vehicles { get; set; }


        [ForeignKey("Model")]
        public long ModelId { get; set; }
        public Model Model { get; set; }
    }
}
