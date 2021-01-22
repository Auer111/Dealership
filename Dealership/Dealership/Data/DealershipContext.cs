using Dealership.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dealership.Data
{
    public class DealershipContext : IdentityDbContext<IdentityUser>
    {
        public DealershipContext(DbContextOptions<DealershipContext> options)
            : base(options)
        {
        }

        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Model> Vins { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Model> Trims { get; set; }
        public DbSet<BodyColor> Colors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

        }

    }
}
