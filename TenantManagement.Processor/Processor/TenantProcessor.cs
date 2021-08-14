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
        private readonly ITenantQueryRepository _tenantQueryRepository;

        public TenantProcessor(ITenantCommandRepository tenantCommandRepository, 
                                ITenantQueryRepository tenantQueryRepository)
        {
            _tenantCommandRepository = tenantCommandRepository;
            _tenantQueryRepository = tenantQueryRepository;
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

        public async Task<IEnumerable<Tenant>> GetTenants()
        {
            var tenants= await _tenantQueryRepository.GetTenants();
            return tenants;
        }

        public Tenant UpdateTenant(Tenant tenant)
        {
            throw new NotImplementedException();
        }
    }
}
