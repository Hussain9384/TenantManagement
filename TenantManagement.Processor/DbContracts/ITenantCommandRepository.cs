using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantManagement.Processor.Models;

namespace TenantManagement.Processor.DbContracts
{
    public interface ITenantCommandRepository
    {
        Task<Tenant> CreateTenant(Tenant tenant);
        Task<Tenant> UpdateTenant(Tenant tenant);
        Task<bool> DeleteTenant(IEnumerable<long> tenant);
    }
}
