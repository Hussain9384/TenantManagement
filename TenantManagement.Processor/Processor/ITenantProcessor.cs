using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TenantManagement.Processor.Models;

namespace TenantManagement.Processor.Processor
{
    public interface ITenantProcessor
    {
        Task<Tenant> CreateTenant(Tenant tenant);
        Task<Tenant> UpdateTenant(Tenant tenant);
        Tenant DeleteTenant(Tenant tenant); 
        Task<IEnumerable<Tenant>> GetTenants();
        Task<Summary> GetTenantSummary();

    }
}