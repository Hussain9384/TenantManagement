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
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TenantProperty> TenantProperties { get; set; }
        public DbSet<ContactDetail> ContactDetails { get; set; }
    }
}
