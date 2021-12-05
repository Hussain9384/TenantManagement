using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain=TenantManagement.Processor.Models;

namespace TenantManagement.Processor.DbContracts
{
    public interface ITenantQueryRepository
    {
        Task<IEnumerable<Domain.Tenant>> GetTenants();

        Task<Domain.Tenant> GetTenantByCodeAndPass(string tenantCode,string tenantPassword);

        Task<Domain.Summary> GetTenantSummary();

    }
}
