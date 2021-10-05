using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantManagement.InfraStructure.Database;
using TenantManagement.Processor.DbContracts;
using TenantManagement.Processor.Models;

namespace TenantManagement.InfraStructure.Repository
{
    public class TenantQueryRepository : ITenantQueryRepository
    {
        public TenantQueryRepository(TenantDatabase tenantDatabase,IMapper mapper )
        {
            _tenantDatabase = tenantDatabase;
            _mapper = mapper;
            _tenantDatabase.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public TenantDatabase _tenantDatabase { get; }
        public IMapper _mapper { get; }

        public async Task<Tenant> GetTenantByUserNamePass(string userName, string password)
        {
            var tenantEntity = await _tenantDatabase.Tenants.FirstAsync(t => t.Name == userName && t.Password == password);
            return _mapper.Map<Tenant>(tenantEntity);
        }

        public async Task<IEnumerable<Tenant>> GetTenants()
        {
            var entities = await _tenantDatabase.Tenants.ToListAsync();
            var res=_mapper.Map<IEnumerable<Tenant>>(entities);
            return res;
        }
    }
}
