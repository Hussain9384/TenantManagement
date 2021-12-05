using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantManagement.InfraStructure.Entities;

namespace TenantManagement.InfraStructure.Database
{
    public class TenantDatabase : DbContext
    {

        public TenantDatabase(DbContextOptions dbContextOptions):base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tenant>()
                .HasOne(t => t.Address)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tenant>()
               .HasMany(t => t.Properties)
               .WithOne()
               .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TenantProperty> TenantProperties { get; set; }
        public DbSet<ContactDetail> ContactDetails { get; set; }
    }
}
