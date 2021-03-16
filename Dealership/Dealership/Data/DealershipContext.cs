using Dealership.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dealership.Data
{
    public class DealershipContext : IdentityDbContext<IdentityUser>
    {
        public IConfiguration Configuration { get; }

        public DealershipContext(DbContextOptions<DealershipContext> options,
            IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Model> Vins { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Trim> Trims { get; set; }
        public DbSet<BodyColor> Colors { get; set; }
        public DbSet<Notification> Issues { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

        //    optionsBuilder.UseMySQL(Configuration.GetConnectionString("DealershipContextConnection"));
        //}
    }
}
