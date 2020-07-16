using System;
using System.Collections.Generic;
using System.Text;
using Charter.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Charter.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
            .HasData(
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Name = "Captain",
                NormalizedName = "CAPTAIN"
            }
            );
        }

        public DbSet<AddressModel> address { get; set; }
        public DbSet<BaitsModel> baits { get; set; }
        public DbSet<BoatsModel> boats { get; set; }
        public DbSet<CaptainsModel> captains { get; set; }
        public DbSet<ClientsModel> clients { get; set; }
        public DbSet<InsurancesModel> insurances { get; set; }

            }
}
