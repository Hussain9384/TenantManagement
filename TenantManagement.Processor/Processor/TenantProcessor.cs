using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantManagement.Processor.DbContracts;
using TenantManagement.Processor.Models;

namespace TenantManagement.Processor.Processor
{
    public class TenantProcessor : ITenantProcessor
    {
        private readonly ITenantCommandRepository _tenantCommandRepository;

        public TenantProcessor(ITenantCommandRepository tenantCommandRepository)
        {
            _tenantCommandRepository = tenantCommandRepository;
        }
        public async Task<Tenant> CreateTenant(Tenant tenant)
        {
            var res= await _tenantCommandRepository.CreateTenant(tenant);
            return res;
        }

        public Tenant DeleteTenant(Tenant tenant)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tenant> GetTenants()
        {
            throw new NotImplementedException();
        }

        public Tenant UpdateTenant(Tenant tenant)
        {
            throw new NotImplementedException();
        }
    }
}
