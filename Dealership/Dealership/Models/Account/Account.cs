using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dealership.Models
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }
        public string CryptoPass { get; set; }


        [ForeignKey("Dealer")]
        public long DealerId { get; set; }
        public Dealer Dealer { get; set; }


        [ForeignKey("IdentityUser")]
        public string IdentityId { get; set; }
        public IdentityUser Identity { get; set; }
    }
}
